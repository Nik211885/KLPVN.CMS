using System.ComponentModel.DataAnnotations;
using CMS.API.Services;
using CMS.Shared.DTOs.InfromationOrgaization.Request;
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

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreateInformationOrganizationAsync(CreateInformationOrganizationRequest request)
  {
    var result = await _services.InformationOrganization.CreateAsync(request);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<ActionResult<Guid>> UpdateInformationOrganizationAsync([Required] Guid id,
    UpdateInformationOrganizationRequest request)
  {
    var result = await _services.InformationOrganization.UpdateAsync(id, request);
    return Ok(result);
  }

  [HttpPut("active")]
  public async Task<ActionResult<Guid>> ActiveInformationOrganizationAsync([Required] Guid id)
  {
    var result = await _services.InformationOrganization.ActiveAsync(id);
    return Ok(result);
  }
}
