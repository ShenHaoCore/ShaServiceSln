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
        /// 状态代码
        /// </summary>
        public enum StatusCode
        {
            /// <summary>
            /// 服务器已成功处理了请求
            /// </summary>
            [Description("成功")]
            Success = 200,

            /// <summary>
            /// 失败
            /// </summary>
            [Description("失败")]
            Fail = 201,

            /// <summary>
            /// 服务器接收到的请求为空
            /// </summary>
            [Description("请求为空")]
            RequestNull = 202,

            /// <summary>
            /// 没有服务器的访问权限
            /// </summary>
            [Description("拒绝访问")]
            AccessDenied = 204,

            /// <summary>
            /// 未开通此服务
            /// </summary>
            [Description("无服务")]
            NoService = 205,

            /// <summary>
            /// 这里应该有数据，但是现在是空的
            /// </summary>
            [Description("无数据")]
            NoData = 206,

            /// <summary>
            /// 操作数据库失败
            /// </summary>
            [Description("保存失败")]
            SaveFailed = 207,

            /// <summary>
            /// 未授权
            /// </summary>
            [Description("未授权")]
            UnAuthorized = 401,

            /// <summary>
            /// 服务器遇到错误无法完成请求
            /// </summary>
            [Description("服务器内部错误")]
            SystemError = 500,

            /// <summary>
            /// 用户不存在
            /// </summary>
            [Description("用户不存在")]
            UserNotFount = 1000,

            /// <summary>
            /// 用户已存在
            /// </summary>
            [Description("用户已存在")]
            UserExists = 1001,
        }
    }
}
