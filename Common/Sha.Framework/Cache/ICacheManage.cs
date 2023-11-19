namespace Sha.Framework.Cache
{
    /// <summary>
    /// 缓存管理
    /// </summary>
    public interface ICacheManage
    {
        #region 获取
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string? GetString(string key);

        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string?> GetStringAsync(string key);

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity? Get<TEntity>(string key) where TEntity : class;

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity?> GetAsync<TEntity>(string key) where TEntity : class;

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        bool Exists(string cacheKey);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string key);
        #endregion
    }
}
