using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{
    /// <summary>
    /// 灯光的控制动作类型
    /// </summary>
    public enum ActionEnumLamp
    {
        /// <summary>
        /// 打开
        /// </summary>
        TurnOn = 100,
        /// <summary>
        /// 关闭
        /// </summary>
        TurnOff = 0,
        /// <summary>
        /// 调光设置
        /// </summary>
        Dimmer = 109
    }
}
