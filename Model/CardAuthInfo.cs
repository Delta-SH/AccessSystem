using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Card Authorization Information Class
    /// </summary>
    [Serializable]
    public class CardAuthInfo
    {
        /// <summary>
        /// CardSn
        /// </summary>
        public String CardSn { get; set; }

        /// <summary>
        /// RtuId
        /// </summary>
        public Int32 RtuId { get; set; }

        /// <summary>
        /// DevId
        /// </summary>
        public Int32 DevId { get; set; }

        /// <summary>
        /// LimitId
        /// </summary>
        public EnmLimitID LimitId { get; set; }

        /// <summary>
        /// LimitIndex
        /// </summary>
        public Int32 LimitIndex { get; set; }

        /// <summary>
        /// BeginTime
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// EndTime
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        public String Remark { get; set; }
    }
}
