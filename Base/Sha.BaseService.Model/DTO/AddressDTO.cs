using FluentValidation;
using System.ComponentModel;

namespace Sha.BaseService.Model.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class AddressCreate
    {
        /// <summary>
        /// 
        /// </summary>
        public AddressCreate()
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
        [DefaultValue("")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string NameCn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string NameEn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
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
    /// 地址验证
    /// </summary>
    public class AddressCreateValidator : AbstractValidator<AddressCreate>
    {
        /// <summary>
        /// 地址验证
        /// </summary>
        public AddressCreateValidator()
        {
            RuleFor(it => it.Number).NotEmpty().WithMessage("{PropertyName}不能为空").WithName("编号");
            RuleFor(it => it.NameCn).NotEmpty().WithMessage("{PropertyName}不能为空").WithName("中文名");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AddressUpdate
    {
        /// <summary>
        /// 
        /// </summary>
        public AddressUpdate()
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
        [DefaultValue("")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string Number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string NameCn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
        public string NameEn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue("")]
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
    /// 地址验证
    /// </summary>
    public class AddressUpdateValidator : AbstractValidator<AddressUpdate>
    {
        /// <summary>
        /// 地址验证
        /// </summary>
        public AddressUpdateValidator()
        {
            RuleFor(it => it.Number).NotEmpty().WithMessage("{PropertyName}不能为空").WithName("编号");
            RuleFor(it => it.NameCn).NotEmpty().WithMessage("{PropertyName}不能为空").WithName("中文名");
        }
    }
}
