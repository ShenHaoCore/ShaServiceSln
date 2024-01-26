using EasyNetQ;
using Sha.Framework.Common;

namespace Sha.Framework.RabbitMQ
{
    /// <summary>
    /// 
    /// </summary>
    public static class RabbitMQSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddRabbitMQSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            var setting = AppSettingHelper.GetObject<RabbitMQSetting>(RabbitMQSetting.KEY);
            if (setting == null) { return; }
            string connectionString = $"host={setting.HostName};virtualHost=/;username={setting.UserName};password={setting.Password}";
            services.AddSingleton(RabbitHutch.CreateBus(connectionString));
        }
    }
}
