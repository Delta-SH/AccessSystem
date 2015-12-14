using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Order Information Class
    /// </summary>
    [Serializable]
    public class OrderInfo
    {
        /// <summary>
        /// TargetID
        /// </summary>
        public Int32 TargetID { get; set; }

        /// <summary>
        /// TargetType
        /// </summary>
        public EnmNodeType TargetType { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        public EnmActType OrderType { get; set; }

        /// <summary>
        /// RelValue1
        /// </summary>
        public String RelValue1 { get; set; }

        /// <summary>
        /// RelValue2
        /// </summary>
        public String RelValue2 { get; set; }

        /// <summary>
        /// RelValue3
        /// </summary>
        public String RelValue3 { get; set; }

        /// <summary>
        /// RelValue4
        /// </summary>
        public String RelValue4 { get; set; }

        /// <summary>
        /// RelValue5
        /// </summary>
        public String RelValue5 { get; set; }
    }
}
