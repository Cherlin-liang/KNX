using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HDLGraphicalSystemServer.MyKNX;
using HDLApiEntity.DeviceStatusDataEntity;
using HDLApiEntity.EnumEntity;

namespace HDLGraphicalSystemServer
{
    public partial class frmMyKNX : Form
    {
        private string GroupAddress = "";
        private int Temperature ;
        public frmMyKNX()
        {
            InitializeComponent();
            Receive.myLocalIP = Receive.GetLocalIP();
        }

        private void FrmMyKNX_Load(object sender, EventArgs e)
        {
            myknx.LoadAllInfo_Redis();  // 获取所有设备和模块信息
            myknx.GetDeviceDatas_Redis();   // 获取所有设备的状态

            Receive.mySends.IniTheSocket(Receive.myLocalIP);
            DeviceType.SelectedIndex = 0;
            cbSwitch.SelectedIndex = 0;
            CbCurtainEdit.SelectedIndex = 0;
            Temperature = Convert.ToInt16(temp.Value);
            GroupAddress = Convert.ToString(num1.Value) + "/" + Convert.ToString(num2.Value) + "/" + Convert.ToString(num3.Value);
            //dgvKNX.Rows[0].HeaderCell.Value = "Curtain";
        }

        private void MyKNX_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                ShowData();
                

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            //byte[] a = null;
            //try
            //{
            //    if (Receive.receiveBuff.Count > 0)
            //    {
            //        a = Receive.receiveBuff.Dequeue();
            //        //richTextBox1.Text += DateTime.Now.ToShortTimeString() + "  " + Receive.sbuf.ToString() +  "\n";
                    //richTextBox1.Text += DateTime.Now.ToShortTimeString() + "  " + a.ToString() + "\n";
            //    }
               
            //}
            //catch(Exception ex)
            //{ MessageBox.Show(ex.Message); }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string SendData = null;
            string straddress1 = null;
            string straddress2 = null;
            string strdata;
            string str1, str2, str3;
            UDPSend send = new UDPSend();

            #region 组地址整合成两个byte数据
            str1 = GroupAddress.Split('/')[0];
            str2 = GroupAddress.Split('/')[1];
            str3 = GroupAddress.Split('/')[2];
            str1 = Convert.ToString(Convert.ToInt32(str1), 2);
            str2 = Convert.ToString(Convert.ToInt32(str2), 2);
            str1 = GlobalClass.AddLeftZero(str1, 4);
            str2 = GlobalClass.AddLeftZero(str2, 3);
            straddress1 = "0" + str1 + str2;
            straddress1 = string.Format("{0:x}", Convert.ToInt32(straddress1, 2));
            straddress1 = GlobalClass.AddLeftZero(straddress1, 2);
            straddress2 = Convert.ToString(Convert.ToInt32(str3), 16);
            straddress2 = GlobalClass.AddLeftZero(straddress2, 2);
            #endregion

            try
            {
                //straddress1 = textBox4.Text.Split(' ')[0];
                //straddress2 = textBox4.Text.Split(' ')[1];
                //灯光模块
                if (DeviceType.SelectedIndex == 0)
                {
                    
                    if (cbSwitch.SelectedIndex == 0)
                    {
                        strdata = "06 10 05 30 00 11 29 00 BC D0 11 64" + straddress1 + straddress2 + "01 00 81";
                    }
                    else
                        strdata = "06 10 05 30 00 11 29 00 BC D0 11 64" + straddress1 + straddress2 + "01 00 80";
                    byte[] data = GlobalClass.HexToByte(strdata);
                    send.Send(data);
                }
                //窗帘模块
                else if (DeviceType.SelectedIndex == 1)
                {
                    if (CbCurtainEdit.SelectedIndex == 0)
                    {
                        strdata = "06 10 05 30 00 12 29 00 BC D0 11 09" + straddress1 + straddress2 + "01 00 80" 
                                  + GlobalClass.AddLeftZero(Convert.ToString(Convert.ToInt32(textBox1.Text), 16), 2);                       
                    }
                    else
                        strdata = "06 10 05 30 00 12 29 00 BC D0 11 09" + straddress1 + straddress2 + "01 00 81" 
                                  + GlobalClass.AddLeftZero(Convert.ToString(Convert.ToInt32(textBox1.Text), 16), 2);
                    byte[] data = GlobalClass.HexToByte(strdata);
                    send.Send(data);

                }
                //空调模块
                else if (DeviceType.SelectedIndex == 2)
                {
                    string strtxt1 = null;
                    string strtxt2 = null;

                    //strtxt1 = textBox1.Text.Split(' ')[0];
                    //strtxt2 = textBox1.Text.Split(' ')[1];
                    //strdata = "06 10 05 30 00 13 29 00 BC D0 11 64" + straddress1 + straddress2 + "03 00 81"
                    //          + GlobalClass.AddLeftZero(Convert.ToString(Convert.ToInt32(strtxt1), 16), 2) +
                    //          GlobalClass.AddLeftZero(Convert.ToString(Convert.ToInt32(strtxt2), 16), 2);
                    if (CbModel.SelectedIndex == 0)
                    {
                        strdata = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 01 01 00 81";//制冷模式
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (CbModel.SelectedIndex == 1)
                    {
                        strdata = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 04 01 00 81";//吹风模式
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (CbModel.SelectedIndex == 2)
                    {
                        strdata = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 02 01 00 81";//制热模式
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (CbModel.SelectedIndex == 3)
                    {
                        strdata = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 05 01 00 81";//自动模式
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    if(CbSpeed.SelectedIndex == 0)
                    {
                        strdata = "06 10 05 30 00 12 29 00 BC D0 11 09 1C 01 02 00 80 55";
                                   //低风模式
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if(CbSpeed.SelectedIndex == 1)
                    {
                        strdata = "06 10 05 30 00 12 29 00 BC D0 11 09 1C 01 02 00 80 AA";
                                  //中风
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (CbSpeed.SelectedIndex == 2)
                    {
                        strdata = "06 10 05 30 00 12 29 00 BC D0 11 09 1C 01 02 00 80 FF";
                                  //高风
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (CbSpeed.SelectedIndex == 3)
                    {
                        strdata = "06 10 05 30 00 11 29 00 BC D0 11 09 1D 06 01 00 81"; //自动模式
                                  
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (CbSpeed.SelectedIndex == 4)
                    {
                        strdata = "06 10 05 30 00 12 29 00 BC D0 11 09 1C 01 02 00 80 00";
                                  //停止吹风
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    if(Temperature == 21)
                    {      //21度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0C 1A";                                  
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 22)
                    {   //22度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0C 4C";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 23)
                    {    //23度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0C 7E";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 24)
                    {    //24度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0C B0";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 25)
                    {    //25度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0C E2";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 26)
                    {    //26度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0D 14";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 27)
                    {    //27度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0D 46";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 28)
                    {    //28度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0D 78";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 29)
                    {    //29度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0D AA";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }
                    else if (Temperature == 30)
                    {    //30度
                        strdata = "06 10 05 30 00 13 29 00 BC D0 11 09 1A 01 03 00 80 0D DC";
                        byte[] data = GlobalClass.HexToByte(strdata);
                        send.Send(data);
                    }


                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            
           
        }
        
        /// <summary>
        /// 打印接收到的数据
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        void ShowData()
        {
            try
            {
                Receive.receiveItems RciveTtem = new Receive.receiveItems();
                byte[] receivemess = null;
                string changebuf = null;
                string straddress1 = null;
                //string straddress2 = null;
                string Databuff = null;
                string Srcaddress = null;
                if (Receive.receiveBuff.Count != 0)
                {
                    receivemess = Receive.receiveBuff.Dequeue();
                    for (int i = 0; i < receivemess.Length; i++)
                    {
                        changebuf += receivemess[i].ToString("X2") + " ";
                    }

                    //straddress1 = receivemess[12].ToString("X2") +" "+ receivemess[13].ToString("X2");
                    //straddress2 = receivemess[13].ToString();
                    //int address = Convert.ToInt32(straddress1, 16) * 256 + Convert.ToInt32(straddress2, 16);

                    //Srcaddress = receivemess[10].ToString("X2") + " " + receivemess[11].ToString("X2");

                    straddress1 = ExchangeDesaddr(receivemess[12], receivemess[13]);
                    Srcaddress =  "1.1." + receivemess[11].ToString();
                    RciveTtem.dstAddress = straddress1;
                    RciveTtem.SrcAddress = Srcaddress;
                    if(receivemess.Length == 17)
                    {
                        RciveTtem.StrMessage = ExchangeMess(receivemess[16].ToString("X2"));

                    }
                    else if(receivemess.Length == 18)
                    { RciveTtem.StrMessage = ExchangeMess(receivemess[17].ToString("X2")); }
                    else if(receivemess.Length == 19)
                    { RciveTtem.StrMessage = ExchangeMess(receivemess[18].ToString("X2")); }
                    //RciveTtem.StrMessage = receivemess[14].ToString("X2") +" " +receivemess[15].ToString("X2") + " " + receivemess[16].ToString("X2");
                    
                    
                    Databuff = DateTime.Now.ToShortTimeString() + "   源地址： " + RciveTtem.SrcAddress + "   目的地址："
                               + RciveTtem.dstAddress + "   相关信息：" + RciveTtem.StrMessage + "\n";

                    if (RciveTtem.StrMessage.Contains("|"))
                    {
                        
                        richTextBox1.Text = richTextBox1.Text.Insert(0, Databuff);
                    }
                        
                    //richTextBox1.AppendText(changebuf.ToString());
                    //richTextBox1.AppendText(Environment.NewLine); 
                   if(receivemess[12] == 10)
                   {
                        DatasLamp datasLamp = new DatasLamp();
                        if (receivemess[16] == 128)
                        {
                            datasLamp.LampStatus = LampStatusEnum.Off;
                            datasLamp.LampBrightness = 0;
                        }
                        else if(receivemess[16] == 129)
                        {
                            datasLamp.LampStatus = LampStatusEnum.On;
                            datasLamp.LampBrightness = 100;
                        }
                        myknx.LampStatusList.Add(datasLamp);
                   }

                   else if(receivemess[12] == 18 || receivemess[12] == 20)
                    {
                        DatasCurtain datasCurtain = new DatasCurtain();
                        if(receivemess[16] == 128 && receivemess[12] == 18)
                        {
                            datasCurtain.CurtainStatus = CurtainStatusEnum.Close;
                            datasCurtain.CutainPercentage = 0;
                        }
                        else if(receivemess[16] == 129 && receivemess[12] == 18)
                        {
                            datasCurtain.CurtainStatus = CurtainStatusEnum.Open;
                            datasCurtain.CutainPercentage = 100;
                        }
                        else if(receivemess[16] == 128 && receivemess[12] == 20)
                        {
                            datasCurtain.CurtainStatus = CurtainStatusEnum.Stop;
                            //datasCurtain.CutainPercentage = 100;
                        }
                        myknx.CurtainStatusList.Add(datasCurtain);

                    }
                   else if(receivemess[11] == 26)
                    {
                        DatasAir datasAir = new DatasAir();
                        if (receivemess[17].ToString("X2") == "55") datasAir.SetupSpeed = AirSpeedEnum.Low;
                        else if (receivemess[17].ToString("X2") == "AA") datasAir.SetupSpeed = AirSpeedEnum.Middle;
                        else if (receivemess[17].ToString("X2") == "FF") datasAir.SetupSpeed = AirSpeedEnum.High;
                        else if (receivemess[12] == 29 && receivemess[13] == 6) datasAir.SetupSpeed = AirSpeedEnum.Auto;
                        else if (receivemess[12] == 29 && receivemess[13] == 1) datasAir.SetupMode = AirModeEnum.Cold;
                        else if (receivemess[12] == 29 && receivemess[13] == 2) datasAir.SetupMode = AirModeEnum.Hot;
                        else if (receivemess[12] == 29 && receivemess[13] == 4) datasAir.SetupMode = AirModeEnum.Fan;
                        else if (receivemess[12] == 29 && receivemess[13] == 5) datasAir.SetupMode = AirModeEnum.Auto;
                        else if (receivemess[18].ToString("X2") == "1A") datasAir.ActualTemp = 21;
                        else if (receivemess[18].ToString("X2") == "4C") datasAir.ActualTemp = 22;
                        else if (receivemess[18].ToString("X2") == "7E") datasAir.ActualTemp = 23;
                        else if (receivemess[18].ToString("X2") == "B0") datasAir.ActualTemp = 24;
                        else if (receivemess[18].ToString("X2") == "E2") datasAir.ActualTemp = 25;
                        else if (receivemess[18].ToString("X2") == "14") datasAir.ActualTemp = 26;
                        else if (receivemess[18].ToString("X2") == "46") datasAir.ActualTemp = 27;
                        else if (receivemess[18].ToString("X2") == "78") datasAir.ActualTemp = 28;
                        else if (receivemess[18].ToString("X2") == "AA") datasAir.ActualTemp = 29;
                        else if (receivemess[18].ToString("X2") == "DC ") datasAir.ActualTemp = 30;

                        myknx.AirStatusList.Add(datasAir);
                    }
                    


                }
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// 开关信息转换
        /// </summary>
        /// <param name="buff">需要转换的信息</param>
        /// <returns></returns>
        public static string ExchangeMess(string buff)
        {
            string a = "";
            if (buff == 81.ToString())
            {
                a = "$01|开";
            }
            else if (buff == 80.ToString())
            {
                a = "$00|关";
            }
            else if (buff == 55.ToString())
            {
                a = "$55|33%";
            }
            else if (buff == "AA")
            {
                a = "$AA|67%";
            }
            else if(buff == "FF")
            {
                a = "$FF|100%";
            }
            else if (buff == "00")
            {
                a = "$00|0%";
            }
            else if (buff == "1A")
            {
                a = "0C 1A|21";
            }
            else if (buff == "4C")
            {
                a = "0C 4C|22";
            }
            else if (buff == "7E")
            {
                a = "0C 7E|23";
            }
            else if (buff == "B0")
            {
                a = "0C B0|24";
            }
            else if (buff == "E2")
            {
                a = "0C E2|25";
            }
            else if (buff == "14")
            {
                a = "0D 14|26";
            }
            else if (buff == "46")
            {
                a = "0D 46|27";
            }
            else if (buff == "78")
            {
                a = "0D 78|28";
            }
            else if (buff == "AA")
            {
                a = "0D AA|29";
            }
            else if (buff == "DC")
            {
                a = "0D DC|30";
            }
            return a;

        }

        /// <summary>
        /// 目的地址信息转换
        /// </summary>
        /// <param name="buff">需要转换的信息</param>
        /// <returns></returns>
        public static string ExchangeDesaddr(byte buff1,byte buff2)
        {
            byte[] straddr1 = new byte[3];
            byte[] straddr2 = new byte[5];
            int a;
            int b;
            string message = null;
            for (int i = 7; i > 2; i--)
            {
                straddr2[i-3] = Convert.ToByte(((buff1 >> i) & 1));

            }
            for (int i = 2; i >= 0; i--)
            {
                straddr1[i] = Convert.ToByte(((buff1 >> i) & 1));
            }
            a = straddr2[0] * 1 + straddr2[1] * 2 + straddr2[2] * 4 + straddr2[3] * 8;
            b = straddr1[0] * 1 + straddr1[1] * 2 + straddr1[2] * 4;
            
            message = a + "/" + b+ "/"+ buff2;
            return message;
            
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {

            richTextBox1.Clear();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(DeviceType.SelectedIndex)
            {
                case 0:
                    label2.Visible = cbSwitch.Visible = true;
                    //label4.Visible = textBox4.Visible = false;
                    label1.Visible = textBox1.Visible = false;
                    lbCurtain.Visible = CbCurtainEdit.Visible = false;
                    lbModel.Visible = CbModel.Visible = false;
                    lbSpeed.Visible = CbSpeed.Visible = temp.Visible = lbTemp.Visible = false;
                    btnSend.Visible = true;
                    break;
                case 1:
                    label2.Visible = cbSwitch.Visible = false;
                    //label4.Visible = textBox4.Visible = false;
                    label1.Visible = textBox1.Visible = true;
                    lbCurtain.Visible = CbCurtainEdit.Visible = true;
                    lbModel.Visible = CbModel.Visible = false;
                    lbSpeed.Visible = CbSpeed.Visible = temp.Visible = lbTemp.Visible = false;
                    btnSend.Visible = true;
                    break;
                case 2:
                    label2.Visible = cbSwitch.Visible = false;
                    //label4.Visible = textBox4.Visible = false;
                    label1.Visible = textBox1.Visible = true;
                    lbCurtain.Visible = CbCurtainEdit.Visible = false;
                    lbModel.Visible = CbModel.Visible = true;
                    lbSpeed.Visible = CbSpeed.Visible = temp.Visible = lbTemp.Visible = true;
                    btnSend.Visible = true;
                    break;
            }
        }

        private void Num1_ValueChanged(object sender, EventArgs e)
        {
            GroupAddress = Convert.ToString(num1.Value) + "/" + Convert.ToString(num2.Value) + "/" + Convert.ToString(num3.Value);
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Temp_ValueChanged(object sender, EventArgs e)
        {
            Temperature = Convert.ToInt16(temp.Value);
        }
    }
}
