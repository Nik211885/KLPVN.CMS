using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using KLPVN.Core.Models;

namespace KLPVN.Core.Interface;

public interface IJwtManager
{
  JwtResult GenerateTokens(string username, List<Claim> claims);

  JwtResult RefreshToken(string refreshToken, string accessToken);
  void RemoveRefreshTokenByUserName(string userName);
  (ClaimsPrincipal, JwtSecurityToken?) DecodeJwtToken(string token);
}
