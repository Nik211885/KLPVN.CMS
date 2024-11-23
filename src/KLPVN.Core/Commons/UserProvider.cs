using System.Security.Claims;
using KLPVN.Core.Commons.Const;
using KLPVN.Core.Interface;
using Microsoft.AspNetCore.Http;

namespace KLPVN.Core.Commons;

public class UserProvider(IHttpContextAccessor httpContextAccessor) : IUserProvider
{
  public bool IsAuthenticated
  {
    get
    {
      bool result = false;
      try
      {
        if (httpContextAccessor.HttpContext.User.Identity != null)
        {
          result = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
      }
      catch
      {
        // ignored
      }

      return result;
    }
  }

  public Guid UserId
  {
    get
    {
      Guid result = Guid.Empty;
      try
      {
        var value = httpContextAccessor.HttpContext.User.FindFirst(x => x.Type.Equals(ClaimTypes.Name))
          ?.Value;
        result = Guid.Parse(value ?? string.Empty);
      }
      catch
      {
        // ignored
      }

      return result;
    }
  }

  public string UserName
  {
    get
    {
      string result = string.Empty;
      try
      {
        var value = httpContextAccessor.HttpContext.User.FindFirst(x => x.Type.Equals(ClaimTypes.NameIdentifier))
          ?.Value;
        result = value ?? Variables.DEFAULT_USER_NAME;
      }
      catch
      {
        // ignored
      }

      return result;
    }
  }
}
