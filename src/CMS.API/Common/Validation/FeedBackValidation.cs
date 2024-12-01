using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Helper;

namespace CMS.API.Common.Validation;

public static class FeedBackValidation
{
  public static bool IsValid(this CreateFeedBackRequest request, out List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.FullName))
    {
      errors.Add("Tên không được để trống");
    }

    if (!RegularExpressionsHelper.IsValidEmail(request.Phone))
    {
      errors.Add("Số điện thoại không đúng định dạng");
    }

    if (string.IsNullOrWhiteSpace(request.Title))
    {
      errors.Add("Tiêu đề không được để trống");
    }

    if (request.FullName.Length > 50)
    {
      errors.Add("Tên không được quá 50 ký tự");
    }

    if (request.Title.Length > 100)
    {
      errors.Add("Tiêu đề không được quá 100 ký tự");
    }

    if (!string.IsNullOrWhiteSpace(request.Email))
    {
      if (!RegularExpressionsHelper.IsValidEmail(request.Email) || request.Email.Length > 100)
      {
        errors.Add("Email không đúng định dạng hoặc lớn hơn 100 kí tự");
      }
    }

    if (request.Address?.Length > 100)
    {
      errors.Add("Địa chỉ không quá 100 ký tự"); 
    }
    return errors.Count == 0;
  }
}
