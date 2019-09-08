using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.CommonEntity
{

    /// <summary>
    /// 群控信息对象
    /// </summary>
    public class GroupControlInfo
    {
        /// <summary>
        /// 群控GUID
        /// </summary>
        public string MultipleCtrlGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 群控名称
        /// </summary>
        public string MultipleCtrlName
        {
            get;
            set;
        }

        /// <summary>
        /// 群控类型，群控的设备类型
        /// </summary>
        public DeviceTypeEnum MultipleCtrlType
        {
            get;
            set;
        }


        /// <summary>
        /// 群控状态，可用不可用
        /// </summary>
        public EnumCommonEnable MultipleCtrlState
        {
            get;
            set;
        }

        /// <summary>
        /// 群控动作
        /// </summary>
        public EnumTargetActionType MultipleCtrlAction
        {
            get;
            set;
        }

        /// <summary>
        /// 群控控制值
        /// </summary>
        public int MultipleCtrlValue
        {
            get;
            set;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string MultipleCtrlMoreMessage
        {
            get;
            set;
        }
    }
}
