using CMS.API.Common;
using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class Content : CoreEntity<Guid>
{
  public string Code { get; set; } = null!;
  public string Title { get; set; } = null!;
  public string? Description { get; set; }
  public string? Avatar { get; set; }
  public string Contents { get; set; }
  public StatusContent Status { get; set; }
  public string? Comment { get; set; }
  public bool IsActive { get; set; }
  public IEnumerable<SubjectContent>? SubjectContents { get; init; }

  public Content()
  {
    
  }
}
