using CMS.Shared.DTOs.AuClass.Response;
using CMS.Shared.DTOs.User.Request;
using CMS.Shared.DTOs.User.Response;

namespace CMS.API.Services.User;

public interface IServices
{
  /// <summary>
  ///   Create new user
  /// </summary>
  /// <param name="request">
  ///   Information need create user
  /// </param>
  /// <exception cref="Exception">
  ///   throw exception bad request if information in form create user not correct format
  /// </exception>
  /// <returns>
  ///   Return id for new user
  /// </returns>
  Task<Guid> CreateAsync(CreateUserRequest request);
  /// <summary>
  ///   Reset password for user
  /// </summary>
  /// <param name="userName">
  ///   Reset password for user have username
  /// </param>
  /// <exception cref="Exception">
  ///   throw exception notfound if not found user have username
  /// </exception>
  /// <returns>
  ///   Return new password for system auto generator include 8 character low case upper case number and special character
  /// </returns>
  Task<string> ResetPasswordAsync(string userName);
  /// <summary>
  ///   Change password for user
  /// </summary>
  /// <param name="userName">
  ///   User have username make change password
  /// </param>
  /// <exception cref="Exception">
  ///   Throw Not found exception if not find user have username or bad request relationship about change password request
  /// </exception>
  /// <param name="request">
  ///   Information about need change password includes new password old password and confirm password
  /// </param>
  /// <returns></returns>
  Task<Guid> ChangePasswordAsync(string userName, ChangePasswordRequest request);
  /// <summary>
  ///   It is active user like soft delete user it is ! compare old value in user
  /// </summary>
  /// <param name="userName">
  ///   User have username make active
  /// </param>
  /// <exception cref="Exception">
  /// Throw NotFound exception if not find user have username like this
  /// </exception>
  /// <returns>
  ///   Return user has active success
  /// </returns>
  Task<Entities.User> ActiveUserAsync(string userName);
  /// <summary>
  ///   Update information for user 
  /// </summary>
  /// <param name="userName">
  ///   User make update has username 
  /// </param>
  /// <param name="request">
  ///   Information need update for user
  /// </param>
  /// <exception cref="Exception">
  ///   Throw notfound if not find user have username like this or bad request it request not valid policy
  /// </exception>
  /// <returns></returns>
  Task<Guid> UpdateAsync(string userName, UpdateUserInformationRequest request);
  /// <summary>
  ///   Add role for user
  /// </summary>
  /// <param name="userName">
  ///   User have username need add role
  /// </param>
  /// <param name="roleId">
  ///   Role have id need add for user
  /// </param>
  /// <exception cref="Exception">
  ///   Throw not found if not found user or role or bad request if user has role before
  /// </exception>
  /// <returns>
  ///   Return id for user add role success
  /// </returns>
  Task<Guid> AddRoleForUserAsync(string userName, Guid roleId);
  /// <summary>
  ///   Remove role for user
  /// </summary>
  /// <param name="userName">Username need remove role</param>
  /// <param name="roleId">Role need remove for user</param>
  /// <exception cref="Exception">
  ///   Throw notfound if not find username and role
  /// </exception>
  /// <returns>
  ///   Return id for user remove role success
  /// </returns>
  Task<Guid> RemoveRoleForUserAsync(string userName, Guid roleId);
  /// <summary>
  ///   Delete user 
  /// </summary>
  /// <param name="userName">Delete user have username</param>
  /// <exception cref="Exception">
  ///   Throw not found if not find user have username
  /// </exception>
  /// <returns>
  ///
  /// </returns>
  Task DeleteAsync(string userName);
  /// <summary>
  ///   Get menu tree for user have permission
  /// </summary>
  /// <param name="permissionCode">All permission for users</param>
  /// <returns>
  ///   Return menu tree response include about menu follow permission code
  /// </returns>
  Task<MenuTreeResponse> GetMenuTreeForUserAsync(IEnumerable<string>? permissionCode);
  /// <summary>
  ///   Get user detail
  /// </summary>
  /// <param name="userName">
  ///   User have user name
  /// </param>
  /// <exception cref="Exception">
  ///   Throw not found if not find user have username
  /// </exception>
  /// <returns>
  ///   Return information about user
  /// </returns>
  Task<UserDetailResponse> GetUserDetailsAsync(string userName);
  /// <summary>
  ///   Upload url images avatar for user 
  /// </summary>
  /// <param name="userName">
  ///   User have username
  /// </param>
  /// <param name="avatarUrl">
  ///   Image url avatar for user
  /// </param>
  /// <exception cref="Exception">
  ///   Throw notfound if not find user have username
  /// </exception>
  /// <returns>
  ///   Return id for user make upload image success
  /// </returns>
  Task<Guid> UploadAvatarAsync(string userName, string avatarUrl);
  /// <summary>
  ///   Get all information user 
  /// </summary>
  /// <returns>
  ///   Return list description for user
  /// </returns>
  Task<List<UserDescriptionResponse>> GetListUserDescriptionsAsync();
}
