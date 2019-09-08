using System;


namespace HDLCommon.RedisHelper.Caching
{
    /// <summary>
    /// 缓存管理器接口
    /// </summary>
    public interface ICacheManager : IDisposable
    {
        /// <summary>
        /// 缓存键前缀类型
        /// </summary>
        CacheKeyType CacheKeyType { get; set; }

        /// <summary>
        ///获取或设置与指定键相关联的值。
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="key">得到这个键的值</param>
        /// <returns>与指定键相关联的值</returns>
        T Get<T>(string key);

        /// <summary>
        /// 将指定的键和对象添加到缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="data">数据</param>
        /// <param name="cacheTime">缓存时间</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// 设置永久的Key,没有过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        void Set(string key, object data);

        /// <summary>
        /// 获取一个值，指示与指定键相关联的值是否被缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>结果</returns>
        bool IsSet(string key);

        /// <summary>
        /// 从缓存中删除指定键的值
        /// </summary>
        /// <param name="key">键</param>
        void Remove(string key);

        /// <summary>
        /// Removes items by pattern
        /// </summary>
        /// <param name="pattern">pattern</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        ///清除所有缓存数据
        /// </summary>
        void Clear();
    }
}
