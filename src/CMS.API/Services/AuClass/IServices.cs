using CMS.Shared.DTOs.AuClass.Request;

namespace CMS.API.Services.AuClass;

public interface IServices
{
  Task<Guid> CreateAsync(CreateAuClassRequest request);
  Task<Guid> UpdateAsync(Guid id, UpdateAuClassRequest request);
  Task DeleteAsync(Guid id);
}
