using System;
using System.IO;
using System.Text;

namespace LichKin.Utils
{
    /// <summary>
    ///     文件读取工具类
    /// </summary>
    public class FileReader
    {
        /// <summary>
        ///     读取文件内容
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>
        ///   文件内容
        /// </returns>
        public static String Read(String fileName)
        {
            String content;
            using (StreamReader sr = new StreamReader(fileName, Encoding.UTF8))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }
    }
}
