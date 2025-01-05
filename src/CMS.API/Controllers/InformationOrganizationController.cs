using System.ComponentModel.DataAnnotations;
using CMS.API.Entities;
using CMS.API.Services;
using CMS.Shared.DTOs.InfromationOrgaization.Request;
using CMS.Shared.DTOs.InfromationOrgaization.Response;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/information-organization")]
public class InformationOrganizationController : ControllerBase
{
  private readonly IServicesWrapper _services;
  private readonly IUserProvider _userProvider;

  public InformationOrganizationController(IServicesWrapper services, IUserProvider userProvider)
  {
    _userProvider = userProvider;
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

  [HttpGet("all")]
  public async Task<ActionResult<List<InformationOrganizationResponse>>> GetAllInformationOrganizationsAsync()
  {
    var result = await _services.InformationOrganization.GetAllAsync();
    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteInformationOrganizationAsync([Required] Guid id)
  {
    await _services.InformationOrganization.DeleteAsync(id);
    return NoContent();
  }

  [HttpPut("upload-icon")]
  public async Task<IActionResult> UploadInformationOrganizationIconAsync([Required] Guid id,[Required] string iconUrl)
  {
    var result = await _services.InformationOrganization.UploadIconAsync(id, iconUrl);
    return Ok(result);
  }
}
