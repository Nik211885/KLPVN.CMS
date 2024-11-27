using Microsoft.Extensions.Caching.Memory;

namespace CMS.API.Infrastructure.Caching.Memory;

public interface IMemoryCacheManager
{
  IMemoryCache GetMemoryCache(string key);
}
