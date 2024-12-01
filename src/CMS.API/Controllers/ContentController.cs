using System.ComponentModel.DataAnnotations;
using CMS.API.Services;
using CMS.Shared.DTOs.Content.Request;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/content")]
public class ContentController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public ContentController(IServicesWrapper services)
  {
    _services = services;
  }

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreateContentAsync(CreateContentRequest request)
  {
    var result = await _services.Content.CreatetAsync(request);
    return Ok(result);
  }
  [HttpPut("update")]

  public async Task<ActionResult<Guid>> UpdateContentAsync([Required] Guid id, UpdateContentRequest request)
  {
    var result = await _services.Content.UpdateAsync(id, request);
    return Ok(result);
  }

  [HttpPut("active")]
  public async Task<ActionResult<Guid>> ActiveContentAsync([Required] Guid id)
  {
    var result = await _services.Content.ActiveAsync(id);
    return Ok(result);
  }
}
