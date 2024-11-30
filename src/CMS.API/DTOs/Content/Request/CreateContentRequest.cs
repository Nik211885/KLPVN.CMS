using CMS.API.Common;

namespace CMS.API.DTOs.Content.Request;

public record CreateContentRequest(string Code,
  string Title, 
  string? Description,
  string? Avatar,
  string Contents,
  IEnumerable<Guid> SubjectId,
  StatusContent Status);
public static class CreateContentRequestExtensions
{
  public static Entities.Content Mapping(this CreateContentRequest request)
  {
    return new Entities.Content()
    {
      Code = request.Code,
      Title = request.Title,
      Description = request.Title,
      Avatar = request.Avatar,
      Contents = request.Contents,
      Status = request.Status,
      IsActive = true,
    };
  }

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
}
