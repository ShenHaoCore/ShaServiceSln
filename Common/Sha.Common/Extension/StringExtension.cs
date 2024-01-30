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
        /// 拆分字符串为整数数组
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static List<int> SplitToInt(this string value, params char[]? separator)
        {
            List<int> list = new List<int>();
            string[] items = value.Split(separator);
            for (int i = 0; i < items.Length; i++) { if (int.TryParse(items[i], out int val)) { list.Add(val); } }
            return list;
        }
    }
}
