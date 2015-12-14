using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Department Information Class
    /// </summary>
    [Serializable]
    public class DepartmentInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int64 ID { get; set; }

        /// <summary>
        /// DepId
        /// </summary>
        public String DepId { get; set; }

        /// <summary>
        /// DepName
        /// </summary>
        public String DepName { get; set; }

        /// <summary>
        /// LastDepId
        /// </summary>
        public String LastDepId { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public String Comment { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }
    }
}
