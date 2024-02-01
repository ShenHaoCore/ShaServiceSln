namespace Sha.Framework.Helper
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static string TempDirectory => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Temp/{DateTime.Now:yyyy-MM-dd}");

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="path">文件地址(带文件名&后缀名)</param>
        public static void Save(IFormFile file, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create)) { file.CopyTo(stream); }
        }

        /// <summary>
        /// 临时保存
        /// </summary>
        /// <param name="file">文件</param>
        public static string TempSave(IFormFile file)
        {
            string dir = TempDirectory;
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
            string ext = Path.GetExtension(file.FileName); // 文件后缀
            string name = Guid.NewGuid().ToString("N"); // 自定义文件名
            var path = $"{dir}/{name}{ext}";
            Save(file, path);
            return path;
        }
    }
}
