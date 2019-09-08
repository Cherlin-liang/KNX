using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 背景图信息对象
    /// </summary>
    public class BasicImageInfo
    {
        /// <summary>
        /// 背景图片GUID
        /// </summary>
        public string BgImgGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImgName
        {
            get;
            set;
        }

        /// <summary>
        /// 图片类型
        /// </summary>
        public EnumImageType ImgType
        {
            get;
            set;
        }

        /// <summary>
        /// 图片路径,http相对路径
        /// </summary>
        public string ImgPath
        {
            get;
            set;
        }

        /// <summary>
        /// 图片内容
        /// </summary>
        public byte[] ImgDataContent
        {
            get;
            set;
        }

        /// <summary>
        /// 图片更多备注
        /// </summary>
        public string ImgMoreMessage
        {
            get;
            set;
        }       
    }
}
