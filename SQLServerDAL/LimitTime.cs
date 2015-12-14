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
    /// This class is an implementation for receiving limit time information from database
    /// </summary>
    public class LimitTime
    {
        /// <summary>
        /// Get Limit Times.
        /// </summary>
        /// <param name="devId">device id</param>
        /// <returns>limit times</returns>
        public List<LimitTimeInfo> GetLimitTimes(Int32 devId) {
            try {
                SqlParameter[] parms = { new SqlParameter("@DevId", SqlDbType.Int) };
                parms[0].Value = devId;

                var times = new List<LimitTimeInfo>(); ;
                using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_LT_GetLimitTimes, parms)) {
                    while (rdr.Read()) {
                        var time = new LimitTimeInfo();
                        time.ID = ComUtility.DBNullInt32Handler(rdr["ID"]);
                        time.DevId = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                        time.LimitId = ComUtility.DBNullLimitIDHandler(rdr["LimitID"]);
                        time.LimitDesc = ComUtility.DBNullStringHandler(rdr["LimitDesc"]);
                        time.LimitIndex = ComUtility.DBNullInt32Handler(rdr["LimitIndex"]);
                        time.WeekIndex = ComUtility.DBNullInt32Handler(rdr["WeekIndex"]);
                        time.StartTime1 = ComUtility.DBNullStringHandler(rdr["StartTime1"]);
                        time.EndTime1 = ComUtility.DBNullStringHandler(rdr["EndTime1"]);
                        time.StartTime2 = ComUtility.DBNullStringHandler(rdr["StartTime2"]);
                        time.EndTime2 = ComUtility.DBNullStringHandler(rdr["EndTime2"]);
                        time.StartTime3 = ComUtility.DBNullStringHandler(rdr["StartTime3"]);
                        time.EndTime3 = ComUtility.DBNullStringHandler(rdr["EndTime3"]);
                        time.StartTime4 = ComUtility.DBNullStringHandler(rdr["StartTime4"]);
                        time.EndTime4 = ComUtility.DBNullStringHandler(rdr["EndTime4"]);
                        time.StartTime5 = ComUtility.DBNullStringHandler(rdr["StartTime5"]);
                        time.EndTime5 = ComUtility.DBNullStringHandler(rdr["EndTime5"]);
                        time.StartTime6 = ComUtility.DBNullStringHandler(rdr["StartTime6"]);
                        time.EndTime6 = ComUtility.DBNullStringHandler(rdr["EndTime6"]);
                        times.Add(time);
                    }
                }
                return times;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Save Limit Times.
        /// </summary>
        /// <param name="devIds">device ids</param>
        /// <param name="limitIds">limit ids</param>
        /// <param name="times">times</param>
        public void SaveLimitTimes(List<Int32> devIds, List<EnmLimitID> limitIds, List<LimitTimeInfo> times) {
            try {
                using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                    conn.Open();
                    using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                        try {
                            SqlParameter[] parms = { new SqlParameter("@DevId", SqlDbType.Int),
                                                     new SqlParameter("@LimitId", SqlDbType.Int) };

                            SqlParameter[] sarms = { new SqlParameter("@DevId", SqlDbType.Int),
                                                     new SqlParameter("@LimitId", SqlDbType.Int),
                                                     new SqlParameter("@LimitDesc", SqlDbType.VarChar,40),
                                                     new SqlParameter("@LimitIndex", SqlDbType.Int),
                                                     new SqlParameter("@WeekIndex", SqlDbType.Int),
                                                     new SqlParameter("@StartTime1", SqlDbType.VarChar,5),
                                                     new SqlParameter("@EndTime1", SqlDbType.VarChar,5),
                                                     new SqlParameter("@StartTime2", SqlDbType.VarChar,5),
                                                     new SqlParameter("@EndTime2", SqlDbType.VarChar,5),
                                                     new SqlParameter("@StartTime3", SqlDbType.VarChar,5),
                                                     new SqlParameter("@EndTime3", SqlDbType.VarChar,5),
                                                     new SqlParameter("@StartTime4", SqlDbType.VarChar,5),
                                                     new SqlParameter("@EndTime4", SqlDbType.VarChar,5),
                                                     new SqlParameter("@StartTime5", SqlDbType.VarChar,5),
                                                     new SqlParameter("@EndTime5", SqlDbType.VarChar,5),
                                                     new SqlParameter("@StartTime6", SqlDbType.VarChar,5),
                                                     new SqlParameter("@EndTime6", SqlDbType.VarChar,5)
                                                   };

                            foreach (var devId in devIds) {
                                foreach (var limitId in limitIds) {
                                    parms[0].Value = devId;
                                    parms[1].Value = (Int32)limitId;

                                    SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_LT_DeleteLimitTimes, parms);
                                }

                                foreach (var time in times) {
                                    sarms[0].Value = devId;
                                    sarms[1].Value = (Int32)time.LimitId;
                                    sarms[2].Value = time.LimitDesc;
                                    sarms[3].Value = time.LimitIndex;
                                    sarms[4].Value = ComUtility.DBNullInt32Checker(time.WeekIndex);
                                    sarms[5].Value = ComUtility.DBNullStringChecker(time.StartTime1);
                                    sarms[6].Value = ComUtility.DBNullStringChecker(time.EndTime1);
                                    sarms[7].Value = ComUtility.DBNullStringChecker(time.StartTime2);
                                    sarms[8].Value = ComUtility.DBNullStringChecker(time.EndTime2);
                                    sarms[9].Value = ComUtility.DBNullStringChecker(time.StartTime3);
                                    sarms[10].Value = ComUtility.DBNullStringChecker(time.EndTime3);
                                    sarms[11].Value = ComUtility.DBNullStringChecker(time.StartTime4);
                                    sarms[12].Value = ComUtility.DBNullStringChecker(time.EndTime4);
                                    sarms[13].Value = ComUtility.DBNullStringChecker(time.StartTime5);
                                    sarms[14].Value = ComUtility.DBNullStringChecker(time.EndTime5);
                                    sarms[15].Value = ComUtility.DBNullStringChecker(time.StartTime6);
                                    sarms[16].Value = ComUtility.DBNullStringChecker(time.EndTime6);

                                    SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_LT_SaveLimitTimes, sarms);
                                }
                            }

                            tran.Commit();
                        } catch {
                            tran.Rollback();
                            throw;
                        }
                    }
                }
            } catch { throw; }
        }
    }
}
