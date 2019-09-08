using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLGraphicalSystemServer
{
    public enum Dimmer
    {
        dimmer = 0x00, //调光回路
        SwitchCircuit = 0x01, //开关回路
        LogicCCT = 0x02, //逻辑灯控制CCT
        LogicRGB = 0x03, //逻辑灯控制RGB       
        LogicRGBW = 0x04, //逻辑灯控制
        LogicRGBCCT = 0x05, //逻辑灯RGB+CCT
        DALI = 0x07, 
        Customize = 0x08, //自定义逻辑灯
        Mixdimmer = 0x09, //混合调光类
        MixSwicth = 0x0A, //混合开光类
        ElectricRelay = 0x0B //电量可读继电器
        
    }
    public enum Curtain
    {
        OpenCloseMoto = 0x00, //开合帘电机
        RollingMoto = 0x01, //卷帘电机
        CurtainModule = 0x02 //窗帘模块
    }
    public enum AirCondition
    {
        HVACModule = 0x00, //HVAC模块
        Coolmaster = 0x01,//Coolmaster控制模块
        InfraredModule = 0x02, //红外空调模块
        UnifiedOutlet = 0x03   //通用空调面板
    }
}
