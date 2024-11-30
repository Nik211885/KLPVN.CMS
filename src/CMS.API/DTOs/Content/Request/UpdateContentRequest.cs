using CMS.API.Common;

namespace CMS.API.DTOs.Content.Request;

public record UpdateContentRequest(string Code,
  string Title, 
  string? Description,
  string? Avatar,
  string Contents,
  IEnumerable<Guid> SubjectId,
  StatusContent Status);

public static class UpdateContentRequestExtensions
{
  public static void Mapping(this UpdateContentRequest request, Entities.Content content)
  {
      content.Code = request.Code;
      content.Title = request.Title;
      content.Description = request.Description;
      content.Avatar = request.Avatar;
      content.Contents = request.Contents;
      content.Status = request.Status;
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
