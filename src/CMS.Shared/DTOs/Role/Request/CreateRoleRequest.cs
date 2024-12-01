namespace CMS.Shared.DTOs.Role.Request;

public record CreateRoleRequest(string Code, string Name, Guid? ParentId);
