using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sha.BaseService.Bll;
using Sha.BaseService.Model.DTO;
using Sha.BaseService.Model.Request;
using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.BaseService.ApiBehand.Controllers.V2
{
    /// <summary>
    /// 地址
    /// </summary>
    [ApiVersion(2.0)]
    public class AddressController : ShaBaseController
    {
        private readonly ILogger<AddressController> logger;
        private readonly AddressBll bll;

        /// <summary>
        /// 地址
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="bll"></param>
        public AddressController(ILogger<AddressController> logger, AddressBll bll)
        {
            this.logger = logger;
            this.bll = bll;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Create([FromBody] AddressCreateRequest request)
        {
            logger.LogDebug($"身份证新增请求【{JsonConvert.SerializeObject(request)}】");
            AddressCreateParam param = new AddressCreateParam();
            ResultModel<bool> result = bll.Create(param);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
