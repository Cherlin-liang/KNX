using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.DevicesEntity
{
    /// <summary>
    /// KNX驱动的功能设备信息
    /// </summary>
    public class Basic_Knx_DeviceInfo
    {
        /// <summary>
        /// 设备唯一GUID
        /// </summary>
        public string DeviceGuid
        {
            get;
            set;
        }

        /// <summary>
		/// 当前设备类型
		/// </summary>
		public int DeviceType
        {
            get;
            set;
        }

        /// <summary>
        /// KNX数据类型
        /// </summary>
        public byte[] KNX_DataType
        {
            get;
            set;
        }

        /// <summary>
        /// KNX组地址
        /// </summary>
        public byte[] KNX_GroupAddress
        {
            get;
            set;
        }

        /// <summary>
        /// KNX反馈地址
        /// </summary>
        public byte[] KNX_FeedbackAddress
        {
            get;
            set;
        }

        /// <summary>
        /// 所属模块GUID
        /// </summary>
        public string ModuleGuid
        {
            get;
            set;
        }
    }
}
