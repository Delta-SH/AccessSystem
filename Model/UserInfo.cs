using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// User Information Class
    /// </summary>
    [Serializable]
    public class UserInfo
    {
        /// <summary>
        /// Role
        /// </summary>
        public RoleInfo Role { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// RemarkName
        /// </summary>
        public String RemarkName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// PasswordFormat
        /// </summary>
        public EnmPasswordFormat PasswordFormat { get; set; }

        /// <summary>
        /// PasswordSalt
        /// </summary>
        public String PasswordSalt { get; set; }

        /// <summary>
        /// MobilePhone
        /// </summary>
        public String MobilePhone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// LimitDate
        /// </summary>
        public DateTime LimitDate { get; set; }

        /// <summary>
        /// LastLoginDate
        /// </summary>
        public DateTime LastLoginDate { get; set; }

        /// <summary>
        /// LastPasswordChangedDate
        /// </summary>
        public DateTime LastPasswordChangedDate { get; set; }

        /// <summary>
        /// FailedPasswordAttemptCount
        /// </summary>
        public Int32 FailedPasswordAttemptCount { get; set; }

        /// <summary>
        /// FailedPasswordDate
        /// </summary>
        public DateTime FailedPasswordDate { get; set; }

        /// <summary>
        /// IsLockedOut
        /// </summary>
        public Boolean IsLockedOut { get; set; }

        /// <summary>
        /// LastLockoutDate
        /// </summary>
        public DateTime LastLockoutDate { get; set; }

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
