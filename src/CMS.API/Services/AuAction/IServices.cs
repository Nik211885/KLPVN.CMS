using CMS.Shared.DTOs.AuAction.Request;

namespace CMS.API.Services.AuAction;

public interface IServices
{
  Task<Guid> CreateAsync(CreateAuActionRequest request);
}
