using CMS.API.DTOs.Role.Request;

namespace CMS.API.Services.Role;

public interface IServices
{
  Task<Guid> CreateAsync(CreateRoleRequest request);
  Task<Guid> UpdateAsync(Guid roleId, UpdateRoleRequest request);
  Task DeleteAsync(Guid roleId);
}
