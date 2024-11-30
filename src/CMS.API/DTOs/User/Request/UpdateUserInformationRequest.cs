using CMS.API.Common.Message;
using KLPVN.Core.Helper;

namespace CMS.API.DTOs.User.Request;

public record UpdateUserInformationRequest(
  string PhoneNumber,
  string? Email,
  string? Address,
  string FullName,
  bool Gender,
  string? Avatar);

public static class UpdateInformationRequestExtensions
{
  public static bool IsValid(this UpdateUserInformationRequest request, out List<string> errors)
  {
    errors = [];
    if (string.IsNullOrWhiteSpace(request.FullName))
    {
      errors.Add("Tên không được để trống");
    }
    if (!RegularExpressionsHelper.IsValidPhoneNumberInVietNam(request.PhoneNumber))
    {
      errors.Add(ConstFailure.IN_VALID_PHONE_NUMBER);
    }
    if (!RegularExpressionsHelper.IsValidEmail(request.Email))
    {
      errors.Add(ConstFailure.IN_VALID_EMAIL);
    }
    if (request?.Email?.Length > 100)
    {
      errors.Add("Email không lớn hơn 100 kí tự");
    }

    if (request?.Address?.Length > 150)
    {
      errors.Add("Địa chỉ không lớn hơn 150 kí tự");
    }

    if (request?.FullName?.Length > 100)
    {
      errors.Add("Tên không lớn hơn 100 kí tự");
    }
    return errors.Count == 0;
  }

  public static void Mapping(this UpdateUserInformationRequest request, Entities.User user)
  {
    user.PhoneNumber = request.PhoneNumber;
    user.Email = request.Email;
    user.Address = request.Address;
    user.FullName = request.FullName;
    user.Gender = request.Gender;
    user.Avatar = request.Avatar;
  }
}
