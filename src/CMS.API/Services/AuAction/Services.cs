using CMS.API.Common.Mapping;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.AuAction.Request;
using CMS.Shared.DTOs.AuAction.Response;
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
    request.IsValid();
    var auAction = request.Mapping();
    var result = _context.Add(auAction);
    await _context.SaveChangesAsync();
    return result.Entity.Id;
  }

  public async Task<Guid> UpdateAsync(Guid id, UpdateAuActionRequest request)
  {
    request.IsValid();
    var auAction = await _context.AuActions.FirstOrDefaultAsync(x => x.Id == id);
    if (auAction is null)
    {
      throw new NotFoundException(nameof(auAction));
    }
    request.Mapping(auAction);
    _context.AuActions.Update(auAction);
    await _context.SaveChangesAsync();
    return id;
  }

  public async Task<AuActionResponse> GetByIdAsync(Guid id)
  {
    var auAction = await _context.AuActions.FirstOrDefaultAsync(x => x.Id == id);
    if (auAction is null)
    {
      throw new NotFoundException(nameof(auAction));
    }
    
    var auActionResponse = AuActionMapping.Mapping(auAction);
    return auActionResponse;
  }

  public async Task<IEnumerable<AuActionResponse>> GetAllAsync()
  {
    var auActions = await _context.AuActions.ToListAsync();
    var auActionsResponse = AuActionMapping.Mapping(auActions);
    return auActionsResponse;
  }

  public async Task DeleteAsync(Guid id)
  {
    var auAction = await _context.AuActions.FirstOrDefaultAsync(x => x.Id == id);
    if (auAction is null)
    {
      throw new NotFoundException(nameof(auAction));
    }
    _context.AuActions.Remove(auAction);
    await _context.SaveChangesAsync();
  }
}
