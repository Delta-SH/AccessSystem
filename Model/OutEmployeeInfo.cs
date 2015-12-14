using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Sub Employee Information Class
    /// </summary>
    [Serializable]
    public class OutEmployeeInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public Int64 ID { get; set; }

        /// <summary>
        /// EmpId
        /// </summary>
        public String EmpId { get; set; }

        /// <summary>
        /// EmpName
        /// </summary>
        public String EmpName { get; set; }

        /// <summary>
        /// Sex
        /// </summary>
        public String Sex { get; set; }

        /// <summary>
        /// CardId
        /// </summary>
        public String CardId { get; set; }

        /// <summary>
        /// CardAddress
        /// </summary>
        public String CardAddress { get; set; }

        /// <summary>
        /// CardIssue
        /// </summary>
        public String CardIssue { get; set; }

        /// <summary>
        /// Hometown
        /// </summary>
        public String Hometown { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        public String CompanyName { get; set; }

        /// <summary>
        /// ProjectName
        /// </summary>
        public String ProjectName { get; set; }

        /// <summary>
        /// OfficePhone
        /// </summary>
        public String OfficePhone { get; set; }

        /// <summary>
        /// MobilePhone
        /// </summary>
        public String MobilePhone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public String Comment { get; set; }

        /// <summary>
        /// DepId
        /// </summary>
        public String DepId { get; set; }

        /// <summary>
        /// DepName
        /// </summary>
        public String DepName { get; set; }

        /// <summary>
        /// ParentEmpId
        /// </summary>
        public String ParentEmpId { get; set; }

        /// <summary>
        /// ParentEmpName
        /// </summary>
        public String ParentEmpName { get; set; }

        /// <summary>
        /// Photo
        /// </summary>
        public Byte[] Photo { get; set; }

        /// <summary>
        /// PhotoLayout
        /// </summary>
        public Int32 PhotoLayout { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }
    }
}
