using System.Reflection;

namespace Sha.UserService.Model.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string AssemblyName => $"{Assembly.GetExecutingAssembly().GetName().Name}";
    }
}
