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
}
