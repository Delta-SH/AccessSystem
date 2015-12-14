using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Log Information Class
    /// </summary>
    [Serializable]
    public class LogInfo
    {
        /// <summary>
        /// EventId
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// EventTime
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// EventType
        /// </summary>
        public EnmMsgType EventType { get; set; }

        /// <summary>
        /// Operator
        /// </summary>
        public String Operator { get; set; }

        /// <summary>
        /// Source
        /// </summary>
        public String Source { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public String Message { get; set; }

        /// <summary>
        /// StackTrace
        /// </summary>
        public String StackTrace { get; set; }
    }
}
