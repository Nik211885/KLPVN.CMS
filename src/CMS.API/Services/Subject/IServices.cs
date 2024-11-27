using CMS.API.DTOs.Subject.Request;

namespace CMS.API.Services.Subject;

public interface IServices
{
  Task<Guid> CreateAsync(CreateSubjectRequest request);
}
