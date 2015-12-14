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

namespace Delta.MPS.AccessSystem
{
    public partial class OutEmployeeDialog : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Employee EmpEntity;
        private List<DepartmentInfo> Departments;
        private List<OrgEmployeeInfo> OrgEmployees;
        private List<OutEmployeeInfo> OutEmployees;

        /// <summary>
        /// SelectedItems
        /// </summary>
        public List<OutEmployeeInfo> SelectedItems { get; private set; }

        /// <summary>
        /// MultiSelect
        /// </summary>
        public Boolean MultiSelect { get; private set; }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public OutEmployeeDialog(Boolean IsMultiSelect) {
            InitializeComponent();
            EmpEntity = new Employee();
            Departments = new List<DepartmentInfo>();
            OrgEmployees = new List<OrgEmployeeInfo>();
            OutEmployees = new List<OutEmployeeInfo>();
            SelectedItems = new List<OutEmployeeInfo>();
            OutEmpTreeView.CheckBoxes = MultiSelect = IsMultiSelect;
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void OutEmployeeDialog_Load(object sender, EventArgs e) {
            try {
                if (MultiSelect) { OutEmpTreeView.ContextMenuStrip = OperationContextMenu; }
                Departments = Common.CurUser.Role.Departments;
                OrgEmployees = EmpEntity.GetOrgEmployees(Common.CurUser.Role.RoleID);
                OutEmployees = EmpEntity.GetOutEmployees(Common.CurUser.Role.RoleID);

                BindEmployeesToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employee TreeView AfterSelect Event.
        /// </summary>
        private void EmpTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                BindOutEmployeesToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.EmpTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sub Empoyee Checked Changed Event.
        /// </summary>
        private void SubEmpCB_CheckedChanged(object sender, EventArgs e) {
            try {
                BindOutEmployeesToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.SubEmpCB.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ok Button Click Event.
        /// </summary>
        private void OKBtn_Click(object sender, EventArgs e) {
            try {
                SelectedItems.Clear();
                if (MultiSelect) {
                    foreach (TreeNode node in OutEmpTreeView.Nodes) {
                        if (node.Checked) {
                            SelectedItems.Add((OutEmployeeInfo)node.Tag);
                        }
                    }
                } else {
                    if (OutEmpTreeView.SelectedNode != null) {
                        SelectedItems.Add((OutEmployeeInfo)OutEmpTreeView.SelectedNode.Tag);
                    }
                }

                if (SelectedItems.Count == 0) {
                    MessageBox.Show("未选择任何数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.OKBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Operation Context Menu Opening Event.
        /// </summary>
        private void OperationContextMenu_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = OpMenuItem2.Enabled = OutEmpTreeView.Nodes.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.OperationContextMenu.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Check All Items.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                foreach (TreeNode node in OutEmpTreeView.Nodes) {
                    node.Checked = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.OpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// UnCheck All Items.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            try {
                foreach (TreeNode node in OutEmpTreeView.Nodes) {
                    node.Checked = !node.Checked;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.OpMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Find TreeView Nodes.
        /// </summary>
        private void OpMenuItem3_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(OutEmpTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeDialog.OpMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind OrgEmployees To TreeView.
        /// </summary>
        private void BindEmployeesToTreeView() {
            EmpTreeView.Nodes.Clear();
            var root = EmpTreeView.Nodes.Add("所有外协人员");
            root.Tag = new IDValuePair<Int32, String>(-1, "0");
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = root.Nodes.Add(dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindEmployeesRecursion(dnode, dept.DepId);
                    var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "Employee";
                        enode.SelectedImageKey = "Employee";
                    }
                }
            }

            EmpTreeView.SelectedNode = root;
            root.Expand();
        }

        /// <summary>
        /// Bind Employees Recursion.
        /// </summary>
        private void BindEmployeesRecursion(TreeNode pNode, String pId) {
            if (Departments != null && Departments.Count > 0) {
                var SubDepartments = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (SubDepartments.Count > 0) {
                    foreach (var dept in SubDepartments) {
                        var dnode = pNode.Nodes.Add(dept.DepName);
                        dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                        dnode.ImageKey = "Department";
                        dnode.SelectedImageKey = "Department";

                        BindEmployeesRecursion(dnode, dept.DepId);
                        var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                        foreach (var se in SubEmployees) {
                            var enode = dnode.Nodes.Add(se.EmpName);
                            enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                            enode.ImageKey = "Employee";
                            enode.SelectedImageKey = "Employee";
                        }
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
        /// Bind Out Employees To TreeView.
        /// </summary>
        private void BindOutEmployeesToTreeView() {
            OutEmpTreeView.Nodes.Clear();
            if (EmpTreeView.SelectedNode != null) {
                var tag = (IDValuePair<Int32, String>)EmpTreeView.SelectedNode.Tag;
                if (tag != null) {
                    if (tag.ID == -1) {
                        foreach (var emp in OutEmployees) {
                            var node = OutEmpTreeView.Nodes.Add(emp.EmpId, String.Format("{0} - {1}", emp.EmpId, emp.EmpName));
                            node.Tag = emp;
                        }
                    } else if (tag.ID == 0) {
                        var ListEmployees = OutEmployees.FindAll(oe => oe.DepId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase));
                        if (SubEmpCB.Checked) {
                            var SubDept = new List<DepartmentInfo>();
                            FindSubDeptRecursion(tag.Value, SubDept);
                            foreach (var sd in SubDept) {
                                ListEmployees.AddRange(OutEmployees.FindAll(e => e.DepId.Equals(sd.DepId, StringComparison.CurrentCultureIgnoreCase)));
                            }
                        }

                        foreach (var emp in ListEmployees) {
                            var node = OutEmpTreeView.Nodes.Add(emp.EmpId, String.Format("{0} - {1}", emp.EmpId, emp.EmpName));
                            node.Tag = emp;
                        }
                    } else if (tag.ID == 1) {
                        var ListEmployees = OutEmployees.FindAll(oe => oe.ParentEmpId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase));
                        foreach (var emp in ListEmployees) {
                            var node = OutEmpTreeView.Nodes.Add(emp.EmpId, String.Format("{0} - {1}", emp.EmpId, emp.EmpName));
                            node.Tag = emp;
                        }
                    }
                }
            }
        }
    }
}
