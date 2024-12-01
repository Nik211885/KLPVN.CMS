using CMS.Shared.DTOs.Subject.Request;

namespace CMS.API.Common.Validation;

public static class SubjectValidation
{
  public static bool IsValid(this CreateSubjectRequest request, out List<string> error)
  {
    error = [];
    if (String.IsNullOrWhiteSpace(request.Code))
    {
      error.Add("Mã chủ đề không được để trống");
    }
    if(string.IsNullOrWhiteSpace(request.Name))
    {
      error.Add("Tên của chủ đề không được để trống");
    }

    if (request.Code.Length > 50)
    {
      error.Add("Mã của chủ đề không lớn hơn 50 ký tự");
    }

    if (request.Name.Length > 75)
    {
      error.Add("Tên của chủ đề không lớn hơn 75 kí tự");
    }
    return error.Count == 0;
  }
  public static bool IsValid(this UpdateSubjectRequest request, out List<string> error)
  {
    error = [];
    if (String.IsNullOrWhiteSpace(request.Code))
    {
      error.Add("Mã chủ đề không được để trống");
    }
    if(string.IsNullOrWhiteSpace(request.Name))
    {
      error.Add("Tên của chủ đề không được để trống");
    }

    if (request.Code.Length > 50)
    {
      error.Add("Mã của chủ đề không lớn hơn 50 ký tự");
    }

    if (request.Name.Length > 75)
    {
      error.Add("Tên của chủ đề không lớn hơn 75 kí tự");
    }
    return error.Count == 0;
  }
}
