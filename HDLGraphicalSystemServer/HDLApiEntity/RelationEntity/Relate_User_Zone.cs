using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.CommonEntity;

namespace HDLApiEntity.RelationEntity
{
    /// <summary>
    /// 用户与区域关系
    /// </summary>
    public class Relate_User_Zone
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
        /// 用户GUID
        /// </summary>
        public string UserGuid
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
        /// 用户的区域权限级别，级别1可控可见，级别2可见
        /// </summary>
        public EnumUserPower UserPower
        {
            get;
            set;
        }

    }
}
