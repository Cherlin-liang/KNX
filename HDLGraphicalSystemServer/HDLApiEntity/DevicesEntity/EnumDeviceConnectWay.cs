using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.DevicesEntity
{
    /// <summary>
    /// 设备连接方式，本地或远程的枚举
    /// </summary>
    public enum EnumDeviceConnectWay
    {
        /// <summary>
        /// 本地
        /// </summary>
        Local = 0,
        /// <summary>
        /// 仅远程
        /// </summary>
        Remote = 1
    }
}
