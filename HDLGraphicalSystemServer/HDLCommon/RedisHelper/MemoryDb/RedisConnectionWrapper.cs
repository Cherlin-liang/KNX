using RedLock;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Net;


namespace HDLCommon.RedisHelper.MemoryDb
{
    public class RedisConnectionWrapper : IRedisConnectionWrapper
    {
        #region 字段

        private readonly Lazy<string> _connectionString;

        private volatile ConnectionMultiplexer _connection;
        //private volatile RedisLockFactory _redisLockFactory;
        //锁标识
        private readonly object _lock = new object();

        #endregion

        #region 构造器

        public RedisConnectionWrapper()
        {
            this._connectionString = new Lazy<string>(GetConnectionString);
            //this._redisLockFactory = CreateRedisLockFactory();
        }

        #endregion

        #region 实用方法

        /// <summary>
        /// 从配置中获取Redis缓存的连接字符串
        /// </summary>
        /// <returns></returns>
        protected string GetConnectionString()
        {
            return "127.0.0.1:6379,allowAdmin = true,password=" + XmlHelper.Redis_Password;
        }

        protected ConnectionMultiplexer GetConnection()
        {
            if (_connection != null && _connection.IsConnected)
            {
                return _connection;
            }

            lock (_lock)
            {
                if (_connection != null && _connection.IsConnected)
                {
                    return _connection;
                }

                if (_connection != null)
                {
                    _connection.Dispose();
                }

                //创建Redis Connection的新实例
                _connection = ConnectionMultiplexer.Connect(_connectionString.Value);
            }

            return _connection;
        }

        ///// <summary>
        ///// 创建RedisLockFactory的实例
        ///// </summary>
        ///// <returns>RedisLockFactory</returns>
        //protected RedisLockFactory CreateRedisLockFactory()
        //{
        //    //获取密码和值是否使用连接字符串中的ssl
        //    var password = string.Empty;
        //    var useSsl = false;
        //    foreach (var option in GetConnectionString().Split(',').Where(option => option.Contains('=')))
        //    {
        //        switch (option.Substring(0, option.IndexOf('=')).Trim().ToLowerInvariant())
        //        {
        //            case "password":
        //                password = option.Substring(option.IndexOf('=') + 1).Trim();
        //                break;
        //            case "ssl":
        //                bool.TryParse(option.Substring(option.IndexOf('=') + 1).Trim(), out useSsl);
        //                break;
        //        }
        //    }

        //    //create RedisLockFactory for using Redlock distributed lock algorithm
        //    return new RedisLockFactory(GetEndPoints().Select(endPoint => new RedisLockEndPoint
        //    {
        //        EndPoint = endPoint,
        //        Password = password,
        //        Ssl = useSsl
        //    }));
        //}

        #endregion

        #region Methods


        public IDatabase GetDatabase(int? db = null)
        {
            return GetConnection().GetDatabase(db ?? -1); //_settings.DefaultDb);
        }

        public IServer GetServer(EndPoint endPoint)
        {
            return GetConnection().GetServer(endPoint);
        }

        public EndPoint[] GetEndPoints()
        {
            return GetConnection().GetEndPoints();
        }

        public void FlushDatabase(int? db = null)
        {
            var endPoints = GetEndPoints();

            foreach (var endPoint in endPoints)
            {
                GetServer(endPoint).FlushDatabase(db ?? -1); //_settings.DefaultDb);
            }
        }


        //public bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action)
        //{
        //    //使用RedLock库
        //    using (var redisLock = _redisLockFactory.Create(resource, expirationTime))
        //    {
        //        //确保获得锁定
        //        if (!redisLock.IsAcquired)
        //        {
        //            return false;
        //        }

        //        //执行
        //        action();
        //        return true;
        //    }
        //}

        /// <summary>
        /// 释放与此对象关联的所有资源
        /// </summary>
        public void Dispose()
        {
            //释放 ConnectionMultiplexer
            if (_connection != null)
            {
                _connection.Dispose();
            }

            ////处理RedisLockFactory
            //if (_redisLockFactory != null)
            //{
            //    _redisLockFactory.Dispose();
            //}
        }

        #endregion
    }
}
