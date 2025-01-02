using CMS.API.Common.Mapping;
using CMS.API.Common.Message;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.Subject.Request;
using CMS.Shared.DTOs.Subject.Response;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.Subject;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;

  public Services(ApplicationDbContext dbContext)
  {
    _context = dbContext;
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

  public async Task<SubjectResponse> GetAllTreeSubjectAsync(bool? isActive)
  {
    var subjectsResponse = new SubjectResponse();
    var allSubjectQuery = _context.Subjects.AsQueryable();
    if (isActive is not null)
    {
      allSubjectQuery = allSubjectQuery.Where(x => x.IsActive == isActive);
    }
    var rootParent = await _context.Subjects.Where(x => x.ParentId == null).OrderBy(x=>x.DisplayOrder).ToListAsync();
    var childSubjects = await _context.Subjects.Where(x => x.ParentId != null).OrderBy(x=>x.DisplayOrder).ToListAsync();
    foreach (var r in rootParent)
    {
      subjectsResponse.SubjectsList.Add(RecursiveSubject(r.Mapping(), childSubjects));
    }
    return subjectsResponse;
  }

  public async Task<List<Subjects>> GetAllSubjectsAsync(bool? isActive = true)
  {
    var subjectsResponse = new SubjectResponse();
    var allSubjectQuery = _context.Subjects.AsQueryable();
    if (isActive is not null)
    {
      allSubjectQuery = allSubjectQuery.Where(x => x.IsActive == isActive);
    }
    
    var subject = await allSubjectQuery.OrderBy(x=>x.DisplayOrder).ToListAsync();
    return subject.Mapping();
  }

  private Subjects RecursiveSubject(Subjects currentSubject,
    List<Entities.Subject> childSubjects)
  {
    var child = childSubjects.Where(x => x.ParentId == currentSubject.Id).ToList().Mapping();
    foreach (var c in child)
    {
      RecursiveSubject(c, childSubjects);
    }

    currentSubject.Subject.AddRange(child);
    return currentSubject;
  }
}
