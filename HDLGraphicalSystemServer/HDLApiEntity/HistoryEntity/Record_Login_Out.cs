using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.HistoryEntity
{

    /// <summary>
    /// 服务端，用户的登录历史记录对象
    /// </summary>
    public class Record_Login_Out:BasicHistoryInfo
    {
        /// <summary>
        /// 登录类型（服务器、用户）
        /// </summary>
        public string LoginType
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
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 登录状态（正常退出，异常退出、上线）
        /// </summary>
        public string LoginStatusValue
        {
            get;
            set;
        }

        /// <summary>
        /// 在线时长
        /// </summary>
        public int OnlineTime
        {
            get;
            set;
        }
    }
}
