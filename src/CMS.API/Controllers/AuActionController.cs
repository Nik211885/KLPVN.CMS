using System.ComponentModel.DataAnnotations;
using CMS.API.Services;
using CMS.Shared.DTOs.AuAction.Request;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/au-action")]
public class AuActionController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public AuActionController(IServicesWrapper services)
  {
    _services = services;
  }

  [HttpPost("create")]
  public async Task<IActionResult> CreateAuActionAsync(CreateAuActionRequest request)
  {
    var result = await _services.AuAction.CreateAsync(request);
    return Ok(result);
  }

  [HttpPost("update")]
  public async Task<ActionResult<Guid>> UpdateAuActionAsync([Required] Guid id, UpdateAuActionRequest request)
  {
    var result = await _services.AuAction.UpdateAsync(id, request);
    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteAuActionAsync([Required] Guid id)
  {
    await _services.AuAction.DeleteAsync(id);
    return NoContent();
  }
}
