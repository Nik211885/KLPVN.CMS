using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class Role : CoreEntity<Guid>
{
  public string Code { get; set; } = null!;
  public string Name { get; set; } = null!;
  public Guid? ParentId { get; set; }
  public Role? Parent { get; init; }
  public IEnumerable<Role>? Child { get; init; }
  public IEnumerable<UserRole>? UserRoles { get; init; }

  public Role()
  {
    
  }
}
