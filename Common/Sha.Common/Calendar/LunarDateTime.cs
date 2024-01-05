namespace Sha.Common.Calendar
{
    /// <summary>
    /// 阴历
    /// </summary>
    public class LunarDateTime
    {
        /// <summary>
        /// 阴历
        /// </summary>
        /// <param name="date"></param>
        public LunarDateTime(DateTime date)
        {
            this.Date = date;
        }

        /// <summary>
        /// 阴历
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="day">日</param>
        public LunarDateTime(int year, int month, int day)
        {
            this.Date = new DateTime(year, month, day);
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; }

        /// <summary>
        /// 是否闰月
        /// </summary>
        public bool IsLeap { get; }

        /// <summary>
        /// 年
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// 月
        /// </summary>
        public int Month { get; }

        /// <summary>
        /// 日
        /// </summary>
        public int Day { get; }
    }
}
