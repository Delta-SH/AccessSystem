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
    public partial class DeviceForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private ComboBoxData ComboEntity;
        private List<IDValuePair<DeviceInfo,Int32>> CurDevices;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public DeviceForm() {
            InitializeComponent();
            ComboEntity = new ComboBoxData();
            CurDevices = new List<IDValuePair<DeviceInfo, Int32>>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void DeviceForm_Load(object sender, EventArgs e) {
            try {
                //加载Combobox
                BindArea2ToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DeviceForm.Load", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DeviceForm.Area2NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DeviceForm.Area3NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DeviceForm.StaNameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void DevNameCB_SelectedIndexChanged(object sender, EventArgs e) {
        }

        /// <summary>
        /// Device GridView CellValue Needed Event.
        /// </summary>
        private void DevGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurDevices.Count - 1) { return; }
                switch (DevGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "RegionNameColumn":
                        e.Value = CurDevices[e.RowIndex].ID.Area2Name;
                        break;
                    case "CityNameColumn":
                        e.Value = CurDevices[e.RowIndex].ID.Area3Name;
                        break;
                    case "StaNameColumn":
                        e.Value = CurDevices[e.RowIndex].ID.StaName;
                        break;
                    case "DevIDColumn":
                        e.Value = CurDevices[e.RowIndex].ID.DevID;
                        break;
                    case "DevNameColumn":
                        e.Value = CurDevices[e.RowIndex].ID.DevName;
                        break;
                    case "CardCntColumn":
                        e.Value = CurDevices[e.RowIndex].Value;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DeviceForm.DevGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView Cell Double Click Event.
        /// </summary>
        private void DevGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                if (!DevGridView.Columns[e.ColumnIndex].Name.Equals("CardCntColumn")) { return; }
                var key = (Int32)DevGridView.Rows[e.RowIndex].Cells["DevIDColumn"].Value;
                var obj = CurDevices.Find(dev => dev.ID.DevID == key);
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                new CardAuthDetailDialog(obj.ID).ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DeviceForm.DevGridView.CellDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Menu Opening Event.
        /// </summary>
        private void RecordContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            RecMenuItem1.Enabled = DevGridView.Rows.Count > 0;
        }

        /// <summary>
        /// Record Menu Item Click Event.
        /// </summary>
        private void RecMenuItem1_Click(object sender, EventArgs e) {
            try {
                var data = new DataTable();
                var colors = new Dictionary<Int32, Excel.Color>();

                data.Columns.Add("序号", typeof(String));
                data.Columns.Add("地区", typeof(String));
                data.Columns.Add("县市", typeof(String));
                data.Columns.Add("局站", typeof(String));
                data.Columns.Add("设备编号", typeof(String));
                data.Columns.Add("设备名称", typeof(String));
                data.Columns.Add("授权卡片", typeof(String));
                for (var i = 0; i < CurDevices.Count; i++) {
                    var dr = data.NewRow();
                    dr["序号"] = i + 1;
                    dr["地区"] = CurDevices[i].ID.Area2Name;
                    dr["县市"] = CurDevices[i].ID.Area3Name;
                    dr["局站"] = CurDevices[i].ID.StaName;
                    dr["设备编号"] = CurDevices[i].ID.DevID.ToString();
                    dr["设备名称"] = CurDevices[i].ID.DevName;
                    dr["授权卡片"] = CurDevices[i].Value.ToString();
                    data.Rows.Add(dr);
                }

                Common.ExportDataToExcel(null, "设备信息", "智能门禁管理系统 设备信息报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DeviceForm.RecMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Query Button Click Event.
        /// </summary>
        private void QueryBtn_Click(object sender, EventArgs e) {
            try {
                CurDevices.Clear();
                DevGridView.Rows.Clear();

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

                var result = Common.ShowWait(() => {
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

                    if (devices.Count > 0) {
                        var counts = new CardAuth().GetDevAuthCount();
                        CurDevices = (from dev in devices
                                      join cnt in counts on dev.DevID equals cnt.ID into tp
                                      from tc in tp.DefaultIfEmpty()
                                      select new IDValuePair<DeviceInfo, Int32>(dev, tc == null ? 0 : tc.Value)).ToList();

                    }
                }, default(string), "正在查询，请稍后...", default(int), default(int));

                if (result == DialogResult.OK) {
                    DevGridView.RowCount = CurDevices.Count;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DeviceForm.QueryBtn.Click", err.Message, err.StackTrace);
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
    }
}
