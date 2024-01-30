using Newtonsoft.Json;

namespace Sha.Common.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T? ToObject<T>(this string value) => JsonConvert.DeserializeObject<T>(value);

        /// <summary>
        /// 拆分
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator">分隔符</param>
        /// <returns>整数数组</returns>
        public static List<int> SplitToInt(this string value, params char[]? separator) => value.Split(separator).Where(it => int.TryParse(it, out int val)).Select(int.Parse).ToList();
    }
}
