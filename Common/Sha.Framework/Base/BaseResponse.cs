using Newtonsoft.Json;
using Sha.Common.Extension;
using Sha.Framework.Enum;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 基础响应
    /// </summary>
    public class BaseResponse : IBaseResponse
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseResponse()
        {
            this.IsSuccess = false;
            this.Code = string.Empty;
            this.Message = string.Empty;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        public BaseResponse(bool isSuccess, FrameworkEnum.StatusCode code)
        {
            this.IsSuccess = isSuccess;
            this.Code = code.GetHashCode().ToString();
            this.Message = code.GetDescription();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public BaseResponse(bool isSuccess, string code, string message)
        {
            this.IsSuccess = isSuccess;
            this.Code = code;
            this.Message = message;
        }

        /// <summary>
        /// 处理成功失败标志
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public BaseResponseException? Exception { get; set; } = null;
    }
}
