using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{
    /// <summary>
    /// 温度类型
    /// </summary>
    public enum TemperatureTypeEnum
    {
        /// <summary>
        ///℃摄氏度,°F=°C×1.8 + 32
        /// </summary>
        Celsius = 0,
        /// <summary>
        ///℉华氏度,°C=(°F-32)÷1.8
        /// </summary>
        Fahrenheit = 1

    }
}
