using CMS.API.Entities;
using CMS.Shared.DTOs.Role.Request;
using CMS.Shared.DTOs.Role.Response;

namespace CMS.API.Common.Mapping;

public static class RoleMapping
{
  public static Role Mapping(this CreateRoleRequest request)
  {
    return new Role()
    {
      Code = request.Code,
      Name = request.Name,
    };
  }
  public static void Mapping(this UpdateRoleRequest request, Role role)
  {
    role.Code = request.Code;
    role.Name = request.Name;
  }

  public static List<RoleResponse> Mapping(this List<Role> roles)
  {
    return roles.Select(r => new RoleResponse(Id: r.Id, Code: r.Code, Name: r.Name)).ToList();
  }
}
