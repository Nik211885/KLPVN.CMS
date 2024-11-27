using CMS.API.DTOs.AuAction.Request;
using CMS.API.Services;
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
}
