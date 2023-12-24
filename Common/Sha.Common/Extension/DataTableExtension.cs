using System.Data;
using System.Reflection;

namespace Sha.Common.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataTableExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            List<PropertyInfo> propertys = new List<PropertyInfo>();
            Array.ForEach<PropertyInfo>(typeof(T).GetProperties(), P => { if (dt.Columns.IndexOf(P.Name) != -1) { propertys.Add(P); } });
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = new T();
                propertys.ForEach(P => { try { if (row[P.Name] != DBNull.Value) { P.SetValue(item, row[P.Name], null); } } catch (Exception) { } });
                list.Add(item);
            }
            return list;
        }
    }
}
