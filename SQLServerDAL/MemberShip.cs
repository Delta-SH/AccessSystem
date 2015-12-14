using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;

namespace Delta.MPS.SQLServerDAL
{
    /// <summary>
    /// This class is an implementation for receiving member ship information from database
    /// </summary>
    public class MemberShip
    {
        /// <summary>
        /// Get role by the specified id.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>the specified role.</returns>
        public RoleInfo GetRole(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = roleId;

            RoleInfo role = null;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetRole, parms)) {
                if (rdr.Read()) {
                    role = new RoleInfo();
                    role.RoleID = ComUtility.DBNullGuidHandler(rdr["RoleId"]);
                    role.RoleName = ComUtility.DBNullStringHandler(rdr["RoleName"]);
                    role.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    role.LastRoleID = ComUtility.DBNullGuidHandler(rdr["LastRoleId"]);
                    role.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                }
            }
            return role;
        }

        /// <summary>
        /// Get role with authorizations by the specified id.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>the specified role.</returns>
        public RoleInfo GetRoleWithAuthorizations(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = roleId;

            RoleInfo role = null;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetRole, parms)) {
                if (rdr.Read()) {
                    role = new RoleInfo();
                    role.RoleID = ComUtility.DBNullGuidHandler(rdr["RoleId"]);
                    role.RoleName = ComUtility.DBNullStringHandler(rdr["RoleName"]);
                    role.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    role.LastRoleID = ComUtility.DBNullGuidHandler(rdr["LastRoleId"]);
                    role.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    role.Authorizations = GetRoleAuthorizations(role.RoleID);
                    role.Nodes = GetRoleNodes(role.RoleID);
                    role.Departments = GetRoleDepartments(role.RoleID);
                }
            }
            return role;
        }

        /// <summary>
        /// Get all roles.
        /// </summary>
        /// <returns>all roles</returns>
        public List<RoleInfo> GetRoles() {
            var roles = new List<RoleInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetRoles, null)) {
                while (rdr.Read()) {
                    var role = new RoleInfo();
                    role.RoleID = ComUtility.DBNullGuidHandler(rdr["RoleId"]);
                    role.RoleName = ComUtility.DBNullStringHandler(rdr["RoleName"]);
                    role.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    role.LastRoleID = ComUtility.DBNullGuidHandler(rdr["LastRoleId"]);
                    role.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    roles.Add(role);
                }
            }
            return roles;
        }

        /// <summary>
        /// Get sub roles.
        /// </summary>
        /// <returns>all roles</returns>
        public List<RoleInfo> GetSubRoles(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = roleId;

            var roles = new List<RoleInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetSubRoles, parms)) {
                while (rdr.Read()) {
                    var role = new RoleInfo();
                    role.RoleID = ComUtility.DBNullGuidHandler(rdr["RoleId"]);
                    role.RoleName = ComUtility.DBNullStringHandler(rdr["RoleName"]);
                    role.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    role.LastRoleID = ComUtility.DBNullGuidHandler(rdr["LastRoleId"]);
                    role.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    roles.Add(role);
                }
            }
            return roles;
        }

        /// <summary>
        /// Get role authorizations.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>role authorizations</returns>
        public List<AuthorizationInfo> GetRoleAuthorizations(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = ComUtility.DBNullSuperChecker(roleId);

            var authorizations = new List<AuthorizationInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetRoleAuthorizations, parms)) {
                while (rdr.Read()) {
                    var authorization = new AuthorizationInfo();
                    authorization.AuthId = ComUtility.DBNullInt32Handler(rdr["AuthId"]);
                    authorization.AuthName = ComUtility.DBNullStringHandler(rdr["AuthName"]);
                    authorization.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    authorization.LastAuthId = ComUtility.DBNullInt32Handler(rdr["LastAuthId"]);
                    authorization.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    authorizations.Add(authorization);
                }
            }
            return authorizations;
        }

        /// <summary>
        /// Get role nodes.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>role nodes</returns>
        public List<NodeLevelInfo> GetRoleNodes(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@AreaType", SqlDbType.Int),
                                     new SqlParameter("@StaType", SqlDbType.Int),
                                     new SqlParameter("@DevType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(roleId);
            parms[1].Value = (int)EnmNodeType.Area;
            parms[2].Value = (int)EnmNodeType.Sta;
            parms[3].Value = (int)EnmNodeType.Dev;

            var nodes = new List<NodeLevelInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetRoleNodes, parms)) {
                while (rdr.Read()) {
                    var node = new NodeLevelInfo();
                    node.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeId"]);
                    node.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                    node.NodeName = ComUtility.DBNullStringHandler(rdr["NodeName"]);
                    node.LastNodeID = ComUtility.DBNullInt32Handler(rdr["LastNodeId"]);
                    node.SortIndex = ComUtility.DBNullInt32Handler(rdr["SortIndex"]);
                    node.Status = EnmAlarmLevel.NoAlarm;
                    node.Remark = ComUtility.DBNullStringHandler(rdr["Remark"]);
                    nodes.Add(node);
                }
            }
            return nodes;
        }

        /// <summary>
        /// Get role departments.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>role departments</returns>
        public List<DepartmentInfo> GetRoleDepartments(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = ComUtility.DBNullSuperChecker(roleId);

            var departments = new List<DepartmentInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetRoleDepartments, parms)) {
                while (rdr.Read()) {
                    var department = new DepartmentInfo();
                    department.ID = ComUtility.DBNullInt64Handler(rdr["ID"]);
                    department.DepId = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    department.DepName = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    department.LastDepId = ComUtility.DBNullStringHandler(rdr["LastDepId"]);
                    department.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    department.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    departments.Add(department);
                }
            }
            return departments;
        }

        /// <summary>
        /// Get role devices.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>role devices</returns>
        public Dictionary<Int32, DeviceInfo> GetRoleDevices(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@DevType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(roleId);
            parms[1].Value = (int)EnmNodeType.Dev;

            var devices = new Dictionary<Int32, DeviceInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetRoleDevices, parms)) {
                while (rdr.Read()) {
                    var dev = new DeviceInfo();
                    dev.Area1ID = ComUtility.DBNullInt32Handler(rdr["Area1ID"]);
                    dev.Area1Name = ComUtility.DBNullStringHandler(rdr["Area1Name"]);
                    dev.Area2ID = ComUtility.DBNullInt32Handler(rdr["Area2ID"]);
                    dev.Area2Name = ComUtility.DBNullStringHandler(rdr["Area2Name"]);
                    dev.Area3ID = ComUtility.DBNullInt32Handler(rdr["Area3ID"]);
                    dev.Area3Name = ComUtility.DBNullStringHandler(rdr["Area3Name"]);
                    dev.StaID = ComUtility.DBNullInt32Handler(rdr["StaID"]);
                    dev.StaName = ComUtility.DBNullStringHandler(rdr["StaName"]);
                    dev.DevID = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                    dev.DevName = ComUtility.DBNullStringHandler(rdr["DevName"]);
                    dev.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    dev.Nodes = null;
                    dev.CardRecord = null;
                    devices[dev.DevID] = dev;
                }
            }
            return devices;
        }

        /// <summary>
        /// Check the specified role exists.
        /// </summary>
        /// <param name="RoleName">Role Name</param>
        public Boolean RoleExists(String RoleName) {
            SqlParameter[] parms = { new SqlParameter("@RoleName", SqlDbType.NVarChar, 50) };
            parms[0].Value = RoleName;

            var cnt = SQLHelper.ExecuteScalar(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_RoleExists, parms);
            if (cnt != null && cnt != DBNull.Value) { return Convert.ToInt32(cnt) > 0; }
            return false;
        }

        /// <summary>
        /// Check user exists by the specified role.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public Boolean RoleUserExists(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = roleId;

            var cnt = SQLHelper.ExecuteScalar(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_RoleUserExists, parms);
            if (cnt != null && cnt != DBNull.Value) { return Convert.ToInt32(cnt) > 0; }
            return false;
        }

        /// <summary>
        /// Save roles.
        /// </summary>
        /// <param name="roles">the roles which will be saved.</param>
        public void SaveRoles(List<RoleInfo> roles) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] roleParms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier), 
                                                     new SqlParameter("@RoleName", SqlDbType.NVarChar, 50), 
                                                     new SqlParameter("@Comment", SqlDbType.NVarChar,1024), 
                                                     new SqlParameter("@LastRoleId", SqlDbType.UniqueIdentifier), 
                                                     new SqlParameter("@Enabled", SqlDbType.Bit) };

                        SqlParameter[] clearParms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };

                        SqlParameter[] authParms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier), 
                                                     new SqlParameter("@AuthId", SqlDbType.Int) };

                        SqlParameter[] nodeParms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier), 
                                                     new SqlParameter("@NodeId", SqlDbType.Int), 
                                                     new SqlParameter("@NodeType", SqlDbType.Int), 
                                                     new SqlParameter("@LastNodeId", SqlDbType.Int), 
                                                     new SqlParameter("@SortIndex", SqlDbType.Int) };

                        SqlParameter[] deptParms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier), 
                                                     new SqlParameter("@DepId", SqlDbType.VarChar, 50) };

                        foreach (var role in roles) {
                            roleParms[0].Value = role.RoleID;
                            roleParms[1].Value = role.RoleName;
                            roleParms[2].Value = ComUtility.DBNullStringChecker(role.Comment);
                            roleParms[3].Value = role.LastRoleID;
                            roleParms[4].Value = role.Enabled;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_SaveRoles_Role, roleParms);

                            clearParms[0].Value = role.RoleID;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_SaveRoles_ClearXInRoles, clearParms);

                            foreach (var auth in role.Authorizations) {
                                authParms[0].Value = role.RoleID;
                                authParms[1].Value = auth.AuthId;
                                SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_SaveRoles_AddAuthorizationInRoles, authParms);
                            }

                            foreach (var node in role.Nodes) {
                                nodeParms[0].Value = role.RoleID;
                                nodeParms[1].Value = node.NodeID;
                                nodeParms[2].Value = (int)node.NodeType;
                                nodeParms[3].Value = node.LastNodeID;
                                nodeParms[4].Value = node.SortIndex;
                                SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_SaveRoles_AddNodeInRoles, nodeParms);
                            }

                            foreach (var dept in role.Departments) {
                                deptParms[0].Value = role.RoleID;
                                deptParms[1].Value = dept.DepId;
                                SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_SaveRoles_AddDepartmentInRoles, deptParms);
                            }
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
        /// Verify roles.
        /// </summary>
        /// <param name="roles">the roles which will be verified.</param>
        public void VerifyRoles(List<RoleInfo> roles) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
                        foreach (var id in roles) {
                            parms[0].Value = id.RoleID;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_VerifyRoles, parms);
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
        /// Delete roles.
        /// </summary>
        /// <param name="roles">the roles which will be deleted.</param>
        public void DelRoles(List<RoleInfo> roles) {
            DelRoles(roles.Select(r => r.RoleID).ToList());
        }

        /// <summary>
        /// Delete roles.
        /// </summary>
        /// <param name="roles">the roles which will be deleted.</param>
        public void DelRoles(List<Guid> roleIds) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
                        foreach (var id in roleIds) {
                            parms[0].Value = id;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_DeleteRoles, parms);
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
        /// Get user by the specified name.
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>user information.</returns>
        public UserInfo GetUser(String userName) {
            SqlParameter[] parms = { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parms[0].Value = ComUtility.DBNullStringChecker(userName);

            UserInfo user = null;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetUserByName, parms)) {
                if (rdr.Read()) {
                    user = new UserInfo();
                    user.Role = new RoleInfo();
                    user.Role.RoleID = ComUtility.DBNullGuidHandler(rdr["RoleId"]);
                    user.Role.RoleName = ComUtility.DBNullStringHandler(rdr["RoleName"]);
                    user.UserID = ComUtility.DBNullGuidHandler(rdr["UserId"]);
                    user.UserName = ComUtility.DBNullStringHandler(rdr["UserName"]);
                    user.RemarkName = ComUtility.DBNullStringHandler(rdr["RemarkName"]);
                    user.Password = ComUtility.DBNullStringHandler(rdr["Password"]);
                    user.PasswordFormat = ComUtility.DBNullPasswordFormatHandler(rdr["PasswordFormat"]);
                    user.PasswordSalt = ComUtility.DBNullStringHandler(rdr["PasswordSalt"]);
                    user.MobilePhone = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    user.Email = ComUtility.DBNullStringHandler(rdr["Email"]);
                    user.CreateDate = ComUtility.DBNullDateTimeHandler(rdr["CreateDate"]);
                    user.LimitDate = ComUtility.DBNullDateTimeHandler(rdr["LimitDate"]);
                    user.LastLoginDate = ComUtility.DBNullDateTimeHandler(rdr["LastLoginDate"]);
                    user.LastPasswordChangedDate = ComUtility.DBNullDateTimeHandler(rdr["LastPasswordChangedDate"]);
                    user.FailedPasswordAttemptCount = ComUtility.DBNullInt32Handler(rdr["FailedPasswordAttemptCount"]);
                    user.FailedPasswordDate = ComUtility.DBNullDateTimeHandler(rdr["FailedPasswordDate"]);
                    user.IsLockedOut = ComUtility.DBNullBooleanHandler(rdr["IsLockedOut"]);
                    user.LastLockoutDate = ComUtility.DBNullDateTimeHandler(rdr["LastLockoutDate"]);
                    user.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    user.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                }
            }
            return user;
        }

        /// <summary>
        /// Get user by the specified id.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>user information.</returns>
        public UserInfo GetUser(Guid userId) {
            SqlParameter[] parms = { new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = userId;

            UserInfo user = null;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetUserByID, parms)) {
                if (rdr.Read()) {
                    user = new UserInfo();
                    user.Role = new RoleInfo();
                    user.Role.RoleID = ComUtility.DBNullGuidHandler(rdr["RoleId"]);
                    user.Role.RoleName = ComUtility.DBNullStringHandler(rdr["RoleName"]);
                    user.UserID = ComUtility.DBNullGuidHandler(rdr["UserId"]);
                    user.UserName = ComUtility.DBNullStringHandler(rdr["UserName"]);
                    user.RemarkName = ComUtility.DBNullStringHandler(rdr["RemarkName"]);
                    user.Password = ComUtility.DBNullStringHandler(rdr["Password"]);
                    user.PasswordFormat = ComUtility.DBNullPasswordFormatHandler(rdr["PasswordFormat"]);
                    user.PasswordSalt = ComUtility.DBNullStringHandler(rdr["PasswordSalt"]);
                    user.MobilePhone = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    user.Email = ComUtility.DBNullStringHandler(rdr["Email"]);
                    user.CreateDate = ComUtility.DBNullDateTimeHandler(rdr["CreateDate"]);
                    user.LimitDate = ComUtility.DBNullDateTimeHandler(rdr["LimitDate"]);
                    user.LastLoginDate = ComUtility.DBNullDateTimeHandler(rdr["LastLoginDate"]);
                    user.LastPasswordChangedDate = ComUtility.DBNullDateTimeHandler(rdr["LastPasswordChangedDate"]);
                    user.FailedPasswordAttemptCount = ComUtility.DBNullInt32Handler(rdr["FailedPasswordAttemptCount"]);
                    user.FailedPasswordDate = ComUtility.DBNullDateTimeHandler(rdr["FailedPasswordDate"]);
                    user.IsLockedOut = ComUtility.DBNullBooleanHandler(rdr["IsLockedOut"]);
                    user.LastLockoutDate = ComUtility.DBNullDateTimeHandler(rdr["LastLockoutDate"]);
                    user.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    user.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                }
            }
            return user;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>users information.</returns>
        public List<UserInfo> GetUsers() {
            var users = new List<UserInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetUsers, null)) {
                while (rdr.Read()) {
                    var user = new UserInfo();
                    user.Role = new RoleInfo();
                    user.Role.RoleID = ComUtility.DBNullGuidHandler(rdr["RoleId"]);
                    user.Role.RoleName = ComUtility.DBNullStringHandler(rdr["RoleName"]);
                    user.UserID = ComUtility.DBNullGuidHandler(rdr["UserId"]);
                    user.UserName = ComUtility.DBNullStringHandler(rdr["UserName"]);
                    user.RemarkName = ComUtility.DBNullStringHandler(rdr["RemarkName"]);
                    user.Password = ComUtility.DBNullStringHandler(rdr["Password"]);
                    user.PasswordFormat = ComUtility.DBNullPasswordFormatHandler(rdr["PasswordFormat"]);
                    user.PasswordSalt = ComUtility.DBNullStringHandler(rdr["PasswordSalt"]);
                    user.MobilePhone = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    user.Email = ComUtility.DBNullStringHandler(rdr["Email"]);
                    user.CreateDate = ComUtility.DBNullDateTimeHandler(rdr["CreateDate"]);
                    user.LimitDate = ComUtility.DBNullDateTimeHandler(rdr["LimitDate"]);
                    user.LastLoginDate = ComUtility.DBNullDateTimeHandler(rdr["LastLoginDate"]);
                    user.LastPasswordChangedDate = ComUtility.DBNullDateTimeHandler(rdr["LastPasswordChangedDate"]);
                    user.FailedPasswordAttemptCount = ComUtility.DBNullInt32Handler(rdr["FailedPasswordAttemptCount"]);
                    user.FailedPasswordDate = ComUtility.DBNullDateTimeHandler(rdr["FailedPasswordDate"]);
                    user.IsLockedOut = ComUtility.DBNullBooleanHandler(rdr["IsLockedOut"]);
                    user.LastLockoutDate = ComUtility.DBNullDateTimeHandler(rdr["LastLockoutDate"]);
                    user.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    user.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    users.Add(user);
                }
            }
            return users;
        }

        /// <summary>
        /// Get users which belong to the specified role.
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>users information.</returns>
        public List<UserInfo> GetUsers(Guid roleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier) };
            parms[0].Value = roleId;

            var users = new List<UserInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetUsersByRoleId, parms)) {
                while (rdr.Read()) {
                    var user = new UserInfo();
                    user.Role = new RoleInfo();
                    user.Role.RoleID = ComUtility.DBNullGuidHandler(rdr["RoleId"]);
                    user.Role.RoleName = ComUtility.DBNullStringHandler(rdr["RoleName"]);
                    user.UserID = ComUtility.DBNullGuidHandler(rdr["UserId"]);
                    user.UserName = ComUtility.DBNullStringHandler(rdr["UserName"]);
                    user.RemarkName = ComUtility.DBNullStringHandler(rdr["RemarkName"]);
                    user.Password = ComUtility.DBNullStringHandler(rdr["Password"]);
                    user.PasswordFormat = ComUtility.DBNullPasswordFormatHandler(rdr["PasswordFormat"]);
                    user.PasswordSalt = ComUtility.DBNullStringHandler(rdr["PasswordSalt"]);
                    user.MobilePhone = ComUtility.DBNullStringHandler(rdr["MobilePhone"]);
                    user.Email = ComUtility.DBNullStringHandler(rdr["Email"]);
                    user.CreateDate = ComUtility.DBNullDateTimeHandler(rdr["CreateDate"]);
                    user.LimitDate = ComUtility.DBNullDateTimeHandler(rdr["LimitDate"]);
                    user.LastLoginDate = ComUtility.DBNullDateTimeHandler(rdr["LastLoginDate"]);
                    user.LastPasswordChangedDate = ComUtility.DBNullDateTimeHandler(rdr["LastPasswordChangedDate"]);
                    user.FailedPasswordAttemptCount = ComUtility.DBNullInt32Handler(rdr["FailedPasswordAttemptCount"]);
                    user.FailedPasswordDate = ComUtility.DBNullDateTimeHandler(rdr["FailedPasswordDate"]);
                    user.IsLockedOut = ComUtility.DBNullBooleanHandler(rdr["IsLockedOut"]);
                    user.LastLockoutDate = ComUtility.DBNullDateTimeHandler(rdr["LastLockoutDate"]);
                    user.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    user.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    users.Add(user);
                }
            }
            return users;
        }

        /// <summary>
        /// Check the specified user exists.
        /// </summary>
        /// <param name="UserName">User Name</param>
        public Boolean UserExists(String UserName) {
            SqlParameter[] parms = { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parms[0].Value = UserName;

            var cnt = SQLHelper.ExecuteScalar(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_UserExists, parms);
            if (cnt != null && cnt != DBNull.Value) { return Convert.ToInt32(cnt) > 0; }
            return false;
        }

        /// <summary>
        /// Create user.
        /// </summary>
        /// <param name="user">user</param>
        public void CreateUser(UserInfo user) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                                 new SqlParameter("@UserId", SqlDbType.UniqueIdentifier), 
                                                 new SqlParameter("@UserName", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@RemarkName", SqlDbType.NVarChar, 50),
                                                 new SqlParameter("@Password", SqlDbType.VarChar, 128),
                                                 new SqlParameter("@PasswordFormat", SqlDbType.Int),
                                                 new SqlParameter("@PasswordSalt", SqlDbType.VarChar, 128),
                                                 new SqlParameter("@MobilePhone", SqlDbType.VarChar, 20),
                                                 new SqlParameter("@Email", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@CreateDate", SqlDbType.DateTime),
                                                 new SqlParameter("@LimitDate", SqlDbType.DateTime),
                                                 new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
                                                 new SqlParameter("@LastPasswordChangedDate", SqlDbType.DateTime),
                                                 new SqlParameter("@FailedPasswordAttemptCount", SqlDbType.Int),
                                                 new SqlParameter("@FailedPasswordDate", SqlDbType.DateTime),
                                                 new SqlParameter("@IsLockedOut", SqlDbType.Bit),
                                                 new SqlParameter("@LastLockoutDate", SqlDbType.DateTime),
                                                 new SqlParameter("@Comment", SqlDbType.NVarChar,1024),
                                                 new SqlParameter("@Enabled", SqlDbType.Bit) };

                        parms[0].Value = user.Role.RoleID;
                        parms[1].Value = user.UserID;
                        parms[2].Value = user.UserName;
                        parms[3].Value = ComUtility.DBNullStringChecker(user.RemarkName);
                        parms[4].Value = user.Password;
                        parms[5].Value = (int)user.PasswordFormat;
                        parms[6].Value = user.PasswordSalt;
                        parms[7].Value = ComUtility.DBNullStringChecker(user.MobilePhone);
                        parms[8].Value = ComUtility.DBNullStringChecker(user.Email);
                        parms[9].Value = user.CreateDate;
                        parms[10].Value = user.LimitDate;
                        parms[11].Value = DBNull.Value;
                        parms[12].Value = DBNull.Value;
                        parms[13].Value = 0;
                        parms[14].Value = DBNull.Value;
                        parms[15].Value = false;
                        parms[16].Value = DBNull.Value;
                        parms[17].Value = ComUtility.DBNullStringChecker(user.Comment);
                        parms[18].Value = user.Enabled;
                        SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_CreateUser, parms);

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Save user.
        /// </summary>
        /// <param name="user">user</param>
        public void SaveUser(UserInfo user) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                                 new SqlParameter("@UserId", SqlDbType.UniqueIdentifier), 
                                                 new SqlParameter("@UserName", SqlDbType.VarChar, 50), 
                                                 new SqlParameter("@RemarkName", SqlDbType.NVarChar, 50),
                                                 new SqlParameter("@MobilePhone", SqlDbType.VarChar, 20),
                                                 new SqlParameter("@Email", SqlDbType.VarChar, 50),
                                                 new SqlParameter("@LimitDate", SqlDbType.DateTime),
                                                 new SqlParameter("@Comment", SqlDbType.NVarChar,1024),
                                                 new SqlParameter("@Enabled", SqlDbType.Bit) };

                        parms[0].Value = user.Role.RoleID;
                        parms[1].Value = user.UserID;
                        parms[2].Value = user.UserName;
                        parms[3].Value = ComUtility.DBNullStringChecker(user.RemarkName);
                        parms[4].Value = ComUtility.DBNullStringChecker(user.MobilePhone);
                        parms[5].Value = ComUtility.DBNullStringChecker(user.Email);
                        parms[6].Value = user.LimitDate;
                        parms[7].Value = ComUtility.DBNullStringChecker(user.Comment);
                        parms[8].Value = user.Enabled;
                        SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_SaveUser, parms);

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Update user.
        /// </summary>
        /// <param name="user">user</param>
        public void UpdateUser(UserInfo user) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@UserId", SqlDbType.UniqueIdentifier),
                                                     new SqlParameter("@LastLoginDate", SqlDbType.DateTime),
                                                     new SqlParameter("@FailedPasswordAttemptCount", SqlDbType.Int),
                                                     new SqlParameter("@FailedPasswordDate", SqlDbType.DateTime),
                                                     new SqlParameter("@IsLockedOut", SqlDbType.Bit),
                                                     new SqlParameter("@LastLockoutDate", SqlDbType.DateTime) };

                        parms[0].Value = user.UserID;
                        parms[1].Value = ComUtility.DBNullDateTimeChecker(user.LastLoginDate);
                        parms[2].Value = user.FailedPasswordAttemptCount;
                        parms[3].Value = ComUtility.DBNullDateTimeChecker(user.FailedPasswordDate);
                        parms[4].Value = user.IsLockedOut;
                        parms[5].Value = ComUtility.DBNullDateTimeChecker(user.LastLockoutDate);
                        SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_UpdateUser, parms);

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Change password.
        /// </summary>
        /// <param name="user">user</param>
        public void ChangePassword(UserInfo user) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@UserId", SqlDbType.UniqueIdentifier), 
                                                     new SqlParameter("@Password", SqlDbType.VarChar, 128),
                                                     new SqlParameter("@PasswordFormat", SqlDbType.Int),
                                                     new SqlParameter("@PasswordSalt", SqlDbType.VarChar, 128),
                                                     new SqlParameter("@LastPasswordChangedDate", SqlDbType.DateTime) };

                        parms[0].Value = user.UserID;
                        parms[1].Value = user.Password;
                        parms[2].Value = (int)user.PasswordFormat;
                        parms[3].Value = user.PasswordSalt;
                        parms[4].Value = user.LastPasswordChangedDate;
                        SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_ChangePassword, parms);

                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Delete users.
        /// </summary>
        /// <param name="usersId">users Id</param>
        public void DeleteUsers(List<Guid> usersId) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@UserId", SqlDbType.UniqueIdentifier) };
                        foreach (var id in usersId) {
                            parms[0].Value = id;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_DeleteUsers, parms);
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
        /// Check password.
        /// </summary>
        /// <param name="encodePwd">encode password</param>
        /// <param name="originalPwd">original password</param>
        /// <param name="passwordFormat">password format</param>
        /// <param name="salt">salt value</param>
        /// <returns>true/false</returns>
        public Boolean CheckPassword(String encodePwd, String originalPwd, EnmPasswordFormat passwordFormat, String salt) {
            return EncodePassword(originalPwd, passwordFormat, salt).Equals(encodePwd);
        }

        /// <summary>
        /// Generate salt value.
        /// </summary>
        /// <returns>salt value</returns>
        public String GenerateSalt() {
            byte[] data = new byte[0x10];
            new RNGCryptoServiceProvider().GetBytes(data);
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Encode password.
        /// </summary>
        /// <param name="password">password</param>
        /// <param name="passwordFormat">password format</param>
        /// <param name="salt">salt value</param>
        /// <returns>password</returns>
        public String EncodePassword(String password, EnmPasswordFormat passwordFormat, String salt) {
            if (passwordFormat == EnmPasswordFormat.Clear) { return password; }
            var bytes = Encoding.Unicode.GetBytes(password);
            var src = Convert.FromBase64String(salt);
            var dst = new byte[src.Length + bytes.Length];
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            var algorithm = HashAlgorithm.Create("SHA1");
            var inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// Get Client Users
        /// </summary>
        /// <param name="uId">UID</param>
        /// <returns>Client Users</returns>
        public List<ClientUserInfo> GetClientUsers(String uId) {
            SqlParameter[] parms = { new SqlParameter("@UID", SqlDbType.VarChar,20) };
            parms[0].Value = uId;

            var users = new List<ClientUserInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_MS_GetClientUsers, parms)) {
                while (rdr.Read()) {
                    var user = new ClientUserInfo();
                    user.ID = ComUtility.DBNullInt32Handler(rdr["ID"]);
                    user.ClientName = ComUtility.DBNullStringHandler(rdr["ClientName"]);
                    user.UID = ComUtility.DBNullStringHandler(rdr["UID"]);
                    user.Pwd = ComUtility.DBNullStringHandler(rdr["PWD"]);
                    user.OpLevel = ComUtility.DBNullInt32Handler(rdr["OpLevel"]);
                    user.PortVer = ComUtility.DBNullInt32Handler(rdr["PortVer"]);
                    user.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    users.Add(user);
                }
            }
            return users;
        }

        /// <summary>
        /// Verify System Data.
        /// </summary>
        public void VerifySystemData() {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_MS_VerifySystemData, null);
                        tran.Commit();
                    } catch {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}