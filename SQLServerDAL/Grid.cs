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
    /// This class is an implementation for receiving grid information from database
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Get Grids.
        /// </summary>
        /// <returns>grids information</returns>
        public List<IDValuePair<Int32, String>> GetGrids() {
            var grids = new List<IDValuePair<Int32, String>>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_GD_GetGrids, null)) {
                while (rdr.Read()) {
                    grids.Add(new IDValuePair<Int32, String>(ComUtility.DBNullInt32Handler(rdr["TypeID"]), ComUtility.DBNullStringHandler(rdr["TypeName"])));
                }
            }
            return grids;
        }

        /// <summary>
        /// Delete Grids.
        /// </summary>
        /// <param name="grids">grids</param>
        public void DeleteGrids(List<IDValuePair<Int32, String>> grids) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@TypeID", SqlDbType.Int) };
                        foreach (var g in grids) {
                            parms[0].Value = g.ID;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_GD_DeleteGrids, parms);
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
        /// Add Grids.
        /// </summary>
        /// <param name="grids">grids</param>
        public void AddGrids(List<IDValuePair<Int32, String>> grids) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@TypeName", SqlDbType.VarChar, 40) };
                        foreach (var g in grids) {
                            parms[0].Value = g.ID;
                            parms[1].Value = g.Value;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_GD_AddGrid, parms);
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
        /// Update Grids.
        /// </summary>
        /// <param name="grids">grids</param>
        public void UpdateGrids(List<IDValuePair<Int32, String>> grids) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@TypeID", SqlDbType.Int), new SqlParameter("@TypeName", SqlDbType.VarChar, 40) };
                        foreach (var g in grids) {
                            parms[0].Value = g.ID;
                            parms[1].Value = g.Value;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_GD_UpdateGrid, parms);
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
        /// Exist GridName.
        /// </summary>
        /// <param name="GridName">GridName</param>
        /// <returns>true/false</returns>
        public Boolean ExistGridName(String GridName) {
            SqlParameter[] parms = { new SqlParameter("@TypeName", SqlDbType.VarChar, 40) };
            parms[0].Value = GridName;

            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                var cnt = SQLHelper.ExecuteScalar(conn, CommandType.Text, SQLText.SQL_GD_ExistGrid, parms);
                return Convert.ToInt32(cnt) > 0;
            }
        }

        /// <summary>
        /// Get Grid Stations.
        /// </summary>
        /// <param name="RoleId">Role Id</param>
        /// <param name="TypeId">Type Id</param>
        /// <returns>Grid Stations</returns>
        public List<StaInfo> GetGridStations(Guid RoleId, Int32 TypeId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@StaType", SqlDbType.Int),
                                     new SqlParameter("@TypeID", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[1].Value = (int)EnmNodeType.Sta;
            parms[2].Value = TypeId;

            var stations = new List<StaInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_GD_GetGridStations, parms)) {
                while (rdr.Read()) {
                    var sta = new StaInfo();
                    sta.Area1ID = ComUtility.DBNullInt32Handler(rdr["Area1ID"]);
                    sta.Area1Name = ComUtility.DBNullStringHandler(rdr["Area1Name"]);
                    sta.Area2ID = ComUtility.DBNullInt32Handler(rdr["Area2ID"]);
                    sta.Area2Name = ComUtility.DBNullStringHandler(rdr["Area2Name"]);
                    sta.Area3ID = ComUtility.DBNullInt32Handler(rdr["Area3ID"]);
                    sta.Area3Name = ComUtility.DBNullStringHandler(rdr["Area3Name"]);
                    sta.StaID = ComUtility.DBNullInt32Handler(rdr["StaID"]);
                    sta.StaName = ComUtility.DBNullStringHandler(rdr["StaName"]);
                    sta.NetGridID = ComUtility.DBNullInt32Handler(rdr["NetGridID"]);
                    sta.NetGridName = ComUtility.DBNullStringHandler(rdr["NetGridName"]);
                    stations.Add(sta);
                }
            }
            return stations;
        }

        /// <summary>
        /// Update Station Grid.
        /// </summary>
        /// <param name="GridId">Grid Id</param>
        /// <param name="StaIds">Stations Id</param>
        public void UpdateStaGrid(Int32 GridId, List<Int32> StaIds) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@NetGridID", SqlDbType.Int), new SqlParameter("@StaID", SqlDbType.Int) };
                        parms[0].Value = GridId;
                        foreach (var id in StaIds) {
                            parms[1].Value = id;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_GD_UpdateStaGrid, parms);
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
        /// Delete Station Grid.
        /// </summary>
        /// <param name="StaIds">Stations Id</param>
        public void DeleteStaGrid(List<Int32> StaIds) {
            using (var conn = new SqlConnection(SQLHelper.ConnectionStringLocalTransaction)) {
                conn.Open();
                using (var tran = conn.BeginTransaction(IsolationLevel.ReadCommitted)) {
                    try {
                        SqlParameter[] parms = { new SqlParameter("@StaID", SqlDbType.Int) };
                        foreach (var id in StaIds) {
                            parms[0].Value = id;
                            SQLHelper.ExecuteNonQuery(tran, CommandType.Text, SQLText.SQL_GD_DeleteStaGrid, parms);
                        }

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