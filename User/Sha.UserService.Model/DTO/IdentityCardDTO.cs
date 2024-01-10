using Sha.Framework.Base;

namespace Sha.UserService.Model.DTO
{
    /// <summary>
    /// 身份证创建
    /// </summary>
    public class IdcardCreate
    {
        /// <summary>
        /// 
        /// </summary>
        public IdcardCreate()
        {
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Number = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Nation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDate { get; set; }
    }

    /// <summary>
    /// 身份证分页查询
    /// </summary>
    public class IdcardPageQuery : PageParam
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 性别
        /// <sample>1：男</sample>
        /// <sample>0：女</sample>
        /// </summary>
        public int? Sex { get; set; }
    }
}
