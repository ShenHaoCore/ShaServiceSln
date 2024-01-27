using Sha.Framework.Common;
using StackExchange.Redis;

namespace Sha.Framework.Redis
{
    /// <summary>
    /// Redis安装服务
    /// </summary>
    public static class RedisSetup
    {
        /// <summary>
        /// Redis注册
        /// </summary>
        /// <param name="services"></param>
        public static void AddRedisSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            var setting = AppSettingHelper.GetObject<RedisSetting>(RedisSetting.KEY);
            ArgumentNullException.ThrowIfNull(setting);

            ConfigurationOptions config = new ConfigurationOptions { ClientName = setting.Name, Password = setting.Password, ConnectTimeout = setting.Timeout };
            setting.EndPoints.ForEach(P => { config.EndPoints.Add(P.Host, P.Port); });
            config.ResolveDns = true;

            services.AddSingleton<IConnectionMultiplexer>(P => ConnectionMultiplexer.Connect(config));
            services.AddSingleton<ConnectionMultiplexer>(P => P.GetService<IConnectionMultiplexer>() as ConnectionMultiplexer ?? throw new ArgumentNullException());
            services.AddTransient<IRedisManage, RedisManage>();
        }
    }
}
