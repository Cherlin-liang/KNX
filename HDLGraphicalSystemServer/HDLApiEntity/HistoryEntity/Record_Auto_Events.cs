using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.HistoryEntity
{
    /// <summary>
    /// 自动化事件执行的历史记录对象
    /// </summary>
    public class Record_Auto_Events:BasicHistoryInfo
    {

        /// <summary>
        /// 自动化事件的Guid
        /// </summary>
        public string AutoEventGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 自动化事件名称
        /// </summary>
        public string AutoEventName
        {
            get;
            set;
        }

        /// <summary>
        /// 自动化事件类型
        /// </summary>
        public string AutoEventType
        {
            get;
            set;
        }

        /// <summary>
        /// 自动化事件执行的动作
        /// </summary>
        public string AutoEventAction
        {
            get;
            set;
        }

        /// <summary>
        /// 自动化事件内容
        /// </summary>
        public string AutoEventContent
        {
            get;
            set;
        }

        /// <summary>
        /// 自动化事件发生的区域
        /// </summary>
        public string EventZoneName
        {
            get;
            set;
        }

    }
}
