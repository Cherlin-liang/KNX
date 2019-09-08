using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.ViewEntity
{
    /// <summary>
    /// 收藏页面的信息对象
    /// </summary>
    public class FavoriteViewInfo
    {
        /// <summary>
        /// 主键GUID
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

    }
}
