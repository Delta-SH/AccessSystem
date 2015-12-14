using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Card Information Class
    /// </summary>
    [Serializable]
    public class CardInfo
    {
        /// <summary>
        /// WorkerId
        /// </summary>
        public String WorkerId { get; set; }

        /// <summary>
        /// WorkerType
        /// </summary>
        public EnmWorkerType WorkerType { get; set; }

        /// <summary>
        /// WorkerName
        /// </summary>
        public String WorkerName { get; set; }

        /// <summary>
        /// DepId
        /// </summary>
        public String DepId { get; set; }

        /// <summary>
        /// DepName
        /// </summary>
        public String DepName { get; set; }

        /// <summary>
        /// CardSn
        /// </summary>
        public String CardSn { get; set; }

        /// <summary>
        /// CardType
        /// </summary>
        public EnmCardType CardType { get; set; }

        /// <summary>
        /// UID
        /// </summary>
        public String UID { get; set; }

        /// <summary>
        /// Pwd
        /// </summary>
        public String Pwd { get; set; }

        /// <summary>
        /// BeginTime
        /// </summary>
        public DateTime BeginTime { get; set; }

        /// <summary>
        /// BeginReason
        /// </summary>
        public String BeginReason { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public String Comment { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }
    }
}
