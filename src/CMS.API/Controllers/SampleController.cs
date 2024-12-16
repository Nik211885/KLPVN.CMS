using CMS.API.Services;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("")]
public class SampleController : ControllerBase
{
  private readonly IServicesWrapper _services;
  private readonly IUserProvider _userProvider;

  public SampleController(IServicesWrapper services, IUserProvider userProvider)
  {
    _userProvider = userProvider;
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
