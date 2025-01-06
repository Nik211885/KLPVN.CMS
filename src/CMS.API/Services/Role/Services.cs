using CMS.API.Common.Mapping;
using CMS.API.Common.Validation;
using CMS.API.Entities;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.Role.Request;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.Role;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;

  public Services(ApplicationDbContext dbContext)
  {
    _context = dbContext;
  }

  public async Task<Guid> CreateAsync(CreateRoleRequest request)
  {
    request.IsValid();

    if (request.ParentId is not null)
    {
      var parentRole = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.ParentId);
      if (parentRole is null)
      {
        throw new NotFoundException("Parent role");
      }
    }
    var role = request.Mapping();
    _context.Roles.Add(role);
    await _context.SaveChangesAsync();
    return role.Id;
  }

  public async Task<Guid> UpdateAsync(Guid roleId, UpdateRoleRequest request)
  {
    request.IsValid();
    var role = _context.Roles.FirstOrDefault(x => x.Id == roleId);
    if (role is null)
    {
      throw new NotFoundException(nameof(Role));
    }
    if (request.ParentId is not null)
    {
      var parentRole = _context.Roles.FirstOrDefault(x => x.Id == request.ParentId);
      if (parentRole is null)
      {
        throw new NotFoundException("Parent role");
      }
    }
    request.Mapping(role);
    _context.Roles.Update(role);
    await _context.SaveChangesAsync();
    return role.Id;
  }

  public async Task DeleteAsync(Guid roleId)
  {
    var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
    if (role is null)
    {
      throw new NotFoundException(nameof(Role));
    }
    _context.Roles.Remove(role);
    await _context.SaveChangesAsync();
  }

  public async Task AddPermissionForRoleAsync(Guid roleId, Guid auActionId)
  {
    var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
    if (role is null)
    {
      throw new NotFoundException(nameof(Role));
    }

    var auAction = await _context.AuActionClasses.FirstOrDefaultAsync(x => x.Id == auActionId);
    if (auAction is null)
    {
      throw new NotFoundException(nameof(AuActionClass));
    }
    var permission = new Entities.Permission(auActionId, roleId);
    _context.Permissions.Add(permission);
    await _context.SaveChangesAsync();
  }

  public async Task RemovePermissionForRoleAsync(Guid roleId, Guid auActionId)
  {
    var permission = await _context.Permissions
       .FirstOrDefaultAsync(x => x.ActionClassId == auActionId && x.ObjectId == roleId);
    if (permission is null)
    {
      throw new NotFoundException($"{nameof(Role)} or {nameof(AuActionClass)}");
    }
    _context.Permissions.Remove(permission);
    await _context.SaveChangesAsync();
  }
}
