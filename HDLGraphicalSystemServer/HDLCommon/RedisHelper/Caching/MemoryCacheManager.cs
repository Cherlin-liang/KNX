using System;
using System.Linq;
using System.Runtime.Caching;

namespace HDLCommon.RedisHelper.Caching
{
    public partial class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        public CacheKeyType CacheKeyType { get; set; } = CacheKeyType.HdlCloudApi;

        public virtual T Get<T>(string key)
        {
            return (T)this.Cache[key];
        }

        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            //DateTimeOffset
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            this.Cache.Add(new CacheItem(key, data), policy);
        }
        public virtual bool IsSet(string key)
        {
            return (this.Cache.Contains(key));
        }
        public virtual void Remove(string key)
        {
            this.Cache.Remove(key);
        }
        public virtual void RemoveByPattern(string pattern)
        {
            this.RemoveByPattern(pattern, Cache.Select(p => p.Key));
        }
        public virtual void Clear()
        {
            foreach (var item in Cache)
            {
                this.Remove(item.Key);
            }
        }
        public virtual void Dispose()
        {
            (this.Cache as MemoryCache).Dispose();
        }

        public void Set(string key, object data)
        {
            throw new NotImplementedException();
        }
    }
}
