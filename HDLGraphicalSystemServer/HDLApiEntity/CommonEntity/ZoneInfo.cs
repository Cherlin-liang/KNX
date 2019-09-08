using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{

    /// <summary>
    /// 区域信息对象
    /// </summary>
    public class ZoneInfo
    {
        /// <summary>
        /// 区域唯一GUID
        /// </summary>
        public string ZoneGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string ZoneName
        {
            get;
            set;
        }

        /// <summary>
        /// 区域级别信息，0.*.* 其中，0是顶级结构，第一个*是顶级结构下的结构，第二个*是顶级结构下的结构下的结构
        /// </summary>
        public string ZoneLevel
        {
            get;
            set;
        }

        /// <summary>
        /// 父级GUID
        /// </summary>
        public string ParentZoneGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 同级区域排序号
        /// </summary>
        public int SeqNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 区域是否可见,0可见，1隐藏不见
        /// </summary>
        public int ZoneVisible
        {
            get;
            set;
        }

        /// <summary>
        /// 区域创建时间
        /// </summary>
        public DateTime ZoneCreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 区域更多备注
        /// </summary>
        public string ZoneMoreMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 区域来源,0本地区域，1远程区域
        /// </summary>
        public int ZoneSource
        {
            get;
            set;
        }

        /// <summary>
        /// 布局方式,0=自动布局，1=自由布局
        /// </summary>
        public int ZoneLayout
        {
            get;
            set;
        }

        /// <summary>
        /// 背景颜色(varchar50),ZoneBackColor
        /// </summary>
        public string ZoneBackColor
        {
            get;
            set;
        }


        /// <summary>
        /// 背景图片(text), ZoneBmgIconUrl
        /// </summary>
        public string ZoneBmgIconUrl
        {
            get;
            set;
        }
    }
}
