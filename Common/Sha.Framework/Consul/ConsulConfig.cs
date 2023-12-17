namespace Sha.Framework.Consul
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsulConfig
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "Consul";

        /// <summary>
        /// Consul 客户端地址
        /// </summary>
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 健康检查地址
        /// </summary>
        public string HealthCheck { get; set; } = string.Empty;

        /// <summary>
        /// 服务名
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 服务绑定IP
        /// </summary>
        public string IP { get; set; } = string.Empty;

        /// <summary>
        /// 服务绑定端口
        /// </summary>
        public int Port { get; set; }
    }
}
