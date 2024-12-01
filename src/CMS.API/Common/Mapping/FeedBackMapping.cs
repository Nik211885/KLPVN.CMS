using CMS.Shared.DTOs.FeedBack.Request;
using CMS.Shared.DTOs.InfromationOrgaization.Request;

namespace CMS.API.Common.Mapping;

public static class FeedBackMapping
{
  public static Entities.FeedBack Mapping(this CreateFeedBackRequest request)
  {
    return new Entities.FeedBack()
    {
      FullName = request.FullName,
      Phone = request.Phone,
      Title = request.Title,
      Email = request.Email,
      Note = request.Note,
      Address = request.Address
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
