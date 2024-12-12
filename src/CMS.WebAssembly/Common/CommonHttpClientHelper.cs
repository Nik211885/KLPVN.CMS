using System.Net;
using System.Net.Http.Headers;
using CMS.WEB.Common;
using KLPVN.Core.Helper;
using KLPVN.Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CMS.WebAssembly.Common;

public class CommonHttpClientHelper
{
  private readonly HttpClient _client;
  private readonly IJSRuntime _jsRuntime;
  private readonly NavigationManager _navigationManager;

  public CommonHttpClientHelper(IHttpClientFactory factory,
    IJSRuntime jsRuntime, NavigationManager navigationManager)
  {
    _jsRuntime = jsRuntime;
    _navigationManager = navigationManager;
    _client = factory.CreateClient(ApiKey.BaseAddress);
  }
  public async Task<HttpResponseMessage?> SendAsync(HttpMethod method, string uri,
    object? content, bool isAu = true)
  {
    var data = content?.EncodeJsonContent();
    string? token = null;
    if (isAu)
    {
      token = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "Token");
      if (token is null)
      {
        _navigationManager.NavigateTo("/login");
        return null;
      }
      _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    var httpResponse = await SendAsync(uri, data, method);
    // add page 403 or 404 here
    if (token is not null && httpResponse.StatusCode == HttpStatusCode.Unauthorized)
    {
      var refreshToken = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "RefreshToken");
      if (refreshToken is null)
      {
        _navigationManager.NavigateTo("/login");
        return null;
      }

      var jwtTokenResponse = await _client.PostAsync(ConstRequestUri.auRefresh + $"?refreshToken={refreshToken}", null);
      if (jwtTokenResponse.IsSuccessStatusCode)
      {
        var jwtResult = await jwtTokenResponse.Content.DecodeAsync<JwtResult>();
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "Token", jwtResult.AccessToken);
        await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "Refresh", jwtResult.RefreshToken);
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtResult.AccessToken);
        return await SendAsync(uri, data, method);
      }
      else
      {
        _navigationManager.NavigateTo("/login");
      }
    }
    return httpResponse;
  }

  private Task<HttpResponseMessage> SendAsync(string uri, StringContent? data, HttpMethod method)
  {
    return method switch
    {
      HttpMethod.GET => _client.GetAsync(uri),
      HttpMethod.POST => _client.PostAsync(uri, data),
      HttpMethod.PUT => _client.PutAsync(uri, data),
      HttpMethod.DELETE => _client.DeleteAsync(uri),
      _ => throw new ArgumentException("Method not supported", nameof(method)),
    };
  }
}
