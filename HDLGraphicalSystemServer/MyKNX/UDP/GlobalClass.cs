﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;

namespace HDLGraphicalSystemServer
{
    /// <summary>
    /// 全局调用的类
    /// </summary>
    internal sealed class GlobalClass
    {
        public static bool IsDownloadReturn = false;

        /// <summary>
        /// 延时
        /// </summary>
        /// <param name="times">次数</param>
        /// <returns></returns>
        public static void minSleepTime(int times)
        {
            int resendtimes = 0;
            DateTime d1;
            DateTime d2;
            d1 = DateTime.Now;
            d2 = DateTime.Now;
            for (int i = 0; ; i++)
            {
                d2 = DateTime.Now;
                if (((d2.Second - d1.Second) > 1) || ((d1.Second - d2.Second) > 1))
                {
                    resendtimes = resendtimes + 1;
                    if (resendtimes >= times) break;
                }
            }
        }



        /// <summary>
        /// 在数据前补充0至指定长度
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <param name="length">指定长度</param>
        /// <returns></returns>
        public static string AddLeftZero(string data, int length)
        {
            while (data.Length < length)
            {
                data = "0" + data;
            }
            if (data.Length > length)
            {
                data = data.Substring(0, length);
            }
            return data;
        }
        /// <summary>
        /// 在数据后补充0至指定长度
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <param name="length">指定长度</param>
        /// <returns></returns>
        public static string AddRightZero(string data, int length)
        {
            if (data.Length % 2 != 0)
            {
                data = "0" + data;
            }
            while (data.Length < length)
            {
                data += "0";
            }
            if (data.Length > length)
            {
                data = data.Substring(0, length);
            }
            return data;
        }
        /// <summary>
        /// 将IP地址转换成16进制
        /// </summary>
        /// <param name="ipadd">ip地址</param>
        /// <returns></returns>
        public static string IPaddToHex(string ipadd)
        {
            string temp = "";
            string[] ad = ipadd.Split('.');
            temp += AddLeftZero((Convert.ToByte(ad[0])).ToString("X"), 2);
            temp += AddLeftZero((Convert.ToByte(ad[1])).ToString("X"), 2);
            temp += AddLeftZero((Convert.ToByte(ad[2])).ToString("X"), 2);
            temp += AddLeftZero((Convert.ToByte(ad[3])).ToString("X"), 2);
            return temp;
        }
        /// <summary>
        /// 将字节数组转换为ip地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteToIPadd(byte[] data)
        {
            string temp = "";
            temp += Convert.ToInt32(data[0]).ToString() + ".";
            temp += Convert.ToInt32(data[1]).ToString() + ".";
            temp += Convert.ToInt32(data[2]).ToString() + ".";
            temp += Convert.ToInt32(data[3]).ToString();
            return temp;
        }
        /// <summary>
        /// 16进制转换为ip地址
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HexToIPadd(string data)
        {
            byte[] temp = HexToByte(data);
            return ByteToIPadd(temp);
        }
        /// <summary>
        /// 16进制转字节数组
        /// </summary>
        /// <param name="hexStr">16进制数</param>
        public static byte[] HexToByte(string hexStr)
        {

            hexStr = System.Text.RegularExpressions.Regex.Replace(
                hexStr, @"[\n\r]", "");
            hexStr = hexStr.Replace(" ", "");
            if ((hexStr.Length % 2) != 0)
                hexStr += " ";//空格
            byte[] bytes = new byte[hexStr.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexStr.Substring(i * 2, 2), 16);

            }
            return bytes;
        }
        /// <summary>
        /// 字符串转16进制
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string StrToHex(string data)
        {
            byte[] temp = Encoding.Default.GetBytes(data);
            return ByteToHex(temp);
        }
        /// <summary>
        /// 字节转16进制
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ByteToHex(byte[] data, int startIndex, int length)
        {
            string result = "";
            for (int i = startIndex; i < startIndex + length; i++)
            {
                if (data[i].ToString("X").Length < 2)
                {
                    result += "0" + data[i].ToString("X");
                }
                else
                {
                    result += data[i].ToString("X");
                }
            }
            return result;

        }
        /// <summary>
        /// 字节转16进制
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ByteToHex(byte[] data, int length)
        {
            return ByteToHex(data, 0, length);
        }
        /// <summary>
        /// Byte转String
        /// </summary>
        /// <param name="data"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] data, string value)
        {
            string result = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < 16)
                {
                    result += "0" + data[i].ToString("X") + value;
                }
                else
                {
                    result += data[i].ToString("X") + value;
                }
            }
            return result;
        }
        /// <summary>
        /// 字节转16进制
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ByteToHex(byte[] data)
        {
            return ByteToHex(data, 0, data.Length);
        }
        /// <summary>
        /// 字节数组转int
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="length">字节长度</param>
        /// <returns></returns>
        public static int ByteToInt32(byte[] data, int startIndex, int length)
        {
            byte[] da = new byte[length];
            for (int i = 0; i < length; i++)
            {
                da[i] = data[startIndex + i];
            }
            data = da;
            byte[] change = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                change[i] = data[data.Length - i - 1];
            }
            data = change;
            byte[] temp = new byte[4];
            if (data.Length < 4)
            {
                //int i;
                //for (i=0; i < data.Length; i++)
                //{
                //    temp[3 - i] = data[data.Length - i - 1];
                //}
                //for (int j = 0; j < 4 - data.Length; j++)
                //{
                //    temp[j] = 0;
                //}
                for (int i = 0; i < data.Length; i++)
                {
                    temp[i] = data[i];
                }
                for (int i = data.Length; i < 4; i++)
                {
                    temp[i] = 0;
                }

            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    temp[i] = data[i];
                }
            }

            return System.BitConverter.ToInt32(temp, 0);
        }
        /// <summary>
        /// 字节数组转int
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <param name="startIndex">开始未知</param>
        /// <returns></returns>
        public static int ByteToInt32(byte[] data, int startIndex)
        {
            int length = data.Length - startIndex - 1;
            return ByteToInt32(data, startIndex, length);
        }
        /// <summary>
        /// 字节数组转int
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <returns></returns>
        public static int ByteToInt32(byte[] data)
        {
            return ByteToInt32(data, 0, data.Length);
        }
        /// <summary>
        /// 从字节数组中提取出一段组成一个新的数组
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static byte[] ByteToByte(byte[] data, int startIndex, int length)
        {
            byte[] myData = new byte[length];
            for (int i = 0; i < length; i++)
            {
                myData[i] = data[i + startIndex];
            }
            return myData;
        }
        /// <summary>
        /// 从字节数组中提取出一段组成一个新的数组
        /// </summary>
        /// <param name="data">数组</param>
        /// <param name="startIndex">开始位置</param>
        /// <returns></returns>
        public static byte[] ByteToByte(byte[] data, int startIndex)
        {
            return ByteToByte(data, startIndex, data.Length - startIndex);
        }

        static string tempk = "";
        /// <summary>
        /// 把int转换为bit
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string IntToBit(int data, int length)
        {

            //if (data == 0 || data == 1)
            //{
            //    string _temp = tempk;
            //    tempk = "";
            //    return AddLeftZero(data.ToString() + _temp, length);
            //}
            //else
            //{
            //    tempk = (data % 2).ToString() + tempk;
            //    return IntToBit(data / 2, length);
            //}
            string va = AddLeftZero(Convert.ToString(data, 2), length);
            return va;
        }


        /// <summary>
        /// 将bit转换为int
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int BitToInt(string data)
        {
            return Convert.ToInt32(data, 2);
        }


        /// <summary>
        /// 获取本机的IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            string IPAddress = "";
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in
                        ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            IPAddress = ip.Address.ToString();
                        }
                    }
                }
            }
            return IPAddress;
            // Receive.LocalIPAddress = "";
            // UDPSend send = new UDPSend(3671, "224.0.23.11");
            // send.Send(new byte[] { 1, 0 });
            //// Thread.Sleep(50);
            // if (Receive.LocalIPAddress != "")
            // {
            //     return Receive.LocalIPAddress;
            // }
            // else
            // {
            //     return "127.0.0.1";
            // }
        }

        /// <summary>
        /// 判断物理地址格式是否正确
        /// </summary>
        public static bool CheckPhAddress(string phAddress, ref int phAdd)
        {
            string patt = @"^([0-9]|0[0-9]|1[0-5])\.([0-9]|0[0-9]|1[0-5])\.(\d{1,2}|[0-1]\d{2}|2[0-5]{2})$";
            if (!Regex.IsMatch(phAddress, patt))
            {
                return false;
            }
            else
            {
                string[] value = phAddress.Split('.');
                phAdd = Convert.ToInt32((int.Parse(value[0]).ToString("X") + int.Parse(value[1]).ToString("X") +
                        AddLeftZero(int.Parse(value[2]).ToString("X"), 2)), 16);
                return true;
            }
        }
        /// <summary>
        /// 判断组地址是否正确
        /// </summary>
        /// <returns></returns>
        public static bool CheckGrAddress(string grAddress)
        {
            string[] value = grAddress.Split('/');
            if (value.Length != 3)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    int outValue = 0;
                    if (int.TryParse(value[i], out outValue))
                    {
                        if (i == 0)
                        {
                            if (outValue > 15 || outValue < 0)
                            {
                                return false;
                            }
                        }
                        else if (i == 1)
                        {
                            if (outValue > 7 || outValue < 0)
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (outValue > 255 || outValue < 0)
                            {
                                return false;
                            }
                        }

                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        /// <summary>
        /// 判断IP地址是否正确
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool CheckIpAddress(string value)
        {
            string patt = @"^(\d{1,2}|[0-1]\d{2}|2[0-5]{2})\.(\d{1,2}|[0-1]\d{2}|2[0-5]{2})\.(\d{1,2}|[0-1]\d{2}|2[0-5]{2})\.(\d{1,2}|[0-1]\d{2}|2[0-5]{2})$";
            if (!Regex.IsMatch(value, patt))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str">需分割的字符串</param>
        /// <param name="getWitch">取分割后的第几个字符串</param>
        /// <param name="strSerepater">分隔符</param>
        /// <returns></returns>
        public static string ResolveString(string str, int getWitch,
            string strSerepater)
        {
            string[] temp = Regex.Split(str, strSerepater);
            if (getWitch > temp.Length || getWitch <= 0)
            {
                return "";
            }
            else
            {
                return temp[getWitch - 1];
            }
        }

        /// <summary>
        /// 判断是不是数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            bool tf = false;
            if (str != null && Regex.IsMatch(str, @"^\d+$"))
                tf = true;
            else
                tf = false;
            return tf;
        }

    }
}
