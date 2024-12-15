using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.Shared.DTOs.User.Request;
using KLPVN.Core.Helper;

namespace CMS.API.Common.Validation;

public static class UserValidation
{
  public static void IsValid(this ChangePasswordRequest request)
  {
    if(!RegularExpressionsHelper.IsValidPassword(request.NewPassword))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_PASSWORD);
    }

    if (request.Password.Equals(request.NewPassword))
    {
      throw new BadRequestException(ConstMessage.DUPLICATE_PASSWORD);
    }

    if (!request.NewPassword.Equals(request.PasswordConfirm))
    {
      throw new BadRequestException(ConstMessage.NOT_DUPLICATE_PASSWORD);
    }
  }
  public static void IsValid(this CreateUserRequest request)
  {
    if (string.IsNullOrWhiteSpace(request.UserName))
    {
      throw new BadRequestException(ConstMessage.USER_NAME_EMPTY);
    }
    if (string.IsNullOrWhiteSpace(request.FullName))
    {
      throw new BadRequestException(ConstMessage.NAME_IS_EMPTY);
    }
    if (!RegularExpressionsHelper.IsValidPhoneNumberInVietNam(request.PhoneNumber))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_PHONE_VN);
    }

    if (!RegularExpressionsHelper.IsValidEmail(request.Email))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_EMAIL);
    }

    if (!RegularExpressionsHelper.IsValidPassword(request.Password))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_PASSWORD);
    }

    if (request.UserName.Length > 50)
    {
      throw new BadRequestException(ConstMessage.USER_NAME_MAX_LENGTH_50);
    }

    if (request.Email?.Length > 100)
    {
      throw new BadRequestException(ConstMessage.EMAIL_MAX_LENGTH_100);
    }

    if (request.Address?.Length > 150)
    {
      throw new BadRequestException(ConstMessage.ADDRESS_MAX_LENGTH_150);
    }

    if (request.FullName?.Length > 100)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_100);
    }
  }
  public static void IsValid(this UpdateUserInformationRequest request)
  {
    if (string.IsNullOrWhiteSpace(request.FullName))
    {
      throw new BadRequestException(ConstMessage.NAME_IS_EMPTY);
    }
    if (!RegularExpressionsHelper.IsValidPhoneNumberInVietNam(request.PhoneNumber))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_EMAIL);
    }
    if (!RegularExpressionsHelper.IsValidEmail(request.Email))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_EMAIL);
    }
    if (request.Email?.Length > 100)
    {
      throw new BadRequestException(ConstMessage.EMAIL_MAX_LENGTH_100);
    }

    if (request.Address?.Length > 150)
    {
      throw new BadRequestException(ConstMessage.ADDRESS_MAX_LENGTH_150);
    }

    if (request.FullName?.Length > 100)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_100);
    }
  }
}
