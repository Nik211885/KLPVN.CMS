using System.ComponentModel.DataAnnotations;
using CMS.API.Entities;
using CMS.API.Services;
using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Interface;
using KLPVN.Core.Models;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/feed-back")]
public class FeedBackController : ControllerBase  
{
  private readonly IServicesWrapper _services;
  private readonly IUserProvider _userProvider;

  public FeedBackController(IServicesWrapper services, IUserProvider userProvider)
  {
    _userProvider = userProvider;
    _services = services;
  }

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreateFeedBackAsync(CreateFeedBackRequest request)
  {
    var result = await _services.FeedBack.CreateAsync(request);
    return Ok(result);
  }

  [HttpGet("all")]
  public async Task<ActionResult<IReadOnlyCollection<FeedBack>>> GetAllFeedBackAsync([FromQuery] string? search)
  {
    var feedBacks = await _services.FeedBack.GetAllFeedBackAsync(search);
    return Ok(feedBacks);
  }
  [HttpGet("p")]
  public async Task<ActionResult<Pagination<FeedBack>>> GetAllFeedBackAsync([FromQuery] string? search, [Required] int page, [Required] int size)
  {
    var feedBacks = await _services.FeedBack.GetFeedBackWithPaginationAsync(page, size, search);
    return Ok(feedBacks);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteFeedBackAsync([FromQuery] Guid id)
  {
    await _services.FeedBack.DeleteAsync(id);
    return NoContent();
  }

  [HttpDelete("delete-list")]
  public async Task<IActionResult> DeleteFeedBackAsync([FromBody] List<Guid> ids)
  {
    await _services.FeedBack.DeleteListAsync(ids);
    return NoContent();
  }
}
