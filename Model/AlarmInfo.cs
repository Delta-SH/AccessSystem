using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Alarm Information Class
    /// </summary>
    [Serializable]
    public class AlarmInfo
    {
        /// <summary>
        /// SerialNO
        /// </summary>
        public int SerialNO { get; set; }

        /// <summary>
        /// Area1Name
        /// </summary>
        public string Area1Name { get; set; }

        /// <summary>
        /// Area2Name
        /// </summary>
        public string Area2Name { get; set; }

        /// <summary>
        /// Area3Name
        /// </summary>
        public string Area3Name { get; set; }

        /// <summary>
        /// Area4Name
        /// </summary>
        public string Area4Name { get; set; }

        /// <summary>
        /// StaName
        /// </summary>
        public string StaName { get; set; }

        /// <summary>
        /// DevName
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// DevDesc
        /// </summary>
        public string DevDesc { get; set; }

        /// <summary>
        /// NodeID
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// NodeType
        /// </summary>
        public EnmNodeType NodeType { get; set; }

        /// <summary>
        /// NodeName
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// AlarmID
        /// </summary>
        public int AlarmID { get; set; }

        /// <summary>
        /// AlarmValue
        /// </summary>
        public float AlarmValue { get; set; }

        /// <summary>
        /// AlarmLevel
        /// </summary>
        public EnmAlarmLevel AlarmLevel { get; set; }

        /// <summary>
        /// AlarmStatus
        /// </summary>
        public EnmAlarmStatus AlarmStatus { get; set; }

        /// <summary>
        /// AlarmDesc
        /// </summary>
        public string AlarmDesc { get; set; }

        /// <summary>
        /// AuxAlarmDesc
        /// </summary>
        public string AuxAlarmDesc { get; set; }

        /// <summary>
        /// StartTime
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// EndTime
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// ConfirmName
        /// </summary>
        public string ConfirmName { get; set; }

        /// <summary>
        /// ConfirmMarking
        /// </summary>
        public EnmConfirmMarking ConfirmMarking { get; set; }

        /// <summary>
        /// ConfirmTime
        /// </summary>
        public DateTime ConfirmTime { get; set; }

        /// <summary>
        /// AuxSet
        /// </summary>
        public string AuxSet { get; set; }

        /// <summary>
        /// TaskID
        /// </summary>
        public string TaskID { get; set; }

        /// <summary>
        /// ProjName
        /// </summary>
        public string ProjName { get; set; }

        /// <summary>
        /// TurnCount
        /// </summary>
        public int TurnCount { get; set; }

        /// <summary>
        /// TotalCount
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// IsSyncAlarm
        /// </summary>
        public bool IsSyncAlarm { get; set; }

        /// <summary>
        /// IsSyncAlarmFirst
        /// </summary>
        public bool IsSyncAlarmFirst { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
