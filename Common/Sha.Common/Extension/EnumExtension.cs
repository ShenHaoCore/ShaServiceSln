using System.Collections;
using System.ComponentModel;

namespace Sha.Common.Extension
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum obj)
        {
            string name = obj.ToString();
            var field = obj.GetType().GetField(name);
            if (field is null) { return string.Empty; }
            object[] attris = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (!attris.Any()) { return string.Empty; }
            DescriptionAttribute desc = (DescriptionAttribute)attris.First();
            return desc.Description;
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="type">枚举</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static string GetDescription(this Type type, object value)
        {
            var name = Enum.GetName(type, value);
            if (string.IsNullOrWhiteSpace(name)) { return string.Empty; }
            var field = type.GetField(name);
            if (field is null) { return string.Empty; }
            object[] attris = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (!attris.Any()) { return string.Empty; }
            DescriptionAttribute desc = (DescriptionAttribute)attris.First();
            return desc.Description; ;
        }

        /// <summary>
        /// 转列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ArrayList ToArrayList(this Type type)
        {
            ArrayList array = new ArrayList();
            if (type.IsEnum)
            {
                Array values = Enum.GetValues(type);
                foreach (Enum value in values)
                {
                    array.Add(new KeyValuePair<Enum, string>(value, value.GetDescription()));
                }
            }
            return array;
        }
    }
}
