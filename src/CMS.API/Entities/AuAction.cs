using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class AuAction : BaseEntity<Guid>
{
  public string Code { get; set; } = null!;
  public string Name { get; set; } = null!;
  public IEnumerable<AuActionClass>? AuActionClasses { get; init; }

  public AuAction()
  {
    
  }
}
