namespace Sha.Framework.Redis
{
    /// <summary>
    /// Redis 配置
    /// </summary>
    public class RedisSetting
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "Redis";

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public List<RedisEndPoint> EndPoints { get; set; } = new List<RedisEndPoint>();

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 超时
        /// </summary>
        public int Timeout { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RedisEndPoint
    {
        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; } = 6379;
    }
}
