using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HDLCommon.RedisHelper.Caching
{
    /// <summary>
    /// 缓存扩展
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// 获取一个缓存项目。 如果它尚未在缓存中，请加载并缓存它
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cacheManager">缓存管理器</param>
        /// <param name="key">缓存键</param>
        /// <param name="acquire">加载项目的函数，如果它尚未在缓存中</param>
        /// <returns>缓存项目</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        /// <summary>
        /// 获取一个缓存项目。 如果它尚未在缓存中，请加载并缓存它
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="cacheManager">缓存管理器</param>
        /// <param name="key">缓存键</param>
        /// <param name="cacheTime">缓存时间（分钟）（0 - 不缓存）</param>
        /// <param name="acquire">加载项目的函数，如果它尚未在缓存中</param>
        /// <returns>缓存项目</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }

            var result = acquire();
            if (cacheTime > 0)
            {
                cacheManager.Set(key, result, cacheTime);
            }
            return result;
        }

        /// <summary>
        ///通过模式删除项目
        /// </summary>
        /// <param name="cacheManager">缓存管理器</param>
        /// <param name="pattern">模式</param>
        /// <param name="keys">缓存中的所有密钥</param>
        public static void RemoveByPattern(this ICacheManager cacheManager, string pattern, IEnumerable<string> keys)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var removeCacheKeyList=keys.Where(p => regex.IsMatch(p.ToString())).ToList();
            foreach (var key in removeCacheKeyList)
            {
                cacheManager.Remove(key);
            }
        }
    }
}
