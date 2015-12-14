using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// License Information Class
    /// </summary>
    [Serializable]
    public class LicenseInfo
    {
        /// <summary>
        /// Name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Company
        /// </summary>
        public String Company { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Expiration
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}
