using CMS.Shared.DTOs.FeedBack.Request;
using KLPVN.Core.Models;

namespace CMS.API.Services.FeedBack;

public interface IServices
{
  /// <summary>
  ///   Create new feed back
  /// </summary>
  /// <param name="request">Information feed back</param>
  /// <returns>
  ///   Return id for new feed back has created
  /// </returns>
  Task<Guid> CreateAsync(CreateFeedBackRequest request);
  /// <summary>
  ///   Delete feed back
  /// </summary>
  /// <param name="id">Feedback has id</param>
  /// <exception cref="Exceptions">
  ///   Throw not found exception if not find feed back has id
  /// </exception>
  /// <returns></returns>
  Task DeleteAsync(Guid id);
  /// <summary>
  ///   Get all feed back
  /// </summary>
  /// <param name="search">search all in param is operator or sql</param>
  /// <returns>
  ///   Return all feed back has match with conditions search
  /// </returns>
  Task<IReadOnlyCollection<Entities.FeedBack>> GetAllFeedBackAsync(string? search = null);
  /// <summary>
  ///   Get feed back with pagination
  /// </summary>
  /// <param name="page">page number</param>
  /// <param name="size">size for one page</param>
  /// <param name="search">search all in param is operator or sql</param>
  /// <returns>
  ///   Return all feed backs with pagination has match condition search
  /// </returns>
  Task<Pagination<Entities.FeedBack>> GetFeedBackWithPaginationAsync(int page, int size, string? search = null);
  /// <summary>
  ///   Delete fake ;)) bulk feed back
  /// </summary>
  /// <param name="ids">ids list id for feed back need delete</param>
  /// <returns>
  /// </returns>
  Task DeleteListAsync(IEnumerable<Guid> ids);
}
