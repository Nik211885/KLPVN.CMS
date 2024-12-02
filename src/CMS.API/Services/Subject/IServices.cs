using CMS.Shared.DTOs.Subject.Request;

namespace CMS.API.Services.Subject;

public interface IServices
{
  Task<Guid> CreateAsync(CreateSubjectRequest request);
  Task<Guid> UpdateAsync(Guid id, UpdateSubjectRequest request);
  Task<Guid> ActiveAsync(Guid id);
  Task DeleteAsync(Guid id);
}
