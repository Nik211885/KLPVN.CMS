using CMS.API.DTOs.Content.Request;

namespace CMS.API.Services.Content;

public interface IServices
{
 Task<Guid> CreateContentAsync(CreateContentRequest request);
 Task<Guid> UpdateContentAsync(Guid id, UpdateContentRequest request);
}
