using System.Security.Claims;
using CMS.API.Services;
using CMS.Shared.DTOs.AuClass.Response;
using CMS.Shared.DTOs.User.Request;
using CMS.Shared.DTOs.User.Response;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  private readonly IServicesWrapper _services;
  private readonly IUserProvider _userProvider;

  public UserController(IServicesWrapper services, IUserProvider userProvider)
  {
    _userProvider = userProvider;
    _services = services;
  }

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreateNewUserAsync(CreateUserRequest request)
  {
    var result = await _services.User.CreateAsync(request);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<ActionResult<Guid>> UpdateUserAsync(UpdateUserInformationRequest request)
  {
    var result = await _services.User.UpdateAsync(_userProvider.UserName, request);
    return Ok(result);
  }

  [HttpPut("active")]
  public async Task<ActionResult<Guid>> ActiveUserAsync(string userName)
  {
    var result = await _services.User.ActiveUserAsync(userName);
    return Ok(result);
  }

  [HttpPut("change-password")]
  public async Task<ActionResult<Guid>> ChangePasswordAsync(ChangePasswordRequest request)
  {
    var result = await _services.User.ChangePasswordAsync(_userProvider.UserName,request);
    return Ok(result);
  }

  [HttpPut("reset-password")]
  public async Task<ActionResult<string>> ResetPasswordAsync(string userName)
  {
    var result = await _services.User.ResetPasswordAsync(userName);
    return Ok(result);
  }

  [HttpPost("add-role")]
  public async Task<ActionResult<Guid>> AddRoleForUserAsync(string userName, Guid roleId)
  {
    var result = await _services.User.AddRoleForUserAsync(userName, roleId);
    return Ok(result);
  }

  [HttpDelete("remove-role")]
  public async Task<ActionResult<Guid>> RemoveRoleForUserAsync(string userName, Guid roleId)
  {
    var result = await _services.User.RemoveRoleForUserAsync(userName, roleId);
    return Ok(result);
  }

  [HttpGet("menu")]
  [Authorize]
  public async Task<ActionResult<MenuTreeResponse>> GetMenuTreeForUserAsync()
  {
    var permissionCode = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Actor)
      .Select(x=>x.Value);
    var result = await _services.User.GetMenuTreeForUserAsync(permissionCode);
    return result;
  }

  [HttpGet("information")]
  public async Task<UserDetailResponse> GetUserDetailAsync()
  {
    var result = await _services.User.GetUserDetailsAsync(_userProvider.UserName);
    return result;
  }

  [HttpPut("upload-avatar")]
  [Authorize]
  public async Task<IActionResult> UploadAvatarAsync(string avatarUrl)
  {
    var result = await _services.User.UploadAvatarAsync(_userProvider.UserName, avatarUrl);
    return Ok(result);
  }
}
