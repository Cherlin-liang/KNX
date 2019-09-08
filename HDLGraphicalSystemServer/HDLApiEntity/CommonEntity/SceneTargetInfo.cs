using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 场景目标信息对象
    /// </summary>
    public class SceneTargetInfo
    {
        /// <summary>
        /// 场景目标GUID
        /// </summary>
        public string SceneTargetGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 场景目标名称
        /// </summary>
        public string SceneTargetName
        {
            get;
            set;
        }

        /// <summary>
        /// 场景目标类型，目标设备类型
        /// </summary>
        public DeviceTypeEnum SceneTargetType
        {
            get;
            set;
        }


        /// <summary>
        /// 场景目标动作
        /// </summary>
        public EnumTargetActionType SceneTargetAction
        {
            get;
            set;
        }

        /// <summary>
        /// 场景目标控制值
        /// </summary>
        public int SceneTargetCtrlValue
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
        /// 场景目标绑定的设备GUID
        /// </summary>
        public string DeviceGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 所属场景GUID
        /// </summary>
        public string SceneGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string SceneTargetMoreMessage
        {
            get;
            set;
        }

    }
}
