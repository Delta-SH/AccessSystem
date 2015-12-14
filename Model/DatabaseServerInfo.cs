using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Database Server Information Class
    /// </summary>
    [Serializable]
    public class DatabaseServerInfo
    {
        /// <summary>
        /// UniqueID
        /// </summary>
        public Guid UniqueID { get; set; }

        /// <summary>
        /// DatabaseIntention
        /// </summary>
        public EnmDBIntention DatabaseIntention { get; set; }

        /// <summary>
        /// DatabaseType
        /// </summary>
        public EnmDBType DatabaseType { get; set; }

        /// <summary>
        /// DatabaseIP
        /// </summary>
        public String DatabaseIP { get; set; }

        /// <summary>
        /// DatabasePort
        /// </summary>
        public Int32 DatabasePort { get; set; }

        /// <summary>
        /// DatabaseUser
        /// </summary>
        public String DatabaseUser { get; set; }

        /// <summary>
        /// DatabasePwd
        /// </summary>
        public String DatabasePwd { get; set; }

        /// <summary>
        /// DatabaseName
        /// </summary>
        public String DatabaseName { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
