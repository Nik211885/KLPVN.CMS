using System.ComponentModel.DataAnnotations;
using CMS.API.Services;
using CMS.Shared.DTOs.AuAction.Request;
using CMS.Shared.DTOs.AuAction.Response;
using Microsoft.AspNetCore.Http.HttpResults;
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

  [HttpGet("detail")]
  public async Task<ActionResult<AuActionResponse>> GetAuActionByIdAsync([Required] Guid id)
  {
    var result = await _services.AuAction.GetByIdAsync(id);
    return Ok(result);
  }

  [HttpGet("all")]
  public async Task<ActionResult<IEnumerable<AuActionResponse>>> GetAllAuActionAsync()
  {
    var result = await _services.AuAction.GetAllAsync();
    return Ok(result);
  }
}
