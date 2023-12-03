using Newtonsoft.Json;
using StackExchange.Redis;

namespace Sha.Framework.Redis
{
    /// <summary>
    /// Redis管理类
    /// </summary>
    public class RedisManage : IRedisManage
    {
        private readonly ILogger<RedisManage> logger;
        private readonly ConnectionMultiplexer connection;
        private readonly IDatabase database;
        private readonly RedisValue token = Environment.MachineName;

        /// <summary>
        /// Redis管理类
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="connection"></param>
        public RedisManage(ILogger<RedisManage> logger, ConnectionMultiplexer connection)
        {
            this.logger = logger;
            this.connection = connection;
            this.database = connection.GetDatabase();
        }

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool Set(string key, string value)
        {
            return database.StringSet(key, value);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public async Task<bool> SetAsync(string key, string value)
        {
            return await database.StringSetAsync(key, value);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        public bool Set(string key, object value, TimeSpan ts)
        {
            if (value == null) { return false; }
            if (value is string stringValue) { return database.StringSet(key, stringValue, ts); }
            if (value is bool boolValue) { return database.StringSet(key, boolValue, ts); }
            if (value is int intValue) { return database.StringSet(key, intValue, ts); }
            return database.StringSet(key, JsonConvert.SerializeObject(value), ts);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        public async Task<bool> SetAsync(string key, object value, TimeSpan ts)
        {
            if (value == null) { return false; }
            if (value is string stringValue) { return await database.StringSetAsync(key, stringValue, ts); }
            if (value is bool boolValue) { return await database.StringSetAsync(key, boolValue, ts); }
            if (value is int intValue) { return await database.StringSetAsync(key, intValue, ts); }
            return await database.StringSetAsync(key, JsonConvert.SerializeObject(value), ts);
        }
        #endregion

        #region 获取
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? GetValue(string key)
        {
            return database.StringGet(key);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string?> GetValueAsync(string key)
        {
            return await database.StringGetAsync(key);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity? Get<TEntity>(string key) where TEntity : class
        {
            var value = database.StringGet(key);
            if (!value.HasValue) { return null; }
            return JsonConvert.DeserializeObject<TEntity>(value!);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<TEntity?> GetAsync<TEntity>(string key) where TEntity : class
        {
            var value = await database.StringGetAsync(key);
            if (!value.HasValue) { return null; }
            return JsonConvert.DeserializeObject<TEntity>(value!);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return database.KeyExists(key);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(string key)
        {
            return await database.KeyExistsAsync(key);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return database.KeyDelete(key);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(string key)
        {
            return await database.KeyDeleteAsync(key);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public long Remove(IEnumerable<string> keys)
        {
            var redisKeys = keys.Select(P => new RedisKey(P)).ToArray();
            return database.KeyDelete(redisKeys);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public async Task<long> RemoveAsync(IEnumerable<string> keys)
        {
            var redisKeys = keys.Select(P => new RedisKey(P)).ToArray();
            return await database.KeyDeleteAsync(redisKeys);
        }
        #endregion

        #region 锁
        /// <summary>
        /// 获取锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public bool LockTake(string key, TimeSpan timeOut)
        {
            return database.LockTake(key, token, timeOut);
        }

        /// <summary>
        /// 获取锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public async Task<bool> LockTakeAsync(string key, TimeSpan timeOut)
        {
            return await database.LockTakeAsync(key, token, timeOut);
        }

        /// <summary>
        /// 获取锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public bool LockTake(string key, string token, TimeSpan timeOut)
        {
            return database.LockTake(key, token, timeOut);
        }

        /// <summary>
        /// 获取锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public async Task<bool> LockTakeAsync(string key, string token, TimeSpan timeOut)
        {
            return await database.LockTakeAsync(key, token, timeOut);
        }

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool LockRelease(string key)
        {
            return database.LockRelease(key, token);
        }

        /// <summary>
        /// 释放锁
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> LockReleaseAsync(string key)
        {
            return await database.LockReleaseAsync(key, token);
        }
        #endregion
    }
}
