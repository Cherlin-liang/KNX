using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{

    /// <summary>
    /// 设备通信协议类型
    /// </summary>
    public enum EnumProtocolStyle
    {       
        /// <summary>
        /// BUS协议
        /// </summary>
        BUS = 0,
        /// <summary>
        /// KNX协议
        /// </summary>
        KNX = 1,
        /// <summary>
        /// Zigbee协议
        /// </summary>
        Zigbee = 2
    }
}
