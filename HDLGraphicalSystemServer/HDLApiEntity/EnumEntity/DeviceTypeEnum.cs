using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{

    /// <summary>
    /// 设备类型
    /// </summary>
    public enum DeviceTypeEnum
    {
        /// <summary>
        /// 不清楚
        /// </summary>
        UnKown = int.MaxValue,
        /// <summary>
        /// 电视
        /// </summary>
        TV = 0x0001,
        /// <summary>
        /// 场景
        /// </summary>
        Scene = 0x0002,
        /// <summary>
        /// 序列
        /// </summary>
        Series = 0x0003,
        /// <summary>
        /// 通用开关
        /// </summary>
        CommonSwitch = 0x0004,
        /// <summary>
        /// 摄像机
        /// </summary>
        Monitor = 0x0005,
        /// <summary>
        /// 窗帘模块
        /// </summary>
        CurtainModel = 0x0202,
        /// <summary>
        /// 开合帘电机
        /// </summary>
        CurtainTrietex = 0x0200,
        /// <summary>
        /// 卷帘
        /// </summary>
        CurtainRoller = 0x0201,
        /// <summary>
        /// 调光灯
        /// </summary>
        LightDimming = 0x0100,
        /// <summary>
        /// 开关灯
        /// </summary>
        LightSwitch = 0x0101,
        /// <summary>
        /// 逻辑灯控制
        /// </summary>
        LightCCT = 0x0102,
        /// <summary>
        /// 逻辑灯RGB
        /// </summary>
        LightRGB = 0x0103,
        /// <summary>
        /// 逻辑灯RBGW
        /// </summary>
        LightRGBW = 0x0104,
        /// <summary>
        /// 逻辑灯RGB+CCT
        /// </summary>
        LightRGBandCCT = 0x0105,
        /// <summary>
        /// 
        /// </summary>
        LightDALI = 0x0107,
        /// <summary>
        /// 自定义逻辑灯
        /// </summary>
        LightLogic = 0x0108,
        /// <summary>
        /// 插座开关
        /// </summary>
        LightSwitchSocket = 0x0188,//自定义特殊的继电器，作插座使用        
        /// <summary>
        /// RCU记录的混合调光回路
        /// </summary>
        LightDimmerRCU = 0x0109,
        /// <summary>
        /// RCU记录的混合开关回路
        /// </summary>
        LightSwitchRCU = 0x010A,

        /// <summary>
        /// The AC device.
        /// </summary>
        ACDevice = 0x07FF,
        /// <summary>
        /// AC模块
        /// </summary>
        HVAC = 0x0700,
        /// <summary>
        /// 通用空调面板
        /// </summary>
        ACPanel = 0x0703,
        /// <summary>
        /// 红外空调
        /// </summary>
        ACInfrared = 0x0702,
        /// <summary>
        /// The AC coolmaster控制模块
        /// </summary>
        ACCoolmaster = 0x0701,
        /// <summary>
        /// 地热
        /// </summary>
        FoolHeat = 0x0800,
        /// <summary>
        /// 常规地热面板
        /// </summary>
        FoolHeatPanel = 0x0801,


        /// <summary>
        /// 无线网关	
        /// </summary>
        OnePortWirelessFR = 0xFE01,
        /// <summary>
        /// 一端口交换机
        /// </summary>
        OnePortBus = 0xFE00,
        /// <summary>
        /// 普通网络设备
        /// </summary>
        OneCommonNetPort = 0xFE03,
        /// <summary>
        /// 酒店RCU
        /// </summary>
        OneHotelRCU = 0xFE04,

        /// <summary>
        /// 按键面板
        /// </summary>
        ButtonPanel = 0x0401,

        /// <summary>
        /// 干接点
        /// </summary>
        DryContact = 0x0400,

        /// <summary>
        /// 音乐模块
        /// </summary>
        MusicModel = 0x0900,
        /// <summary>
        /// 音乐控制面板
        /// </summary>
        MusicPanel = 0x0902,

        InfraredMode = 0x0300,
        /// <summary>
        /// 第三方背景音乐模块
        /// </summary>
        A31MusicModel = 0x0901,

        InfraredTV = 0x0305,
        InfraredSTB = 0x0303,
        InfraredProjetor = 0x0301,

        /// <summary>
        /// 安防模块
        /// </summary>
        SecurityModule = 0x0A00,
        /// <summary>
        /// 安防面板
        /// </summary>
        SecurityPanel = 0x0A02,

        /// <summary>
        /// BUS风扇模块16-00
        /// </summary>
        FanModule = 0x1600,
        /// <summary>
        /// RCU风扇模块,协议文档里定义的是16-01，胡工返回的是4097(0x1001)
        /// </summary>
        FanRCUmodel = 0x1001,

        /// <summary>
        /// 逻辑控制模块
        /// </summary>
        LogicModule = 0x0C00,        
        /// <summary>
        /// 单相电表模块
        /// </summary>
        PowerMeterSingle = 0x1300       
    }
}
