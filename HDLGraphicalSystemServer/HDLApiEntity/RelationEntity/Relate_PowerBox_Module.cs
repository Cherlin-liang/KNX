using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.RelationEntity
{
    /// <summary>
    /// 配电箱与模块的关系对象
    /// </summary>
    public class Relate_PowerBox_Module
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string GuidKey
        {
            get;
            set;
        }


        /// <summary>
        /// 配电箱GUID
        /// </summary>
        public string PowerBoxGuid
        {
            get;
            set;
        }


        /// <summary>
        /// 模块Guid
        /// </summary>
        public string ModuleGuid
        {
            get;
            set;
        }
    }
}
