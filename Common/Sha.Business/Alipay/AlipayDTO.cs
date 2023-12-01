using Aop.Api.Response;

namespace Sha.Business.Alipay
{
    /// <summary>
    /// 交易参数
    /// </summary>
    public class TradeParam
    {
        /// <summary>
        /// 交易参数
        /// </summary>
        /// <param name="TotalAmount">订单总金额</param>
        /// <param name="Body">商品描述信息</param>
        /// <param name="Subject">订单标题</param>
        /// <param name="OutTradeNo">订单号</param>
        public TradeParam(string TotalAmount, string Body, string Subject, string OutTradeNo)
        {
            this.TotalAmount = TotalAmount;
            this.Body = Body;
            this.Subject = Subject;
            this.OutTradeNo = OutTradeNo;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TimeoutExpress { get; set; } = "90m";

        /// <summary>
        /// (必选)订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]，金额不能为0
        /// </summary>
        public string TotalAmount { get; set; } = string.Empty;

        /// <summary>
        /// (可选)销售产品码，商家和支付宝签约的产品码
        /// </summary>
        public string ProductCode { get; set; } = "FAST_INSTANT_TRADE_PAY";

        /// <summary>
        /// (可选)对一笔交易的具体描述信息。如果是多种商品，请将商品描述字符串累加传给body。
        /// </summary>
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// (必选)订单标题
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// (必选)商户网站唯一订单号
        /// </summary>
        public string OutTradeNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// APP交易参数
    /// </summary>
    public class TradeAppParam
    {
        /// <summary>
        /// APP交易参数
        /// </summary>
        /// <param name="TotalAmount">订单总金额</param>
        /// <param name="Body">商品描述信息</param>
        /// <param name="Subject">订单标题</param>
        /// <param name="OutTradeNo">订单号</param>
        public TradeAppParam(string TotalAmount, string Body, string Subject, string OutTradeNo)
        {
            this.TotalAmount = TotalAmount;
            this.Body = Body;
            this.Subject = Subject;
            this.OutTradeNo = OutTradeNo;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TimeoutExpress { get; set; } = "90m";

        /// <summary>
        /// (必选)订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]，金额不能为0
        /// </summary>
        public string TotalAmount { get; set; } = string.Empty;

        /// <summary>
        /// (可选)销售产品码，商家和支付宝签约的产品码
        /// </summary>
        public string ProductCode { get; set; } = "FAST_INSTANT_TRADE_PAY";

        /// <summary>
        /// (可选)对一笔交易的具体描述信息。如果是多种商品，请将商品描述字符串累加传给body。
        /// </summary>
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// (必选)订单标题
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// (必选)商户网站唯一订单号
        /// </summary>
        public string OutTradeNo { get; set; } = string.Empty;
    }

    /// <summary>
    /// 交易订单
    /// </summary>
    public class TradeOrder
    {
        /// <summary>
        /// 交易订单
        /// </summary>
        public TradeOrder(AlipayTradePayResponse response)
        {
            this.Code = response.Code;
            this.Msg = response.Msg;
            this.SubCode = response.SubCode;
            this.SubMsg = response.SubMsg;
            this.Body = response.Body;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubMsg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }
    }

    /// <summary>
    /// APP交易订单
    /// </summary>
    public class TradeAppOrder
    {
        /// <summary>
        /// APP交易订单
        /// </summary>
        public TradeAppOrder(AlipayTradeAppPayResponse response)
        {
            this.Code = response.Code;
            this.Msg = response.Msg;
            this.SubCode = response.SubCode;
            this.SubMsg = response.SubMsg;
            this.Body = response.Body;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubMsg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }
    }

    /// <summary>
    /// PAGE交易参数
    /// </summary>
    public class TradePageParam
    {
        /// <summary>
        /// PAGE交易参数
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="body"></param>
        /// <param name="subject"></param>
        /// <param name="outTradeNo"></param>
        /// <param name="requestMethod">请求方式</param>
        public TradePageParam(string totalAmount, string body, string subject, string outTradeNo, string requestMethod)
        {
            this.TotalAmount = totalAmount;
            this.Body = body;
            this.Subject = subject;
            this.OutTradeNo = outTradeNo;
            this.RequestMethod = requestMethod;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TimeoutExpress { get; set; } = "90m";

        /// <summary>
        /// (必选)订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]，金额不能为0
        /// </summary>
        public string TotalAmount { get; set; } = string.Empty;

        /// <summary>
        /// (可选)销售产品码，商家和支付宝签约的产品码
        /// </summary>
        public string ProductCode { get; set; } = "FAST_INSTANT_TRADE_PAY";

        /// <summary>
        /// (可选)对一笔交易的具体描述信息。如果是多种商品，请将商品描述字符串累加传给body。
        /// </summary>
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// (必选)订单标题
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// (必选)商户网站唯一订单号
        /// </summary>
        public string OutTradeNo { get; set; } = string.Empty;

        /// <summary>
        /// (可选)请求方式，默认POST，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成FORM表单</sample>
        /// </summary>
        public string RequestMethod { get; set; } = "POST";
    }

    /// <summary>
    /// PAGE交易订单
    /// </summary>
    public class TradePageOrder
    {
        /// <summary>
        /// PAGE交易订单
        /// </summary>
        /// <param name="response">响应</param>
        public TradePageOrder(AlipayTradePagePayResponse response)
        {
            this.Code = response.Code;
            this.Msg = response.Msg;
            this.SubCode = response.SubCode;
            this.SubMsg = response.SubMsg;
            this.Body = response.Body;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubMsg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }
    }

    /// <summary>
    /// WAP交易参数
    /// </summary>
    public class TradeWapParam
    {
        /// <summary>
        /// WAP交易参数
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <param name="body"></param>
        /// <param name="subject"></param>
        /// <param name="outTradeNo"></param>
        /// <param name="requestMethod">请求方式</param>
        public TradeWapParam(string totalAmount, string body, string subject, string outTradeNo, string requestMethod)
        {
            this.TotalAmount = totalAmount;
            this.Body = body;
            this.Subject = subject;
            this.OutTradeNo = outTradeNo;
            this.RequestMethod = requestMethod;
        }

        /// <summary>
        /// 
        /// </summary>
        public string TimeoutExpress { get; set; } = "90m";

        /// <summary>
        /// (必选)订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]，金额不能为0
        /// </summary>
        public string TotalAmount { get; set; } = string.Empty;

        /// <summary>
        /// (可选)销售产品码，商家和支付宝签约的产品码
        /// </summary>
        public string ProductCode { get; set; } = "FAST_INSTANT_TRADE_PAY";

        /// <summary>
        /// (可选)对一笔交易的具体描述信息。如果是多种商品，请将商品描述字符串累加传给body。
        /// </summary>
        public string Body { get; set; } = string.Empty;

        /// <summary>
        /// (必选)订单标题
        /// </summary>
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// (必选)商户网站唯一订单号
        /// </summary>
        public string OutTradeNo { get; set; } = string.Empty;

        /// <summary>
        /// (可选)请求方式，默认POST，仅支持支付宝
        /// <sample>GET：生成URL链接</sample>
        /// <sample>POST：生成FORM表单</sample>
        /// </summary>
        public string RequestMethod { get; set; } = "POST";
    }

    /// <summary>
    /// WAP交易订单
    /// </summary>
    public class TradeWapOrder
    {
        /// <summary>
        /// WAP交易订单
        /// </summary>
        /// <param name="response">响应</param>
        public TradeWapOrder(AlipayTradeWapPayResponse response)
        {
            this.Code = response.Code;
            this.Msg = response.Msg;
            this.SubCode = response.SubCode;
            this.SubMsg = response.SubMsg;
            this.Body = response.Body;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubMsg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }
    }
}
