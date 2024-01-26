namespace Sha.Framework.Cors
{
    /// <summary>
    /// 跨域设置
    /// </summary>
    public class CorsSetting
    {
        /// <summary>
        /// KEY
        /// </summary>
        public const string KEY = "Cors";

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 是否允许所有
        /// </summary>
        public bool AllowAnyone { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public List<string> Origins { get; set; } = new List<string>();
    }
}
