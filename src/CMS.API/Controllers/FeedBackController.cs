using CMS.API.DTOs.FeedBack.Request;
using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/feed-back")]
public class FeedBackController : ControllerBase  
{
  private readonly IServicesWrapper _services;

  public FeedBackController(IServicesWrapper services)
  {
    _services = services;
  }

  [HttpPost("create")]
  public async Task<ActionResult<Guid>> CreateFeedBackAsync(CreateFeedBackRequest request)
  {
    var result = await _services.FeedBack.CreateAsync(request);
    return Ok(result);
  }
}
