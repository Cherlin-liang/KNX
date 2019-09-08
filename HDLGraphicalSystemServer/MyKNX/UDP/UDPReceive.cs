using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace HDLGraphicalSystemServer
{
    internal class UDPReceive : IDisposable
    {
        public static Socket hjSocket;	//socket实例
        public void Dispose()
        {
            try
            {
                receiveQueue.Clear();
            }
            catch
            {

            }
        }
        private static Queue<byte[]> receiveQueue = new Queue<byte[]>();
        public static void OnReceive(byte[] receiveData)
        {
            receiveQueue.Enqueue(receiveData);
        }
        public static void ClearQueueData()
        {
            receiveQueue.Clear();
        }
        /// <summary>
        /// 在指定的2000毫秒内读取一条数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>true：接收成功，false：接收失败</returns>
        public static bool Receive(ref byte[] data, int receiveAddress, int type)
        {
            return Receive(ref data, 2000, receiveAddress, type);
        }
        /// <summary>
        /// 在指定的时间内读取一条数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="timeOut">指定的时间，单位为毫秒</param>
        /// <returns>true：接收成功，false：接收失败</returns>
        public static bool Receive(ref byte[] data, int timeOut, int receiveAddress, int type)
        {
            int timeSleep = 30;
            byte[] readData = null;
            for (int i = 0; ; i++)
            {
                readData = null;
                if (i * timeSleep > timeOut) break;

                try
                {
                    if (receiveQueue.Count > 0)
                    {
                        readData = receiveQueue.Dequeue();
                    }
                    else
                    {
                        readData = null;
                    }

                    if (readData != null)
                    {
                        if (type == 0)
                        {
                            if (readData[12] * 256 + readData[13] == receiveAddress && readData[14] == 1)
                            {
                                data = readData;
                                return true;
                            }
                        }
                        else if (type == 2)
                        {
                            if (readData[12] * 256 + readData[13] == receiveAddress && readData[14] == 3)
                            {
                                data = readData;
                                return true;
                            }
                        }
                    }
                }
                catch
                {
                    readData = null;
                }
                Thread.Sleep(30);
            }
            return false;

        }

    }
}
