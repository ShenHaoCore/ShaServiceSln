using Sha.Common.Extension;
using Sha.Framework.Enum;

namespace Sha.Framework.Base
{
    /// <summary>
    /// 分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponsePage<T> : BaseResponse
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        /// <param name="code">代码</param>
        /// <param name="data">数据</param>
        /// <param name="total">行数</param>
        public BaseResponsePage(bool isSuccess, FrameworkEnum.StatusCode code, List<T> data, long total)
        {
            this.IsSuccess = isSuccess;
            this.Code = code.GetHashCode().ToString();
            this.Message = code.GetDescription();
            this.Data = data;
            this.Total = total;
        }

        /// <summary>
        /// 结果集合
        /// </summary>
        public List<T> Data { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public long Total { get; set; }
    }
}
