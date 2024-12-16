using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.Permission;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;

  public Services(ApplicationDbContext dbContext)
  {
    _context = dbContext;
  }

  public async Task<Guid> CreateAsync(Guid objectId, Guid auActionClassId)
  {
    var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == objectId);
    var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == objectId);
    var objId = user?.Id ?? role?.Id;
    if (objId is null)
    {
      throw new NotFoundException("Đối tượng để gán quyền");
    }

    var auActionClass = await _context.AuActionClasses.FirstOrDefaultAsync(x => x.Id == auActionClassId);
    if (auActionClass is null)
    {
      throw new NotFoundException("Hành động của đối tượng");
    }
    var permission = new Entities.Permission(auActionClassId, objectId);
    _context.Permissions.Add(permission);
    await _context.SaveChangesAsync();
    return auActionClassId;
  }

  public async Task DeleteAsync(Guid objectId, Guid auActionClassId)
  {
    var permission = await _context.Permissions
        .Where(x => x.ObjectId == objectId && x.ActionClassId == auActionClassId)
        .FirstOrDefaultAsync();
    if (permission is null)
    {
      throw new NotFoundException(nameof(permission));
    }
    _context.Permissions.Remove(permission);
    await _context.SaveChangesAsync();
  }
}
