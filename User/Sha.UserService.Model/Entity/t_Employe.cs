using SqlSugar;

namespace Sha.UserService.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class t_Employee
    {
        /// <summary>
        /// 
        /// </summary>
        public t_Employee()
        {
            this.Number = string.Empty;
            this.Password = string.Empty;
            this.Name = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 ID { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public System.String Number { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public System.String Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public System.String Name { get; set; }
    }
}
