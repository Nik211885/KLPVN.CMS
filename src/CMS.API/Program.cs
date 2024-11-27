using System.Text;
using CMS.API.Common;
using CMS.API.Infrastructure.Authentication;
using CMS.API.Infrastructure.Caching.Memory;
using CMS.API.Infrastructure.Data;
using CMS.API.Infrastructure.Notification;
using CMS.API.Services;
using KLPVN.Core.Commons;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
builder.Services.AddScoped<IJwtManager, JwtManager>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped(typeof(IServicesWrapper), typeof(ServicesWrapper));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")
                    ?? throw new ArgumentException("Not config connection string"));
});
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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
