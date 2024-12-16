using System.ComponentModel.DataAnnotations;
using CMS.API.Services;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/permission")]
public class PermissionController : ControllerBase
{
  private readonly IServicesWrapper _services;
  private readonly IUserProvider _userProvider;
  public PermissionController(IServicesWrapper services, IUserProvider userProvider)
  {
    _userProvider = userProvider;
    _services = services;
  }

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreatePermissionAsync([Required] Guid objectId, [Required] Guid auActionClassId)
  {
    var result = await _services.Permission.CreateAsync(objectId, auActionClassId);
    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<ActionResult<Guid>> DeletePermissionAsync([Required] Guid objectId, [Required] Guid auActionClassId)
  {
    await _services.Permission.DeleteAsync(objectId, auActionClassId);
    return NoContent();
  }
}
