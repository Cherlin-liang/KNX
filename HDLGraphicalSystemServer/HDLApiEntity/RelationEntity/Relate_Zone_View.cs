using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.RelationEntity
{

    /// <summary>
    /// 区域与组件的关系
    /// </summary>
    public class Relate_Zone_View
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
        /// 区域Guid
        /// </summary>
        public string ZoneGuid
        {
            get;
            set;
        }


        /// <summary>
        /// 组件GUID
        /// </summary>
        public string ViewGuid
        {
            get;
            set;
        }
    }
}
