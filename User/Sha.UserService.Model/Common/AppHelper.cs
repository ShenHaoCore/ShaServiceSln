using System.Reflection;

namespace Sha.UserService.Model.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class AppHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string AssemblyName => $"{Assembly.GetExecutingAssembly().GetName().Name}";
    }
}
