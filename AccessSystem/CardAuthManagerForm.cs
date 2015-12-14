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
    public partial class CardAuthManagerForm : Form
    {
        /// <summary>
        /// Gloal variables.
        /// </summary>
        private CardAuth CardAuthEntity;
        private List<CardInfo> OrgCards;
        private List<CardInfo> OutCards;
        private List<NodeLevelInfo> Nodes;
        private Dictionary<Int32, DeviceInfo> Devices;
        private List<DepartmentInfo> Departments;
        private List<OrgEmployeeInfo> OrgEmployees;
        private List<OutEmployeeInfo> OutEmployees;
        private List<IDValuePair<OrgEmployeeInfo, CardAuthInfo>> OrgDevCardAuth;
        private List<IDValuePair<OutEmployeeInfo, CardAuthInfo>> OutDevCardAuth;
        private List<IDValuePair<DeviceInfo, CardAuthInfo>> OrgEmpCardAuth;
        private List<IDValuePair<DeviceInfo, CardAuthInfo>> OutEmpCardAuth;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public CardAuthManagerForm() {
            InitializeComponent();
            CardAuthEntity = new CardAuth();
            OrgCards = new List<CardInfo>();
            OutCards = new List<CardInfo>();
            Nodes = new List<NodeLevelInfo>();
            Devices = new Dictionary<Int32, DeviceInfo>();
            Departments = new List<DepartmentInfo>();
            OrgEmployees = new List<OrgEmployeeInfo>();
            OutEmployees = new List<OutEmployeeInfo>();
            OrgDevCardAuth = new List<IDValuePair<OrgEmployeeInfo, CardAuthInfo>>();
            OutDevCardAuth = new List<IDValuePair<OutEmployeeInfo, CardAuthInfo>>();
            OrgEmpCardAuth = new List<IDValuePair<DeviceInfo, CardAuthInfo>>();
            OutEmpCardAuth = new List<IDValuePair<DeviceInfo, CardAuthInfo>>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void CardAuthManagerForm_Load(object sender, EventArgs e) {
            try {
                AuthBtn1.Enabled = false;
                CancelAuthBtn1.Enabled = false;
                ExportDataBtn1.Enabled = false;

                AuthBtn2.Enabled = false;
                CancelAuthBtn2.Enabled = false;
                ExportDataBtn2.Enabled = false;

                AuthBtn3.Enabled = false;
                CancelAuthBtn3.Enabled = false;
                ExportDataBtn3.Enabled = false;

                AuthBtn4.Enabled = false;
                CancelAuthBtn4.Enabled = false;
                ExportDataBtn4.Enabled = false;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void CardAuthManagerForm_Shown(object sender, EventArgs e) {
            try {
                BindSearchType();
                var DevTempTreeView = new TreeView();
                var OrgEmpTempTreeView = new TreeView();
                var OutEmpTempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    Nodes = Common.CurUser.Role.Nodes;
                    Devices = Common.CurUser.Role.Devices;
                    Departments = Common.CurUser.Role.Departments;
                    OrgCards = new Card().GetOrgCards(Common.CurUser.Role.RoleID);
                    OutCards = new Card().GetOutCards(Common.CurUser.Role.RoleID);
                    OrgEmployees = new Employee().GetOrgEmployees(Common.CurUser.Role.RoleID);
                    OutEmployees = new Employee().GetOutEmployees(Common.CurUser.Role.RoleID);

                    BindDeviceToTreeView(DevTempTreeView);
                    BindOrgEmployeesToTreeView(OrgEmpTempTreeView);
                    BindOutEmployeesToTreeView(OutEmpTempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    DeviceTreeView1.Nodes.Clear();
                    DeviceTreeView2.Nodes.Clear();
                    EmpTreeView3.Nodes.Clear();
                    EmpTreeView4.Nodes.Clear();
                    foreach (TreeNode tn in DevTempTreeView.Nodes) {
                        DeviceTreeView1.Nodes.Add((TreeNode)tn.Clone());
                        DeviceTreeView2.Nodes.Add((TreeNode)tn.Clone());
                    }

                    foreach (TreeNode tn in OrgEmpTempTreeView.Nodes) {
                        EmpTreeView3.Nodes.Add((TreeNode)tn.Clone());
                    }

                    foreach (TreeNode tn in OutEmpTempTreeView.Nodes) {
                        EmpTreeView4.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (DeviceTreeView1.Nodes.Count > 0) {
                        var root = DeviceTreeView1.Nodes[0];
                        DeviceTreeView1.SelectedNode = root;
                        root.Expand();
                    }

                    if (DeviceTreeView2.Nodes.Count > 0) {
                        var root = DeviceTreeView2.Nodes[0];
                        DeviceTreeView2.SelectedNode = root;
                        root.Expand();
                    }

                    if (EmpTreeView3.Nodes.Count > 0) {
                        var root = EmpTreeView3.Nodes[0];
                        EmpTreeView3.SelectedNode = root;
                        root.Expand();
                    }

                    if (EmpTreeView4.Nodes.Count > 0) {
                        var root = EmpTreeView4.Nodes[0];
                        EmpTreeView4.SelectedNode = root;
                        root.Expand();
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device TreeView AfterSelect Event.
        /// </summary>
        private void DeviceTreeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                var tag = (NodeLevelInfo)e.Node.Tag;
                AuthBtn1.Enabled = tag != null && tag.NodeType == EnmNodeType.Dev;
                CancelAuthBtn1.Enabled = tag != null && tag.NodeType == EnmNodeType.Dev;
                ExportDataBtn1.Enabled = tag != null && tag.NodeType == EnmNodeType.Dev;
                BindAuthToGridView1();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.DeviceTreeView1.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device TreeView AfterSelect Event.
        /// </summary>
        private void DeviceTreeView2_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                var tag = (NodeLevelInfo)e.Node.Tag;
                AuthBtn2.Enabled = tag != null && tag.NodeType == EnmNodeType.Dev;
                CancelAuthBtn2.Enabled = tag != null && tag.NodeType == EnmNodeType.Dev;
                ExportDataBtn2.Enabled = tag != null && tag.NodeType == EnmNodeType.Dev;
                BindAuthToGridView2();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.DeviceTreeView2.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OrgEmployee TreeView AfterSelect Event.
        /// </summary>
        private void EmpTreeView3_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                var tag = (IDValuePair<Int32, String>)e.Node.Tag;
                AuthBtn3.Enabled = tag != null && tag.ID == 1;
                CancelAuthBtn3.Enabled = tag != null && tag.ID == 1;
                ExportDataBtn3.Enabled = tag != null && tag.ID == 1;
                BindAuthToGridView3();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.EmpTreeView3.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView After Select Event.
        /// </summary>
        private void EmpTreeView4_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                var tag = (IDValuePair<Int32, String>)e.Node.Tag;
                AuthBtn4.Enabled = tag != null && tag.ID == 2;
                CancelAuthBtn4.Enabled = tag != null && tag.ID == 2;
                ExportDataBtn4.Enabled = tag != null && tag.ID == 2;
                BindAuthToGridView4();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.EmpTreeView4.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView1 CellValue Needed Event.
        /// </summary>
        private void AuthGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > OrgDevCardAuth.Count - 1) { return; }
                switch (AuthGridView1.Columns[e.ColumnIndex].Name) {
                    case "IDColumn1":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EIDColumn1":
                        e.Value = OrgDevCardAuth[e.RowIndex].ID.EmpId;
                        break;
                    case "NameColumn1":
                        e.Value = OrgDevCardAuth[e.RowIndex].ID.EmpName;
                        break;
                    case "DepNameColumn1":
                        e.Value = String.Format("{0} - {1}", OrgDevCardAuth[e.RowIndex].ID.DepId, OrgDevCardAuth[e.RowIndex].ID.DepName);
                        break;
                    case "CardSnColumn1":
                        e.Value = OrgDevCardAuth[e.RowIndex].Value.CardSn;
                        break;
                    case "BeginTimeColumn1":
                        e.Value = Common.GetDateTimeString(OrgDevCardAuth[e.RowIndex].Value.BeginTime);
                        break;
                    case "EndTimeColumn1":
                        e.Value = Common.GetDateTimeString(OrgDevCardAuth[e.RowIndex].Value.EndTime);
                        break;
                    case "LimitColumn1":
                        e.Value = ComUtility.GetLimitIDText(OrgDevCardAuth[e.RowIndex].Value.LimitId);
                        break;
                    case "LimitIndexColumn1":
                        e.Value = OrgDevCardAuth[e.RowIndex].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : OrgDevCardAuth[e.RowIndex].Value.LimitIndex.ToString();
                        break;
                    case "EnabledColumn1":
                        e.Value = OrgDevCardAuth[e.RowIndex].Value.Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView1.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView2 CellValue Needed Event.
        /// </summary>
        private void AuthGridView2_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > OutDevCardAuth.Count - 1) { return; }
                switch (AuthGridView2.Columns[e.ColumnIndex].Name) {
                    case "IDColumn2":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EIDColumn2":
                        e.Value = OutDevCardAuth[e.RowIndex].ID.EmpId;
                        break;
                    case "NameColumn2":
                        e.Value = OutDevCardAuth[e.RowIndex].ID.EmpName;
                        break;
                    case "PENameColumn2":
                        e.Value = String.Format("{0} - {1}", OutDevCardAuth[e.RowIndex].ID.ParentEmpId, OutDevCardAuth[e.RowIndex].ID.ParentEmpName);
                        break;
                    case "DepNameColumn2":
                        e.Value = String.Format("{0} - {1}", OutDevCardAuth[e.RowIndex].ID.DepId, OutDevCardAuth[e.RowIndex].ID.DepName);
                        break;
                    case "CardSnColumn2":
                        e.Value = OutDevCardAuth[e.RowIndex].Value.CardSn;
                        break;
                    case "BeginTimeColumn2":
                        e.Value = Common.GetDateTimeString(OutDevCardAuth[e.RowIndex].Value.BeginTime);
                        break;
                    case "EndTimeColumn2":
                        e.Value = Common.GetDateTimeString(OutDevCardAuth[e.RowIndex].Value.EndTime);
                        break;
                    case "LimitColumn2":
                        e.Value = ComUtility.GetLimitIDText(OutDevCardAuth[e.RowIndex].Value.LimitId);
                        break;
                    case "LimitIndexColumn2":
                        e.Value = OutDevCardAuth[e.RowIndex].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : OutDevCardAuth[e.RowIndex].Value.LimitIndex.ToString();
                        break;
                    case "EnabledColumn2":
                        e.Value = OutDevCardAuth[e.RowIndex].Value.Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView2.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView3 CellValue Needed Event.
        /// </summary>
        private void AuthGridView3_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > OrgEmpCardAuth.Count - 1) { return; }
                switch (AuthGridView3.Columns[e.ColumnIndex].Name) {
                    case "IDColumn3":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "DevIDColumn3":
                        e.Value = OrgEmpCardAuth[e.RowIndex].Value.DevId;
                        break;
                    case "DevNameColumn3":
                        e.Value = GetDeviceRemark(OrgEmpCardAuth[e.RowIndex].ID);
                        break;
                    case "CardSnColumn3":
                        e.Value = OrgEmpCardAuth[e.RowIndex].Value.CardSn;
                        break;
                    case "BeginTimeColumn3":
                        e.Value = Common.GetDateTimeString(OrgEmpCardAuth[e.RowIndex].Value.BeginTime);
                        break;
                    case "EndTimeColumn3":
                        e.Value = Common.GetDateTimeString(OrgEmpCardAuth[e.RowIndex].Value.EndTime);
                        break;
                    case "LimitColumn3":
                        e.Value = ComUtility.GetLimitIDText(OrgEmpCardAuth[e.RowIndex].Value.LimitId);
                        break;
                    case "LimitIndexColumn3":
                        e.Value = OrgEmpCardAuth[e.RowIndex].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : OrgEmpCardAuth[e.RowIndex].Value.LimitIndex.ToString();
                        break;
                    case "EnabledColumn3":
                        e.Value = OrgEmpCardAuth[e.RowIndex].Value.Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView3.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView4 CellValue Needed Event.
        /// </summary>
        private void AuthGridView4_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > OutEmpCardAuth.Count - 1) { return; }
                switch (AuthGridView4.Columns[e.ColumnIndex].Name) {
                    case "IDColumn4":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "DevIDColumn4":
                        e.Value = OutEmpCardAuth[e.RowIndex].Value.DevId;
                        break;
                    case "DevNameColumn4":
                        e.Value = GetDeviceRemark(OutEmpCardAuth[e.RowIndex].ID);
                        break;
                    case "CardSnColumn4":
                        e.Value = OutEmpCardAuth[e.RowIndex].Value.CardSn;
                        break;
                    case "BeginTimeColumn4":
                        e.Value = Common.GetDateTimeString(OutEmpCardAuth[e.RowIndex].Value.BeginTime);
                        break;
                    case "EndTimeColumn4":
                        e.Value = Common.GetDateTimeString(OutEmpCardAuth[e.RowIndex].Value.EndTime);
                        break;
                    case "LimitColumn4":
                        e.Value = ComUtility.GetLimitIDText(OutEmpCardAuth[e.RowIndex].Value.LimitId);
                        break;
                    case "LimitIndexColumn4":
                        e.Value = OutEmpCardAuth[e.RowIndex].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : OutEmpCardAuth[e.RowIndex].Value.LimitIndex.ToString();
                        break;
                    case "EnabledColumn4":
                        e.Value = OutEmpCardAuth[e.RowIndex].Value.Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView3.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView1 CellContent Click Event.
        /// </summary>
        private void AuthGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key = (String)AuthGridView1.Rows[e.RowIndex].Cells["CardSnColumn1"].Value;
                var obj = OrgDevCardAuth.Find(d => d.Value.CardSn.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (AuthGridView1.Columns[e.ColumnIndex].Name) {
                    case "CancelColumn1":
                        if (MessageBox.Show(String.Format("卡片[{0}]将被撤权，您确定要撤权吗？",obj.Value.CardSn), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardAuthEntity.DeleteCardAuth(new List<IDValuePair<Int32, String>>() { new IDValuePair<Int32, String>(obj.Value.DevId, obj.Value.CardSn) });
                            }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                OrgDevCardAuth.Remove(obj);
                                AuthGridView1.Rows.RemoveAt(e.RowIndex);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView1.CellContentClick", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", obj.Value.DevId, obj.Value.CardSn), null);
                            }
                        }
                        break;
                    case "EditColumn1":
                        var card = OrgCards.Find(c => c.CardSn.Equals(obj.Value.CardSn));
                        if (card == null) {
                            MessageBox.Show("未找到卡片信息", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (new SaveCardAuthForm(EnmSaveBehavior.Edit, card, obj.Value, OrgCards, Departments, OrgEmployees, OutEmployees).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            AuthGridView1.InvalidateRow(e.RowIndex);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView1.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView2 Cell Content Click Event.
        /// </summary>
        private void AuthGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key = (String)AuthGridView2.Rows[e.RowIndex].Cells["CardSnColumn2"].Value;
                var obj = OutDevCardAuth.Find(d => d.Value.CardSn.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (AuthGridView2.Columns[e.ColumnIndex].Name) {
                    case "CancelColumn2":
                        if (MessageBox.Show(String.Format("卡片[{0}]将被撤权，您确定要撤权吗？", obj.Value.CardSn), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardAuthEntity.DeleteCardAuth(new List<IDValuePair<Int32, String>>() { new IDValuePair<Int32, String>(obj.Value.DevId, obj.Value.CardSn) });
                            }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                OutDevCardAuth.Remove(obj);
                                AuthGridView2.Rows.RemoveAt(e.RowIndex);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView2.CellContentClick", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", obj.Value.DevId, obj.Value.CardSn), null);
                            }
                        }
                        break;
                    case "EditColumn2":
                        var card = OutCards.Find(c => c.CardSn.Equals(obj.Value.CardSn));
                        if (card == null) {
                            MessageBox.Show("未找到卡片信息", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (new SaveCardAuthForm(EnmSaveBehavior.Edit, card, obj.Value, OutCards, Departments, OrgEmployees, OutEmployees).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            AuthGridView2.InvalidateRow(e.RowIndex);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView2.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView3 Cell Content Click Event.
        /// </summary>
        private void AuthGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key1 = (Int32)AuthGridView3.Rows[e.RowIndex].Cells["DevIDColumn3"].Value;
                var key2 = (String)AuthGridView3.Rows[e.RowIndex].Cells["CardSnColumn3"].Value;
                var obj = OrgEmpCardAuth.Find(oe => oe.Value.DevId == key1 && oe.Value.CardSn.Equals(key2));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (AuthGridView3.Columns[e.ColumnIndex].Name) {
                    case "CancelColumn3":
                        if (MessageBox.Show(String.Format("门禁设备[{0} - {1}]将被撤权，您确定要撤权吗？", obj.ID.DevID, obj.ID.DevName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardAuthEntity.DeleteCardAuth(new List<IDValuePair<Int32, String>>() { new IDValuePair<Int32, String>(obj.Value.DevId, obj.Value.CardSn) });
                            }, default(string), "正在撤权，请稍后...", default(int), default(int));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                OrgEmpCardAuth.Remove(obj);
                                AuthGridView3.Rows.RemoveAt(e.RowIndex);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView3.CellContentClick", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", obj.Value.DevId, obj.Value.CardSn), null);
                            }
                        }
                        break;
                    case "EditColumn3":
                        if (new SaveCardDevAuthForm(EnmSaveBehavior.Edit, new List<CardAuthInfo>() { obj.Value }, Nodes).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            AuthGridView3.InvalidateRow(e.RowIndex);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView3.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Auth GridView4 Cell Content Click Event.
        /// </summary>
        private void AuthGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key1 = (Int32)AuthGridView4.Rows[e.RowIndex].Cells["DevIDColumn4"].Value;
                var key2 = (String)AuthGridView4.Rows[e.RowIndex].Cells["CardSnColumn4"].Value;
                var obj = OutEmpCardAuth.Find(oe => oe.Value.DevId == key1 && oe.Value.CardSn.Equals(key2));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (AuthGridView4.Columns[e.ColumnIndex].Name) {
                    case "CancelColumn4":
                        if (MessageBox.Show(String.Format("门禁设备[{0} - {1}]将被撤权，您确定要撤权吗？", obj.ID.DevID, obj.ID.DevName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardAuthEntity.DeleteCardAuth(new List<IDValuePair<Int32, String>>() { new IDValuePair<Int32, String>(obj.Value.DevId, obj.Value.CardSn) });
                            }, default(string), "正在撤权，请稍后...", default(int), default(int));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                OutEmpCardAuth.Remove(obj);
                                AuthGridView4.Rows.RemoveAt(e.RowIndex);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView4.CellContentClick", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", obj.Value.DevId, obj.Value.CardSn), null);
                            }
                        }
                        break;
                    case "EditColumn4":
                        if (new SaveCardDevAuthForm(EnmSaveBehavior.Edit, new List<CardAuthInfo>() { obj.Value }, Nodes).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            AuthGridView4.InvalidateRow(e.RowIndex);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthGridView4.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void AuthBtn1_Click(object sender, EventArgs e) {
            try {
                if (DeviceTreeView1.SelectedNode != null) {
                    var tag = (NodeLevelInfo)DeviceTreeView1.SelectedNode.Tag;
                    if (tag != null && tag.NodeType == EnmNodeType.Dev) {
                        var CardAuth = new CardAuthInfo() {
                            CardSn = String.Empty,
                            DevId = tag.NodeID,
                            LimitId = EnmLimitID.TQ,
                            LimitIndex = 0,
                            BeginTime = DateTime.Today,
                            EndTime = new DateTime(2099, 12, 31),
                            Password = String.Empty,
                            Enabled = true,
                            Remark = String.Empty
                        };

                        if (new SaveCardAuthForm(EnmSaveBehavior.Add, new CardInfo() { WorkerType = EnmWorkerType.ZSYG }, CardAuth, OrgCards, Departments, OrgEmployees, OutEmployees).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            BindAuthToGridView1();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthBtn1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void AuthBtn2_Click(object sender, EventArgs e) {
            try {
                if (DeviceTreeView2.SelectedNode != null) {
                    var tag = (NodeLevelInfo)DeviceTreeView2.SelectedNode.Tag;
                    if (tag != null && tag.NodeType == EnmNodeType.Dev) {
                        var CardAuth = new CardAuthInfo() {
                            CardSn = String.Empty,
                            DevId = tag.NodeID,
                            LimitId = EnmLimitID.TQ,
                            LimitIndex = 0,
                            BeginTime = DateTime.Today,
                            EndTime = DateTime.Today.AddMonths(3),
                            Password = String.Empty,
                            Enabled = true,
                            Remark = String.Empty
                        };

                        if (new SaveCardAuthForm(EnmSaveBehavior.Add, new CardInfo() { WorkerType = EnmWorkerType.WXRY }, CardAuth, OutCards, Departments, OrgEmployees, OutEmployees).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            BindAuthToGridView2();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthBtn2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void AuthBtn3_Click(object sender, EventArgs e) {
            try {
                if (EmpTreeView3.SelectedNode != null) {
                    var tag = (IDValuePair<Int32, String>)EmpTreeView3.SelectedNode.Tag;
                    if (tag != null && tag.ID == 1) {
                        var EmpCards = OrgCards.FindAll(c => c.WorkerId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase));
                        if (EmpCards.Count == 0) {
                            MessageBox.Show("该员工未分配卡片，无法授权。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var CardAuth = new List<CardAuthInfo>();
                        foreach (var ec in EmpCards) {
                            CardAuth.Add(new CardAuthInfo() {
                                CardSn = ec.CardSn,
                                DevId = -1,
                                LimitId = EnmLimitID.TQ,
                                LimitIndex = 0,
                                BeginTime = DateTime.Today,
                                EndTime = new DateTime(2099, 12, 31),
                                Password = String.Empty,
                                Enabled = true,
                                Remark = String.Empty
                            });
                        }

                        if (new SaveCardDevAuthForm(EnmSaveBehavior.Add, CardAuth, Nodes).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            BindAuthToGridView3();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthBtn3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void AuthBtn4_Click(object sender, EventArgs e) {
            try {
                if (EmpTreeView4.SelectedNode != null) {
                    var tag = (IDValuePair<Int32, String>)EmpTreeView4.SelectedNode.Tag;
                    if (tag != null && tag.ID == 2) {
                        var EmpCards = OutCards.FindAll(c => c.WorkerId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase));
                        if (EmpCards.Count == 0) {
                            MessageBox.Show("该人员未分配卡片，无法授权。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var CardAuth = new List<CardAuthInfo>();
                        foreach (var ec in EmpCards) {
                            CardAuth.Add(new CardAuthInfo() {
                                CardSn = ec.CardSn,
                                DevId = -1,
                                LimitId = EnmLimitID.TQ,
                                LimitIndex = 0,
                                BeginTime = DateTime.Today,
                                EndTime = DateTime.Today.AddMonths(3),
                                Password = String.Empty,
                                Enabled = true,
                                Remark = String.Empty
                            });
                        }

                        if (new SaveCardDevAuthForm(EnmSaveBehavior.Add, CardAuth, Nodes).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            BindAuthToGridView4();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.AuthBtn4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void CancelAuthBtn1_Click(object sender, EventArgs e) {
            try {
                if (AuthGridView1.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部撤权吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            CardAuthEntity.DeleteCardAuth(OrgDevCardAuth.Select(odca => new IDValuePair<Int32, String>(odca.Value.DevId, odca.Value.CardSn)).ToList());
                        }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var dc in OrgDevCardAuth) {
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.CancelAuthBtn1.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", dc.Value.DevId, dc.Value.CardSn), null);
                            }
                            OrgDevCardAuth.Clear();
                            AuthGridView1.Rows.Clear();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.CancelAuthBtn1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void CancelAuthBtn2_Click(object sender, EventArgs e) {
            try {
                if (AuthGridView2.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部撤权吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            CardAuthEntity.DeleteCardAuth(OutDevCardAuth.Select(odca => new IDValuePair<Int32, String>(odca.Value.DevId, odca.Value.CardSn)).ToList());
                        }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var dc in OutDevCardAuth) {
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.CancelAuthBtn2.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", dc.Value.DevId, dc.Value.CardSn), null);
                            }
                            OutDevCardAuth.Clear();
                            AuthGridView2.Rows.Clear();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.CancelAuthBtn2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void CancelAuthBtn3_Click(object sender, EventArgs e) {
            try {
                if (AuthGridView3.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部撤权吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            CardAuthEntity.DeleteCardAuth(OrgEmpCardAuth.Select(odca => new IDValuePair<Int32, String>(odca.Value.DevId, odca.Value.CardSn)).ToList());
                        }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var ec in OrgEmpCardAuth) {
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.CancelAuthBtn3.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", ec.Value.DevId, ec.Value.CardSn), null);
                            }
                            OrgEmpCardAuth.Clear();
                            AuthGridView3.Rows.Clear();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.CancelAuthBtn3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void CancelAuthBtn4_Click(object sender, EventArgs e) {
            try {
                if (AuthGridView4.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部撤权吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            CardAuthEntity.DeleteCardAuth(OutEmpCardAuth.Select(odca => new IDValuePair<Int32, String>(odca.Value.DevId, odca.Value.CardSn)).ToList());
                        }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var ec in OutEmpCardAuth) {
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.CancelAuthBtn4.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", ec.Value.DevId, ec.Value.CardSn), null);
                            }
                            OutEmpCardAuth.Clear();
                            AuthGridView4.Rows.Clear();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.CancelAuthBtn4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void ExportDataBtn1_Click(object sender, EventArgs e) {
            try {
                if (OrgDevCardAuth.Count > 0) {
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

                    for (var i = 0; i < OrgDevCardAuth.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["工号"] = OrgDevCardAuth[i].ID.EmpId;
                        dr["姓名"] = OrgDevCardAuth[i].ID.EmpName;
                        dr["部门"] = String.Format("{0} - {1}", OrgDevCardAuth[i].ID.DepId, OrgDevCardAuth[i].ID.DepName);
                        dr["卡号"] = OrgDevCardAuth[i].Value.CardSn;
                        dr["开始日期"] = Common.GetDateString(OrgDevCardAuth[i].Value.BeginTime);
                        dr["结束日期"] = Common.GetDateString(OrgDevCardAuth[i].Value.EndTime);
                        dr["权限类型"] = ComUtility.GetLimitIDText(OrgDevCardAuth[i].Value.LimitId);
                        dr["权限分组"] = OrgDevCardAuth[i].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : OrgDevCardAuth[i].Value.LimitIndex.ToString();
                        dr["状态"] = OrgDevCardAuth[i].Value.Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "设备授权信息", "智能门禁管理系统 设备授权信息报表", String.Format("操作员:{0}{1}  日期:{2} 设备:{3} - {4}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now), OrgDevCardAuth[0].Value.DevId, GetDeviceRemark(OrgDevCardAuth[0].Value.DevId)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.ExportDataBtn1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void ExportDataBtn2_Click(object sender, EventArgs e) {
            try {
                if (OutDevCardAuth.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("工号", typeof(String));
                    data.Columns.Add("姓名", typeof(String));
                    data.Columns.Add("责任人", typeof(String));
                    data.Columns.Add("部门", typeof(String));
                    data.Columns.Add("卡号", typeof(String));
                    data.Columns.Add("开始日期", typeof(String));
                    data.Columns.Add("结束日期", typeof(String));
                    data.Columns.Add("权限类型", typeof(String));
                    data.Columns.Add("权限分组", typeof(String));
                    data.Columns.Add("状态", typeof(String));

                    for (var i = 0; i < OutDevCardAuth.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["工号"] = OutDevCardAuth[i].ID.EmpId;
                        dr["姓名"] = OutDevCardAuth[i].ID.EmpName;
                        dr["责任人"] = String.Format("{0} - {1}", OutDevCardAuth[i].ID.ParentEmpId, OutDevCardAuth[i].ID.ParentEmpName);
                        dr["部门"] = String.Format("{0} - {1}", OutDevCardAuth[i].ID.DepId, OutDevCardAuth[i].ID.DepName);
                        dr["卡号"] = OutDevCardAuth[i].Value.CardSn;
                        dr["开始日期"] = Common.GetDateString(OutDevCardAuth[i].Value.BeginTime);
                        dr["结束日期"] = Common.GetDateString(OutDevCardAuth[i].Value.EndTime);
                        dr["权限类型"] = ComUtility.GetLimitIDText(OutDevCardAuth[i].Value.LimitId);
                        dr["权限分组"] = OutDevCardAuth[i].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : OutDevCardAuth[i].Value.LimitIndex.ToString();
                        dr["状态"] = OutDevCardAuth[i].Value.Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "设备授权信息", "智能门禁管理系统 设备授权信息报表", String.Format("操作员:{0}{1}  日期:{2} 设备:{3} - {4}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now), OutDevCardAuth[0].Value.DevId, GetDeviceRemark(OutDevCardAuth[0].Value.DevId)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.ExportDataBtn2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void ExportDataBtn3_Click(object sender, EventArgs e) {
            try {
                if (OrgEmpCardAuth.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("设备编号", typeof(String));
                    data.Columns.Add("设备描述", typeof(String));
                    data.Columns.Add("卡号", typeof(String));
                    data.Columns.Add("开始日期", typeof(String));
                    data.Columns.Add("结束日期", typeof(String));
                    data.Columns.Add("权限类型", typeof(String));
                    data.Columns.Add("权限分组", typeof(String));
                    data.Columns.Add("状态", typeof(String));

                    for (var i = 0; i < OrgEmpCardAuth.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["设备编号"] = OrgEmpCardAuth[i].Value.DevId;
                        dr["设备描述"] = GetDeviceRemark(OrgEmpCardAuth[i].ID);
                        dr["卡号"] = OrgEmpCardAuth[i].Value.CardSn;
                        dr["开始日期"] = Common.GetDateString(OrgEmpCardAuth[i].Value.BeginTime);
                        dr["结束日期"] = Common.GetDateString(OrgEmpCardAuth[i].Value.EndTime);
                        dr["权限类型"] = ComUtility.GetLimitIDText(OrgEmpCardAuth[i].Value.LimitId);
                        dr["权限分组"] = OrgEmpCardAuth[i].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : OrgEmpCardAuth[i].Value.LimitIndex.ToString();
                        dr["状态"] = OrgEmpCardAuth[i].Value.Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }


                    var card = OrgCards.Find(c => c.CardSn.Equals(OrgEmpCardAuth[0].Value.CardSn));
                    Common.ExportDataToExcel(null, "员工授权信息", "智能门禁管理系统 员工授权信息报表", String.Format("操作员:{0}{1}  日期:{2} 员工:{3} - {4}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now), card != null ? card.WorkerId : String.Empty, card != null ? card.WorkerName : String.Empty), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.ExportDataBtn3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void ExportDataBtn4_Click(object sender, EventArgs e) {
            try {
                if (OutEmpCardAuth.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("设备编号", typeof(String));
                    data.Columns.Add("设备描述", typeof(String));
                    data.Columns.Add("卡号", typeof(String));
                    data.Columns.Add("开始日期", typeof(String));
                    data.Columns.Add("结束日期", typeof(String));
                    data.Columns.Add("权限类型", typeof(String));
                    data.Columns.Add("权限分组", typeof(String));
                    data.Columns.Add("状态", typeof(String));

                    for (var i = 0; i < OutEmpCardAuth.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["设备编号"] = OutEmpCardAuth[i].Value.DevId;
                        dr["设备描述"] = GetDeviceRemark(OutEmpCardAuth[i].ID);
                        dr["卡号"] = OutEmpCardAuth[i].Value.CardSn;
                        dr["开始日期"] = Common.GetDateString(OutEmpCardAuth[i].Value.BeginTime);
                        dr["结束日期"] = Common.GetDateString(OutEmpCardAuth[i].Value.EndTime);
                        dr["权限类型"] = ComUtility.GetLimitIDText(OutEmpCardAuth[i].Value.LimitId);
                        dr["权限分组"] = OutEmpCardAuth[i].Value.LimitIndex == ComUtility.DefaultInt32 ? String.Empty : OutEmpCardAuth[i].Value.LimitIndex.ToString();
                        dr["状态"] = OutEmpCardAuth[i].Value.Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }


                    var card = OutCards.Find(c => c.CardSn.Equals(OutEmpCardAuth[0].Value.CardSn));
                    Common.ExportDataToExcel(null, "外协授权信息", "智能门禁管理系统 外协授权信息报表", String.Format("操作员:{0}{1}  日期:{2} 人员:{3} - {4}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now), card != null ? card.WorkerId : String.Empty, card != null ? card.WorkerName : String.Empty), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.ExportDataBtn4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Batch Add CardAuth Button Click.
        /// </summary>
        private void BitchAddCardAuthBtn_Click(object sender, EventArgs e) {
            try {
                if (MainTabControl.SelectedIndex == 0 || MainTabControl.SelectedIndex == 2) {
                    new BatchCardAuthForm(EnmWorkerType.ZSYG, OrgCards, Nodes, Departments, OrgEmployees, OutEmployees).ShowDialog(this);
                } else if (MainTabControl.SelectedIndex == 1 || MainTabControl.SelectedIndex == 3) {
                    new BatchCardAuthForm(EnmWorkerType.WXRY, OutCards, Nodes, Departments, OrgEmployees, OutEmployees).ShowDialog(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.BitchAddCardAuthBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Batch Cancel CardAuth Button Click.
        /// </summary>
        private void BitchCancelCardAuthBtn_Click(object sender, EventArgs e) {
            try {
                if (MainTabControl.SelectedIndex == 0 || MainTabControl.SelectedIndex == 2) {
                    new BatchCancelCardAuthForm(EnmWorkerType.ZSYG, OrgCards, Nodes, Departments, OrgEmployees, OutEmployees).ShowDialog(this);
                } else if (MainTabControl.SelectedIndex == 1 || MainTabControl.SelectedIndex == 3) {
                    new BatchCancelCardAuthForm(EnmWorkerType.WXRY, OutCards, Nodes, Departments, OrgEmployees, OutEmployees).ShowDialog(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.BitchCancelCardAuthBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Batch Update EndTime Button Click.
        /// </summary>
        private void BitchEndTimeBtn_Click(object sender, EventArgs e) {
            try {
                if (MainTabControl.SelectedIndex == 0 || MainTabControl.SelectedIndex == 2) {
                    new BitchUpdateEndTimeForm(EnmWorkerType.ZSYG, OrgCards).ShowDialog(this);
                } else if (MainTabControl.SelectedIndex == 1 || MainTabControl.SelectedIndex == 3) {
                    new BitchUpdateEndTimeForm(EnmWorkerType.WXRY, OutCards).ShowDialog(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.BitchCancelCardAuthBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void SearchBtn1_Click(object sender, EventArgs e) {
            try {
                BindAuthToGridView1();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.SearchBtn1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void SearchBtn2_Click(object sender, EventArgs e) {
            try {
                BindAuthToGridView2();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.SearchBtn2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void SearchBtn3_Click(object sender, EventArgs e) {
            try {
                BindAuthToGridView3();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.SearchBtn3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button Click Event.
        /// </summary>
        private void SearchBtn4_Click(object sender, EventArgs e) {
            try {
                BindAuthToGridView4();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.SearchBtn4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search Type Combobox Selected Index Changed Event.
        /// </summary>
        private void SearchTypeCB1_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (!String.IsNullOrWhiteSpace(SearchTB1.Text)) {
                    BindAuthToGridView1();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.SearchTypeCB1.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search Type Combobox Selected Index Changed Event.
        /// </summary>
        private void SearchTypeCB2_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (!String.IsNullOrWhiteSpace(SearchTB2.Text)) {
                    BindAuthToGridView2();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.SearchTypeCB2.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search Type Combobox Selected Index Changed Event.
        /// </summary>
        private void SearchTypeCB3_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (!String.IsNullOrWhiteSpace(SearchTB3.Text)) {
                    BindAuthToGridView3();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.SearchTypeCB3.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search Type Combobox Selected Index Changed Event.
        /// </summary>
        private void SearchTypeCB4_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (!String.IsNullOrWhiteSpace(SearchTB4.Text)) {
                    BindAuthToGridView4();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.SearchTypeCB4.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Operation Context1 Opening Event.
        /// </summary>
        private void OperationContext1_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem11.Enabled = AuthGridView1.SelectedRows.Count > 0;
                OpMenuItem12.Enabled = AuthGridView1.Rows.Count > 0;
                OpMenuItem13.Enabled = OrgDevCardAuth.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.OperationContext1.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Operation Context2 Opening Event.
        /// </summary>
        private void OperationContext2_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem21.Enabled = AuthGridView2.SelectedRows.Count > 0;
                OpMenuItem22.Enabled = AuthGridView2.Rows.Count > 0;
                OpMenuItem23.Enabled = OutDevCardAuth.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.OperationContext2.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Operation Context3 Opening Event.
        /// </summary>
        private void OperationContext3_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem31.Enabled = AuthGridView3.SelectedRows.Count > 0;
                OpMenuItem32.Enabled = AuthGridView3.Rows.Count > 0;
                OpMenuItem33.Enabled = OrgEmpCardAuth.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.OperationContext3.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Operation Context4 Opening Event.
        /// </summary>
        private void OperationContext4_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem41.Enabled = AuthGridView4.SelectedRows.Count > 0;
                OpMenuItem42.Enabled = AuthGridView4.Rows.Count > 0;
                OpMenuItem43.Enabled = OutEmpCardAuth.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.OperationContext4.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OpMenuItem11 Click Event.
        /// </summary>
        private void OpMenuItem11_Click(object sender, EventArgs e) {
            try {
                if (AuthGridView1.SelectedRows.Count > 0) {
                    var adEmps = new Dictionary<Int32, IDValuePair<OrgEmployeeInfo, CardAuthInfo>>();
                    foreach (DataGridViewRow row in AuthGridView1.SelectedRows) {
                        var key = (String)row.Cells["CardSnColumn1"].Value;
                        var obj = OrgDevCardAuth.Find(dc => dc.Value.CardSn.Equals(key));
                        if (obj != null) { adEmps[row.Index] = obj; }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中授权将被撤销，您确定要撤权吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardAuthEntity.DeleteCardAuth(adEmps.Select(ad => new IDValuePair<Int32, String>(ad.Value.Value.DevId, ad.Value.Value.CardSn)).ToList());
                            }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var ad in adEmps) {
                                    OrgDevCardAuth.Remove(ad.Value);
                                    AuthGridView1.Rows.RemoveAt(ad.Key);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.OpMenuItem11.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", ad.Value.Value.DevId, ad.Value.Value.CardSn), null);
                                }
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.OpMenuItem11.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OpMenuItem21 Click Event.
        /// </summary>
        private void OpMenuItem21_Click(object sender, EventArgs e) {
            try {
                if (AuthGridView2.SelectedRows.Count > 0) {
                    var adEmps = new Dictionary<Int32, IDValuePair<OutEmployeeInfo, CardAuthInfo>>();
                    foreach (DataGridViewRow row in AuthGridView2.SelectedRows) {
                        var key = (String)row.Cells["CardSnColumn2"].Value;
                        var obj = OutDevCardAuth.Find(dc => dc.Value.CardSn.Equals(key));
                        if (obj != null) { adEmps[row.Index] = obj; }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中授权将被撤销，您确定要撤权吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardAuthEntity.DeleteCardAuth(adEmps.Select(ad => new IDValuePair<Int32, String>(ad.Value.Value.DevId, ad.Value.Value.CardSn)).ToList());
                            }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var ad in adEmps) {
                                    OutDevCardAuth.Remove(ad.Value);
                                    AuthGridView2.Rows.RemoveAt(ad.Key);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.OpMenuItem21.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", ad.Value.Value.DevId, ad.Value.Value.CardSn), null);
                                }
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.OpMenuItem21.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OpMenuItem31 Click Event.
        /// </summary>
        private void OpMenuItem31_Click(object sender, EventArgs e) {
            try {
                if (AuthGridView3.SelectedRows.Count > 0) {
                    var adEmps = new Dictionary<Int32, IDValuePair<DeviceInfo, CardAuthInfo>>();
                    foreach (DataGridViewRow row in AuthGridView3.SelectedRows) {
                        var key1 = (Int32)row.Cells["DevIDColumn3"].Value;
                        var key2 = (String)row.Cells["CardSnColumn3"].Value;
                        var obj = OrgEmpCardAuth.Find(dc => dc.Value.DevId == key1 && dc.Value.CardSn.Equals(key2));
                        if (obj != null) { adEmps[row.Index] = obj; }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中授权将被撤销，您确定要撤权吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardAuthEntity.DeleteCardAuth(adEmps.Select(ad => new IDValuePair<Int32, String>(ad.Value.Value.DevId, ad.Value.Value.CardSn)).ToList());
                            }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var ad in adEmps) {
                                    OrgEmpCardAuth.Remove(ad.Value);
                                    AuthGridView3.Rows.RemoveAt(ad.Key);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.OpMenuItem31.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", ad.Value.Value.DevId, ad.Value.Value.CardSn), null);
                                }
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.OpMenuItem31.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OpMenuItem41 Click Event.
        /// </summary>
        private void OpMenuItem41_Click(object sender, EventArgs e) {
            try {
                if (AuthGridView4.SelectedRows.Count > 0) {
                    var adEmps = new Dictionary<Int32, IDValuePair<DeviceInfo, CardAuthInfo>>();
                    foreach (DataGridViewRow row in AuthGridView4.SelectedRows) {
                        var key1 = (Int32)row.Cells["DevIDColumn4"].Value;
                        var key2 = (String)row.Cells["CardSnColumn4"].Value;
                        var obj = OutEmpCardAuth.Find(dc => dc.Value.DevId == key1 && dc.Value.CardSn.Equals(key2));
                        if (obj != null) { adEmps[row.Index] = obj; }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中授权将被撤销，您确定要撤权吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardAuthEntity.DeleteCardAuth(adEmps.Select(ad => new IDValuePair<Int32, String>(ad.Value.Value.DevId, ad.Value.Value.CardSn)).ToList());
                            }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var ad in adEmps) {
                                    OutEmpCardAuth.Remove(ad.Value);
                                    AuthGridView4.Rows.RemoveAt(ad.Key);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CardAuthManagerForm.OpMenuItem41.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", ad.Value.Value.DevId, ad.Value.Value.CardSn), null);
                                }
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.OpMenuItem41.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OpMenuItem12 Click Event.
        /// </summary>
        private void OpMenuItem12_Click(object sender, EventArgs e) {
            CancelAuthBtn1_Click(sender, e);
        }

        /// <summary>
        /// OpMenuItem22 Click Event.
        /// </summary>
        private void OpMenuItem22_Click(object sender, EventArgs e) {
            CancelAuthBtn2_Click(sender, e);
        }

        /// <summary>
        /// OpMenuItem32 Click Event.
        /// </summary>
        private void OpMenuItem32_Click(object sender, EventArgs e) {
            CancelAuthBtn3_Click(sender, e);
        }

        /// <summary>
        /// OpMenuItem42 Click Event.
        /// </summary>
        private void OpMenuItem42_Click(object sender, EventArgs e) {
            CancelAuthBtn4_Click(sender, e);
        }

        /// <summary>
        /// OpMenuItem13 Click Event.
        /// </summary>
        private void OpMenuItem13_Click(object sender, EventArgs e) {
            ExportDataBtn1_Click(sender, e);
        }

        /// <summary>
        /// OpMenuItem23 Click Event.
        /// </summary>
        private void OpMenuItem23_Click(object sender, EventArgs e) {
            ExportDataBtn2_Click(sender, e);
        }

        /// <summary>
        /// OpMenuItem33 Click Event.
        /// </summary>
        private void OpMenuItem33_Click(object sender, EventArgs e) {
            ExportDataBtn3_Click(sender, e);
        }

        /// <summary>
        /// OpMenuItem43 Click Event.
        /// </summary>
        private void OpMenuItem43_Click(object sender, EventArgs e) {
            ExportDataBtn4_Click(sender, e);
        }

        /// <summary>
        /// MainTabControl SelectedIndexChanged Event.
        /// </summary>
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (Finder != null && !Finder.IsDisposed) { Finder.Close(); }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.MainTabControl.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item11 Click Event.
        /// </summary>
        private FinderDialog Finder = null;
        private void TVToolStripMenuItem11_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(DeviceTreeView1);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.TVToolStripMenuItem11.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item21 Click Event.
        /// </summary>
        private void TVToolStripMenuItem21_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(DeviceTreeView2);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.TVToolStripMenuItem21.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item31 Click Event.
        /// </summary>
        private void TVToolStripMenuItem31_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(EmpTreeView3);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.TVToolStripMenuItem31.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item41 Click Event.
        /// </summary>
        private void TVToolStripMenuItem41_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(EmpTreeView4);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CardAuthManagerForm.TVToolStripMenuItem41.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Search Type.
        /// </summary>
        private void BindSearchType() {
            var data1 = new List<object>();
            data1.Add(new {
                ID = 0,
                Name = "按姓名查询"
            });
            data1.Add(new {
                ID = 1,
                Name = "按工号查询"
            });
            data1.Add(new {
                ID = 2,
                Name = "按卡号查询"
            });

            SearchTypeCB1.ValueMember = "ID";
            SearchTypeCB1.DisplayMember = "Name";
            SearchTypeCB1.DataSource = data1;

            var data2 = new List<object>(data1);
            SearchTypeCB2.ValueMember = "ID";
            SearchTypeCB2.DisplayMember = "Name";
            SearchTypeCB2.DataSource = data2;

            var data3 = new List<object>();
            data3.Add(new {
                ID = 0,
                Name = "按设备编号查询"
            });
            data3.Add(new {
                ID = 1,
                Name = "按设备描述查询"
            });
            data3.Add(new {
                ID = 2,
                Name = "按卡号查询"
            });

            SearchTypeCB3.ValueMember = "ID";
            SearchTypeCB3.DisplayMember = "Name";
            SearchTypeCB3.DataSource = data3;

            var data4 = new List<object>(data3);
            SearchTypeCB4.ValueMember = "ID";
            SearchTypeCB4.DisplayMember = "Name";
            SearchTypeCB4.DataSource = data4;
        }

        /// <summary>
        /// Bind Device To TreeView.
        /// </summary>
        private void BindDeviceToTreeView(TreeView TempTreeView) {
            BindDeviceRecursion(TempTreeView.Nodes, 0);
        }

        /// <summary>
        /// Bind Device With Recursion.
        /// </summary>
        private void BindDeviceRecursion(TreeNodeCollection collection, Int32 parentId) {
            var SubNodes = Nodes.FindAll(n => n.LastNodeID == parentId);
            foreach (var node in SubNodes) {
                var treenode = collection.Add(String.Format("delta_device_{0}", node.NodeID), Common.GetTreeNodeName(node));
                treenode.Tag = node;
                treenode.ImageKey = node.NodeType == EnmNodeType.Dev ? "Device" : "Area";
                treenode.SelectedImageKey = node.NodeType == EnmNodeType.Dev ? "Device" : "Area";
                BindDeviceRecursion(treenode.Nodes, node.NodeID);
            }
        }

        /// <summary>
        /// Bind OrgEmployees To TreeView.
        /// </summary>
        private void BindOrgEmployeesToTreeView(TreeView TempTreeView) {
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = TempTreeView.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindOrgEmployeesRecursion(dnode, dept.DepId);
                    var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(String.Format("delta_employee_{0}", se.EmpId), se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "Employee";
                        enode.SelectedImageKey = "Employee";
                    }
                }
            }
        }

        /// <summary>
        /// Bind OrgEmployees Recursion.
        /// </summary>
        private void BindOrgEmployeesRecursion(TreeNode pNode, String pId) {
            var SubDepartments = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
            if (SubDepartments.Count > 0) {
                foreach (var dept in SubDepartments) {
                    var dnode = pNode.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindOrgEmployeesRecursion(dnode, dept.DepId);
                    var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(String.Format("delta_employee_{0}", se.EmpId), se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "Employee";
                        enode.SelectedImageKey = "Employee";
                    }
                }
            }
        }

        /// <summary>
        /// Bind OutEmployees To TreeView.
        /// </summary>
        private void BindOutEmployeesToTreeView(TreeView TempTreeView) {
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = TempTreeView.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindOutEmployeesRecursion(dnode, dept.DepId);
                    var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId.Equals(dept.DepId, StringComparison.CurrentCultureIgnoreCase));
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(String.Format("delta_employee_{0}", se.EmpId), se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "Employee";
                        enode.SelectedImageKey = "Employee";

                        var SubOutEmployees = OutEmployees.FindAll(oes => oes.ParentEmpId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
                        foreach (var soe in SubOutEmployees) {
                            var onode = enode.Nodes.Add(String.Format("delta_out_employee_{0}", soe.EmpId), soe.EmpName);
                            onode.Tag = new IDValuePair<Int32, String>(2, soe.EmpId);
                            onode.ImageKey = "OutEmployee";
                            onode.SelectedImageKey = "OutEmployee";
                        }

                        if (enode.Nodes.Count == 0) { dnode.Nodes.Remove(enode); }
                    }

                    if (dnode.Nodes.Count == 0) { TempTreeView.Nodes.Remove(dnode); }
                }
            }
        }

        /// <summary>
        /// Bind OutEmployees Recursion.
        /// </summary>
        private void BindOutEmployeesRecursion(TreeNode pNode, String pId) {
            var SubDepartments = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
            if (SubDepartments.Count > 0) {
                foreach (var dept in SubDepartments) {
                    var dnode = pNode.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindOutEmployeesRecursion(dnode, dept.DepId);
                    var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(String.Format("delta_employee_{0}", se.EmpId), se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "Employee";
                        enode.SelectedImageKey = "Employee";

                        var SubOutEmployees = OutEmployees.FindAll(oes => oes.ParentEmpId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
                        foreach (var soe in SubOutEmployees) {
                            var onode = enode.Nodes.Add(String.Format("delta_out_employee_{0}", soe.EmpId), soe.EmpName);
                            onode.Tag = new IDValuePair<Int32, String>(2, soe.EmpId);
                            onode.ImageKey = "OutEmployee";
                            onode.SelectedImageKey = "OutEmployee";
                        }

                        if (enode.Nodes.Count == 0) { dnode.Nodes.Remove(enode); }
                    }

                    if (dnode.Nodes.Count == 0) { pNode.Nodes.Remove(dnode); }
                }
            }
        }

        /// <summary>
        /// Bind Auth To GridView.
        /// </summary>
        private void BindAuthToGridView1() {
            OrgDevCardAuth.Clear();
            AuthGridView1.Rows.Clear();
            if (DeviceTreeView1.SelectedNode != null) {
                var tag = (NodeLevelInfo)DeviceTreeView1.SelectedNode.Tag;
                if (tag != null && tag.NodeType == EnmNodeType.Dev) {
                    var auths = CardAuthEntity.GetDevCardAuth(tag.NodeID);
                    OrgDevCardAuth.AddRange(from a in auths
                                            join c in OrgCards on a.CardSn equals c.CardSn
                                            join e in OrgEmployees on c.WorkerId equals e.EmpId
                                            orderby e.EmpId
                                            select new IDValuePair<OrgEmployeeInfo, CardAuthInfo>(e, a));

                    if (OrgDevCardAuth.Count > 0 && !String.IsNullOrWhiteSpace(SearchTB1.Text)) {
                        var searchText = SearchTB1.Text.ToLower().Trim();
                        switch ((Int32)SearchTypeCB1.SelectedValue) {
                            case 0:
                                OrgDevCardAuth = OrgDevCardAuth.FindAll(dc => dc.ID.EmpName.ToLower().Contains(searchText));
                                break;
                            case 1:
                                OrgDevCardAuth = OrgDevCardAuth.FindAll(dc => dc.ID.EmpId.ToLower().Contains(searchText));
                                break;
                            case 2:
                                OrgDevCardAuth = OrgDevCardAuth.FindAll(dc => dc.Value.CardSn.ToLower().Contains(searchText));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            AuthGridView1.RowCount = OrgDevCardAuth.Count;
        }

        /// <summary>
        /// Bind Auth To GridView.
        /// </summary>
        private void BindAuthToGridView2() {
            OutDevCardAuth.Clear();
            AuthGridView2.Rows.Clear();
            if (DeviceTreeView2.SelectedNode != null) {
                var tag = (NodeLevelInfo)DeviceTreeView2.SelectedNode.Tag;
                if (tag != null && tag.NodeType == EnmNodeType.Dev) {
                    var auths = CardAuthEntity.GetDevCardAuth(tag.NodeID);
                    OutDevCardAuth.AddRange(from a in auths
                                            join c in OutCards on a.CardSn equals c.CardSn
                                            join e in OutEmployees on c.WorkerId equals e.EmpId
                                            orderby e.EmpId
                                            select new IDValuePair<OutEmployeeInfo, CardAuthInfo>(e, a));

                    if (OutDevCardAuth.Count > 0 && !String.IsNullOrWhiteSpace(SearchTB2.Text)) {
                        var searchText = SearchTB2.Text.ToLower().Trim();
                        switch ((Int32)SearchTypeCB2.SelectedValue) {
                            case 0:
                                OutDevCardAuth = OutDevCardAuth.FindAll(dc => dc.ID.EmpName.ToLower().Contains(searchText));
                                break;
                            case 1:
                                OutDevCardAuth = OutDevCardAuth.FindAll(dc => dc.ID.EmpId.ToLower().Contains(searchText));
                                break;
                            case 2:
                                OutDevCardAuth = OutDevCardAuth.FindAll(dc => dc.Value.CardSn.ToLower().Contains(searchText));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            AuthGridView2.RowCount = OutDevCardAuth.Count;
        }

        /// <summary>
        /// Bind Auth To GridView.
        /// </summary>
        private void BindAuthToGridView3() {
            OrgEmpCardAuth.Clear();
            AuthGridView3.Rows.Clear();
            if (EmpTreeView3.SelectedNode != null) {
                var tag = (IDValuePair<Int32, String>)EmpTreeView3.SelectedNode.Tag;
                if (tag != null && tag.ID == 1) {
                    var Employee = OrgEmployees.Find(oe => oe.EmpId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase));
                    if (Employee != null) {
                        var auths = CardAuthEntity.GetCardAuth(Employee.EmpId, Employee.EmpType);
                        foreach (var a in auths) {
                            if (Devices.ContainsKey(a.DevId)) {
                                OrgEmpCardAuth.Add(new IDValuePair<DeviceInfo, CardAuthInfo>(Devices[a.DevId], a));
                            }
                        }

                        if (OrgEmpCardAuth.Count > 0 && !String.IsNullOrWhiteSpace(SearchTB3.Text)) {
                            var searchText = SearchTB3.Text.ToLower().Trim();
                            switch ((Int32)SearchTypeCB3.SelectedValue) {
                                case 0:
                                    OrgEmpCardAuth = OrgEmpCardAuth.FindAll(ec => ec.Value.DevId.ToString().ToLower().Contains(searchText));
                                    break;
                                case 1:
                                    OrgEmpCardAuth = OrgEmpCardAuth.FindAll(ec => GetDeviceRemark(ec.ID).ToLower().Contains(searchText));
                                    break;
                                case 2:
                                    OrgEmpCardAuth = OrgEmpCardAuth.FindAll(ec => ec.Value.CardSn.ToLower().Contains(searchText));
                                    break;
                                default:
                                    break;
                            }
                        }

                        OrgEmpCardAuth = OrgEmpCardAuth
                                        .OrderBy(ec => ec.ID.Area2Name)
                                        .ThenBy(ec => ec.ID.Area3Name)
                                        .ThenBy(ec => ec.ID.StaName)
                                        .ToList();
                    }
                }
            }

            AuthGridView3.RowCount = OrgEmpCardAuth.Count;
        }

        /// <summary>
        /// Bind Auth To GridView.
        /// </summary>
        private void BindAuthToGridView4() {
            OutEmpCardAuth.Clear();
            AuthGridView4.Rows.Clear();
            if (EmpTreeView4.SelectedNode != null) {
                var tag = (IDValuePair<Int32, String>)EmpTreeView4.SelectedNode.Tag;
                if (tag != null && tag.ID == 2) {
                    var auths = CardAuthEntity.GetCardAuth(tag.Value, EnmWorkerType.WXRY);
                    foreach (var a in auths) {
                        if (Devices.ContainsKey(a.DevId)) {
                            OutEmpCardAuth.Add(new IDValuePair<DeviceInfo, CardAuthInfo>(Devices[a.DevId], a));
                        }
                    }

                    if (OutEmpCardAuth.Count > 0 && !String.IsNullOrWhiteSpace(SearchTB4.Text)) {
                        var searchText = SearchTB4.Text.ToLower().Trim();
                        switch ((Int32)SearchTypeCB4.SelectedValue) {
                            case 0:
                                OutEmpCardAuth = OutEmpCardAuth.FindAll(ec => ec.Value.DevId.ToString().ToLower().Contains(searchText));
                                break;
                            case 1:
                                OutEmpCardAuth = OutEmpCardAuth.FindAll(ec => GetDeviceRemark(ec.ID).ToLower().Contains(searchText));
                                break;
                            case 2:
                                OutEmpCardAuth = OutEmpCardAuth.FindAll(ec => ec.Value.CardSn.ToLower().Contains(searchText));
                                break;
                            default:
                                break;
                        }
                    }

                    OutEmpCardAuth = OutEmpCardAuth
                                    .OrderBy(ec => ec.ID.Area2Name)
                                    .ThenBy(ec => ec.ID.Area3Name)
                                    .ThenBy(ec => ec.ID.StaName)
                                    .ToList();
                }
            }

            AuthGridView4.RowCount = OutEmpCardAuth.Count;
        }

        /// <summary>
        /// Get Device Remark.
        /// </summary>
        /// <param name="dev">device</param>
        private String GetDeviceRemark(DeviceInfo dev) {
            return dev == null ? String.Empty : String.Format("{0}>{1}>{2}>{3}", dev.Area2Name, dev.Area3Name, dev.StaName, dev.DevName);
        }

        /// <summary>
        /// Get Device Remark.
        /// </summary>
        private String GetDeviceRemark(Int32 devId) {
            if (Devices.ContainsKey(devId)) {
                var dev = Devices[devId];
                return String.Format("{0}>{1}>{2}>{3}", dev.Area2Name, dev.Area3Name, dev.StaName, dev.DevName);
            } else {
                return String.Empty;
            }
        }
    }
}