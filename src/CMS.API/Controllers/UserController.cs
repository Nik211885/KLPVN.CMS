using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public UserController(IServicesWrapper services)
  {
    _services = services;
  }
}
