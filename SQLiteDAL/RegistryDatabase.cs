using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;
using Delta.MPS.DBUtility;
using Delta.MPS.Model;

namespace Delta.MPS.SQLiteDAL
{
    /// <summary>
    /// The RegistryDatabase class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of System.Data.SQLite.
    /// </summary>
    public class RegistryDatabase
    {
        //Database connection parameters
        private string registryConnectionString;
        private string dbPassword;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public RegistryDatabase() {
            registryConnectionString = String.Format(@"data source={0}\Registry.db;Pooling=True;Max Pool Size=100;FailIfMissing=False", Environment.CurrentDirectory);
            dbPassword = "1qazxsw23edc";
        }

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="filePath">database file path</param>
        /// <param name="dbPwd">database password</param>
        public RegistryDatabase(string filePath, string dbPwd) {
            registryConnectionString = String.Format(@"data source={0}\Registry.db;Pooling=True;Max Pool Size=100;FailIfMissing=False", filePath);
            dbPassword = dbPwd;
        }

        /// <summary>
        /// Create registry database file.
        /// </summary>
        public void CreateRegistry() {
            try {
                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand()) {
                        command.Connection = conn;
                        command.CommandText = SQLiteText.Registry_Create_Tables;
                        command.ExecuteNonQuery();
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get database servers setting.
        /// </summary>
        /// <returns>database servers setting</returns>
        public List<DatabaseServerInfo> GetDatabaseServers() {
            try {
                var databases = new List<DatabaseServerInfo>();
                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Get_DatabaseServers, conn)) {
                        using (var rdr = command.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (rdr.Read()) {
                                var db = new DatabaseServerInfo();
                                db.UniqueID = ComUtility.DBNullGuidHandler(rdr["unique_id"]);
                                db.DatabaseIntention = ComUtility.DBNullDBIntentionHandler(rdr["database_intention"]);
                                db.DatabaseType = ComUtility.DBNullDBTypeHandler(rdr["database_type"]);
                                db.DatabaseIP = ComUtility.DBNullStringHandler(rdr["database_ip"]);
                                db.DatabasePort = ComUtility.DBNullInt32Handler(rdr["database_port"]);
                                db.DatabaseUser = ComUtility.DBNullStringHandler(rdr["database_user"]);
                                db.DatabasePwd = ComUtility.DBNullStringHandler(rdr["database_pwd"]);
                                db.DatabaseName = ComUtility.DBNullStringHandler(rdr["database_name"]);
                                db.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["update_time"]);
                                databases.Add(db);
                            }
                        }
                    }
                }

                return databases;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Save database servers setting.
        /// </summary>
        /// <param name="databases">database setting</param>
        public void SaveDatabaseServers(List<DatabaseServerInfo> databases) {
            try {
                SQLiteParameter[] parms = { new SQLiteParameter("@unique_id", DbType.Guid),
                                            new SQLiteParameter("@database_intention", DbType.Int32),
                                            new SQLiteParameter("@database_type", DbType.Int32),
                                            new SQLiteParameter("@database_ip", DbType.String,128),
                                            new SQLiteParameter("@database_port", DbType.Int32),
                                            new SQLiteParameter("@database_user", DbType.String,50),
                                            new SQLiteParameter("@database_pwd", DbType.String,50),
                                            new SQLiteParameter("@database_name", DbType.String,128),
                                            new SQLiteParameter("@update_time", DbType.DateTime)};

                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Clear_DatabaseServers, conn)) {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SQLiteCommand(SQLiteText.Registry_Save_DatabaseServers, conn)) {
                        using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                            try {
                                foreach (var db in databases) {
                                    parms[0].Value = db.UniqueID;
                                    parms[1].Value = (Int32)db.DatabaseIntention;
                                    parms[2].Value = (Int32)db.DatabaseType;
                                    parms[3].Value = ComUtility.DBNullStringChecker(db.DatabaseIP);
                                    parms[4].Value = ComUtility.DBNullInt32Checker(db.DatabasePort);
                                    parms[5].Value = ComUtility.DBNullStringChecker(db.DatabaseUser);
                                    parms[6].Value = ComUtility.DBNullStringChecker(db.DatabasePwd);
                                    parms[7].Value = ComUtility.DBNullStringChecker(db.DatabaseName);
                                    parms[8].Value = db.UpdateTime;

                                    command.Parameters.Clear();
                                    command.Parameters.AddRange(parms);
                                    command.ExecuteNonQuery();
                                }

                                tran.Commit();
                            } catch {
                                tran.Rollback();
                                throw;
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get interface paramter.
        /// </summary>
        /// <returns>interface paramter</returns>
        public InterfaceInfo GetInterfaceParamter() {
            try {
                InterfaceInfo parm = null;
                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Get_Interface, conn)) {
                        using (var rdr = command.ExecuteReader(CommandBehavior.CloseConnection)) {
                            if (rdr.Read()) {
                                parm = new InterfaceInfo();
                                parm.UniqueID = ComUtility.DBNullGuidHandler(rdr["unique_id"]);
                                parm.InterfaceIP = ComUtility.DBNullStringHandler(rdr["interface_ip"]);
                                parm.InterfacePort = ComUtility.DBNullInt32Handler(rdr["interface_port"]);
                                parm.InterfaceUser = ComUtility.DBNullStringHandler(rdr["interface_user"]);
                                parm.InterfacePwd = ComUtility.DBNullStringHandler(rdr["interface_pwd"]);
                                parm.InterfaceDetect = ComUtility.DBNullInt32Handler(rdr["interface_detect"]);
                                parm.InterfaceInterrupt = ComUtility.DBNullInt32Handler(rdr["interface_interrupt"]);
                                parm.InterfaceSyncTime = ComUtility.DBNullBooleanHandler(rdr["interface_synctime"]);
                                parm.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["update_time"]);
                            }
                        }
                    }
                }

                return parm;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Save interface paramters.
        /// </summary>
        /// <param name="paramters">interface paramters</param>
        public void SaveInterfaceParamters(InterfaceInfo paramters) {
            try {
                SQLiteParameter[] parms = { new SQLiteParameter("@unique_id", DbType.Guid),
                                            new SQLiteParameter("@interface_ip", DbType.String,128),
                                            new SQLiteParameter("@interface_port", DbType.Int32),
                                            new SQLiteParameter("@interface_user", DbType.String,50),
                                            new SQLiteParameter("@interface_pwd", DbType.String,50),
                                            new SQLiteParameter("@interface_detect", DbType.Int32),
                                            new SQLiteParameter("@interface_interrupt", DbType.Int32),
                                            new SQLiteParameter("@interface_synctime", DbType.Boolean),
                                            new SQLiteParameter("@update_time", DbType.DateTime)};

                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Save_Interface, conn)) {
                        parms[0].Value = paramters.UniqueID;
                        parms[1].Value = ComUtility.DBNullStringChecker(paramters.InterfaceIP);
                        parms[2].Value = ComUtility.DBNullInt32Checker(paramters.InterfacePort);
                        parms[3].Value = ComUtility.DBNullStringChecker(paramters.InterfaceUser);
                        parms[4].Value = ComUtility.DBNullStringChecker(paramters.InterfacePwd);
                        parms[5].Value = ComUtility.DBNullInt32Checker(paramters.InterfaceDetect);
                        parms[6].Value = ComUtility.DBNullInt32Checker(paramters.InterfaceInterrupt);
                        parms[7].Value = paramters.InterfaceSyncTime;
                        parms[8].Value = paramters.UpdateTime;

                        command.Parameters.Clear();
                        command.Parameters.AddRange(parms);
                        command.ExecuteNonQuery();
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get recent users list.
        /// </summary>
        /// <param name="limit">the max count of the recent users</param>
        /// <returns>recent users list</returns>
        public List<RecentUserInfo> GetRecentUsers(int limit) {
            try {
                SQLiteParameter[] parms = { new SQLiteParameter("@limit", DbType.Int32) };
                parms[0].Value = limit;

                var users = new List<RecentUserInfo>();
                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Get_RecentUsers, conn)) {
                        command.Parameters.AddRange(parms);
                        using (var rdr = command.ExecuteReader(CommandBehavior.CloseConnection)) {
                            while (rdr.Read()) {
                                var user = new RecentUserInfo();
                                user.UniqueID = ComUtility.DBNullGuidHandler(rdr["unique_id"]);
                                user.RecentUser = ComUtility.DBNullStringHandler(rdr["recent_user"]);
                                user.RecentPwd = ComUtility.DBNullStringHandler(rdr["recent_pwd"]);
                                user.RecentRmb = ComUtility.DBNullBooleanHandler(rdr["recent_rmb"]);
                                user.RecentLan = ComUtility.DBNullStringHandler(rdr["recent_lan"]);
                                user.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["update_time"]);
                                users.Add(user);
                            }
                        }
                    }
                }

                return users;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Save recent users list.
        /// </summary>
        /// <param name="users">recent users list</param>
        public void SaveRecentUsers(List<RecentUserInfo> users) {
            try {
                SQLiteParameter[] parms = { new SQLiteParameter("@unique_id", DbType.Guid),
                                            new SQLiteParameter("@recent_user", DbType.String,50),
                                            new SQLiteParameter("@recent_pwd", DbType.String,50),
                                            new SQLiteParameter("@recent_rmb", DbType.Boolean),
                                            new SQLiteParameter("@recent_lan", DbType.String,50),
                                            new SQLiteParameter("@update_time", DbType.DateTime)};

                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Save_RecentUsers, conn)) {
                        using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                            try {
                                foreach (var user in users) {
                                    parms[0].Value = user.UniqueID;
                                    parms[1].Value = ComUtility.DBNullStringChecker(user.RecentUser);
                                    parms[2].Value = ComUtility.DBNullStringChecker(user.RecentPwd);
                                    parms[3].Value = user.RecentRmb;
                                    parms[4].Value = user.RecentLan;
                                    parms[5].Value = user.UpdateTime;

                                    command.Parameters.Clear();
                                    command.Parameters.AddRange(parms);
                                    command.ExecuteNonQuery();
                                }

                                tran.Commit();
                            } catch {
                                tran.Rollback();
                                throw;
                            }
                        }
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Delete all recent users list.
        /// </summary>
        public void ClearRecentUsers() {
            try {
                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Clear_RecentUsers, conn)) {
                        command.ExecuteNonQuery();
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get system application.
        /// </summary>
        /// <param name="appID">application id</param>
        /// <returns>system application</returns>
        public ApplicationInfo GetSystemApplication(Guid appID) {
            try {
                SQLiteParameter[] parms = { new SQLiteParameter("@app_id", DbType.Guid) };
                parms[0].Value = appID;

                ApplicationInfo application = null;
                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Get_SystemApplication, conn)) {
                        command.Parameters.Clear();
                        command.Parameters.AddRange(parms);
                        using (var rdr = command.ExecuteReader(CommandBehavior.CloseConnection)) {
                            if (rdr.Read()) {
                                application = new ApplicationInfo();
                                application.UniqueID = ComUtility.DBNullGuidHandler(rdr["app_id"]);
                                application.AppName = ComUtility.DBNullStringHandler(rdr["app_name"]);
                                application.AppLicense = ComUtility.DBNullStringHandler(rdr["app_license"]);
                                application.AppFirstTime = ComUtility.DBNullDateTimeHandler(rdr["app_firsttime"]);
                                application.AppLastTime = ComUtility.DBNullDateTimeHandler(rdr["app_lasttime"]);
                                application.AppLoginTime = ComUtility.DBNullDateTimeHandler(rdr["app_logintime"]);
                            }
                        }
                    }
                }
                return application;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Save system application.
        /// </summary>
        /// <param name="application">system application</param>
        public void SaveSystemApplication(ApplicationInfo application) {
            try {
                SQLiteParameter[] parms = { new SQLiteParameter("@app_id", DbType.Guid),
                                            new SQLiteParameter("@app_name", DbType.String),
                                            new SQLiteParameter("@app_license", DbType.String),
                                            new SQLiteParameter("@app_firsttime", DbType.DateTime),
                                            new SQLiteParameter("@app_lasttime", DbType.DateTime),
                                            new SQLiteParameter("@app_logintime", DbType.DateTime) };

                using (var conn = new SQLiteConnection(registryConnectionString)) {
                    conn.SetPassword(dbPassword);
                    conn.Open();
                    using (var command = new SQLiteCommand(SQLiteText.Registry_Save_SystemApplication, conn)) {
                        parms[0].Value = application.UniqueID;
                        parms[1].Value = ComUtility.DBNullStringChecker(application.AppName);
                        parms[2].Value = ComUtility.DBNullStringChecker(application.AppLicense);
                        parms[3].Value = ComUtility.DBNullDateTimeChecker(application.AppFirstTime);
                        parms[4].Value = ComUtility.DBNullDateTimeChecker(application.AppLastTime);
                        parms[5].Value = ComUtility.DBNullDateTimeChecker(application.AppLoginTime);

                        command.Parameters.Clear();
                        command.Parameters.AddRange(parms);
                        command.ExecuteNonQuery();
                    }
                }
            } catch {
                throw;
            }
        }
    }
}