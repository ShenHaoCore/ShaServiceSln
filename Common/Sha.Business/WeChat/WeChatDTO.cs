using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace Sha.Business.WeChat
{
    /// <summary>
    /// 微信证书请求
    /// </summary>
    public class CertResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public List<Cert> Certs { get; set; } = [];
    }

    /// <summary>
    /// 平台证书信息
    /// </summary>
    public class Cert
    {
        /// <summary>
        /// 序列号
        /// </summary>
        [JsonProperty("serial_no")]
        public string SerialNo { get; set; } = string.Empty;

        /// <summary>
        /// 生效时间
        /// </summary>
        [JsonProperty("effective_time")]
        public DateTime EffectiveTime { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        [JsonProperty("expire_time")]
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 加密证书
        /// </summary>
        [JsonProperty("encrypt_certificate")]
        public EncryptCert EncryptCert { get; set; } = new();
    }

    /// <summary>
    /// 加密证书信息
    /// </summary>
    public class EncryptCert
    {
        /// <summary>
        /// 获取或设置算法类型，目前只支持：AEAD_AES_256_GCM。
        /// </summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = string.Empty;

        /// <summary>
        /// 随机串
        /// </summary>
        [JsonProperty("nonce")]
        public string Nonce { get; set; } = string.Empty;

        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonProperty("associated_data")]
        public string AssociatedData { get; set; } = string.Empty;

        /// <summary>
        /// 数据密文
        /// </summary>
        [JsonProperty("ciphertext")]
        public string Ciphertext { get; set; } = string.Empty;
    }

    /// <summary>
    /// 平台证书
    /// </summary>
    public class PlatformCert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mchid"></param>
        /// <param name="serialno"></param>
        /// <param name="effectivetime"></param>
        /// <param name="expiretime"></param>
        /// <param name="cert"></param>
        public PlatformCert(string mchid, string serialno, DateTime effectivetime, DateTime expiretime, X509Certificate2 cert)
        {
            this.MchId = mchid;
            this.SerialNo = serialno;
            this.ExpireTime = effectivetime;
            this.ExpireTime = expiretime;
            this.Cert = cert;
        }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNo { get; set; }

        /// <summary>
        /// 生效时间
        /// </summary>
        public DateTime EffectiveTime { get; set; }

        /// <summary>
        /// 失效时间
        /// </summary>
        public DateTime ExpireTime { get; set; }

        /// <summary>
        /// 证书
        /// </summary>
        public X509Certificate2 Cert;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TradeAppPayModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mchid")]
        public string MchId { get; set; } = string.Empty;

        /// <summary>
        /// 商户订单号
        /// </summary>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; } = string.Empty;

        /// <summary>
        /// 应用ID
        /// </summary>
        [JsonProperty("appid")]
        public string AppID { get; set; } = string.Empty;

        /// <summary>
        /// 商品描述
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 通知地址
        /// </summary>
        [JsonProperty("notify_url")]
        public string NotifyUrl { get; set; } = string.Empty;

        /// <summary>
        /// 金额
        /// </summary>
        [JsonProperty("amount")]
        public TradeAppAmountModel Amount { get; set; } = new();
    }

    /// <summary>
    /// 订单金额请求
    /// </summary>
    public class TradeAppAmountModel
    {
        /// <summary>
        /// 总金额（单位为分）
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// 货币类型（CNY）
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TradeAppPayResponse
    {
        
    }

    /// <summary>
    /// 通知头
    /// </summary>
    public class NotifyHeader
    {
        /// <summary>
        /// 平台证书序列号[Wechatpay-Serial]
        /// </summary>
        public string SerialNo { get; set; } = string.Empty;

        /// <summary>
        /// 时间戳[Wechatpay-Timestamp]
        /// </summary>
        public string Timestamp { get; set; } = string.Empty;

        /// <summary>
        /// 随机串[Wechatpay-Nonce]
        /// </summary>
        public string Nonce { get; set; } = string.Empty;

        /// <summary>
        /// 签名串[Wechatpay-Signature]
        /// </summary>
        public string Signature { get; set; } = string.Empty;
    }

    /// <summary>
    /// 微信支付通知请求
    /// </summary>
    public class NotifyRequest
    {
        /// <summary>
        /// 通知ID
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; } = string.Empty;

        /// <summary>
        /// 通知创建时间
        /// </summary>
        [JsonProperty("create_time")]
        public string CreateTime { get; set; } = string.Empty;

        /// <summary>
        /// 通知类型
        /// </summary>
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; } = string.Empty;

        /// <summary>
        /// 通知数据类型
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; set; } = string.Empty;

        /// <summary>
        /// 回调摘要
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; } = string.Empty;

        /// <summary>
        /// 通知数据
        /// </summary>
        [JsonProperty("resource")]
        public TranNotifyResource Resource { get; set; } = new TranNotifyResource();
    }

    /// <summary>
    /// 微信资源请求
    /// </summary>
    public class TranNotifyResource
    {
        /// <summary>
        /// 原始类型
        /// </summary>
        [JsonProperty("original_type")]
        public string OriginalType { get; set; } = string.Empty;

        /// <summary>
        /// 加密算法类型
        /// </summary>
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; } = string.Empty;

        /// <summary>
        /// 数据密文
        /// </summary>
        [JsonProperty("ciphertext")]
        public string Ciphertext { get; set; } = string.Empty;

        /// <summary>
        /// 随机串
        /// </summary>
        [JsonProperty("associated_data")]
        public string AssociatedData { get; set; } = string.Empty;

        /// <summary>
        /// 附加数据
        /// </summary>
        [JsonProperty("nonce")]
        public string Nonce { get; set; } = string.Empty;
    }

    /// <summary>
    /// 微信支付通知响应
    /// </summary>
    public class NotifyResponse
    {
        /// <summary>
        /// 错误码（SUCCESS：接收成功）
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 返回信息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class TransactionsNotify
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        /// <remarks>
        /// 直连商户申请的公众号或移动应用appid。
        /// <para>示例值：wxd678efh567hg6787</para>
        /// </remarks>
        [JsonProperty("appid")]
        public string AppID { get; set; } = string.Empty;

        /// <summary>
        /// 商户号
        /// </summary>
        /// <remarks>
        /// 直连商户的商户号，由微信支付生成并下发。
        /// <para>示例值：1230000109</para>
        /// </remarks>
        [JsonProperty("mchid")]
        public string MchID { get; set; } = string.Empty;

        /// <summary>
        /// 商户订单号
        /// </summary>
        /// <remarks>
        /// 商户系统内部订单号，只能是数字、大小写字母_-*且在同一个商户号下唯一，详见【商户订单号】。
        /// 特殊规则：最小字符长度为6
        /// <para>示例值：1217752501201407033233368018</para>
        /// </remarks>
        [JsonProperty("out_trade_no")]
        public string OutTradeNo { get; set; } = string.Empty;

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        /// <remarks>
        /// 微信支付系统生成的订单号。
        /// <para>示例值：1217752501201407033233368018</para>
        /// </remarks>
        [JsonProperty("transaction_id")]
        public string TransactionID { get; set; } = string.Empty;

        /// <summary>
        /// 交易类型
        /// </summary>
        /// <remarks>
        /// 交易类型，枚举值。
        /// <para>示例值：MICROPAY</para>
        /// <sample>JSAPI：公众号支付</sample>
        /// <sample>NATIVE：扫码支付</sample>
        /// <sample>APP：APP支付</sample>
        /// <sample>MICROPAY：付款码支付</sample>
        /// <sample>MWEB：H5支付</sample>
        /// <sample>FACEPAY：刷脸支付</sample>
        /// </remarks>
        [JsonProperty("trade_type")]
        public string TradeType { get; set; } = string.Empty;

        /// <summary>
        /// 交易状态
        /// </summary>
        /// <remarks>
        /// 交易状态，枚举值。
        /// <para>示例值：SUCCESS</para>
        /// <sample>SUCCESS：支付成功</sample>
        /// <sample>REFUND：转入退款</sample>
        /// <sample>NOTPAY：未支付</sample>
        /// <sample>CLOSED：已关闭</sample>
        /// <sample>REVOKED：已撤销（付款码支付）</sample>
        /// <sample>USERPAYING：用户支付中（付款码支付）</sample>
        /// <sample>PAYERROR：支付失败(其他原因，如银行返回失败)</sample>
        /// </remarks>
        [JsonProperty("trade_state")]
        public string TradeState { get; set; } = string.Empty;

        /// <summary>
        /// 交易状态描述
        /// </summary>
        /// <remarks>
        /// 交易状态描述
        /// <para>示例值：支付失败，请重新下单支付</para>
        /// </remarks>
        [JsonProperty("trade_state_desc")]
        public string TradeStateDesc { get; set; } = string.Empty;

        /// <summary>
        /// 付款银行
        /// </summary>
        /// <remarks>
        /// 银行类型，采用字符串类型的银行标识。
        /// <para>示例值：CMC</para>
        /// </remarks>
        [JsonProperty("bank_type")]
        public string BankType { get; set; } = string.Empty;

        /// <summary>
        /// 附加数据
        /// </summary>
        /// <remarks>
        /// 附加数据，在查询API和支付通知中原样返回，可作为自定义参数使用
        /// <para>示例值：自定义数据</para>
        /// </remarks>
        [JsonProperty("attach")]
        public string Attach { get; set; } = string.Empty;

        /// <summary>
        /// 支付完成时间
        /// </summary>
        /// <remarks>
        /// 支付完成时间，遵循RFC3339标准格式，格式为YYYY-MM-DDTHH:mm:ss+TIMEZONE
        /// YYYY-MM-DD 表示年月日，T 出现在字符串中表示 TIEM 元素的开头，HH:mm:ss 表示时分秒，TIMEZONE 表示时区
        /// <para>示例值：2018-06-08T10:34:56+08:00</para>
        /// <para>东八区时间 +08:00 表示，领先UTC 8小时，即北京时间</para>
        /// <para>例如：2015-05-20T13:29:35+08:00表示，北京时间2015年5月20日 13点29分35秒</para>
        /// </remarks>
        [JsonProperty("success_time")]
        public string SuccessTime { get; set; } = string.Empty;

        /// <summary>
        /// 支付者
        /// </summary>
        /// <remarks>
        /// 支付者信息
        /// <para>示例值：见请求示例</para>
        /// </remarks>
        [JsonProperty("payer")]
        public PayerInfo Payer { get; set; } = new PayerInfo();

        /// <summary>
        /// 订单金额
        /// </summary>
        /// <remarks>
        /// 订单金额信息
        /// <para>示例值：见请求示例</para>
        /// </remarks>
        [JsonProperty("amount")]
        public Amount Amount { get; set; } = new Amount();

        /// <summary>
        /// 场景信息
        /// </summary>
        /// <remarks>
        /// 支付场景描述
        /// <para>示例值：见请求示例</para>
        /// </remarks>
        [JsonProperty("scene_info")]
        public SceneInfo SceneInfo { get; set; } = new SceneInfo();

        /// <summary>
        /// 优惠功能
        /// </summary>
        /// <remarks>
        /// 优惠功能，享受优惠时返回该字段。
        /// <para>示例值：见请求示例</para>
        /// </remarks>
        [JsonProperty("promotion_detail")]
        public List<PromotionDetail> PromotionDetail { get; set; } = new List<PromotionDetail>();
    }

    /// <summary>
    /// 支付者信息
    /// </summary>
    public class PayerInfo
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        /// <remarks>
        /// 用户在直连商户APPID下的唯一标识。
        /// <para>示例值：oUpF8uMuAJO_M2pxb1Q9zNjWeS6o</para>
        /// </remarks>
        [JsonProperty("openid")]
        public string OpenID { get; set; } = string.Empty;
    }

    /// <summary>
    /// 订单金额
    /// </summary>
    public class Amount
    {
        /// <summary>
        /// 订单金额
        /// </summary>
        /// <remarks>
        /// 订单总金额，单位为分。
        /// <para>示例值：100</para>
        /// </remarks>
        [JsonProperty("total")]
        public int? Total { get; set; }

        /// <summary>
        /// 用户支付金额
        /// </summary>
        /// <remarks>
        /// 用户支付金额，单位为分。
        /// <para>示例值：100</para>
        /// </remarks>
        [JsonProperty("payer_total")]
        public int? PayerTotal { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        /// <remarks>
        /// CNY：人民币，境内商户号仅支持人民币。
        /// <para>示例值：CNY</para>
        /// </remarks>
        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// 用户支付币种
        /// </summary>
        /// <remarks>
        /// 用户支付币种
        /// <para>示例值：CNY</para>
        /// </remarks>
        [JsonProperty("payer_currency")]
        public string PayerCurrency { get; set; } = string.Empty;
    }

    /// <summary>
    /// 场景信息
    /// </summary>       
    public class SceneInfo
    {
        /// <summary>
        /// 用户终端IP
        /// </summary>
        /// <remarks>
        /// 调用微信支付API的机器IP，支持IPv4和IPv6两种格式的IP地址。
        /// <para>示例值：14.23.150.211</para>
        /// </remarks>
        [JsonProperty("payer_client_ip")]
        public string PayerClientIp { get; set; } = string.Empty;

        /// <summary>
        /// 商户端设备号
        /// </summary>
        /// <remarks>
        /// 商户端设备号（门店号或收银设备ID）。
        /// <para>示例值：013467007045764</para>
        /// </remarks>
        [JsonProperty("device_id")]
        public string DeviceId { get; set; } = string.Empty;

        /// <summary>
        /// 商户门店信息
        /// </summary>
        /// <remarks>
        /// 商户门店信息
        /// </remarks>
        [JsonProperty("store_info")]
        public StoreInfo StoreInfo { get; set; } = new StoreInfo();

        /// <summary>
        /// H5场景信息
        /// </summary>
        /// <remarks>
        /// H5场景信息
        /// </remarks>
        [JsonProperty("h5_info")]
        public H5Info H5Info { get; set; } = new H5Info();
    }

    /// <summary>
    /// 优惠功能
    /// </summary>
    public class PromotionDetail
    {
        /// <summary>
        /// 券ID
        /// </summary>
        /// <remarks>
        /// 券ID
        /// <para>示例值：109519</para>
        /// </remarks>
        [JsonProperty("coupon_id")]
        public string CouponId { get; set; } = string.Empty;

        /// <summary>
        /// 优惠名称
        /// </summary>
        /// <remarks>
        /// 优惠名称
        /// <para>示例值：单品惠-6</para>
        /// </remarks>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 优惠范围
        /// </summary>
        /// <remarks>
        /// GLOBAL：全场代金券
        /// SINGLE：单品优惠
        /// <para>示例值：GLOBAL</para>
        /// </remarks>
        [JsonProperty("scope")]
        public string Scope { get; set; } = string.Empty;

        /// <summary>
        /// 优惠类型
        /// </summary>
        /// <remarks>
        /// CASH：充值
        /// NOCASH：预充值
        /// <para>示例值：CASH</para>
        /// </remarks>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 优惠券面额
        /// </summary>
        /// <remarks>
        /// 优惠券面额
        /// <para>示例值：100</para>
        /// </remarks>
        [JsonProperty("amount")]
        public int Amount { get; set; }

        /// <summary>
        /// 活动ID
        /// </summary>
        /// <remarks>
        /// 活动ID
        /// <para>示例值：931386</para>
        /// </remarks>
        [JsonProperty("stock_id")]
        public string StockId { get; set; } = string.Empty;

        /// <summary>
        /// 微信出资
        /// </summary>
        /// <remarks>
        /// 微信出资，单位为分
        /// <para>示例值：0</para>
        /// </remarks>
        [JsonProperty("wechatpay_contribute")]
        public int? WeChatPayContribute { get; set; }

        /// <summary>
        /// 商户出资
        /// </summary>
        /// <remarks>
        /// 商户出资，单位为分
        /// <para>示例值：0</para>
        /// </remarks>
        [JsonProperty("merchant_contribute")]
        public long? MerchantContribute { get; set; }

        /// <summary>
        /// 其他出资
        /// </summary>
        /// <remarks>
        /// 其他出资，单位为分
        /// <para>示例值：0</para>
        /// </remarks>
        [JsonProperty("other_contribute")]
        public long? OtherContribute { get; set; }

        /// <summary>
        /// 优惠币种
        /// </summary>
        /// <remarks>
        /// CNY：人民币，境内商户号仅支持人民币。
        /// <para>示例值：CNY</para>
        /// </remarks>
        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// 单品列表
        /// </summary>
        /// <remarks>
        /// 单品列表信息
        /// </remarks>
        [JsonProperty("goods_detail")]
        public List<PromotionGoodsDetail> GoodsDetail { get; set; } = new List<PromotionGoodsDetail>();
    }

    /// <summary>
    /// H5场景信息
    /// </summary>
    public class H5Info
    {
        /// <summary>
        /// 场景类型
        /// </summary>
        /// <remarks>
        /// 场景类型，枚举值：
        /// iOS：IOS移动应用；
        /// Android：安卓移动应用；
        /// Wap：WAP网站应用；
        /// <para>示例值：iOS</para>
        /// </remarks>
        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// 应用名称
        /// </summary>
        /// <remarks>
        /// 应用名称
        /// <para>示例值：王者荣耀</para>
        /// </remarks>
        [JsonProperty("app_name")]
        public string AppName { get; set; } = string.Empty;

        /// <summary>
        /// 网站URL
        /// </summary>
        /// <remarks>
        /// 网站URL
        /// <para>示例值：https://pay.qq.com</para>
        /// </remarks>
        [JsonProperty("app_url")]
        public string AppUrl { get; set; } = string.Empty;

        /// <summary>
        /// iOS平台BundleID
        /// </summary>
        /// <remarks>
        /// iOS平台BundleID
        /// <para>示例值：com.tencent.wzryiOS</para>
        /// </remarks>
        [JsonProperty("bundle_id")]
        public string BundleId { get; set; } = string.Empty;

        /// <summary>
        /// Android平台PackageName
        /// </summary>
        /// <remarks>
        /// Android平台PackageName
        /// <para>示例值：com.tencent.tmgp.sgame</para>
        /// </remarks>
        [JsonProperty("package_name")]
        public string PackageName { get; set; } = string.Empty;
    }

    /// <summary>
    /// 单品列表信息
    /// </summary>
    public class PromotionGoodsDetail
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        /// <remarks>
        /// 商品编码
        /// <para>示例值：M1006</para>
        /// </remarks>
        [JsonProperty("goods_id")]
        public string GoodsId { get; set; } = string.Empty;

        /// <summary>
        /// 商品数量
        /// </summary>
        /// <remarks>
        /// 用户购买的数量
        /// <para>示例值：1</para>
        /// </remarks>
        [JsonProperty("quantity")]
        public int? Quantity { get; set; }

        /// <summary>
        /// 商品单价
        /// </summary>
        /// <remarks>
        /// 商品单价，单位为分
        /// <para>示例值：100</para>
        /// </remarks>
        [JsonProperty("unit_price")]
        public long? UnitPrice { get; set; }

        /// <summary>
        /// 商品优惠金额
        /// </summary>
        /// <remarks>
        /// 商品优惠金额
        /// <para>示例值：0  </para>
        /// </remarks>
        [JsonProperty("discount_amount")]
        public long? DiscountAmount { get; set; }

        /// <summary>
        /// 商品备注
        /// </summary>
        /// <remarks>
        /// 商品备注信息
        /// <para>示例值：商品备注信息</para>
        /// </remarks>
        [JsonProperty("goods_remark")]
        public string GoodsRemark { get; set; } = string.Empty;
    }

    /// <summary>
    /// 商户门店信息
    /// </summary>
    public class StoreInfo
    {
        /// <summary>
        /// 门店编号
        /// <para>示例值：0001</para>
        /// </summary>
        /// <remarks>商户侧门店编号</remarks>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 门店名称
        /// <para>示例值：腾讯大厦分店</para>
        /// </summary>
        /// <remarks>商户侧门店名称</remarks>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 地区编码
        /// <para>示例值：440305</para>
        /// </summary>
        /// <remarks>地区编码，详细请见省市区编号对照表。</remarks>
        [JsonProperty("area_code")]
        public string AreaCode { get; set; } = string.Empty;

        /// <summary>
        /// 详细地址
        /// <para>示例值：广东省深圳市南山区科技中一道10000号</para>
        /// </summary>
        /// <remarks>详细的商户门店地址</remarks>
        [JsonProperty("address")]
        public string Address { get; set; } = string.Empty;
    }
}
