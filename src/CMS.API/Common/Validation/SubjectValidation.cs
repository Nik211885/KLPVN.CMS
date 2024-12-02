using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.Shared.DTOs.Subject.Request;

namespace CMS.API.Common.Validation;

public static class SubjectValidation
{
  public static void IsValid(this CreateSubjectRequest request)
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

    if (request.Name.Length > 75)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_75);
    }
  }
  public static void IsValid(this UpdateSubjectRequest request)
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

    if (request.Name.Length > 75)
    {
      throw new BadRequestException(ConstMessage.NAME_LENGTH_MAX_75);
    }
  }
}
