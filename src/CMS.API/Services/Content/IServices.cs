using CMS.Shared.DTOs.Content.Request;

namespace CMS.API.Services.Content;

public interface IServices
{
 Task<Guid> CreatetAsync(CreateContentRequest request);
 Task<Guid> UpdateAsync(Guid id, UpdateContentRequest request);
 Task<Guid> ActiveAsync(Guid id);
}
