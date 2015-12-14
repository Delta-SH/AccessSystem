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
    public partial class CardRecordsCountForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private ComboBoxData ComboEntity;
        private List<ValuesPair<DeviceInfo, CardInfo, List<CardRecordInfo>,object,object>> CurRecords;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public CardRecordsCountForm() {
            InitializeComponent();
            ComboEntity = new ComboBoxData();
            CurRecords = new List<ValuesPair<DeviceInfo, CardInfo, List<CardRecordInfo>, object, object>>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void CardRecordsCountForm_Load(object sender, EventArgs e) {
            try {
                //加载Combobox
                BindArea2ToCombobox();
                BindQueryTypeToCombobox();

                BeginFromTime.Value = DateTime.Today.AddMonths(-1);
                BeginToTime.Value = DateTime.Now;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsCountForm.Load", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsCountForm.Area2NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsCountForm.Area3NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsCountForm.StaNameCB.SelectedIndexChanged", err.Message, err.StackTrace);
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
        private void CardCountGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurRecords.Count - 1) { return; }
                switch (CardCountGridView.Columns[e.ColumnIndex].Name) {
                    case "HCIDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "HCArea2Column":
                        e.Value = CurRecords[e.RowIndex].Value1.Area2Name;
                        break;
                    case "HCArea3Column":
                        e.Value = CurRecords[e.RowIndex].Value1.Area3Name;
                        break;
                    case "HCStaNameColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.StaName;
                        break;
                    case "HCDevIDColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.DevID;
                        break;
                    case "HCDevNameColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.DevName;
                        break;
                    case "HCCardSnColumn":
                        e.Value = CurRecords[e.RowIndex].Value2.CardSn;
                        break;
                    case "HCWorkerColumn":
                        e.Value = String.Format("{0} - {1}", CurRecords[e.RowIndex].Value2.WorkerId, CurRecords[e.RowIndex].Value2.WorkerName);
                        break;
                    case "HCWorkerTypeColumn":
                        e.Value = ComUtility.GetWorkerTypeText(CurRecords[e.RowIndex].Value2.WorkerType);
                        break;
                    case "HCDeptColumn":
                        e.Value = String.Format("{0} - {1}", CurRecords[e.RowIndex].Value2.DepId, CurRecords[e.RowIndex].Value2.DepName);
                        break;
                    case "CountColumn":
                        e.Value = CurRecords[e.RowIndex].Value3.Count;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsCountForm.CardCountGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Records GridView Cell DoubleClick Event.
        /// </summary>
        private void CardCountGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                if (!CardCountGridView.Columns[e.ColumnIndex].Name.Equals("CountColumn")) { return; }
                var key1 = (Int32)CardCountGridView.Rows[e.RowIndex].Cells["HCDevIDColumn"].Value;
                var key2 = (String)CardCountGridView.Rows[e.RowIndex].Cells["HCCardSnColumn"].Value;
                var obj = CurRecords.Find(rec => rec.Value1.DevID == key1 && rec.Value2.CardSn.Equals(key2, StringComparison.CurrentCultureIgnoreCase));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                for (var i = 0; i < obj.Value3.Count; i++) {
                    obj.Value3[i].Device = obj.Value1;
                    obj.Value3[i].Card = obj.Value2;
                }
                new CardRecordsDetailDialog(obj.Value3).ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsCountForm.CardCountGridView.CellDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Menu Opening Event.
        /// </summary>
        private void RecordContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            RecMenuItem1.Enabled = CardCountGridView.Rows.Count > 0;
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
                data.Columns.Add("设备名称", typeof(String));
                data.Columns.Add("刷卡卡号", typeof(String));
                data.Columns.Add("刷卡人员", typeof(String));
                data.Columns.Add("人员类型", typeof(String));
                data.Columns.Add("所属部门", typeof(String));
                data.Columns.Add("刷卡次数", typeof(String));

                for (var i = 0; i < CurRecords.Count; i++) {
                    var dr = data.NewRow();
                    dr["序号"] = i + 1;
                    dr["所属地区"] = CurRecords[i].Value1.Area2Name;
                    dr["所属县市"] = CurRecords[i].Value1.Area3Name;
                    dr["所属局站"] = CurRecords[i].Value1.StaName;
                    dr["设备名称"] = CurRecords[i].Value1.DevName;
                    dr["刷卡卡号"] = CurRecords[i].Value2.CardSn;
                    dr["刷卡人员"] = String.Format("{0} - {1}", CurRecords[i].Value2.WorkerId, CurRecords[i].Value2.WorkerName);
                    dr["人员类型"] = ComUtility.GetWorkerTypeText(CurRecords[i].Value2.WorkerType);
                    dr["所属部门"] = String.Format("{0} - {1}", CurRecords[i].Value2.DepId, CurRecords[i].Value2.DepName);
                    dr["刷卡次数"] = CurRecords[i].Value3.Count;
                    data.Rows.Add(dr);
                }

                Common.ExportDataToExcel(null, "刷卡次数统计", "智能门禁管理系统 刷卡次数统计报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsCountForm.RecMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Query Button Click Event.
        /// </summary>
        private void QueryBtn_Click(object sender, EventArgs e) {
            try {
                CurRecords.Clear();
                CardCountGridView.Rows.Clear();

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

                var result = Common.ShowWait(() => {
                    var tpRecords = new Card().GetHisCardRecords(beginTime, endTime);
                    if (tpRecords != null && tpRecords.Count > 0) {
                        var devices = Common.CurUser.Role.Devices.Values.ToList();
                        if (area2Index == -1) {
                            devices = devices.FindAll(rec => rec.Area2Name.ToLower().Contains(area2Text));
                        }

                        if (area2Index > 0) {
                            devices = devices.FindAll(rec => rec.Area2ID == area2Value);
                        }

                        if (area3Index == -1) {
                            devices = devices.FindAll(rec => rec.Area3Name.ToLower().Contains(area3Text));
                        }

                        if (area3Index > 0) {
                            devices = devices.FindAll(rec => rec.Area3ID == area3Value);
                        }

                        if (staIndex == -1) {
                            devices = devices.FindAll(rec => rec.StaName.ToLower().Contains(staText));
                        }

                        if (staIndex > 0) {
                            devices = devices.FindAll(rec => rec.StaID == staValue);
                        }

                        if (devIndex == -1) {
                            devices = devices.FindAll(rec => rec.DevName.ToLower().Contains(devText));
                        }

                        if (devIndex > 0) {
                            devices = devices.FindAll(rec => rec.DevID == devValue);
                        }

                        var cards = Common.CurUser.Role.Cards;
                        if (!String.IsNullOrWhiteSpace(queryText)) {
                            var filters = queryText.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            switch (queryIndex) {
                                case 0:
                                    cards = cards.FindAll(rec => {
                                        if (String.IsNullOrWhiteSpace(rec.CardSn)) { return false; }
                                        foreach (var f in filters) {
                                            if (rec.CardSn.Contains(f.Trim())) { return true; }
                                        }
                                        return false;
                                    });
                                    break;
                                case 1:
                                    cards = cards.FindAll(rec => {
                                        if (String.IsNullOrWhiteSpace(rec.WorkerId)) { return false; }
                                        foreach (var f in filters) {
                                            if (rec.WorkerId.Contains(f.Trim())) { return true; }
                                        }
                                        return false;
                                    });
                                    break;
                                case 2:
                                    cards = cards.FindAll(rec => {
                                        if (String.IsNullOrWhiteSpace(rec.WorkerName)) { return false; }
                                        foreach (var f in filters) {
                                            if (rec.WorkerName.Equals(f.Trim(), StringComparison.CurrentCultureIgnoreCase)) { return true; }
                                        }
                                        return false;
                                    });
                                    break;
                                default:
                                    break;
                            }
                        }

                        var gpRecords = from rec in tpRecords
                                        group rec by new { rec.DevID, rec.CardSn } into g
                                        select new {
                                            DevID = g.Key.DevID,
                                            CardSn = g.Key.CardSn,
                                            Cnt = g.ToList()
                                        };

                        CurRecords = (from rec in gpRecords
                                      join dev in devices on rec.DevID equals dev.DevID
                                      join card in cards on rec.CardSn equals card.CardSn
                                      orderby card.CardSn,dev.DevID
                                      select new ValuesPair<DeviceInfo, CardInfo, List<CardRecordInfo>, object, object> {
                                          Value1 = dev,
                                          Value2 = card,
                                          Value3 = rec.Cnt,
                                          Value4 = null,
                                          Value5 = null
                                      }).ToList();
                    }
                }, default(string), "正在查询，请稍后...", default(int), default(int));

                if (result == DialogResult.OK) {
                    CardCountGridView.RowCount = CurRecords.Count;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardRecordsCountForm.QueryBtn.Click", err.Message, err.StackTrace);
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
    }
}
