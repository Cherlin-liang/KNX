using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.CommonEntity
{

    /// <summary>
    /// 场景信息对象
    /// </summary>
    public class SceneInfo
    {
        /// <summary>
        /// 场景GUID
        /// </summary>
        public string SceneGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 场景名称
        /// </summary>
        public string SceneName
        {
            get;
            set;
        }

        /// <summary>
        /// 场景类型
        /// </summary>
        public EnumSceneType SceneType
        {
            get;
            set;
        }


        /// <summary>
        /// 场景状态，可控不可控
        /// </summary>
        public EnumCommonControl SceneState
        {
            get;
            set;
        }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string SceneMoreMessage
        {
            get;
            set;
        }
    }
}
