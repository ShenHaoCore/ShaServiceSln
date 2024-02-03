using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sha.Business.Storage;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using System.ComponentModel;

namespace Sha.BaseService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 存储
    /// </summary>
    [ApiVersion(1.0)]
    public class StorageController : ShaBaseController
    {
        /// <summary>
        /// 存储
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        public StorageController(ILogger<ShaBaseController> logger, IMapper mapper) : base(logger, mapper) { }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("上传文件")]
        public BaseResponseList<UploadModel> Upload([FromForm] FileUpload request)
        {
            List<UploadModel> uploads = StorageHelper.SaveTemp(request.Files);
            return new BaseResponseList<UploadModel>(true, FrameworkEnum.StatusCode.Success, uploads);
        }
    }
}
