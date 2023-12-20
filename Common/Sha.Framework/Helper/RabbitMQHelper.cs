using EasyNetQ;

namespace Sha.Framework.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class RabbitMQHelper
    {
        /// <summary>
        /// 发布
        /// </summary>
        public static void Publish()
        {
            var connStr = "host=127.0.0.1;virtualHost=/;username=admin;password=123456";
            using (IBus bus = RabbitHutch.CreateBus(connStr))
            {
                bus.PubSub.Publish(new TextMessage { Text = "hello world" });
                bus.Dispose();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TextMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; } = string.Empty;
    }
}
