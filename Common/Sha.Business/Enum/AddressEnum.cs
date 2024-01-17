using System.ComponentModel;

namespace Sha.Business.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressEnum
    {
        /// <summary>
        /// 类型
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// 国家
            /// </summary>
            [Description("国家")]
            Country = 1,

            /// <summary>
            /// 省
            /// </summary>
            [Description("省")]
            Province = 2,

            /// <summary>
            /// 直辖市
            /// </summary>
            [Description("直辖市")]
            Munici = 3,

            /// <summary>
            /// 特别行政区
            /// </summary>
            [Description("特别行政区")]
            Special = 4,

            /// <summary>
            /// 市
            /// </summary>
            [Description("市")]
            City = 5,

            /// <summary>
            /// 区
            /// </summary>
            [Description("区")]
            District = 6,
        }
    }
}
