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
    /// This class is an implementation for receiving card information from database
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Get cards by the specified role id.
        /// </summary>
        /// <param name="RoleId">role id</param>
        /// <returns>cards information</returns>
        public List<CardInfo> GetOrgCards(Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@EmpType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[1].Value = EnmWorkerType.WXRY;

            var cards = new List<CardInfo>(); ;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CD_GetOrgCards, parms)) {
                while (rdr.Read()) {
                    var card = new CardInfo();
                    card.WorkerId = ComUtility.DBNullStringHandler(rdr["EmpId"]);
                    card.WorkerType = ComUtility.DBNullWorkerTypeHandler(rdr["EmpType"]);
                    card.WorkerName = ComUtility.DBNullStringHandler(rdr["EmpName"]);
                    card.DepId = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    card.DepName = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    card.CardSn = ComUtility.DBNullStringHandler(rdr["CardSn"]);
                    card.CardType = ComUtility.DBNullCardTypeHandler(rdr["CardType"]);
                    card.UID = ComUtility.DBNullStringHandler(rdr["UID"]);
                    card.Pwd = ComUtility.DBNullStringHandler(rdr["Pwd"]);
                    card.BeginTime = ComUtility.DBNullDateTimeHandler(rdr["BeginTime"]);
                    card.BeginReason = ComUtility.DBNullStringHandler(rdr["BeginReason"]);
                    card.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    card.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);

                    card.CardSn = ComUtility.GetCardSn16to10(card.CardSn);
                    cards.Add(card);
                }
            }
            return cards;
        }

        /// <summary>
        /// Get cards by the specified role id.
        /// </summary>
        /// <param name="RoleId">role id</param>
        /// <returns>cards information</returns>
        public List<CardInfo> GetOutCards(Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@EmpType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[1].Value = EnmWorkerType.WXRY;

            var cards = new List<CardInfo>(); ;
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CD_GetOutCards, parms)) {
                while (rdr.Read()) {
                    var card = new CardInfo();
                    card.WorkerId = ComUtility.DBNullStringHandler(rdr["EmpId"]);
                    card.WorkerType = ComUtility.DBNullWorkerTypeHandler(rdr["EmpType"]);
                    card.WorkerName = ComUtility.DBNullStringHandler(rdr["EmpName"]);
                    card.DepId = ComUtility.DBNullStringHandler(rdr["DepId"]);
                    card.DepName = ComUtility.DBNullStringHandler(rdr["DepName"]);
                    card.CardSn = ComUtility.DBNullStringHandler(rdr["CardSn"]);
                    card.CardType = ComUtility.DBNullCardTypeHandler(rdr["CardType"]);
                    card.UID = ComUtility.DBNullStringHandler(rdr["UID"]);
                    card.Pwd = ComUtility.DBNullStringHandler(rdr["Pwd"]);
                    card.BeginTime = ComUtility.DBNullDateTimeHandler(rdr["BeginTime"]);
                    card.BeginReason = ComUtility.DBNullStringHandler(rdr["BeginReason"]);
                    card.Comment = ComUtility.DBNullStringHandler(rdr["Comment"]);
                    card.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);

                    card.CardSn = ComUtility.GetCardSn16to10(card.CardSn);
                    cards.Add(card);
                }
            }
            return cards;
        }

        /// <summary>
        /// Exist Card.
        /// </summary>
        /// <param name="CardSn">card sn</param>
        /// <returns>true/false</returns>
        public bool ExistCard(String CardSn) {
            SqlParameter[] parms = { new SqlParameter("@CardSn", SqlDbType.VarChar, 50) };
            parms[0].Value = ComUtility.GetCardSn10to16(CardSn);

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var cnt = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_CD_ExistCard, parms);
                return Convert.ToInt32(cnt) > 0;
            }
        }

        /// <summary>
        /// Delete Cards.
        /// </summary>
        /// <param name="Cards"></param>
        public void DeleteCards(List<CardInfo> Cards) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@CardSn", SqlDbType.VarChar,50) };
                        foreach (var C in Cards) {
                            parms[0].Value = ComUtility.GetCardSn10to16(C.CardSn);
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CD_DeleteCard, parms);
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
        /// Save Cards.
        /// </summary>
        /// <param name="Cards">cards</param>
        public void SaveCards(List<CardInfo> Cards) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@EmpId", SqlDbType.VarChar,50),
                                                 new SqlParameter("@EmpType", SqlDbType.Int),
                                                 new SqlParameter("@CardSn", SqlDbType.VarChar,50), 
                                                 new SqlParameter("@CardType", SqlDbType.Int), 
                                                 new SqlParameter("@UID", SqlDbType.VarChar,50),
                                                 new SqlParameter("@Pwd", SqlDbType.VarChar,50),
                                                 new SqlParameter("@BeginTime", SqlDbType.DateTime),
                                                 new SqlParameter("@BeginReason", SqlDbType.NVarChar,1024),
                                                 new SqlParameter("@Comment", SqlDbType.NVarChar,1024),
                                                 new SqlParameter("@Enabled", SqlDbType.Bit) };

                        foreach (var card in Cards) {
                            parms[0].Value = card.WorkerId;
                            parms[1].Value = (Int32)card.WorkerType;
                            parms[2].Value = ComUtility.GetCardSn10to16(card.CardSn);
                            parms[3].Value = (Int32)card.CardType;
                            parms[4].Value = ComUtility.DBNullStringChecker(card.UID);
                            parms[5].Value = ComUtility.DBNullStringChecker(card.Pwd);
                            parms[6].Value = ComUtility.DBNullDateTimeChecker(card.BeginTime);
                            parms[7].Value = ComUtility.DBNullStringChecker(card.BeginReason);
                            parms[8].Value = ComUtility.DBNullStringChecker(card.Comment);
                            parms[9].Value = card.Enabled;

                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_CD_SaveCard, parms);
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
        /// Get Last Card Records.
        /// </summary>
        /// <param name="beginTime">beginTime</param>
        /// <param name="endTime">endTime</param>
        /// <returns>last card records</returns>
        public List<CardRecordInfo> GetLastCardRecords(DateTime beginTime, DateTime endTime) {
            SqlParameter[] parms = { new SqlParameter("@BeginTime", SqlDbType.DateTime),
                                     new SqlParameter("@EndTime", SqlDbType.DateTime) };

            parms[0].Value = ComUtility.DBNullDateTimeChecker(beginTime);
            parms[1].Value = ComUtility.DBNullDateTimeChecker(endTime);

            var records = new List<CardRecordInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.HisConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CD_GetLastCardRecords, parms)) {
                while (rdr.Read()) {
                    var rec = new CardRecordInfo();
                    rec.ID = ComUtility.DBNullInt32Handler(rdr["ID"]);
                    rec.DevID = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                    rec.CardSn = ComUtility.DBNullStringHandler(rdr["PunchNO"]);
                    rec.CardTime = ComUtility.DBNullDateTimeHandler(rdr["PunchTime"]);
                    rec.Status = ComUtility.DBNullStringHandler(rdr["Status"]);
                    rec.Remark = ComUtility.DBNullStringHandler(rdr["Remark"]);
                    rec.Direction = ComUtility.DBNullDirectionHandler(rdr["Direction"]);
                    rec.GrantPunch = ComUtility.DBNullBooleanHandler(rdr["GrantPunch"]);

                    rec.CardSn = ComUtility.GetCardSn16to10(rec.CardSn);
                    records.Add(rec);
                }
            }
            return records;
        }

        /// <summary>
        /// Get History Card Records.
        /// </summary>
        /// <param name="beginTime">beginTime</param>
        /// <param name="endTime">endTime</param>
        /// <returns>last card records</returns>
        public List<CardRecordInfo> GetHisCardRecords(DateTime beginTime, DateTime endTime) {
            SqlParameter[] parms = { new SqlParameter("@BeginTime", SqlDbType.DateTime),
                                     new SqlParameter("@EndTime", SqlDbType.DateTime) };

            parms[0].Value = ComUtility.DBNullDateTimeChecker(beginTime);
            parms[1].Value = ComUtility.DBNullDateTimeChecker(endTime);

            var records = new List<CardRecordInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.HisConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_CD_GetHisCardRecords, parms)) {
                while (rdr.Read()) {
                    var rec = new CardRecordInfo();
                    rec.ID = ComUtility.DBNullInt32Handler(rdr["ID"]);
                    rec.DevID = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                    rec.CardSn = ComUtility.DBNullStringHandler(rdr["PunchNO"]);
                    rec.CardTime = ComUtility.DBNullDateTimeHandler(rdr["PunchTime"]);
                    rec.Status = ComUtility.DBNullStringHandler(rdr["Status"]);
                    rec.Remark = ComUtility.DBNullStringHandler(rdr["Remark"]);
                    rec.Direction = ComUtility.DBNullDirectionHandler(rdr["Direction"]);
                    rec.GrantPunch = ComUtility.DBNullBooleanHandler(rdr["GrantPunch"]);

                    rec.CardSn = ComUtility.GetCardSn16to10(rec.CardSn);
                    records.Add(rec);
                }
            }
            return records;
        }
    }
}
