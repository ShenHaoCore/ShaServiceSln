using SqlSugar;

namespace Sha.UserService.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class t_Customer
    {
        /// <summary>
        /// 
        /// </summary>
        public t_Customer()
        {
            this.LoginName = string.Empty;
            this.Password = string.Empty;
            this.Name = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsIdentity = true)]
        public System.Int32 ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String LoginName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CreateTime { get; set; }
    }
}
