using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.DevicesEntity;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.ApiShowEntity
{
    /// <summary>
    /// 前端要显示的模块设备信息对象
    /// </summary>
    public class UI_ModuleInfo
    {
        /// <summary>
        /// 模块GUID
        /// </summary>
        public string ModuleGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 模块备注信息
        /// </summary>
        public string ModuleName
        {
            get;
            set;
        }

        /// <summary>
		/// 模块类型
		/// </summary>
		public int ModuleType
        {
            get;
            set;
        }

        /// <summary>
        /// 设备协议类型
        /// </summary>
        public EnumProtocolStyle ProtocolStyle { get; set; }

        /// <summary>
        /// 标签信息
        /// </summary>
        public string TagGuid
        {
            get;
            set;
        }

        /// <summary>
        /// MAC信息
        /// </summary>
        public string ModuleMac
        {
            get;
            set;
        }

        /// <summary>
        /// KNX物理地址
        /// </summary>
        public string PhysicalAddress
        {
            get;
            set;
        }

        /// <summary>
        /// 所属IP地址
        /// </summary>
        public string ModuleIPaddress
        {
            get;
            set;
        }


        /// <summary>
        /// 子网号
        /// </summary>
        public byte ModuleSubnet
        {
            get;
            set;
        }

        /// <summary>
        /// 设备号
        /// </summary>
        public byte ModuleDeviceNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 模块回路数
        /// </summary>
        public byte ModuleChannelsCount
        {
            get;
            set;
        }

        /// <summary>
        /// 故障标识或正常标识
        /// </summary>
        public EnumDeviceStatusMark ModuleStatsMark
        {
            get;
            set;
        }

        /// <summary>
        /// 模块类型中文名称
        /// </summary>
        public string ModuleTypeChineseName
        {
            get;
            set;
        }

        /// <summary>
        /// 模块类型英文名称
        /// </summary>
        public string ModuleTypeEnglishName
        {
            get;
            set;
        }

        /// <summary>
        /// 所属配电箱名称
        /// </summary>
        public string PowerBoxName
        {
            get;
            set;
        }        

        /// <summary>
        /// 所属区域名称
        /// </summary>
        public string ZoneName
        {
            get;
            set;
        }

        /// <summary>
        /// 更多备注
        /// </summary>
        public string ModuleMoreMessage
        {
            get;
            set;
        }
    }
}
