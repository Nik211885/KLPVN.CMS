using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/au-class")]

public class AuClassController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public AuClassController(IServicesWrapper services)
  {
   _services = services; 
  }
}
