namespace CMS.Shared.DTOs.AuClass.Request;

public record CreateAuClassRequest(string Code, string Name, string MenuName, Guid? ParentId);
