using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{
    /// <summary>
    /// 驱动层操作的主题类型
    /// </summary>
    public enum RedisThemeType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// BUS,灯光，设备状态上报
        /// </summary>
        Bus_Device_Report_Lamp,
        /// <summary>
        /// BUS窗帘，设备状态上报
        /// </summary>
        Bus_Device_Report_Curtain,
        /// <summary>
        /// BUS空调，设备状态上报
        /// </summary>
        Bus_Device_Report_Air,
        /// <summary>
        /// BUS风扇，风机，设备状态上报
        /// </summary>
        Bus_Device_Report_Fan,
        /// <summary>
        /// BUS远程设备控制
        /// </summary>
        Bus_Remote_Control,
        /// <summary>
        /// KNX,灯光，设备状态上报
        /// </summary>
        KNX_Device_Report_Lamp,
        /// <summary>
        /// BUS窗帘，设备状态上报
        /// </summary>
        KNX_Device_Report_Curtain,
        /// <summary>
        /// BUS空调，设备状态上报
        /// </summary>
        KNX_Device_Report_Air,
        /// <summary>
        /// BUS风扇，风机，设备状态上报
        /// </summary>
        KNX_Device_Report_Fan,
        /// <summary>
        /// KNX远程设备控制
        /// </summary>
        KNX_Remote_Control
    }
}
