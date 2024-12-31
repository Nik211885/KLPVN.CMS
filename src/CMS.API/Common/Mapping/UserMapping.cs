using CMS.Shared.DTOs.User.Request;
using CMS.Shared.DTOs.User.Response;
using Faker;

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

  public static UserDetailResponse Mapping (this Entities.User user)
  {
    string avatarUrl;
    if (user.Avatar is not null)
    {
      avatarUrl = user.Avatar;
    }
    else
    {
      avatarUrl = user.Gender ? "imgs/men.png" : "imgs/women.png";
    }
    return new UserDetailResponse(
      Id: user.Id,
      FullName: user.FullName,
      Email: user.Email,
      Gender: user.Gender, 
      Phone: user.PhoneNumber, 
      Address: user.Address,
      Avatar: avatarUrl
      );
  }

  public static List<UserDescriptionResponse> Mapping(this List<Entities.User> users)
  {
    var result = new List<UserDescriptionResponse>();
    foreach (var u in users)
    {
      string avatarUrl;
      if (u.Avatar is not null)
      {
        avatarUrl = u.Avatar;
      }
      else
      {
        avatarUrl = u.Gender ? "imgs/men.png" : "imgs/women.png";
      }
      result.Add(new()
      {
        Id = u.Id,
        UserName = u.UserName,
        Avatar = avatarUrl,
        FullName = u.FullName,
        Roles = u.UserRoles.Select(x=>x.Role).ToList().Mapping()
      });
    }

    return result;
  }
}
