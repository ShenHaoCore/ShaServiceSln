using SqlSugar;

namespace Sha.UserService.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class t_IdentityCard
    {
        /// <summary>
        /// 
        /// </summary>
        public t_IdentityCard()
        {
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Number = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public System.String Name { get; set; }

        /// <summary>
        /// 性别 1：男 0：女
        /// </summary>
        public System.Int32 Sex { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public System.Int32 Nation { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public System.DateTime Birthday { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public System.String Address { get; set; }

        /// <summary>
        /// 公民身份号码
        /// </summary>
        public System.String Number { get; set; }

        /// <summary>
        /// 有效期起始日期
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// 有效期截止日期
        /// </summary>
        public System.DateTime EndDate { get; set; }
    }
}
