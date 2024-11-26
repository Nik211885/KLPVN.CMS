using CMS.API.Services;
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
}
