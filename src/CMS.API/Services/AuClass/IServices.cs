using CMS.Shared.DTOs.AuClass.Request;
using CMS.Shared.DTOs.AuClass.Response;

namespace CMS.API.Services.AuClass;

public interface IServices
{
  Task<Guid> CreateAsync(CreateAuClassRequest request);
  Task<Guid> UpdateAsync(Guid id, UpdateAuClassRequest request);
  Task<List<AuClassResponse>> GetAllAsync();
  Task DeleteAsync(Guid id);
}
