using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using CMS.Shared.DTOs.Au.Request;
using CMS.WEB.Common;
using CMS.WebAssembly.Common;
using KLPVN.Core.Helper;
using KLPVN.Core.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace CMS.WebAssembly.Pages.Admin.Account;

public partial class Login
{
  private bool isPassPage = false;
  private bool isLoginButton = false;
  private string? errorMessage;

  [SupplyParameterFromForm] private InputModel Input { get; set; } = new();

  private bool isShowPass = false;
  private InputType passType = InputType.Password;
  private string passIcon = Icons.Material.Filled.VisibilityOff;

  protected override async Task OnInitializedAsync()
  {
  }

  public void ShowPass()
  {
    if (isShowPass)
    {
      isShowPass = false;
      passType = InputType.Password;
      passIcon = Icons.Material.Filled.VisibilityOff;
    }
    else
    {
      isShowPass = true;
      passType = InputType.Text;
      passIcon = Icons.Material.Filled.Visibility;
    }
  }

  private sealed class InputModel
  {
    [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
    public string UserName { get; set; } = "";

    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";
  }

  private async Task HandlerLoginAsync()
  {
    isLoginButton = true;
    var client = Factory.CreateClient(ApiKey.BaseAddress);
    var loginRequest = new LoginRequest(Input.UserName, Input.Password);
    var data = loginRequest.EncodeJsonContent();
    try
    {
      var httpResponse = await client.PostAsync(ConstRequestUri.AuLogin, data);
      if (httpResponse.IsSuccessStatusCode)
      {
        // save in local storgage
        var jwtResult = await httpResponse.Content.DecodeAsync<JwtResult>();
        await Js.InvokeVoidAsync("localStorage.setItem", "Token", jwtResult.AccessToken);
        await Js.InvokeVoidAsync("localStorage.setItem", "Refresh", jwtResult.RefreshToken);
        Navigation.NavigateTo("/admin");
        Snack.Add("Đăng nhập thành công", Severity.Success);
        return;
      }
      else
      {
        var errors = await httpResponse.Content.DecodeAsync<ErrorResponse>();
        Snack.Add(errors.Detail, Severity.Warning);
      }
    }
    catch (Exception ex)
    {
      Snack.Add("Có lỗi trong quá trình đăng nhập", Severity.Error);
    }

    isLoginButton = false;
  }

  protected override async Task OnAfterRenderAsync(bool firstRender)
  {
    if (firstRender)
    {
      var token = await Js.InvokeAsync<string?>("localStorage.getItem", "Token");
      var client = Factory.CreateClient(ApiKey.BaseAddress);
      if (token is null)
      {
        isPassPage = true;
        StateHasChanged();
        return;
      }
      else
      {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        try
        {
          var sampleResponse = await client.GetAsync("sample");
          if (sampleResponse.IsSuccessStatusCode)
          {
            Navigation.NavigateTo("/admin");
          }
          else if (sampleResponse.StatusCode == HttpStatusCode.Unauthorized)
          {
            var refreshToken = await Js.InvokeAsync<string?>("localStorage.getItem", "Refresh");
            if (refreshToken is null)
            {
              isPassPage = true;
              StateHasChanged();
              return;
            }

            var tokenResponse =
              await client.PostAsync(ConstRequestUri.AuRefresh + $"?refreshToken={refreshToken}", null);
            if (tokenResponse.IsSuccessStatusCode)
            {
              var jwtResult = await tokenResponse.Content.DecodeAsync<JwtResult>();
              await Js.InvokeVoidAsync("localStorage.setItem", "Token", jwtResult.AccessToken);
              await Js.InvokeVoidAsync("localStorage.setItem", "Refresh", jwtResult.RefreshToken);
              Navigation.NavigateTo("/admin");
            }
            else
            {
              await Js.InvokeVoidAsync("localStorage.removeItem", "Token");
              await Js.InvokeVoidAsync("localStorage.removeItem", "Refresh");
              await Js.InvokeVoidAsync("localStorage.removeItem", "Menu");
              isPassPage = true;
              StateHasChanged();
            }
          }
          else
          {
            await Js.InvokeVoidAsync("localStorage.removeItem", "Token");
            await Js.InvokeVoidAsync("localStorage.removeItem", "Refresh");
            await Js.InvokeVoidAsync("localStorage.removeItem", "Menu");
            isPassPage = true;
            StateHasChanged();
            return;
          }
        }
        catch (Exception)
        {
          await Js.InvokeVoidAsync("localStorage.removeItem", "Token");
          await Js.InvokeVoidAsync("localStorage.removeItem", "Refresh");
          await Js.InvokeVoidAsync("localStorage.removeItem", "Menu");
          isPassPage = true;
          StateHasChanged();
          return;
        }
      }
    }
  }
}
