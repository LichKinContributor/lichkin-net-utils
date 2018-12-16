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
        ///     16进制字符串
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
            String crc = ((byte)num).ToString("X2") + (split ? " " : "") + (num >> 8).ToString("X2");
            if (crcOnly)
            {
                return crc;
            }
            else
            {
                return HexUtils.BytesToHexString(modbusdata, split) + " " + crc;
            }
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
        ///     16进制字符串
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
        ///     16进制字符串
        /// </returns>
        public static String CRC(String address, String func, String data)
        {
            return CRC(HexUtils.HexStringToBytes(address + " " + func + " " + data), false, true);
        }

        /// <summary>
        ///     验证是否为完整指令
        ///     目前已知
        ///         1、MODBUS协议下地址码为8位。
        ///         2、MODBUS协议下功能码为8位。
        ///         3、MODBUS协议下采用的是CRC16，CRC补充码为16位。
        ///     因而实现逻辑如下
        ///         1、整个指令长度必然要大于等于5个字节。
        ///         2、排除最后两个字节后做CRC运算，结果应与最后两个字节一致。
        /// </summary>
        /// <param name="cmd">指令</param>
        /// <returns>
        ///     true  : 指令完整;
        ///     false : 指令不完整;
        /// </returns>
        public static Boolean IsFullCmd(String cmd)
        {
            String[] cmds = cmd.Split(' ');
            if (cmds.Length < 5)
            {
                return false;
            }
            String address = cmds[0];// 地址码
            String func = cmds[1];// 功能码
            String data = "";// 数据
            for (int i = 2; i < cmds.Length - 2; i++)
            {
                data += " " + cmds[i];
            }
            return (cmds[cmds.Length - 2] + cmds[cmds.Length - 1]).Equals(CRC(address, func, data, true, false));
        }
    }
}
