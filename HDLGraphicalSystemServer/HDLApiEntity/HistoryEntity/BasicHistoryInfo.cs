using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.HistoryEntity
{

    /// <summary>
    /// 历史记录基本信息
    /// </summary>
    public abstract class BasicHistoryInfo
    {
        /// <summary>
        /// 数据库表自动增加ID
        /// </summary>
        public ulong TableID
        {
            get;
            set;
        }

        /// <summary>
        /// 发生的时间
        /// </summary>
        public DateTime HappenDatetime
        {
            get;
            set;
        }

        /// <summary>
        /// 更多信息
        /// </summary>
        public string RecordMoreMessage
        {
            get;
            set;
        }
    }
}
