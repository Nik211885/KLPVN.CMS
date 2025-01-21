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
using HttpMethod = CMS.WebAssembly.Common.HttpMethod;

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
    var loginRequest = new LoginRequest(Input.UserName, Input.Password);

    var loginMessage = await Client.SendAsync(HttpMethod.POST,
      ConstRequestUri.AuLogin, loginRequest, true);
    if (loginMessage is null)
    {
      return;
    }

    if (loginMessage.IsSuccessStatusCode)
    {
      var jwtResult = await loginMessage.Content.DecodeAsync<JwtResult>();
      await Js.InvokeVoidAsync("localStorage.setItem", "Token", jwtResult.AccessToken);
      await Js.InvokeVoidAsync("localStorage.setItem", "Refresh", jwtResult.RefreshToken);
      Navigation.NavigateTo("/admin");
      Snack.Add("Đăng nhập thành công", Severity.Success);
      return;
    }
    var errors = await loginMessage.Content.DecodeAsync<ErrorResponse>();
    Snack.Add(errors.Detail, Severity.Warning);
    isLoginButton = false;
  }

  protected override void OnAfterRender(bool firstRender)
  {
    if (firstRender)
    {
      isPassPage = true;
      StateHasChanged();
    }
  }
}
