namespace Sha.Framework.Base
{
    /// <summary>
    /// 分页参数
    /// </summary>
    public class BasePage
    {
        /// <summary>
        /// 分页参数
        /// </summary>
        public BasePage()
        {
            this.PageIndex = 1;
            this.PageSize = 10;
        }

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
