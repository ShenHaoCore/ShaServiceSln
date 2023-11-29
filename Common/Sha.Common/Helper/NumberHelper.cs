using System.Text;

namespace Sha.Common.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class NumberHelper
    {
        /// <summary>
        /// 将正整数转换为26进制字符
        /// </summary>
        /// <param name="number">自然数</param>
        /// <returns></returns>
        public static string ToChar(int number)
        {
            StringBuilder str = new StringBuilder();
            int num = number;
            while (num > 0)
            {
                int remainder = number % 26;
                if (remainder == 0) { remainder = 26; }
                remainder = remainder + 64;
                str.Insert(0, (char)remainder);
                num = (num - remainder) / 26;
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
