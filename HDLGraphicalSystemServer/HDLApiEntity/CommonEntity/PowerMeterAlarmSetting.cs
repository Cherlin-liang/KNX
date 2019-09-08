using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 电表报警条件对象
    /// </summary>
    public class PowerMeterAlarmSetting
    {
        /// <summary>
        /// 电表GUID
        /// </summary>
        public string PowerMeterGuid
        {
            get;
            set;
        }


        /// <summary>
        /// 报警的回路
        /// </summary>
        public int PowerMeter_Loop
        {
            get;
            set;
        }

        /// <summary>
        /// 报警的类型，电压，电流
        /// </summary>
        public EnumCommonAlarmType PowerMeter_Type
        {
            get;
            set;
        }

        /// <summary>
        /// 报警的值
        /// </summary>
        public float PowerMeter_Alarm_Value
        {
            get;
            set;
        }


        /// <summary>
        /// 更多备注
        /// </summary>
        public string PowerMeter_Remarks
        {
            get;
            set;
        }
    }
}
