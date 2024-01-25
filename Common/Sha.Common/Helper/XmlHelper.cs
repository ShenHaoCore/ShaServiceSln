using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace Sha.Common.Helper
{
    /// <summary>
    /// XML 帮助类
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            if (obj is null) { return string.Empty; }
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // 使用UTF-8编码和无BOM的XmlWriterSettings
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Encoding = Encoding.UTF8,
                    Indent = true, // 可选的，如果你想要格式化的XML
                    OmitXmlDeclaration = false, // 可选的，如果你想要包含XML声明
                };
                using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
                {
                    xmlSerializer.Serialize(xmlWriter, obj);
                }
                return Encoding.UTF8.GetString(memoryStream.ToArray()); // 将MemoryStream的内容转换为UTF-8字符串
            }
        }
    }
}
