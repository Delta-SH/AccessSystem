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
    /// This class is an implementation for receiving combobox information from database
    /// </summary>
    public class ComboBoxData
    {
        /// <summary>
        /// Method to get lsc combobox information
        /// </summary>
        public Dictionary<Int32, String> GetLscs() {
            var dict = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CB_GetLsc, null)) {
                while (rdr.Read()) {
                    var id = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                    var name = ComUtility.DBNullStringHandler(rdr["LscName"]);
                    dict[id] = name;
                }
            }
            return dict;
        }

        /// <summary>
        /// Method to get area1 combobox information
        /// </summary>
        /// <param name="RoleId">Role Id</param>
        public Dictionary<Int32, String> GetArea1(Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@AreaType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[1].Value = (Int32)EnmNodeType.Area;

            var dict = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CB_GetArea1, parms)) {
                while (rdr.Read()) {
                    var id = ComUtility.DBNullInt32Handler(rdr["AreaID"]);
                    var name = ComUtility.DBNullStringHandler(rdr["AreaName"]);
                    dict[id] = name;
                }
            }
            return dict;
        }

        /// <summary>
        /// Method to get area2 combobox information
        /// </summary>
        /// <param name="Area1Id">Area1 Id</param>
        /// <param name="RoleId">Role Id</param>
        public Dictionary<Int32, String> GetArea2(Int32 Area1Id, Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@AreaID", SqlDbType.Int),
                                     new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@AreaType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullInt32Checker(Area1Id);
            parms[1].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[2].Value = (Int32)EnmNodeType.Area;

            var dict = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CB_GetArea2, parms)) {
                while (rdr.Read()) {
                    var id = ComUtility.DBNullInt32Handler(rdr["AreaID"]);
                    var name = ComUtility.DBNullStringHandler(rdr["AreaName"]);
                    dict[id] = name;
                }
            }
            return dict;
        }

        /// <summary>
        /// Method to get area3 combobox information
        /// </summary>
        /// <param name="Area2Id">Area2 Id</param>
        /// <param name="RoleId">Role Id</param>
        public Dictionary<Int32, String> GetArea3(Int32 Area2Id, Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@AreaID", SqlDbType.Int),
                                     new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@AreaType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullInt32Checker(Area2Id);
            parms[1].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[2].Value = (Int32)EnmNodeType.Area;

            var dict = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CB_GetArea3, parms)) {
                while (rdr.Read()) {
                    var id = ComUtility.DBNullInt32Handler(rdr["AreaID"]);
                    var name = ComUtility.DBNullStringHandler(rdr["AreaName"]);
                    dict[id] = name;
                }
            }
            return dict;
        }

        /// <summary>
        /// Method to get stations combobox information
        /// </summary>
        /// <param name="Area3Id">Area3 Id</param>
        /// <param name="RoleId">Role Id</param>
        public Dictionary<Int32, String> GetStations(Int32 Area3Id, Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@AreaID", SqlDbType.Int),
                                     new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@StaType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullInt32Checker(Area3Id);
            parms[1].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[2].Value = (Int32)EnmNodeType.Sta;

            var dict = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CB_GetSta, parms)) {
                while (rdr.Read()) {
                    var id = ComUtility.DBNullInt32Handler(rdr["StaID"]);
                    var name = ComUtility.DBNullStringHandler(rdr["StaName"]);
                    dict[id] = name;
                }
            }
            return dict;
        }

        /// <summary>
        /// Method to get devices combobox information
        /// </summary>
        /// <param name="Area3Id">Area3 Id</param>
        /// <param name="StaId">Station Id</param>
        /// <param name="RoleId">Role Id</param>
        public Dictionary<Int32, String> GetDevices(Int32 Area3Id, Int32 StaId, Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@AreaID", SqlDbType.Int),
                                     new SqlParameter("@StaID", SqlDbType.Int),
                                     new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@DevType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullInt32Checker(Area3Id);
            parms[1].Value = ComUtility.DBNullInt32Checker(StaId);
            parms[2].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[3].Value = (Int32)EnmNodeType.Dev;

            var dict = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CB_GetDev, parms)) {
                while (rdr.Read()) {
                    var id = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                    var name = ComUtility.DBNullStringHandler(rdr["DevName"]);
                    dict[id] = name;
                }
            }
            return dict;
        }

        /// <summary>
        /// Method to get nodes combobox information
        /// </summary>
        /// <param name="DevId">Dev Id</param>
        /// <param name="AI">AI</param>
        /// <param name="AO">AO</param>
        /// <param name="DI">DI</param>
        /// <param name="DO">DO</param>
        public Dictionary<Int32, String> GetNodes(Int32 DevId, Boolean AI, Boolean AO, Boolean DI, Boolean DO) {
            SqlParameter[] parms = { new SqlParameter("@DevID", SqlDbType.Int),
                                     new SqlParameter("@AI", SqlDbType.Bit),
                                     new SqlParameter("@AO", SqlDbType.Bit),
                                     new SqlParameter("@DI", SqlDbType.Bit),
                                     new SqlParameter("@DO", SqlDbType.Bit) };
            parms[0].Value = DevId;
            parms[1].Value = AI;
            parms[2].Value = AO;
            parms[3].Value = DI;
            parms[4].Value = DO;

            var dict = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CB_GetNodes, parms)) {
                while (rdr.Read()) {
                    var id = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                    var name = ComUtility.DBNullStringHandler(rdr["NodeName"]);
                    dict[id] = name;
                }
            }
            return dict;
        }

        /// <summary>
        /// Method to get alarm levels combobox information
        /// </summary>
        public Dictionary<Int32, String> GetAlarmLevels() {
            var dict = new Dictionary<Int32, String>();
            foreach (EnmAlarmLevel level in Enum.GetValues(typeof(EnmAlarmLevel))) {
                if (level == EnmAlarmLevel.NoAlarm) { continue; }
                dict[(Int32)level] = ComUtility.GetAlarmLevelName(level);
            }
            return dict;
        }
    }
}