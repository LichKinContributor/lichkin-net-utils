using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LichKin.Utils
{
    /// <summary>
    ///     JSON文件工具类
    /// </summary>
    public class JSONFileReader
    {
        /// <summary>
        ///     读取JSON文件内容（单个）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>
        ///   键值对
        /// </returns>
        public static Dictionary<String, String> Read(String fileName)
        {
            return JsonConvert.DeserializeObject<Dictionary<String, String>>(FileReader.Read(fileName).Trim());
        }

        /// <summary>
        ///     读取JSON文件内容（列表）
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>
        ///   键值对列表
        /// </returns>
        public static List<Dictionary<String, String>> ReadArray(String fileName)
        {
            return JsonConvert.DeserializeObject<List<Dictionary<String, String>>>(FileReader.Read(fileName).Trim());
        }
    }
}
