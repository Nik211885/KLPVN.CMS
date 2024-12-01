using System.ComponentModel.DataAnnotations;
using KLPVN.Core.Helper;

namespace CMS.API.DTOs.InfromationOrgaization.Request;

public record CreateInformationOrganizationRequest(
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

public static class CreateInformationOrganizationRequestExtensions
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
  public static bool IsValid(this CreateInformationOrganizationRequest request,out  List<string> errors)
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
