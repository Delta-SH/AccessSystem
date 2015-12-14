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
    public partial class LogManagerForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Log LogEntity;
        private List<LogInfo> GridLogs;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public LogManagerForm() {
            InitializeComponent();
            LogEntity = new Log();
            GridLogs = new List<LogInfo>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void LogManagerForm_Load(object sender, EventArgs e) {
            try {
                BeginTimeDTP.Value = DateTime.Today.AddDays(-1);
                EndTimeDTP.Value = DateTime.Now;
                ExportBtn.Enabled = ExportExcelBtn.Enabled = false;
                BindLogTypeCombobox();
                BindMHSXCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LogManagerForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Query Button Click Event.
        /// </summary>
        private void QueryBtn_Click(object sender, EventArgs e) {
            try {
                ExportBtn.Enabled = ExportExcelBtn.Enabled = false;
                GridLogs.Clear();
                EventGridView.Rows.Clear();
                var Logs = LogEntity.GetDBLogs(BeginTimeDTP.Value, EndTimeDTP.Value, (Int32)LogTypeCB.SelectedValue);
                if (!String.IsNullOrWhiteSpace(MHSXTB.Text)) {
                    switch ((Int32)MHSXCB.SelectedValue) {
                        case 1:
                            Logs = Logs.FindAll(l => l.Operator.ToLower().Contains(MHSXTB.Text.ToLower().Trim()));
                            break;
                        case 2:
                            Logs = Logs.FindAll(l => l.Source.ToLower().Contains(MHSXTB.Text.ToLower().Trim()));
                            break;
                        case 3:
                            Logs = Logs.FindAll(l => l.Message.ToLower().Contains(MHSXTB.Text.ToLower().Trim()));
                            break;
                        case 4:
                            Logs = Logs.FindAll(l => l.StackTrace.ToLower().Contains(MHSXTB.Text.ToLower().Trim()));
                            break;
                        default:
                            break;
                    }
                }

                Logs = Logs.OrderBy(l => l.EventTime).ToList();
                GridLogs.AddRange(Logs);
                EventGridView.RowCount = GridLogs.Count;
                ExportBtn.Enabled = ExportExcelBtn.Enabled = GridLogs.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LogManagerForm.QueryBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event GridView Cell Value Needed Event.
        /// </summary>
        private void EventGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > GridLogs.Count - 1) { return; }
                switch (EventGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EventIdColumn":
                        e.Value = GridLogs[e.RowIndex].EventId;
                        break;
                    case "EventTimeColumn":
                        e.Value = Common.GetDateTimeString(GridLogs[e.RowIndex].EventTime);
                        break;
                    case "EventTypeColumn":
                        e.Value = ComUtility.GetLogTypeText(GridLogs[e.RowIndex].EventType);
                        break;
                    case "OperatorColumn":
                        e.Value = GridLogs[e.RowIndex].Operator;
                        break;
                    case "SourceColumn":
                        e.Value = GridLogs[e.RowIndex].Source;
                        break;
                    case "MessageColumn":
                        e.Value = GridLogs[e.RowIndex].Message;
                        break;
                    case "StackTraceColumn":
                        e.Value = GridLogs[e.RowIndex].StackTrace;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LogManagerForm.EventGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event GridView Cell Formatting Event.
        /// </summary>
        private void EventGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            try {
                switch (EventGridView.Columns[e.ColumnIndex].Name) {
                    case "StackTraceColumn":
                        var cell = EventGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        if (cell.Value != null) { cell.ToolTipText = cell.Value.ToString(); }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LogManagerForm.EventGridView.CellFormatting", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export Data To Text.
        /// </summary>
        private void ExportBtn_Click(object sender, EventArgs e) {
            try {
                if (GridLogs.Count > 0) {
                    var logText = new StringBuilder();
                    foreach (var log in GridLogs) {
                        logText.AppendLine("=======================================================================================");
                        logText.AppendLine(String.Format("日志编号: {0}", log.EventId));
                        logText.AppendLine(String.Format("日志时间: {0}", Common.GetDateTimeString(log.EventTime)));
                        logText.AppendLine(String.Format("日志类型: {0}", ComUtility.GetLogTypeText(log.EventType)));
                        logText.AppendLine(String.Format("触发对象: {0}", log.Operator));
                        logText.AppendLine(String.Format("触发来源: {0}", log.Source));
                        logText.AppendLine(String.Format("日志描述: {0}", log.Message));
                        logText.AppendLine(String.Format("详细信息: {0}", log.StackTrace));
                        logText.AppendLine();
                    }

                    Common.ExportDataToText(null, "智能门禁管理系统 系统日志", logText.ToString());
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LogManagerForm.ExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export Data To Excel.
        /// </summary>
        private void ExportExcelBtn_Click(object sender, EventArgs e) {
            try {
                if (GridLogs.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("日志时间", typeof(String));
                    data.Columns.Add("日志类型", typeof(String));
                    data.Columns.Add("触发对象", typeof(String));
                    data.Columns.Add("触发来源", typeof(String));
                    data.Columns.Add("日志描述", typeof(String));
                    for (var i = 0; i < GridLogs.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["日志时间"] = Common.GetDateTimeString(GridLogs[i].EventTime);
                        dr["日志类型"] = ComUtility.GetLogTypeText(GridLogs[i].EventType);
                        dr["触发对象"] = GridLogs[i].Operator;
                        dr["触发来源"] = GridLogs[i].Source;
                        dr["日志描述"] = GridLogs[i].Message;
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "系统日志", "智能门禁管理系统 系统日志报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LogManagerForm.ExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Log Type Combobox.
        /// </summary>
        private void BindLogTypeCombobox() {
            var data = new List<object>();
            data.Add(new {
                ID = -1,
                Name = "所有类型"
            });

            foreach (EnmMsgType type in Enum.GetValues(typeof(EnmMsgType))) {
                data.Add(new {
                    ID = (int)type,
                    Name = ComUtility.GetLogTypeText(type)
                });
            }

            LogTypeCB.ValueMember = "ID";
            LogTypeCB.DisplayMember = "Name";
            LogTypeCB.DataSource = data;
        }

        /// <summary>
        /// Bind MHSX Combobox.
        /// </summary>
        private void BindMHSXCombobox() {
            var data = new List<object>();
            data.Add(new { ID = 1, Name = "按触发对象查询" });
            data.Add(new { ID = 2, Name = "按触发来源查询" });
            data.Add(new { ID = 3, Name = "按日志描述查询" });
            data.Add(new { ID = 4, Name = "按详细信息查询" });

            MHSXCB.ValueMember = "ID";
            MHSXCB.DisplayMember = "Name";
            MHSXCB.DataSource = data;
        }
    }
}
