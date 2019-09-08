using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 软件基本信息对象
    /// </summary>
    public class Basic_Software_Info
    {
        /// <summary>
        /// ID值
        /// </summary>
        public string SettingID
        {
            get;
            set;
        }

        /// <summary>
        /// 收藏页布局方式,0=自动布局，1=自由布局
        /// </summary>
        public int FavoriteLayout
        {
            get;
            set;
        }

        /// <summary>
        /// 收藏页背景颜色,空值“None”
        /// </summary>
        public string FavoriteBackColor
        {
            get;
            set;
        }

        /// <summary>
        /// 收藏页背景图片,该字段存储的是相对路径
        /// </summary>
        public string FavoriteBmgIconUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 地理区域信息
        /// </summary>
        public string AreaMessage
        {
            get;
            set;
        }

        /// <summary>
        /// 语言版本
        /// </summary>
        public string LanguageVersion
        {
            get;
            set;
        }

        /// <summary>
        /// 字体信息
        /// </summary>
        public string FavoriteFont
        {
            get;
            set;
        }

        /// <summary>
        /// 主题信息
        /// </summary>
        public string FavoriteTheme
        {
            get;
            set;
        }

        /// <summary>
        /// 主页面默认方式,0=最后一次打开区域，1=收藏页面区域，2=指定的区域
        /// </summary>
        public int FavoriteOpenWay
        {
            get;
            set;
        }

        /// <summary>
        /// 主页面默认区域GUID
        /// </summary>
        public string ZoneGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 系统开始时间，第一次全新数据库时创建的时间
        /// </summary>
        public DateTime SystemStartTime
        {
            get;
            set;
        }

        /// <summary>
        /// 备用数据1
        /// </summary>
        public byte[] MarkBytes1
        {
            get;
            set;
        }

        /// <summary>
        /// 备用数据2
        /// </summary>
        public byte[] MarkBytes2
        {
            get;
            set;
        }

        /// <summary>
        /// 备用数据3
        /// </summary>
        public byte[] MarkBytes3
        {
            get;
            set;
        }

        /// <summary>
        /// 备用数据4
        /// </summary>
        public byte[] MarkBytes4
        {
            get;
            set;
        }

        /// <summary>
        /// 备用数据5
        /// </summary>
        public byte[] MarkBytes5
        {
            get;
            set;
        }

        /// <summary>
        /// 备用标识1
        /// </summary>
        public int MarkType1
        {
            get;
            set;
        }

        /// <summary>
        /// 备用标识2
        /// </summary>
        public int MarkType2
        {
            get;
            set;
        }

        /// <summary>
        /// 备用标识3
        /// </summary>
        public int MarkType3
        {
            get;
            set;
        }

        /// <summary>
        /// 备用标识4
        /// </summary>
        public int MarkType4
        {
            get;
            set;
        }

        /// <summary>
        /// 备用标识5
        /// </summary>
        public int MarkType5
        {
            get;
            set;
        }

        /// <summary>
        /// 备用信息1
        /// </summary>
        public string MarkMessage1
        {
            get;
            set;
        }        

        /// <summary>
        /// 备用信息2
        /// </summary>
        public string MarkMessage2
        {
            get;
            set;
        }

        /// <summary>
        /// 备用信息3
        /// </summary>
        public string MarkMessage3
        {
            get;
            set;
        }

        /// <summary>
        /// 备用信息4
        /// </summary>
        public string MarkMessage4
        {
            get;
            set;
        }

        /// <summary>
        /// 备用信息5
        /// </summary>
        public string MarkMessage5
        {
            get;
            set;
        }

        /// <summary>
        /// 备用信息6
        /// </summary>
        public string MarkMessage6
        {
            get;
            set;
        }

        /// <summary>
        /// 备用信息7
        /// </summary>
        public string MarkMessage7
        {
            get;
            set;
        }

        /// <summary>
        /// 备用信息8
        /// </summary>
        public string MarkMessage8
        {
            get;
            set;
        }

        /// <summary>
        /// 备用信息9
        /// </summary>
        public string MarkMessage9
        {
            get;
            set;
        }
    }
}
