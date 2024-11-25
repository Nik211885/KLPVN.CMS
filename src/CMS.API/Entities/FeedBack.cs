using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class FeedBack : BaseEntity<Guid>
{
  public string FullName { get; } = null!;
  public string Phone { get; } = null!;
  public string Title { get; } = null!;
  public string? Email { get;}
  public string? Note { get; }
  public string? Address { get; }
  public DateTimeOffset CreatedDateTime { get; }

  public FeedBack() : base(default)
  {
    
  }

  public FeedBack(string fullName,string title,
    string phone, string? email, string? note, string address)
    : base(Guid.NewGuid())
  {
    FullName = fullName;
    Phone = phone;
    Title = title;
    Email = email;
    Note = note;
    Address = address;
    CreatedDateTime = DateTimeOffset.UtcNow;
  } 
}
