using KLPVN.Core.Models;

namespace CMS.API.Entities;

public class InformationOrganization : CoreEntity<Guid>
{
  public string Code { get; private set; } = null!;
  public string OrganizationName { get;private set; } = null!;
  public string Address { get;private set; } = null!;
  public string Phone { get;private set; } = null!;
  public string? Email { get;private set; }
  public string? Icon { get;private set; }
  public string? RefFacebook { get;private set; }
  public string? RefYoutube { get;private set; }
  public string? RefX { get;private set; }
  public string? RefSocial { get;private set; }
  public string? RefTikTok { get;private set; }
  public bool IsActive { get;private set; }

  public InformationOrganization() 
    : base(default,default)
  {
    
  }

  public void UpdateActive(string updateBy, bool isActive)
  {
    base.UpdateCoreEntity(updateBy);
    IsActive = isActive;
  }
  public void UpdateInformationOrganization(string updateBy, string code, string organizationName, string address,
    string phone, string? email, string? icon, string? refFacebook, string? refYoutube, string? refX, string? refSocial, string? refTiktok, bool? isActive = null)
  {
    base.UpdateCoreEntity(updateBy);
    Code = code;
    OrganizationName = organizationName;
    Address = address;
    Phone = phone;
    Email = email;
    IsActive = isActive ?? IsActive;
    Icon = icon;
    RefFacebook = refFacebook;
    RefYoutube = refYoutube;
    RefX = refX;
    RefSocial = refSocial;
    RefTikTok = refTiktok;
  }
  public InformationOrganization(string createdBy, string code ,string organizationName, string address, string phone,
    string? email, string? icon, string? refFacebook, string? refYoutube, string? refX, string? refSocial, string? refTiktok
    )
    :base(Guid.NewGuid(), createdBy)
  {
    Code = code;
    OrganizationName = organizationName;
    Address = address;
    Phone = phone;
    Email = email;
    Icon = icon;
    RefFacebook = refFacebook;
    RefYoutube = refYoutube;
    RefX = refX;
    RefSocial = refSocial;
    RefTikTok = refTiktok;
    IsActive = true;
  }
}
