using SqlSugar;

namespace Sha.UserService.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class t_AccountCath
    {
        /// <summary>
        /// 
        /// </summary>
        public t_AccountCath()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Decimal Balance { get; set; }
    }
}
