using CMS.Shared.DTOs.Content.Request;

namespace CMS.API.Services.Content;

public interface IServices
{
 Task<Guid> CreateAsync(CreateContentRequest request);
 Task<Guid> UpdateAsync(Guid id, UpdateContentRequest request);
 Task DeleteAsync(Guid id);
 Task<Guid> ActiveAsync(Guid id);
}
