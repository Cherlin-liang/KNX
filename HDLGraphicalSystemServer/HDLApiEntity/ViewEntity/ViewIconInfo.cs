using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.ViewEntity
{
    /// <summary>
    /// 组件图标信息对象
    /// </summary>
    public class ViewIconInfo
    {
        /// <summary>
        /// 图标Guid
        /// </summary>
        public string IconGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 图标名称
        /// </summary>
        public string IconName
        {
            get;
            set;
        }

        /// <summary>
        /// 图标类型
        /// </summary>
        public EnumIconType IconType
        {
            get;
            set;
        }

        /// <summary>
        /// 图标字体
        /// </summary>
        public string IconFont
        {
            get;
            set;
        }

        /// <summary>
        /// 图标路径
        /// </summary>
        public string IconURL
        {
            get;
            set;
        }

        /// <summary>
        /// 图片内容,Basic64string
        /// </summary>
        public string IconDataContent
        {
            get;
            set;
        }

        /// <summary>
        /// 更多备注
        /// </summary>
        public string IconMoreMessage
        {
            get;
            set;
        }
    }
}
