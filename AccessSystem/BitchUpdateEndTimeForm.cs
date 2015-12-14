using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delta.MPS.Model;
using Delta.MPS.SQLServerDAL;
using Delta.MPS.DBUtility;

namespace Delta.MPS.AccessSystem {
    public partial class BitchUpdateEndTimeForm : Form {
        private CardAuth CardAuthEntity;
        private EnmWorkerType CurWorkerType;
        private List<CardInfo> CurCards;
        private Dictionary<Int32, DeviceInfo> Devices;
        private List<ValuesPair<DeviceInfo, CardAuthInfo, CardInfo, String, String>> TotalRecords;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public BitchUpdateEndTimeForm(EnmWorkerType WorkerType, List<CardInfo> Cards) {
            InitializeComponent();
            CardAuthEntity = new CardAuth();
            CurWorkerType = WorkerType;
            CurCards = Cards;
            Devices = Common.CurUser.Role.Devices;
            TotalRecords = new List<ValuesPair<DeviceInfo, CardAuthInfo, CardInfo, String, String>>();
            Text = WorkerType == EnmWorkerType.WXRY ? String.Format("{0} - [外协人员]", Text) : String.Format("{0} - [正式员工]", Text);
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void BitchUpdateEndTimeForm_Load(object sender, EventArgs e) {
            try {

            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BitchUpdateEndTimeForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void BitchUpdateEndTimeForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                BeginTimeDTP.Value = DateTime.Today;
                EndTimeDTP.Value = new DateTime(2099, 12, 31);
                BindSearchType();
                BindLimitTypeCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BitchUpdateEndTimeForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Search Type.
        /// </summary>
        private void BindSearchType() {
            var data = new List<object>();
            data.Add(new {
                ID = 0,
                Name = "按工号查询"
            });
            data.Add(new {
                ID = 1,
                Name = "按姓名查询"
            });
            data.Add(new {
                ID = 2,
                Name = "按卡号查询"
            });
            data.Add(new {
                ID = 3,
                Name = "按部门编号查询"
            });
            data.Add(new {
                ID = 4,
                Name = "按部门名称查询"
            });
            data.Add(new {
                ID = 5,
                Name = "按设备编号查询"
            });
            if (CurWorkerType == EnmWorkerType.WXRY) {
                data.Add(new {
                    ID = 6,
                    Name = "按责任人工号查询"
                });
                data.Add(new {
                    ID = 7,
                    Name = "按责任人姓名查询"
                });
            }

            SearchTypeCB.ValueMember = "ID";
            SearchTypeCB.DisplayMember = "Name";
            SearchTypeCB.DataSource = data;
        }

        /// <summary>
        /// Search Type Combobox Selected Index Changed Event.
        /// </summary>
        private void SearchTypeCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (!String.IsNullOrWhiteSpace(SearchTB.Text)) {
                    BindAuthToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BitchUpdateEndTimeForm.SearchTypeCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView CellValue Needed Event.
        /// </summary>
        private void AuthGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > TotalRecords.Count - 1) { return; }
                switch (AuthGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EIDColumn":
                        e.Value = TotalRecords[e.RowIndex].Value3.WorkerId;
                        break;
                    case "NameColumn":
                        e.Value = TotalRecords[e.RowIndex].Value3.WorkerName;
                        break;
                    case "DeptNameColumn":
                        e.Value = String.Format("{0} - {1}", TotalRecords[e.RowIndex].Value3.DepId, TotalRecords[e.RowIndex].Value3.DepName);
                        break;
                    case "CardSnColumn":
                        e.Value = TotalRecords[e.RowIndex].Value3.CardSn;
                        break;
                    case "DevIDColumn":
                        e.Value = TotalRecords[e.RowIndex].Value1.DevID;
                        break;
                    case "DevNameColumn":
                        e.Value = GetDeviceRemark(TotalRecords[e.RowIndex].Value1);
                        break;
                    case "BeginTimeColumn":
                        e.Value = Common.GetDateTimeString(TotalRecords[e.RowIndex].Value2.BeginTime);
                        break;
                    case "EndTimeColumn":
                        e.Value = Common.GetDateTimeString(TotalRecords[e.RowIndex].Value2.EndTime);
                        break;
                    case "LimitColumn":
                        e.Value = ComUtility.GetLimitIDText(TotalRecords[e.RowIndex].Value2.LimitId);
                        break;
                    case "LimitIndexColumn":
                        e.Value = TotalRecords[e.RowIndex].Value2.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : TotalRecords[e.RowIndex].Value2.LimitIndex.ToString();
                        break;
                    case "EnabledColumn":
                        e.Value = TotalRecords[e.RowIndex].Value2.Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BitchUpdateEndTimeForm.AuthGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Limit Type Combobox.
        /// </summary>
        private void BindLimitTypeCombobox() {
            var data = new List<object>();
            data.Add(new {
                ID = (Int32)EnmLimitID.TQ,
                Name = ComUtility.GetLimitIDText(EnmLimitID.TQ)
            });
            data.Add(new {
                ID = (Int32)EnmLimitID.WTMG,
                Name = ComUtility.GetLimitIDText(EnmLimitID.WTMG)
            });
            data.Add(new {
                ID = (Int32)EnmLimitID.DTM,
                Name = ComUtility.GetLimitIDText(EnmLimitID.DTM)
            });

            LimitTypeCB.ValueMember = "ID";
            LimitTypeCB.DisplayMember = "Name";
            LimitTypeCB.DataSource = data;
        }

        /// <summary>
        /// Limit Type SelectedIndex Changed Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LimitTypeCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (LimitTypeCB.SelectedValue != null) {
                    var type = (Int32)LimitTypeCB.SelectedValue;
                    BindLimitIndexCombobox((EnmLimitID)type);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BitchUpdateEndTimeForm.LimitTypeCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Limit Index Combobox By Limit Id.
        /// </summary>
        /// <param name="limitId">Limit Id</param>
        private void BindLimitIndexCombobox(EnmLimitID limitId) {
            LimitIndexCB.Enabled = true;
            var data = new List<IDValuePair<Int32, String>>();
            switch (limitId) {
                case EnmLimitID.TQ:
                    LimitIndexCB.Enabled = false;
                    break;
                case EnmLimitID.WTMG:
                    for (var i = 0; i < 16; i++) {
                        data.Add(new IDValuePair<Int32, String>(i, String.Format("第{0}组", i + 1)));
                    }
                    break;
                case EnmLimitID.DTM:
                    for (var i = 1; i <= 4; i++) {
                        data.Add(new IDValuePair<Int32, String>(i, String.Format("第{0}组", i)));
                    }
                    break;
                default:
                    break;
            }

            LimitIndexCB.ValueMember = "ID";
            LimitIndexCB.DisplayMember = "Value";
            LimitIndexCB.DataSource = data;
        }

        /// <summary>
        /// Search Button Click Event.
        /// </summary>
        private void SearchBtn_Click(object sender, EventArgs e) {
            try {
                BindAuthToGridView();
                SaveBtn.Enabled = TotalRecords.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BitchUpdateEndTimeForm.SearchBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save Button Click Event.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                if (TotalRecords.Count == 0) {
                    MessageBox.Show("暂无需要保存的记录", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("您确定要保存吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var target = new CardAuthInfo();
                    target.BeginTime = BeginTimeDTP.Value;
                    target.EndTime = EndTimeDTP.Value;
                    target.Password = PwdCB.Text.Trim();
                    target.Enabled = true;
                    var limitId = (Int32)LimitTypeCB.SelectedValue;
                    switch ((EnmLimitID)limitId) {
                        case EnmLimitID.TQ:
                            target.LimitId = EnmLimitID.TQ;
                            target.LimitIndex = ComUtility.DefaultInt32;
                            break;
                        case EnmLimitID.WTMG:
                            target.LimitId = EnmLimitID.WTMG;
                            target.LimitIndex = Convert.ToInt32(LimitIndexCB.SelectedValue);
                            break;
                        case EnmLimitID.DTM:
                            target.LimitId = EnmLimitID.DTM;
                            target.LimitIndex = Convert.ToInt32(LimitIndexCB.SelectedValue);
                            break;
                    }

                    var ids = new List<IDValuePair<Int32, String>>();
                    foreach (var tr in TotalRecords) {
                        var id = new IDValuePair<Int32, String>(tr.Value2.RtuId, tr.Value2.CardSn);
                        ids.Add(id);
                    }

                    var result = Common.ShowWait(() => {
                        new CardAuth().UpdateBitchCardAuth(ids, target);
                    }, default(string), "正在保存，请稍后...", default(int), default(int), 1800);

                    if (result == DialogResult.OK) {
                        foreach (var tr in TotalRecords) {
                            Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.BitchUpdateEndTimeForm.SaveBtn.Click", String.Format("更新卡片授权[设备:{0} 卡号:{1}]", tr.Value2.DevId, tr.Value2.CardSn), null);
                        }

                        BindAuthToGridView();
                        MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BitchUpdateEndTimeForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Auth To GridView.
        /// </summary>
        private void BindAuthToGridView() {
            TotalRecords.Clear();
            AuthGridView.Rows.Clear();
            if (!String.IsNullOrWhiteSpace(SearchTB.Text)) {
                var auths = new CardAuth().GetCardAuthByCondition(Convert.ToInt32(SearchTypeCB.SelectedValue), CurWorkerType, SearchTB.Text.Trim());
                TotalRecords.AddRange(
                    from a in auths
                    join d in Devices.Values on a.DevId equals d.DevID
                    join c in CurCards on a.CardSn equals c.CardSn
                    orderby c.WorkerId
                    select new ValuesPair<DeviceInfo, CardAuthInfo, CardInfo, String, String> {
                        Value1 = d,
                        Value2 = a,
                        Value3 = c
                    }
                );
            }

            AuthGridView.RowCount = TotalRecords.Count;
        }

        /// <summary>
        /// Get Device Remark.
        /// </summary>
        /// <param name="dev">device</param>
        private String GetDeviceRemark(DeviceInfo dev) {
            return dev == null ? String.Empty : String.Format("{0}>{1}>{2}>{3}", dev.Area2Name, dev.Area3Name, dev.StaName, dev.DevName);
        }
    }
}