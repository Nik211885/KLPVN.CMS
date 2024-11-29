using CMS.API.Common.Message;
using KLPVN.Core.Helper;

namespace CMS.API.DTOs.User.Request;

public record ChangePasswordRequest(string Password, string NewPassword, string PasswordConfirm);

public static class ChangePasswordRequestExtension
{
  public static bool IsValid(this ChangePasswordRequest request, out List<string> errors)
  {
    errors = [];
    if(!RegularExpressionsHelper.IsValidPassword(request.NewPassword))
    {
      errors.Add(ConstFailure.IN_VALID_PASSWORD);
    }

    if (request.Password.Equals(request.NewPassword))
    {
      errors.Add(ConstFailure.IN_DUPLICATE_PASSWORD);
    }

    if (request.NewPassword.Equals(request.PasswordConfirm))
    {
      errors.Add(ConstFailure.IN_MATCH_PASSWORD);
    }
    return errors.Count == 0;
  }
}
