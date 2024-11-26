using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/subject")]
public class SubjectController
{
  private readonly IServicesWrapper _services;

  public SubjectController(IServicesWrapper services)
  {
    _services = services;
  }
}
