using Newtonsoft.Json;

namespace Sha.Common.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public static class ObjectExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ObjToString(this object value) => value is null ? string.Empty : value.ToString()!.Trim();

        /// <summary>
        /// 深度克隆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T? DeepClone<T>(this T obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            JsonSerializerSettings deserSettings = new() { ObjectCreationHandling = ObjectCreationHandling.Replace };
            JsonSerializerSettings serSettings = new() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj, serSettings), deserSettings);
        }
    }
}
