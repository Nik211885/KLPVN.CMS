using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using CMS.WEB.Common;
using KLPVN.Core.Helper;
using KLPVN.Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace CMS.WebAssembly.Common;

public class CommonHttpClientHelper
{
  private readonly HttpClient _client;
  private readonly IJSRuntime _jsRuntime;
  private readonly NavigationManager _navigationManager;
  private readonly ISnackbar _snackbar;

  public CommonHttpClientHelper(IHttpClientFactory factory,
    IJSRuntime jsRuntime, NavigationManager navigationManager, ISnackbar snackbar)
  {
    _snackbar = snackbar;
    _jsRuntime = jsRuntime;
    _navigationManager = navigationManager;
    _client = factory.CreateClient(ApiKey.BaseAddress);
  }
  public async Task<HttpResponseMessage?> SendAsync(HttpMethod method, string uri,
    object? content, bool isAu = true)
  {
    try
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
      switch (httpResponse.StatusCode)
      {
        case HttpStatusCode.NotFound:
          _navigationManager.NavigateTo("/404ErrorNotFoundPage");
          return null;
        case HttpStatusCode.Forbidden:
          _navigationManager.NavigateTo("/403ErrorForbiddenPage");
          return null;
        case HttpStatusCode.InternalServerError:
          _navigationManager.NavigateTo("/500ErrorInternalServer");
          return null;
          
      }

      if (token is null || httpResponse.StatusCode != HttpStatusCode.Unauthorized)
      {
        return httpResponse;
      }
  
      var refreshToken = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "RefreshToken");
      if (refreshToken is null)
      {
        _navigationManager.NavigateTo("/login");
        return null;
      }

      var jwtTokenResponse =
        await _client.PostAsync(ConstRequestUri.AuRefresh + $"?refreshToken={refreshToken}", null);
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

      return httpResponse;
    }
    catch (HttpRequestException ex)
    {
      _navigationManager.NavigateTo("/ErrorNoHaveInternet");
    }
    catch (Exception ex)
    {
      _navigationManager.NavigateTo("/500ErrorInternalServer");
    }

    return null;
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
