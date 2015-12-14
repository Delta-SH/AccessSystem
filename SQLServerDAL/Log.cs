using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Delta.MPS.Model;
using System.Data.SqlClient;
using Delta.MPS.DBUtility;
using System.Data;

namespace Delta.MPS.SQLServerDAL
{
    /// <summary>
    /// This class is an implementation for write log information to database and file.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Write text log information.
        /// </summary>
        /// <param name="log">log</param>
        public void WriteTxtLog(LogInfo log) {
            var fullPath = String.Format(@"{0}\Log", Environment.CurrentDirectory);
            var runName = String.Format(@"{0}\RUN{1}.log", fullPath, DateTime.Today.ToString("yyyyMMdd"));
            var sysName = String.Format(@"{0}\SYS{1}.log", fullPath, DateTime.Today.ToString("yyyyMMdd"));
            if (!Directory.Exists(fullPath)) { Directory.CreateDirectory(fullPath); }

            if (log != null) {
                var runFile = new FileInfo(runName);
                if (runFile.Exists) {
                    using (var sw = runFile.AppendText()) {
                        sw.WriteLine(String.Format("{0} {1} {2}", log.EventTime.ToString("MM/dd HH:mm:ss"), log.Operator, log.Message));
                        sw.Close();
                    }
                } else {
                    using (var sw = runFile.CreateText()) {
                        sw.WriteLine(String.Format("{0} {1} {2}", log.EventTime.ToString("MM/dd HH:mm:ss"), log.Operator, log.Message));
                        sw.Close();
                    }
                }

                if (log.EventType == EnmMsgType.Error) {
                    var logText = new StringBuilder();
                    logText.AppendLine(String.Format("事件时间: {0}", log.EventTime.ToString("yyyy/MM/dd HH:mm:ss")));
                    logText.AppendLine(String.Format("事件级别: {0}", log.EventType));
                    logText.AppendLine(String.Format("触发对象: {0}", log.Operator));
                    logText.AppendLine(String.Format("事件来源: {0}", log.Source));
                    logText.AppendLine("事件内容:");
                    logText.AppendLine(log.Message);
                    logText.AppendLine(log.StackTrace);
                    logText.AppendLine("=======================================================================================");

                    var sysFile = new FileInfo(sysName);
                    if (sysFile.Exists) {
                        using (var sw = sysFile.AppendText()) {
                            sw.WriteLine(logText.ToString());
                            sw.Close();
                        }
                    } else {
                        using (var sw = sysFile.CreateText()) {
                            sw.WriteLine(logText.ToString());
                            sw.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Write database log information.
        /// </summary>
        /// <param name="log">log</param>
        public void WriteDBLog(LogInfo log) {
            SqlParameter[] parms = { new SqlParameter("@EventId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@EventTime", SqlDbType.DateTime), 
                                     new SqlParameter("@EventType", SqlDbType.Int), 
                                     new SqlParameter("@Operator", SqlDbType.VarChar, 50), 
                                     new SqlParameter("@Source", SqlDbType.VarChar, 256), 
                                     new SqlParameter("@Message", SqlDbType.NVarChar, 1024), 
                                     new SqlParameter("@StackTrace", SqlDbType.NVarChar, 4000) };

            parms[0].Value = log.EventId;
            parms[1].Value = log.EventTime;
            parms[2].Value = (Int32)log.EventType;
            parms[3].Value = log.Operator;
            parms[4].Value = log.Source;
            parms[5].Value = log.Message;
            parms[6].Value = ComUtility.DBNullStringChecker(log.StackTrace);

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                SQLHelper.ExecuteNonQuery(conn, CommandType.Text, SQLText.SQL_LG_WriteLog, parms);
            }
        }

        /// <summary>
        /// Clear text log information.
        /// </summary>
        /// <param name="beginDate">begin date</param>
        /// <param name="endDate">end date</param>
        /// <param name="type">log type</param>
        public void ClearTxtLog(DateTime beginDate, DateTime endDate, Int32 type) {
            var fullPath = String.Format(@"{0}\Log", Environment.CurrentDirectory);
            if (!Directory.Exists(fullPath)) { return; }

            while (beginDate <= endDate) {
                var runName = String.Format(@"{0}\RUN{1}.log", fullPath, beginDate.ToString("yyyyMMdd"));
                var sysName = String.Format(@"{0}\SYS{1}.log", fullPath, beginDate.ToString("yyyyMMdd"));
                if (type == -1 || type == 0) {
                    var sysFile = new FileInfo(sysName);
                    if (sysFile.Exists) { sysFile.Delete(); }
                }

                if (type == -1 || type == 1) {
                    var runFile = new FileInfo(runName);
                    if (runFile.Exists) { runFile.Delete(); }
                }

                beginDate = beginDate.AddDays(1);
            }
        }

        /// <summary>
        /// Clear Database Logs.
        /// </summary>
        /// <param name="beginDate">begin date</param>
        /// <param name="endDate">end date</param>
        /// <param name="type">log type</param>
        public void ClearDBLog(DateTime beginDate, DateTime endDate, Int32 type) {
            SqlParameter[] parms = { new SqlParameter("@BeginDate", SqlDbType.DateTime),
                                     new SqlParameter("@EndDate", SqlDbType.DateTime), 
                                     new SqlParameter("@EventType", SqlDbType.Int) };

            parms[0].Value = beginDate;
            parms[1].Value = endDate;
            if (type == -1) {
                parms[2].Value = DBNull.Value;
            } else {
                parms[2].Value = type;
            }

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                SQLHelper.ExecuteNonQuery(conn, CommandType.Text, SQLText.SQL_LG_ClearLog, parms);
            }
        }

        /// <summary>
        /// Get Database Logs.
        /// </summary>
        /// <param name="beginDate">begin date</param>
        /// <param name="endDate">end date</param>
        /// <param name="type">log type</param>
        /// <returns>database logs</returns>
        public List<LogInfo> GetDBLogs(DateTime beginDate, DateTime endDate, Int32 type) {
            SqlParameter[] parms = { new SqlParameter("@BeginDate", SqlDbType.DateTime),
                                     new SqlParameter("@EndDate", SqlDbType.DateTime), 
                                     new SqlParameter("@EventType", SqlDbType.Int) };

            parms[0].Value = beginDate;
            parms[1].Value = endDate;
            if (type == -1) {
                parms[2].Value = DBNull.Value;
            } else {
                parms[2].Value = type;
            }

            var logs = new List<LogInfo>(); ;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_LG_GetLogs, parms)) {
                while (rdr.Read()) {
                    var log = new LogInfo();
                    log.EventId = ComUtility.DBNullGuidHandler(rdr["EventId"]);
                    log.EventTime = ComUtility.DBNullDateTimeHandler(rdr["EventTime"]);
                    log.EventType = ComUtility.DBNullMsgTypeHandler(rdr["EventType"]);
                    log.Operator = ComUtility.DBNullStringHandler(rdr["Operator"]);
                    log.Source = ComUtility.DBNullStringHandler(rdr["Source"]);
                    log.Message = ComUtility.DBNullStringHandler(rdr["Message"]);
                    log.StackTrace = ComUtility.DBNullStringHandler(rdr["StackTrace"]);
                    logs.Add(log);
                }
            }
            return logs;
        }
    }
}
