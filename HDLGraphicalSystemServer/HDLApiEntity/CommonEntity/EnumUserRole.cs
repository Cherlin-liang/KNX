using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public enum EnumUserRole
    {
        /// <summary>
        /// 普通用户
        /// </summary>
        Guest = 0,
        /// <summary>
        /// 临时管理员
        /// </summary>
        Tempadmin = 1,
        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdmin = 2
    }
}
