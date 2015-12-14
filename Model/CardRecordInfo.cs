using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Card Record Information Class
    /// </summary>
    [Serializable]
    public class CardRecordInfo
    {
        /// <summary>
        /// Card
        /// </summary>
        public CardInfo Card { get; set; }

        /// <summary>
        /// Device
        /// </summary>
        public DeviceInfo Device { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public Int32 ID { get; set; }
 
        /// <summary>
        /// DevID
        /// </summary>
        public Int32 DevID { get; set; }

        /// <summary>
        /// CardSn
        /// </summary>
        public String CardSn { get; set; }

        /// <summary>
        /// CardTime
        /// </summary>
        public DateTime CardTime { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public String Status { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// Direction
        /// </summary>
        public EnmDirection Direction { get; set; }

        /// <summary>
        /// GrantPunch
        /// </summary>
        public Boolean GrantPunch { get; set; }
    }
}
