using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sha.BaseService.Bll.Common;
using Sha.BaseService.Model.DTO;
using Sha.Framework.Helper;

namespace Sha.BaseService.Bll
{
    /// <summary>
    /// 文件
    /// </summary>
    public class FileBll : BaseServiceBll
    {
        /// <summary>
        /// 文件
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        public FileBll(ILogger<BaseServiceBll> logger, IMapper mapper) : base(logger, mapper) { }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="paramObj"></param>
        public void Upload(UploadModel paramObj)
        {
            foreach (IFormFile file in paramObj.Files)
            {
                string path = FileHelper.TempSave(file);
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        public void Download()
        {

        }
    }
}
