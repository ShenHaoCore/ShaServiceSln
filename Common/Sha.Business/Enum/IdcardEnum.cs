using System.ComponentModel;

namespace Sha.Business.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public class IdcardEnum
    {
        /// <summary>
        /// 性別
        /// </summary>
        public enum Sex
        {
            /// <summary>
            /// 男
            /// </summary>
            [Description("男")]
            Man = 1,

            /// <summary>
            /// 女
            /// </summary>
            [Description("女")]
            Woman = 0,
        }

        /// <summary>
        /// 民族
        /// </summary>
        public enum Nation
        {
            /// <summary>
            /// 汉族
            /// </summary>
            [Description("汉族")]
            Han = 1,

            /// <summary>
            /// 壮族
            /// </summary>
            [Description("壮族")]
            Zhuang = 2,

            /// <summary>
            /// 满族
            /// </summary>
            [Description("满族")]
            Manchu = 3,

            /// <summary>
            /// 回族
            /// </summary>
            [Description("回族")]
            Hui = 4,

            /// <summary>
            /// 苗族
            /// </summary>
            [Description("苗族")]
            Miao = 5,

            /// <summary>
            /// 维吾尔族
            /// </summary>
            [Description("维吾尔族")]
            Uyghur = 6,

            /// <summary>
            /// 土家族
            /// </summary>
            [Description("土家族")]
            Tujia = 7,

            /// <summary>
            /// 彝族
            /// </summary>
            [Description("彝族")]
            Yi = 8,

            /// <summary>
            /// 蒙古族
            /// </summary>
            [Description("蒙古族")]
            Mongolian = 9,

            /// <summary>
            /// 藏族
            /// </summary>
            [Description("藏族")]
            Tibetan = 10,

            /// <summary>
            /// 布依族
            /// </summary>
            [Description("布依族")]
            Buyei = 11,

            /// <summary>
            /// 侗族
            /// </summary>
            [Description("侗族")]
            Dong = 12,

            /// <summary>
            /// 瑶族
            /// </summary>
            [Description("瑶族")]
            Yao = 13,

            /// <summary>
            /// 朝鲜族
            /// </summary>
            [Description("朝鲜族")]
            Korean = 14,

            /// <summary>
            /// 白族
            /// </summary>
            [Description("白族")]
            Bai = 15,

            /// <summary>
            /// 哈尼族
            /// </summary>
            [Description("哈尼族")]
            Hani = 16,

            /// <summary>
            /// 黎族
            /// </summary>
            [Description("黎族")]
            Li = 17,

            /// <summary>
            /// 哈萨克族
            /// </summary>
            [Description("哈萨克族")]
            Kazak = 18,

            /// <summary>
            /// 傣族
            /// </summary>
            [Description("傣族")]
            Dai = 19,

            /// <summary>
            /// 畲族
            /// </summary>
            [Description("畲族")]
            She = 20,

            /// <summary>
            /// 僳僳族
            /// </summary>
            [Description("僳僳族")]
            Lisu = 21,

            /// <summary>
            /// 仡佬族
            /// </summary>
            [Description("仡佬族")]
            Gelao = 22,
        }
    }
}
