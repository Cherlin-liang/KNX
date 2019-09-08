using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLCommon.RedisHelper;
using HDLCommon.RedisHelper.Caching;
using HDLCommon.RedisHelper.MemoryDb;
using Newtonsoft.Json;

namespace HDLCommon
{

    /// <summary>
    /// 操作Redis的keys处理的工具类
    /// </summary>
    public class RedisKeyTool
    {
        /// <summary>
        /// 控制Redis的Key
        /// </summary>
        private static RedisCacheManager _redisKeyManager;

        /// <summary>
        /// 控制Redis的业务逻辑
        /// </summary>
        private static RedisStackExchangeHelper _redisBusiness;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static RedisKeyTool()
        {
            _redisKeyManager = new RedisCacheManager(new RedisConnectionWrapper());

            _redisBusiness = new RedisStackExchangeHelper();
        }

        /// <summary>
        /// 设置Redis的key-value值,不存在新增，存在则覆盖
        /// </summary>
        /// <param name="keyStr"></param>
        /// <param name="valueObj"></param>
        public static void Set_Key_ObjectValue(string keyStr,object valueObj)
        {
            try
            {
                _redisKeyManager.Set(keyStr, valueObj);
            }
            catch(Exception ex)
            {
               XmlHelper.Export_Log_Error("Set Redis Key-value Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// 设置Redis的key-value值,不存在新增，存在则覆盖
        /// </summary>
        /// <param name="keyStr"></param>
        /// <param name="valueJsonString"></param>
        public static void Set_Key_StringValue(string keyStr, string valueJsonString)
        {
            try
            {
                _redisBusiness.StringSet(keyStr, valueJsonString);
            }
            catch (Exception ex)
            {
                XmlHelper.Export_Log_Error("Set Redis Key-value Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// 获取缓存里的Key对应的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyStr"></param>
        /// <returns></returns>
        public static T GetValue_With_Key<T>(string keyStr)
        {
            try
            {
                return _redisKeyManager.Get<T>(keyStr);
            }
            catch (Exception ex)
            {
                XmlHelper.Export_Log_Error("GetValue_With_Key Exception: " + ex.Message);

                return default(T);
            }
        }

        /// <summary>
        /// 判断Redis数据的Key值是否存在
        /// </summary>
        /// <param name="keyStr"></param>
        /// <returns></returns>
        public static bool Is_Key_Exist(string keyStr)
        {
            try
            {
                return _redisKeyManager.IsSet(keyStr);
            }
            catch (Exception ex)
            {
                XmlHelper.Export_Log_Error("Is_Key_Exist Exception: " + ex.Message);

                return false;
            }
        }
        
        /// <summary>
        /// 获取Redis数据库的所有Keys集合
        /// </summary>
        /// <returns></returns>
        public static List<string> Get_All_Redis_Keys_List()
        {            
            try
            {
                return _redisKeyManager.GetAllkeys();
            }
            catch (Exception ex)
            {
                XmlHelper.Export_Log_Error("GetAllkeys Exception: " + ex.Message);

                return null;
            }
        }

        /// <summary>
        /// 获取包含keyword关键字的keys集合
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public static List<string> Get_Redis_Keys_List(string keyWord)
        {            
            try
            {
                return _redisKeyManager.Get_keysList_ContainsKeyword(keyWord);
            }
            catch (Exception ex)
            {
                XmlHelper.Export_Log_Error("Get_keysList_ContainsKeyword Exception: " + ex.Message);

                return null;
            }
        }
        
        /// <summary>
        /// 删除缓存里的一个key值对
        /// </summary>
        /// <param name="oneKeyStr"></param>
        public static void Delete_One_Key(string oneKeyStr)
        {
            try
            {
                _redisKeyManager.Remove(oneKeyStr);
            }
            catch (Exception ex)
            {
                XmlHelper.Export_Log_Error("Delete_One_Key Exception: " + ex.Message);                
            }
        }

        /// <summary>
        /// 删除缓存里的所有keys值对
        /// </summary>
        public static void Clear_All_Keys()
        {
            try
            {
                _redisKeyManager.Clear();
            }
            catch (Exception ex)
            {
                XmlHelper.Export_Log_Error("Clear_All_Keys Exception: " + ex.Message);
            }
        }



        
    }
}
