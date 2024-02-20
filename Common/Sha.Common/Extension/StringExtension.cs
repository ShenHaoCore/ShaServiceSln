namespace Sha.Common.Extension
{
    /// <summary>
    /// String 扩展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 拆分
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator">分隔符</param>
        /// <returns>整数数组</returns>
        public static List<int> SplitToInt(this string value, params char[]? separator) => value.Split(separator).Where(it => int.TryParse(it, out int val)).Select(int.Parse).ToList();
    }
}
