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
        [SugarColumn(IsPrimaryKey = true)]
        public System.Int32 ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String Name { get; set; }
    }
}
