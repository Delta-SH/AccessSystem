using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Organization Employee Information Class
    /// </summary>
    [Serializable]
    public class OrgEmployeeInfo
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
        /// EmpType
        /// </summary>
        public EnmWorkerType EmpType { get; set; }

        /// <summary>
        /// EmpName
        /// </summary>
        public String EmpName { get; set; }

        /// <summary>
        /// EnglishName
        /// </summary>
        public String EnglishName { get; set; }

        /// <summary>
        /// Sex
        /// </summary>
        public String Sex { get; set; }

        /// <summary>
        /// CardId
        /// </summary>
        public String CardId { get; set; }

        /// <summary>
        /// Hometown
        /// </summary>
        public String Hometown { get; set; }

        /// <summary>
        /// BirthDay
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Marriage
        /// </summary>
        public EnmMarriageType Marriage { get; set; }

        /// <summary>
        /// HomeAddress
        /// </summary>
        public String HomeAddress { get; set; }

        /// <summary>
        /// HomePhone
        /// </summary>
        public String HomePhone { get; set; }

        /// <summary>
        /// EntryDay
        /// </summary>
        public DateTime EntryDay { get; set; }

        /// <summary>
        /// PositiveDay
        /// </summary>
        public DateTime PositiveDay { get; set; }

        /// <summary>
        /// DepId
        /// </summary>
        public String DepId { get; set; }

        /// <summary>
        /// DepName
        /// </summary>
        public String DepName { get; set; }

        /// <summary>
        /// DutyName
        /// </summary>
        public String DutyName { get; set; }

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
        /// Photo
        /// </summary>
        public Byte[] Photo { get; set; }

        /// <summary>
        /// PhotoLayout
        /// </summary>
        public Int32 PhotoLayout { get; set; }

        /// <summary>
        /// ResignationDate
        /// </summary>
        public DateTime ResignationDate { get; set; }

        /// <summary>
        /// ResignationRemark
        /// </summary>
        public String ResignationRemark { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        public Boolean Enabled { get; set; }
    }
}
