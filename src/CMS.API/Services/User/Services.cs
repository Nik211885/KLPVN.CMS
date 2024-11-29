using CMS.API.Common.Message;
using CMS.API.DTOs.User.Request;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
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
  public async Task<Guid> CreateNewUserAsync(CreateUserRequest request)
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

  public async Task<string> RestPasswordAsync(string userName)
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

  public async Task<Guid> UpdateUserAsync(UpdateUserInformationRequest request)
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
}
