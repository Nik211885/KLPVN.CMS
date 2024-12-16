using System.Text;
using CMS.API.Common;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Authentication;
using CMS.API.Infrastructure.Caching.Memory;
using CMS.API.Infrastructure.Data;
using CMS.API.Infrastructure.Data.Seeder;
using CMS.API.Infrastructure.Notification;
using CMS.API.Services;
using KLPVN.Core.Commons;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
  options.JsonSerializerOptions.IgnoreNullValues = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INotification, EmailSender>();
builder.Services.AddSingleton<IMemoryCacheManager, MemoryCacheManager>();
var identityAuthentication =
  builder.Configuration.GetSection(nameof(IdentityAuthentication)).Get<IdentityAuthentication>()
  ?? throw new ArgumentException("IdentityAuthentication section not config or key not correct");
builder.Services.AddSingleton(identityAuthentication);
builder.Services.AddScoped<IUserProvider, UserProvider>();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IJwtManager, JwtManager>();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
                    ?? throw new ArgumentException("Not config connection string"),
    optionsBuilder => optionsBuilder.CommandTimeout(60000));
});
builder.Services.AddScoped(typeof(IServicesWrapper), typeof(ServicesWrapper));
builder.Services.AddAuthentication(options =>
  {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  })
  .AddJwtBearer(x =>
  {
    // x.RequireHttpsMetadata = identityAuthentication.RequireHttpsMetadata;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidIssuer = identityAuthentication.Issuer,
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(identityAuthentication.Secret)),
      ValidAudience = identityAuthentication.Audience,
      ValidateAudience = true,
      ValidateLifetime = true,
      ClockSkew = TimeSpan.Zero
    };
  });
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "KLPVN.CMS",
    Version = "v1"
  });
  var securityScheme = new OpenApiSecurityScheme
  {
    Name = "JWT Authentication",
    Description = "Enter JWT Bearer token **_only_**",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    BearerFormat = "JWT",
    Reference = new OpenApiReference
    {
      Id = JwtBearerDefaults.AuthenticationScheme,
      Type = ReferenceType.SecurityScheme
    }
  };
  c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
  c.AddSecurityRequirement(new OpenApiSecurityRequirement
  {
    {securityScheme, new string[] { }}
  });
  c.CustomSchemaIds(i => i.FullName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(b =>
{
    b.WithOrigins(builder.Configuration.GetValue<string>("CorsWebApp")?? "localhost")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionHandlingMiddleware>();

await SeederData.SeederAsync(app.Services);
app.Run();
