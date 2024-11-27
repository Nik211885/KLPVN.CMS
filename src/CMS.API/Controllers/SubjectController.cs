using CMS.API.DTOs.Subject.Request;
using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/subject")]
public class SubjectController : ControllerBase
{
  private readonly IServicesWrapper _services;

  public SubjectController(IServicesWrapper services)
  {
    _services = services;
  }

  [HttpPost("create")]
  public async Task<IActionResult> CreateAuActionAsync(CreateSubjectRequest request)
  {
    var result = await _services.Subject.CreateAsync(request);
    return Ok(result);
  }
}
