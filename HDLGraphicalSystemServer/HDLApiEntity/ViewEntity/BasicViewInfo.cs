using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.ViewEntity
{
    /// <summary>
    /// 组件基本信息对象
    /// </summary>
    public class BasicViewInfo
    {
        /// <summary>
        /// 组件GUID
        /// </summary>
        public string ViewGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 组件名称
        /// </summary>
        public string ViewName
        {
            get;
            set;
        }

        /// <summary>
        /// 组件类型
        /// </summary>
        public EnumViewType ViewType
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
        /// 组件状态
        /// </summary>
        public EnumViewState ViewState
        {
            get;
            set;
        }

        /// <summary>
        /// 是否绑定设备
        /// </summary>
        public EnumViewBind ViewBind
        {
            get;
            set;
        }

        /// <summary>
        /// 绑定设备GUID，灯光、窗帘、空调、场景、群控等的GUID
        /// </summary>
        public string DeviceGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 组件CSS内容
        /// </summary>
        public byte[] ViewCSSContent
        {
            get;
            set;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string ViewMoreMessage
        {
            get;
            set;
        }
    }
}
