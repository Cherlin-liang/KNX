using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{
    /// <summary>
    /// 所有设备子类型的枚举管理
    /// </summary>
    class DeviceChildType
    {

    }

    /// <summary>
    /// 灯光子类型
    /// </summary>
    public enum LampTypeEunm
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown,
        /// <summary>
        /// 开关灯
        /// </summary>
        Lamp_Switch,
        /// <summary>
        /// 调光灯
        /// </summary>
        Lamp_Dimmer,
    }


    /// <summary>
    /// 窗帘子类型
    /// </summary>
    public enum CurtainTypeEunm
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown,
        /// <summary>
        /// 窗帘模块
        /// </summary>
        Curtain_Model,
        /// <summary>
        /// 开合帘
        /// </summary>
        Curtain_Trietex,
        /// <summary>
        /// 卷帘
        /// </summary>
        Curtain_Roller,
        /// <summary>
        /// 百叶窗
        /// </summary>
        Curtain_Shutter
    }

    /// <summary>
    /// 空调子类型
    /// </summary>
    public enum AirTypeEunm
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown,
        /// <summary>
        /// 空调模块
        /// </summary>
        HVAC,
        /// <summary>
        /// 空调面板
        /// </summary>
        PanelAC,
        /// <summary>
        /// 中央空调
        /// </summary>
        CenterAC,
    }
}
