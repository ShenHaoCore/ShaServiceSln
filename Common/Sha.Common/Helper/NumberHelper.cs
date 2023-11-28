using System.Text;

namespace Sha.Common.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class NumberHelper
    {
        /// <summary>
        /// 将指定的自然数转换为26进制字符
        /// </summary>
        /// <param name="number">自然数</param>
        /// <returns></returns>
        public static string ToSystem26(int number)
        {
            StringBuilder str = new StringBuilder();
            while (number > 0)
            {
                int remainder = number % 26;
                if (remainder == 0) { remainder = 26; }
                remainder = remainder + 64;
                str.Insert(0, (char)remainder);
                number = (number - remainder) / 26;
            }
            return str.ToString();
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="d"></param>
        /// <param name="decimals"></param>
        /// <returns></returns>
        public static decimal HalfAdjust(decimal d, int decimals = 0)
        {
            return Math.Round(d, decimals, MidpointRounding.AwayFromZero);
        }
    }
}
