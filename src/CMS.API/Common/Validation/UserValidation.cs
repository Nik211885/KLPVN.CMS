using CMS.API.Common.Message;
using CMS.Shared.DTOs.User.Request;
using KLPVN.Core.Helper;

namespace CMS.API.Common.Validation;

public static class UserValidation
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

    if (request.UserName.Length > 50)
    {
      errors.Add("User name không lớn hơn 50 ký tự");
    }

    if (request?.Email?.Length > 100)
    {
      errors.Add("Email không lớn hơn 100 kí tự");
    }

    if (request?.Address?.Length > 150)
    {
      errors.Add("Địa chỉ không lớn hơn 150 kí tự");
    }

    if (request?.FullName?.Length > 100)
    {
      errors.Add("Tên không lớn hơn 100 kí tự");
    }
    return errors.Count == 0;
  }
  public static bool IsValid(this UpdateUserInformationRequest request, out List<string> errors)
  {
    errors = [];
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
    if (request?.Email?.Length > 100)
    {
      errors.Add("Email không lớn hơn 100 kí tự");
    }

    if (request?.Address?.Length > 150)
    {
      errors.Add("Địa chỉ không lớn hơn 150 kí tự");
    }

    if (request?.FullName?.Length > 100)
    {
      errors.Add("Tên không lớn hơn 100 kí tự");
    }
    return errors.Count == 0;
  }
}
