namespace CMS.Shared.DTOs.Role.Request;

public record UpdateRoleRequest(string Code, string Name, Guid? ParentId);
