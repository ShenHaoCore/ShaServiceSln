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
            ArgumentNullException.ThrowIfNull(nameof(services));
            var rabbitmq = AppSettingHelper.GetObject<RabbitMQConfig>(RabbitMQConfig.KEY);
            if (rabbitmq == null) { return; } // 暂时禁用
            if (rabbitmq == null) { throw new ArgumentNullException(nameof(rabbitmq)); }
            string connectionString = $"host={rabbitmq.HostName};virtualHost=/;username={rabbitmq.UserName};password={rabbitmq.Password}";
            services.AddSingleton(RabbitHutch.CreateBus(connectionString));
        }
    }
}
