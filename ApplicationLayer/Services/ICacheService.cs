using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface ICacheService
    {
        TItem Get<TItem>(string key);
        void Set<TItem>(string key, TItem value, TimeSpan expiration);
        bool TryGetValue<TItem>(string key, out TItem value);
        Task ClearAllCache();
    }
}
