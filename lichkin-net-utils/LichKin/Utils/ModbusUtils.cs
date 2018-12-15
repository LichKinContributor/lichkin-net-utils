using System;

namespace LichKin.Utils
{
    /// <summary>
    ///     MODBUS协议工具类
    /// </summary>
    public class ModbusUtils
    {
        /// <summary>
        ///     构造方法私有
        /// </summary>
        private ModbusUtils()
        {
        }

        /// <summary>
        ///     补充校验码
        /// </summary>
        /// <param name="modbusdata">MODUBS协议数据</param>
        /// <param name="crcOnly">是否只返回校验码</param>
        /// <param name="split">每个字节间是否使用空格分割</param>
        /// <returns>
        ///   16进制字符串
        /// </returns>
        public static String CRC(byte[] modbusdata, Boolean crcOnly, Boolean split)
        {
            int num = (int)ushort.MaxValue;
            for (int index1 = 0; index1 < modbusdata.Length; ++index1)
            {
                num ^= (int)modbusdata[index1];
                for (int index2 = 0; index2 < 8; ++index2)
                {
                    if ((num & 1) == 1)
                        num = num >> 1 ^ 40961;
                    else
                        num >>= 1;
                }
            }
            String crc = ((byte)num).ToString("X2") + " " + (num >> 8).ToString("X2"); ; if (crcOnly)
            {
                return crc;
            }
            else { return HexUtils.BytesToHexString(modbusdata, split) + " " + crc; }
        }

        /// <summary>
        ///     补充校验码
        /// </summary>
        /// <param name="address">地址码</param>
        /// <param name="func">功能码</param>
        /// <param name="data">数据</param>
        /// <param name="crcOnly">是否只返回校验码</param>
        /// <param name="split">每个字节间是否使用空格分割</param>
        /// <returns>
        ///   16进制字符串
        /// </returns>
        public static String CRC(String address, String func, String data, Boolean crcOnly, Boolean split)
        {
            return CRC(HexUtils.HexStringToBytes(address + " " + func + " " + data), crcOnly, split);
        }

        /// <summary>
        ///     补充校验码
        /// </summary>
        /// <param name="address">地址码</param>
        /// <param name="func">功能码</param>
        /// <param name="data">数据</param>
        /// <returns>
        ///   16进制字符串
        /// </returns>
        public static String CRC(String address, String func, String data)
        {
            return CRC(HexUtils.HexStringToBytes(address + " " + func + " " + data), false, true);
        }
    }
}
