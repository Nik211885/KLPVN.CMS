using CMS.API.Entities;
using CMS.Shared.DTOs.AuAction.Response;

namespace CMS.API.Common.Mapping;

public static class AuActionClassMapping
{
  public static AuActionResponse Mapping(this Entities.AuActionClass entity)
  {
    return new AuActionResponse(
      Id: entity.Id,
      Code: entity.Code,
      Name: entity.Name,
      Description: entity.Description
    );
  }

  public static List<AuActionResponse> Mapping(this IEnumerable<Entities.AuActionClass> entities)
  {
    return entities.Select(Mapping).ToList();
  }
}
