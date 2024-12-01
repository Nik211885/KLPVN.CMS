using CMS.Shared.DTOs.Role.Request;

namespace CMS.API.Common.Mapping;

public static class RoleMapping
{
  public static Entities.Role Mapping(this CreateRoleRequest request)
  {
    return new Entities.Role()
    {
      Code = request.Code,
      Name = request.Name,
    };
  }
  public static void Mapping(this UpdateRoleRequest request, Entities.Role role)
  {
    role.Code = request.Code;
    role.Name = request.Name;
  }
}
