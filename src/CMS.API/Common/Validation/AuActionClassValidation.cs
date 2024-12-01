using CMS.Shared.DTOs.Au.Request;
using CMS.Shared.DTOs.AuAction.Request;

namespace CMS.API.Common.Validation;

public static class AuActionClassValidation
{
  public static bool IsValid(this CreateAuActionRequest request, out List<string> error)
  {
    error = [];
    if (String.IsNullOrWhiteSpace(request.Code))
    {
      error.Add("Mã action không được để trống");
    }
    if(string.IsNullOrWhiteSpace(request.Name))
    {
      error.Add("Tên của action không được để trống");
    }

    if (request.Code.Length > 50)
    {
      error.Add("Mã action không lớn hơn 50 ký tự");
    }

    if (request.Name.Length > 50)
    {
      error.Add("Tên của action không lơn hơn 50 ký tự");
    }
    return error.Count == 0;
  }
}
