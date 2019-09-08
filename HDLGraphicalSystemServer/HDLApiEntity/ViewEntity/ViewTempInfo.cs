using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.ViewEntity
{

    /// <summary>
    /// 组件模板信息对象
    /// </summary>
    public class ViewTempInfo
    {
        /// <summary>
        /// 组件模板GUID
        /// </summary>
        public string ViewTempGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 组件模板名称
        /// </summary>
        public string ViewTempName
        {
            get;
            set;
        }


        /// <summary>
        /// 组件模板类型
        /// </summary>
        public EnumViewTempType ViewTempType
        {
            get;
            set;
        }
       

        /// <summary>
        /// 是否默认模板，0默认，1自定义
        /// </summary>
        public int ViewTempDefault
        {
            get;
            set;
        }

        /// <summary>
        /// 组件模板CSS内容
        /// </summary>
        public byte[] ViewTempContent
        {
            get;
            set;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string ViewTempMoreMessage
        {
            get;
            set;
        }
    }
}
