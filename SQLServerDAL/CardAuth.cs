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
    /// This class is an implementation for receiving authorization information from database
    /// </summary>
    public class CardAuth
    {
        /// <summary>
        /// Get Card Authorizations By Device Id and Card Sn.
        /// </summary>
        /// <param name="DevId">Device Id</param>
        /// <param name="CardSn">Card Sn</param>
        /// <returns>Card Authorizations</returns>
        public CardAuthInfo GetCardAuth(Int32 DevId, String CardSn) {
            SqlParameter[] parms = { new SqlParameter("@DevId", SqlDbType.Int),
                                     new SqlParameter("@CardSn", SqlDbType.VarChar, 50) };
            parms[0].Value = DevId;
            parms[1].Value = ComUtility.GetCardSn10to16(CardSn);

            CardAuthInfo auth = null;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CA_GetCardAuthByCardSn, parms)) {
                if (rdr.Read()) {
                    auth = new CardAuthInfo();
                    auth.CardSn = ComUtility.DBNullStringHandler(rdr["CardSn"]);
                    auth.RtuId = ComUtility.DBNullInt32Handler(rdr["RtuId"]);
                    auth.DevId = ComUtility.DBNullInt32Handler(rdr["DevId"]);
                    auth.LimitId = ComUtility.DBNullLimitIDHandler(rdr["LimitId"]);
                    auth.LimitIndex = ComUtility.DBNullInt32Handler(rdr["LimitIndex"]);
                    auth.BeginTime = ComUtility.DBNullDateTimeHandler(rdr["BeginTime"]);
                    auth.EndTime = ComUtility.DBNullDateTimeHandler(rdr["EndTime"]);
                    auth.Password = ComUtility.DBNullStringHandler(rdr["Password"]);
                    auth.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    auth.Remark = String.Empty;

                    auth.CardSn = ComUtility.GetCardSn16to10(auth.CardSn);
                }
            }
            return auth;
        }

        /// <summary>
        /// Get Card Authorizations By Device Id.
        /// </summary>
        /// <param name="DevId">Device Id</param>
        /// <returns>Card Authorizations</returns>
        public List<CardAuthInfo> GetDevCardAuth(Int32 DevId) {
            SqlParameter[] parms = { new SqlParameter("@DevId", SqlDbType.Int) };
            parms[0].Value = DevId;

            var auths = new List<CardAuthInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CA_GetDevCardAuth, parms)) {
                while (rdr.Read()) {
                    var auth = new CardAuthInfo();
                    auth.CardSn = ComUtility.DBNullStringHandler(rdr["CardSn"]);
                    auth.RtuId = ComUtility.DBNullInt32Handler(rdr["RtuId"]);
                    auth.DevId = ComUtility.DBNullInt32Handler(rdr["DevId"]);
                    auth.LimitId = ComUtility.DBNullLimitIDHandler(rdr["LimitId"]);
                    auth.LimitIndex = ComUtility.DBNullInt32Handler(rdr["LimitIndex"]);
                    auth.BeginTime = ComUtility.DBNullDateTimeHandler(rdr["BeginTime"]);
                    auth.EndTime = ComUtility.DBNullDateTimeHandler(rdr["EndTime"]);
                    auth.Password = ComUtility.DBNullStringHandler(rdr["Password"]);
                    auth.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    auth.Remark = String.Empty;

                    auth.CardSn = ComUtility.GetCardSn16to10(auth.CardSn);
                    auths.Add(auth);
                }
            }
            return auths;
        }

        /// <summary>
        /// Get Card Authorizations By Employee Id.
        /// </summary>
        /// <param name="EmpId">Employee Id</param>
        /// <returns>Card Authorizations</returns>
        public List<CardAuthInfo> GetCardAuth(String EmpId, EnmWorkerType WorkType) {
            SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar,50),
                                     new SqlParameter("@EmpType", SqlDbType.Int) };
            parms[0].Value = EmpId;
            parms[1].Value = (Int32)WorkType;

            var auths = new List<CardAuthInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CA_GetCardAuthByEmpId, parms)) {
                while (rdr.Read()) {
                    var auth = new CardAuthInfo();
                    auth.CardSn = ComUtility.DBNullStringHandler(rdr["CardSn"]);
                    auth.RtuId = ComUtility.DBNullInt32Handler(rdr["RtuId"]);
                    auth.DevId = ComUtility.DBNullInt32Handler(rdr["DevId"]);
                    auth.LimitId = ComUtility.DBNullLimitIDHandler(rdr["LimitId"]);
                    auth.LimitIndex = ComUtility.DBNullInt32Handler(rdr["LimitIndex"]);
                    auth.BeginTime = ComUtility.DBNullDateTimeHandler(rdr["BeginTime"]);
                    auth.EndTime = ComUtility.DBNullDateTimeHandler(rdr["EndTime"]);
                    auth.Password = ComUtility.DBNullStringHandler(rdr["Password"]);
                    auth.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    auth.Remark = String.Empty;

                    auth.CardSn = ComUtility.GetCardSn16to10(auth.CardSn);
                    auths.Add(auth);
                }
            }
            return auths;
        }

        /// <summary>
        /// Get Card Authorizations By Condition.
        /// </summary>
        /// <returns>Card Authorizations</returns>
        public List<CardAuthInfo> GetCardAuthByCondition(Int32 QType, EnmWorkerType WorkType,String Filter) {
            SqlParameter[] parms = { new SqlParameter("@QType", SqlDbType.Int),
                                     new SqlParameter("@WorkType", SqlDbType.Int),
                                     new SqlParameter("@WXRY", SqlDbType.Int),
                                     new SqlParameter("@Filter", SqlDbType.NVarChar,1024) };
            parms[0].Value = QType;
            parms[1].Value = (Int32)WorkType;
            parms[2].Value = (Int32)EnmWorkerType.WXRY;
            parms[3].Value = ComUtility.DBNullStringChecker(Filter);

            var auths = new List<CardAuthInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CA_GetCardAuthByCondition, parms)) {
                while (rdr.Read()) {
                    var auth = new CardAuthInfo();
                    auth.CardSn = ComUtility.DBNullStringHandler(rdr["CardSn"]);
                    auth.RtuId = ComUtility.DBNullInt32Handler(rdr["RtuId"]);
                    auth.DevId = ComUtility.DBNullInt32Handler(rdr["DevId"]);
                    auth.LimitId = ComUtility.DBNullLimitIDHandler(rdr["LimitId"]);
                    auth.LimitIndex = ComUtility.DBNullInt32Handler(rdr["LimitIndex"]);
                    auth.BeginTime = ComUtility.DBNullDateTimeHandler(rdr["BeginTime"]);
                    auth.EndTime = ComUtility.DBNullDateTimeHandler(rdr["EndTime"]);
                    auth.Password = ComUtility.DBNullStringHandler(rdr["Password"]);
                    auth.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    auth.Remark = String.Empty;

                    auth.CardSn = ComUtility.GetCardSn16to10(auth.CardSn);
                    auths.Add(auth);
                }
            }
            return auths;
        }

        /// <summary>
        /// Delete Card Auth.
        /// </summary>
        /// <param name="Ids">Device Id and Card Sn</param>
        public void DeleteCardAuth(List<IDValuePair<Int32, String>> Ids) {
            SqlParameter[] parms = { new SqlParameter("@DevId", SqlDbType.Int), 
                                     new SqlParameter("@CardSn", SqlDbType.VarChar, 50) };

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        foreach (var id in Ids) {
                            parms[0].Value = id.ID;
                            parms[1].Value = ComUtility.GetCardSn10to16(id.Value);

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CA_DeleteCardAuth, parms);
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
        /// Save Card Auth
        /// </summary>
        /// <param name="CardAuth">Card Auth</param>
        public void SaveCardAuth(List<CardAuthInfo> CardAuth, Boolean IsSync) {
            SqlParameter[] parms = { new SqlParameter("@CardSn", SqlDbType.VarChar,50),
                                     new SqlParameter("@DevId", SqlDbType.Int), 
                                     new SqlParameter("@LimitId", SqlDbType.Int),
                                     new SqlParameter("@LimitIndex", SqlDbType.Int),
                                     new SqlParameter("@BeginTime", SqlDbType.DateTime),
                                     new SqlParameter("@EndTime", SqlDbType.DateTime),
                                     new SqlParameter("@Password", SqlDbType.VarChar,50),
                                     new SqlParameter("@Enabled", SqlDbType.Bit) };

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        var dictionary = new Dictionary<String, CardAuthInfo>();
                        foreach (var auth in CardAuth) {
                            parms[0].Value = ComUtility.GetCardSn10to16(auth.CardSn);
                            parms[1].Value = auth.DevId;
                            parms[2].Value = (Int32)auth.LimitId;
                            parms[3].Value = ComUtility.DBNullInt32Checker(auth.LimitIndex);
                            parms[4].Value = auth.BeginTime;
                            parms[5].Value = auth.EndTime;
                            parms[6].Value = ComUtility.DBNullStringChecker(auth.Password);
                            parms[7].Value = auth.Enabled;

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CA_SaveCardAuth, parms);
                            dictionary[auth.CardSn] = auth;
                        }

                        if (IsSync) {
                            foreach (var dic in dictionary) {
                                parms[0].Value = ComUtility.GetCardSn10to16(dic.Key);
                                parms[1].Value = dic.Value.DevId;
                                parms[2].Value = (Int32)dic.Value.LimitId;
                                parms[3].Value = ComUtility.DBNullInt32Checker(dic.Value.LimitIndex);
                                parms[4].Value = dic.Value.BeginTime;
                                parms[5].Value = dic.Value.EndTime;
                                parms[6].Value = ComUtility.DBNullStringChecker(dic.Value.Password);
                                parms[7].Value = dic.Value.Enabled;

                                SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CA_SyncCardAuth, parms);
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
        /// Bitch Update Card Auth.
        /// </summary>
        /// <param name="Ids">Ids</param>
        /// <param name="auth">auth</param>
        public void UpdateBitchCardAuth(List<IDValuePair<Int32, String>> Ids, CardAuthInfo auth) {
            SqlParameter[] parms = { new SqlParameter("@CardSn", SqlDbType.VarChar,50),
                                     new SqlParameter("@RtuId", SqlDbType.Int), 
                                     new SqlParameter("@LimitId", SqlDbType.Int),
                                     new SqlParameter("@LimitIndex", SqlDbType.Int),
                                     new SqlParameter("@BeginTime", SqlDbType.DateTime),
                                     new SqlParameter("@EndTime", SqlDbType.DateTime),
                                     new SqlParameter("@Password", SqlDbType.VarChar,50),
                                     new SqlParameter("@Enabled", SqlDbType.Bit) };

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        foreach (var id in Ids) {
                            parms[0].Value = ComUtility.GetCardSn10to16(id.Value);
                            parms[1].Value = id.ID;
                            parms[2].Value = (Int32)auth.LimitId;
                            parms[3].Value = ComUtility.DBNullInt32Checker(auth.LimitIndex);
                            parms[4].Value = auth.BeginTime;
                            parms[5].Value = auth.EndTime;
                            parms[6].Value = ComUtility.DBNullStringChecker(auth.Password);
                            parms[7].Value = auth.Enabled;

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CA_BitchUpdateCardAuth, parms);
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
        /// Copy Auth By Device.
        /// </summary>
        /// <param name="source">source device id</param>
        /// <param name="target">target device id</param>
        /// <param name="delete">whether to delete target auth</param>
        public void CopyAuthByDev(List<Int32> source, List<Int32> target, bool delete) {
            SqlParameter[] parms = { new SqlParameter("@TargetDevId", SqlDbType.Int),
                                     new SqlParameter("@SourceDevId", SqlDbType.Int) };

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        foreach (var t in target) {
                            parms[0].Value = t;
                            parms[1].Value = DBNull.Value;
                            if (delete) { SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CA_DeleteAuthByDev, parms); }
                            foreach (var s in source) {
                                parms[1].Value = s;
                                SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CA_CopyAuthByDev, parms);
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
        /// Copy Auth By Card.
        /// </summary>
        /// <param name="source">source card sn</param>
        /// <param name="target">target card sn</param>
        /// <param name="delete">whether to delete target auth</param>
        public void CopyAuthByCard(List<String> source, List<String> target, bool delete) {
            SqlParameter[] parms = { new SqlParameter("@TargetCardSn", SqlDbType.VarChar,50),
                                     new SqlParameter("@SourceCardSn", SqlDbType.VarChar,50) };

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        foreach (var t in target) {
                            parms[0].Value = ComUtility.GetCardSn10to16(t);
                            parms[1].Value = DBNull.Value;
                            if (delete) { SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CA_DeleteAuthByCard, parms); }
                            foreach (var s in source) {
                                parms[1].Value = ComUtility.GetCardSn10to16(s);
                                SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CA_CopyAuthByCard, parms);
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
        /// Get Device Auth Count.
        /// </summary>
        /// <returns>auth count</returns>
        public List<IDValuePair<Int32, Int32>> GetDevAuthCount() {
            var counts = new List<IDValuePair<Int32, Int32>>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CA_GetDevAuthCount, null)) {
                while (rdr.Read()) {
                    counts.Add(new IDValuePair<Int32, Int32>(ComUtility.DBNullInt32Handler(rdr["DevId"]), ComUtility.DBNullInt32Handler(rdr["Count"])));
                }
            }
            return counts;
        }

        /// <summary>
        /// Get Card Auth Count.
        /// </summary>
        /// <returns>auth count</returns>
        public List<IDValuePair<String, Int32>> GetCardAuthCount() {
            var counts = new List<IDValuePair<String, Int32>>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CA_GetCardAuthCount, null)) {
                while (rdr.Read()) {
                    counts.Add(new IDValuePair<String, Int32>(ComUtility.GetCardSn16to10(ComUtility.DBNullStringHandler(rdr["CardSn"])), ComUtility.DBNullInt32Handler(rdr["Count"])));
                }
            }
            return counts;
        }

        /// <summary>
        /// Get Device Auth Cards.
        /// </summary>
        /// <returns>auth cards</returns>
        public Dictionary<String,Int32> GetDevAuthCards(Int32 devId) {
            SqlParameter[] parms = { new SqlParameter("@DevId", SqlDbType.Int) };
            parms[0].Value = devId;

            var cards = new Dictionary<String, Int32>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CA_GetCardAuthCards, parms)) {
                while (rdr.Read()) {
                    cards[ComUtility.GetCardSn16to10(ComUtility.DBNullStringHandler(rdr["CardSn"]))] = devId;
                }
            }
            return cards;
        }

        /// <summary>
        /// Get Card Auth Devices.
        /// </summary>
        /// <returns>auth devices</returns>
        public Dictionary<Int32,String> GetCardAuthDevs(String cardSn) {
            SqlParameter[] parms = { new SqlParameter("@CardSn", SqlDbType.VarChar, 50) };
            parms[0].Value = ComUtility.GetCardSn10to16(cardSn);

            var devices = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CA_GetCardAuthDevs, parms)) {
                while (rdr.Read()) {
                    devices[ComUtility.DBNullInt32Handler(rdr["DevId"])] = cardSn;
                }
            }
            return devices;
        }
    }
}
