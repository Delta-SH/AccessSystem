using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Recent User Information Class
    /// </summary>
    [Serializable]
    public class RecentUserInfo
    {
        /// <summary>
        /// UniqueID
        /// </summary>
        public Guid UniqueID { get; set; }

        /// <summary>
        /// RecentUser
        /// </summary>
        public String RecentUser { get; set; }

        /// <summary>
        /// DatabaseIP
        /// </summary>
        public String RecentPwd { get; set; }

        /// <summary>
        /// RecentRmb
        /// </summary>
        public Boolean RecentRmb { get; set; }

        /// <summary>
        /// RecentLan
        /// </summary>
        public String RecentLan { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
