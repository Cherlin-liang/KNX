using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.DevicesEntity;
using HDLApiEntity.DeviceStatusDataEntity;
using HDLApiEntity.EnumEntity;
using HDLApiEntity.RelationEntity;
using HDLApiEntity.WebsocketEntity;
using HDLCommon.RedisHelper;
using HDLCommon.RedisHelper.Caching;
using HDLCommon.RedisHelper.MemoryDb;
using Newtonsoft.Json;

namespace HDLCommon
{

    /// <summary>
    /// 驱动层操作Redis数据辅助类
    /// </summary>
    public class RedisController
    {
        /// <summary>
        /// 静态构造函数，只执行一次
        /// </summary>
        static RedisController()
        {
            redisKeyControl = new RedisCacheManager(new RedisConnectionWrapper());

            redisReport = new RedisStackExchangeHelper();
        }

        /// <summary>
        /// 控制Redis的Key
        /// </summary>
        private static RedisCacheManager redisKeyControl;

        /// <summary>
        /// 上报Redis数据处理
        /// </summary>
        private static RedisStackExchangeHelper redisReport;

        #region  //BUS功能模块的设备状态上报调用函数

        /**
        *
        * @api {Class Method} / BUS驱动的灯光状态上报
        * @apiName bus lamp device status report
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 状态上报调用的函数
        * 
        * public static void Bus_Device_Status_Report_Lamp(DatasLamp deviceStatusObj)
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiParam {DatasLamp} deviceStatusObj 灯光状态对象
        *
        */
        /// <summary>
        /// 灯光，设备状态上报
        /// </summary>
        /// <param name="deviceStatusObj">灯光数据上报对象</param>
        public static void Bus_Device_Status_Report_Lamp(DatasLamp deviceStatusObj)
        {
            redisReport.PublishAsync(RedisThemeType.Bus_Device_Report_Lamp.ToString(), JsonConvert.SerializeObject(deviceStatusObj));
        }

        /**
        *
        * @api {Class Method} / BUS驱动的窗帘状态上报
        * @apiName bus curtain device status report
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 状态上报调用的函数
        * 
        * public static void Bus_Device_Status_Report_Curtain(DatasCurtain deviceStatusObj)
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiParam {DatasCurtain} deviceStatusObj 窗帘状态对象
        *
        */
        /// <summary>
        /// 窗帘，设备状态上报
        /// </summary>
        /// <param name="deviceStatusObj">窗帘数据上报对象</param>
        public static void Bus_Device_Status_Report_Curtain(DatasCurtain deviceStatusObj)
        {
            redisReport.PublishAsync(RedisThemeType.Bus_Device_Report_Curtain.ToString(), JsonConvert.SerializeObject(deviceStatusObj));
        }

        /**
        *
        * @api {Class Method} / BUS驱动的空调状态上报
        * @apiName bus air device status report
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 状态上报调用的函数
        * 
        * public static void Bus_Device_Status_Report_Air(DatasAir deviceStatusObj)
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiParam {DatasAir} deviceStatusObj 空调状态对象
        *
        */
        /// <summary>
        /// 空调，设备状态上报
        /// </summary>
        /// <param name="deviceStatusObj">空调数据上报对象</param>
        public static void Bus_Device_Status_Report_Air(DatasAir deviceStatusObj)
        {
            redisReport.PublishAsync(RedisThemeType.Bus_Device_Report_Air.ToString(), JsonConvert.SerializeObject(deviceStatusObj));
        }

        /**
        *
        * @api {Class Method} / BUS驱动的远程控制上报
        * @apiName bus remote device control
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 状态上报调用的函数
        * 
        * public static void Bus_Remote_Control(string gateRoomGuid, byte[] mqttDatas)
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiParam {String} gateRoomGuid 设备所属的住宅ID
        * @apiParam {byte[]} mqttDatas 远程控制的完整附加数据
        *
        */
        /// <summary>
        /// 驱动通知，远程BUS设备控制
        /// </summary>
        /// <param name="gateRoomGuid"></param>
        /// <param name="mqttDatas"></param>
        public static void Bus_Remote_Control(string gateRoomGuid, byte[] mqttDatas)
        {
            BUS_Remote_Control_Object busRemoteObj = new BUS_Remote_Control_Object();

            busRemoteObj.HomeRoomGuid = gateRoomGuid;
            busRemoteObj.MqttDatas = mqttDatas;

            redisReport.PublishAsync(RedisThemeType.Bus_Remote_Control.ToString(), JsonConvert.SerializeObject(busRemoteObj));
        }

        #endregion

        #region  //KNX功能模块的设备状态上报调用函数


        /**
        *
        * @api {Class Method} / KNX驱动的灯光状态上报
        * @apiName KNX lamp device status report
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 状态上报调用的函数
        * 
        * public static void KNX_Device_Status_Report_Lamp(DatasLamp deviceStatusObj)
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiParam {DatasLamp} deviceStatusObj 灯光状态对象
        *
        */
        /// <summary>
        /// 灯光，设备状态上报
        /// </summary>
        /// <param name="deviceStatusObj">灯光数据上报对象</param>
        public static void KNX_Device_Status_Report_Lamp(DatasLamp deviceStatusObj)
        {
            redisReport.PublishAsync(RedisThemeType.KNX_Device_Report_Lamp.ToString(), JsonConvert.SerializeObject(deviceStatusObj));
        }

        /**
        *
        * @api {Class Method} / KNX驱动的窗帘状态上报
        * @apiName KNX curtain device status report
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 状态上报调用的函数
        * 
        * public static void KNX_Device_Status_Report_Curtain(DatasCurtain deviceStatusObj)
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiParam {DatasCurtain} deviceStatusObj 窗帘状态对象
        *
        */
        /// <summary>
        /// 窗帘，设备状态上报
        /// </summary>
        /// <param name="deviceStatusObj">窗帘数据上报对象</param>
        public static void KNX_Device_Status_Report_Curtain(DatasCurtain deviceStatusObj)
        {
            redisReport.PublishAsync(RedisThemeType.KNX_Device_Report_Curtain.ToString(), JsonConvert.SerializeObject(deviceStatusObj));
        }

        /**
        *
        * @api {Class Method} / KNX驱动的空调状态上报
        * @apiName KNX air device status report
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 状态上报调用的函数
        * 
        * public static void KNX_Device_Status_Report_Air(DatasAir deviceStatusObj)
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiParam {DatasAir} deviceStatusObj 空调状态对象
        *
        */
        /// <summary>
        /// 空调，设备状态上报
        /// </summary>
        /// <param name="deviceStatusObj">空调数据上报对象</param>
        public static void KNX_Device_Status_Report_Air(DatasAir deviceStatusObj)
        {
            redisReport.PublishAsync(RedisThemeType.KNX_Device_Report_Air.ToString(), JsonConvert.SerializeObject(deviceStatusObj));
        }


        /**
        *
        * @api {Class Method} / KNX驱动的远程控制上报
        * @apiName KNX remote device control
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 状态上报调用的函数
        * 
        * public static void KNX_Remote_Control(string gateRoomGuid, byte[] mqttDatas)
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiParam {String} gateRoomGuid 设备所属的住宅ID
        * @apiParam {byte[]} mqttDatas 远程控制的完整附加数据
        *
        */
        /// <summary>
        /// 驱动通知，远程KNX设备控制
        /// </summary>
        /// <param name="gateRoomGuid"></param>
        /// <param name="mqttDatas"></param>
        public static void KNX_Remote_Control(string gateRoomGuid, byte[] mqttDatas)
        {
            KNX_Remote_Control_Object knxRemoteObj = new KNX_Remote_Control_Object();

            knxRemoteObj.HomeRoomGuid = gateRoomGuid;
            knxRemoteObj.MqttDatas = mqttDatas;

            redisReport.PublishAsync(RedisThemeType.KNX_Remote_Control.ToString(), JsonConvert.SerializeObject(knxRemoteObj));
        }

        #endregion

        #region  //驱动层获取设备状态的接口


        /**
        *
        * @api {Class Method} /  获取所有设备基本信息
        * @apiName Get all device information list
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 获取所有设备的基本信息的函数
        * 
        * public static List<BaseDeviceInfo>  Load_All_BasicDeviceInfo_Redis()
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiSuccessExample Success-Response:
        * 成功返回List<BaseDeviceInfo>集合       
        *
        *  @apiErrorExample {json} Error-Response:
        *  返回Null        
        */
        /// <summary>
        /// 获取所有设备基本信息
        /// </summary>
        /// <returns></returns>
        public static List<BaseDeviceInfo>  Load_All_BasicDeviceInfo_Redis()
        {
            //判断key存在
            if (redisKeyControl.IsSet(RedisKeyType.AllBasicDeviceInfo.ToString()))
            {
                List<BaseDeviceInfo> CacheList = redisKeyControl.Get<List<BaseDeviceInfo>>(RedisKeyType.AllBasicDeviceInfo.ToString());

                if (CacheList != null) return CacheList;
            }

            return null;
        }


        /**
        *
        * @api {Class Method} /  获取所有模块信息
        * @apiName Get all module information list
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 获取所有模块信息的函数
        * 
        * public static List<ModuleInfo> Load_All_ModuleInfo_Redis()
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiSuccessExample Success-Response:
        * 成功返回List<ModuleInfo>集合       
        *
        *  @apiErrorExample {json} Error-Response:
        *  返回Null        
        */
        /// <summary>
        /// 获取所有模块信息
        /// </summary>
        /// <returns></returns>
        public static List<ModuleInfo> Load_All_ModuleInfo_Redis()
        {
            //判断key存在
            if (redisKeyControl.IsSet(RedisKeyType.AllModuleInfoList.ToString()))
            {
                List<ModuleInfo> CacheList = redisKeyControl.Get<List<ModuleInfo>>(RedisKeyType.AllModuleInfoList.ToString());

                if (CacheList != null) return CacheList;
            }

            return null;
        }

        /**
        *
        * @api {Class Method} /  获取所有模块与设备的关系信息
        * @apiName Get relate module and device
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 获取所有模块与设备的关系信息的函数
        * 
        * public static List<Relate_Module_Device> Load_All_Relate_ModuleDevice_Redis()
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiSuccessExample Success-Response:
        * 成功返回List<Relate_Module_Device>集合       
        *
        *  @apiErrorExample {json} Error-Response:
        *  返回Null        
        */
        /// <summary>
        /// 获取所有模块与设备的关系信息
        /// </summary>
        /// <returns></returns>
        public static List<Relate_Module_Device> Load_All_Relate_ModuleDevice_Redis()
        {
            //判断key存在
            if (redisKeyControl.IsSet(RedisKeyType.AllRelateModuleDeviceList.ToString()))
            {
                List<Relate_Module_Device> CacheList = redisKeyControl.Get<List<Relate_Module_Device>>(RedisKeyType.AllRelateModuleDeviceList.ToString());

                if (CacheList != null) return CacheList;
            }

            return null;
        }

        /**
        *
        * @api {Class Method} /  获取灯光的状态数据
        * @apiName Get lamp status
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 获取灯光的状态数据的函数
        * 
        * public static DatasLamp Get_Datas_Lamp_Redis(string devGuid)
        * 
        * 参数devGuid,是灯光设备的唯一guid值
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiSuccessExample Success-Response:
        * 成功返回 DatasLamp 对象       
        *
        *  @apiErrorExample {json} Error-Response:
        *  返回Null        
        */
        /// <summary>
        /// 获取灯光的状态数据
        /// </summary>
        /// <param name="devGuid"></param>
        /// <returns></returns>
        public static DatasLamp Get_Datas_Lamp_Redis(string devGuid)
        {
            //判断key存在
            if (redisKeyControl.IsSet(RedisKeyType.DatasLampList.ToString()))
            {
                List<DatasLamp> CacheList = redisKeyControl.Get<List<DatasLamp>>(RedisKeyType.DatasLampList.ToString());

                if (CacheList != null)
                {
                    foreach (var item in CacheList)
                    {
                        if (item.DeviceGuid == devGuid) return item;
                    }
                }
            }

            return null;
        }

        /**
        *
        * @api {Class Method} /  获取窗帘的状态数据
        * @apiName Get curtain status
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 获取窗帘的状态数据的函数
        * 
        * public static DatasCurtain Get_Datas_Curtain_Redis(string devGuid)
        * 
        * 参数devGuid,是窗帘设备的唯一guid值
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiSuccessExample Success-Response:
        * 成功返回 DatasCurtain 对象       
        *
        *  @apiErrorExample {json} Error-Response:
        *  返回Null        
        */
        /// <summary>
        /// 获取窗帘的状态数据
        /// </summary>
        /// <param name="devGuid"></param>
        /// <returns></returns>
        public static DatasCurtain Get_Datas_Curtain_Redis(string devGuid)
        {
            //判断key存在
            if (redisKeyControl.IsSet(RedisKeyType.DatasCurtainList.ToString()))
            {
                List<DatasCurtain> CacheList = redisKeyControl.Get<List<DatasCurtain>>(RedisKeyType.DatasCurtainList.ToString());

                if (CacheList != null)
                {
                    foreach (var item in CacheList)
                    {
                        if (item.DeviceGuid == devGuid) return item;
                    }
                }
            }

            return null;
        }

        /**
        *
        * @api {Class Method} /  获取空调的状态数据
        * @apiName Get air status
        * @apiGroup 驱动接口
        * @apiVersion 1.0.1
        * @apiDescription 
        * 
        * 函数接口，跟HttpRequest请求的接口调用方法不一样，需要引用DLL文件直接调用
        * HDLCommon.dll、HDLApiEntity.dll 驱动接口的DLL库文件
        * 
        * 获取空调的状态数据的函数
        * 
        * public static DatasAir Get_Datas_Air_Redis(string devGuid)
        * 
        * 参数devGuid,是空调设备的唯一guid值
        *
        * 函数接口请忽略下面的URL前缀地址
        * 
        * @apiSuccessExample Success-Response:
        * 成功返回 DatasAir 对象       
        *
        *  @apiErrorExample {json} Error-Response:
        *  返回Null        
        */
        /// <summary>
        /// 获取空调的状态数据
        /// </summary>
        /// <param name="devGuid"></param>
        /// <returns></returns>
        public static DatasAir Get_Datas_Air_Redis(string devGuid)
        {
            //判断key存在
            if (redisKeyControl.IsSet(RedisKeyType.DatasAirList.ToString()))
            {
                List<DatasAir> CacheList = redisKeyControl.Get<List<DatasAir>>(RedisKeyType.DatasAirList.ToString());

                if (CacheList != null)
                {
                    foreach (var item in CacheList)
                    {
                        if (item.DeviceGuid == devGuid) return item;
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
