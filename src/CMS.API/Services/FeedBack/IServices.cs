using CMS.API.DTOs.FeedBack.Request;

namespace CMS.API.Services.FeedBack;

public interface IServices
{
  Task<Guid> CreateFeedBackAsync(CreateFeedBackRequest request);
}
