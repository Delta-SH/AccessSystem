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

namespace Delta.MPS.AccessSystem
{
    public partial class CardRecordsDetailDialog : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private List<CardRecordInfo> CurRecords;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public CardRecordsDetailDialog(List<CardRecordInfo> records) {
            InitializeComponent();
            CurRecords = records;
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void CardRecordsDetailDialog_Load(object sender, EventArgs e) {
            try {
                if (CurRecords != null && CurRecords.Count > 0) {
                    CurRecords = CurRecords.OrderBy(rec => rec.CardTime).ToList();
                    HisCardGridView.RowCount = CurRecords.Count;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsDetailDialog.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Records GridView CellValue Needed Event.
        /// </summary>
        private void HisCardGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurRecords.Count - 1) { return; }
                switch (HisCardGridView.Columns[e.ColumnIndex].Name) {
                    case "HCIDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "HCRecIDColumn":
                        e.Value = CurRecords[e.RowIndex].ID;
                        break;
                    case "HCArea2Column":
                        e.Value = CurRecords[e.RowIndex].Device.Area2Name;
                        break;
                    case "HCArea3Column":
                        e.Value = CurRecords[e.RowIndex].Device.Area3Name;
                        break;
                    case "HCStaNameColumn":
                        e.Value = CurRecords[e.RowIndex].Device.StaName;
                        break;
                    case "HCDevIDColumn":
                        e.Value = CurRecords[e.RowIndex].Device.DevID;
                        break;
                    case "HCDevNameColumn":
                        e.Value = CurRecords[e.RowIndex].Device.DevName;
                        break;
                    case "HCDescColumn":
                        e.Value = CurRecords[e.RowIndex].Remark;
                        break;
                    case "HCCardSnColumn":
                        e.Value = CurRecords[e.RowIndex].CardSn;
                        break;
                    case "HCTimeColumn":
                        e.Value = Common.GetDateTimeString(CurRecords[e.RowIndex].CardTime);
                        break;
                    case "HCWorkerColumn":
                        e.Value = CurRecords[e.RowIndex].Card != null ? String.Format("{0} - {1}", CurRecords[e.RowIndex].Card.WorkerId, CurRecords[e.RowIndex].Card.WorkerName) : String.Empty;
                        break;
                    case "HCWorkerTypeColumn":
                        e.Value = CurRecords[e.RowIndex].Card != null ? ComUtility.GetWorkerTypeText(CurRecords[e.RowIndex].Card.WorkerType) : String.Empty;
                        break;
                    case "HCDeptColumn":
                        e.Value = CurRecords[e.RowIndex].Card != null ? String.Format("{0} - {1}", CurRecords[e.RowIndex].Card.DepId, CurRecords[e.RowIndex].Card.DepName) : String.Empty;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsDetailDialog.HisCardGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Menu Opening Event.
        /// </summary>
        private void RecordContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            RecMenuItem1.Enabled = HisCardGridView.Rows.Count > 0;
        }

        /// <summary>
        /// Record Menu Item Click Event.
        /// </summary>
        private void RecMenuItem1_Click(object sender, EventArgs e) {
            try {
                var data = new DataTable();
                data.Columns.Add("序号", typeof(String));
                data.Columns.Add("所属地区", typeof(String));
                data.Columns.Add("所属县市", typeof(String));
                data.Columns.Add("所属局站", typeof(String));
                data.Columns.Add("设备编号", typeof(String));
                data.Columns.Add("设备名称", typeof(String));
                data.Columns.Add("刷卡描述", typeof(String));
                data.Columns.Add("刷卡卡号", typeof(String));
                data.Columns.Add("刷卡时间", typeof(String));
                data.Columns.Add("刷卡人员", typeof(String));
                data.Columns.Add("人员类型", typeof(String));
                data.Columns.Add("所属部门", typeof(String));

                for (var i = 0; i < CurRecords.Count; i++) {
                    var dr = data.NewRow();
                    dr["序号"] = i + 1;
                    dr["所属地区"] = CurRecords[i].Device.Area2Name;
                    dr["所属县市"] = CurRecords[i].Device.Area3Name;
                    dr["所属局站"] = CurRecords[i].Device.StaName;
                    dr["设备编号"] = CurRecords[i].Device.DevID.ToString();
                    dr["设备名称"] = CurRecords[i].Device.DevName;
                    dr["刷卡描述"] = CurRecords[i].Remark;
                    dr["刷卡卡号"] = CurRecords[i].CardSn;
                    dr["刷卡时间"] = Common.GetDateTimeString(CurRecords[i].CardTime);
                    dr["刷卡人员"] = CurRecords[i].Card != null ? String.Format("{0} - {1}", CurRecords[i].Card.WorkerId, CurRecords[i].Card.WorkerName) : String.Empty;
                    dr["人员类型"] = CurRecords[i].Card != null ? ComUtility.GetWorkerTypeText(CurRecords[i].Card.WorkerType) : String.Empty;
                    dr["所属部门"] = CurRecords[i].Card != null ? String.Format("{0} - {1}", CurRecords[i].Card.DepId, CurRecords[i].Card.DepName) : String.Empty;
                    data.Rows.Add(dr);
                }

                Common.ExportDataToExcel(null, "刷卡记录详单", "智能门禁管理系统 刷卡记录详单", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsDetailDialog.RecMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
