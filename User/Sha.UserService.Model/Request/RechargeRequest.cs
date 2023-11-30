namespace Sha.UserService.Model.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class RechargeRequest
    {
        /// <summary>
        /// (必填)金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// (必填)支付方式 
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联支付[UnionPay]</sample>
        /// </summary>
        public int Payment { get; set; }

        /// <summary>
        /// (可选)请求方式，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成FORM表单</sample>
        /// </summary>
        public string Method { get; set; } = "POST";
    }
}
