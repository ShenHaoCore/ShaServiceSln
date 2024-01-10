namespace Sha.UserService.Model.Request
{
    /// <summary>
    /// 身份证新增请求
    /// </summary>
    public class IdcardCreateRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public IdcardCreateRequest()
        {
            this.Name = string.Empty;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public int Nation { get; set; }
    }
}
