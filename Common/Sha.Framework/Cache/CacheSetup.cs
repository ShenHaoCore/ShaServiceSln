namespace Sha.Framework.Cache
{
    /// <summary>
    /// 本地缓存安装服务
    /// </summary>
    public static class CacheSetup
    {
        /// <summary>
        /// 内存注册
        /// </summary>
        /// <param name="services"></param>
        public static void AddCacheSetup(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddSingleton<ICacheManage, CacheManage>();
        }
    }
}
