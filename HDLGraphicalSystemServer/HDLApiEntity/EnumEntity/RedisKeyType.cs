using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{

    /// <summary>
    /// Redis数据的Key类型
    /// </summary>
    public enum RedisKeyType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown,
        /// <summary>
        /// 所有设备基本信息
        /// </summary>
        AllBasicDeviceInfo,
        /// <summary>
        /// 所有模块信息
        /// </summary>
        AllModuleInfoList,
        /// <summary>
        /// 所有模块与设备关系信息
        /// </summary>
        AllRelateModuleDeviceList,
        /// <summary>
        /// 所有灯光状态数据
        /// </summary>
        DatasLampList,
        /// <summary>
        /// 所有窗帘状态数据
        /// </summary>
        DatasCurtainList,
        /// <summary>
        /// 所有空调状态数据
        /// </summary>
        DatasAirList,
        /// <summary>
        /// 所有风扇、排风机的状态数据
        /// </summary>
        DatasFanList
    }
}
