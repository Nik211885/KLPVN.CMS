using System.Security.Claims;
using CMS.API.Common;
using CMS.API.Common.Message;
using CMS.API.Common.Validation;
using CMS.API.Entities;
using CMS.API.Exceptions;
using CMS.API.Infrastructure.Data;
using CMS.Shared.DTOs.Au.Response;
using CMS.Shared.DTOs.User.Response;
using KLPVN.Core.Helper;
using KLPVN.Core.Interface;
using KLPVN.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
  private readonly IUserProvider _userProvider;
  public AuController(ApplicationDbContext context, IUserProvider userProvider ,IJwtManager jwtManager, IdentityAuthentication identity)
  {
    _userProvider = userProvider;
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
    var tokens = _jwtManager.GenerateTokens(user.UserName, claims);
    SetCookie(tokens);
    return tokens;
  }

  [HttpPost("refresh")]
  public ActionResult<JwtResult> Refresh(string refreshToken)
  {
    string accessToken = HttpContext.Request.Headers.Authorization.ToString().Split(" ").Last();
    if (accessToken is null)
    {
      throw new UnauthorizedException("Access token is invalid");
    }
    var tokens = _jwtManager.RefreshToken(refreshToken, accessToken);
    SetCookie(tokens);
    return tokens;
  }

  [HttpPost("logout")]
  [Authorize]
  public IActionResult Logout()
  {
    var userName = HttpContext.User.Claims
      .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
    if (userName is null)
    {
      throw new Exception("Token has not user name");
    }
    _jwtManager.RemoveRefreshTokenByUserName(userName.Value);
    return Ok();
  }

  [HttpGet("user")]
  [Authorize]
  public ActionResult<UserDecodeAccessToken> GetUserDecodeAccessToken()
  {
    var userName = HttpContext.User.Claims
      .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
    var role = HttpContext.User.Claims
      .Where(x => x.Type == ClaimTypes.Role)
      .Select(x => x.Value);
    return Ok(new UserDecodeAccessToken(userName ?? "Guest", role));
  }
  private void SetCookie(JwtResult jwt)
  {
    HttpContext.Response.Cookies.Append("Token",jwt.AccessToken, new CookieOptions()
    {
      Secure = true,
      IsEssential = true,
      Domain = _identity.Audience,
      HttpOnly = true,
      Path = "api/",
      Expires = DateTimeOffset.UtcNow.AddMinutes(_identity.AccessTokenExpiration)
    });
    HttpContext.Response.Cookies.Append("Refresh",jwt.RefreshToken, new CookieOptions()
    {
      Secure = true,
      IsEssential = true,
      HttpOnly = true,
      Path = "api/refresh",
      Domain = _identity.Audience,
      Expires = DateTimeOffset.UtcNow.AddMinutes(_identity.RefreshTokenExpiration)
    });
  }
}
