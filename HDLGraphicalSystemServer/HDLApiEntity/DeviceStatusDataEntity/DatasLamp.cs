using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.DeviceStatusDataEntity
{

    /// <summary>
    /// 灯光数据的状态对象
    /// </summary>
    public class DatasLamp : BaseDataInfo
    {
        /// <summary>
        /// 灯光状态
        /// </summary>
        public LampStatusEnum LampStatus;

        /// <summary>
        /// 灯光亮度值
        /// </summary>
        public byte LampBrightness;
    }
}
