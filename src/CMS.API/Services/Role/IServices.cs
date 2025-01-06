using CMS.Shared.DTOs.Role.Request;

namespace CMS.API.Services.Role;

public interface IServices
{
  /// <summary>
  ///   Create new role
  /// </summary>
  /// <param name="request">Information need created role</param>
  /// <returns>
  ///   Return id for role if update success
  /// </returns>
  Task<Guid> CreateAsync(CreateRoleRequest request);
  /// <summary>
  ///   Update role 
  /// </summary>
  /// <param name="roleId">Role has id</param>
  /// <param name="request">Information need update</param>
  /// <returns>
  ///   Return id for role if update success
  /// </returns>
  Task<Guid> UpdateAsync(Guid roleId, UpdateRoleRequest request);
  /// <summary>
  ///   Delete role
  /// </summary>
  /// <param name="roleId">Role has id</param>
  /// <returns></returns>
  Task DeleteAsync(Guid roleId);
  /// <summary>
  ///   Add permission for role
  /// </summary>
  /// <param name="roleId">role has id</param>
  /// <param name="auActinId">permission has id</param>
  /// <returns>
  ///   
  /// </returns>
  Task AddPermissionForRoleAsync(Guid roleId, Guid auActinId);
  /// <summary>
  ///   Remove permission for role
  /// </summary>
  /// <param name="roleId">Role has id</param>
  /// <param name="auActinId">Permission has id</param>
  /// <returns>
  ///   
  /// </returns>
  Task RemovePermissionForRoleAsync(Guid roleId, Guid auActinId);
}
