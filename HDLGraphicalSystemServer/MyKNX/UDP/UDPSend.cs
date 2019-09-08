using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace HDLGraphicalSystemServer
{
    internal class UDPSend : IDisposable
    {
        public void Dispose()
        {

            GC.Collect();
        }
        private int desPort;//目的端口
        private string desAddress;//目的地址
        private int srcPort;//源端口
        IPEndPoint ipep;
        /// <summary>
        /// UDPsend
        /// </summary>
        internal UDPSend()
        {
            desAddress = "224.0.23.12";
            desPort = 3671;
            ipep = new IPEndPoint(IPAddress.Parse(desAddress), desPort);
        }
        /// <summary>
        /// UDPSend
        /// </summary>
        /// <param name="srcPort">源端口</param>
        internal UDPSend(int srcPort)
        {
            this.srcPort = srcPort;
            desPort = 3671;
            desAddress = "224.0.23.12";
            ipep = new IPEndPoint(IPAddress.Parse(desAddress), desPort);
        }
        /// <summary>
        /// UDPSend
        /// </summary>
        /// <param name="desPort">目的端口</param>
        /// <param name="desAddress">目的地址</param>
        internal UDPSend(int desPort, string desAddress)
        {
            this.desPort = desPort;
            this.desAddress = desAddress;
            srcPort = 3671;
            ipep = new IPEndPoint(IPAddress.Parse(desAddress), desPort);
        }
        /// <summary>
        /// UDPSend
        /// </summary>
        /// <param name="srcPort">源端口</param>
        /// <param name="desPort">目的端口</param>
        /// <param name="desAddress">目的地址</param>
        internal UDPSend(int srcPort, int desPort, string desAddress)
        {
            this.srcPort = srcPort;
            this.desPort = desPort;
            this.desAddress = desAddress;
            ipep = new IPEndPoint(IPAddress.Parse(desAddress), desPort);
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="data"></param>
        public bool Send(byte[] data)
        {
            //using (UdpClient myClient = new UdpClient(srcPort))
            using (UdpClient myClient = new UdpClient())
            {
                try
                {
                    UDPReceive.ClearQueueData();
                    myClient.Send(data, data.Length, ipep);
                    myClient.Close();
                    return true;
                }
                catch
                {
                    myClient.Close();
                    return false;
                }
            }
        }

        /// <summary>
        ///   查找服务器
        /// </summary>
        public bool Sendmore(byte[] data)
        {
            using (UdpClient myClient = new UdpClient(3671))
            {
                try
                {
                    UDPReceive.ClearQueueData();
                    myClient.Send(data, data.Length, ipep);
                    myClient.Close();
                    return true;
                }
                catch
                {
                    myClient.Close();
                    return false;
                }
            }
        }



    }
}
