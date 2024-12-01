using CMS.API.Common.Mapping;
using CMS.API.Common.Message;
using CMS.API.Common.Validation;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.User.Request;
using KLPVN.Core.Helper;
using KLPVN.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.User;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;
  private readonly IUserProvider _userProvider;

  public Services(ApplicationDbContext dbContext, IUserProvider userProvider)
  {
    _context = dbContext;
    _userProvider = userProvider;
  }
  public async Task<Guid> CreateAsync(CreateUserRequest request)
  {
    if (!request.IsValid(out var errors))
    {
      throw new BadRequestException(errors);
    }
    var requestUerName = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
    if (requestUerName is not null)
    {
      throw new BadRequestException([ConstFailure.LOGIN_FAILURE_USER_NAME]);
    }
    var user = request.Mapping();
    user.IsActive = true;
    user.Salt = SecurityHelper.GenerateSalt();
    user.PasswordHash = SecurityHelper.HashPassword(request.Password,user.Salt);
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return user.Id;
  }

  public async Task<string> ResetPasswordAsync(string userName)
  {
    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    if (user is null)
    {
      throw new NotFoundException(nameof(user));
    }
    var passwordRest = StringHelper.GeneratorRandomPassword();
    user.Salt = SecurityHelper.GenerateSalt();
    user.PasswordHash = SecurityHelper.HashPassword(passwordRest, user.Salt);
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return passwordRest;
  }

  public async Task<Guid> ChangePasswordAsync(ChangePasswordRequest request)
  {
    if (!request.IsValid(out var errors))
    {
      throw new BadRequestException(errors);
    }
    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userProvider.UserName);
    if (user is null)
    {
      throw new NotFoundException(nameof(user));
    }
    user.Salt = SecurityHelper.GenerateSalt();
    user.PasswordHash = SecurityHelper.HashPassword(request.NewPassword, user.Salt);
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return user.Id;
  }

  public async Task<Guid> ActiveUserAsync(string userName)
  {
    var user = await _context.Users.FirstOrDefaultAsync(x=>x.UserName == userName);
    if (user is null)
    {
      throw new NotFoundException(nameof(user));
    }
    user.IsActive = !user.IsActive;
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return user.Id;
  }

  public async Task<Guid> UpdateAsync(UpdateUserInformationRequest request)
  {
    if (!request.IsValid(out var errors))
    {
      throw new BadRequestException(errors);
    }
    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userProvider.UserName);
    if (user is null)
    {
      throw new NotFoundException(nameof(user));
    }
    request.Mapping(user);
    _context.Users.Update(user);
    await _context.SaveChangesAsync();
    return user.Id;
  }

  public async Task<Guid> AddRoleForUserAsync(string userName, Guid roleId)
  {
    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    if (user is null)
    {
      throw new NotFoundException(nameof(user));
    }
    var role = await _context.Roles.FirstOrDefaultAsync(x=>x.Id == roleId);
    if (role is null)
    {
      throw new NotFoundException(nameof(role));
    }
    var userRoleExits = await _context.UserRoles.FirstOrDefaultAsync(x=>x.UserId == user.Id && x.RoleId == role.Id);
    if (userRoleExits is not null)
    {
      throw new BadRequestException(["User này đã có quyền này rồi"]);
    }
    var userRole = new Entities.UserRole(user.Id, role.Id);
    _context.UserRoles.Add(userRole);
    await _context.SaveChangesAsync();
    return user.Id;
  }

  public async Task<Guid> RemoveRoleForUserAsync(string userName, Guid roleId)
  {
    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
    if (user is null)
    {
      throw new NotFoundException(nameof(user));
    }
    var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
    if (role is null)
    {
      throw new NotFoundException(nameof(role));
    }
    var userRole = await _context.UserRoles.FirstOrDefaultAsync(x=>x.RoleId == roleId && x.UserId == user.Id);
    if (userRole is null)
    {
      throw new NotFoundException("Role for user");
    }
    _context.UserRoles.Remove(userRole);
    await _context.SaveChangesAsync();
    return user.Id;
  }
}
