namespace Sha.Framework.Base
{
    /// <summary>
    /// 
    /// </summary>
    public class ShaServiceBll : IShaServiceBll
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly ILogger<ShaServiceBll> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public ShaServiceBll(ILogger<ShaServiceBll> logger)
        {
            this.logger = logger;
        }
    }
}
