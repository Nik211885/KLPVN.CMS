using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CMS.API.Common;
using KLPVN.Core.Helper;
using KLPVN.Core.Interface;
using KLPVN.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace CMS.API.Infrastructure.Authentication;

public class JwtManager : IJwtManager
{
  private readonly IdentityAuthentication _identityAuthentication;
  private readonly IMemoryCache _memoryCache;
  private readonly byte[] _secret;
  public JwtManager(IdentityAuthentication identityAuthentication, IMemoryCache memoryCache)
  {
    _identityAuthentication = identityAuthentication;
    _memoryCache = memoryCache;
    _secret = Encoding.UTF8.GetBytes(_identityAuthentication.Secret);
  }
  // make sure claims have user name is claims type name
  public JwtResult GenerateTokens(string userName, List<Claim> claims)
  {
    claims.Add(new Claim(ClaimTypes.NameIdentifier, userName));
    var jwtToken = new JwtSecurityToken(
      issuer: _identityAuthentication.Issuer,
      claims: claims,
      audience: _identityAuthentication.Audience,
      expires: DateTime.UtcNow.AddMinutes(_identityAuthentication.AccessTokenExpiration),
      signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256)
    );
    var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
    var refreshToken = GenerateRefreshToken();
    _memoryCache.Set(userName, refreshToken, DateTime.Now.AddMinutes(_identityAuthentication.RefreshTokenExpiration));
    return new JwtResult(accessToken, refreshToken);
    // add in memory caching
  }

  public JwtResult RefreshToken(string refreshToken, string accessToken)
  {
      // check refresh token is pass signal
      var (principal, jwtToken) = DecodeJwtToken(accessToken);
      if (jwtToken is null || jwtToken.Header.Alg != SecurityAlgorithms.HmacSha256)
      {
        throw new ArgumentException("Invalid JWT token");
      }
      var userName = principal.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?.Value
        ?? throw new ArgumentException("Not find user name");
      if (!_memoryCache.TryGetValue(userName, out var refresh))
      {
        throw new ArgumentException("Invalid refresh token");
      }
      if (refresh is null || !refresh.Equals(refreshToken))
      {
        throw new ArgumentException("Invalid refresh token");
      }
      return GenerateTokens(userName, principal.Claims.ToList());
  }
  
  public void RemoveRefreshTokenByUserName(string userName)
   => _memoryCache.Remove(userName);

  public (ClaimsPrincipal, JwtSecurityToken?) DecodeJwtToken(string token)
  {
    if (string.IsNullOrEmpty(token))
    {
      throw new ArgumentException("Invalid token");
    }
    var principal = new JwtSecurityTokenHandler().ValidateToken(token, new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidIssuer = _identityAuthentication.Issuer,
      ValidateAudience = true,
      ValidAudience = _identityAuthentication.Audience,
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(_secret),
      ValidateLifetime = false,
      ClockSkew = TimeSpan.Zero
    }, out var validatedToken);
    return (principal, validatedToken as JwtSecurityToken);
  }
  private static string GenerateRefreshToken()
    => StringHelper.GeneratorStringBase64(32);
}
