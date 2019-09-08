using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{

    /// <summary>
    /// 空调控制的动作类型
    /// </summary>
    public enum ActionEnumAir
    {
        /// <summary>
        /// 自定义温度
        /// </summary>
        CustomTemperature = 16,
        /// <summary>
        /// 关闭
        /// </summary>
        TurnOff = 0,
        /// <summary>
        /// 打开
        /// </summary>
        TurnOn = 1,
        /// <summary>
        /// 扫风关，摆风关
        /// </summary>
        WindClose = 0,
        /// <summary>
        /// 扫风开，摆风开
        /// </summary>
        WindOpen = 1,
        /// <summary>
        /// 制冷模式
        /// </summary>
        SetMode_Cold = 0,
        /// <summary>
        /// 制热模式
        /// </summary>
        SetMode_Hot = 1,
        /// <summary>
        /// 通风模式
        /// </summary>
        SetMode_Fan = 2,
        /// <summary>
        /// 自动模式
        /// </summary>
        SetMode_Auto = 3,
        /// <summary>
        /// 除湿模式
        /// </summary>
        SetMode_Dry = 4,
        /// <summary>
        /// 自动风
        /// </summary>
        SetSpeed_Auto = 0,
        /// <summary>
        /// 高风
        /// </summary>
        SetSpeed_High = 1,
        /// <summary>
        /// 中风
        /// </summary>
        SetSpeed_Middle = 2,
        /// <summary>
        /// 低风
        /// </summary>
        SetSpeed_Low = 3

    }
}
