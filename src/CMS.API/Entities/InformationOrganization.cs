using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class InformationOrganization : CoreEntity<Guid>
{
  public string Code { get; set; } = null!;
  public string OrganizationName { get; set; } = null!;
  public string Address { get; set; } = null!;
  public string Phone { get; set; } = null!;
  public string? Email { get; set; }
  public string? Icon { get; set; }
  public string? RefFacebook { get; set; }
  public string? RefYoutube { get; set; }
  public string? RefX { get; set; }
  public string? RefSocial { get; set; }
  public string? RefTikTok { get; set; }
  public bool IsActive { get; set; }
  public InformationOrganization()
  {
    
  }
}
