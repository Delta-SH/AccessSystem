using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Limit Time Information Class
    /// </summary>
    [Serializable]
    public class LimitTimeInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int64 ID { get; set; }

        /// <summary>
        /// DevId
        /// </summary>
        public Int32 DevId { get; set; }

        /// <summary>
        /// LimitId
        /// </summary>
        public EnmLimitID LimitId { get; set; }

        /// <summary>
        /// LimitDesc
        /// </summary>
        public String LimitDesc { get; set; }

        /// <summary>
        /// LimitIndex
        /// </summary>
        public Int32 LimitIndex { get; set; }

        /// <summary>
        /// WeekIndex
        /// </summary>
        public Int32 WeekIndex { get; set; }

        /// <summary>
        /// StartTime1
        /// </summary>
        public String StartTime1 { get; set; }

        /// <summary>
        /// EndTime1
        /// </summary>
        public String EndTime1 { get; set; }

        /// <summary>
        /// StartTime2
        /// </summary>
        public String StartTime2 { get; set; }

        /// <summary>
        /// EndTime2
        /// </summary>
        public String EndTime2 { get; set; }

        /// <summary>
        /// StartTime3
        /// </summary>
        public String StartTime3 { get; set; }

        /// <summary>
        /// EndTime3
        /// </summary>
        public String EndTime3 { get; set; }

        /// <summary>
        /// StartTime4
        /// </summary>
        public String StartTime4 { get; set; }

        /// <summary>
        /// EndTime4
        /// </summary>
        public String EndTime4 { get; set; }

        /// <summary>
        /// StartTime5
        /// </summary>
        public String StartTime5 { get; set; }

        /// <summary>
        /// EndTime5
        /// </summary>
        public String EndTime5 { get; set; }

        /// <summary>
        /// StartTime6
        /// </summary>
        public String StartTime6 { get; set; }

        /// <summary>
        /// EndTime6
        /// </summary>
        public String EndTime6 { get; set; }
    }
}
