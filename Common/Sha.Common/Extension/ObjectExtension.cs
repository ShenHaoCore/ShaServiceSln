using Newtonsoft.Json;

namespace Sha.Common.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ObjToString(this object value) => value is null ? string.Empty : value.ToString()!.Trim();

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJson(this object value) => JsonConvert.SerializeObject(value);
    }
}
