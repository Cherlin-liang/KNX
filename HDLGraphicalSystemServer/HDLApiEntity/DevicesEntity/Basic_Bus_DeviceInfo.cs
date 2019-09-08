using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.DevicesEntity
{
    /// <summary>
    /// BUS驱动的功能设备信息
    /// </summary>
    public class Basic_Bus_DeviceInfo
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
        /// 子网号
        /// </summary>
        public byte Bus_SubnetID
        {
            get;
            set;
        }

        /// <summary>
        /// 设备号
        /// </summary>
        public byte Bus_DeviceID
        {
            get;
            set;
        }

        /// <summary>
        /// 回路号，通道号
        /// </summary>
        public byte Bus_Channel
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
