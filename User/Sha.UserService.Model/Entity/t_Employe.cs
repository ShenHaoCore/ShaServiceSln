using SqlSugar;

namespace Sha.UserService.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class t_Employe
    {
        /// <summary>
        /// 
        /// </summary>
        public t_Employe()
        {
            this.Number = string.Empty;
            this.Password = string.Empty;
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
    }
}
