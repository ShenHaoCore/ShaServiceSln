using Sha.Common.Extension;
using Sha.Framework.Enum;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponseList<T> : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="code"></param>
        /// <param name="data"></param>
        public BaseResponseList(bool isSuccess, FrameworkEnum.StatusCode code, List<T> data)
        {
            this.IsSuccess = isSuccess;
            this.Code = code.GetHashCode().ToString();
            this.Message = code.GetDescription();
            this.Data = data;
        }

        /// <summary>
        /// 结果集合
        /// </summary>
        public List<T> Data { get; set; }
    }
}
