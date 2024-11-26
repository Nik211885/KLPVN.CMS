using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class User : CoreEntity<Guid>
{
  public string UserName { get; set; } = null!;
  public string PhoneNumber { get; set; } = null!;
  public string? Email { get; set; }
  public string? Address { get; set; }
  public string FullName { get; set; } = null!;
  public string PasswordHash { get; set; } = null!;
  public string Salt { get; set; } = null!;
  public bool Gender { get; set; }
  public bool IsActive { get; set; }
  public string? Avatar { get; set; }
  public IEnumerable<UserRole>? UserRoles { get; init; }
  public User()
  {
    
  }

}
