using System.ComponentModel.DataAnnotations;
using CMS.API.Services;
using CMS.Shared.DTOs.Subject.Request;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/subject")]
public class SubjectController : ControllerBase
{
  private readonly IServicesWrapper _services;
  private readonly IUserProvider _userProvider;

  public SubjectController(IServicesWrapper services, IUserProvider userProvider)
  {
    _userProvider = userProvider;
    _services = services;
  }

  [HttpPost("create")]
  public async Task<IActionResult> CreateSubjectAsync(CreateSubjectRequest request)
  {
    var result = await _services.Subject.CreateAsync(request);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<ActionResult<Guid>> UpdateSubjectAsync([Required] Guid id, UpdateSubjectRequest request)
  {
    var result = await _services.Subject.UpdateAsync(id, request);
    return Ok(result);
  }

  [HttpPut("active")]
  public async Task<ActionResult<Guid>> ActiveSubjectAsync([Required] Guid id)
  {
    var result = await _services.Subject.ActiveAsync(id);
    return Ok(result);
  }
}
