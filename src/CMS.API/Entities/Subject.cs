using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class Subject : CoreEntity<Guid>
{
  public string Code { get; set; } = null!;
  public string Name { get; set; } = null!;
  public bool IsActive { get; set; }
  public int DisplayOrder {  get; set; }
  public Guid? ParentId { get; set; }
  public Subject? Parent { get; init; }
  public IEnumerable<Subject>? Children { get; init; }
  public IEnumerable<SubjectContent>? SubjectContents { get; init; }
  public Subject()
  {
    
  }
}
