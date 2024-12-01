using CMS.Shared.DTOs.Content.Request;

namespace CMS.API.Common.Validation;

public static class ContentValidation
{
  public static bool IsValid(this CreateContentRequest request, out List<string> errors)
  {
    errors = [];
    if (!request.SubjectId.Any())
    {
      errors.Add("Bài viết chưa chọn chủ đề");
    }
    if (string.IsNullOrEmpty(request.Code))
    {
      errors.Add("Mã code không đuược đễ trống");
    }

    if (request.Code.Length > 50)
    {
      errors.Add("Mã code không được lớn hơn 50 ký tự");
    }

    if (request.Title.Length > 500)
    {
      errors.Add("Tiêu đề không lớn hơn 500 ký tự");
    }

    if (request.Description?.Length > 500)
    {
      errors.Add("Mô tả không lớn hơn 500 kí tự");
    }
    if (string.IsNullOrWhiteSpace(request.Title))
    {
      errors.Add("Tiêu đề không được để trống");
    }

    if (string.IsNullOrWhiteSpace(request.Contents))
    {
      errors.Add("Nội dung bài viết không được để trống");
    }
    return errors.Count == 0;
  }
  public static bool IsValid(this UpdateContentRequest request, out List<string> errors)
  {
    errors = [];
    if (!request.SubjectId.Any())
    {
      errors.Add("Bài viết chưa chọn chủ đề");
    }
    if (string.IsNullOrEmpty(request.Code))
    {
      errors.Add("Mã code không đuược đễ trống");
    }

    if (request.Code.Length > 50)
    {
      errors.Add("Mã code không được lớn hơn 50 ký tự");
    }

    if (request.Title.Length > 500)
    {
      errors.Add("Tiêu đề không lớn hơn 500 ký tự");
    }

    if (request.Description?.Length > 500)
    {
      errors.Add("Mô tả không lớn hơn 500 kí tự");
    }
    if (string.IsNullOrWhiteSpace(request.Title))
    {
      errors.Add("Tiêu đề không được để trống");
    }

    if (string.IsNullOrWhiteSpace(request.Contents))
    {
      errors.Add("Nội dung bài viết không được để trống");
    }
    return errors.Count == 0;
  }
}
