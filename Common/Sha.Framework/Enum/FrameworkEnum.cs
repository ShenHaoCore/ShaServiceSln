using System.ComponentModel;

namespace Sha.Framework.Enum
{
    /// <summary>
    /// 框架枚举
    /// </summary>
    public class FrameworkEnum
    {
        /// <summary>
        /// 版本
        /// </summary>
        public enum ApiVersion
        {
            /// <summary>
            /// V1版本
            /// </summary>
            [Description("V1版本")]
            V1 = 1,

            /// <summary>
            /// V2版本
            /// </summary>
            [Description("V2版本")]
            V2 = 2,
        }

        /// <summary>
        /// 用户类型
        /// </summary>
        public enum UserType
        {
            /// <summary>
            /// 员工
            /// </summary>
            [Description("员工")]
            Employee = 0,

            /// <summary>
            /// 客户
            /// </summary>
            [Description("客户")]
            Customer = 1,
        }

        /// <summary>
        /// 状态代码
        /// </summary>
        public enum StatusCode
        {
            /// <summary>
            /// 未授权
            /// </summary>
            [Description("未授权")]
            UnAuthorized = 401,

            /// <summary>
            /// 权限不足
            /// </summary>
            [Description("权限不足")]
            Forbidden = 403,

            /// <summary>
            /// 服务器遇到错误无法完成请求
            /// </summary>
            [Description("服务器内部错误")]
            ServerError = 500,

            /// <summary>
            /// 服务器已成功处理了请求
            /// </summary>
            [Description("成功")]
            Success = 10000,

            /// <summary>
            /// 失败
            /// </summary>
            [Description("失败")]
            Fail = 10001,

            /// <summary>
            /// 服务器接收到的请求参数为空
            /// </summary>
            [Description("请求为空")]
            RequestNull = 10002,

            /// <summary>
            /// 数据验证失败
            /// </summary>
            [Description("验证失败")]
            ValidateFail = 10003,

            /// <summary>
            /// 错误的响应
            /// </summary>
            [Description("错误响应")]
            ResponseError = 10005,

            /// <summary>
            /// 未开通此服务
            /// </summary>
            [Description("无服务")]
            NoService = 10006,

            /// <summary>
            /// 这里应该有数据，但是现在是空的
            /// </summary>
            [Description("无数据")]
            NotFountData = 10007,

            /// <summary>
            /// 用户不存在
            /// </summary>
            [Description("用户不存在")]
            UserNotFount = 20000,
        }
    }
}
