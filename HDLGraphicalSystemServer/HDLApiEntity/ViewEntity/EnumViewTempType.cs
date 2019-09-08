using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.ViewEntity
{

    /// <summary>
    /// 组件模板类型的枚举
    /// </summary>
    public enum EnumViewTempType
    {        
        /// <summary>
        /// 通用模板
        /// </summary>
        CommonTemp =1,
        /// <summary>
        /// 空调模板
        /// </summary>
        AirTemp =2,
        /// <summary>
        /// 灯光模板
        /// </summary>
        LampTemp =3,
        /// <summary>
        /// 窗帘模板
        /// </summary>
        CurtainTemp =4,
        /// <summary>
        /// 排风机模板
        /// </summary>
        FanTemp =5,
        /// <summary>
        /// 场景模板
        /// </summary>
        SceneTemp =6,
        /// <summary>
        /// 地暖模板
        /// </summary>
        GeothermyTemp =7,
        /// <summary>
        /// 群控模板
        /// </summary>
        GroupControlTemp =8
    }
}
