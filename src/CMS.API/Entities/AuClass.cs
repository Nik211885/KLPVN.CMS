using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class AuClass : BaseEntity<Guid>
{
  public string Code { get; set; } = null!;
  public string Name { get; set; } = null!;
  public string MenuName { get; set; } = null!;
  public Guid? ParentId { get; set; }
  public AuClass? Parent { get; init; }
  public IEnumerable<AuClass>? Child { get; init; }
  public IEnumerable<AuActionClass>? AuActionClasses { get; init; }
  public AuClass()
  {
    
  }
}
