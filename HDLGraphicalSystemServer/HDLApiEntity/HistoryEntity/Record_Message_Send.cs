using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.HistoryEntity
{

    /// <summary>
    /// 消息推送的历史记录对象
    /// </summary>
    public class Record_Message_Send : BasicHistoryInfo
    {
        /// <summary>
        /// 消息的GUID
        /// </summary>
        public string MessageGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 消息名称
        /// </summary>
        public string MessageName
        {
            get;
            set;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string MessageType
        {
            get;
            set;
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string MessageContent
        {
            get;
            set;
        }

        /// <summary>
        /// 消息推送的目标
        /// </summary>
        public string MessageAccepter
        {
            get;
            set;
        }
    }
}
