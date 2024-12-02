using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.Shared.DTOs.Content.Request;

namespace CMS.API.Common.Validation;

public static class ContentValidation
{
  public static void IsValid(this CreateContentRequest request)
  {
    if (!request.SubjectId.Any())
    {
      throw new BadRequestException(ConstMessage.CONTENT_INVALID_SUBJECT);
    }
    if (string.IsNullOrWhiteSpace(request.Code))
    {
      throw new BadRequestException(ConstMessage.CODE_IS_EMPTY);
    }

    if (request.Code.Length > 50)
    {
      throw new BadRequestException(ConstMessage.CODE_LENGTH_MAX_50);
    }

    if (request.Title.Length > 500)
    {
      throw new BadRequestException(ConstMessage.TITLE_MAX_LENGTH_500);
    }

    if (request.Description?.Length > 500)
    {
      throw new BadRequestException(ConstMessage.DESCRIPTION_MAX_LENGTH_500);
    }
    if (string.IsNullOrWhiteSpace(request.Title))
    {
      throw new BadRequestException(ConstMessage.TITLE_EMPTY);
    }

    if (string.IsNullOrWhiteSpace(request.Contents))
    {
      throw new BadRequestException(ConstMessage.CONTENT_EMPTY);
    }
  }
  public static void IsValid(this UpdateContentRequest request)
  {
    if (!request.SubjectId.Any())
    {
      throw new BadRequestException(ConstMessage.CONTENT_INVALID_SUBJECT);
    }
    if (string.IsNullOrWhiteSpace(request.Code))
    {
      throw new BadRequestException(ConstMessage.CODE_IS_EMPTY);
    }

    if (request.Code.Length > 50)
    {
      throw new BadRequestException(ConstMessage.CODE_LENGTH_MAX_50);
    }

    if (request.Title.Length > 500)
    {
      throw new BadRequestException(ConstMessage.TITLE_MAX_LENGTH_500);
    }

    if (request.Description?.Length > 500)
    {
      throw new BadRequestException(ConstMessage.DESCRIPTION_MAX_LENGTH_500);
    }
    if (string.IsNullOrWhiteSpace(request.Title))
    {
      throw new BadRequestException(ConstMessage.TITLE_EMPTY);
    }

    if (string.IsNullOrWhiteSpace(request.Contents))
    {
      throw new BadRequestException(ConstMessage.CONTENT_EMPTY);
    }
  }
}
