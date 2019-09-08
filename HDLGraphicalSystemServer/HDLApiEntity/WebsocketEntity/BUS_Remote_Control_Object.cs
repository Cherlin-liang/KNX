using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.WebsocketEntity
{
    /// <summary>
    /// BUS远程控制数据对象
    /// </summary>
    public class BUS_Remote_Control_Object
    {


        /// <summary>
        /// 账号信息
        /// </summary>
        public string HDLAccount
        {
            get;
            set;
        }

        /// <summary>
        /// 住宅ID
        /// </summary>
        public string HomeRoomGuid
        {
            get;
            set;
        }

        /// <summary>
        /// MQTT控制数据
        /// </summary>
        public byte[] MqttDatas
        {
            get;
            set;
        }

    }
}
