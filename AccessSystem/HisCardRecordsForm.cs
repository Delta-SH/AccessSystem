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
    public partial class HisCardRecordsForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private ComboBoxData ComboEntity;
        private List<CardRecordInfo> CurRecords;
        private DeviceInfo CurDev;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public HisCardRecordsForm() {
            InitializeComponent();
            ComboEntity = new ComboBoxData();
            CurRecords = new List<CardRecordInfo>();
        }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public HisCardRecordsForm(DeviceInfo dev) {
            InitializeComponent();
            ComboEntity = new ComboBoxData();
            CurRecords = new List<CardRecordInfo>();
            CurDev = dev;
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void HisCardRecordsForm_Load(object sender, EventArgs e) {
            try {
                //加载Combobox
                BindArea2ToCombobox();
                BindQueryTypeToCombobox();
                BindRecTypeToCombobox();

                BeginFromTime.Value = DateTime.Today.AddMonths(-1);
                BeginToTime.Value = DateTime.Now;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisCardRecordsForm.Load", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisCardRecordsForm.Area2NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisCardRecordsForm.Area3NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisCardRecordsForm.StaNameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void DevNameCB_SelectedIndexChanged(object sender, EventArgs e) {
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisCardRecordsForm.HisCardGridView.CellValueNeeded", err.Message, err.StackTrace);
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

                Common.ExportDataToExcel(null, "刷卡记录", "智能门禁管理系统 刷卡记录报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisCardRecordsForm.RecMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Query Button Click Event.
        /// </summary>
        private void QueryBtn_Click(object sender, EventArgs e) {
            try {
                CurRecords.Clear();
                HisCardGridView.Rows.Clear();

                var area2Index = Area2NameCB.SelectedIndex;
                var area2Text = Area2NameCB.Text.ToLower().Trim();
                var area2Value = Area2NameCB.SelectedValue != null ? (Int32)Area2NameCB.SelectedValue : -1;

                var area3Index = Area3NameCB.SelectedIndex;
                var area3Text = Area3NameCB.Text.ToLower().Trim();
                var area3Value = Area3NameCB.SelectedValue != null ? (Int32)Area3NameCB.SelectedValue : -1;

                var staIndex = StaNameCB.SelectedIndex;
                var staText = StaNameCB.Text.ToLower().Trim();
                var staValue = StaNameCB.SelectedValue != null ? (Int32)StaNameCB.SelectedValue : -1;

                var devIndex = DevNameCB.SelectedIndex;
                var devText = DevNameCB.Text.ToLower().Trim();
                var devValue = DevNameCB.SelectedValue != null ? (Int32)DevNameCB.SelectedValue : -1;

                var beginTime = BeginFromTime.Value;
                var endTime = BeginToTime.Value;

                var queryIndex = (Int32)QueryTypeCB.SelectedValue;
                var queryText = QueryTypeTB.Text;

                var recUnChecked = new List<IDValuePair<String, String>>();
                for (var i = 0; i < RecTypeCL.Items.Count; i++) {
                    if (!RecTypeCL.GetItemChecked(i)) {
                        recUnChecked.Add((IDValuePair<String, String>)RecTypeCL.Items[i]);
                    }
                }

                var result = Common.ShowWait(() => {
                    CurRecords = new Card().GetHisCardRecords(beginTime, endTime);
                    if (CurRecords != null && CurRecords.Count > 0) {
                        CurRecords = (from tr in CurRecords
                                      join dev in Common.CurUser.Role.Devices on tr.DevID equals dev.Key
                                      join cd in Common.CurUser.Role.Cards on tr.CardSn equals cd.CardSn into tp
                                      from td in tp.DefaultIfEmpty()
                                      orderby tr.CardTime descending
                                      select new CardRecordInfo {
                                          Card = td,
                                          Device = dev.Value,
                                          DevID = tr.DevID,
                                          CardSn = tr.CardSn,
                                          CardTime = tr.CardTime,
                                          Status = tr.Status,
                                          Remark = tr.Remark,
                                          Direction = tr.Direction,
                                          GrantPunch = tr.GrantPunch
                                      }).ToList();

                        if (area2Index == -1) {
                            CurRecords = CurRecords.FindAll(rec => rec.Device.Area2Name.ToLower().Contains(area2Text));
                        }

                        if (area2Index > 0) {
                            CurRecords = CurRecords.FindAll(rec => rec.Device.Area2ID == area2Value);
                        }

                        if (area3Index == -1) {
                            CurRecords = CurRecords.FindAll(rec => rec.Device.Area3Name.ToLower().Contains(area3Text));
                        }

                        if (area3Index > 0) {
                            CurRecords = CurRecords.FindAll(rec => rec.Device.Area3ID == area3Value);
                        }

                        if (staIndex == -1) {
                            CurRecords = CurRecords.FindAll(rec => rec.Device.StaName.ToLower().Contains(staText));
                        }

                        if (staIndex > 0) {
                            CurRecords = CurRecords.FindAll(rec => rec.Device.StaID == staValue);
                        }

                        if (devIndex == -1) {
                            CurRecords = CurRecords.FindAll(rec => rec.Device.DevName.ToLower().Contains(devText));
                        }

                        if (devIndex > 0) {
                            CurRecords = CurRecords.FindAll(rec => rec.Device.DevID == devValue);
                        }

                        if (!String.IsNullOrWhiteSpace(queryText)) {
                            var filters = queryText.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            switch (queryIndex) {
                                case 0:
                                    CurRecords = CurRecords.FindAll(rec => {
                                        if (String.IsNullOrWhiteSpace(rec.CardSn)) { return false; }
                                        foreach (var f in filters) {
                                            if (rec.CardSn.Contains(f.Trim())) { return true; }
                                        }
                                        return false;
                                    });
                                    break;
                                case 1:
                                    CurRecords = CurRecords.FindAll(rec => {
                                        if (rec.Card == null || String.IsNullOrWhiteSpace(rec.Card.WorkerId)) { return false; }
                                        foreach (var f in filters) {
                                            if (rec.Card.WorkerId.Contains(f.Trim())) { return true; }
                                        }
                                        return false;
                                    });
                                    break;
                                case 2:
                                    CurRecords = CurRecords.FindAll(rec => {
                                        if (rec.Card == null || String.IsNullOrWhiteSpace(rec.Card.WorkerName)) { return false; }
                                        foreach (var f in filters) {
                                            if (rec.Card.WorkerName.Equals(f.Trim(), StringComparison.CurrentCultureIgnoreCase)) { return true; }
                                        }
                                        return false;
                                    });
                                    break;
                                default:
                                    break;
                            }
                        }

                        foreach (var rc in recUnChecked) {
                            var filters = rc.ID.Split(new char[] { ';' });
                            var flag = rc.Value.Equals("其他记录");
                            CurRecords.RemoveAll(rec => {
                                foreach (var f in filters) {
                                    if (rec.Remark.Equals(f)) { return !flag; }
                                }
                                return flag;
                            });
                        }
                    }
                }, default(string), "正在查询，请稍后...", default(int), default(int));

                if (result == DialogResult.OK) {
                    HisCardGridView.RowCount = CurRecords.Count;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.HisCardRecordsForm.QueryBtn.Click", err.Message, err.StackTrace);
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

            if (CurDev != null && dict.ContainsKey(CurDev.DevID)) {
                DevNameCB.SelectedValue = CurDev.DevID;
            }
        }

        /// <summary>
        /// Bind Query Type To Combobox.
        /// </summary>
        private void BindQueryTypeToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(0, "按卡号查询"));
            data.Add(new IDValuePair<Int32, String>(1, "按工号查询"));
            data.Add(new IDValuePair<Int32, String>(2, "按姓名查询"));

            QueryTypeCB.ValueMember = "ID";
            QueryTypeCB.DisplayMember = "Value";
            QueryTypeCB.DataSource = data;
        }

        /// <summary>
        /// Bind Record Type To Combobox.
        /// </summary>
        private void BindRecTypeToCombobox() {
            var zckm = "刷卡开门记录;键入用户ID及个人密码开门的记录;正常开门（刷卡）";
            var ffkm = "报警记录:非正常开门;手动开门记录;非法开门";
            var yckm = "远程(由SU)开门记录;按钮开门";
            var qtjl = String.Format("{0};{1};{2}", zckm, ffkm, yckm);

            var data = new List<IDValuePair<String, String>>();
            data.Add(new IDValuePair<String, String>(zckm, "正常开门"));
            data.Add(new IDValuePair<String, String>(ffkm, "非法开门"));
            data.Add(new IDValuePair<String, String>(yckm, "远程开门"));
            data.Add(new IDValuePair<String, String>(qtjl, "其他记录"));

            RecTypeCL.DataSource = data;
            RecTypeCL.ValueMember = "ID";
            RecTypeCL.DisplayMember = "Value";

            for (var i = 0; i < RecTypeCL.Items.Count; i++) {
                RecTypeCL.SetItemCheckState(i, CheckState.Checked);
            }
        }
    }
}