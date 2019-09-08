using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;
using HDLApiEntity.ViewEntity;

namespace HDLApiEntity.RelationEntity
{

    /// <summary>
    /// 用户与组件关系
    /// </summary>
    public class Relate_User_View
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
        /// 组件GUID
        /// </summary>
        public string ViewGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 是否可控
        /// </summary>
        public EnumCommonControl EnableControl
        {
            get;
            set;
        }

        /// <summary>
        /// 是否可见
        /// </summary>
        public EnumCommonVisable EnableSee
        {
            get;
            set;
        }
    }
}
