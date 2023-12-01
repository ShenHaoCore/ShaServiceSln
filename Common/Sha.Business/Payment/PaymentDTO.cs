namespace Sha.Business.Payment
{
    /// <summary>
    /// 支付交易
    /// </summary>
    public class PaymentTrade
    {
        /// <summary>
        /// 支付交易
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="amount"></param>
        /// <param name="tradeno"></param>
        public PaymentTrade(string subject, string body, decimal amount, string tradeno)
        {
            this.Subject = subject;
            this.Body = body;
            this.Amount = amount;
            this.TradeNo = tradeno;
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
    }

    /// <summary>
    /// APP支付交易参数
    /// </summary>
    public class AppPaymentTradeParam : PaymentTrade
    {
        /// <summary>
        /// APP支付交易参数
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="amount"></param>
        /// <param name="tradeno"></param>
        public AppPaymentTradeParam(string subject, string body, decimal amount, string tradeno) : base(subject, body, amount, tradeno)
        {
            this.Subject = subject;
            this.Body = body;
            this.Amount = amount;
            this.TradeNo = tradeno;
        }
    }

    /// <summary>
    /// 支付交易参数
    /// </summary>
    public class PagePaymentTradeParam : PaymentTrade
    {
        /// <summary>
        /// 支付交易参数
        /// </summary>
        /// <param name="subject">标题</param>
        /// <param name="body">描述信息</param>
        /// <param name="amount">金额</param>
        /// <param name="tradeno">交易单号</param>
        /// <param name="method">
        /// (可选)请求方式，默认POST，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成FORM表单</sample>
        /// </param>
        public PagePaymentTradeParam(string subject, string body, decimal amount, string tradeno, string method) : base(subject, body, amount, tradeno)
        {
            this.Subject = subject;
            this.Body = body;
            this.Amount = amount;
            this.TradeNo = tradeno;
            this.Method = method;
        }

        /// <summary>
        /// (可选)请求方式，默认POST，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成FORM表单</sample>
        /// </summary>
        public string Method { get; set; }
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

    /// <summary>
    /// 
    /// </summary>
    public class AppPaymentTradeOrder : PaymentTradeOrder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        public AppPaymentTradeOrder(string body) : base(body)
        {
            this.Body = body;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PagePaymentTradeOrder : PaymentTradeOrder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        public PagePaymentTradeOrder(string body) : base(body)
        {
            this.Body = body;
        }
    }
}
