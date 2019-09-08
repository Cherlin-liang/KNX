using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDLApiEntity.DevicesEntity;
using HDLApiEntity.EnumEntity;

namespace HDLApiEntity.CommonEntity
{
    /// <summary>
    /// 电表信息对象
    /// </summary>
    public class PowerMeterInfo
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
        /// 电表备注信息
        /// </summary>
        public string PowerMeterName
        {
            get;
            set;
        }

        /// <summary>
        /// 电表状态
        /// </summary>
        public EnumDeviceStatusMark PowerMeterState
        {
            get;
            set;
        }

        /// <summary>
        /// 子网号
        /// </summary>
        public int PowerMeterSubnet
        {
            get;
            set;
        }

        /// <summary>
        /// 设备号
        /// </summary>
        public int PowerMeterDeviceNumber
        {
            get;
            set;
        }

        /// <summary>
        /// A相名称
        /// </summary>
        public string A_Meter_Name
        {
            get;
            set;
        }

        /// <summary>
        /// A相-电压值
        /// </summary>
        public float A_Meter_U
        {
            get;
            set;
        }

        /// <summary>
        /// A相-电流值
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
        /// A相，有功电度值
        /// </summary>
        public double A_Meter_KW_Degree_Usefull
        {
            get;
            set;
        }

        /// <summary>
        /// A相，无功电度值
        /// </summary>
        public double A_Meter_KW_Degree_Useless
        {
            get;
            set;
        }

        /// <summary>
        /// A相，隐藏与否，0不隐藏，1隐藏
        /// </summary>
        public EnumCommonVisable A_Meter_Hide
        {
            get;
            set;
        }

        /// <summary>
        /// A相，是否使用
        /// </summary>
        public EnumCommonEnable A_Meter_Enable
        {
            get;
            set;
        }


        /// <summary>
        /// B相名称
        /// </summary>
        public string B_Meter_Name
        {
            get;
            set;
        }

        /// <summary>
        /// B相-电压值
        /// </summary>
        public float B_Meter_U
        {
            get;
            set;
        }

        /// <summary>
        /// B相-电流值
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
        /// B相，有功电度值
        /// </summary>
        public double B_Meter_KW_Degree_Usefull
        {
            get;
            set;
        }

        /// <summary>
        /// B相，无功电度值
        /// </summary>
        public double B_Meter_KW_Degree_Useless
        {
            get;
            set;
        }

        /// <summary>
        /// B相，隐藏与否，0不隐藏，1隐藏
        /// </summary>
        public EnumCommonVisable B_Meter_Hide
        {
            get;
            set;
        }

        /// <summary>
        /// B相，是否使用
        /// </summary>
        public EnumCommonEnable B_Meter_Enable
        {
            get;
            set;
        }

        /// <summary>
        /// C相名称
        /// </summary>
        public string C_Meter_Name
        {
            get;
            set;
        }

        /// <summary>
        /// C相-电压值
        /// </summary>
        public float C_Meter_U
        {
            get;
            set;
        }

        /// <summary>
        /// C相-电流值
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
        /// C相，有功电度值
        /// </summary>
        public double C_Meter_KW_Degree_Usefull
        {
            get;
            set;
        }

        /// <summary>
        /// C相，无功电度值
        /// </summary>
        public double C_Meter_KW_Degree_Useless
        {
            get;
            set;
        }

        /// <summary>
        /// C相，隐藏与否，0不隐藏，1隐藏
        /// </summary>
        public EnumCommonVisable C_Meter_Hide
        {
            get;
            set;
        }

        /// <summary>
        /// C相，是否使用
        /// </summary>
        public EnumCommonEnable C_Meter_Enable
        {
            get;
            set;
        }

        /// <summary>
        /// C相，是否使用
        /// </summary>
        public EnumPowerMeterGather GatherEnable
        {
            get;
            set;
        }

    }
}
