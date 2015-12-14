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
    public class RoleInfo
    {
        /// <summary>
        /// RoleID
        /// </summary>
        public Guid RoleID { get; set; }

        /// <summary>
        /// RoleName
        /// </summary>
        public String RoleName { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public String Comment { get; set; }

        /// <summary>
        /// LastRoleID
        /// </summary>
        public Guid LastRoleID { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }

        /// <summary>
        /// Authorizations
        /// </summary>
        public List<AuthorizationInfo> Authorizations { get; set; }

        /// <summary>
        /// Nodes
        /// </summary>
        public List<NodeLevelInfo> Nodes { get; set; }

        /// <summary>
        /// Departments
        /// </summary>
        public List<DepartmentInfo> Departments { get; set; }

        /// <summary>
        /// Devices
        /// </summary>
        public Dictionary<Int32, DeviceInfo> Devices { get; set; }

        /// <summary>
        /// Cards
        /// </summary>
        public List<CardInfo> Cards { get; set; }
    }
}
