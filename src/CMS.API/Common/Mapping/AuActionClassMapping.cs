using CMS.Shared.DTOs.AuAction.Request;

namespace CMS.API.Common.Mapping;

public static class AuActionClassMapping
{
  public static Entities.AuAction Mapping(this CreateAuActionRequest request)
  {
    return new Entities.AuAction()
    {
      Code = request.Code,
      Name = request.Name
    };
  }
}
