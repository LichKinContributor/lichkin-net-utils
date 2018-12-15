using System;
using System.Text;

namespace LichKin.Utils
{
    /// <summary>
    ///     16进制工具类
    /// </summary>
    public class HexUtils
    {
        /// <summary>
        ///     字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="split">每个字节间是否使用空格分割</param>
        /// <returns>
        ///   键值对16进制字符串
        /// </returns>
        public static string BytesToHexString(byte[] bytes, Boolean split)
        {
            StringBuilder sb = new StringBuilder(bytes.Length);
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("X2"));
                if (split)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        ///     16进制字符串转字节数组
        /// </summary>
        /// <param name="hexString">16进制字符串</param>
        /// <returns>
        ///   字节数组
        /// </returns>
        public static byte[] HexStringToBytes(String hexString)
        {
            hexString = hexString.Replace(" ", "");
            int byteLength = hexString.Length / 2;
            byte[] bytes = new byte[byteLength];
            for (int i = 0; i < byteLength; i++)
            {
                byte.TryParse(hexString.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber, null, out bytes[i]);
            }
            return bytes;
        }
    }
}
