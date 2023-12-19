namespace Sha.Framework.RabbitMQ
{
    public class RabbitMQConfig
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "RabbitMQ";

        /// <summary>
        /// 
        /// </summary>
        public string HostName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; } = 5672;
    }
}
