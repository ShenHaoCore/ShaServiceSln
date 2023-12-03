using SqlSugar;

namespace Sha.UserService.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class t_RechargeTrade
    {
        /// <summary>
        /// 
        /// </summary>
        public t_RechargeTrade()
        {
            this.TradeNo = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tradeno"></param>
        /// <param name="amount"></param>
        /// <param name="currency"></param>
        /// <param name="payment"></param>
        public t_RechargeTrade(string tradeno, decimal amount, int currency, int payment)
        {
            this.TradeNo = tradeno;
            this.Amount = amount;
            this.Currency = currency;
            this.Payment = payment;
            this.CreateTime = DateTime.Now;
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
        public System.Int32 Currency { get; set; }

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
