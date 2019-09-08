using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.XmlEntity
{
    /// <summary>
    /// 模块类型信息对象
    /// </summary>
    public class ModuleTypeInfo
    {
        /// <summary>
        /// 区域是否可见,0可见，1隐藏不见
        /// </summary>
        public int ModuleTypeInt
        {
            get;
            set;
        }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string ChineseName
        {
            get;
            set;
        }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnglishName
        {
            get;
            set;
        }
    }
}
