using CMS.API.DTOs.Content.Request;
using CMS.API.Entities;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.Content;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;
  private readonly IUserProvider _userProvider;

  public Services(ApplicationDbContext dbContext, IUserProvider userProvider)
  {
    _context = dbContext;
    _userProvider = userProvider;
  }

  public async Task<Guid> CreateContentAsync(CreateContentRequest request)
  {
    if (!request.IsValid(out var errors))
    {
      throw new BadRequestException(errors);
    }

    var subjects = await _context.Subjects
      .Where(x => x.IsActive && request.SubjectId.Contains(x.Id))
      .CountAsync();
    if (request.SubjectId.Count() != subjects)
    {
      throw new BadRequestException(["Có chủ đề không hợp lễ hoặc đã không hoạt động trước đấy"]);
    }
    var content = request.Mapping();
    try
    {
      await _context.Database.BeginTransactionAsync();
      _context.Contents.Add(content);
      var subjectContents = request.SubjectId.Select(x => new SubjectContent(x, content.Id));
      _context.SubjectContents.AddRange(subjectContents);
      await _context.SaveChangesAsync();
      await _context.Database.CommitTransactionAsync();
      return content.Id;
    }
    catch (Exception ex)
    {
      await _context.Database.RollbackTransactionAsync();
      throw new ErrorProcessing();
    }
  }

  public async Task<Guid> UpdateContentAsync(Guid id, UpdateContentRequest request)
  {
    if (!request.IsValid(out var errors))
    {
      throw new BadRequestException(errors);
    }
    var content = await _context.Contents.FirstOrDefaultAsync(x=>x.Id == id);
    if (content is null)
    {
      throw new NotFoundException(nameof(content));
    }
    var subjects = await _context.Subjects
      .Where(x => x.IsActive && request.SubjectId.Contains(x.Id))
      .CountAsync();
    if (request.SubjectId.Count() != subjects)
    {
      throw new BadRequestException(["Có chủ đề không hợp lễ hoặc đã không hoạt động trước đấy"]);
    }
    request.Mapping(content);
    try
    {
      await _context.Database.BeginTransactionAsync();
      _context.Contents.Update(content);
      await _context.SubjectContents.Where(x => x.ContentId == id).ExecuteDeleteAsync();
      var subjectContents = request.SubjectId.Select(x=>new SubjectContent(x, content.Id));
      _context.SubjectContents.AddRange(subjectContents);
      await _context.SaveChangesAsync();
      await _context.Database.CommitTransactionAsync();
      return content.Id;
    }
    catch (Exception ex)
    {
      await _context.Database.RollbackTransactionAsync();
      throw new ErrorProcessing();
    }
  }
}
