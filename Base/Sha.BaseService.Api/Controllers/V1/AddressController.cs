﻿using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sha.BaseService.Bll;
using Sha.BaseService.Model.DTO;
using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.BaseService.Api.Controllers.V1
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
        /// <param name="mapper">自动映射</param>
        /// <param name="bll">业务逻辑层</param>
        public AddressController(ILogger<AddressController> logger, IMapper mapper, AddressBll bll) : base(logger, mapper)
        {
            this.bll = bll;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Create([FromBody] AddressCreate request)
        {
            logger.LogDebug($"地址新增请求【{JsonConvert.SerializeObject(request)}】");
            ResultModel<bool> result = bll.Create(request);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Update([FromBody] AddressUpdate request)
        {
            logger.LogDebug($"地址更新请求【{JsonConvert.SerializeObject(request)}】");
            ResultModel<bool> result = bll.Update(request);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <response code="200">接口响应成功</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public BaseResponse Delete([FromQuery] Guid key)
        {
            ResultModel<bool> result = bll.Delete(key);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
