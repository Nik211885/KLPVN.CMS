using CMS.Shared.DTOs.Role.Response;

namespace CMS.Shared.DTOs.User.Response;

public class UserDescriptionResponse
{
  public Guid Id { get; set; }
  public string UserName { get; set; }
  public string FullName { get; set; }
  public string Avatar { get; set; }
  public List<RoleResponse> Roles  { get; set; }
}
