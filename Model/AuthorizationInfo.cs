using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Authorization Information Class
    /// </summary>
    [Serializable]
    public class AuthorizationInfo
    {
        /// <summary>
        /// AuthId
        /// </summary>
        public Int32 AuthId { get; set; }

        /// <summary>
        /// AuthName
        /// </summary>
        public String AuthName { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public String Comment { get; set; }

        /// <summary>
        /// LastAuthId
        /// </summary>
        public Int32 LastAuthId { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }
    }
}
