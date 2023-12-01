using SqlSugar;

namespace Sha.UserService.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class t_Cus_RechargeTrade
    {
        /// <summary>
        /// 
        /// </summary>
        public t_Cus_RechargeTrade()
        {
            this.TradeNo = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public System.Int32 ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.String TradeNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.Int32 Payment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CreateTime { get; set; }
    }
}
