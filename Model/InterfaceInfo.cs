using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Interface Paramters Information Class
    /// </summary>
    [Serializable]
    public class InterfaceInfo
    {
        /// <summary>
        /// UniqueID
        /// </summary>
        public Guid UniqueID { get; set; }

        /// <summary>
        /// InterfaceIP
        /// </summary>
        public String InterfaceIP { get; set; }

        /// <summary>
        /// InterfacePort
        /// </summary>
        public Int32 InterfacePort { get; set; }

        /// <summary>
        /// InterfaceUser
        /// </summary>
        public String InterfaceUser { get; set; }

        /// <summary>
        /// InterfacePwd
        /// </summary>
        public String InterfacePwd { get; set; }

        /// <summary>
        /// InterfaceDetect
        /// </summary>
        public Int32 InterfaceDetect { get; set; }

        /// <summary>
        /// InterfaceInterrupt
        /// </summary>
        public Int32 InterfaceInterrupt { get; set; }

        /// <summary>
        /// InterfaceSyncTime
        /// </summary>
        public Boolean InterfaceSyncTime { get; set; }

        /// <summary>
        /// UpdateTime
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
