using Sha.Business.Enum;

namespace Sha.Business.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderHelper
    {
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetOrderNo(BusinessEnum.BusinessType type) => $"{type}{DateTime.Now:yyyyMMddHHmmssfff}{new Random().Next(10000, 99999)}";
    }
}
