using System.Security.Claims;
using CMS.API.Common;
using CMS.API.Common.Message;
using CMS.API.Common.Validation;
using CMS.API.Entities;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using KLPVN.Core.Helper;
using KLPVN.Core.Interface;
using KLPVN.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoginRequest = CMS.Shared.DTOs.Au.Request.LoginRequest;

namespace CMS.API.Controllers;
[ApiController]
[Route("api/au")]
public class AuController : ControllerBase
{
  private readonly ApplicationDbContext _context;
  private readonly IJwtManager _jwtManager;
  private readonly IdentityAuthentication _identity;
  public AuController(ApplicationDbContext context, IJwtManager jwtManager, IdentityAuthentication identity)
  {
    _identity = identity;
    _context = context;
    _jwtManager = jwtManager;
  }

  [HttpPost("login")]
  public async Task<ActionResult<JwtResult>> LoginAsync(LoginRequest request)
  {
    request.IsValid();
    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName && x.IsActive);
    if (user is null)
    {
      throw new UnauthorizedException(ConstMessage.USER_NAME_NOT_EXITS);
    }

    if (!SecurityHelper.VerifyPassword(request.Password, user.Salt, user.PasswordHash))
    {
      throw new UnauthorizedException(ConstMessage.PASSORD_NOT_CORRECT);
    }

    var role = await _context.UserRoles
      .Where(x => x.UserId == user.Id)
      .Include(x => x.Role)
      .Select(x=>x.Role)
      .ToListAsync();
    var roleId = role.Select(x=>x?.Id).ToList();
    var action = await _context.Permissions
      .Where(x => x.ObjectId == user.Id || roleId.Contains(x.ObjectId))
      .Include(x=>x.ActionClass)
      .Select(x=>x.ActionClass)
      .ToListAsync();
    var claims = new List<Claim>()
    {
      new(ClaimTypes.Name, user.Id.ToString()), 
      new(ClaimTypes.NameIdentifier, user.UserName)
    };
    claims.AddRange(role.OfType<Role>().Select(r => new Claim(ClaimTypes.Role, r.Code)));
    claims.AddRange(action.OfType<AuActionClass>().Select(a=>new Claim(ClaimTypes.Actor, a.Code)));
    var jwt = _jwtManager.GenerateTokens(user.UserName, claims);
    return jwt;
  }

  [HttpPost("refresh")]
  public ActionResult<JwtResult> Refresh(string refreshToken)
  {
    string accessToken = HttpContext.Request.Headers.Authorization.ToString().Split(" ").Last();
    if (accessToken is null)
    {
      throw new UnauthorizedException("Access token is invalid");
    }
    var token = _jwtManager.RefreshToken(refreshToken, accessToken);
    return token;
  }
}
