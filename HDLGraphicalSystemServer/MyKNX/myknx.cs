using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.DeviceStatusDataEntity;
using HDLApiEntity.DevicesEntity;
using HDLApiEntity.EnumEntity;
using Newtonsoft.Json;
using HDLCommon;

namespace HDLGraphicalSystemServer.MyKNX
{
    [Serializable]
    public class myknx
    {
        
        public static List<BaseDeviceInfo> baseDeviceInfos = new List<BaseDeviceInfo>();
        public static List<ModuleInfo> moduleInfos = new List<ModuleInfo>();
        /// <summary>
        /// 所有灯光状态列表
        /// </summary>
        public static List<DatasLamp> LampStatusList = new List<DatasLamp>();
        /// <summary>
        /// 所有窗帘状态列表
        /// </summary>
        public static List<DatasCurtain> CurtainStatusList = new List<DatasCurtain>();
        /// <summary>
        /// 所有空调状态列表
        /// </summary>
        public static List<DatasAir> AirStatusList = new List<DatasAir>();

        public static DatasLamp datasLamp = new DatasLamp();
        public static DatasCurtain datasCurtain = new DatasCurtain();
        public static DatasAir datasAir = new DatasAir();
       

        public static int KnxType = 1;
        public static BaseDeviceInfo knxSetMessage = new BaseDeviceInfo();
        public static ModuleInfo knxModuleMess = new ModuleInfo();

        public static DatasLamp LampStatus = new DatasLamp();
        public static DatasCurtain CurtainStatus = new DatasCurtain();
        public static DatasAir AirStatus = new DatasAir();



        /// <summary>
        /// 功能设备基本信息
        /// </summary>
        public class BasicDeviceInfo
        {
            public string DeviceGuid;   // 设备唯一GUID
            public string DeviceName;   // 设备名称
            public int DeviceType;      // 当前设备类型
            public EnumProtocolStyle ProtocolStyle;    // 设备协议类型

            public string TagGuid;   // 标签信息
            public int DeviceControlClicks;   // 开关次数
            public EnumDeviceStatusMark DeviceStatusMark;  // 故障标识或正常标识
            public EnumCommonControl DeviceEnable;  // 是否可控
            public int DeviceHoursLife;   // 灯光寿命时长
            public float DevicePowerValue; // 灯光的功率
            public string DeviceMoreMessage;  // 更多备注
            public string ModuleGuid;   // 所属模块GUID
            public byte Bus_SubnetID;   // 子网号
            public byte Bus_DeviceID;   // 设备号
            public byte Bus_Channel;    // 回路号，通道号

            public string ZoneGuid;    // 所属区域GUID
            public byte[] KNX_DataType;    // KNX数据类型
            public byte[] KNX_GroupAddress;   // KNX组地址
            public byte[] KNX_FeedbackAddress;   // KNX反馈地址

        }

        /// <summary>
        /// 模块信息表
        /// </summary>
        public class Moduleinfo
        {
            public string ModuleGuid;  // 模块GUID
            public string ModuleName;   // 模块备注信息
            public int ModuleType;     // 模块类型
            public EnumProtocolStyle ProtocolStyle;  // 设备协议类型
            public string TagGuid;   // 标签信息
            public string ModuleMac;   // MAC信息
            public string PhysicalAddress;   // KNX物理地址
            public string ModuleIPaddress;   // 所属IP地址
            public byte ModuleSubnet;    // 子网号
            public byte ModuleDeviceNumber;   // 设备号
            public byte ModuleChannelsCount;  // 模块回路数
            public EnumDeviceStatusMark ModuleStatsMark;   // 故障标识或正常标识
            public EnumDeviceConnectWay ModuleConnectWay;   // 连接方式，本地或远程
            public EnumDeviceBelonging ModuleBelong;   // 模块所属项目，本身或其它工程
            public string HomeRoomGuid;    // 所属住宅ID
            public string ModuleTypeChineseName;   // 模块类型中文名称
            public string ModuleTypeEnglishName;   // 模块类型英文名称
            public string PowerBoxGuid;    // 所属配电箱GUID
            public string ModuleMoreMessage;  // 更多备注

        }

       

        /// <summary>
        /// 获取所有设备和模块信息
        /// </summary>
        public static void LoadAllInfo_Redis()
        {
            
            baseDeviceInfos = RedisController.Load_All_BasicDeviceInfo_Redis(); //获取所有设备基本信息
            
            moduleInfos = RedisController.Load_All_ModuleInfo_Redis();  // 获取所有模块信息
        }
        
        /// <summary>
        /// 获取所有设备的状态
        /// </summary>
        public static void GetDeviceDatas_Redis()
        {
            string devGuid = " ";
            byte brightness;
            string StrStatus; 
            datasLamp = RedisController.Get_Datas_Lamp_Redis(devGuid);   // 获取缓存的灯光状态

            datasCurtain = RedisController.Get_Datas_Curtain_Redis(devGuid); //获取缓存的窗帘状态

            datasAir = RedisController.Get_Datas_Air_Redis(devGuid);  //获取缓存的空调状态
            brightness = datasLamp.LampBrightness;
            if(LampStatusEnum.Off == datasLamp.LampStatus)
            {
                StrStatus = "01 00 80";               
            }
            if(LampStatusEnum.On == datasLamp.LampStatus)
            {
                StrStatus = "01 00 81";
            }


        }

        /// <summary>
        /// 上报所有设备状态
        /// </summary>
        public static void Device_Status_Report()
        {
            RedisController.KNX_Device_Status_Report_Lamp(LampStatus); //上报灯光状态

            RedisController.KNX_Device_Status_Report_Curtain(CurtainStatus); //上报窗帘状态

            RedisController.KNX_Device_Status_Report_Air(AirStatus);   // 上报空调状态

        }

    
        



        /// <summary>
        /// 接收控制灯光信息
        /// </summary>
        /// <param name="devGuid"></param>
        /// <param name="actionType"></param>
        /// <param name="brightness"></param>
        /// <returns></returns>
        public static string ControlLamp(string devGuid, ActionEnumLamp actionType, byte brightness)
        {
            string DevGuid = devGuid;
            string dstAddress = "";
            string actionLamp = "";
            string Brightness = "";
            string ActionLamp;
            BaseDeviceInfo knxDevbuff = new BaseDeviceInfo();
            
            //ActionEnumLamp actionLamp = actionType;
            //int a = Convert.ToInt32(actionLamp.GetType());
            for (int i = 0; i < baseDeviceInfos.Count; i++)
            {
                if (devGuid == baseDeviceInfos[i].DeviceGuid)
                {
                    knxDevbuff = baseDeviceInfos[i];
                }
            }
            
            //dstAddress = frmMyKNX.ExchangeDesaddr(knxDevbuff.KNX_GroupAddress[0], knxDevbuff.KNX_GroupAddress[1]);

            dstAddress = knxDevbuff.KNX_GroupAddress[0].ToString("X2") + " " + knxDevbuff.KNX_GroupAddress[1].ToString("X2");
            if (actionType == ActionEnumLamp.TurnOff)  //关灯
            {
                actionLamp = "01 00 80";
            }
            else if (actionType == ActionEnumLamp.TurnOn)   //开灯
            {
                actionLamp = "01 00 81";
            }
            else if (actionType == ActionEnumLamp.Dimmer)   //调光模式
            {
                actionLamp = "01 00 81";
                Brightness = brightness.ToString("X2");
            }
            ActionLamp = dstAddress + " " + actionLamp;
            return ActionLamp;

        }

        /// <summary>
        /// 接收控制窗帘信息
        /// </summary>
        /// <param name="devGuid"></param>
        /// <param name="actionType"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static string ControlCurtain(string devGuid, ActionEnumCurtain actionType, byte percent)
        {
            string actionCurtain = " ";
            string dstAddress = "";
            BaseDeviceInfo knxDevbuff1 = new BaseDeviceInfo();
            string Actioncurtain;
            string Percent;
            for (int i = 0; i < baseDeviceInfos.Count; i++)
            {
                if (devGuid == baseDeviceInfos[i].DeviceGuid)
                {
                    knxDevbuff1 = baseDeviceInfos[i];
                }
            }          
            dstAddress = knxDevbuff1.KNX_GroupAddress[0].ToString("X2") + " " + knxDevbuff1.KNX_GroupAddress[1].ToString("X2");

            if (actionType == ActionEnumCurtain.Close)   //关窗帘
            {
                actionCurtain = "01 00 80";
            }
            else if(actionType == ActionEnumCurtain.Open)  //开窗帘
            {
                actionCurtain = "01 00 81";
            }
            else if (actionType == ActionEnumCurtain.Stop)  //停止
            {
                actionCurtain = "01 00 80";
            }
            else if(actionType == ActionEnumCurtain.Percent)   //开到百分比
            {
                Percent = percent.ToString("X2");      //有待改进
            }
           
            Actioncurtain = dstAddress + " " + actionCurtain;
            return Actioncurtain;

        }

        /// <summary>
        /// 接收控制空调信息
        /// </summary>
        /// <param name="devGuid"></param>
        /// <param name="actionType"></param>
        /// <param name="tempValue"></param>
        /// <returns></returns>
        public static string ControlAir(string devGuid, ActionEnumAir actionType, byte tempValue)
        {
            BaseDeviceInfo knxDevbuff2 = new BaseDeviceInfo();
            string dstAddress = "";
            string strMessage = null;
            string Mess;
            for (int i = 0; i < baseDeviceInfos.Count; i++)
            {
                if (devGuid == baseDeviceInfos[i].DeviceGuid)
                {
                    knxDevbuff2 = baseDeviceInfos[i];
                }
            }
            
            dstAddress = knxDevbuff2.KNX_GroupAddress[0].ToString("X2") + " " + knxDevbuff2.KNX_GroupAddress[1].ToString("X2");

            if ( actionType == ActionEnumAir.TurnOff) //关空调
            {
                strMessage = " ";
            }
            else if(actionType == ActionEnumAir.TurnOn)  //开空调
            {
                strMessage = " ";
            }
            else if (actionType == ActionEnumAir.SetMode_Cold) //制冷
            {
                strMessage = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 01 01 00 81";
            }
            else if (actionType == ActionEnumAir.SetMode_Hot)  //制热
            {
                strMessage = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 02 01 00 81";
            }
            else if (actionType == ActionEnumAir.SetMode_Fan)  //通风
            {
                strMessage = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 04 01 00 81";
            }
            else if (actionType == ActionEnumAir.SetMode_Auto)  //自动模式
            {
                strMessage = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 05 01 00 81";
            }
            else if (actionType == ActionEnumAir.SetMode_Dry)   //除湿模式
            {
                strMessage = " ";
            }
            else if (actionType == ActionEnumAir.SetSpeed_Auto)  //自动送风
            {
                strMessage = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 06 01 00 81";
            }
            else if (actionType == ActionEnumAir.SetSpeed_High)  //高风
            {
                strMessage = "06 10 05 30 00 12 29 00 BC D0 11 09 1C 01 02 00 80 FF";
            }
            else if (actionType == ActionEnumAir.SetSpeed_Middle)  //中风
            {
                strMessage = "06 10 05 30 00 12 29 00 BC D0 11 09 1C 01 02 00 80 AA";
            }
            else if (actionType == ActionEnumAir.SetSpeed_Low)   //低风
            {
                strMessage = "06 10 05 30 00 12 29 00 BC D0 11 09 1C 01 02 00 80 55";
            }
            else if (actionType == ActionEnumAir.CustomTemperature)   //自定义温度
            {
                strMessage = "";
            }
            else if(actionType == ActionEnumAir.WindClose)  //扫风关，摆风关
            {

            }
            else if (actionType == ActionEnumAir.WindOpen)  //扫风开，摆风开
            {

            }
            //Mess = strMessage;
            return strMessage;
        }

        /// <summary>
        /// 收到远程控制处理，解析后上报
        /// </summary>
        /// <param name="gateRoomGuid"></param>
        /// <param name="remoteDatas"></param>
        /// <returns></returns>
        public static int RemoteDatas(string gateRoomGuid, byte[] remoteDatas)
        {
            return 1;
        }



        /// <summary>
        /// 读取灯光状态
        /// </summary>
        /// <param name="devGuid"></param>
        /// <returns></returns>
        public static DatasLamp ReadStatus_Lamp(string devGuid)
        {                
            if(LampStatusList != null)
            {
                
                foreach(var item in LampStatusList)
                {
                    if(item.DeviceGuid == devGuid)
                    {
                        return item;
                    }
                }

            }                   
            return null;
            //return dataslamp;
        }

        /// <summary>
        /// 读取窗帘状态
        /// </summary>
        /// <param name="devGuid"></param>
        /// <returns></returns>
        public static DatasCurtain ReadStatus_Curtain(string devGuid)
        {
            if(CurtainStatusList != null)
            {
                foreach (var item in CurtainStatusList)
                {
                    if (item.DeviceGuid == devGuid)
                    {
                        return item;
                    }
                }
            }
            return null;

            //return datascurtain;
        }

        /// <summary>
        /// 读取空调状态
        /// </summary>
        /// <param name="devGuid"></param>
        /// <returns></returns>
        public static DatasAir ReadStatus_Air(string devGuid)
        {
            if (AirStatusList != null)
            {
                foreach (var item in AirStatusList)
                {
                    if (item.DeviceGuid == devGuid)
                    {
                        return item;
                    }
                }
            }
            return null;

            //return datasair;
        }

        /// <summary>
        /// 服务端数据有改变，通知驱动重新获取设备信息
        /// </summary>
        public static void Load_All_Datas_From_AboveServer()
        {
            baseDeviceInfos = RedisController.Load_All_BasicDeviceInfo_Redis(); //获取所有设备基本信息

            moduleInfos = RedisController.Load_All_ModuleInfo_Redis();  // 获取所有模块信息
            
            //Load_All_BasicDeviceInfo_Redis(1);
            //Load_All_ModuleInfo_Redis(1);
        }
    }
}
