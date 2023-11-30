using Sha.Common.Extension;
using Sha.Framework.Enum;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 结果
    /// </summary>
    public class ResultModel<T>
    {
        /// <summary>
        /// 结果
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        public ResultModel(bool isSuccess, FrameworkEnum.StatusCode code)
        {
            this.IsSuccess = isSuccess;
            this.Code = code.GetHashCode().ToString();
            this.Message = code.GetDescription();
        }

        /// <summary>
        /// 结果
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        /// <param name="date"></param>
        public ResultModel(bool isSuccess, FrameworkEnum.StatusCode code, T date)
        {
            this.IsSuccess = isSuccess;
            this.Code = code.GetHashCode().ToString();
            this.Message = code.GetDescription();
            this.Data = date;
        }

        /// <summary>
        /// 结果
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ResultModel(bool isSuccess, string code, string message)
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
        /// 结果
        /// </summary>
        public T? Data { get; set; }
    }
}
