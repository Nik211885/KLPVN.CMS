using CMS.API.Common.Mapping;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Interface;

namespace CMS.API.Services.FeedBack;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;
  private readonly IUserProvider _userProvider;

  public Services(ApplicationDbContext dbContext, IUserProvider userProvider)
  {
    _context = dbContext;
    _userProvider = userProvider;
  }

  public async Task<Guid> CreateAsync(CreateFeedBackRequest request)
  {
    request.IsValid();
    var feedBack = request.Mapping();
    _context.FeedBacks.Add(feedBack);
    await _context.SaveChangesAsync();
    return feedBack.Id;
  }
}
