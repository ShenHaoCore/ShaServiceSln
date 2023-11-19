namespace Sha.BaseService.Model.Request
{
    /// <summary>
    /// 地址新增请求
    /// </summary>
    public class AddressCreateRequest
    {
        /// <summary>
        /// 地址新增请求
        /// </summary>
        public AddressCreateRequest()
        {
            this.NameCn = string.Empty;
        }

        /// <summary>
        /// 中文名
        /// </summary>
        public string NameCn { get; set; }
    }
}
