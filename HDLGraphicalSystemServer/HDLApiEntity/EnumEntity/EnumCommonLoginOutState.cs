using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.EnumEntity
{

    /// <summary>
    /// 用户登录状态的枚举
    /// </summary>
    public enum EnumCommonLoginOutState
    {
        /// <summary>
        /// 登录成功
        /// </summary>
        Login = 0,
        /// <summary>
        /// 注销退出
        /// </summary>
        Logout = 1,
        /// <summary>
        /// 异常退出
        /// </summary>
        UnusualLogout = 2
    }
}
