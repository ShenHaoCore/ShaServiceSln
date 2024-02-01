using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sha.BaseService.Bll;
using Sha.BaseService.Model.DTO;
using Sha.Framework.Base;
using Sha.Framework.Enum;
using Sha.Framework.Swagger;
using System.ComponentModel;

namespace Sha.BaseService.ApiBehand.Controllers.V1
{
    /// <summary>
    /// 文件
    /// </summary>
    [ApiVersion(1.0)]
    public class FileController : ShaBaseController
    {
        private readonly FileBll bll;

        /// <summary>
        /// 文件
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        /// <param name="bll">业务逻辑层</param>
        public FileController(ILogger<ShaBaseController> logger, IMapper mapper, FileBll bll) : base(logger, mapper)
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
        public BaseResponse Upload([FromForm] UploadModel request)
        {
            bll.Upload(request);
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("下载文件")]
        public BaseResponse Download()
        {
            bll.Download();
            return new BaseResponse(true, FrameworkEnum.StatusCode.Success);
        }
    }
}
