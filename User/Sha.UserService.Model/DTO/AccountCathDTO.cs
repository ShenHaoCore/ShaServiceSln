using FluentValidation;
using Sha.Business.Enum;

namespace Sha.UserService.Model.DTO
{
    /// <summary>
    /// 充值交易参数
    /// </summary>
    public class RechargeTradeParam
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="payment">
        /// 支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </param>
        public RechargeTradeParam(decimal amount, int payment)
        {
            this.Amount = amount;
            this.Payment = payment;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="amount">金额</param>
        /// <param name="payment">
        /// 支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </param>
        /// <param name="isGet">是否生成GET请求URL</param>
        public RechargeTradeParam(decimal amount, int payment, bool isGet)
        {
            this.Amount = amount;
            this.Payment = payment;
            this.IsGet = isGet;
        }

        /// <summary>
        /// 支付平台
        /// <sample>1：支付宝[Alipay]</sample>
        /// <sample>2：微信[WeChat]</sample>
        /// <sample>3：银联[UnionPay]</sample>
        /// </summary>
        public int Payment { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 是否生成GET请求URL
        /// </summary>
        public bool IsGet { get; set; }
    }

    /// <summary>
    /// 充值交易验证
    /// </summary>
    public class RechargeTradeValidator : AbstractValidator<RechargeTradeParam>
    {
        /// <summary>
        /// 充值交易验证
        /// </summary>
        public RechargeTradeValidator()
        {
            RuleFor(it => it.Amount).GreaterThan(0).WithName("金额");
            RuleFor(it => it.Payment).Must(IsPayment).WithMessage("支付平台错误");
        }

        /// <summary>
        /// 是否支付平台
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        private bool IsPayment(int payment)
        {
            return Enum.IsDefined(typeof(BusinessEnum.Payment), payment);
        }
    }

    /// <summary>
    /// 充值实体
    /// </summary>
    public class RechargeTradeModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Body"></param>
        public RechargeTradeModel(string Body)
        {
            this.Body = Body;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Body { get; set; } = string.Empty;
    }
}
