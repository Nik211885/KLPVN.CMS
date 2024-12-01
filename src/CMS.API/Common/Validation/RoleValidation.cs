using CMS.Shared.DTOs.Role.Request;

namespace CMS.API.Common.Validation;

public static class RoleValidation
{
  public static bool IsValid(this CreateRoleRequest request, out List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.Code))
    {
      errors.Add("Mã role không được để trống");
    }

    if (string.IsNullOrWhiteSpace(request.Name))
    {
      errors.Add("Tên của role không được để trống");
    }

    if (request.Code.Length > 50)
    {
      errors.Add("Mã của role không lớn hơn 50");
    }

    if (request.Name.Length > 50)
    {
      errors.Add("Tên của role không lớn hơn 50");
    }
    return errors.Count == 0;
  }
  public static bool IsValid(this UpdateRoleRequest request, out List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.Code))
    {
      errors.Add("Mã role không được để trống");
    }

    if (string.IsNullOrWhiteSpace(request.Name))
    {
      errors.Add("Tên của role không được để trống");
    }

    if (request.Code.Length > 50)
    {
      errors.Add("Mã của role không lớn hơn 50");
    }

    if (request.Name.Length > 50)
    {
      errors.Add("Tên của role không lớn hơn 50");
    }
    return errors.Count == 0;
  }
}
