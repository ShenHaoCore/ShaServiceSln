using System.Globalization;

namespace Sha.Common.Extension
{
    /// <summary>
    /// 日期时间扩展
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// 时间戳计时开始时间
        /// </summary>
        private static readonly DateTime StartTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// 获取星期一日期时间（以星期一为第一天）
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetMonday(this DateTime dt) => dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).Date;

        /// <summary>
        /// 获取星期二日期时间（以星期一为第一天）
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetTuesday(this DateTime dt) => dt.AddDays(2 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).Date;

        /// <summary>
        /// 获取星期三日期时间（以星期一为第一天）
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetWednesday(this DateTime dt) => dt.AddDays(3 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).Date;

        /// <summary>
        /// 获取星期四日期时间（以星期一为第一天）
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetThursday(this DateTime dt) => dt.AddDays(4 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).Date;

        /// <summary>
        /// 获取星期五日期时间（以星期一为第一天）
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetFriday(this DateTime dt) => dt.AddDays(5 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).Date;

        /// <summary>
        /// 获取星期六日期时间（以星期一为第一天）
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetSaturday(this DateTime dt) => dt.AddDays(6 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).Date;

        /// <summary>
        /// 获取星期天日期时间（以星期一为第一天）
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetSunday(this DateTime dt) => dt.AddDays(7 - Convert.ToInt32(dt.DayOfWeek.ToString("d"))).Date;

        /// <summary>
        /// 获取月初日期时间
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetStartMonth(this DateTime dt) => new DateTime(dt.Year, dt.Month, 1);

        /// <summary>
        /// 获取月末日期时间
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns></returns>
        public static DateTime GetEndMonth(this DateTime dt) => new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));

        /// <summary>
        /// 转化UTC日期时间
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <param name="zone">时区</param>
        /// <returns></returns>
        public static DateTime ConvertUtc(this DateTime dt, TimeZoneInfo zone) => TimeZoneInfo.ConvertTimeToUtc(Convert.ToDateTime(dt.ToString("M/d/yyyy hh:mm:ss tt", DateTimeFormatInfo.InvariantInfo)), zone);

        /// <summary>
        /// 转换为10位时间戳（单位：秒）
        /// </summary>
        /// <param name="dt">日期时间</param>
        /// <returns>10位时间戳（单位：秒）</returns>
        public static long ConvertTimeStamp(this DateTime dt) => (long)(dt.ToUniversalTime() - StartTime).TotalSeconds;
    }
}
