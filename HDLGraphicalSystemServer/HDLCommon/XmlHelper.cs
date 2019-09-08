using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HDLCommon
{
    /// <summary>
    /// xml文件操作类
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// Redis的密码，默认值为hdl85521566
        /// </summary>
        public static string Redis_Password = "hdl85521566";

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static XmlHelper()
        {
            Get_Redis_Password();
        }

        /// <summary>
        /// 从配置文件里,获取Redis的密码
        /// </summary>
        /// <returns></returns>
        public static void Get_Redis_Password()
        {
            try
            {
                string xmlPath = Path.Combine(Application.StartupPath, "Setting.xml");

                //加载配置文件
                XmlDocument xmlDocu = new XmlDocument();
                xmlDocu.Normalize();
                xmlDocu.Load(xmlPath);

                XmlNodeList xnlnode = xmlDocu.SelectSingleNode("HDLGraphicalSetting").ChildNodes;
                //遍历根节点下的子节点
                foreach (XmlNode xn in xnlnode)
                {
                    //图形监控系统子网号
                    if (xn.Name == "RedisPwd")
                    {
                        Redis_Password = xn.Attributes.GetNamedItem("value").Value;                       
                    }
                }

                Export_Log_Info("Get the redis password success.");
            }
            catch (Exception ex)
            {
                Export_Log_Error("Get Redis Password Exception: " + ex.Message);              
            }
        }      

        /// <summary>
        /// 输出错误日志信息
        /// </summary>
        /// <param name="exceptionString"></param>
        public static void Export_Log_Error(string exceptionString)
        {
            try
            {
                exceptionString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ---[Error]--- " + exceptionString;

                string path = Application.StartupPath + @"\LogList\ErrorLog.txt";

                if (!File.Exists(path))
                {
                    FileInfo myfile = new FileInfo(path);
                    FileStream fs = myfile.Create();
                    fs.Close();
                }

                using (StreamWriter sw = File.AppendText(System.Windows.Forms.Application.StartupPath + @"\LogList\ErrorLog.txt"))
                {
                    sw.WriteLine(exceptionString);
                }
            }
            catch { }
        }

        /// <summary>
        /// 输出提示信息日志
        /// </summary>
        /// <param name="exceptionString"></param>
        public static void Export_Log_Info(string exceptionString)
        {
            try
            {
                exceptionString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ---[Info]--- " + exceptionString;

                string path = Application.StartupPath + @"\LogList\InfoLog.txt";

                if (!File.Exists(path))
                {
                    FileInfo myfile = new FileInfo(path);
                    FileStream fs = myfile.Create();
                    fs.Close();
                }

                using (StreamWriter sw = File.AppendText(System.Windows.Forms.Application.StartupPath + @"\LogList\InfoLog.txt"))
                {
                    sw.WriteLine(exceptionString);
                }
            }
            catch { }
        }
    }
}
