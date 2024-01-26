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
            ArgumentNullException.ThrowIfNull(services);
            var setting = AppSettingHelper.GetObject<ConsulSetting>(ConsulSetting.KEY);
            if (setting is null) { return; }
            if (!setting.Enable) { return; }

            ConsulClient client = new ConsulClient(options => { options.Address = new Uri(setting.Address); });
            AgentServiceRegistration service = new AgentServiceRegistration
            {
                ID = $"{setting.Name}-{setting.IP}:{setting.Port}", // 唯一ID
                Name = setting.Name, // 服务名
                Address = setting.IP, // 服务绑定IP
                Port = setting.Port, // 服务绑定端口
                Check = new AgentServiceCheck
                {
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5), // 失败后多久移除
                    Interval = TimeSpan.FromSeconds(10), // 健康检查时间间隔
                    HTTP = $"http://{setting.IP}:{setting.Port}{setting.HealthCheck}", // 健康检查地址
                    Timeout = TimeSpan.FromSeconds(5) // 超时时间
                }
            };
            client.Agent.ServiceRegister(service).Wait();
        }
    }
}
