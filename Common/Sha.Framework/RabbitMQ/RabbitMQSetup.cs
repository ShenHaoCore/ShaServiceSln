using RabbitMQ.Client;
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
            if (rabbitmq == null) { throw new ArgumentNullException(nameof(rabbitmq)); }

            ConnectionFactory factory = new ConnectionFactory() { HostName = rabbitmq.HostName, Port = rabbitmq.Port, UserName = rabbitmq.UserName, Password = rabbitmq.Password };
        }
    }
}
