namespace Sha.Framework.RabbitMQ
{
    public class RabbitMQSetting
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "RabbitMQ";

        /// <summary>
        /// RabbitMQ IP
        /// </summary>
        public string HostName { get; set; } = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; } = 5672;
    }
}
