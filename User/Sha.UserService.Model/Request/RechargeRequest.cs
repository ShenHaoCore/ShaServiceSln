namespace Sha.UserService.Model.Request
{
    /// <summary>
    /// 充值请求
    /// </summary>
    public class AppRechargeRequest
    {
        /// <summary>
        /// (必填)金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// (必填)支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </summary>
        public int PayPlatform { get; set; }
    }


    /// <summary>
    /// 充值请求
    /// </summary>
    public class PageRechargeRequest
    {
        /// <summary>
        /// 充值请求
        /// </summary>
        public PageRechargeRequest()
        {
            this.Method = string.Empty;
        }

        /// <summary>
        /// (必填)金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// (必填)支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </summary>
        public int PayPlatform { get; set; }

        /// <summary>
        /// (可选)请求方式，默认POST，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成FORM表单</sample>
        /// </summary>
        public string Method { get; set; } = "POST";
    }
}
