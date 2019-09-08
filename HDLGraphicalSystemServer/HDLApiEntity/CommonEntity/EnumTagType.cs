using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 标签类型枚举
    /// </summary>
    public enum EnumTagType
    {
        /// <summary>
        /// 功能设备标签
        /// </summary>
        Device = 1,
        /// <summary>
        /// 场景标签
        /// </summary>
        Scene = 2,
        /// <summary>
        /// 群控标签
        /// </summary>
        MultiControl = 3,
        /// <summary>
        /// 自动化标签
        /// </summary>
        Automation = 4,
        /// <summary>
        /// 用户标签
        /// </summary>
        User = 5,
        /// <summary>
        /// 组件标签
        /// </summary>
        View = 6,
        /// <summary>
        /// 配电箱标签
        /// </summary>
        PowerBox = 7
    }
}
