using CMS.API.DTOs.Subject.Request;
using CMS.API.Infrastructure.Data;
using KLPVN.Core.Interface;
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
      throw new ArgumentException(string.Join(", ", errors));  
    }
    var subject = request.Mapping();
    var entry = _context.Subjects.Add(subject);
    await _context.SaveChangesAsync();
    return entry.Entity.Id;
  }
}
