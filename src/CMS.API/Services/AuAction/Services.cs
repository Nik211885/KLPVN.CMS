using CMS.API.DTOs.AuAction.Request;
using CMS.API.Infrastructure.Data;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.AuAction;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;
  private readonly IUserProvider _userProvider;

  public Services(ApplicationDbContext dbContext, IUserProvider userProvider)
  {
    _context = dbContext;
    _userProvider = userProvider;
  }

  public async Task<Guid> CreateAsync(CreateAuActionRequest request)
  {
    if (!request.IsValid(out var errors))
    {
      throw new ArgumentException(string.Join(", ", errors));  
    }
    var auAction = request.Mapping();
    var result = _context.Add(auAction);
    await _context.SaveChangesAsync();
    return result.Entity.Id;
  }
}
