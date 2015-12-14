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
    public partial class OrgEmployeeDialog : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Employee EmpEntity;
        private List<OrgEmployeeInfo> Employees;
        private List<DepartmentInfo> Departments;

        /// <summary>
        /// SelectedItems
        /// </summary>
        public List<OrgEmployeeInfo> SelectedItems { get; private set; }

        /// <summary>
        /// MultiSelect
        /// </summary>
        public Boolean MultiSelect { get; private set; }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public OrgEmployeeDialog(Boolean IsMultiSelect) {
            InitializeComponent();
            EmpEntity = new Employee();
            Departments = new List<DepartmentInfo>();
            Employees = new List<OrgEmployeeInfo>();
            SelectedItems = new List<OrgEmployeeInfo>();
            EmpTreeView.CheckBoxes = MultiSelect = IsMultiSelect;
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void OrgEmployeeDialog_Load(object sender, EventArgs e) {
            try {
                if (MultiSelect) { EmpTreeView.ContextMenuStrip = OperationContextMenu; }
                Departments = Common.CurUser.Role.Departments;
                Employees = EmpEntity.GetOrgEmployees(Common.CurUser.Role.RoleID);
                BindDepartmentsToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Department TreeView AfterSelect Event.
        /// </summary>
        private void DeptTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                BindEmployeesToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.DeptTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// SubEmployee Checked Changed Event.
        /// </summary>
        private void SubEmpCB_CheckedChanged(object sender, EventArgs e) {
            try {
                BindEmployeesToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.SubEmpCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ok Button Click Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKBtn_Click(object sender, EventArgs e) {
            try {
                SelectedItems.Clear();
                if (MultiSelect) {
                    foreach (TreeNode node in EmpTreeView.Nodes) {
                        if (node.Checked) {
                            SelectedItems.Add((OrgEmployeeInfo)node.Tag);
                        }
                    }
                } else {
                    if (EmpTreeView.SelectedNode != null) {
                        SelectedItems.Add((OrgEmployeeInfo)EmpTreeView.SelectedNode.Tag);
                    }
                }

                if (SelectedItems.Count == 0) {
                    MessageBox.Show("未选择任何数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.OKBtn.Click", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(DeptTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Operation Context Menu Opening Event.
        /// </summary>
        private void OperationContextMenu_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = OpMenuItem2.Enabled = MultiSelect && EmpTreeView.Nodes.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.OperationContextMenu.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Check All Items.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                foreach (TreeNode node in EmpTreeView.Nodes) {
                    node.Checked = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.OpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// UnCheck All Items.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            try {
                foreach (TreeNode node in EmpTreeView.Nodes) {
                    node.Checked = !node.Checked;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.OpMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Find Node Items.
        /// </summary>
        private void OpMenuItem3_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(EmpTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeDialog.OpMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Departments To TreeView.
        /// </summary>
        private void BindDepartmentsToTreeView() {
            DeptTreeView.Nodes.Clear();
            var root = DeptTreeView.Nodes.Add("0", "所有员工");
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
            root.Expand();
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
        /// Bind Employees To TreeView.
        /// </summary>
        private void BindEmployeesToTreeView() {
            EmpTreeView.Nodes.Clear();
            if (DeptTreeView.SelectedNode != null) {
                var dId = (String)DeptTreeView.SelectedNode.Tag;
                if (dId.Equals("0")) {
                    foreach (var emp in Employees) {
                        var node = EmpTreeView.Nodes.Add(emp.EmpId, String.Format("{0} - {1}", emp.EmpId, emp.EmpName));
                        node.Tag = emp;
                    }
                } else {
                    var ListEmployees = Employees.FindAll(e => e.DepId.Equals(dId, StringComparison.CurrentCultureIgnoreCase));
                    if (SubEmpCB.Checked) {
                        var SubDept = new List<DepartmentInfo>();
                        FindSubDeptRecursion(dId, SubDept);
                        foreach (var sd in SubDept) {
                            ListEmployees.AddRange(Employees.FindAll(e => e.DepId.Equals(sd.DepId, StringComparison.CurrentCultureIgnoreCase)));
                        }
                    }

                    foreach (var emp in ListEmployees) {
                        var node = EmpTreeView.Nodes.Add(emp.EmpId, String.Format("{0} - {1}", emp.EmpId, emp.EmpName));
                        node.Tag = emp;
                    }
                }
            }
        }
    }
}
