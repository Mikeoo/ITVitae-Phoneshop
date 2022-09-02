using Microsoft.Extensions.Caching.Memory;
using Phoneshop.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Phoneshop.Business
{
    public class Caching : ICaching
    {
        private readonly MemoryCache _cache = new(new MemoryCacheOptions());
        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks = new();
        public async Task<TItem> GetOrCreate<TItem>(string key, Func<TItem> createItem)
        {
            if (!_cache.TryGetValue(key, out TItem cacheEntry))
            {
                var mylock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));

                await mylock.WaitAsync();

                try
                {
                    if (!_cache.TryGetValue(key, out cacheEntry))
                    {
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromSeconds(20))
                            .SetAbsoluteExpiration(TimeSpan.FromHours(1));

                        cacheEntry = createItem();
                        _cache.Set(key, cacheEntry, cacheEntryOptions);
                    }
                }
                finally
                {
                    mylock.Release();
                }
            }

            return cacheEntry;
        }
    }
}
