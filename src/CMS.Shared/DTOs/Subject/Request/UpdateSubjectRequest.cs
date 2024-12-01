namespace CMS.Shared.DTOs.Subject.Request;

public record UpdateSubjectRequest(string Code, string Name, int DisplayOrder, Guid? ParentId);
