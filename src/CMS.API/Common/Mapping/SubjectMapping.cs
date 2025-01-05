using CMS.Shared.DTOs.Subject.Request;
using CMS.Shared.DTOs.Subject.Response;
using Faker;

namespace CMS.API.Common.Mapping;

public static class SubjectMapping
{
  public static Entities.Subject Mapping(this CreateSubjectRequest request)
  {
    return new Entities.Subject()
    {
      Code = request.Code, 
      Name = request.Name, 
      DisplayOrder = request.DisplayOrder,
      ParentId = request.ParentId,
    };
  }
  public static void Mapping(this UpdateSubjectRequest request, Entities.Subject subject)
  {
    subject.Code = request.Code;
    subject.Name = request.Name;
    subject.DisplayOrder = request.DisplayOrder;
    subject.ParentId = request.ParentId;
  }

  public static Subjects Mapping(this Entities.Subject subject)
  {
    return new Subjects()
    {
      Id = subject.Id,
      Code = subject.Code,
      Name = subject.Name,
      IsActive = subject.IsActive,
      DisplayOrder = subject.DisplayOrder,
    };
  }

  public static List<Subjects> Mapping(this List<Entities.Subject> subjects)
  {
    return subjects.Select(Mapping).ToList();
  }

  public static SubjectDetailResponse MappingDetail(this Entities.Subject subject)
  {
    return new SubjectDetailResponse()
    {
      Id = subject.Id,
      Code = subject.Code,
      Name = subject.Name,
      IsActive = subject.IsActive,
      DisplayOrder = subject.DisplayOrder,
      ParentId = subject.ParentId,
      ParentName = subject.Parent?.Name
    };
  }
}
