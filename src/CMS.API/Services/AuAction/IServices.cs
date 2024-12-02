using CMS.Shared.DTOs.AuAction.Request;

namespace CMS.API.Services.AuAction;

public interface IServices
{
  Task<Guid> CreateAsync(CreateAuActionRequest request);
  Task<Guid> UpdateAsync(Guid id, UpdateAuActionRequest request);
  Task DeleteAsync(Guid id);
}
