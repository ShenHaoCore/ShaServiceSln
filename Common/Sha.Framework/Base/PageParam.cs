using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 分页查询
    /// </summary>
    public class QueryPage
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        public QueryPage()
        {
            this.PageIndex = 1;
            this.PageSize = 10;
        }

        /// <summary>
        /// 页数
        /// </summary>
        [DefaultValue(1)]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页行数
        /// </summary>
        [DefaultValue(10)]
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        [JsonIgnore]
        public int TotalNumber { get; set; }
    }
}
