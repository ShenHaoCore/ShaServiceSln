using Microsoft.AspNetCore.Http;

namespace Sha.BaseService.Model.DTO
{
    /// <summary>
    /// 上传
    /// </summary>
    public class UploadModel
    {
        /// <summary>
        /// 
        /// </summary>
        public required List<IFormFile> Files { get; set; }

        /// <summary>
        /// 是否临时文件
        /// </summary>
        public bool IsTemp { get; set; }
    }
}
