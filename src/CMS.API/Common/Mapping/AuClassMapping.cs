using CMS.Shared.DTOs.AuClass.Request;

namespace CMS.API.Common.Mapping;

public static class AuClassMapping
{
  public static Entities.AuClass Mapping(this CreateAuClassRequest request)
  {
    return new Entities.AuClass()
    {
      Name = request.Name,
      Code = request.Code,
      MenuName = request.MenuName,
      ParentId = request.ParentId
    };
  }

  public static void Mapping(this UpdateAuClassRequest request, Entities.AuClass auClass)
  {
    auClass.Code = request.Code;
    auClass.Name = request.Name;
    auClass.MenuName = request.MenuName;
    auClass.ParentId = request.ParentId;
  }
}
