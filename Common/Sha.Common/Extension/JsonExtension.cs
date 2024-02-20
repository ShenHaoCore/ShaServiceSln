using Newtonsoft.Json;

namespace Sha.Common.Extension
{
    /// <summary>
    /// JSON扩展
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? ToObject<T>(this string? value) => JsonConvert.DeserializeObject<T>(value is null ? string.Empty : value);

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToJson(this object value) => JsonConvert.SerializeObject(value);
    }
}
