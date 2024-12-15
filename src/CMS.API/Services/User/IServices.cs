using CMS.Shared.DTOs.AuClass.Response;
using CMS.Shared.DTOs.User.Request;
using CMS.Shared.DTOs.User.Response;

namespace CMS.API.Services.User;

public interface IServices
{
  Task<Guid> CreateAsync(CreateUserRequest request);
  Task<string> ResetPasswordAsync(string userName);
  Task<Guid> ChangePasswordAsync(ChangePasswordRequest request);
  Task<Guid> ActiveUserAsync(string userName);
  Task<Guid> UpdateAsync(UpdateUserInformationRequest request);
  Task<Guid> AddRoleForUserAsync(string userName, Guid roleId);
  Task<Guid> RemoveRoleForUserAsync(string userName, Guid roleId);
  Task DeleteAsync(Guid id);
  Task<MenuTreeResponse> GetMenuTreeForUserAsync(IEnumerable<string>? permissionCode);
  Task<UserDetailResponse> GetUserDetailsAsync(string userName);
}
