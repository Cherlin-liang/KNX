using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.RelationEntity
{
    /// <summary>
    /// 区域与电表的关系
    /// </summary>
    public class Relate_Zone_PowerMeter
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
        /// 电表GUID
        /// </summary>
        public string PowerMeterGuid
        {
            get;
            set;
        }
    }
}
