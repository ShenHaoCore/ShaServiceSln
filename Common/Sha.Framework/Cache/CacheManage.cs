using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace Sha.Framework.Cache
{
    /// <summary>
    /// 缓存管理
    /// </summary>
    public class CacheManage : ICacheManage
    {
        private readonly IDistributedCache cache;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cache"></param>
        public CacheManage(IDistributedCache cache)
        {
            this.cache = cache;
        }

        #region 获取
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? GetString(string key)
        {
            return cache.GetString(key);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string?> GetStringAsync(string key)
        {
            return await cache.GetStringAsync(key);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity? Get<TEntity>(string key) where TEntity : class
        {
            var value = cache.Get(key);
            if (value is null) { return null; }
            return JsonConvert.DeserializeObject<TEntity>(Encoding.UTF8.GetString(value));
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetAsync<TEntity>(string key) where TEntity : class
        {
            var value = await cache.GetAsync(key);
            if (value is null) { return null; }
            return JsonConvert.DeserializeObject<TEntity>(Encoding.UTF8.GetString(value));
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return cache.Get(key) is not null;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(string key)
        {
            return await cache.GetAsync(key) is not null;
        }
        #endregion
    }
}
