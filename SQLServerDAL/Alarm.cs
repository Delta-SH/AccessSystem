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
    /// This class is an implementation for receiving alarms information from database
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// Get all alarms.
        /// </summary>
        /// <returns>alarms</returns>
        public List<AlarmInfo> GetAlarms() {
            var alarms = new List<AlarmInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_AM_GetAlarms, null)) {
                while (rdr.Read()) {
                    var alarm = new AlarmInfo();
                    alarm.SerialNO = ComUtility.DBNullInt32Handler(rdr["SerialNO"]);
                    alarm.Area1Name = ComUtility.DBNullStringHandler(rdr["Area1Name"]);
                    alarm.Area2Name = ComUtility.DBNullStringHandler(rdr["Area2Name"]);
                    alarm.Area3Name = ComUtility.DBNullStringHandler(rdr["Area3Name"]);
                    alarm.Area4Name = ComUtility.DBNullStringHandler(rdr["Area4Name"]);
                    alarm.StaName = ComUtility.DBNullStringHandler(rdr["StaName"]);
                    alarm.DevName = ComUtility.DBNullStringHandler(rdr["DevName"]);
                    alarm.DevDesc = ComUtility.DBNullStringHandler(rdr["DevDesc"]);
                    alarm.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                    alarm.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                    alarm.NodeName = ComUtility.DBNullStringHandler(rdr["NodeName"]);
                    alarm.AlarmID = ComUtility.DBNullInt32Handler(rdr["AlarmID"]);
                    alarm.AlarmValue = ComUtility.DBNullFloatHandler(rdr["AlarmValue"]);
                    alarm.AlarmLevel = ComUtility.DBNullAlarmLevelHandler(rdr["AlarmLevel"]);
                    alarm.AlarmStatus = ComUtility.DBNullAlarmStatusHandler(rdr["AlarmStatus"]);
                    alarm.AlarmDesc = ComUtility.DBNullStringHandler(rdr["AlarmDesc"]);
                    alarm.AuxAlarmDesc = ComUtility.DBNullStringHandler(rdr["AuxAlarmDesc"]);
                    alarm.StartTime = ComUtility.DBNullDateTimeHandler(rdr["StartTime"]);
                    alarm.ConfirmName = ComUtility.DBNullStringHandler(rdr["ConfirmName"]);
                    alarm.ConfirmMarking = ComUtility.DBNullConfirmMarkingHandler(rdr["ConfirmMarking"]);
                    alarm.ConfirmTime = ComUtility.DBNullDateTimeHandler(rdr["ConfirmTime"]);
                    alarm.AuxSet = ComUtility.DBNullStringHandler(rdr["AuxSet"]);
                    alarm.TaskID = ComUtility.DBNullStringHandler(rdr["TaskID"]);
                    alarm.ProjName = ComUtility.DBNullStringHandler(rdr["ProjName"]);
                    alarm.TurnCount = ComUtility.DBNullInt32Handler(rdr["TurnCount"]);
                    alarm.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["UpdateTime"]);

                    alarms.Add(alarm);
                }
            }
            return alarms;
        }

        /// <summary>
        /// Get history alarms.
        /// </summary>
        /// <param name="area2">area2</param>
        /// <param name="area3">area3</param>
        /// <param name="sta">sta</param>
        /// <param name="dev">dev</param>
        /// <param name="node">node</param>
        /// <param name="level">level</param>
        /// <param name="bfTime">bfTime</param>
        /// <param name="btTime">btTime</param>
        /// <param name="efTime">efTime</param>
        /// <param name="etTime">etTime</param>
        /// <param name="fInterval">fInterval</param>
        /// <param name="eInterval">eInterval</param>
        /// <returns>history alarms</returns>
        public List<AlarmInfo> GetHisAlarms(String area2, String area3, String sta, String dev, String node, EnmAlarmLevel level, DateTime bfTime, DateTime btTime, DateTime efTime, DateTime etTime, Int32 fInterval, Int32 eInterval) {
            SqlParameter[] parms = { new SqlParameter("@Area2Name", SqlDbType.VarChar,40),
                                     new SqlParameter("@Area3Name", SqlDbType.VarChar,40),
                                     new SqlParameter("@StaName", SqlDbType.VarChar,40),
                                     new SqlParameter("@DevName", SqlDbType.VarChar,40),
                                     new SqlParameter("@NodeName", SqlDbType.VarChar,40),
                                     new SqlParameter("@AlarmLevel", SqlDbType.Int),
                                     new SqlParameter("@BeginFromTime", SqlDbType.DateTime),
                                     new SqlParameter("@BeginToTime", SqlDbType.DateTime),
                                     new SqlParameter("@EndFromTime", SqlDbType.DateTime),
                                     new SqlParameter("@EndToTime", SqlDbType.DateTime),
                                     new SqlParameter("@FromInterval", SqlDbType.Int),
                                     new SqlParameter("@EndInterval", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullStringChecker(area2);
            parms[1].Value = ComUtility.DBNullStringChecker(area3);
            parms[2].Value = ComUtility.DBNullStringChecker(sta);
            parms[3].Value = ComUtility.DBNullStringChecker(dev);
            parms[4].Value = ComUtility.DBNullStringChecker(node);
            parms[5].Value = ComUtility.DBNullAlarmLevelChecker(level);
            parms[6].Value = ComUtility.DBNullDateTimeChecker(bfTime);
            parms[7].Value = ComUtility.DBNullDateTimeChecker(btTime);
            parms[8].Value = ComUtility.DBNullDateTimeChecker(efTime);
            parms[9].Value = ComUtility.DBNullDateTimeChecker(etTime);
            parms[10].Value = ComUtility.DBNullInt32Checker(fInterval);
            parms[11].Value = ComUtility.DBNullInt32Checker(eInterval);

            var alarms = new List<AlarmInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.HisConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_AM_GetHisAlarms, parms)) {
                while (rdr.Read()) {
                    var alarm = new AlarmInfo();
                    alarm.SerialNO = ComUtility.DBNullInt32Handler(rdr["SerialNO"]);
                    alarm.Area1Name = ComUtility.DBNullStringHandler(rdr["Area1Name"]);
                    alarm.Area2Name = ComUtility.DBNullStringHandler(rdr["Area2Name"]);
                    alarm.Area3Name = ComUtility.DBNullStringHandler(rdr["Area3Name"]);
                    alarm.Area4Name = ComUtility.DBNullStringHandler(rdr["Area4Name"]);
                    alarm.StaName = ComUtility.DBNullStringHandler(rdr["StaName"]);
                    alarm.DevName = ComUtility.DBNullStringHandler(rdr["DevName"]);
                    alarm.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                    alarm.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                    alarm.NodeName = ComUtility.DBNullStringHandler(rdr["NodeName"]);
                    alarm.AlarmID = ComUtility.DBNullInt32Handler(rdr["AlarmID"]);
                    alarm.AlarmValue = ComUtility.DBNullFloatHandler(rdr["AlarmValue"]);
                    alarm.AlarmLevel = ComUtility.DBNullAlarmLevelHandler(rdr["AlarmLevel"]);
                    alarm.AlarmDesc = ComUtility.DBNullStringHandler(rdr["AlarmDesc"]);
                    alarm.AuxAlarmDesc = ComUtility.DBNullStringHandler(rdr["AuxAlarmDesc"]);
                    alarm.StartTime = ComUtility.DBNullDateTimeHandler(rdr["StartTime"]);
                    alarm.EndTime = ComUtility.DBNullDateTimeHandler(rdr["EndTime"]);
                    alarm.ConfirmName = ComUtility.DBNullStringHandler(rdr["ConfirmName"]);
                    alarm.ConfirmMarking = ComUtility.DBNullConfirmMarkingHandler(rdr["ConfirmMarking"]);
                    alarm.ConfirmTime = ComUtility.DBNullDateTimeHandler(rdr["ConfirmTime"]);
                    alarm.ProjName = ComUtility.DBNullStringHandler(rdr["ProjName"]);

                    alarms.Add(alarm);
                }
            }
            return alarms;
        }
    }
}
