using CMS.Shared.Enums;

namespace CMS.Shared.DTOs.Content.Request;

public record UpdateContentRequest(string Code,
  string Title, 
  string? Description,
  string? Avatar,
  string Contents,
  IEnumerable<Guid> SubjectId,
  StatusContent Status);

