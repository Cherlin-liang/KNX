using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Management;
using System.Web.Script.Serialization;
using HDLApiEntity.DeviceStatusDataEntity;

namespace HDLGraphicalSystemServer
{
    public class Receive
    {
        private RowSocket row;
        private static string dstAddress;
        private static int dstPort;
        public static Int32 UDPPort = 3671;
        public static string myLocalIP = null; // 本机地址
        public static Receive mySends = new Receive();					//建立发送机制
        public static List<string> mstrActiveIPs = new List<string>();  //获取当前活动的IP
        public static Queue<byte[]> receiveBuff = new Queue<byte[]>();  //接收到的数据 
        public static string strsourceip;
        public static string strdesip;
        public static string strsourceport;
        public static string strdesport;
        public static string sbuf;
        public Socket hjSocket;	//socket实例
        public static receiveItems Sitems = new receiveItems();
        public static KNXCurtain Curtain = new KNXCurtain();
        public static Queue<KNXDimmer> DimmerQue = new Queue<KNXDimmer>();
        public static Queue<KNXCurtain> CurtainQue = new Queue<KNXCurtain>();
        public static Queue<KNXAirCdit> AirCditQue = new Queue<KNXAirCdit>();
        


        [Serializable]
        public class receiveItems
        {
            //public string PacketHderLen;  //数据包头长
            //public string sVersion;       //版本号
            //public string DataFrameType;  //网络路由帧
            //public string PacketLen;      //包数据总长度，包含头
            //public string PacketFlowTo;   //数据流向
            //public string StrControl;     //控制字
            public string SrcAddress;       //源地址
            public string dstAddress;       //目的地址
            public string StrMessage;       //控制信息

        }

        [Serializable]
        public class KNXBasic
        {
            public string DeviceType;      //设备类型 
            public string GroupAddress;   //组地址
            public string PhysicalAddress;  //物理地址
            public string Status;   //状态信息
                                     
        }
        [Serializable]
        public class KNXDimmer: KNXBasic
        {
            public KNXControl Open;   //开灯
            public KNXControl Close;   //关灯
        }

        [Serializable]
        public class KNXCurtain: KNXBasic
        {
            public KNXControl Open;    //开窗帘
            public KNXControl Close;   //关窗帘
            public KNXControl Stop;    //停止
            //public string FeedBack;  //反馈信息
           // public List<KNXControl> kNXControls;
        }

        [Serializable]
        public class KNXAirCdit: KNXBasic
        {           
            public KNXControl Cool;   //制冷
            public KNXControl Heat;      //制热
            public KNXControl Fan;     //送风
            public KNXControl Auto;    //自动
            public KNXControl SetWindSpeed;    //调节风速
            public KNXControl SetTemp;   //调节温度

            
        }

        [Serializable]
        public class KNXControl
        {
            public string GroupAddress;   //控制组地址
            public string FdbackAddress;  //反馈地址
            public string DataType;   //数据类型
            public string Remark;   //备注
        }

        [Serializable]
        public class KNXSetMessage
        {
            public string DeviceGuid;   //唯一GUID
            public string DeviceName;   //设备名称
            public int DeviceType;      //功能设备类型，大小类别值
            public int ProtocolStyle;    //协议类型，0=bus,1=knx
            public string ZoneGuid;      //所属区域GUID
            public byte[] KNX_DataType;   //数据类型
            public byte[] KNX_GroupAddress;  //组地址
            public byte[] KNX_FeedbackAddress;    //反馈地址

        }

        /// <summary>
        /// 关闭环境监控
        /// </summary>
        public void closeHJ()
        {
            if (hjSocket == null) return;
            try
            {
                hjSocket.Shutdown(SocketShutdown.Both);
            }
            catch
            { }

            try
            {
                hjSocket.Close();
            }
            catch
            { }
        }

        /// <summary>
        /// 初始化环境控制
        /// </summary>
        /// <returns>成功初始化返回真，否则返回否</returns>
        public void IniTheSocket(string tmpip)
        {
            try
            {
                myLocalIP = tmpip;
                if (hjSocket == null)
                {
                    hjSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    hjSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                    EndPoint ipep = new IPEndPoint(IPAddress.Parse(myLocalIP), UDPPort);
                    hjSocket.Bind(ipep);
                    
                }
                else
                {
                    this.closeHJ();
                    Thread.Sleep(3000);
                    hjSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
                    hjSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                    EndPoint ipep = new IPEndPoint(IPAddress.Parse(myLocalIP), UDPPort);
                    hjSocket.Bind(ipep);                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            StartReceive();
        }

        public void StartReceive()
        {
            try
            {
                if (row != null)
                {
                    row.Close();
                }
                row = new RowSocket();
                row.CreateAndBindSocket(myLocalIP);
                row.KeepRunning = true;
                row.OnPacketArrival += new RowSocket.PacketArrivedEventHandler(row_OnPacketArrival);
                row.Run();
            }
            catch
            {

            }
        }
        private static void row_OnPacketArrival(object sender, RowSocket.PacketArrivedEventArgs e)
        {
            try
            {
                if (e.Protocol == "UDP")
                {
                    if(e.OriginationAddress == "192.168.1.106" && e.OriginationPort == "3671" && e.DestinationAddress == "224.0.23.12")
                    {
                        byte[] buf = new byte[e.MessageBuffer.Length - 8];
                        Array.Copy(e.MessageBuffer, 8, buf, 0, e.MessageBuffer.Length - 8);
                        receiveBuff.Enqueue(buf);
                        




                        //Sitems.dstAddress = Convert.ToString(buf[8].ToString() + '.' + buf[9].ToString() + '.' + buf[10].ToString() + '.' + buf[11].ToString());
                        //Sitems.SrcAddress = Convert.ToString(buf[28].ToString() + '.' + buf[29].ToString() + '.' + buf[30].ToString() + '.' + buf[31].ToString());
                        //Sitems.StrMessage = Convert.ToString(buf[32].ToString() + ',' + buf[33].ToString() + ',' + buf[34].ToString() + ',' + buf[35].ToString());
                        //byte[] data = GlobalClass.HexToByte(buf.ToString());

                        //sbuf = Encoding.UTF8.GetString(buf);
                        //Sitems = ReadAppLoadListssJson(sbuf);
                        //Sitems.SrcAddress = e.OriginationAddress;
                        //Sitems.dstAddress = e.DestinationAddress;


                    }
                    if (e.DestinationAddress == "224.0.23.12" && e.OriginationPort == "3671"
                            && e.OriginationAddress != GetLocalIP())
                    {
                        byte[] buffer = new byte[e.MessageBuffer.Length - 8];
                        Array.Copy(e.MessageBuffer, 8, buffer, 0, e.MessageBuffer.Length - 8);

                        UDPReceive.OnReceive(buffer);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        public void EndReceive()
        {
            if (row != null)
            {
                row.Close();
                row = null;
            }
        }

        /// <summary>
        /// read ip 
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            string strIP = "";
            try
            {
                mstrActiveIPs = new List<string>();
                getNetworkDeviceIPs();
                //IniFile iniFile = new IniFile(Application.StartupPath + @"\ini\Default.ini");
                //strIP = iniFile.IniReadValue("ProgramMode", "IP", "");
                strIP = "192.168.1.101";
                if (strIP == null || strIP == "" || !mstrActiveIPs.Contains(strIP))
                {
                    if (mstrActiveIPs.Count != 0)
                        strIP = mstrActiveIPs[0];
                }
            }
            catch
            {
            }
            return strIP;
        }

        /// <summary>
        /// read ip 
        /// </summary>
        /// <returns></returns>
        public static void getNetworkDeviceIPs()
        {
            try
            {
                mstrActiveIPs = new List<string>();
                IPHostEntry ipHost = Dns.Resolve(Dns.GetHostName());
                foreach (IPAddress ipAddress in ipHost.AddressList)
                {
                    if (ipAddress.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        if (!mstrActiveIPs.Contains(ipAddress.ToString()))
                        {
                            mstrActiveIPs.Add(ipAddress.ToString());
                        }
                    }
                }
            }
            catch
            {
            }

        }


        
        /// <summary>
        /// ReadJson方法定义的是Json.Net用来处理反序列化的逻辑
        /// </summary>
        public static receiveItems ReadAppLoadListssJson(String sContent)
        {
            receiveItems tmpResult = new receiveItems();
            try
            {
                JsonReader reader = new JsonTextReader(new StringReader(sContent));
                //使用JObject类的Load方法可以从传入的参数reader中读取Json中的键值对，然后用这些键值对还原ListInfo对象，来自定义反序列化逻辑
                JObject jObject = JObject.Load(reader);
                JavaScriptSerializer js = new JavaScriptSerializer();
                tmpResult = js.Deserialize<receiveItems>(jObject.ToString());
                return tmpResult;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return tmpResult;
            }
        }
    }
}

