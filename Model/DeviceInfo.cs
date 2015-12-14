using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Device Information Class
    /// </summary>
    [Serializable]
    public class DeviceInfo
    {
        /// <summary>
        /// Area1ID
        /// </summary>
        public Int32 Area1ID { get; set; }

        /// <summary>
        /// Area1Name
        /// </summary>
        public String Area1Name { get; set; }

        /// <summary>
        /// Area2ID
        /// </summary>
        public Int32 Area2ID { get; set; }

        /// <summary>
        /// Area2Name
        /// </summary>
        public String Area2Name { get; set; }

        /// <summary>
        /// Area3ID
        /// </summary>
        public Int32 Area3ID { get; set; }

        /// <summary>
        /// Area3Name
        /// </summary>
        public String Area3Name { get; set; }

        /// <summary>
        /// StaID
        /// </summary>
        public Int32 StaID { get; set; }

        /// <summary>
        /// StaName
        /// </summary>
        public String StaName { get; set; }

        /// <summary>
        /// DevID
        /// </summary>
        public Int32 DevID { get; set; }

        /// <summary>
        /// DevName
        /// </summary>
        public String DevName { get; set; }

        /// <summary>
        /// Nodes
        /// </summary>
        public List<NodeInfo> Nodes { get; set; }

        /// <summary>
        /// StatusNode
        /// </summary>
        public NodeInfo StatusNode { get; set; }

        /// <summary>
        /// RemoteNode
        /// </summary>
        public NodeInfo RemoteNode { get; set; }

        /// <summary>
        /// CardRecord
        /// </summary>
        public CardRecordInfo CardRecord { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }
    }
}
