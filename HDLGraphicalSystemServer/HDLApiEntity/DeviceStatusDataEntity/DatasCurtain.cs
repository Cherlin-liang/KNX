using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.DeviceStatusDataEntity
{

    /// <summary>
    /// 窗帘数据的状态对象
    /// </summary>
    public class DatasCurtain : BaseDataInfo
    {
        /// <summary>
        /// 窗帘状态
        /// </summary>
        public CurtainStatusEnum CurtainStatus;

        /// <summary>
        /// 窗帘的百分比值
        /// </summary>
        public byte CutainPercentage;
    }
}
