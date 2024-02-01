using AutoMapper;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Sha.BaseService.Bll.Common;
using Sha.BaseService.Dal;
using Sha.BaseService.Model.DTO;
using Sha.BaseService.Model.Entity;
using Sha.Common.Extension;
using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.BaseService.Bll
{
    /// <summary>
    /// 地址
    /// </summary>
    public class AddressBll : BaseServiceBll
    {
        private readonly AddressDal dal;

        /// <summary>
        /// 地址
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="dal"></param>
        public AddressBll(ILogger<AddressBll> logger, IMapper mapper, AddressDal dal) : base(logger, mapper)
        {
            this.dal = dal;
        }

        #region 方法
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public t_Address GetByKey(Guid key) => dal.GetByKey(key);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public t_Address GetByCode(string code) => dal.GetByCode(code);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<t_Address> GetByParentKey(Guid key) => dal.GetByParentKey(key);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<bool> Create(AddressCreate paramObj)
        {
            logger.LogDebug($"地址新增参数【{paramObj.ToJson()}】");
            AddressCreateValidator validator = new AddressCreateValidator();
            ValidationResult validResult = validator.Validate(paramObj);
            if (!validResult.IsValid) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.ValidateFail); }
            t_Address address = mapper.Map<t_Address>(paramObj);
            if (!this.dal.Create(address)) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<bool>(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="paramObj"></param>
        /// <returns></returns>
        public ResultModel<bool> Update(AddressUpdate paramObj)
        {
            logger.LogDebug($"地址更新参数【{paramObj.ToJson()}】");
            AddressUpdateValidator validator = new AddressUpdateValidator();
            ValidationResult validResult = validator.Validate(paramObj);
            if (!validResult.IsValid) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.ValidateFail); }
            t_Address address = mapper.Map<t_Address>(paramObj);
            if (!this.dal.Update(address)) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<bool>(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ResultModel<bool> Delete(Guid key)
        {
            if (!this.dal.Delete(key)) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<bool>(true, FrameworkEnum.StatusCode.Success);
        }
        #endregion
    }
}
