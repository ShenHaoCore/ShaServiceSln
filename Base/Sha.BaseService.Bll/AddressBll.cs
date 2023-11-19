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
        private readonly ILogger<AddressBll> logger;
        private readonly AddressDal dal;

        /// <summary>
        /// 地址
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dal"></param>
        public AddressBll(ILogger<AddressBll> logger, AddressDal dal)
        {
            this.logger = logger;
            this.dal = dal;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public ResultModel<bool> Create(AddressCreateParam param)
        {
            logger.LogDebug($"地址新增参数【{JsonConvert.SerializeObject(param)}】");
            t_Address address = ConvertFrom(param);
            if (!this.dal.Create(address)) { return new ResultModel<bool>(false, FrameworkEnum.StatusCode.Fail); }
            return new ResultModel<bool>(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private t_Address ConvertFrom(AddressCreateParam param)
        {
            t_Address address = new t_Address();
            address.NameCn = param.NameCn;
            return address;
        }
    }
}
