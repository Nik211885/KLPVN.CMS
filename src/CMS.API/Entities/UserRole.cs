namespace CMS.API.Entities;

public class UserRole
{
  public Guid UserId { get;}
  public  Guid RoleId { get; }
  public User? User { get; init; }
  public Role? Role{ get; init; }

  public UserRole()
  {
    
  }

  public UserRole(Guid userId, Guid roleId)
  {
    UserId = userId;
    RoleId = roleId;
  }
  // ctor make sedder data
  public UserRole(Guid roleId)
  {
    RoleId = roleId;
  }
}
