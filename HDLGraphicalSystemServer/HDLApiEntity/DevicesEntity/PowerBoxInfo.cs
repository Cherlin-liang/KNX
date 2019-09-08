using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.DevicesEntity
{
    /// <summary>
    /// 配电箱信息对象
    /// </summary>
    public class PowerBoxInfo
    {
        /// <summary>
        /// 配电箱GUID
        /// </summary>
        public string PowerBoxGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 配电箱名称
        /// </summary>
        public string PowerBoxName
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
		/// 配电箱详情
		/// </summary>
		public string PowerBoxDetail
        {
            get;
            set;
        }

        /// <summary>
		/// 配电箱所属区域GUID
		/// </summary>
		public string ZoneGuid
        {
            get;
            set;
        }

        /// <summary>
		/// 更多备注
		/// </summary>
		public string MoreMessage
        {
            get;
            set;
        }

    }
}
