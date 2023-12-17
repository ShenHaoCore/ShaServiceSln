using Consul;
using Sha.Framework.Common;

namespace Sha.Framework.Consul
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConsulSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddConsulSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(nameof(services));
            ConsulConfig? consul = AppSettingHelper.GetObject<ConsulConfig>(ConsulConfig.KEY);
            if (consul == null) { throw new ArgumentNullException(nameof(consul)); }

            var client = new ConsulClient(options => { options.Address = new Uri(consul.Address); });

            var registration = new AgentServiceRegistration
            {
                ID = Guid.NewGuid().ToString(),                                     // 唯一ID
                Name = consul.Name,                                                 // 服务名
                Address = consul.IP,                                                // 服务绑定IP
                Port = consul.Port,                                                 // 服务绑定端口
                Check = new AgentServiceCheck
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),       // 服务启动多久后注册
                    Interval = TimeSpan.FromSeconds(10),                            // 健康检查时间间隔
                    HTTP = $"http://{consul.IP}:{consul.Port}{consul.HealthCheck}", // 健康检查地址
                    Timeout = TimeSpan.FromSeconds(5)                               // 超时时间
                }
            };
            client.Agent.ServiceRegister(registration);
        }
    }
}
