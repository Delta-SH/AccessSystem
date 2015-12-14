using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.MPS.Model;
using System.Data.SqlClient;
using System.Data;
using Delta.MPS.DBUtility;

namespace Delta.MPS.SQLServerDAL
{
    /// <summary>
    /// This class is an implementation for receiving department information from database
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Get department by the specified id.
        /// </summary>
        /// <param name="deptId">department id</param>
        /// <returns>department which belong to the specified id</returns>
        public DepartmentInfo GetDepartment(String deptId) {
            SqlParameter[] parms = { new SqlParameter("@DepId", SqlDbType.NVarChar, 50) };
            parms[0].Value = deptId;

            DepartmentInfo department = null;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_DT_GetDepartment, parms)) {
                if (rdr.Read()) {
                    department = new DepartmentInfo();
                    department.ID = ComUtility.DBNullInt64Handler(rdr["ID"]);
                    department.DepId = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    department.DepName = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    department.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    department.LastDepId = ComUtility.DBNullStringHandler(rdr["LastDepId"]);
                    department.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                }
            }
            return department;
        }

        /// <summary>
        /// Save departments.
        /// </summary>
        /// <param name="departments">departments</param>
        public void SaveDepartments(List<DepartmentInfo> departments) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@DepId", SqlDbType.VarChar,50), 
                                                 new SqlParameter("@DepName", SqlDbType.NVarChar, 50), 
                                                 new SqlParameter("@Comment", SqlDbType.NVarChar,1024), 
                                                 new SqlParameter("@LastDepId", SqlDbType.VarChar,50),
                                                 new SqlParameter("@Enabled", SqlDbType.Bit) };

                        foreach (var department in departments) {
                            parms[0].Value = department.DepId;
                            parms[1].Value = department.DepName;
                            parms[2].Value = department.Comment;
                            parms[3].Value = department.LastDepId;
                            parms[4].Value = department.Enabled;

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_DT_SaveDepartments, parms);
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
        /// Delete departments.
        /// </summary>
        /// <param name="deptIds">departments Id</param>
        public void DeleteDepartments(List<String> deptIds) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@DepId", SqlDbType.NVarChar, 50) };
                        foreach (var id in deptIds) {
                            parms[0].Value = id;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_DT_DeleteDepartment, parms);
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
        /// Get Max Department ID.
        /// </summary>
        /// <returns>Max Department ID</returns>
        public Int64 GetMaxDepartmentID() {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var maxId = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_DT_GetMaxDepartmentID, null);
                return maxId != null && maxId != DBNull.Value ? Convert.ToInt64(maxId) : 0;
            }
        }

        /// <summary>
        /// Exist employees in department.
        /// </summary>
        /// <param name="deptId">department Id</param>
        /// <returns>true/false</returns>
        public bool ExistEmployeesInDepartment(String deptId) {
            SqlParameter[] parms = { new SqlParameter("@DepId", SqlDbType.NVarChar, 50) };
            parms[0].Value = deptId;
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var cnt = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_DT_ExistEmployeesInDepartment, parms);
                return Convert.ToInt32(cnt) > 0;
            }
        }

        /// <summary>
        /// Exist department.
        /// </summary>
        /// <param name="deptId">deptId</param>
        /// <returns>true/false</returns>
        public bool ExistDepartment(String deptId) {
            SqlParameter[] parms = { new SqlParameter("@DepId", SqlDbType.VarChar, 50) };
            parms[0].Value = deptId;

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var cnt = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_DT_ExistDepartment, parms);
                return Convert.ToInt32(cnt) > 0;
            }
        }
    }
}
