using CMS.API.DTOs.User.Request;
using CMS.API.Services;
using Microsoft.AspNetCore.Identity.Data;
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
    var result = await _services.User.CreateNewUserAsync(request);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<ActionResult<Guid>> UpdateUserAsync(UpdateUserInformationRequest request)
  {
    var result = await _services.User.UpdateUserAsync(request);
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
    var result = await _services.User.RestPasswordAsync(userName);
    return Ok(result);
  }
}
