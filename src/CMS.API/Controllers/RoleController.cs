using System.ComponentModel.DataAnnotations;
using CMS.API.DTOs.Role.Request;
using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/role")]
public class RoleController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public RoleController(IServicesWrapper services)
  {
    _services = services;
  }

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreateRoleAsync(CreateRoleRequest request)
  {
    var result = await _services.Role.CreateRoleAsync(request);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<ActionResult<Guid>> UpdateRoleAsync([Required] Guid id, UpdateRoleRequest request)
  {
    var result = await _services.Role.UpdateRoleAsync(id, request);
    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteRoleAsync([Required] Guid id)
  {
    await _services.Role.DeleteRoleAsync(id);
    return NoContent();
  }
}
