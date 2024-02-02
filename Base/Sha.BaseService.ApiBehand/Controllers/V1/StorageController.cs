using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sha.BaseService.Bll;
using Sha.Business.Storage;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using System.ComponentModel;

namespace Sha.BaseService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 文件
    /// </summary>
    [ApiVersion(1.0)]
    public class StorageController : ShaBaseController
    {
        private readonly StorageBll bll;

        /// <summary>
        /// 文件
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="bll">业务逻辑层</param>
        public StorageController(ILogger<ShaBaseController> logger, IMapper mapper, StorageBll bll) : base(logger, mapper)
        {
            this.bll = bll;
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("上传文件")]
        public BaseResponseList<UploadModel> Upload([FromForm] FileUpload request)
        {
            return new BaseResponseList<UploadModel>(true, FrameworkEnum.StatusCode.Success, StorageHelper.TempSave(request.Files));
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("下载文件")]
        public BaseResponse Download()
        {
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
