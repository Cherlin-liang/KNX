using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDLApiEntity.CommonEntity
{

    /// <summary>
    /// 电表的时表行数据对象
    /// </summary>
    public class PowerMeterHours
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
        /// A相,电压值
        /// </summary>
        public float A_Meter_U
        {
            get;
            set;
        }

        /// <summary>
        /// A相,电流值
        /// </summary>
        public float A_Meter_I
        {
            get;
            set;
        }

        /// <summary>
        /// A相，有功功率
        /// </summary>
        public float A_Meter_P_kw
        {
            get;
            set;
        }

        /// <summary>
        /// A相，无功功率
        /// </summary>
        public float A_Meter_P_kVar
        {
            get;
            set;
        }

        /// <summary>
        /// A相，视在功率
        /// </summary>
        public float A_Meter_P_kVA
        {
            get;
            set;
        }

        /// <summary>
        /// A相，功率因数
        /// </summary>
        public float A_Meter_Power_Factor
        {
            get;
            set;
        }

        /// <summary>
        /// A相，有功电度值,差值
        /// </summary>
        public double A_Meter_KW_Degree_Usefull
        {
            get;
            set;
        }

        /// <summary>
        /// A相，无功电度值,差值
        /// </summary>
        public double A_Meter_KW_Degree_Useless
        {
            get;
            set;
        }

        /// <summary>
        /// B相,电压值
        /// </summary>
        public float B_Meter_U
        {
            get;
            set;
        }

        /// <summary>
        /// B相,电流值
        /// </summary>
        public float B_Meter_I
        {
            get;
            set;
        }

        /// <summary>
        /// B相，有功功率
        /// </summary>
        public float B_Meter_P_kw
        {
            get;
            set;
        }

        /// <summary>
        /// B相，无功功率
        /// </summary>
        public float B_Meter_P_kVar
        {
            get;
            set;
        }

        /// <summary>
        /// B相，视在功率
        /// </summary>
        public float B_Meter_P_kVA
        {
            get;
            set;
        }

        /// <summary>
        /// B相，功率因数
        /// </summary>
        public float B_Meter_Power_Factor
        {
            get;
            set;
        }

        /// <summary>
        /// B相，有功电度值,差值
        /// </summary>
        public double B_Meter_KW_Degree_Usefull
        {
            get;
            set;
        }

        /// <summary>
        /// B相，无功电度值,差值
        /// </summary>
        public double B_Meter_KW_Degree_Useless
        {
            get;
            set;
        }

        /// <summary>
        /// C相,电压值
        /// </summary>
        public float C_Meter_U
        {
            get;
            set;
        }

        /// <summary>
        /// C相,电流值
        /// </summary>
        public float C_Meter_I
        {
            get;
            set;
        }

        /// <summary>
        /// C相，有功功率
        /// </summary>
        public float C_Meter_P_kw
        {
            get;
            set;
        }

        /// <summary>
        /// C相，无功功率
        /// </summary>
        public float C_Meter_P_kVar
        {
            get;
            set;
        }

        /// <summary>
        /// C相，视在功率
        /// </summary>
        public float C_Meter_P_kVA
        {
            get;
            set;
        }

        /// <summary>
        /// C相，功率因数
        /// </summary>
        public float C_Meter_Power_Factor
        {
            get;
            set;
        }

        /// <summary>
        /// C相，有功电度值,差值
        /// </summary>
        public double C_Meter_KW_Degree_Usefull
        {
            get;
            set;
        }

        /// <summary>
        /// C相，无功电度值,差值
        /// </summary>
        public double C_Meter_KW_Degree_Useless
        {
            get;
            set;
        }

        /// <summary>
        /// 时间点
        /// </summary>
        public DateTime Meter_Datetime
        {
            get;
            set;
        }
    }
}
