namespace Sha.Business.Payment
{
    /// <summary>
    /// 支付交易
    /// </summary>
    public class PaymentTrade
    {
        /// <summary>
        /// 支付交易参数
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">描述信息</param>
        /// <param name="amount">金额</param>
        /// <param name="tradeNo">交易单号</param>
        public PaymentTrade(string subject, string body, decimal amount, string tradeNo)
        {
            this.Subject = subject;
            this.Body = body;
            this.Amount = amount;
            this.TradeNo = tradeNo;
            this.IsGet = false;
        }

        /// <summary>
        /// 支付交易参数
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">描述信息</param>
        /// <param name="amount">金额</param>
        /// <param name="tradeNo">交易单号</param>
        /// <param name="isGet">是否生成GET请求URL</param>
        public PaymentTrade(string subject, string body, decimal amount, string tradeNo, bool isGet)
        {
            this.Subject = subject;
            this.Body = body;
            this.Amount = amount;
            this.TradeNo = tradeNo;
            this.IsGet = isGet;
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 交易单号
        /// </summary>
        public string TradeNo { get; set; }

        /// <summary>
        /// 是否生成GET请求URL
        /// </summary>
        public bool IsGet { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PaymentTradeOrder
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="body"></param>
        public PaymentTradeOrder(string body)
        {
            this.Body = body;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Body { get; set; } = string.Empty;
    }
}
