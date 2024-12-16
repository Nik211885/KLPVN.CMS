using CMS.API.Common.Mapping;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.FeedBack;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;

  public Services(ApplicationDbContext dbContext)
  {
    _context = dbContext;
  }

  public async Task<Guid> CreateAsync(CreateFeedBackRequest request)
  {
    request.IsValid();
    var feedBack = request.Mapping();
    _context.FeedBacks.Add(feedBack);
    await _context.SaveChangesAsync();
    return feedBack.Id;
  }

  public async Task DeleteAsync(Guid id)
  {
    var feedBack = await _context.FeedBacks.FirstOrDefaultAsync(x=>x.Id == id);
    if (feedBack is null)
    {
      throw new NotFoundException(nameof(feedBack));
    }
    _context.FeedBacks.Remove(feedBack);
    await _context.SaveChangesAsync();
  }
}
