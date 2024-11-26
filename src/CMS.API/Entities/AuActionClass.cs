using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class AuActionClass : BaseEntity<Guid>
{
  public Guid ClassId { get;}
  public Guid ActionId { get;}
  public AuClass? AuClass { get; init; }
  public AuAction? AuAction  { get; init; }
  public string Code { get; set; } = null!;
  public string Name { get; set; } = null!;
  public string Path { get; set; } = null!;
  public IEnumerable<Permission>? Permissions { get; init; }

  public AuActionClass()
  {
    
  }
  public AuActionClass(Guid classId, Guid actionId)
  {
    ClassId = classId;
    ActionId = actionId;
  }
}
