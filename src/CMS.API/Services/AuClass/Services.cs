using CMS.API.Common.Mapping;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.AuClass.Request;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.AuClass;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;
  private readonly IUserProvider _userProvider;

  public Services(ApplicationDbContext dbContext, IUserProvider userProvider)
  {
    _context = dbContext;
    _userProvider = userProvider;
  }

  public async Task<Guid> CreateAsync(CreateAuClassRequest request)
  {
    request.IsValid();
    if (request.ParentId is not null)
    {
      var parentMenu = await _context.AuClasses.FirstOrDefaultAsync(x=>x.Id == request.ParentId);
      if (parentMenu is null)
      {
        throw new NotFoundException("Parent menu");
      }
    }

    var auClass = request.Mapping();
    _context.AuClasses.Add(auClass);
    await _context.SaveChangesAsync();
    return auClass.Id;
  }

  public async Task<Guid> UpdateAsync(Guid id, UpdateAuClassRequest request)
  {
    request.IsValid();
    var auClass = await _context.AuClasses.FirstOrDefaultAsync(x=>x.Id == id);
    if (auClass is null)
    {
      throw new NotFoundException(nameof(auClass));
    }
    if (request.ParentId is not null)
    {
      var parentMenu = await _context.AuClasses.FirstOrDefaultAsync(x=>x.Id == request.ParentId);
      if (parentMenu is null)
      {
        throw new NotFoundException("Parent menu");
      }
    }
    request.Mapping(auClass);
    _context.AuClasses.Update(auClass);
    await _context.SaveChangesAsync();
    return id;
  }

  public async Task DeleteAsync(Guid id)
  {
    var auClass = await _context.AuClasses.FirstOrDefaultAsync(x=>x.Id == id);
    if (auClass is null)
    {
      throw new NotFoundException(nameof(auClass));
    }
    _context.AuClasses.Remove(auClass);
    await _context.SaveChangesAsync();
  }
}
