namespace Sha.Common.Calendar
{
    /// <summary>
    /// 节日
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="name"></param>
        public Holiday(int month, int day, string name)
        {
            this.Month = month;
            this.Day = day;
            this.Name = name;
        }

        /// <summary>
        /// 月
        /// </summary>
        public readonly int Month;

        /// <summary>
        /// 日
        /// </summary>
        public readonly int Day;

        /// <summary>
        /// 节假日名
        /// </summary>
        public readonly string Name;
    }
}
