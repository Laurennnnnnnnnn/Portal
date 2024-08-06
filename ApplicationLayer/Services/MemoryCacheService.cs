using ApplicationLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace ApplicationLayer.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private static readonly HashSet<string> _cacheKeys = new HashSet<string>();

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public TItem Get<TItem>(string key)
        {
            return _memoryCache.Get<TItem>(key);
        }

        public void Set<TItem>(string key, TItem value, TimeSpan expiration)
        {
            _memoryCache.Set(key, value, expiration);
            _cacheKeys.Add(key);
        }

        public bool TryGetValue<TItem>(string key, out TItem value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }
        public async Task ClearAllCache()
        {
            foreach (var key in _cacheKeys)
            {
                _memoryCache.Remove(key);
            }
            _cacheKeys.Clear();
        }
    }
}
