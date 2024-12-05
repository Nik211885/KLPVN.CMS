using CMS.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("")]
public class SampleController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public SampleController(IServicesWrapper services)
  {
    _services = services;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok("I'm fine");
  }
  [Authorize]
  [HttpGet("api/sample")]
  public IActionResult GetApi()
  {
    return Ok("I'm fine sample");
  }
}
