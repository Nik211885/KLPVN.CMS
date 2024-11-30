using CMS.API.DTOs.Role.Request;

namespace CMS.API.Services.Role;

public interface IServices
{
  Task<Guid> CreateRoleAsync(CreateRoleRequest request);
  Task<Guid> UpdateRoleAsync(Guid roleId, UpdateRoleRequest request);
  Task DeleteRoleAsync(Guid roleId);
}
