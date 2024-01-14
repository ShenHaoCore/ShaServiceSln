using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sha.BaseService.Bll.Common;
using Sha.BaseService.Dal;
using Sha.BaseService.Model.DTO;
using Sha.BaseService.Model.Entity;
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
        /// <param name="dal"></param>
        public AddressBll(ILogger<AddressBll> logger, AddressDal dal) : base(logger)
        {
            this.dal = dal;
        }

        #region 方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<t_Address> GetByParentKey(Guid key) => dal.GetByParentKey(key);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public ResultModel<bool> Create(AddressCreateParam param)
        {
            logger.LogDebug($"地址新增参数【{JsonConvert.SerializeObject(param)}】");
            t_Address address = ConvertTo(param);
            if (!this.dal.Create(address)) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<bool>(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public ResultModel<bool> Update(AddressUpdateParam param)
        {
            logger.LogDebug($"地址更新参数【{JsonConvert.SerializeObject(param)}】");
            t_Address address = ConvertTo(param);
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

        #region 转型
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private t_Address ConvertTo(AddressCreateParam param)
        {
            t_Address address = new t_Address()
            {
                Key = Guid.NewGuid(),
                Code = param.Code,
                Number = param.Number,
                NameCn = param.NameCn,
                NameEn = param.NameEn,
                ShortName = param.ShortName,
                ParentKey = param.ParentKey,
                Type = param.Type,
                Sort = param.Sort,
                IsDelete = false,
                CreateTime = DateTime.Now
            };
            return address;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private t_Address ConvertTo(AddressUpdateParam param)
        {
            t_Address address = new t_Address()
            {
                Key = param.Key,
                Code = param.Code,
                Number = param.Number,
                NameCn = param.NameCn,
                NameEn = param.NameEn,
                ShortName = param.ShortName,
                ParentKey = param.ParentKey,
                Type = param.Type,
                Sort = param.Sort,
                IsDelete = param.IsDelete,
                CreateTime = DateTime.Now
            };
            return address;
        }
        #endregion
    }
}
