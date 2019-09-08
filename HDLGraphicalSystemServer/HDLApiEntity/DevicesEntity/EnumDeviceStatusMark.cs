using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.DevicesEntity
{
    /// <summary>
    /// 设备故障或正常状态标识枚举
    /// </summary>
    public enum EnumDeviceStatusMark
    {        
        /// <summary>
        /// 在线
        /// </summary>
        OnLine = 0,
        /// <summary>
        /// 离线
        /// </summary>
        OffLine = 1,
        /// <summary>
        /// 已损坏
        /// </summary>
        Damaged = 2
    }
}
