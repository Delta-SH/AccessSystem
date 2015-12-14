using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;

namespace Delta.MPS.SQLServerDAL
{
    /// <summary>
    /// This class is an implementation for receiving employees information from database
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Get Organization Employees By Role Id.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>Role Organization Employees</returns>
        public List<OrgEmployeeInfo> GetOrgEmployees(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = ComUtility.DBNullSuperChecker(roleId);

            var employees = new List<OrgEmployeeInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_EE_GetOrgEmployees, parms)) {
                while (rdr.Read()) {
                    var employee = new OrgEmployeeInfo();
                    employee.ID = ComUtility.DBNullInt64Handler(rdr["ID"]);
                    employee.EmpId = ComUtility.DBNullStringHandler(rdr["EmpId"]);
                    employee.EmpType = ComUtility.DBNullWorkerTypeHandler(rdr["EmpType"]);
                    employee.EmpName = ComUtility.DBNullStringHandler(rdr["EmpName"]);
                    employee.EnglishName = ComUtility.DBNullStringHandler(rdr["EnglishName"]);
                    employee.Sex = ComUtility.DBNullStringHandler(rdr["Sex"]);
                    employee.CardId = ComUtility.DBNullStringHandler(rdr["CardID"]);
                    employee.Hometown = ComUtility.DBNullStringHandler(rdr["Hometown"]);
                    employee.BirthDay = ComUtility.DBNullDateTimeHandler(rdr["BirthDay"]);
                    employee.Marriage = ComUtility.DBNullMarriageTypeHandler(rdr["Marriage"]);
                    employee.HomeAddress = ComUtility.DBNullStringHandler(rdr["HomeAddress"]);
                    employee.HomePhone = ComUtility.DBNullStringHandler(rdr["HomePhone"]);
                    employee.EntryDay = ComUtility.DBNullDateTimeHandler(rdr["EntryDay"]);
                    employee.PositiveDay = ComUtility.DBNullDateTimeHandler(rdr["PositiveDay"]);
                    employee.DepId = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    employee.DepName = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    employee.DutyName = ComUtility.DBNullStringHandler(rdr["DutyName"]);
                    employee.OfficePhone = ComUtility.DBNullStringHandler(rdr["OfficePhone"]);
                    employee.MobilePhone = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    employee.Email = ComUtility.DBNullStringHandler(rdr["Email"]);
                    employee.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    employee.Photo = ComUtility.DBNullBytesHandler(rdr["Photo"]);
                    employee.PhotoLayout = ComUtility.DBNullInt32Handler(rdr["PhotoLayout"]);
                    employee.ResignationDate = ComUtility.DBNullDateTimeHandler(rdr["ResignationDate"]);
                    employee.ResignationRemark = ComUtility.DBNullStringHandler(rdr["ResignationRemark"]);
                    employee.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    employees.Add(employee);
                }
            }
            return employees;
        }

        /// <summary>
        /// Get Organization Employee By The Specified ID.
        /// </summary>
        /// <param name="EmpId">employee id</param>
        /// <returns>the specified employee</returns>
        public OrgEmployeeInfo GetOrgEmployee(String EmpId) {
            SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar, 50) };
            parms[0].Value = EmpId;

            OrgEmployeeInfo employee = null;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_EE_GetOrgEmployee, parms)) {
                if (rdr.Read()) {
                    employee = new OrgEmployeeInfo();
                    employee.ID = ComUtility.DBNullInt64Handler(rdr["ID"]);
                    employee.EmpId = ComUtility.DBNullStringHandler(rdr["EmpId"]);
                    employee.EmpType = ComUtility.DBNullWorkerTypeHandler(rdr["EmpType"]);
                    employee.EmpName = ComUtility.DBNullStringHandler(rdr["EmpName"]);
                    employee.EnglishName = ComUtility.DBNullStringHandler(rdr["EnglishName"]);
                    employee.Sex = ComUtility.DBNullStringHandler(rdr["Sex"]);
                    employee.CardId = ComUtility.DBNullStringHandler(rdr["CardID"]);
                    employee.Hometown = ComUtility.DBNullStringHandler(rdr["Hometown"]);
                    employee.BirthDay = ComUtility.DBNullDateTimeHandler(rdr["BirthDay"]);
                    employee.Marriage = ComUtility.DBNullMarriageTypeHandler(rdr["Marriage"]);
                    employee.HomeAddress = ComUtility.DBNullStringHandler(rdr["HomeAddress"]);
                    employee.HomePhone = ComUtility.DBNullStringHandler(rdr["HomePhone"]);
                    employee.EntryDay = ComUtility.DBNullDateTimeHandler(rdr["EntryDay"]);
                    employee.PositiveDay = ComUtility.DBNullDateTimeHandler(rdr["PositiveDay"]);
                    employee.DepId = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    employee.DepName = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    employee.DutyName = ComUtility.DBNullStringHandler(rdr["DutyName"]);
                    employee.OfficePhone = ComUtility.DBNullStringHandler(rdr["OfficePhone"]);
                    employee.MobilePhone = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    employee.Email = ComUtility.DBNullStringHandler(rdr["Email"]);
                    employee.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    employee.Photo = ComUtility.DBNullBytesHandler(rdr["Photo"]);
                    employee.PhotoLayout = ComUtility.DBNullInt32Handler(rdr["PhotoLayout"]);
                    employee.ResignationDate = ComUtility.DBNullDateTimeHandler(rdr["ResignationDate"]);
                    employee.ResignationRemark = ComUtility.DBNullStringHandler(rdr["ResignationRemark"]);
                    employee.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                }
            }
            return employee;
        }

        /// <summary>
        /// Get Max Organization Employee ID.
        /// </summary>
        /// <returns>max id</returns>
        public Int64 GetMaxOrgEmployeeID() {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var maxId = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_EE_GetMaxOrgEmployeeID, null);
                return maxId != null && maxId != DBNull.Value ? Convert.ToInt64(maxId) : 0;
            }
        }

        /// <summary>
        /// Save Organization Employees.
        /// </summary>
        /// <param name="employees">employees</param>
        public void SaveOrgEmployees(List<OrgEmployeeInfo> employees) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar,50),
                                                 new SqlParameter("@EmpType", SqlDbType.Int), 
                                                 new SqlParameter("@EmpName", SqlDbType.NVarChar, 50), 
                                                 new SqlParameter("@EnglishName", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@Sex", SqlDbType.VarChar,10),
                                                 new SqlParameter("@CardID", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@Hometown", SqlDbType.NVarChar, 200), 
                                                 new SqlParameter("@BirthDay", SqlDbType.DateTime), 
                                                 new SqlParameter("@Marriage", SqlDbType.Int), 
                                                 new SqlParameter("@HomeAddress", SqlDbType.NVarChar, 200), 
                                                 new SqlParameter("@HomePhone", SqlDbType.VarChar, 20), 
                                                 new SqlParameter("@EntryDay", SqlDbType.DateTime), 
                                                 new SqlParameter("@PositiveDay", SqlDbType.DateTime), 
                                                 new SqlParameter("@DepId", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@DutyName", SqlDbType.NVarChar, 50), 
                                                 new SqlParameter("@OfficePhone", SqlDbType.VarChar, 20), 
                                                 new SqlParameter("@MobilePhone", SqlDbType.VarChar, 20), 
                                                 new SqlParameter("@Email", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@Comment", SqlDbType.NVarChar,1024),
                                                 new SqlParameter("@Photo", SqlDbType.Image),
                                                 new SqlParameter("@PhotoLayout", SqlDbType.Int),
                                                 new SqlParameter("@ResignationDate", SqlDbType.DateTime),
                                                 new SqlParameter("@ResignationRemark", SqlDbType.NVarChar,1024),
                                                 new SqlParameter("@Enabled", SqlDbType.Bit) };

                        foreach (var employee in employees) {
                            parms[0].Value = employee.EmpId;
                            parms[1].Value = (Int32)employee.EmpType;
                            parms[2].Value = employee.EmpName;
                            parms[3].Value = ComUtility.DBNullStringChecker(employee.EnglishName);
                            parms[4].Value = employee.Sex;
                            parms[5].Value = ComUtility.DBNullStringChecker(employee.CardId);
                            parms[6].Value = ComUtility.DBNullStringChecker(employee.Hometown);
                            parms[7].Value = employee.BirthDay;
                            parms[8].Value = (Int32)employee.Marriage;
                            parms[9].Value = ComUtility.DBNullStringChecker(employee.HomeAddress);
                            parms[10].Value = ComUtility.DBNullStringChecker(employee.HomePhone);
                            parms[11].Value = employee.EntryDay;
                            parms[12].Value = employee.PositiveDay;
                            parms[13].Value = employee.DepId;
                            parms[14].Value = ComUtility.DBNullStringChecker(employee.DutyName);
                            parms[15].Value = ComUtility.DBNullStringChecker(employee.OfficePhone);
                            parms[16].Value = employee.MobilePhone;
                            parms[17].Value = employee.Email;
                            parms[18].Value = ComUtility.DBNullStringChecker(employee.Comment);
                            parms[19].Value = ComUtility.DBNullBytesChecker(employee.Photo);
                            parms[20].Value = employee.PhotoLayout;
                            parms[21].Value = ComUtility.DBNullDateTimeChecker(employee.ResignationDate);
                            parms[22].Value = ComUtility.DBNullStringChecker(employee.ResignationRemark);
                            parms[23].Value = employee.Enabled;

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_EE_SaveOrgEmployee, parms);
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Delete Organization Employees.
        /// </summary>
        /// <param name="employees">employees</param>
        public void DeleteOrgEmployees(List<OrgEmployeeInfo> employees) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@EmpType", SqlDbType.Int)};
                        foreach (var emp in employees) {
                            parms[0].Value = emp.EmpId;
                            parms[1].Value = (Int32)emp.EmpType;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_EE_DeleteOrgEmployee, parms);
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Exist Organization Employee.
        /// </summary>
        /// <param name="EmpId">employee id</param>
        /// <returns>true/false</returns>
        public bool ExistOrgEmployee(String EmpId) {
            SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar, 50) };
            parms[0].Value = EmpId;
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var cnt = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_EE_ExistOrgEmployee, parms);
                return Convert.ToInt32(cnt) > 0;
            }
        }

        /// <summary>
        /// Exist Out Employees In Organization Employee.
        /// </summary>
        /// <param name="EmpId">employee Id</param>
        /// <returns>true/false</returns>
        public bool ExistOutEmployeesInOrgEmployees(String EmpId) {
            SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar, 50) };
            parms[0].Value = EmpId;
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var cnt = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_EE_ExistOutEmployeesInOrgEmployees, parms);
                return Convert.ToInt32(cnt) > 0;
            }
        }

        /// <summary>
        /// Get Out Employees By Role Id.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>Out Employees</returns>
        public List<OutEmployeeInfo> GetOutEmployees(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = ComUtility.DBNullSuperChecker(roleId);

            var employees = new List<OutEmployeeInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_EE_GetOutEmployees, parms)) {
                while (rdr.Read()) {
                    var employee = new OutEmployeeInfo();
                    employee.ID = ComUtility.DBNullInt64Handler(rdr["ID"]);
                    employee.EmpId = ComUtility.DBNullStringHandler(rdr["EmpId"]);
                    employee.EmpName = ComUtility.DBNullStringHandler(rdr["EmpName"]);
                    employee.Sex = ComUtility.DBNullStringHandler(rdr["Sex"]);
                    employee.CardId = ComUtility.DBNullStringHandler(rdr["CardId"]);
                    employee.CardAddress = ComUtility.DBNullStringHandler(rdr["CardAddress"]);
                    employee.CardIssue = ComUtility.DBNullStringHandler(rdr["CardIssue"]);
                    employee.Hometown = ComUtility.DBNullStringHandler(rdr["Hometown"]);
                    employee.CompanyName = ComUtility.DBNullStringHandler(rdr["CompanyName"]);
                    employee.ProjectName = ComUtility.DBNullStringHandler(rdr["ProjectName"]);
                    employee.OfficePhone = ComUtility.DBNullStringHandler(rdr["OfficePhone"]);
                    employee.MobilePhone = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    employee.Email = ComUtility.DBNullStringHandler(rdr["Email"]);
                    employee.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    employee.DepId = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    employee.DepName = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    employee.ParentEmpId = ComUtility.DBNullStringHandler(rdr["ParentEmpId"]);
                    employee.ParentEmpName = ComUtility.DBNullStringHandler(rdr["ParentEmpName"]);
                    employee.Photo = ComUtility.DBNullBytesHandler(rdr["Photo"]);
                    employee.PhotoLayout = ComUtility.DBNullInt32Handler(rdr["PhotoLayout"]);
                    employee.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    employees.Add(employee);
                }
            }
            return employees;
        }

        /// <summary>
        /// Get Out Employee By The Specified ID.
        /// </summary>
        /// <param name="EmpId">Employee ID</param>
        /// <returns>The Specified Out Employee</returns>
        public OutEmployeeInfo GetOutEmployee(String EmpId) {
            SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar, 50) };
            parms[0].Value = EmpId;

            OutEmployeeInfo employee = null;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_EE_GetOutEmployee, parms)) {
                if (rdr.Read()) {
                    employee = new OutEmployeeInfo();
                    employee.ID = ComUtility.DBNullInt64Handler(rdr["ID"]);
                    employee.EmpId = ComUtility.DBNullStringHandler(rdr["EmpId"]);
                    employee.EmpName = ComUtility.DBNullStringHandler(rdr["EmpName"]);
                    employee.Sex = ComUtility.DBNullStringHandler(rdr["Sex"]);
                    employee.CardId = ComUtility.DBNullStringHandler(rdr["CardId"]);
                    employee.CardAddress = ComUtility.DBNullStringHandler(rdr["CardAddress"]);
                    employee.CardIssue = ComUtility.DBNullStringHandler(rdr["CardIssue"]);
                    employee.Hometown = ComUtility.DBNullStringHandler(rdr["Hometown"]);
                    employee.CompanyName = ComUtility.DBNullStringHandler(rdr["CompanyName"]);
                    employee.ProjectName = ComUtility.DBNullStringHandler(rdr["ProjectName"]);
                    employee.OfficePhone = ComUtility.DBNullStringHandler(rdr["OfficePhone"]);
                    employee.MobilePhone = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    employee.Email = ComUtility.DBNullStringHandler(rdr["Email"]);
                    employee.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    employee.DepId = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    employee.DepName = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    employee.ParentEmpId = ComUtility.DBNullStringHandler(rdr["ParentEmpId"]);
                    employee.ParentEmpName = ComUtility.DBNullStringHandler(rdr["ParentEmpName"]);
                    employee.Photo = ComUtility.DBNullBytesHandler(rdr["Photo"]);
                    employee.PhotoLayout = ComUtility.DBNullInt32Handler(rdr["PhotoLayout"]);
                    employee.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                }
            }
            return employee;
        }

        /// <summary>
        /// Get Max Out Employee ID.
        /// </summary>
        /// <returns>Max Out Employee ID</returns>
        public Int64 GetMaxOutEmployeeID() {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var maxId = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_EE_GetMaxOutEmployeeID, null);
                return maxId != null && maxId != DBNull.Value ? Convert.ToInt64(maxId) : 0;
            }
        }

        /// <summary>
        /// Save Out Employees.
        /// </summary>
        /// <param name="employees">Out Employees</param>
        public void SaveOutEmployees(List<OutEmployeeInfo> employees) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar,50),
                                                 new SqlParameter("@EmpName", SqlDbType.NVarChar, 50),  
                                                 new SqlParameter("@Sex", SqlDbType.VarChar,10),
                                                 new SqlParameter("@CardId", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@CardAddress", SqlDbType.NVarChar, 200), 
                                                 new SqlParameter("@CardIssue", SqlDbType.NVarChar, 200), 
                                                 new SqlParameter("@Hometown", SqlDbType.NVarChar, 200), 
                                                 new SqlParameter("@CompanyName", SqlDbType.NVarChar, 100), 
                                                 new SqlParameter("@ProjectName", SqlDbType.NVarChar, 100), 
                                                 new SqlParameter("@OfficePhone", SqlDbType.VarChar, 20), 
                                                 new SqlParameter("@MobilePhone", SqlDbType.VarChar, 20), 
                                                 new SqlParameter("@Email", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@Comment", SqlDbType.NVarChar,1024),
                                                 new SqlParameter("@ParentEmpId", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@Photo", SqlDbType.Image),
                                                 new SqlParameter("@PhotoLayout", SqlDbType.Int),
                                                 new SqlParameter("@Enabled", SqlDbType.Bit) };

                        foreach (var employee in employees) {
                            parms[0].Value = employee.EmpId;
                            parms[1].Value = employee.EmpName;
                            parms[2].Value = employee.Sex;
                            parms[3].Value = ComUtility.DBNullStringChecker(employee.CardId);
                            parms[4].Value = ComUtility.DBNullStringChecker(employee.CardAddress);
                            parms[5].Value = ComUtility.DBNullStringChecker(employee.CardIssue);
                            parms[6].Value = ComUtility.DBNullStringChecker(employee.Hometown);
                            parms[7].Value = ComUtility.DBNullStringChecker(employee.CompanyName);
                            parms[8].Value = ComUtility.DBNullStringChecker(employee.ProjectName);
                            parms[9].Value = ComUtility.DBNullStringChecker(employee.OfficePhone);
                            parms[10].Value = employee.MobilePhone;
                            parms[11].Value = employee.Email;
                            parms[12].Value = ComUtility.DBNullStringChecker(employee.Comment);
                            parms[13].Value = employee.ParentEmpId;
                            parms[14].Value = ComUtility.DBNullBytesChecker(employee.Photo);
                            parms[15].Value = employee.PhotoLayout;
                            parms[16].Value = employee.Enabled;

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_EE_SaveOutEmployee, parms);
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Delete Out Employees.
        /// </summary>
        /// <param name="employees">Out Employees</param>
        public void DeleteOutEmployees(List<OutEmployeeInfo> employees) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@EmpType", SqlDbType.Int)};
                        foreach (var emp in employees) {
                            parms[0].Value = emp.EmpId;
                            parms[1].Value = (Int32)EnmWorkerType.WXRY;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_EE_DeleteOutEmployee, parms);
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Exist Out Employee.
        /// </summary>
        /// <param name="EmpId">employee id</param>
        /// <returns>true/false</returns>
        public bool ExistOutEmployee(String EmpId) {
            SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar, 50) };
            parms[0].Value = EmpId;
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var cnt = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_EE_ExistOutEmployee, parms);
                return Convert.ToInt32(cnt) > 0;
            }
        }

        /// <summary>
        /// Import Org Employees.
        /// </summary>
        /// <param name="dt">DataTable</param>
        public void ImportOrgEmployees(DataTable dt) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar,50),
                                                 new SqlParameter("@EmpType", SqlDbType.Int), 
                                                 new SqlParameter("@EmpName", SqlDbType.NVarChar, 50),  
                                                 new SqlParameter("@Sex", SqlDbType.VarChar,10),
                                                 new SqlParameter("@CardID", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@DepId", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@MobilePhone", SqlDbType.VarChar, 20), 
                                                 new SqlParameter("@Email", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@CardSn", SqlDbType.VarChar,50), 
                                                 new SqlParameter("@CardType", SqlDbType.Int)};

                        for (var i = 0; i < dt.Rows.Count; i++) {
                            if (dt.Rows[i][0] == DBNull.Value
                                || dt.Rows[i][2] == DBNull.Value
                                || String.IsNullOrWhiteSpace(dt.Rows[i][0].ToString())
                                || String.IsNullOrWhiteSpace(dt.Rows[i][2].ToString())
                                ) { continue; }

                            parms[0].Value = dt.Rows[i][2].ToString().Trim().PadLeft(8, '0');
                            parms[1].Value = (Int32)EnmWorkerType.ZSYG;
                            parms[2].Value = dt.Rows[i][3];
                            parms[3].Value = "M";
                            parms[4].Value = dt.Rows[i][4];
                            parms[5].Value = dt.Rows[i][0].ToString().Trim().PadLeft(5, '0');
                            parms[6].Value = dt.Rows[i][5];
                            parms[7].Value = dt.Rows[i][6];
                            if (dt.Rows[i][7] == DBNull.Value || String.IsNullOrWhiteSpace(dt.Rows[i][7].ToString())) {
                                parms[8].Value = DBNull.Value;
                            } else {
                                parms[8].Value = ComUtility.GetCardSn10to16(dt.Rows[i][7].ToString().Trim());
                            }
                            parms[9].Value = EnmCardType.ZSK;

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_EE_ImportOrgEmployees, parms);
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Export Org Employees.
        /// </summary>
        public DataTable ExportOrgEmployees(Guid roleId) {
            var data = new DataTable();
            data.Columns.Add("部门代码", typeof(String));
            data.Columns.Add("部门名称", typeof(String));
            data.Columns.Add("员工工号", typeof(String));
            data.Columns.Add("员工姓名", typeof(String));
            data.Columns.Add("身份证号", typeof(String));
            data.Columns.Add("手机", typeof(String));
            data.Columns.Add("Email", typeof(String));
            data.Columns.Add("卡号", typeof(String));

            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = ComUtility.DBNullSuperChecker(roleId);
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_EE_ExportOrgEmployees, parms)) {
                while (rdr.Read()) {
                    var dr = data.NewRow();
                    dr["部门代码"] = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    dr["部门名称"] = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    dr["员工工号"] = ComUtility.DBNullStringHandler(rdr["EmpId"]);
                    dr["员工姓名"] = ComUtility.DBNullStringHandler(rdr["EmpName"]);
                    dr["身份证号"] = ComUtility.DBNullStringHandler(rdr["CardId"]);
                    dr["手机"] = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    dr["Email"] = ComUtility.DBNullStringHandler(rdr["Email"]);
                    dr["卡号"] = rdr["CardSn"] == DBNull.Value || String.IsNullOrWhiteSpace(rdr["CardSn"].ToString()) ? String.Empty : ComUtility.GetCardSn16to10(rdr["CardSn"].ToString());
                    data.Rows.Add(dr);
                }
            }
            return data;
        }

        /// <summary>
        /// Import Out Employees.
        /// </summary>
        /// <param name="dt">DataTable</param>
        public void ImportOutEmployees(DataTable dt) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar,50),
                                                 new SqlParameter("@EmpType", SqlDbType.Int), 
                                                 new SqlParameter("@EmpName", SqlDbType.NVarChar, 50),  
                                                 new SqlParameter("@Sex", SqlDbType.VarChar,10),
                                                 new SqlParameter("@CardID", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@ParentEmpId", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@MobilePhone", SqlDbType.VarChar, 20), 
                                                 new SqlParameter("@Email", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@CardSn", SqlDbType.VarChar,50), 
                                                 new SqlParameter("@CardType", SqlDbType.Int)};

                        for (var i = 0; i < dt.Rows.Count; i++) {
                            if (dt.Rows[i][2] == DBNull.Value
                                || dt.Rows[i][4] == DBNull.Value
                                || String.IsNullOrWhiteSpace(dt.Rows[i][2].ToString())
                                || String.IsNullOrWhiteSpace(dt.Rows[i][4].ToString())
                                ) { continue; }

                            parms[0].Value = dt.Rows[i][4].ToString().Trim().PadLeft(8, '0');
                            parms[1].Value = (Int32)EnmWorkerType.WXRY;
                            parms[2].Value = dt.Rows[i][5];
                            parms[3].Value = "M";
                            parms[4].Value = dt.Rows[i][6];
                            parms[5].Value = dt.Rows[i][2].ToString().Trim().PadLeft(8, '0');
                            parms[6].Value = dt.Rows[i][7];
                            parms[7].Value = dt.Rows[i][8];
                            if (dt.Rows[i][9] == DBNull.Value || String.IsNullOrWhiteSpace(dt.Rows[i][9].ToString())) {
                                parms[8].Value = DBNull.Value;
                            } else {
                                parms[8].Value = ComUtility.GetCardSn10to16(dt.Rows[i][9].ToString().Trim());
                            }
                            parms[9].Value = EnmCardType.LSK;

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_EE_ImportOutEmployees, parms);
                        }

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Export Out Employees.
        /// </summary>
        public DataTable ExportOutEmployees(Guid roleId) {
            var data = new DataTable();
            data.Columns.Add("部门代码", typeof(String));
            data.Columns.Add("部门名称", typeof(String));
            data.Columns.Add("责任人工号", typeof(String));
            data.Columns.Add("责任人姓名", typeof(String));
            data.Columns.Add("外协人员工号", typeof(String));
            data.Columns.Add("外协人员姓名", typeof(String));
            data.Columns.Add("身份证号", typeof(String));
            data.Columns.Add("手机", typeof(String));
            data.Columns.Add("Email", typeof(String));
            data.Columns.Add("卡号", typeof(String));

            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@EmpType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(roleId);
            parms[1].Value = EnmWorkerType.WXRY;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_EE_ExportOutEmployees, parms)) {
                while (rdr.Read()) {
                    var dr = data.NewRow();
                    dr["部门代码"] = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    dr["部门名称"] = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    dr["责任人工号"] = ComUtility.DBNullStringHandler(rdr["ParentEmpId"]);
                    dr["责任人姓名"] = ComUtility.DBNullStringHandler(rdr["ParentEmpName"]);
                    dr["外协人员工号"] = ComUtility.DBNullStringHandler(rdr["EmpId"]);
                    dr["外协人员姓名"] = ComUtility.DBNullStringHandler(rdr["EmpName"]);
                    dr["身份证号"] = ComUtility.DBNullStringHandler(rdr["CardId"]);
                    dr["手机"] = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    dr["Email"] = ComUtility.DBNullStringHandler(rdr["Email"]);
                    dr["卡号"] = rdr["CardSn"] == DBNull.Value || String.IsNullOrWhiteSpace(rdr["CardSn"].ToString()) ? String.Empty : ComUtility.GetCardSn16to10(rdr["CardSn"].ToString());
                    data.Rows.Add(dr);
                }
            }
            return data;
        }
    }
}
