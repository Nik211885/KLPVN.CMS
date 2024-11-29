using CMS.API.DTOs.Au.Request;
using CMS.API.Services;
using KLPVN.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/au")]
public class AuController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public AuController(IServicesWrapper services)
  {
    _services = services;
  }

  [HttpPost("login")]
  public async Task<ActionResult<JwtResult>> LoginAsync(LoginRequest request)
  {
    var result = await _services.Au.LoginAsync(request);
    return Ok(result);
  }
}
