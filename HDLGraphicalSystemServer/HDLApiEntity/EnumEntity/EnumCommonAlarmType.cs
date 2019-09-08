using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{

    /// <summary>
    /// 报警数据类型的枚举
    /// </summary>
    public enum EnumCommonAlarmType
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown =-1,
        /// <summary>
        /// 电流报警
        /// </summary>
        Current =1,
        /// <summary>
        /// 电压报警
        /// </summary>
        Voltage =2

    }
}
