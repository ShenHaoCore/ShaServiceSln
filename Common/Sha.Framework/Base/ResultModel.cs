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
        /// 构造函数
        /// </summary>
        public ResultModel(bool isSuccess, FrameworkEnum.StatusCode code)
        {
            this.IsSuccess = isSuccess;
            this.Code = code.GetHashCode().ToString();
            this.Message = code.GetDescription();
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
