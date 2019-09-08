using System;
using System.Net;
using StackExchange.Redis;

namespace HDLCommon.RedisHelper.MemoryDb
{
    /// <summary>
    /// Redis连接包装器接口
    /// </summary>
    public interface IRedisConnectionWrapper : IDisposable
    {
        /// <summary>
        /// 获取redis内部数据库的交互式连接
        /// </summary>
        /// <param name="db">数据库号; 传递null以使用默认值</param>
        /// <returns>Redis缓存数据库</returns>
        IDatabase GetDatabase(int? db = null);

        /// <summary>
        /// 获取单个服务器的配置API
        /// </summary>
        /// <param name="endPoint">网络端点</param>
        /// <returns>Redis服务器</returns>
        IServer GetServer(EndPoint endPoint);

        /// <summary>
        /// 获取服务器上定义的所有端点
        /// </summary>
        /// <returns>端点数组</returns>
        EndPoint[] GetEndPoints();

        /// <summary>
        /// 删除数据库的所有键
        /// </summary>
        /// <param name="db">数据库号; 传递null以使用默认值<</param>
        void FlushDatabase(int? db = null);

        ///// <summary>
        ///// 使用Redis分布式锁执行某些操作
        ///// </summary>
        ///// <param name="resource">锁定的资源</param>
        ///// <param name="expirationTime">Redis自动锁定锁定的时间</param>
        ///// <param name="action">要使用锁定执行的操作</param>
        ///// <returns>如果获得锁定并执行操作，则为True; 否则是假的</returns>
        //bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action);
    }
}
