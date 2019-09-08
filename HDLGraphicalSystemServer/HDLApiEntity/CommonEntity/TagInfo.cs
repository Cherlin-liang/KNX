using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 标签信息对象
    /// </summary>
    public class TagInfo
    {
        /// <summary>
        /// 标签GUID
        /// </summary>
        public string TagGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName
        {
            get;
            set;
        }

        /// <summary>
        /// 标签类型
        /// </summary>
        public EnumTagType TagType
        {
            get;
            set;
        }


        /// <summary>
        /// 标签颜色
        /// </summary>
        public string TagColor
        {
            get;
            set;
        }

        /// <summary>
        /// 标签更多备注
        /// </summary>
        public string TagMoreMessage
        {
            get;
            set;
        }
       
    }
}
