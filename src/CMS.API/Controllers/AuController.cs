using CMS.API.Services;
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
}
