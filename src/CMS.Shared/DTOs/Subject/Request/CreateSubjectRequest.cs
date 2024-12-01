namespace CMS.Shared.DTOs.Subject.Request;

public record CreateSubjectRequest(string Code, string Name, int DisplayOrder, Guid? ParentId);
