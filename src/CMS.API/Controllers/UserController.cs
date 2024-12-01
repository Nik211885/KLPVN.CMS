using CMS.API.DTOs.User.Request;
using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public UserController(IServicesWrapper services)
  {
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
    var result = await _services.User.UpdateAsync(request);
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
    var result = await _services.User.ChangePasswordAsync(request);
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
}
