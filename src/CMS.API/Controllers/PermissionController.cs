using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/permission")]
public class PermissionController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public PermissionController(IServicesWrapper services)
  {
    _services = services;
  }
}
