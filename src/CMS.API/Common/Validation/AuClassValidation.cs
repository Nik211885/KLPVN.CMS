using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.Shared.DTOs.AuClass.Request;

namespace CMS.API.Common.Validation;

public static class AuClassValidation
{
  public static void IsValid(this CreateAuClassRequest request)
  {
    if (request.Name is null)
    {
      throw new BadRequestException(ConstMessage.NAME_IS_EMPTY);
    }

    if (request.Code is null)
    {
      throw new BadRequestException(ConstMessage.CODE_IS_EMPTY);
    }

    if (request.MenuName is null)
    {
      throw new BadRequestException(ConstMessage.NAME_MENU_EMPTY);
    }

    if (request.Code.Length > 50)
    {
      throw new BadRequestException(ConstMessage.CODE_LENGTH_MAX_50);
    }

    if (request.Name.Length > 50)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_50);
    }

    if (request.MenuName.Length > 50)
    {
      throw new BadRequestException(ConstMessage.NAME_MENU_MAX_LENGTH_50);
    }
  }

  public static void IsValid(this UpdateAuClassRequest request)
  {
    if (request.Name is null)
    {
      throw new BadRequestException(ConstMessage.NAME_IS_EMPTY);
    }

    if (request.Code is null)
    {
      throw new BadRequestException(ConstMessage.CODE_IS_EMPTY);
    }

    if (request.MenuName is null)
    {
      throw new BadRequestException(ConstMessage.NAME_MENU_EMPTY);
    }

    if (request.Code.Length > 50)
    {
      throw new BadRequestException(ConstMessage.CODE_LENGTH_MAX_50);
    }

    if (request.Name.Length > 50)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_50);
    }

    if (request.MenuName.Length > 50)
    {
      throw new BadRequestException(ConstMessage.NAME_MENU_MAX_LENGTH_50);
    }
  }
}
