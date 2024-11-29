using CMS.API.Common.Message;
using KLPVN.Core.Helper;

namespace CMS.API.DTOs.User.Request;

public record CreateUserRequest(string UserName,
  string PhoneNumber,
  string? Email,
  string? Address,
  string FullName,
  string Password,
  bool Gender, 
  string? Avatar);

public static class CreateUserRequestExtensions
{
  public static Entities.User Mapping(this CreateUserRequest request)
  {
    return new Entities.User()
    {
      PhoneNumber = request.PhoneNumber,
      UserName = request.UserName,
      Email = request.Email,
      Address = request.Address,
      FullName = request.FullName,
      Gender = request.Gender,
      Avatar = request.Avatar,
    };
  }

  public static bool IsValid(this CreateUserRequest request, out List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.UserName))
    {
      errors.Add("User name không được để trống");
    }
    if (string.IsNullOrWhiteSpace(request.FullName))
    {
      errors.Add("Tên không được để trống");
    }
    if (!RegularExpressionsHelper.IsValidPhoneNumberInVietNam(request.PhoneNumber))
    {
      errors.Add(ConstFailure.IN_VALID_PHONE_NUMBER);
    }

    if (!RegularExpressionsHelper.IsValidEmail(request.Email))
    {
      errors.Add(ConstFailure.IN_VALID_EMAIL);
    }

    if (!RegularExpressionsHelper.IsValidPassword(request.Password))
    {
      errors.Add(ConstFailure.IN_VALID_PASSWORD);
    }
    return errors.Count == 0;
  }
}
