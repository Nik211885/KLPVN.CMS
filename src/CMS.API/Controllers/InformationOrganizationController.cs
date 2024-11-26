using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/information-organization")]
public class InformationOrganizationController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public InformationOrganizationController(IServicesWrapper services)
  {
    _services = services;
  }
}
