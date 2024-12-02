using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Helper;

namespace CMS.API.Common.Validation;

public static class FeedBackValidation
{
  public static void IsValid(this CreateFeedBackRequest request)
  {
    if (string.IsNullOrWhiteSpace(request.FullName))
    {
      throw new BadRequestException(ConstMessage.NAME_IS_EMPTY);
    }

    if (!RegularExpressionsHelper.IsValidPhoneNumberInVietNam(request.Phone))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_PHONE_VN);
    }

    if (string.IsNullOrWhiteSpace(request.Title))
    {
      throw new BadRequestException(ConstMessage.TITLE_EMPTY);
    }

    if (request.FullName.Length > 50)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_50);
    }

    if (request.Title.Length > 100)
    {
      throw new BadRequestException(ConstMessage.TITLE_MAX_LENGTH_100);
    }

    if (!string.IsNullOrWhiteSpace(request.Email))
    {
      if (!RegularExpressionsHelper.IsValidEmail(request.Email) || request.Email.Length > 100)
      {
        throw new BadRequestException(ConstMessage.IN_VALID_EMAIL);
      }
    }

    if (request.Address?.Length > 100)
    {
      throw new BadRequestException(ConstMessage.ADDRESS_MAX_LENGTH_100); 
    }
  }
}
