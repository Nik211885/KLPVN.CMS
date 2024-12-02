namespace CMS.Shared.DTOs.AuClass.Request;

public record UpdateAuClassRequest(string Code, string Name, string MenuName, Guid? ParentId);
