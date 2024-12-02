using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.Shared.DTOs.InfromationOrgaization.Request;
using KLPVN.Core.Helper;

namespace CMS.API.Common.Validation;

public static class InformationOrganizationValidation
{
  public static void IsValid(this CreateInformationOrganizationRequest request)
  {
    if (string.IsNullOrWhiteSpace(request.Code))
    {
      throw new BadRequestException(ConstMessage.CODE_IS_EMPTY);
    }

    if (string.IsNullOrWhiteSpace(request.OrganizationName))
    {
      throw new BadRequestException(ConstMessage.NAME_IS_EMPTY); 
    }

    if (string.IsNullOrWhiteSpace(request.Address))
    {
      throw new BadRequestException(ConstMessage.ADDRESS_EMPTY);
    }
    if (!RegularExpressionsHelper.IsValidPhoneNumberInVietNam(request.Phone))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_PHONE_VN);
    }

    if (!string.IsNullOrWhiteSpace(request.Email))
    {
      if (RegularExpressionsHelper.IsValidEmail(request.Email) || request.Email.Length > 50)
      {
        throw new BadRequestException(ConstMessage.IN_VALID_EMAIL);
      }
    }

    if (request.Code.Length > 50)
    {
      throw new BadRequestException(ConstMessage.CODE_LENGTH_MAX_50);
    }

    if (request.OrganizationName.Length > 200)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_200);
    }

    if (request.Address.Length > 200)
    {
      throw new BadRequestException(ConstMessage.ADDRESS_MAX_LENGTH_200);
    }
  }
  public static void IsValid(this UpdateInformationOrganizationRequest request)
  {
    if (string.IsNullOrWhiteSpace(request.Code))
    {
      throw new BadRequestException(ConstMessage.CODE_IS_EMPTY);
    }

    if (string.IsNullOrWhiteSpace(request.OrganizationName))
    {
      throw new BadRequestException(ConstMessage.NAME_IS_EMPTY); 
    }

    if (string.IsNullOrWhiteSpace(request.Address))
    {
      throw new BadRequestException(ConstMessage.ADDRESS_EMPTY);
    }
    if (!RegularExpressionsHelper.IsValidPhoneNumberInVietNam(request.Phone))
    {
      throw new BadRequestException(ConstMessage.IN_VALID_PHONE_VN);
    }

    if (!string.IsNullOrWhiteSpace(request.Email))
    {
      if (RegularExpressionsHelper.IsValidEmail(request.Email) || request.Email.Length > 50)
      {
        throw new BadRequestException(ConstMessage.IN_VALID_EMAIL);
      }
    }

    if (request.Code.Length > 50)
    {
      throw new BadRequestException(ConstMessage.CODE_LENGTH_MAX_50);
    }

    if (request.OrganizationName.Length > 200)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_200);
    }

    if (request.Address.Length > 200)
    {
      throw new BadRequestException(ConstMessage.ADDRESS_MAX_LENGTH_200);
    }
  }
}
