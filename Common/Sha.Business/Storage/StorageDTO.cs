﻿using Microsoft.AspNetCore.Http;

namespace Sha.Business.Storage
{
    /// <summary>
    /// 上传
    /// </summary>
    public class FileUpload
    {
        /// <summary>
        /// 文件
        /// </summary>
        public required List<IFormFile> Files { get; set; }

        /// <summary>
        /// 是否临时文件
        /// </summary>
        public bool IsTemp { get; set; } = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public class UploadModel
    {
        /// <summary>
        /// 文件
        /// </summary>
        public required IFormFile File { get; set; }

        /// <summary>
        /// 保存路径
        /// </summary>
        public string Path { get; set; } = string.Empty;
    }
}
