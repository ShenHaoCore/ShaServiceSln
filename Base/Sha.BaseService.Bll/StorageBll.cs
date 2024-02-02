using AutoMapper;
using Microsoft.Extensions.Logging;
using Sha.BaseService.Bll.Common;
using Sha.BaseService.Model.DTO;
using Sha.Business.Storage;
using Sha.Framework.Base;
using Sha.Framework.Enum;

namespace Sha.BaseService.Bll
{
    /// <summary>
    /// 文件
    /// </summary>
    public class StorageBll : BaseServiceBll
    {
        /// <summary>
        /// 文件
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="mapper">映射</param>
        public StorageBll(ILogger<BaseServiceBll> logger, IMapper mapper) : base(logger, mapper) { }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="paramObj"></param>
        public ResultModel<List<Upload>> Upload(FileUpload paramObj)
        {
        }

        public void BatchTempSave()
        {
            
        }

        /// <summary>
        /// 下载
        /// </summary>
        public void Download()
        {

        }
    }
}
