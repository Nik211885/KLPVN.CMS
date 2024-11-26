using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class FeedBack : BaseEntity<Guid>
{
  public string FullName { get; set; } = null!;
  public string Phone { get; set; } = null!;
  public string Title { get; set; } = null!;
  public string? Email { get; set; }
  public string? Note { get; set; }
  public string? Address { get; set; }
  public DateTimeOffset CreatedDateTime { get; set; }

  public FeedBack()
  {
    
  }
}
