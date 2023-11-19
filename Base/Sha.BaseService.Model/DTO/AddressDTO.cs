namespace Sha.BaseService.Model.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressCreateParam
    {
        /// <summary>
        /// 
        /// </summary>
        public AddressCreateParam()
        {
            this.Code = string.Empty;
            this.Number = string.Empty;
            this.NameCn = string.Empty;
            this.NameEn = string.Empty;
            this.ShortName = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NameCn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid ParentKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDelete { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AddressUpdateParam
    {
        /// <summary>
        /// 
        /// </summary>
        public AddressUpdateParam()
        {
            this.Code = string.Empty;
            this.Number = string.Empty;
            this.NameCn = string.Empty;
            this.NameEn = string.Empty;
            this.ShortName = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NameCn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid ParentKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
