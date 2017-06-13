using System;
using System.Runtime.Caching;

namespace mqlib
{
    public class mqCache
    {
          ObjectCache cache = MemoryCache.Default;
          CacheItemPolicy cacheItemPolicy ;    
        public mqCache()
        {
            cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(24.0);  
        }
        public void AddToCache(string key,dynamic value)
        {
            cache.Add(key, value, cacheItemPolicy);
        }
        public dynamic GetFromCache(string key)
        {
            return cache.Get(key);
        }
        public dynamic RemoveFromCache(string key)
        {
            return cache.Remove(key);
        }
    }
}
