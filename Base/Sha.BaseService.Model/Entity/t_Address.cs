using SqlSugar;

namespace Sha.BaseService.Model.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class t_Address
    {
        /// <summary>
        /// 
        /// </summary>
        public t_Address()
        {
            this.Code = string.Empty;
            this.Number = string.Empty;
            this.NameCn = string.Empty;
            this.NameEn = string.Empty;
            this.ShortName = string.Empty;
        }

        /// <summary>
        /// 主键KEY
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public System.Guid Key { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public System.String Code { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public System.String Number { get; set; }

        /// <summary>
        /// 中文名
        /// </summary>
        public System.String NameCn { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        public System.String NameEn { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public System.String ShortName { get; set; }

        /// <summary>
        /// 父级KEY
        /// </summary>
        public System.Guid ParentKey { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public System.Int32 Type { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public System.Int32 Sort { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public System.Boolean IsDelete { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
    }
}
