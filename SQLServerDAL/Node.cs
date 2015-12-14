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
    /// This class is an implementation for receiving nodes information from database
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Get Nodes By Device Id.
        /// </summary>
        public List<NodeInfo> GetNodes(int devId) {
            SqlParameter[] parms = { new SqlParameter("@AIType", SqlDbType.Int),
                                     new SqlParameter("@AOType", SqlDbType.Int),
                                     new SqlParameter("@DIType", SqlDbType.Int),
                                     new SqlParameter("@DOType", SqlDbType.Int),
                                     new SqlParameter("@DevID", SqlDbType.Int) };

            parms[0].Value = (Int32)EnmNodeType.Aic;
            parms[1].Value = (Int32)EnmNodeType.Aoc;
            parms[2].Value = (Int32)EnmNodeType.Dic;
            parms[3].Value = (Int32)EnmNodeType.Doc;
            parms[4].Value = devId;

            var nodes = new List<NodeInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_ND_GetNodes, parms)) {
                while (rdr.Read()) {
                    var node = new NodeInfo();
                    node.DevID = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                    node.RtuID = ComUtility.DBNullInt32Handler(rdr["RtuID"]);
                    node.DotID = ComUtility.DBNullInt32Handler(rdr["DotID"]);
                    node.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                    node.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                    node.NodeName = ComUtility.DBNullStringHandler(rdr["NodeName"]);
                    node.NodeDesc = ComUtility.DBNullStringHandler(rdr["NodeDesc"]);
                    node.Remark = ComUtility.DBNullStringHandler(rdr["Remark"]);
                    node.AuxSet = ComUtility.DBNullStringHandler(rdr["AuxSet"]);
                    node.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    node.Value = ComUtility.DBNullFloatHandler(rdr["Value"]);
                    node.Status = ComUtility.DBNullStateHandler(rdr["Status"]);
                    node.DateTime = ComUtility.DBNullDateTimeHandler(rdr["DateTime"]);
                    node.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["UpdateTime"]);
                    nodes.Add(node);
                }
            }
            return nodes;
        }

        /// <summary>
        /// Get Status Nodes.
        /// </summary>
        public Dictionary<Int32, NodeInfo> GetStatusNodes(Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@DevType", SqlDbType.Int),
                                     new SqlParameter("@DIType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[1].Value = (Int32)EnmNodeType.Dev;
            parms[2].Value = (Int32)EnmNodeType.Dic;

            var nodes = new Dictionary<Int32, NodeInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_ND_GetStatusNodes, parms)) {
                while (rdr.Read()) {
                    var node = new NodeInfo();
                    node.DevID = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                    node.RtuID = ComUtility.DBNullInt32Handler(rdr["RtuID"]);
                    node.DotID = ComUtility.DBNullInt32Handler(rdr["DotID"]);
                    node.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                    node.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                    node.NodeName = ComUtility.DBNullStringHandler(rdr["NodeName"]);
                    node.NodeDesc = ComUtility.DBNullStringHandler(rdr["NodeDesc"]);
                    node.Remark = ComUtility.DBNullStringHandler(rdr["Remark"]);
                    node.AuxSet = ComUtility.DBNullStringHandler(rdr["AuxSet"]);
                    node.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    node.Value = ComUtility.DBNullFloatHandler(rdr["Value"]);
                    node.Status = ComUtility.DBNullStateHandler(rdr["Status"]);
                    node.DateTime = ComUtility.DBNullDateTimeHandler(rdr["DateTime"]);
                    node.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["UpdateTime"]);
                    nodes[node.DevID] = node;
                }
            }
            return nodes;
        }

        /// <summary>
        /// Get Remote Nodes.
        /// </summary>
        public Dictionary<Int32, NodeInfo> GetRemoteNodes(Guid RoleId) {
            SqlParameter[] parms = { new SqlParameter("@RoleId", SqlDbType.UniqueIdentifier),
                                     new SqlParameter("@DevType", SqlDbType.Int),
                                     new SqlParameter("@DOType", SqlDbType.Int) };

            parms[0].Value = ComUtility.DBNullSuperChecker(RoleId);
            parms[1].Value = (Int32)EnmNodeType.Dev;
            parms[2].Value = (Int32)EnmNodeType.Doc;

            var nodes = new Dictionary<Int32, NodeInfo>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_ND_GetRemoteNodes, parms)) {
                while (rdr.Read()) {
                    var node = new NodeInfo();
                    node.DevID = ComUtility.DBNullInt32Handler(rdr["DevID"]);
                    node.RtuID = ComUtility.DBNullInt32Handler(rdr["RtuID"]);
                    node.DotID = ComUtility.DBNullInt32Handler(rdr["DotID"]);
                    node.NodeID = ComUtility.DBNullInt32Handler(rdr["NodeID"]);
                    node.NodeType = ComUtility.DBNullNodeTypeHandler(rdr["NodeType"]);
                    node.NodeName = ComUtility.DBNullStringHandler(rdr["NodeName"]);
                    node.NodeDesc = ComUtility.DBNullStringHandler(rdr["NodeDesc"]);
                    node.Remark = ComUtility.DBNullStringHandler(rdr["Remark"]);
                    node.AuxSet = ComUtility.DBNullStringHandler(rdr["AuxSet"]);
                    node.Enabled = ComUtility.DBNullBooleanHandler(rdr["Enabled"]);
                    node.Value = ComUtility.DBNullFloatHandler(rdr["Value"]);
                    node.Status = ComUtility.DBNullStateHandler(rdr["Status"]);
                    node.DateTime = ComUtility.DBNullDateTimeHandler(rdr["DateTime"]);
                    node.UpdateTime = ComUtility.DBNullDateTimeHandler(rdr["UpdateTime"]);
                    nodes[node.DevID] = node;
                }
            }
            return nodes;
        }

        /// <summary>
        /// Get Lsc
        /// </summary>
        /// <returns>lsc information</returns>
        public Dictionary<Int32, String> GetLsc() {
            var lscs = new Dictionary<Int32, String>();
            using (var rdr = SQLHelper.ExecuteReader(SQLHelper.ConnectionStringLocalTransaction, CommandType.Text, SQLText.SQL_ND_GetLsc, null)) {
                while (rdr.Read()) {
                    var Id = ComUtility.DBNullInt32Handler(rdr["LscID"]);
                    var Name = ComUtility.DBNullStringHandler(rdr["LscName"]);
                    lscs[Id] = Name;
                }
            }
            return lscs;
        }
    }
}
