using CMS.Shared.DTOs.Content.Request;

namespace CMS.API.Common.Mapping;

public static class ContentMapping
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
  public static void Mapping(this UpdateContentRequest request, Entities.Content content)
  {
    content.Code = request.Code;
    content.Title = request.Title;
    content.Description = request.Description;
    content.Avatar = request.Avatar;
    content.Contents = request.Contents;
    content.Status = request.Status;
  }
}
