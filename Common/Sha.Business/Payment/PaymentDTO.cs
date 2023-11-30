namespace Sha.Business.Payment
{
    /// <summary>
    /// 支付交易参数
    /// </summary>
    public class PaymentTradeParam
    {
        /// <summary>
        /// 支付交易参数
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">描述信息</param>
        /// <param name="amount">金额</param>
        /// <param name="tradeno">交易单号</param>
        /// <param name="method">
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成FORM表单</sample>
        /// (可选)请求方式，仅支持支付宝
        /// </param>
        public PaymentTradeParam(string subject, string body, decimal amount, string tradeno, string method)
        {
            this.Subject = subject;
            this.Body = body;
            this.Amount = amount;
            this.TradeNo = tradeno;
            this.Method = method;
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
        /// (可选)请求方式，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成FORM表单</sample>
        /// </summary>
        public string Method { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PaymentTradeModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Body"></param>
        public PaymentTradeModel(string Body)
        {
            this.Body = Body;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Body { get; set; } = string.Empty;
    }
}
