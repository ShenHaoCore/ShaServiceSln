namespace Sha.Framework.Base
{
    /// <summary>
    /// 基础响应异常
    /// </summary>
    public class BaseResponseException
    {
        /// <summary>
        /// 堆栈信息
        /// </summary>
        public string StackTrace { get; set; } = String.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; } = String.Empty;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; } = String.Empty;
    }
}
