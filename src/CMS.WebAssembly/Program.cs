using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CMS.WebAssembly;
using CMS.WebAssembly.Common;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<CommonHttpClientHelper>();
builder.Services.AddMudServices(config =>
{
  config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
  config.SnackbarConfiguration.PreventDuplicates = true;
  config.SnackbarConfiguration.NewestOnTop = false;
  config.SnackbarConfiguration.ShowCloseIcon = true;
  config.SnackbarConfiguration.VisibleStateDuration = 5000; // Duration in milliseconds
  config.SnackbarConfiguration.HideTransitionDuration = 500; // Transition out duration
  config.SnackbarConfiguration.ShowTransitionDuration = 500; // Transition in duration
  config.SnackbarConfiguration.SnackbarVariant = Variant.Filled; // Filled, Outlined, or Text
});
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient(ApiKey.BaseAddress, client =>
{
  client.BaseAddress = new Uri("http://localhost:5046/api/");
});
await builder.Build().RunAsync();

