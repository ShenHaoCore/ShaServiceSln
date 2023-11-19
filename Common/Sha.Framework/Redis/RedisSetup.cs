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
            ArgumentNullException.ThrowIfNull(nameof(services));
            RedisConfig? redis = AppSettings.GetObject<RedisConfig>(RedisConfig.KEY);
            if (redis == null) { throw new ArgumentNullException(nameof(redis)); }

            ConfigurationOptions config = new ConfigurationOptions { ClientName = redis.Name, Password = redis.Password, ConnectTimeout = redis.Timeout };
            redis.EndPoints.ForEach(P => { config.EndPoints.Add(P.Host, P.Port); });
            config.ResolveDns = true;

            services.AddSingleton<IConnectionMultiplexer>(P => ConnectionMultiplexer.Connect(config));
            services.AddSingleton<ConnectionMultiplexer>(P => P.GetService<IConnectionMultiplexer>() as ConnectionMultiplexer ?? throw new ArgumentNullException());
            services.AddTransient<IRedisManage, RedisManage>();
        }
    }
}
