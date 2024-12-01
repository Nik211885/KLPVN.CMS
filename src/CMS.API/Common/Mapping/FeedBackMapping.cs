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
}
