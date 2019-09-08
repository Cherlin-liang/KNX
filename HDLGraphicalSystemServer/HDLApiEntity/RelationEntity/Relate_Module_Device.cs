using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.RelationEntity
{
    /// <summary>
    /// 模块与设备关系信息对象
    /// </summary>
    public class Relate_Module_Device
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string GuidKey
        {
            get;
            set;
        }


        /// <summary>
        /// 模块GUID
        /// </summary>
        public string ModuleGuid
        {
            get;
            set;
        }


        /// <summary>
        /// 设备Guid
        /// </summary>
        public string DeviceGuid
        {
            get;
            set;
        }
    }
}
