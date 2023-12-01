using System.ComponentModel;

namespace Sha.Business.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public class BusinessEnum
    {
        /// <summary>
        /// 支付平台
        /// </summary>
        public enum PayPlatform
        {
            /// <summary>
            /// 支付宝
            /// </summary>
            [Description("支付宝")]
            Alipay = 1,

            /// <summary>
            /// 微信
            /// </summary>
            [Description("微信")]
            WeChat = 2,

            /// <summary>
            /// 银联
            /// </summary>
            [Description("银联")]
            UnionPay = 3,
        }

        /// <summary>
        /// 请求方式
        /// </summary>
        public enum RequestMethod
        {
            /// <summary>
            /// POST
            /// </summary>
            [Description("POST")]
            POST = 1,

            /// <summary>
            /// GET
            /// </summary>
            [Description("GET")]
            GET = 2,
        }
    }
}
