using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.Shared.DTOs.AuAction.Request;

namespace CMS.API.Common.Validation;

public static class AuActionValidation
{
  public static void IsValid(this CreateAuActionRequest request)
  {
    if (String.IsNullOrWhiteSpace(request.Code))
    {
      throw new BadRequestException(ConstMessage.CODE_IS_EMPTY);
    }
    if(string.IsNullOrWhiteSpace(request.Name))
    {
        throw new BadRequestException(ConstMessage.NAME_IS_EMPTY);
    }

    if (request.Code.Length > 50)
    {
      throw new BadRequestException(ConstMessage.CODE_LENGTH_MAX_50);
    }

    if (request.Name.Length > 50)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_50);
    }
  }

  public static void IsValid(this UpdateAuActionRequest request)
  {
    if (String.IsNullOrWhiteSpace(request.Code))
    {
      throw new BadRequestException(ConstMessage.CODE_IS_EMPTY);
    }
    if(string.IsNullOrWhiteSpace(request.Name))
    {
      throw new BadRequestException(ConstMessage.NAME_IS_EMPTY);
    }

    if (request.Code.Length > 50)
    {
      throw new BadRequestException(ConstMessage.CODE_LENGTH_MAX_50);
    }

    if (request.Name.Length > 50)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_50);
    }
  }
}
