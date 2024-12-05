using CMS.Shared.DTOs.AuAction.Request;
using CMS.Shared.DTOs.AuAction.Response;

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

  public static AuActionResponse Mapping(Entities.AuAction auAction)
  {
    return new AuActionResponse(
      Id: auAction.Id,
      Code: auAction.Code,
      Name: auAction.Name
    );
  }
  
  public static IEnumerable<AuActionResponse> Mapping(IEnumerable<Entities.AuAction> auActions)
  {
    return auActions.Select(Mapping);
  }
}
