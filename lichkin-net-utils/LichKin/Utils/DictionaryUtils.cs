using System;
using System.Collections.Generic;

namespace LichKin.Utils
{
    /// <summary>
    ///     字典工具类
    /// </summary>
    public class DictionaryUtils
    {
        /// <summary>
        ///     从字典中取对应键的值
        /// </summary>
        /// <param name="dictionary">字典</param>
        /// <param name="key">键</param>
        /// <returns>
        ///   值
        /// </returns>
        public static String GetString(Dictionary<String, String> dictionary, String key)
        {
            String str;
            dictionary.TryGetValue(key, out str);
            return str;
        }

        /// <summary>
        ///     从字典中取对应键的值
        /// </summary>
        /// <param name="dictionary">字典</param>
        /// <param name="key">键</param>
        /// <returns>
        ///   值
        /// </returns>
        public static Boolean GetBool(Dictionary<String, Boolean> dictionary, String key)
        {
            Boolean boolean;
            dictionary.TryGetValue(key, out boolean);
            return boolean;
        }
    }
}
