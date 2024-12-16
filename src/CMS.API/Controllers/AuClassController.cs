using System.ComponentModel.DataAnnotations;
using CMS.API.Services;
using CMS.Shared.DTOs.AuClass.Request;
using CMS.Shared.DTOs.AuClass.Response;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/au-class")]

public class AuClassController : ControllerBase
{
  private readonly IServicesWrapper _services;
  private readonly IUserProvider _userProvider;

  public AuClassController(IServicesWrapper services, IUserProvider userProvider)
  {
    _userProvider = userProvider;
   _services = services; 
  }

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreateAuClassAsync(CreateAuClassRequest request)
  {
    var result = await _services.AuClass.CreateAsync(request);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<ActionResult<Guid>> UpdateAuClassAsync([Required] Guid id, UpdateAuClassRequest request)
  {
    var result = await _services.AuClass.UpdateAsync(id, request);
    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteAuClassAsync([Required] Guid id)
  {
    await _services.AuClass.DeleteAsync(id);
    return NoContent();
  }
}
