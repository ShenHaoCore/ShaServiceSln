using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sha.BaseService.Bll;
using Sha.BaseService.Model.DTO;
using Sha.BaseService.Model.Entity;
using Sha.Common.Extension;
using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.BaseService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 地址
    /// </summary>
    [ApiVersion(1.0)]
    public class AddressController : ShaBaseController
    {
        private readonly AddressBll bll;

        /// <summary>
        /// 地址
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="bll">业务逻辑层</param>
        public AddressController(ILogger<AddressController> logger, IMapper mapper, AddressBll bll) : base(logger, mapper)
        {
            this.bll = bll;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_Address> GetByKey([FromQuery] Guid key) => new BaseResponseObject<t_Address>(true, FrameworkEnum.StatusCode.Success, bll.GetByKey(key));

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseObject<t_Address> GetByCode([FromQuery] string code) => new BaseResponseObject<t_Address>(true, FrameworkEnum.StatusCode.Success, bll.GetByCode(code));

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponseList<t_Address> GetByParentKey([FromQuery] Guid key) => new BaseResponseList<t_Address>(true, FrameworkEnum.StatusCode.Success, bll.GetByParentKey(key));

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
