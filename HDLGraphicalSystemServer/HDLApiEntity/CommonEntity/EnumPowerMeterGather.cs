using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{

    /// <summary>
    /// 电表数据采集状态的枚举
    /// </summary>
    public enum EnumPowerMeterGather
    {
        /// <summary>
        /// 采集数据
        /// </summary>
        Gather = 0,
        /// <summary>
        /// 不采集数据
        /// </summary>
        NotGather = 1
    }
}
