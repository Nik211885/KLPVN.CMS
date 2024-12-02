using CMS.API.Common.Mapping;
using CMS.API.Common.Message;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.Subject.Request;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.Subject;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;
  private readonly IUserProvider _userProvider;

  public Services(ApplicationDbContext dbContext, IUserProvider userProvider)
  {
    _context = dbContext;
    _userProvider = userProvider;
  }

  public async Task<Guid> CreateAsync(CreateSubjectRequest request)
  {
    request.IsValid();

    if (request.ParentId is not null)
    {
      var parentSubject = await _context.Subjects.FirstOrDefaultAsync(x=>x.Id == request.ParentId && x.IsActive);
      if (parentSubject is null)
      {
        throw new NotFoundException(ConstMessage.PARENT_SUBJECT_NOT_SUPPORT);
      }
    }
    var subject = request.Mapping();
    subject.IsActive = true;
    var entry = _context.Subjects.Add(subject);
    await _context.SaveChangesAsync();
    return entry.Entity.Id;
  }

  public async Task<Guid> UpdateAsync(Guid id, UpdateSubjectRequest request)
  {
    request.IsValid();
    var subject = await _context.Subjects.FirstOrDefaultAsync(x=>x.Id == id);
    if (subject is null)
    {
      throw new NotFoundException(nameof(subject));
    }
    if (request.ParentId is not null)
    {
      var parentSubject = await _context.Subjects.FirstOrDefaultAsync(x=>x.Id == request.ParentId && x.IsActive);
      if (parentSubject is null)
      {
        throw new NotFoundException(ConstMessage.PARENT_SUBJECT_NOT_SUPPORT);
      }
    }
    request.Mapping(subject);
    _context.Subjects.Update(subject);
    await _context.SaveChangesAsync();
    return subject.Id;
  }

  public async Task<Guid> ActiveAsync(Guid id)
  {
    var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
    if (subject is null)
    {
      throw new NotFoundException(nameof(subject));
    }
    subject.IsActive = !subject.IsActive;
    _context.Subjects.Update(subject);
    await _context.SaveChangesAsync();
    return subject.Id;
  }

  public async Task DeleteAsync(Guid id)
  {
    var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
    if (subject is null)
    {
      throw new NotFoundException(nameof(subject));
    }

    _context.Subjects.Remove(subject);
    await _context.SaveChangesAsync();
  }
}
