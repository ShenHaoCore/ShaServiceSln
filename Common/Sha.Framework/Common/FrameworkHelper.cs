using System.Reflection;

namespace Sha.Framework.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class FrameworkHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static string AssemblyName => $"{Assembly.GetExecutingAssembly().GetName().Name}";
    }
}
