using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Delta.MPS.Model;
using Delta.MPS.SQLServerDAL;

namespace Delta.MPS.AccessSystem
{
    public partial class DepartmentManagerForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Department DeptEntity;
        private List<DepartmentInfo> Departments;
        private List<DepartmentInfo> GridDepartments;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public DepartmentManagerForm() {
            InitializeComponent();
            DeptEntity = new Department();
            Departments = new List<DepartmentInfo>();
            GridDepartments = new List<DepartmentInfo>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void DepartmentManagerForm_Load(object sender, EventArgs e) {
            try {
                Departments = Common.CurUser.Role.Departments = new MemberShip().GetRoleDepartments(Common.CurUser.Role.RoleID);
                BindDepartmentsToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Department TreeView AfterSelect Event.
        /// </summary>
        private void DeptTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                BindDepartmentsToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.DeptTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Show All Children Departments.
        /// </summary>
        private void SubDeptCB_CheckedChanged(object sender, EventArgs e) {
            try {
                BindDepartmentsToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.SubDeptCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Department GridView CellValue Needed Event.
        /// </summary>
        private void DeptGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > GridDepartments.Count - 1) { return; }
                switch (DeptGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "DIDColumn":
                        e.Value = GridDepartments[e.RowIndex].DepId;
                        break;
                    case "NameColumn":
                        e.Value = GridDepartments[e.RowIndex].DepName;
                        break;
                    case "CommentColumn":
                        e.Value = GridDepartments[e.RowIndex].Comment;
                        break;
                    case "EnabledColumn":
                        e.Value = GridDepartments[e.RowIndex].Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.DeptGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Department GridView CellContent Click Event.
        /// </summary>
        private void DeptGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key = (String)DeptGridView.Rows[e.RowIndex].Cells["DIDColumn"].Value;
                var obj = GridDepartments.Find(d => d.DepId.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (DeptGridView.Columns[e.ColumnIndex].Name) {
                    case "DeleteColumn":
                        if (DeptEntity.ExistEmployeesInDepartment(obj.DepId)) {
                            MessageBox.Show(String.Format("部门[{0},{1}]下存在员工，无法执行删除操作。", obj.DepId, obj.DepName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var SubDept = new List<DepartmentInfo>();
                        FindSubDeptRecursion(obj.DepId, SubDept);
                        foreach (var sd in SubDept) {
                            if (DeptEntity.ExistEmployeesInDepartment(sd.DepId)) {
                                MessageBox.Show(String.Format("其子部门[{0},{1}]下存在员工，无法执行删除操作。", sd.DepId, sd.DepName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        if (MessageBox.Show(String.Format("部门[{0},{1}]{2}将被删除，您确定要删除吗?", obj.DepId, obj.DepName, SubDept.Count > 0 ? "及其子部门" : String.Empty), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                SubDept.Add(obj);
                                DeptEntity.DeleteDepartments(SubDept.Select(sd => sd.DepId).ToList());
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var sr in SubDept) {
                                    Departments.Remove(sr);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.DepartmentManagerForm.DeptGridView.CellContentClick", String.Format("删除部门:[{0},{1}]", sr.DepId, sr.DepName), null);
                                }

                                BindDepartmentsToTreeView();
                            }
                        }
                        break;
                    case "EditColumn":
                        if (new SaveDepartmentForm(EnmSaveBehavior.Edit, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            BindDepartmentsToTreeView();
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.DeptGridView.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add Department.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                var maxId = DeptEntity.GetMaxDepartmentID() + 1;
                var obj = new DepartmentInfo() {
                    ID = maxId,
                    DepId = String.Format("{0:D8}", maxId),
                    DepName = String.Empty,
                    Comment = String.Empty,
                    LastDepId = DeptTreeView.SelectedNode != null ? (String)DeptTreeView.SelectedNode.Tag : String.Empty,
                    Enabled = true
                };

                if (new SaveDepartmentForm(EnmSaveBehavior.Add, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    BindDepartmentsToTreeView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Departments.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                if (DeptGridView.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var adDept = new Dictionary<String, DepartmentInfo>();
                        foreach (var dd in GridDepartments) {
                            if (DeptEntity.ExistEmployeesInDepartment(dd.DepId)) {
                                MessageBox.Show(String.Format("部门[{0},{1}]下存在员工，无法执行删除操作。", dd.DepId, dd.DepName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            adDept[dd.DepId] = dd;

                            var SubDept = new List<DepartmentInfo>();
                            FindSubDeptRecursion(dd.DepId, SubDept);
                            foreach (var sd in SubDept) {
                                if (DeptEntity.ExistEmployeesInDepartment(sd.DepId)) {
                                    MessageBox.Show(String.Format("部门[{0},{1}]的子部门[{2},{3}]下存在员工，无法执行删除操作。", dd.DepId, dd.DepName, sd.DepId, sd.DepName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                adDept[sd.DepId] = sd;
                            }
                        }

                        var result = Common.ShowWait(() => {
                            DeptEntity.DeleteDepartments(adDept.Select(sd => sd.Value.DepId).ToList());
                        }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var gr in adDept) {
                                Departments.Remove(gr.Value);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.DepartmentManagerForm.DeleteBtn.Click", String.Format("删除部门:[{0},{1}]", gr.Value.DepId, gr.Value.DepName), null);
                            }

                            BindDepartmentsToTreeView();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export roles to excel.
        /// </summary>
        private void ExportBtn_Click(object sender, EventArgs e) {
            try {
                if (GridDepartments.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("部门编号", typeof(String));
                    data.Columns.Add("部门名称", typeof(String));
                    data.Columns.Add("备注", typeof(String));
                    data.Columns.Add("状态", typeof(String));
                    for (var i = 0; i < GridDepartments.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["部门编号"] = GridDepartments[i].DepId;
                        dr["部门名称"] = GridDepartments[i].DepName;
                        dr["备注"] = GridDepartments[i].Comment;
                        dr["状态"] = GridDepartments[i].Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "部门信息", "智能门禁管理系统 系统部门报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.ExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Opening Event.
        /// </summary>
        private void OperationContext_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = DeptGridView.SelectedRows.Count > 0;
                OpMenuItem2.Enabled = DeptGridView.Rows.Count > 0;
                OpMenuItem3.Enabled = GridDepartments.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.OperationContext.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Selected Departments.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (DeptGridView.SelectedRows.Count > 0) {
                    var dDept = new List<DepartmentInfo>();
                    foreach (DataGridViewRow row in DeptGridView.SelectedRows) {
                        var key = (String)row.Cells["DIDColumn"].Value;
                        var obj = GridDepartments.Find(r => r.DepId.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                        if (obj != null) { dDept.Add(obj); }
                    }

                    if (dDept.Count > 0) {
                        var adDept = new Dictionary<String, DepartmentInfo>();
                        foreach (var dd in dDept) {
                            if (DeptEntity.ExistEmployeesInDepartment(dd.DepId)) {
                                MessageBox.Show(String.Format("部门[{0},{1}]下存在员工，无法执行删除操作。", dd.DepId, dd.DepName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            adDept[dd.DepId] = dd;

                            var SubDept = new List<DepartmentInfo>();
                            FindSubDeptRecursion(dd.DepId, SubDept);
                            foreach (var sd in SubDept) {
                                if (DeptEntity.ExistEmployeesInDepartment(sd.DepId)) {
                                    MessageBox.Show(String.Format("部门[{0},{1}]的子部门[{2},{3}]下存在员工，无法执行删除操作。", dd.DepId, dd.DepName, sd.DepId, sd.DepName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                adDept[sd.DepId] = sd;
                            }
                        }

                        if (MessageBox.Show("选中部门及其子部门将被删除，您确定要删除吗?", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                DeptEntity.DeleteDepartments(adDept.Select(sd => sd.Value.DepId).ToList());
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var gr in adDept) {
                                    Departments.Remove(gr.Value);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.DepartmentManagerForm.OpMenuItem1.Click", String.Format("删除部门:[{0},{1}]", gr.Value.DepId, gr.Value.DepName), null);
                                }

                                BindDepartmentsToTreeView();
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.OpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Departments.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            DeleteBtn_Click(sender, e);
        }

        /// <summary>
        /// Save All Departments To Excel.
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
                    Finder = new FinderDialog(DeptTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Departments To TreeView.
        /// </summary>
        private void BindDepartmentsToTreeView() {
            DeptTreeView.Nodes.Clear();
            var root = DeptTreeView.Nodes.Add("0", "所有部门");
            root.Tag = "0";
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var node = root.Nodes.Add(dept.DepId, dept.DepName);
                    node.Tag = dept.DepId;

                    BindDepartmentsRecursion(node, dept.DepId);
                }
            }

            DeptTreeView.SelectedNode = root;
            DeptTreeView.ExpandAll();
        }

        /// <summary>
        /// Bind Departments Recursion.
        /// </summary>
        private void BindDepartmentsRecursion(TreeNode pNode, String pId) {
            if (Departments != null && Departments.Count > 0) {
                var sds = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (sds.Count > 0) {
                    foreach (var d in sds) {
                        var tnode = pNode.Nodes.Add(d.DepId, d.DepName);
                        tnode.Tag = d.DepId;
                        BindDepartmentsRecursion(tnode, d.DepId);
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
        /// Bind Departments To GridView.
        /// </summary>
        private void BindDepartmentsToGridView() {
            GridDepartments.Clear();
            DeptGridView.Rows.Clear();
            if (DeptTreeView.SelectedNode != null) {
                var dId = (String)DeptTreeView.SelectedNode.Tag;
                var nodes = Departments.FindAll(d => d.LastDepId.Equals(dId, StringComparison.CurrentCultureIgnoreCase));
                GridDepartments.AddRange(nodes);
                if (SubDeptCB.Checked) {
                    foreach (var n in nodes) {
                        var SubDept = new List<DepartmentInfo>();
                        FindSubDeptRecursion(n.DepId, SubDept);
                        foreach (var sd in SubDept) {
                            GridDepartments.Add(sd);
                        }
                    }
                }
            }
            DeptGridView.RowCount = GridDepartments.Count;
        }
    }
}