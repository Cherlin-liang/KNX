using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.ViewEntity
{

    /// <summary>
    /// 组件类型枚举
    /// </summary>
    public enum EnumViewType
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown,
        /// <summary>
        /// 空调
        /// </summary>
        AirView,
        /// <summary>
        /// 灯光
        /// </summary>
        LampView,
        /// <summary>
        /// 窗帘
        /// </summary>
        CurtainView,
        /// <summary>
        /// 排风机
        /// </summary>
        FanView,
        /// <summary>
        /// 场景
        /// </summary>
        SceneView,
        /// <summary>
        /// 地暖
        /// </summary>
        GeothermyView,
        /// <summary>
        /// 群控组件
        /// </summary>
        GroupControlView
    }
}
