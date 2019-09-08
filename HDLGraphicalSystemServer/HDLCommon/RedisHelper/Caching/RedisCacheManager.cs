using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Text;
using HDLCommon.RedisHelper.MemoryDb;
using System.Collections.Generic;

namespace HDLCommon.RedisHelper.Caching
{
    public partial class RedisCacheManager : ICacheManager
    {
        public CacheKeyType CacheKeyType { get; set; } = CacheKeyType.HdlCloudApi;

        #region 字段

        private readonly IRedisConnectionWrapper _connectionWrapper;
        private readonly IDatabase _db;
        private readonly ICacheManager _memoryCacheManager;

        #endregion

        #region 构造器

        public RedisCacheManager(IRedisConnectionWrapper connectionWrapper)
        {          
            // ConnectionMultiplexer.Connect只应调用一次并在调用者之间共享
            this._connectionWrapper = connectionWrapper;

            //默认就使用Redis 16个中的第一个数据库吧
            this._db = _connectionWrapper.GetDatabase();
          
            this._memoryCacheManager = new MemoryCacheManager();   //暂时这样
        }

        #endregion

        #region 实用方法

        protected virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }
        protected virtual T Deserialize<T>(byte[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            var jsonString = Encoding.UTF8.GetString(serializedObject);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        #endregion
                       
        #region 方法
              
        public virtual T Get<T>(string key)
        {
            //这里的小性能解决方法：
            //使用“PerRequestCacheManager”在内存中缓存当前HTTP请求的加载对象。
            //这样我们就不会每个HTTP请求连接到Redis服务器500次（例如，每次加载一个区域设置或设置）
            if (_memoryCacheManager.IsSet(key))
            {
                return _memoryCacheManager.Get<T>(key);
            }

            var rValue = _db.StringGet(key);
            if (!rValue.HasValue)
            {
                return default(T);
            }

            var result = Deserialize<T>(rValue);

            _memoryCacheManager.Set(key, result, 0);

            return result;
        }
   
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }

            var entryBytes = Serialize(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            _db.StringSet(key, entryBytes, expiresIn);
        }

        public virtual void Set(string key, object data)
        {
            if (data == null)
            {
                return;
            }

            var entryBytes = Serialize(data);

            _db.StringSet(key, entryBytes, null);
        }



        public virtual bool IsSet(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return false;
            }

            //这里的小性能解决方法：
            //使用“PerRequestCacheManager”在内存中缓存当前HTTP请求的加载对象。
            //这样我们就不会每个HTTP请求连接到Redis服务器500次（例如，每次加载一个区域设置或设置）
            if (_memoryCacheManager.IsSet(key))
            {
                return true;
            }

            return _db.KeyExists(key);
        }
      
        public virtual void Remove(string key)
        {
            DirectRemoveKey(key);
        }

        private void DirectRemoveKey(string key)
        {
            _db.KeyDelete(key);
            _memoryCacheManager.Remove(key);
        }

        public virtual void RemoveByPattern(string pattern)
        {
            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.GetServer(ep);
                var keys = server.Keys(database: _db.Database, pattern: "*" + pattern + "*");
                foreach (var key in keys)
                {
                    //Remove(KeyHp.GetCacheKey(key));
                    // Remove(key);
                    DirectRemoveKey(key);
                }
            }
        }

        public virtual void Clear()
        {
            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.GetServer(ep);
                //我们可以使用下面的代码（评论）
                //但它需要管理权限 - “，allowAdmin = true”
                //server.FlushDatabase();

                //这就是我们现在简单地遍历所有元素的原因
                var keys = server.Keys(database: _db.Database);

                foreach (var key in keys)
                {
                    //  Remove(key);
                    DirectRemoveKey(key);
                }
            }
        }

        /// <summary>
        /// 查询所有Keys值
        /// </summary>
        /// <param name="allKeysList"></param>
        public virtual List<string> GetAllkeys()
        {
            List<string> allKeysList = new List<string>();
            allKeysList.Clear();

            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.GetServer(ep);
                //我们可以使用下面的代码（评论）
                //但它需要管理权限 - “，allowAdmin = true”
                //server.FlushDatabase();

                //这就是我们现在简单地遍历所有元素的原因
                var keys = server.Keys(database: _db.Database);

                foreach (var key in keys)
                {
                    //  加入缓存
                    allKeysList.Add(key);
                }
            }

            return allKeysList;
        }

        /// <summary>
        /// 搜索关键字的Keys值
        /// </summary>
        /// <param name="allKeysList"></param>
        public virtual List<string> Get_keysList_ContainsKeyword(string searchKeys)
        {
            List<string>  allKeysList = new List<string>();
            allKeysList.Clear();

            foreach (var ep in _connectionWrapper.GetEndPoints())
            {
                var server = _connectionWrapper.GetServer(ep);
                //我们可以使用下面的代码（评论）
                //但它需要管理权限 - “，allowAdmin = true”
                //server.FlushDatabase();

                //这就是我们现在简单地遍历所有元素的原因
                var keys = server.Keys(database: _db.Database);

                foreach (var key in keys)
                {
                    //  加入缓存
                    if(key.ToString().Contains(searchKeys))
                    {
                        allKeysList.Add(key);
                    }                    
                }
            }

            return allKeysList;
        }

        public virtual void Dispose()
        {
            //if (_connectionWrapper != null)
            //    _connectionWrapper.Dispose();
        }
        #endregion
    }
}
