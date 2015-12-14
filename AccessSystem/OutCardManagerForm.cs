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

namespace Delta.MPS.AccessSystem
{
    public partial class OutCardManagerForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Card CardEntity;
        private List<DepartmentInfo> Departments;
        private List<OrgEmployeeInfo> OrgEmployees;
        private List<OutEmployeeInfo> OutEmployees;
        private List<CardInfo> Cards;
        private List<CardInfo> GridCards;
        private String SelectedCardSn;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public OutCardManagerForm() {
            InitializeComponent();
            CardEntity = new Card();
            Departments = new List<DepartmentInfo>();
            OrgEmployees = new List<OrgEmployeeInfo>();
            OutEmployees = new List<OutEmployeeInfo>();
            Cards = new List<CardInfo>();
            GridCards = new List<CardInfo>();
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutCardManagerForm_Shown(object sender, EventArgs e) {
            try {
                var TempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    Departments = Common.CurUser.Role.Departments;
                    OrgEmployees = new Employee().GetOrgEmployees(Common.CurUser.Role.RoleID);
                    OutEmployees = new Employee().GetOutEmployees(Common.CurUser.Role.RoleID);
                    Cards = CardEntity.GetOutCards(Common.CurUser.Role.RoleID);
                    BindEmployeesToTreeView(TempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    EmpTreeView.Nodes.Clear();
                    foreach (TreeNode tn in TempTreeView.Nodes) {
                        EmpTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (EmpTreeView.Nodes.Count > 0) {
                        var root = EmpTreeView.Nodes[0];
                        EmpTreeView.SelectedNode = root;
                        root.Expand();
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OutEmployees TreeView AfterSelect Event.
        /// </summary>
        private void EmpTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                BindCardsToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.EmpTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sub Cards Checked Changed Event.
        /// </summary>
        private void SubCardCB_CheckedChanged(object sender, EventArgs e) {
            try {
                BindCardsToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.SubCardCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cards GridView CellValue Needed Event.
        /// </summary>
        private void CardsGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > GridCards.Count - 1) { return; }
                switch (CardsGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EIDColumn":
                        e.Value = String.Format("{0} - {1}", GridCards[e.RowIndex].WorkerId, GridCards[e.RowIndex].WorkerName);
                        break;
                    case "CardSnColumn":
                        e.Value = GridCards[e.RowIndex].CardSn;
                        if (!String.IsNullOrWhiteSpace(SelectedCardSn) && SelectedCardSn.Equals(e.Value)) {
                            CardsGridView.ClearSelection();
                            CardsGridView.Rows[e.RowIndex].Selected = true;
                            SelectedCardSn = null;
                        }
                        break;
                    case "DepNameColumn":
                        e.Value = String.Format("{0} - {1}", GridCards[e.RowIndex].DepId, GridCards[e.RowIndex].DepName);
                        break;
                    case "CardTypeColumn":
                        e.Value = ComUtility.GetCardTypeText(GridCards[e.RowIndex].CardType);
                        break;
                    case "BeginTimeColumn":
                        e.Value = Common.GetDateTimeString(GridCards[e.RowIndex].BeginTime);
                        break;
                    case "BeginReasonColumn":
                        e.Value = GridCards[e.RowIndex].BeginReason;
                        break;
                    case "CommentColumn":
                        e.Value = GridCards[e.RowIndex].Comment;
                        break;
                    case "EnabledColumn":
                        e.Value = GridCards[e.RowIndex].Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.CardsGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cards GridView CellContent Click Event.
        /// </summary>
        private void CardsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key = (String)CardsGridView.Rows[e.RowIndex].Cells["CardSnColumn"].Value;
                var obj = GridCards.Find(d => d.CardSn.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (CardsGridView.Columns[e.ColumnIndex].Name) {
                    case "DeleteColumn":
                        if (MessageBox.Show(String.Format("卡片[{0} - {1},{2}]将被删除，您确定要删除吗?", obj.CardSn, obj.WorkerId, obj.WorkerName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardEntity.DeleteCards(new List<CardInfo>() { obj });
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                Cards.Remove(obj);
                                GridCards.Remove(obj);
                                CardsGridView.Rows.RemoveAt(e.RowIndex);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Cardout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OutCardManagerForm.CardsGridView.CellContentClick", String.Format("删除卡片:[{0} - {1},{2}]", obj.CardSn, obj.WorkerId, obj.WorkerName), null);
                            }
                        }
                        break;
                    case "EditColumn":
                        if (new SaveCardForm(EnmSaveBehavior.Edit, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            CardsGridView.InvalidateRow(e.RowIndex);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.CardsGridView.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add Card Button Click Event.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                OutEmployeeInfo Employee = null;
                if (EmpTreeView.SelectedNode != null) {
                    var tag = (IDValuePair<Int32, String>)EmpTreeView.SelectedNode.Tag;
                    if (tag != null && tag.ID == 2) {
                        Employee = OutEmployees.Find(oe => oe.EmpId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase));
                    }
                }

                var obj = new CardInfo() {
                    WorkerId = Employee != null ? Employee.EmpId : String.Empty,
                    WorkerType = EnmWorkerType.WXRY,
                    WorkerName = Employee != null ? Employee.EmpName : String.Empty,
                    DepId = Employee != null ? Employee.DepId : String.Empty,
                    DepName = Employee != null ? Employee.DepName : String.Empty,
                    CardSn = String.Empty,
                    CardType = EnmCardType.LSK,
                    UID = String.Empty,
                    Pwd = String.Empty,
                    BeginTime = DateTime.Now,
                    BeginReason = "员工入职",
                    Comment = String.Empty,
                    Enabled = true
                };

                if (new SaveCardForm(EnmSaveBehavior.Add, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    Cards.Add(obj);
                    BindCardsToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Cards.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                if (CardsGridView.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            CardEntity.DeleteCards(GridCards);
                        }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var gc in GridCards) {
                                Cards.Remove(gc);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Cardout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OutCardManagerForm.DeleteBtn.Click", String.Format("删除卡片:[{0} - {1},{2}]", gc.CardSn, gc.WorkerId, gc.WorkerName), null);
                            }
                            GridCards.Clear();
                            CardsGridView.Rows.Clear();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export All Cards To Excel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportBtn_Click(object sender, EventArgs e) {
            try {
                if (GridCards.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("持卡人", typeof(String));
                    data.Columns.Add("卡号", typeof(String));
                    data.Columns.Add("所属部门", typeof(String));
                    data.Columns.Add("卡片类型", typeof(String));
                    data.Columns.Add("发卡时间", typeof(String));
                    data.Columns.Add("发卡原因", typeof(String));
                    data.Columns.Add("备注", typeof(String));
                    data.Columns.Add("状态", typeof(String));
                    for (var i = 0; i < GridCards.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["持卡人"] = String.Format("{0} - {1}", GridCards[i].WorkerId, GridCards[i].WorkerName);
                        dr["卡号"] = GridCards[i].CardSn;
                        dr["所属部门"] = String.Format("{0} - {1}", GridCards[i].DepId, GridCards[i].DepName);
                        dr["卡片类型"] = ComUtility.GetCardTypeText(GridCards[i].CardType);
                        dr["发卡时间"] = Common.GetDateTimeString(GridCards[i].BeginTime);
                        dr["发卡原因"] = GridCards[i].BeginReason;
                        dr["备注"] = GridCards[i].Comment;
                        dr["状态"] = GridCards[i].Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "外协卡片信息", "智能门禁管理系统 外协卡片信息报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.ExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Batch Add Cards.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BatchAddBtn_Click(object sender, EventArgs e) {
            try {
                if (new BatchOutCardsForm().ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    Cards = CardEntity.GetOutCards(Common.CurUser.Role.RoleID);
                    BindCardsToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.BatchAddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Find Card Button Click Event.
        /// </summary>
        private void FindCardBtn_Click(object sender, EventArgs e) {
            try {
                var Dialog = new FindCardDialog();
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    var FindCard = Cards.Find(c => c.CardSn.Equals(Dialog.CardSn));
                    if (FindCard != null) {
                        SelectedCardSn = FindCard.CardSn;
                        var TreeNode = EmpTreeView.Nodes.Find(String.Format("delta_out_employee_{0}", FindCard.WorkerId), true);
                        if (TreeNode != null && TreeNode.Length > 0) {
                            EmpTreeView.SelectedNode = TreeNode[0];
                        } else {
                            if (EmpTreeView.Nodes.Count > 0) {
                                EmpTreeView.SelectedNode = EmpTreeView.Nodes[0];
                            }
                        }
                    } else {
                        MessageBox.Show("未查询到卡片信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.FindCardBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Opening Event.
        /// </summary>
        private void OperationContext_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = CardsGridView.SelectedRows.Count > 0;
                OpMenuItem2.Enabled = CardsGridView.Rows.Count > 0;
                OpMenuItem3.Enabled = GridCards.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.OperationContext.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Selected Cards.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (CardsGridView.SelectedRows.Count > 0) {
                    var adEmps = new Dictionary<Int32, CardInfo>();
                    foreach (DataGridViewRow row in CardsGridView.SelectedRows) {
                        var key = (String)row.Cells["CardSnColumn"].Value;
                        var obj = GridCards.Find(gc => gc.CardSn.Equals(key));
                        if (obj != null) { adEmps[row.Index] = obj; }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中卡片将被删除，您确定要删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                CardEntity.DeleteCards(adEmps.Select(ad => ad.Value).ToList());
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var ae in adEmps) {
                                    Cards.Remove(ae.Value);
                                    GridCards.Remove(ae.Value);
                                    CardsGridView.Rows.RemoveAt(ae.Key);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Cardout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OutCardManagerForm.OpMenuItem1.Click", String.Format("删除卡片:[{0} - {1},{2}]", ae.Value.CardSn, ae.Value.WorkerId, ae.Value.WorkerName), null);
                                }
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.OpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Employees.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            DeleteBtn_Click(sender, e);
        }

        /// <summary>
        /// Save All Employees To Excel.
        /// </summary>
        private void OpMenuItem3_Click(object sender, EventArgs e) {
            ExportBtn_Click(sender, e);
        }

        /// <summary>
        /// TreeView Menu Item1 Click Event.
        /// </summary>
        private FinderDialog Finder = null;
        private void TVToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(EmpTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutCardManagerForm.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind OrgEmployees To TreeView.
        /// </summary>
        private void BindEmployeesToTreeView(TreeView TempTreeView) {
            var root = TempTreeView.Nodes.Add("delta_cards_0", "所有卡片");
            root.Tag = new IDValuePair<Int32, String>(-1, "0");
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = root.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindEmployeesRecursion(dnode, dept.DepId);
                    var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId.Equals(dept.DepId,StringComparison.CurrentCultureIgnoreCase));
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

                    if (dnode.Nodes.Count == 0) { root.Nodes.Remove(dnode); }
                }
            }
        }

        /// <summary>
        /// Bind Employees Recursion.
        /// </summary>
        private void BindEmployeesRecursion(TreeNode pNode, String pId) {
            if (Departments != null && Departments.Count > 0) {
                var SubDepartments = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (SubDepartments.Count > 0) {
                    foreach (var dept in SubDepartments) {
                        var dnode = pNode.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                        dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                        dnode.ImageKey = "Department";
                        dnode.SelectedImageKey = "Department";

                        BindEmployeesRecursion(dnode, dept.DepId);
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
        }

        /// <summary>
        /// Find SubDepartments Recursion.
        /// </summary>
        private void FindSubDeptRecursion(String pId, List<DepartmentInfo> sDept) {
            var sds = Departments.FindAll(d => d.LastDepId == pId);
            if (sds.Count > 0) {
                foreach (var d in sds) {
                    sDept.Add(d);
                    FindSubDeptRecursion(d.DepId, sDept);
                }
            }
        }

        /// <summary>
        /// Bind Cards To GridView.
        /// </summary>
        private void BindCardsToGridView() {
            GridCards.Clear();
            CardsGridView.Rows.Clear();
            if (EmpTreeView.SelectedNode != null) {
                var tag = (IDValuePair<Int32, String>)EmpTreeView.SelectedNode.Tag;
                if (tag != null) {
                    if (tag.ID == -1) {
                        GridCards.AddRange(Cards);
                    } else if (tag.ID == 0) {
                        GridCards.AddRange(Cards.FindAll(c => c.DepId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase)));
                        if (SubCardCB.Checked) {
                            var SubDept = new List<DepartmentInfo>();
                            FindSubDeptRecursion(tag.Value, SubDept);
                            foreach (var sd in SubDept) {
                                GridCards.AddRange(Cards.FindAll(c => c.DepId.Equals(sd.DepId, StringComparison.CurrentCultureIgnoreCase)));
                            }
                        }
                    } else if (tag.ID == 1) {
                        var SubOutEmployees = OutEmployees.FindAll(oe => oe.ParentEmpId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase));
                        foreach (var soe in SubOutEmployees) {
                            GridCards.AddRange(Cards.FindAll(c => c.WorkerId.Equals(soe.EmpId, StringComparison.CurrentCultureIgnoreCase)));
                        }
                    } else if (tag.ID == 2) {
                        GridCards.AddRange(Cards.FindAll(c => c.WorkerId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase)));
                    }
                }
            }

            CardsGridView.RowCount = GridCards.Count;
        }
    }
}
