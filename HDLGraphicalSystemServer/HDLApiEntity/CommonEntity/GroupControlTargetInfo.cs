using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.CommonEntity
{

    /// <summary>
    /// 群控目标的信息对象
    /// </summary>
    public class GroupControlTargetInfo
    {
        /// <summary>
        /// 群控目标GUID
        /// </summary>
        public string MultipleCtrlTargetGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 群控目标名称
        /// </summary>
        public string MultipleCtrlTargetName
        {
            get;
            set;
        }

        /// <summary>
        /// 群控目标类型，目标设备类型
        /// </summary>
        public DeviceTypeEnum MultipleCtrlTargetType
        {
            get;
            set;
        }

        /// <summary>
        /// 群控目标绑定的设备GUID
        /// </summary>
        public string DeviceGuid
        {
            get;
            set;
        }


        /// <summary>
        /// 延迟执行时间
        /// </summary>
        public int DelayTime
        {
            get;
            set;
        }

        /// <summary>
        /// 所属群控GUID
        /// </summary>
        public string MultipleCtrlGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string MultipleCtrlTargetMoreMessage
        {
            get;
            set;
        }
    }
}
