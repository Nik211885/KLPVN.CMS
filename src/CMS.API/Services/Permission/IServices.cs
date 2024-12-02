namespace CMS.API.Services.Permission;

public interface IServices
{
  Task<Guid> CreateAsync(Guid objectId, Guid auActionClassId);
  Task DeleteAsync(Guid objectId, Guid auActionClassId);
}
