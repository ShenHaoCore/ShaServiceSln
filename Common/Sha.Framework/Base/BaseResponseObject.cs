using Sha.Common.Extension;
using Sha.Framework.Enum;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseObject<T> : BaseResponse
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        public BaseResponseObject(bool isSuccess, FrameworkEnum.StatusCode code)
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
        public BaseResponseObject(bool isSuccess, string code, string message)
        {
            this.IsSuccess = isSuccess;
            this.Code = code;
            this.Message = message;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        /// <param name="data"></param>
        public BaseResponseObject(bool isSuccess, FrameworkEnum.StatusCode code, T? data)
        {
            this.IsSuccess = isSuccess;
            this.Code = code.GetHashCode().ToString();
            this.Message = code.GetDescription();
            this.Data = data;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public BaseResponseObject(bool isSuccess, string code, string message, T? data)
        {
            this.IsSuccess = isSuccess;
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        /// <summary>
        /// 返回对象数据
        /// </summary>
        public T? Data { get; set; }
    }
}
