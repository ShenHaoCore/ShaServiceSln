using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sha.BaseService.Bll;
using Sha.BaseService.Model.DTO;
using Sha.BaseService.Model.Request;
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
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Create([FromBody] AddressCreateRequest request)
        {
            logger.LogDebug($"地址新增请求【{JsonConvert.SerializeObject(request)}】");
            AddressCreateParam param = ConvertTo(request);
            ResultModel<bool> result = bll.Create(param);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public BaseResponse Update([FromBody] AddressUpdateRequest request)
        {
            logger.LogDebug($"地址更新请求【{JsonConvert.SerializeObject(request)}】");
            AddressUpdateParam param = ConvertTo(request);
            ResultModel<bool> result = bll.Update(param);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public BaseResponse Delete([FromQuery] Guid key)
        {
            ResultModel<bool> result = bll.Delete(key);
            if (!result.IsSuccess) { return new BaseResponse(false, result.Code, result.Message); }
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }

        #region 转型
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AddressCreateParam ConvertTo(AddressCreateRequest request)
        {
            AddressCreateParam param = new AddressCreateParam()
            {
                NameCn = request.NameCn,
            };
            return param;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AddressUpdateParam ConvertTo(AddressUpdateRequest request)
        {
            AddressUpdateParam param = new AddressUpdateParam()
            {
                NameCn = request.NameCn,
            };
            return param;
        }
        #endregion
    }
}
