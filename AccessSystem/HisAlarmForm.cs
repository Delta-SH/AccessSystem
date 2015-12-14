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
using Excel = org.in2bits.MyXls;

namespace Delta.MPS.AccessSystem
{
    public partial class HisAlarmForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private ComboBoxData ComboEntity;
        private List<AlarmInfo> CurAlarms;
        private DeviceInfo CurDev;
        private NodeInfo CurNode;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public HisAlarmForm() {
            InitializeComponent();
            ComboEntity = new ComboBoxData();
            CurAlarms = new List<AlarmInfo>();
        }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public HisAlarmForm(NodeInfo node) {
            InitializeComponent();
            ComboEntity = new ComboBoxData();
            CurAlarms = new List<AlarmInfo>();

            CurNode = node;
            if (CurNode != null && Common.CurUser.Role.Devices.ContainsKey(CurNode.DevID)) {
                CurDev = Common.CurUser.Role.Devices[CurNode.DevID];
            }
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void HisAlarmForm_Load(object sender, EventArgs e) {
            try {
                //加载Combobox
                BindAlarmLevelToCombobox();
                BindArea2ToCombobox();
                CurDev = null;
                CurNode = null;

                BeginFromTime.Value = EndFromTime.Value = DateTime.Today.AddMonths(-1);
                BeginToTime.Value = EndToTime.Value = DateTime.Now;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void Area2NameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                BindArea3ToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.Area2NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void Area3NameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                BindStaToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.Area3NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void StaNameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                BindDevToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.StaNameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void DevNameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                BindNodeToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.DevNameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void NodeNameCB_SelectedIndexChanged(object sender, EventArgs e) {

        }

        /// <summary>
        /// Alarm GridView CellValue Needed Event.
        /// </summary>
        private void AlarmGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurAlarms.Count - 1) { return; }
                switch (AlarmGridView.Columns[e.ColumnIndex].Name) {
                    case "AIDColumn":
                        e.Value = e.RowIndex + 1;
                        AlarmGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = AlarmMenuItem1.Checked ? Common.GetLevelColor(CurAlarms[e.RowIndex].AlarmLevel) : Color.White;
                        break;
                    case "SerialNOColumn":
                        e.Value = CurAlarms[e.RowIndex].SerialNO;
                        break;
                    case "Area2Column":
                        e.Value = CurAlarms[e.RowIndex].Area2Name;
                        break;
                    case "Area3Column":
                        e.Value = CurAlarms[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn":
                        e.Value = CurAlarms[e.RowIndex].StaName;
                        break;
                    case "DevNameColumn":
                        e.Value = CurAlarms[e.RowIndex].DevName;
                        break;
                    case "NodeIDColumn":
                        e.Value = CurAlarms[e.RowIndex].NodeID;
                        break;
                    case "NodeNameColumn":
                        e.Value = CurAlarms[e.RowIndex].NodeName;
                        break;
                    case "AlarmDescColumn":
                        e.Value = CurAlarms[e.RowIndex].AlarmDesc;
                        break;
                    case "AlarmLevelColumn":
                        e.Value = (Int32)CurAlarms[e.RowIndex].AlarmLevel;
                        break;
                    case "AlarmTimeColumn":
                        e.Value = Common.GetDateTimeString(CurAlarms[e.RowIndex].StartTime);
                        break;
                    case "EndTimeColumn":
                        e.Value = Common.GetDateTimeString(CurAlarms[e.RowIndex].EndTime);
                        break;
                    case "AlarmIntervalColumn":
                        e.Value = Common.GetTimeInterval(CurAlarms[e.RowIndex].StartTime, CurAlarms[e.RowIndex].EndTime);
                        break;
                    case "ConfirmMarkingColumn":
                        e.Value = Common.GetConfirmMarkingName(CurAlarms[e.RowIndex].ConfirmMarking);
                        break;
                    case "ConfirmTimeColumn":
                        e.Value = Common.GetDateTimeString(CurAlarms[e.RowIndex].ConfirmTime);
                        break;
                    case "ConfirmNameColumn":
                        e.Value = CurAlarms[e.RowIndex].ConfirmName;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.AlarmGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Menu Opening Event.
        /// </summary>
        private void AlarmContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            AlarmMenuItem1.Enabled = AlarmMenuItem2.Enabled = AlarmGridView.Rows.Count > 0;
        }

        /// <summary>
        /// Alarm Menu Item Click Event.
        /// </summary>
        private void AlarmMenuItem1_Click(object sender, EventArgs e) {
            try {
                AlarmGridView.Invalidate(AlarmGridView.DisplayRectangle);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.AlarmMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Alarm Menu Item Click Event.
        /// </summary>
        private void AlarmMenuItem2_Click(object sender, EventArgs e) {
            try {
                var data = new DataTable();
                var colors = new Dictionary<Int32, Excel.Color>();

                data.Columns.Add("序号", typeof(String));
                data.Columns.Add("告警标识", typeof(String));
                data.Columns.Add("所属地区", typeof(String));
                data.Columns.Add("所属县市", typeof(String));
                data.Columns.Add("所属局站", typeof(String));
                data.Columns.Add("所属设备", typeof(String));
                data.Columns.Add("测点编号", typeof(String));
                data.Columns.Add("测点名称", typeof(String));
                data.Columns.Add("告警描述", typeof(String));
                data.Columns.Add("告警级别", typeof(String));
                data.Columns.Add("告警时间", typeof(String));
                data.Columns.Add("结束时间", typeof(String));
                data.Columns.Add("告警历时", typeof(String));
                data.Columns.Add("处理标识", typeof(String));
                data.Columns.Add("处理时间", typeof(String));
                data.Columns.Add("处理人员", typeof(String));

                for (var i = 0; i < CurAlarms.Count; i++) {
                    var dr = data.NewRow();
                    dr["序号"] = i + 1;
                    dr["告警标识"] = CurAlarms[i].SerialNO.ToString();
                    dr["所属地区"] = CurAlarms[i].Area2Name;
                    dr["所属县市"] = CurAlarms[i].Area3Name;
                    dr["所属局站"] = CurAlarms[i].StaName;
                    dr["所属设备"] = CurAlarms[i].DevName;
                    dr["测点编号"] = CurAlarms[i].NodeID.ToString();
                    dr["测点名称"] = CurAlarms[i].NodeName;
                    dr["告警描述"] = CurAlarms[i].AlarmDesc;
                    dr["告警级别"] = ((Int32)CurAlarms[i].AlarmLevel).ToString();
                    dr["告警时间"] = Common.GetDateTimeString(CurAlarms[i].StartTime);
                    dr["结束时间"] = Common.GetDateTimeString(CurAlarms[i].EndTime);
                    dr["告警历时"] = Common.GetTimeInterval(CurAlarms[i].StartTime, CurAlarms[i].EndTime);
                    dr["处理标识"] = Common.GetConfirmMarkingName(CurAlarms[i].ConfirmMarking);
                    dr["处理时间"] = Common.GetDateTimeString(CurAlarms[i].ConfirmTime);
                    dr["处理人员"] = CurAlarms[i].ConfirmName;
                    data.Rows.Add(dr);

                    if (AlarmMenuItem1.Checked) {
                        colors[i] = Common.GetExcelAlarmColor(CurAlarms[i].AlarmLevel);
                    }
                }

                Common.ExportDataToExcel(null, "历史告警信息", "智能门禁管理系统 历史告警信息报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.AlarmMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Query Button Click Event.
        /// </summary>
        private void QueryBtn_Click(object sender, EventArgs e) {
            try {
                CurAlarms.Clear();
                AlarmGridView.Rows.Clear();
                
                var area2 = ComUtility.DefaultString;
                if (Area2NameCB.SelectedIndex != 0) {
                    area2 = Area2NameCB.Text.Trim();
                }

                var area3 = ComUtility.DefaultString;
                if (Area3NameCB.SelectedIndex != 0) {
                    area3 = Area3NameCB.Text.Trim();
                }

                var sta = ComUtility.DefaultString;
                if (StaNameCB.SelectedIndex != 0) {
                    sta = StaNameCB.Text.Trim();
                }

                var dev = ComUtility.DefaultString;
                if (DevNameCB.SelectedIndex != 0) {
                    dev = DevNameCB.Text.Trim();
                }

                var node = ComUtility.DefaultString;
                if (NodeNameCB.SelectedIndex != 0) {
                    node = NodeNameCB.Text.Trim();
                }

                var level = EnmAlarmLevel.NoAlarm;
                if (AlarmLevelCB.SelectedIndex > 0) {
                    var alarmLevel = (Int32)AlarmLevelCB.SelectedValue;
                    level = Enum.IsDefined(typeof(EnmAlarmLevel), alarmLevel) ? (EnmAlarmLevel)alarmLevel : EnmAlarmLevel.NoAlarm;
                }

                var bfTime = BeginFromTime.Value;
                var btTime = BeginToTime.Value;
                var efTime = EndFromTime.Value;
                var etTime = EndToTime.Value;
                var fInterval = Common.GetSecondFromDateTime(TimeFromIntervalTB.Text);
                var eInterval = Common.GetSecondFromDateTime(TimeToIntervalTB.Text);

                var result = Common.ShowWait(() => {
                    CurAlarms = new Alarm().GetHisAlarms(area2, area3, sta, dev, node, level, bfTime, btTime, efTime, etTime, fInterval, eInterval);
                }, default(string), "正在查询，请稍后...", default(int), default(int));

                if (result == DialogResult.OK) {
                    AlarmGridView.RowCount = CurAlarms.Count;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisAlarmForm.QueryBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Area2 To Combobox.
        /// </summary>
        private void BindArea2ToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var dict = ComboEntity.GetArea2(ComUtility.DefaultInt32, Common.CurUser.Role.RoleID);
            if (dict != null && dict.Count > 0) {
                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            Area2NameCB.ValueMember = "ID";
            Area2NameCB.DisplayMember = "Value";
            Area2NameCB.DataSource = data;

            if (CurDev != null && dict.ContainsKey(CurDev.Area2ID)) {
                Area2NameCB.SelectedValue = CurDev.Area2ID;
            }
        }

        /// <summary>
        /// Bind Area3 To Combobox.
        /// </summary>
        private void BindArea3ToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var area2Id = Area2NameCB.SelectedIndex > 0 ? (Int32)Area2NameCB.SelectedValue : ComUtility.DefaultInt32;
            var dict = ComboEntity.GetArea3(area2Id, Common.CurUser.Role.RoleID);
            if (dict != null && dict.Count > 0) {
                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            Area3NameCB.ValueMember = "ID";
            Area3NameCB.DisplayMember = "Value";
            Area3NameCB.DataSource = data;

            if (CurDev != null && dict.ContainsKey(CurDev.Area3ID)) {
                Area3NameCB.SelectedValue = CurDev.Area3ID;
            }
        }

        /// <summary>
        /// Bind Station To Combobox.
        /// </summary>
        private void BindStaToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var area3Id = Area3NameCB.SelectedIndex > 0 ? (Int32)Area3NameCB.SelectedValue : ComUtility.DefaultInt32;
            var dict = ComboEntity.GetStations(area3Id, Common.CurUser.Role.RoleID);
            if (dict != null && dict.Count > 0) {
                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            StaNameCB.ValueMember = "ID";
            StaNameCB.DisplayMember = "Value";
            StaNameCB.DataSource = data;

            if (CurDev != null && dict.ContainsKey(CurDev.StaID)) {
                StaNameCB.SelectedValue = CurDev.StaID;
            }
        }

        /// <summary>
        /// Bind Device To Combobox.
        /// </summary>
        private void BindDevToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var area3Id = Area3NameCB.SelectedIndex > 0 ? (Int32)Area3NameCB.SelectedValue : ComUtility.DefaultInt32;
            var staId = StaNameCB.SelectedIndex > 0 ? (Int32)StaNameCB.SelectedValue : ComUtility.DefaultInt32;
            var dict = ComboEntity.GetDevices(area3Id, staId, Common.CurUser.Role.RoleID);
            if (dict != null && dict.Count > 0) {
                if (StaNameCB.SelectedIndex == 0) {
                    dict = dict.GroupBy(item => item.Value).ToDictionary(x => x.Min(y => y.Key), x => x.Key);
                }

                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            DevNameCB.ValueMember = "ID";
            DevNameCB.DisplayMember = "Value";
            DevNameCB.DataSource = data;

            if (CurNode != null && dict.ContainsKey(CurNode.DevID)) {
                DevNameCB.SelectedValue = CurNode.DevID;
            }
        }

        /// <summary>
        /// Bind Node To Combobox.
        /// </summary>
        private void BindNodeToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var dict = new Dictionary<Int32, String>();
            if (StaNameCB.SelectedIndex > 0 && DevNameCB.SelectedIndex > 0) {
                var devId = (Int32)DevNameCB.SelectedValue;
                dict = ComboEntity.GetNodes(devId, true, false, true, false);
                if (dict != null && dict.Count > 0) {
                    foreach (var d in dict) {
                        data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                    }
                }
            }

            NodeNameCB.ValueMember = "ID";
            NodeNameCB.DisplayMember = "Value";
            NodeNameCB.DataSource = data;

            if (CurNode != null && dict.ContainsKey(CurNode.NodeID)) {
                NodeNameCB.SelectedValue = CurNode.NodeID;
            }
        }

        /// <summary>
        /// Bind Alarm Level To Combobox.
        /// </summary>
        private void BindAlarmLevelToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "所有告警"));

            var dict = ComboEntity.GetAlarmLevels();
            if (dict != null && dict.Count > 0) {
                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            AlarmLevelCB.ValueMember = "ID";
            AlarmLevelCB.DisplayMember = "Value";
            AlarmLevelCB.DataSource = data;
        }
    }
}
