using CMS.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/feed-back")]
public class FeedBackController
{
  private readonly IServicesWrapper _services;

  public FeedBackController(IServicesWrapper services)
  {
    _services = services;
  }
}
