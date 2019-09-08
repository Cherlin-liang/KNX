using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{

    /// <summary>
    /// 窗帘控制的动作类型
    /// </summary>
    public enum ActionEnumCurtain
    {
        /// <summary>
        /// 打开
        /// </summary>
        Open = 1,
        /// <summary>
        /// 关闭
        /// </summary>
        Close = 2,
        /// <summary>
        /// 停止
        /// </summary>
        Stop = 0,
        /// <summary>
        /// 百分比控制
        /// </summary>
        Percent = 3
    }
}
