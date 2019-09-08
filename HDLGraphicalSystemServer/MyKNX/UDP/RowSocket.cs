using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;

namespace HDLGraphicalSystemServer
{

    public class PacketArrivedEventArgs
    {

        public uint HeaderLength;  // = (uint)(head->ip_verlen & 0x0F) << 2;
        public string Protocol;    // = "ICMP"; break;
        public string IPVersion;   //= temp_version.ToString();
        public string DestinationAddress;  // = temp_ip.ToString();
        public string OriginationPort; // = IPAddress.NetworkToHostOrder(temp_srcport).ToString();
        public string DestinationPort; // = IPAddress.NetworkToHostOrder(temp_dstport).ToString();
        public uint PacketLength;  // = (uint)len;
        public uint MessageLength; // = (uint)len - e.HeaderLength;
        public byte[] ReceiveBuffer;   // = buf;
        public byte[] IPHeaderBuffer;
        public string OriginationAddress;
        public byte[] MessageBuffer;

        public PacketArrivedEventArgs()
        {
        }
    }

    public class RowSocket
    {
        //private static BackgroundWorker SearchDevices = null;
        public class PacketArrivedEventArgs
        {
            public uint HeaderLength;  // = (uint)(head->ip_verlen & 0x0F) << 2;
            public string Protocol;    // = "ICMP"; break;
            public string IPVersion;   //= temp_version.ToString();
            public string DestinationAddress;  // = temp_ip.ToString();
            public string OriginationPort; // = IPAddress.NetworkToHostOrder(temp_srcport).ToString();
            public string DestinationPort; // = IPAddress.NetworkToHostOrder(temp_dstport).ToString();
            public uint PacketLength;  // = (uint)len;
            public uint MessageLength; // = (uint)len - e.HeaderLength;
            public byte[] ReceiveBuffer;   // = buf;
            public byte[] IPHeaderBuffer;
            public string OriginationAddress;
            public byte[] MessageBuffer;

            public PacketArrivedEventArgs()
            {
            }
        }

        public delegate void PacketArrivedEventHandler(Object sender, PacketArrivedEventArgs e);

        //事件句柄：包到达时引发事件
        public event PacketArrivedEventHandler OnPacketArrival;//声明时间句柄函数

        public RowSocket() //构造函数
        {
            error_occurred = false;
            len_receive_buf = 4096;
            receive_buf_bytes = new byte[len_receive_buf];
            KeepRunning = true;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct IPHeader
        {
            [FieldOffset(0)]
            public byte ip_verlen; //I4位首部长度+4位IP版本号
            [FieldOffset(1)]
            public byte ip_tos; //8位服务类型TOS
            [FieldOffset(2)]
            public ushort ip_totallength; //16位数据包总长度（字节）
            [FieldOffset(4)]
            public ushort ip_id; //16位标识
            [FieldOffset(6)]
            public ushort ip_offset; //3位标志位
            [FieldOffset(8)]
            public byte ip_ttl; //8位生存时间 TTL
            [FieldOffset(9)]
            public byte ip_protocol; //8位协议(TCP, UDP, ICMP, Etc.)
            [FieldOffset(10)]
            public ushort ip_checksum; //16位IP首部校验和
            [FieldOffset(12)]
            public uint ip_srcaddr; //32位源IP地址
            [FieldOffset(16)]
            public uint ip_destaddr; //32位目的IP地址
        }

        // public ReceiveData OnDataArrived;//

        const int SIO_RCVALL = unchecked((int)0x98000001);//监听所有的数据包

        private bool error_occurred; //套接字在接收包时是否产生错误
        public bool KeepRunning; //是否继续进行
        private static int len_receive_buf; //得到的数据流的长度
        byte[] receive_buf_bytes; //收到的字节
        private Socket socket = null; //声明套接字 
        public bool isExpection = false;
        public void CreateAndBindSocket(string ip) //建立并绑定套接字
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
                //socket.Blocking = false; //置socket非阻塞状态
                //socket.Bind(new IPEndPoint(IPAddress.Any,6000));
                socket.Bind(new IPEndPoint(IPAddress.Parse(ip), 0)); //绑定套接字
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(IPAddress.Parse("224.0.23.12")));
                if (SetSocketOption() == false) error_occurred = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                isExpection = true;
            }
        }

        private bool SetSocketOption() //设置raw socket
        {
            bool ret_value = true;
            try
            {
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, 1);
                byte[] IN = new byte[4] { 1, 0, 0, 0 };
                byte[] OUT = new byte[4];

                //低级别操作模式,接受所有的数据包，这一步是关键，必须把socket设成raw和IP Level才可用SIO_RCVALL
                int ret_code = socket.IOControl(SIO_RCVALL, IN, OUT);
                ret_code = OUT[0] + OUT[1] + OUT[2] + OUT[3];//把4个8位字节合成一个32位整数
                if (ret_code != 0) ret_value = false;
            }
            //catch (SocketException)
            //{
            //    ret_value = false;
            //}
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return ret_value;
        }

        /*
        int WSAIoctl(
        SOCKET s, //一个指定的套接字
        DWORD dwIoControlCode, //控制操作码
        LPVOID lpvInBuffer, //指向输入数据流的指针
        DWORD cbInBuffer, //输入数据流的大小（字节数）
        LPVOID lpvOutBuffer, // 指向输出数据流的指针
        DWORD cbOutBuffer, //输出数据流的大小（字节数）
        LPDWORD lpcbBytesReturned, //指向输出字节流数目的实数值
        LPWSAOVERLAPPED lpOverlapped, //指向一个WSAOVERLAPPED结构
        LPWSAOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine//指向操作完成时执行的例程
        );         
         */

        public bool ErrorOccurred
        {
            get
            {
                return error_occurred;
            }
        }


        //解析接收的数据包，形成PacketArrivedEventArgs事件数据类对象，并引发PacketArrival事件
        unsafe private void Receive(byte[] buf, int len)
        {
            byte temp_protocol = 0;
            uint temp_version = 0;
            uint temp_ip_srcaddr = 0;
            uint temp_ip_destaddr = 0;
            short temp_srcport = 0;
            short temp_dstport = 0;
            IPAddress temp_ip;

            PacketArrivedEventArgs e = new PacketArrivedEventArgs();//新网络数据包信息事件
            
            fixed (byte* fixed_buf = buf)
            {
                IPHeader* head = (IPHeader*)fixed_buf;//把数据流整和为IPHeader结构
                e.HeaderLength = (uint)(head->ip_verlen & 0x0F) << 2;

                temp_protocol = head->ip_protocol;
                switch (temp_protocol)//提取协议类型
                {
                    case 1: e.Protocol = "ICMP"; break;
                    case 2: e.Protocol = "IGMP"; break;
                    case 6: e.Protocol = "TCP"; break;
                    case 17: e.Protocol = "UDP"; break;
                    default: e.Protocol = "UNKNOWN"; break;
                }

                temp_version = (uint)(head->ip_verlen & 0xF0) >> 4;//提取IP协议版本
                e.IPVersion = temp_version.ToString();

                //以下语句提取出了PacketArrivedEventArgs对象中的其他参数
                temp_ip_srcaddr = head->ip_srcaddr;
                temp_ip_destaddr = head->ip_destaddr;
                temp_ip = new IPAddress(temp_ip_srcaddr);
                e.OriginationAddress = temp_ip.ToString();
                temp_ip = new IPAddress(temp_ip_destaddr);
                e.DestinationAddress = temp_ip.ToString();

                temp_srcport = *(short*)&fixed_buf[e.HeaderLength];
                temp_dstport = *(short*)&fixed_buf[e.HeaderLength + 2];
                e.OriginationPort = IPAddress.NetworkToHostOrder(temp_srcport).ToString();
                e.DestinationPort = IPAddress.NetworkToHostOrder(temp_dstport).ToString();

                e.PacketLength = (uint)len;
                e.MessageLength = (uint)len - e.HeaderLength;

                e.ReceiveBuffer = buf;

                e.IPHeaderBuffer = new byte[e.HeaderLength];
                //把buf中的IP头赋给PacketArrivedEventArgs中的IPHeaderBuffer
                Array.Copy(buf, 0, e.IPHeaderBuffer, 0, (int)e.HeaderLength);

                //把buf中的包中内容赋给PacketArrivedEventArgs中的MessageBuffer
                e.MessageBuffer = new byte[e.MessageLength];
                Array.Copy(buf, (int)e.HeaderLength, e.MessageBuffer, 0, (int)e.MessageLength);
            }
            //引发PacketArrival事件
            if (OnPacketArrival != null)
                OnPacketArrival(this, e);
        }

        public void Run() //开始监听
        {
            try
            {
                if (isExpection)
                {
                    EndPoint ep = new IPEndPoint(IPAddress.Any, 0);
                   
                }
                else
                {
                    IAsyncResult ar = socket.BeginReceive(receive_buf_bytes, 0, len_receive_buf, SocketFlags.None, new AsyncCallback(CallReceive), this);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        /*public void Run() //开始监听
        {
            try
            {
                SearchDevices = new BackgroundWorker();
                SearchDevices.DoWork += new DoWorkEventHandler(calculationWorker_DoWork);
                SearchDevices.RunWorkerAsync();

            }
            catch
            {

            }
        }*/

        void calculationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (KeepRunning)
                {
                    int rcv_size = socket.Receive(receive_buf_bytes);
                    Receive(receive_buf_bytes, rcv_size);
                }
            }
            catch
            {
            }
        }

        private void CallReceive(IAsyncResult ar)//异步回调
        {
            try
            {
                int received_bytes;
                received_bytes = socket.EndReceive(ar);
                Receive(receive_buf_bytes, received_bytes);
                if (KeepRunning) Run();
                //OnPacketArrival(e);
                //OnDataArrived(receive_buf_bytes, received_bytes);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                if (KeepRunning) Run();
            }

        }

        public void Close() //关闭raw socket
        {
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        }
    }
}
