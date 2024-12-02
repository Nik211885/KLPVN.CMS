using CMS.API.Common.Message;
using CMS.API.Exceptions;
using CMS.Shared.DTOs.Au.Request;

namespace CMS.API.Common.Validation;

public static class AuValidation
{
  public static void IsValid(this LoginRequest request)
  {
    if (string.IsNullOrWhiteSpace(request.UserName))
    {
      throw new BadRequestException(ConstMessage.USER_NAME_EMPTY);
    }

    if (string.IsNullOrWhiteSpace(request.Password))
    {
      throw new BadRequestException(ConstMessage.PASSWORD_EMPTY);
    }
  }
}
