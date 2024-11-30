using System.Security.Claims;
using CMS.API.Common.Message;
using CMS.API.DTOs.Au.Request;
using CMS.API.DTOs.Au.Response;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using KLPVN.Core.Interface;
using KLPVN.Core.Helper;
using KLPVN.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.API.Services.Au;

public class Services : IServices
{
  private readonly ApplicationDbContext _context;
  private readonly IUserProvider _userProvider;
  private readonly IJwtManager _jwtManager;

  public Services(ApplicationDbContext context, IUserProvider userProvider, IJwtManager jwtManager)
  {
    _jwtManager = jwtManager;
    _context = context;
    _userProvider = userProvider;
  }

  public async Task<JwtResult> LoginAsync(LoginRequest request)
  {
    if (!request.IsValid(out var errors))
    {
      throw new BadRequestException(errors);
    }

    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
    if (user is null || !user.IsActive)
    {
      throw new UnauthorizedException(ConstFailure.LOGIN_FAILURE_USER_NAME);
    }

    if (!SecurityHelper.VerifyPassword(request.Password, user.Salt, user.PasswordHash))
    {
      throw new UnauthorizedException(ConstFailure.LOGIN_FAILURE_PASSWORD);
    }
    var roles = await _context.UserRoles
      .Include(x=>x.Role)
      .Where(x=>x.UserId == user.Id)
      .Select(x=>x.Role)
      .ToListAsync();
    var roleIds = roles.Select(x => x?.Id);
    var permissions = await _context.Permissions
      .Include(x => x.ActionClass)
      .Where(x => x.ObjectId == user.Id || roleIds.Contains(x.ObjectId))
      .ToListAsync();
    var claims = new List<Claim>()
    {
      new(ClaimTypes.Name, user.Id.ToString()),
      new(ClaimTypes.NameIdentifier, user.UserName),
    };
    foreach (var p in permissions)
    {
      if (p.ActionClass is not null)
      {
        claims.Add(new Claim(ClaimTypes.Actor, p.ActionClass.Code));
      }
    }
    claims.AddRange(roles.OfType<Entities.Role>().Select(r => new Claim(ClaimTypes.Role, r.Code)));
    // return token and with menu for permission
    var jwt = _jwtManager.GenerateTokens(user.UserName, claims);
    return jwt;
  }
  
}
