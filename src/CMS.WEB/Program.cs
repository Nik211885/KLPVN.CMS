using CMS.WEB.Common;
using CMS.WEB.Components;
using KLPVN.Core.Models;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();
builder.Services.AddHttpClient(ApiKey.BaseAddress, client =>
{
  client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiBaseAddress") 
                               ?? throw new ArgumentException("Not config api address"));
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
