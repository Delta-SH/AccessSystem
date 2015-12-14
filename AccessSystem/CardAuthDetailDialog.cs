using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLServerDAL;

namespace Delta.MPS.AccessSystem
{
    public partial class CardAuthDetailDialog : Form
    {
        /// <summary>
        /// Gloal variables.
        /// </summary>
        private DeviceInfo CurDevice;
        private List<IDValuePair<CardInfo, CardAuthInfo>> CurRecords;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public CardAuthDetailDialog(DeviceInfo dev) {
            InitializeComponent();
            CurDevice = dev;
            CurRecords = new List<IDValuePair<CardInfo, CardAuthInfo>>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void CardAuthDetailDialog_Load(object sender, EventArgs e) {
            try {
                if (CurDevice != null) {
                    var auths = new CardAuth().GetDevCardAuth(CurDevice.DevID);
                    var cards = new Card().GetOrgCards(ComUtility.SuperRoleID);
                    cards.AddRange(new Card().GetOutCards(ComUtility.SuperRoleID));

                    if (auths!=null && auths.Count > 0) {
                        CurRecords = (from auth in auths
                                      join card in cards on auth.CardSn equals card.CardSn into tp
                                      from tc in tp.DefaultIfEmpty()
                                      orderby (tc != null ? tc.WorkerId : String.Empty),auth.CardSn
                                      select new IDValuePair<CardInfo, CardAuthInfo>(tc, auth)).ToList();
                    }
                    AuthGridView.RowCount = CurRecords.Count;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthDetailDialog.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Card Auth GridView CellValue Needed Event.
        /// </summary>
        private void AuthGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurRecords.Count - 1) { return; }
                switch (AuthGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EIDColumn":
                        e.Value = CurRecords[e.RowIndex].ID != null ? CurRecords[e.RowIndex].ID.WorkerId : String.Empty;
                        break;
                    case "NameColumn":
                        e.Value = CurRecords[e.RowIndex].ID != null ? CurRecords[e.RowIndex].ID.WorkerName : String.Empty;
                        break;
                    case "DepNameColumn":
                        e.Value = CurRecords[e.RowIndex].ID != null ? String.Format("{0} - {1}", CurRecords[e.RowIndex].ID.DepId, CurRecords[e.RowIndex].ID.DepName) : String.Empty;
                        break;
                    case "CardSnColumn":
                        e.Value = CurRecords[e.RowIndex].Value.CardSn;
                        break;
                    case "BeginTimeColumn":
                        e.Value = Common.GetDateTimeString(CurRecords[e.RowIndex].Value.BeginTime);
                        break;
                    case "EndTimeColumn":
                        e.Value = Common.GetDateTimeString(CurRecords[e.RowIndex].Value.EndTime);
                        break;
                    case "LimitColumn":
                        e.Value = ComUtility.GetLimitIDText(CurRecords[e.RowIndex].Value.LimitId);
                        break;
                    case "LimitIndexColumn":
                        e.Value = CurRecords[e.RowIndex].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : CurRecords[e.RowIndex].Value.LimitIndex.ToString();
                        break;
                    case "EnabledColumn":
                        e.Value = CurRecords[e.RowIndex].Value.Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthDetailDialog.AuthGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Menu Opening Event.
        /// </summary>
        private void RecordContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            RecMenuItem1.Enabled = AuthGridView.Rows.Count > 0;
        }

        /// <summary>
        /// Menu Item Click Event.
        /// </summary>
        private void RecMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (CurRecords.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("工号", typeof(String));
                    data.Columns.Add("姓名", typeof(String));
                    data.Columns.Add("部门", typeof(String));
                    data.Columns.Add("卡号", typeof(String));
                    data.Columns.Add("开始日期", typeof(String));
                    data.Columns.Add("结束日期", typeof(String));
                    data.Columns.Add("权限类型", typeof(String));
                    data.Columns.Add("权限分组", typeof(String));
                    data.Columns.Add("状态", typeof(String));

                    for (var i = 0; i < CurRecords.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["工号"] = CurRecords[i].ID != null ? CurRecords[i].ID.WorkerId : String.Empty;
                        dr["姓名"] = CurRecords[i].ID != null ? CurRecords[i].ID.WorkerName : String.Empty;
                        dr["部门"] = CurRecords[i].ID != null ? String.Format("{0} - {1}", CurRecords[i].ID.DepId, CurRecords[i].ID.DepName) : String.Empty;
                        dr["卡号"] = CurRecords[i].Value.CardSn;
                        dr["开始日期"] = Common.GetDateString(CurRecords[i].Value.BeginTime);
                        dr["结束日期"] = Common.GetDateString(CurRecords[i].Value.EndTime);
                        dr["权限类型"] = ComUtility.GetLimitIDText(CurRecords[i].Value.LimitId);
                        dr["权限分组"] = CurRecords[i].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : CurRecords[i].Value.LimitIndex.ToString();
                        dr["状态"] = CurRecords[i].Value.Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "设备授权信息", "智能门禁管理系统 设备授权信息报表", String.Format("操作员:{0}{1}  日期:{2} 设备:{3} - {4}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now), CurDevice.DevID, String.Format("{0}>{1}>{2}>{3}", CurDevice.Area2Name, CurDevice.Area3Name, CurDevice.StaName, CurDevice.DevName)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthDetailDialog.RecMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
