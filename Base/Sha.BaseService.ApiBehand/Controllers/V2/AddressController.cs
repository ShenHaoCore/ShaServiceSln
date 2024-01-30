using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sha.BaseService.Bll;
using Sha.BaseService.Model.DTO;
using Sha.Common.Extension;
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
        private readonly AddressBll bll;

        /// <summary>
        /// 地址
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">自动映射</param>
        /// <param name="bll">业务逻辑层</param>
        public AddressController(ILogger<AddressController> logger, IMapper mapper, AddressBll bll) : base(logger, mapper)
        {
            this.bll = bll;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Create([FromBody] AddressCreate request)
        {
            logger.LogDebug($"地址新增请求【{request.ToJson()}】");
            ResultModel<bool> result = bll.Create(request);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
