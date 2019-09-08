using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.DevicesEntity
{
    /// <summary>
    /// 是否允许远程控制的枚举
    /// </summary>
    public enum EnumDeviceRemoteCtrl
    {
        /// <summary>
        /// 允许远程
        /// </summary>
        Allow = 0,
        /// <summary>
        /// 禁止远程
        /// </summary>
        Forbid = 1
    }
}
