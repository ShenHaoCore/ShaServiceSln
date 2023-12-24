namespace Sha.Common.Calendar
{
    /// <summary>
    /// 阴历
    /// </summary>
    public class LunarCalendar
    {
        private const int YEAR_OF_THE_MOUSE = 1900; // 鼠年(1900年)

        /// <summary>
        /// 最小日期
        /// </summary>
        private static readonly DateTime MinDate = new DateTime(1900, 1, 1);

        /// <summary>
        /// 
        /// </summary>
        private static readonly DateTime GanZhiStartDay = new DateTime(1899, 12, 22); //起始日

        /// <summary>
        /// 12生肖
        /// </summary>
        private static readonly string[] SymbolicAnimals = { "鼠", "牛", "虎", "兔", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };

        /// <summary>
        /// 天干
        /// </summary>
        private static readonly string[] HeavenlyStems = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };

        /// <summary>
        /// 地支
        /// </summary>
        private static readonly string[] EarthlyBranches = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

        /// <summary>
        /// 24节气
        /// </summary>
        private static readonly string[] SolarTerms = {
            "小寒", "大寒", "立春", "雨水", "惊蛰", "春分",
            "清明", "谷雨", "立夏", "小满", "芒种", "夏至",
            "小暑", "大暑", "立秋", "处暑", "白露", "秋分",
            "寒露", "霜降", "立冬", "小雪", "大雪", "冬至"
        };

        /// <summary>
        /// 节日
        /// </summary>
        private static readonly HashSet<Holiday> Holidays = new HashSet<Holiday>() {
            new Holiday(1, 1, "春节"),
            new Holiday(1, 15, "元宵节"),
            new Holiday(5, 5, "端午节"),
            new Holiday(7, 7, "七夕节"),
            new Holiday(7, 15, "中元节"),
            new Holiday(8, 15, "中秋节"),
            new Holiday(9, 9, "重阳节"),
            new Holiday(12, 8, "腊八节"),
            new Holiday(12, 30, "除夕节"),
        };
    }
}
