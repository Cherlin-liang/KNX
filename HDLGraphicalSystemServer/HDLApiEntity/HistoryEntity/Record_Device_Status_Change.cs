using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.HistoryEntity
{

    /// <summary>
    /// 设备状态变化历史记录对象
    /// </summary>
    public class Record_Device_Status_Change : BasicHistoryInfo
    {
        /// <summary>
        /// 设备GUID
        /// </summary>
        public string DeviceGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName
        {
            get;
            set;
        }

        /// <summary>
        /// 设备类型的名称
        /// </summary>
        public string DeviceType
        {
            get;
            set;
        }

        /// <summary>
        /// 设备变化状态的信息
        /// </summary>
        public string DeviceStatusValue
        {
            get;
            set;
        }
    }
}
