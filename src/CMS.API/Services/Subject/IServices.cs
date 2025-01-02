using CMS.Shared.DTOs.Subject.Request;
using CMS.Shared.DTOs.Subject.Response;

namespace CMS.API.Services.Subject;

public interface IServices
{
  /// <summary>
  ///   Create new subject
  /// </summary>
  /// <param name="request">Information about subject</param>
  /// <exception cref="Exception">
  ///   Throw exception if not found subject
  /// </exception>
  /// <returns>
  ///   Return id for new subject has created success
  /// </returns>
  Task<Guid> CreateAsync(CreateSubjectRequest request);
  /// <summary>
  ///   Update information about subject
  /// </summary>
  /// <param name="id">id for subject need update</param>
  /// <param name="request">information about subject need update</param>
  /// <exception cref="Exception">Throw exception notfound if not find subject has id</exception>
  /// <returns>
  ///   Return id for subject has update success
  /// </returns>
  Task<Guid> UpdateAsync(Guid id, UpdateSubjectRequest request);
  /// <summary>
  ///     Active subject
  /// </summary>
  /// <param name="id">subject has id if active all contents will disable in public pages</param>
  /// <exception cref="Exception">Throw exception notfound if not find subject has id</exception>
  /// <returns>
  ///   Return id for subject has active success
  /// </returns>
  Task<Guid> ActiveAsync(Guid id);
  /// <summary>
  ///     Delete subject
  /// </summary>
  /// <param name="id">Subject has id</param>
  /// <exception cref="Exception">Throw exception notfound if not find subject has id</exception>
  /// <returns>
  ///
  /// </returns>
  Task DeleteAsync(Guid id);
  /// <summary>
  ///   Get all subject
  /// </summary>
  /// <param name="isActive">
  ///   Get all subject has status is active
  ///   If active is null get all subject no filter for active
  /// </param>
  /// <returns>
  ///   Return list subject response 
  /// </returns>
  Task<SubjectResponse> GetAllSubjectAsync(bool? isActive = true);
}
