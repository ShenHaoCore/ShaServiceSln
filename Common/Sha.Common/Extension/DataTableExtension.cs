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
            Array.ForEach<PropertyInfo>(typeof(T).GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) propertys.Add(p); });
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T obj = new();
                propertys.ForEach(p => { try { if (row[p.Name] != DBNull.Value) { p.SetValue(obj, row[p.Name], null); } } catch (Exception) { } });
                list.Add(obj);
            }
            return list;
        }
    }
}
