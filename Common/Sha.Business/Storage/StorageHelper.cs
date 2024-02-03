using Microsoft.AspNetCore.Http;

namespace Sha.Business.Storage
{
    /// <summary>
    /// 存储帮助类
    /// </summary>
    public class StorageHelper
    {
        /// <summary>
        /// 临时文件目录
        /// </summary>
        public static string TempDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Temp/{DateTime.Now:yyyy-MM-dd}");

        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public FileStream GetFileStream(IFormFile file)
        {
            string path = GetTempPath(file);
            using (FileStream stream = new FileStream(path, FileMode.Create)) { file.CopyTo(stream); }
            FileStream fileStream = new FileStream(path, FileMode.Open);
            File.Delete(path);
            return fileStream;
        }

        /// <summary>
        /// 获取临时临时路径
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetTempPath(IFormFile file)
        {
            string dire = TempDirectory;
            if (!Directory.Exists(dire)) { Directory.CreateDirectory(dire); }
            return $"{dire}/{Guid.NewGuid():N}{Path.GetExtension(file.FileName)}";
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="path">文件路径</param>
        public static void Save(IFormFile file, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create)) { file.CopyTo(stream); }
        }

        /// <summary>
        /// 保存到临时目录
        /// </summary>
        /// <param name="file">文件</param>
        public static string SaveTemp(IFormFile file)
        {
            string path = GetTempPath(file);
            Save(file, path);
            return path;
        }

        /// <summary>
        /// 保存到临时目录
        /// </summary>
        /// <param name="upload">上传</param>
        public static void SaveTemp(UploadModel upload)
        {
            upload.Path = SaveTemp(upload.File);
        }

        /// <summary>
        /// 保存到临时目录
        /// </summary>
        /// <param name="files">文件</param>
        public static List<UploadModel> SaveTemp(List<IFormFile> files)
        {
            List<UploadModel> uploads = files.Select(file => new UploadModel() { File = file, Path = string.Empty }).ToList();
            Parallel.ForEach(uploads, SaveTemp);
            return uploads;
        }
    }
}
