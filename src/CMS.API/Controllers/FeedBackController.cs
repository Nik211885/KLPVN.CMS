using CMS.API.Services;
using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Interface;
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
}
