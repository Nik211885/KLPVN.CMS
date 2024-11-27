using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;

namespace CMS.API.Infrastructure.Caching.Memory;

public class MemoryCacheManager : IMemoryCacheManager
{
  private readonly ConcurrentDictionary<string, Lazy<IMemoryCache>> _memoryCaches = new();
  public IMemoryCache GetMemoryCache(string key)
  {
    return _memoryCaches.GetOrAdd(
      key,
      _ => new Lazy<IMemoryCache>(() => new MemoryCache(new MemoryCacheOptions()),
      LazyThreadSafetyMode.ExecutionAndPublication)
    ).Value;
  }
}
