namespace CMS.API.DTOs.Role.Request;

public record UpdateRoleRequest(string Code, string Name, Guid? ParentId);
public static class UpdateRoleRequestExtensions
{
  public static bool IsValid(this UpdateRoleRequest request, out List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.Code))
    {
      errors.Add("Mã role không được để trống");
    }

    if (string.IsNullOrWhiteSpace(request.Name))
    {
      errors.Add("Tên của role không được để trống");
    }

    if (request.Code.Length > 50)
    {
      errors.Add("Mã của role không lớn hơn 50");
    }

    if (request.Name.Length > 50)
    {
      errors.Add("Tên của role không lớn hơn 50");
    }
    return errors.Count == 0;
  }

  public static void Mapping(this UpdateRoleRequest request, Entities.Role role)
  {
    role.Code = request.Code;
    role.Name = request.Name;
  }
  
}
