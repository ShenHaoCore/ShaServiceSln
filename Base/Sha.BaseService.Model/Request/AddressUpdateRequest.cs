namespace Sha.BaseService.Model.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressUpdateRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public AddressUpdateRequest()
        {
            this.NameCn = string.Empty;
        }

        /// <summary>
        /// 中文名
        /// </summary>
        public string NameCn { get; set; }
    }
}
