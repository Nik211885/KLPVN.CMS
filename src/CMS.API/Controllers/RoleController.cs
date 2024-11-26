using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/role")]
public class RoleController
{
  private readonly IServicesWrapper _services;

  public RoleController(IServicesWrapper services)
  {
    _services = services;
  }
}
