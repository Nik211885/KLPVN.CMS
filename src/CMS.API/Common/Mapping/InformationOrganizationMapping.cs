using CMS.Shared.DTOs.InfromationOrgaization.Request;
using CMS.Shared.DTOs.InfromationOrgaization.Response;

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
    informationOrganization.RefFacebook = request.RefFacebook;
    informationOrganization.RefYoutube = request.RefYoutube;
    informationOrganization.RefX = request.RefX;
    informationOrganization.RefSocial = request.RefSocial;
    informationOrganization.RefTikTok = request.RefTikTok;
  }

  public static InformationOrganizationResponse Mapping(this Entities.InformationOrganization informationOrganization)
  {
    return new InformationOrganizationResponse(
      Id: informationOrganization.Id,
      Code: informationOrganization.Code,
      OrganizationName: informationOrganization.OrganizationName,
      Address: informationOrganization.Address,
      Phone: informationOrganization.Phone,
      Email: informationOrganization.Email,
      Icon: informationOrganization.Icon,
      RefFacebook: informationOrganization.RefFacebook,
      RefYoutube: informationOrganization.RefYoutube,
      RefX: informationOrganization.RefX,
      RefSocial: informationOrganization.RefSocial,
      RefTikTok: informationOrganization.RefTikTok,
      IsActive: informationOrganization.IsActive
    );
  }

  public static List<InformationOrganizationResponse> Mapping(
    this List<Entities.InformationOrganization> informationOrganizations)
  {
    return informationOrganizations.Select(Mapping).ToList();
  }
}
