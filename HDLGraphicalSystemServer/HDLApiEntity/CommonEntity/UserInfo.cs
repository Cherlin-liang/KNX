using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 用户的基本信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户唯一GUID
        /// </summary>
        public string UserGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 登录密码,未加密的原始密码
        /// </summary>
        public string UserPassword
        {
            get;
            set;
        }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string UserRealName
        {
            get;
            set;
        }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string UserEmail
        {
            get;
            set;
        }


        /// <summary>
        /// 用户角色，0普通用户，1临时管理员
        /// </summary>
        public EnumUserRole UserRole
        {
            get;
            set;
        }

        /// <summary>
        /// 用户操作，0启用，禁用
        /// </summary>
        public EnumUserEnable UserEnable
        {
            get;
            set;
        }

        /// <summary>
        /// 权限级别
        /// </summary>
        public EnumUserPower UserPower
        {
            get;
            set;
        }

        /// <summary>
        /// 用户状态
        /// </summary>
        public EnumUserState UserState
        {
            get;
            set;
        }

        /// <summary>
        /// 标签GUID
        /// </summary>
        public string TagGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 用户头像路径,http绝对路径，完整的路径
        /// </summary>
        public string UserIconUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime UserCreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string MoreMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 一级权限的区域信息
        /// </summary>
        public string PowerLevelOne
        {
            get;
            set;
        }

        /// <summary>
        /// 二级权限的区域信息
        /// </summary>
        public string PowerLevelTwo
        {
            get;
            set;
        }

    }
}
