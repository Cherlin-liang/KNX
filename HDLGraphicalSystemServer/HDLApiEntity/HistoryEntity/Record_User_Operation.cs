using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.ViewEntity;

namespace HDLApiEntity.HistoryEntity
{

    /// <summary>
    /// 用户操作的历史记录对象
    /// </summary>
    public class Record_User_Operation : BasicHistoryInfo
    {
        /// <summary>
        /// 用户GUID
        /// </summary>
        public string UserGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 操作用户名称
        /// </summary>
        public string UserName
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
        /// 控制组件名称
        /// </summary>
        public string ViewName
        {
            get;
            set;
        }

        /// <summary>
        /// 控制的组件类型名称
        /// </summary>
        public string ViewType
        {
            get;
            set;
        }

        /// <summary>
        /// 控制的动作类型
        /// </summary>
        public string ActionType
        {
            get;
            set;
        }

        /// <summary>
        /// 控制的设置值
        /// </summary>
        public string CtrlValue
        {
            get;
            set;
        }

    }
}
