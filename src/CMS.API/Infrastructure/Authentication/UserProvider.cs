using System.Security.Claims;
using KLPVN.Core.Commons.Const;
using KLPVN.Core.Interface;

namespace KLPVN.Core.Commons;

public class UserProvider(IHttpContextAccessor context) : IUserProvider
{
  public bool IsAuthenticated
  {
    get
    {
      bool result = false;
      try
      {
        if (context.HttpContext?.User.Identity != null)
        {
          result = context.HttpContext.User.Identity.IsAuthenticated;
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
        var value = context.HttpContext?.User.FindFirst(x => x.Type.Equals(ClaimTypes.Name))
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
        var value = context.HttpContext?.User.FindFirst(x => x.Type.Equals(ClaimTypes.NameIdentifier))
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
