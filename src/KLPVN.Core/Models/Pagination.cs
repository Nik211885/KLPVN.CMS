using Microsoft.EntityFrameworkCore;

namespace KLPVN.Core.Models;

public class Pagination<TEntity>(IReadOnlyCollection<TEntity> items,
  int pageNumber, int pageSize, int totalItems)
  where TEntity : class
{
  public IReadOnlyCollection<TEntity> Items { get; } = items;
  public int PageNumber { get;  } = pageNumber;
  public int TotalPages { get; } = (int)Math.Ceiling(totalItems / (double)pageSize);
  public int TotalItems { get;} = totalItems;

  // offset => getSkipRows and limit is page sizes
  public static int GetSkipRows(int pageNumber, int pageSize)
    => (pageNumber - 1) * pageSize;
  // offset, limit
  public bool HasPreviousPage => PageNumber > 1;
  public bool HasNextPage => PageNumber < TotalPages;
  public static async Task<Pagination<TEntity>> GetPaginationForQueryableAsync(IQueryable<TEntity> source, 
    int pageNumber, int pageSize)
  {
    var totalItems = await source.CountAsync();
    var items = await source.Skip(GetSkipRows(pageNumber,pageSize)).Take(pageSize).ToListAsync();
    return new Pagination<TEntity>(items, pageNumber, pageSize, totalItems);
  }
}
