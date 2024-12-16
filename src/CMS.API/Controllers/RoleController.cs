using System.ComponentModel.DataAnnotations;
using CMS.API.Services;
using CMS.Shared.DTOs.Role.Request;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/role")]
public class RoleController : ControllerBase
{
  private readonly IServicesWrapper _services;
  private readonly IUserProvider _userProvider;

  public RoleController(IServicesWrapper services, IUserProvider userProvider)
  {
    _userProvider = userProvider;
    _services = services;
  }

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreateRoleAsync(CreateRoleRequest request)
  {
    var result = await _services.Role.CreateAsync(request);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<ActionResult<Guid>> UpdateRoleAsync([Required] Guid id, UpdateRoleRequest request)
  {
    var result = await _services.Role.UpdateAsync(id, request);
    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteRoleAsync([Required] Guid id)
  {
    await _services.Role.DeleteAsync(id);
    return NoContent();
  }
}
