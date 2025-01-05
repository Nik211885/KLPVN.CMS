using CMS.Shared.DTOs.InfromationOrgaization.Request;
using CMS.Shared.DTOs.InfromationOrgaization.Response;

namespace CMS.API.Services.InformationOrganization;

public interface IServices
{
  /// <summary>
  ///   Create new information about organization if have information has active new information
  ///   will inactivate just have one information is active in system
  /// </summary>
  /// <param name="request">
  ///   Form about data need create 
  /// </param>
  /// <returns>
  ///   id for new information organization
  /// </returns>
  Task<Guid> CreateAsync(CreateInformationOrganizationRequest request);
  /// <summary>
  ///   update information about organization
  /// </summary>
  /// <param name="id">information has id</param>
  /// <param name="request">form data need update for information</param>
  /// <exception cref="Exceptions">
  ///   Throw not found exception if not find information has id
  /// </exception>
  /// <returns>
  ///   Return id for this information has update success
  /// </returns>
  Task<Guid> UpdateAsync(Guid id, UpdateInformationOrganizationRequest request);
  /// <summary>
  ///   Active information about organization in all information just have one information active
  ///   please inactive before active information it is ! compare old value in value
  /// </summary>
  /// <param name="id">id need active or inactive</param>
  /// <exception cref="Exceptions">
  ///   Throw notfound exception when not find information has id
  ///   and bad request exception when you want to active information but has information active before
  /// </exception>
  /// <returns>
  ///    Id for information has active success
  /// </returns>
  Task<Guid> ActiveAsync(Guid id);
  /// <summary>
  ///   Get all information about organization
  /// </summary>
  /// <returns>
  ///   Return all information 
  /// </returns>
  Task<List<InformationOrganizationResponse>> GetAllAsync();
  /// <summary>
  ///   Delete information about organization
  /// </summary>
  /// <param name="id">
  /// <exception cref="Exceptions">
  ///   Throw exception not found when not find infromation has id 
  /// </exception>
  /// </param>
  /// <returns></returns>
  Task DeleteAsync(Guid id);
  /// <summary>
  ///    Upload image url for information about organization
  /// </summary>
  ///  <param name="id">information has id</param>
  /// <param name="iconUrl">url icon for information</param>
  /// <exception cref="Exceptions">
  ///   Throw not found exception when not find information
  /// </exception>
  /// <returns>
  ///   Return id for information has upload success
  /// </returns>
  Task<Guid> UploadIconAsync(Guid id, string iconUrl);
}
