using CMS.WEB.Components;
using KLPVN.Core.Models;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiType = builder.Configuration.GetSection("ApiType").Get<ApiType>() ?? throw new ArgumentException("Not config apiTypes");
builder.Services.AddSingleton(apiType);
builder.Services.AddHttpClient(apiType.Key, (httpClient) =>
{
  httpClient.BaseAddress = new Uri(apiType.Uri);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
