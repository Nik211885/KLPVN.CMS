using CMS.Shared.DTOs.Subject.Request;

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
}
