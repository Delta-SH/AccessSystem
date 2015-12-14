using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Client User Information Class
    /// </summary>
    [Serializable]
    public class ClientUserInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int32 ID { get; set; }

        /// <summary>
        /// ClientName
        /// </summary>
        public String ClientName { get; set; }

        /// <summary>
        /// UID
        /// </summary>
        public String UID { get; set; }

        /// <summary>
        /// Pwd
        /// </summary>
        public String Pwd { get; set; }

        /// <summary>
        /// OpLevel
        /// </summary>
        public Int32 OpLevel { get; set; }

        /// <summary>
        /// PortVer
        /// </summary>
        public Int32 PortVer { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }
    }
}
