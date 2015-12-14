using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Role Information Class
    /// </summary>
    [Serializable]
    public class NodeLevelInfo
    {
        /// <summary>
        /// NodeID
        /// </summary>
        public Int32 NodeID { get; set; }

        /// <summary>
        /// NodeType
        /// </summary>
        public EnmNodeType NodeType { get; set; }

        /// <summary>
        /// NodeName
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// LastNodeID
        /// </summary>
        public Int32 LastNodeID { get; set; }

        /// <summary>
        /// SortIndex
        /// </summary>
        public Int32 SortIndex { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public EnmAlarmLevel Status { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        public string Remark { get; set; }
    }
}
