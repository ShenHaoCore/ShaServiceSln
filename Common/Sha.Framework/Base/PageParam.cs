namespace Sha.Framework.Base
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParam
    {
        /// <summary>
        /// 页数
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalNumber { get; set; }
    }
}
