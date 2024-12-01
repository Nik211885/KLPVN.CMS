using KLPVN.Core.Helper;

namespace CMS.API.DTOs.InfromationOrgaization.Request;

public record UpdateInformationOrganizationRequest(
  string Code, 
  string OrganizationName, 
  string Address,
  string Phone, 
  string? Email,
  string? Icon,
  string? RefFacebook, 
  string? RefYoutube,  
  string? RefX, 
  string? RefSocial, 
  string? RefTikTok);

public static class UpdateInformationOrganizationRequestExtensions
{
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
  public static bool IsValid(this UpdateInformationOrganizationRequest request,out  List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.Code))
    {
      errors.Add("mã của tổ chức không được để trống");
    }

    if (string.IsNullOrWhiteSpace(request.OrganizationName))
    {
      errors.Add("tên của tổ chức không được để trống"); 
    }

    if (string.IsNullOrWhiteSpace(request.Address))
    {
      errors.Add("địa chỉ của tổ chức không được để trống");
    }
    if (!RegularExpressionsHelper.IsValidPhoneNumberInVietNam(request.Phone))
    {
      errors.Add("Số điện thoại không đúng định dạng");
    }

    if (!string.IsNullOrWhiteSpace(request.Email))
    {
      if (RegularExpressionsHelper.IsValidEmail(request.Email) || request.Email.Length > 50)
      {
        errors.Add("Email không đúng định dạng và có số kí tự bé hơn 50");
      }
    }

    if (request.Code.Length > 50)
    {
      errors.Add("mã của tổ chức không lớn hơn 50 kí tự");
    }

    if (request.OrganizationName.Length > 200)
    {
      errors.Add("Tên của tổ chức không được lớn hơn 200 kí tự");
    }

    if (request.Address.Length > 200)
    {
      errors.Add("Địa chỉ của tổ chức không được lớn hơn 200 kí tự");
    }
    return errors.Count == 0;
  }
}
