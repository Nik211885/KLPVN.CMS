using CMS.API.DTOs.User.Request;

namespace CMS.API.Services.User;

public interface IServices
{
  Task<Guid> CreateNewUserAsync(CreateUserRequest request);
  Task<string> RestPasswordAsync(string userName);
  Task<Guid> ChangePasswordAsync(ChangePasswordRequest request);
  Task<Guid> ActiveUserAsync(string userName);
  Task<Guid> UpdateUserAsync(UpdateUserInformationRequest request);
  Task<Guid> AddRoleForUserAsync(string userName, Guid roleId);
  Task<Guid> RemoveRoleForUserAsync(string userName, Guid roleId);
}
