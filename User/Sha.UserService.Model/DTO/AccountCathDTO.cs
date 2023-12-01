namespace Sha.UserService.Model.DTO
{
    /// <summary>
    /// 充值交易参数
    /// </summary>
    public class AppRechargeTradeParam
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="payplatform">
        /// 支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </param>
        public AppRechargeTradeParam(decimal amount, int payplatform)
        {
            this.Amount = amount;
            this.PayPlatform = payplatform;
        }

        /// <summary>
        /// 支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </summary>
        public int PayPlatform { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
    }

    /// <summary>
    /// 充值实体
    /// </summary>
    public class AppRechargeTradeModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Body"></param>
        public AppRechargeTradeModel(string Body)
        {
            this.Body = Body;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Body { get; set; } = string.Empty;
    }

    /// <summary>
    /// 充值交易参数
    /// </summary>
    public class PageRechargeTradeParam
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="payplatform">
        /// 支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </param>
        /// <param name="method">
        /// (可选)请求方式，默认POST，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成URL链接</sample>
        /// </param>
        public PageRechargeTradeParam(decimal amount, int payplatform, string method)
        {
            this.Amount = amount;
            this.PayPlatform = payplatform;
            this.Method = method;
        }

        /// <summary>
        /// 支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </summary>
        public int PayPlatform { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// (可选)请求方式，默认POST，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成URL链接</sample>
        /// </summary>
        public string Method { get; set; }
    }

    /// <summary>
    /// 充值实体
    /// </summary>
    public class PageRechargeTradeModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Body"></param>
        public PageRechargeTradeModel(string Body)
        {
            this.Body = Body;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Body { get; set; } = string.Empty;
    }
}
