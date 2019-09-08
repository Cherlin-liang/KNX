using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{

    /// <summary>
    /// 目标动作类型的枚举
    /// </summary>
    public enum EnumTargetActionType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// 打开
        /// </summary>
        TurnOn = 0,
        /// <summary>
        /// 关闭
        /// </summary>
        TurnOff = 1,
        /// <summary>
        /// 调光设置
        /// </summary>
        Dimmer = 2,
        /// <summary>
        /// 打开
        /// </summary>
        Open =3,
        /// <summary>
        /// 关闭
        /// </summary>
        Close =4,
        /// <summary>
        /// 停止
        /// </summary>
        Stop =5,
        /// <summary>
        /// 百分比控制
        /// </summary>
        Percent =6,
        /// <summary>
        /// 自定义温度
        /// </summary>
        CustomTemperature =7,        
        /// <summary>
        /// 扫风关，摆风关
        /// </summary>
        WindClose =8,
        /// <summary>
        /// 扫风开，摆风开
        /// </summary>
        WindOpen =9,
        /// <summary>
        /// 制冷模式
        /// </summary>
        SetMode_Cold =10,
        /// <summary>
        /// 制热模式
        /// </summary>
        SetMode_Hot =11,
        /// <summary>
        /// 通风模式
        /// </summary>
        SetMode_Fan =12,
        /// <summary>
        /// 自动模式
        /// </summary>
        SetMode_Auto =13,
        /// <summary>
        /// 除湿模式
        /// </summary>
        SetMode_Dry =14,
        /// <summary>
        /// 自动风
        /// </summary>
        SetSpeed_Auto =15,
        /// <summary>
        /// 高风
        /// </summary>
        SetSpeed_High =16,
        /// <summary>
        /// 中风
        /// </summary>
        SetSpeed_Middle =17,
        /// <summary>
        /// 低风
        /// </summary>
        SetSpeed_Low =18
    }
}
