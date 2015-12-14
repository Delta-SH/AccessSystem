using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Application Information Class
    /// </summary>
    [Serializable]
    public class ApplicationInfo
    {
        /// <summary>
        /// UniqueID
        /// </summary>
        public Guid UniqueID { get; set; }

        /// <summary>
        /// AppName
        /// </summary>
        public String AppName { get; set; }

        /// <summary>
        /// AppLicense
        /// </summary>
        public String AppLicense { get; set; }

        /// <summary>
        /// AppFirstTime
        /// </summary>
        public DateTime AppFirstTime { get; set; }

        /// <summary>
        /// AppLastTime
        /// </summary>
        public DateTime AppLastTime { get; set; }

        /// <summary>
        /// AppLoginTime
        /// </summary>
        public DateTime AppLoginTime { get; set; }
    }
}
