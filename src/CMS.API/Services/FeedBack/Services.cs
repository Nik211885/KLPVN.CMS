using System.Globalization;
using CMS.API.Common.Mapping;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Models;
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

  public async Task<IReadOnlyCollection<Entities.FeedBack>> GetAllFeedBackAsync(string? search = null)
  {
    var feedBacks = await GetFeedBackQuery(search).ToListAsync();
    return feedBacks;
  }

  public async Task<Pagination<Entities.FeedBack>> GetFeedBackWithPaginationAsync(int page, int size, string? search = null)
  {
    var feedBacks = await Pagination<Entities.FeedBack>
      .GetPaginationForQueryableAsync(GetFeedBackQuery(search), page, size);
    return feedBacks;
  }

  public async Task DeleteFeedBackAsync(Guid id)
  {
    var feedBack = await _context.FeedBacks.FirstOrDefaultAsync(x => x.Id == id);
    if (feedBack is null)
    {
      throw new NotFoundException(nameof(feedBack));
    }
    _context.FeedBacks.Remove(feedBack);
    await _context.SaveChangesAsync();
  }

  private IQueryable<Entities.FeedBack> GetFeedBackQuery(string? search)
  {
    IQueryable<Entities.FeedBack> feedQuery = _context.FeedBacks;
    if (!string.IsNullOrWhiteSpace(search))
    {
      var isCreateDate = DateTime.TryParseExact(
        search,
        "dd/MM/yyyy",
        CultureInfo.InvariantCulture, 
        DateTimeStyles.None,
        out var createDate);
      var searchLower = search.ToLower();
      feedQuery = feedQuery.Where(x=>x.FullName.ToLower().Contains(searchLower)
                                     || x.Phone.ToLower().Contains(searchLower)
                                     || x.Title.ToLower().Contains(searchLower)
                                     || (x.Email != null && x.Email.ToLower().Contains(searchLower))
                                     || (x.Note != null && x.Note.ToLower().Contains(searchLower))
                                     || (x.Address != null && x.Address.ToLower().Contains(searchLower))
                                     || (isCreateDate && x.CreatedDateTime.Date.AddHours(7) == createDate)
      );
    }

    feedQuery = feedQuery.OrderByDescending(x => x.CreatedDateTime).AsNoTracking();
    return feedQuery;
  }
}
