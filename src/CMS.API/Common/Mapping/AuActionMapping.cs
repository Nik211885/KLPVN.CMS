using CMS.Shared.DTOs.AuAction.Request;

namespace CMS.API.Common.Mapping;

public static class AuActionMapping
{
  public static Entities.AuAction Mapping(this CreateAuActionRequest request)
  {
    return new Entities.AuAction()
    {
      Code = request.Code,
      Name = request.Name
    };
  }

  public static void Mapping(this UpdateAuActionRequest request, Entities.AuAction auAction)
  {
    auAction.Code = request.Code;
    auAction.Name = request.Name;
  }
}
