using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.HistoryEntity
{

    /// <summary>
    /// 设备报警的历史记录对象
    /// </summary>
    public class Record_Device_Alarm : BasicHistoryInfo
    {
        /// <summary>
        /// 报警设备GUID
        /// </summary>
        public string DeviceGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 报警设备名称
        /// </summary>
        public string DeviceName
        {
            get;
            set;
        }

        /// <summary>
        /// 报警设备类型的名称
        /// </summary>
        public string DeviceType
        {
            get;
            set;
        }

        /// <summary>
        /// 报警状态（离线，电压超标)
        /// </summary>
        public string AlarmAction
        {
            get;
            set;
        }

        /// <summary>
        /// 报警值
        /// </summary>
        public string AlarmStatusValue
        {
            get;
            set;
        }

        /// <summary>
        /// 报警区域信息
        /// </summary>
        public string AlarmZoneName
        {
            get;
            set;
        }

        /// <summary>
        /// 报警区域GUID
        /// </summary>
        public string ZoneGuid
        {
            get;
            set;
        }
    }
}
