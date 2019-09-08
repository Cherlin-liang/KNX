using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.DeviceStatusDataEntity
{

    /// <summary>
    /// 空调数据的状态对象
    /// </summary>
    public class DatasAir : BaseDataInfo
    {
        /// <summary>
        /// 空调状态
        /// </summary>
        public EnumCommonOnOff OnOff;

        /// <summary>
        /// 温度类型
        /// </summary>
        public TemperatureTypeEnum TempStyle;

        /// <summary>
        /// 当前温度
        /// </summary>
        public int ActualTemp;

        /// <summary>
        /// 制冷的温度点
        /// </summary>
        public int ColdTemp;

        /// <summary>
        /// 制热的温度点
        /// </summary>
        public int HotTemp;

        /// <summary>
        /// 自动模式的温度点
        /// </summary>
        public int AutoTemp;

        /// <summary>
        /// 除湿模式的温度点
        /// </summary>
        public int DryTemp;

        /// <summary>
        /// 控制模式和风速的值，需要分解高低位得到对应的模式与风速
        /// </summary>
        public int ControlMode;

        /// <summary>
        /// 设置模式
        /// </summary>
        public AirModeEnum SetupMode;

        /// <summary>
        /// 设置风速
        /// </summary>
        public AirSpeedEnum SetupSpeed;

        /// <summary>
        /// 实际运行的模式和风速的值，需要分解高低位得到对应的模式与风速
        /// </summary>
        public int RunMode;

        /// <summary>
        /// 是否扫风，摆风
        /// </summary>
        public EnumCommonOnOff WindSweep;
    }
}
