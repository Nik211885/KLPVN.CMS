using CMS.Shared.DTOs.Au.Request;

namespace CMS.API.Common.Validation;

public static class AuValidation
{
  public static bool IsValid(this LoginRequest request, out List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.UserName))
    {
      errors.Add("User name không được để trống");
    }

    if (string.IsNullOrWhiteSpace(request.Password))
    {
      errors.Add("Mật khẩu không được để trống");
    }
    return errors.Count == 0;
  }
}
