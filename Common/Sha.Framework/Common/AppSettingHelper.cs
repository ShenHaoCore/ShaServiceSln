/*************************************************************************************
 * 
 * 文 件 名：AppSettingHelper.cs
 * 描    述：配置文件 appsettings.json 读取
 * 
 * 版    本：V1.0
 * 创 建 者：Shenhao 
 * 创建时间：2023/11/11
 * ======================================
 * 历史更新记录
 * 版本：V1.0  修改时间：2023/11/11  修改人：Shenhao    修改内容：新建文件
 * ======================================
 * 引入NuGet包：Microsoft.Extensions.Configuration.Binder
 * 
*************************************************************************************/

namespace Sha.Framework.Common
{
    /// <summary>
    /// 配置帮助类
    /// </summary>
    public class AppSettingHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static IConfiguration? config { get; set; }

        /// <summary>
        /// 配置帮助类
        /// </summary>
        /// <param name="configuration"></param>
        public AppSettingHelper(IConfiguration configuration)
        {
            config = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            ArgumentNullException.ThrowIfNull(config);
            return config.GetConnectionString(key) ?? string.Empty;
        }

        /// <summary>
        /// 封装要操作的字符
        /// <sample>例：GetValue("App", "Name")</sample>
        /// </summary>
        /// <param name="keys">节点</param>
        /// <returns></returns>
        public static string GetValue(params string[] keys)
        {
            ArgumentNullException.ThrowIfNull(config);
            if (keys.Any()) { return config[string.Join(":", keys)] ?? string.Empty; }
            return string.Empty;
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T? GetObject<T>(params string[] key)
        {
            ArgumentNullException.ThrowIfNull(config);
            return config.GetSection(string.Join(":", key)).Get<T>();
        }

        /// <summary>
        /// 递归获取配置信息数组
        /// 引用 Microsoft.Extensions.Configuration.Binder 包
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">节点</param>
        /// <returns></returns>
        public static List<T> GetList<T>(params string[] key)
        {
            ArgumentNullException.ThrowIfNull(config);
            List<T> list = new List<T>();
            config.Bind(string.Join(":", key), list);
            return list;
        }
    }
}
