using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.MessageEntity
{
    public class ResponeMessage
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public string ReplyCode { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string ReplyMessage { get; set; }

        /// <summary>
        /// 响应的对象
        /// </summary>
        public object ReplyObject { get; set; }

        /// <summary>
        /// 查询结果的总行数
        /// </summary>
        public int TotalRowCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
    }
}
