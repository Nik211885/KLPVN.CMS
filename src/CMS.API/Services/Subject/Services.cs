﻿using CMS.API.DTOs.Subject.Request;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
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
    if (!request.IsValid(out var errors))
    {
      throw new BadRequestException(errors);
    }

    if (request.ParentId is not null)
    {
      var parentSubject = await _context.Subjects.FirstOrDefaultAsync(x=>x.Id == request.ParentId && x.IsActive);
      if (parentSubject is null)
      {
        throw new NotFoundException("chủ đề cha hoặc đã không còn hỗ trợ");
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
    if (request.IsValid(out var errors))
    {
      throw new BadRequestException(errors);
    }
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
        throw new NotFoundException("chủ đề cha hoặc đã không còn hỗ trợ");
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
}
