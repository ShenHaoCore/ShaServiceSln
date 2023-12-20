using EasyNetQ;

namespace Sha.Business.Queue
{
    /// <summary>
    /// 
    /// </summary>
    [Queue("Sha.TestMessagge", ExchangeName = "Sha.TestMessagge")]
    public class TestMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
