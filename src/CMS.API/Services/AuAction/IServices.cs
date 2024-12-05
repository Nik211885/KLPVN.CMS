using CMS.Shared.DTOs.AuAction.Request;
using CMS.Shared.DTOs.AuAction.Response;

namespace CMS.API.Services.AuAction;

public interface IServices
{
  Task<Guid> CreateAsync(CreateAuActionRequest request);
  Task<Guid> UpdateAsync(Guid id, UpdateAuActionRequest request);
  Task<AuActionResponse> GetByIdAsync(Guid id);
  Task<IEnumerable<AuActionResponse>> GetAllAsync();
  Task DeleteAsync(Guid id);
}
