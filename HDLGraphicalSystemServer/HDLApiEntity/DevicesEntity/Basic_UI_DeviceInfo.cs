﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.DevicesEntity
{
    /// <summary>
    /// UI显示的功能设备信息对象
    /// </summary>
    public class Basic_UI_DeviceInfo
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
        /// 设备名称
        /// </summary>
        public string DeviceName
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
        /// 设备协议类型
        /// </summary>
        public EnumProtocolStyle ProtocolStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 标签信息
        /// </summary>
        public string TagGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 开关次数
        /// </summary>
        public int DeviceControlClicks
        {
            get;
            set;
        }

        /// <summary>
        /// 故障标识或正常标识
        /// </summary>
        public EnumDeviceStatusMark DeviceStatusMark
        {
            get;
            set;
        }

        /// <summary>
        /// 是否可控
        /// </summary>
        public EnumCommonControl DeviceEnable
        {
            get;
            set;
        }

        /// <summary>
        /// 灯光寿命时长
        /// </summary>
        public int DeviceHoursLife
        {
            get;
            set;
        }

        /// <summary>
        /// 灯光的功率
        /// </summary>
        public float DevicePowerValue
        {
            get;
            set;
        }

        /// <summary>
        /// 更多备注
        /// </summary>
        public string DeviceMoreMessage
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

        /// <summary>
        /// 回路号，通道号
        /// </summary>
        public byte Bus_Channel
        {
            get;
            set;
        }

        /// <summary>
        /// 所属区域GUID
        /// </summary>
        public string ZoneGuid
        {
            get;
            set;
        }        
    }
}
