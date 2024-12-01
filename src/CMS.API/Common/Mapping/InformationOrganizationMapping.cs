using CMS.Shared.DTOs.InfromationOrgaization.Request;

namespace CMS.API.Common.Mapping;

public static class InformationOrganizationMapping
{
  public static Entities.InformationOrganization Mapping(this CreateInformationOrganizationRequest request)
  {
    return new Entities.InformationOrganization()
    {
      Code = request.Code,
      OrganizationName = request.OrganizationName,
      Address = request.Address,
      Phone = request.Phone,
      Email = request.Email,
      Icon = request.Icon,
      RefFacebook = request.RefFacebook,
      RefYoutube = request.RefYoutube,
      RefX = request.RefX,
      RefSocial = request.RefSocial,
      RefTikTok = request.RefTikTok
    };
  }
  public static void Mapping(this UpdateInformationOrganizationRequest request,
    Entities.InformationOrganization informationOrganization)
  {
    informationOrganization.Code = request.Code;
    informationOrganization.OrganizationName = request.OrganizationName;
    informationOrganization.Address = request.Address;
    informationOrganization.Phone = request.Phone;
    informationOrganization.Email = request.Email;
    informationOrganization.Icon = request.Icon;
    informationOrganization.RefFacebook = request.RefFacebook;
    informationOrganization.RefYoutube = request.RefYoutube;
    informationOrganization.RefX = request.RefX;
    informationOrganization.RefSocial = request.RefSocial;
    informationOrganization.RefTikTok = request.RefTikTok;
  }
}
