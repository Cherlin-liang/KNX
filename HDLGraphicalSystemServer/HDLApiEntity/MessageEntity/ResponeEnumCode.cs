using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.MessageEntity
{

    /// <summary>
    /// API响应的信息码
    /// </summary>
    public enum ResponeEnumCode
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        Unknown = int.MinValue,
        /// <summary>
        /// 成功
        /// </summary>
        Success,       
        /// <summary>
        /// 令牌无效
        /// </summary>
        TokenInvalid,
        /// <summary>
        /// 令牌过期
        /// </summary>
        TokenExpired,
        /// <summary>
        /// Json格式错误
        /// </summary>
        JsonFormatError,
        /// <summary>
        /// 数据格式错误
        /// </summary>
        FormatError,
        /// <summary>
        /// URL请求地址无效
        /// </summary>
        URLInvalid,        
        /// <summary>
        /// 用户名不存在
        /// </summary>
        UserNameIsNull,
        /// <summary>
        /// 密码错误
        /// </summary>
        PasswordError,        
        /// <summary>
        /// 数据库操作异常
        /// </summary>
        MySQLException,
        /// <summary>
        /// GUID不存在异常
        /// </summary>
        GuidNotExist,
        /// <summary>
        /// 请求的参数值空异常
        /// </summary>
        ParametersNull,
        /// <summary>
        /// 请求的参数值错误
        /// </summary>
        ParametersError,
        /// <summary>
        /// 缺少请求参数
        /// </summary>
        ParametersLoss,
        /// <summary>
        /// 请求的参数不存在
        /// </summary>
        ParametersNotExist,
        /// <summary>
        /// 名称已经存在
        /// </summary>
        NameAlreadyExist,
        /// <summary>
        /// 名称已经存在
        /// </summary>
        NameNotExist,
        /// <summary>
        /// 无效的Base64字符串
        /// </summary>
        Base64Invalid,
        /// <summary>
        /// 拒绝请求处理
        /// </summary>
        RefuseRequest,
        /// <summary>
        /// 没有找到符合的数据
        /// </summary>
        NoFindConformData


    }
}
