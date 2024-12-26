using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Models;

namespace CMS.API.Services.FeedBack;

public interface IServices
{
  Task<Guid> CreateAsync(CreateFeedBackRequest request);
  Task DeleteAsync(Guid id);
  Task<IReadOnlyCollection<Entities.FeedBack>> GetAllFeedBackAsync(string? search = null);
  Task<Pagination<Entities.FeedBack>> GetFeedBackWithPaginationAsync(int page, int size, string? search = null);
}
