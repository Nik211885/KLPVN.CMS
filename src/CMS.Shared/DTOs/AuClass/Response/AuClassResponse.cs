using CMS.Shared.DTOs.AuAction.Response;

namespace CMS.Shared.DTOs.AuClass.Response;

public record AuClassResponse(
  Guid Id, 
  string Code, 
  string Name,
  string MenuName,
  ICollection<AuActionResponse>? Actions
  );
