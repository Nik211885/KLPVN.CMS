using CMS.Shared.DTOs.User.Request;

namespace CMS.API.Common.Mapping;

public static class UserMapping
{
  public static Entities.User Mapping(this CreateUserRequest request)
  {
    return new Entities.User()
    {
      PhoneNumber = request.PhoneNumber,
      UserName = request.UserName,
      Email = request.Email,
      Address = request.Address,
      FullName = request.FullName,
      Gender = request.Gender,
    };
  }
  public static void Mapping(this UpdateUserInformationRequest request, Entities.User user)
  {
    user.PhoneNumber = request.PhoneNumber;
    user.Email = request.Email;
    user.Address = request.Address;
    user.FullName = request.FullName;
    user.Gender = request.Gender;
  }
}
