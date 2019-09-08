using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.RelationEntity
{

    /// <summary>
    /// 区域与背景图关系对象
    /// </summary>
    public class Relate_Zone_BgImg
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
        /// 背景图GUID
        /// </summary>
        public string BgImgGuid
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
    }
}
