using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delta.MPS.Model;

namespace Delta.MPS.AccessSystem
{
    public partial class DepartmentDialog : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private List<DepartmentInfo> Departments;

        /// <summary>
        /// SelectedItems
        /// </summary>
        public List<DepartmentInfo> SelectedItems { get; private set; }

        /// <summary>
        /// MultiSelect
        /// </summary>
        public Boolean MultiSelect { get; set; }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public DepartmentDialog(Boolean IsMultiSelect) {
            InitializeComponent();
            Departments = new List<DepartmentInfo>();
            SelectedItems = new List<DepartmentInfo>();
            DeptTreeView.CheckBoxes = MultiSelect = IsMultiSelect;
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void DepartmentDialog_Load(object sender, EventArgs e) {
            try {
                Departments = Common.CurUser.Role.Departments;
                BindDepartmentsToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentDialog.Load", err.Message, err.StackTrace);
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
                    foreach (TreeNode tn in DeptTreeView.Nodes) {
                        if (tn.Checked) {
                            var dept = (DepartmentInfo)tn.Tag;
                            if (dept != null) { SelectedItems.Add(dept); }
                        }

                        CheckDepartmentsTreeView(tn);
                    }
                } else {
                    if (DeptTreeView.SelectedNode != null) {
                        var dept = (DepartmentInfo)DeptTreeView.SelectedNode.Tag;
                        if (dept != null) { SelectedItems.Add(dept); }
                    }
                }

                if (SelectedItems.Count == 0) {
                    MessageBox.Show("未选择任何数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentDialog.OKBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Operation Context Menu Opening Event.
        /// </summary>
        private void TreeViewContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            TVToolStripMenuItem2.Enabled = TVToolStripMenuItem3.Enabled = MultiSelect && DeptTreeView.Nodes.Count > 0;
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentDialog.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item2 Click Event.
        /// </summary>
        private void TVToolStripMenuItem2_Click(object sender, EventArgs e) {
            try {
                foreach (TreeNode node in DeptTreeView.Nodes) {
                    SetNodeChecked(node);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentDialog.TVToolStripMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item3 Click Event.
        /// </summary>
        private void TVToolStripMenuItem3_Click(object sender, EventArgs e) {
            try {
                foreach (TreeNode node in DeptTreeView.Nodes) {
                    SetNodeUnChecked(node);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentDialog.TVToolStripMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Node Checked.
        /// </summary>
        /// <param name="tn">Tree Node</param>
        private void SetNodeChecked(TreeNode tn) {
            tn.Checked = true;
            foreach (TreeNode node in tn.Nodes) {
                SetNodeChecked(node);
            }
        }

        /// <summary>
        /// Set Node UnChecked.
        /// </summary>
        /// <param name="tn">Tree Node</param>
        private void SetNodeUnChecked(TreeNode tn) {
            tn.Checked = !tn.Checked;
            foreach (TreeNode node in tn.Nodes) {
                SetNodeUnChecked(node);
            }
        }

        /// <summary>
        /// Bind Departments To TreeView.
        /// </summary>
        private void BindDepartmentsToTreeView() {
            DeptTreeView.Nodes.Clear();
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var node = DeptTreeView.Nodes.Add(dept.DepId, dept.DepName);
                    node.Tag = dept;

                    BindDepartmentsRecursion(node, dept.DepId);
                    node.Expand();
                }
            }
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
                        tnode.Tag = d;
                        BindDepartmentsRecursion(tnode, d.DepId);
                    }
                }
            }
        }

        /// <summary>
        /// Get Checked Departments TreeNodes.
        /// </summary>
        private void CheckDepartmentsTreeView(TreeNode pNode) {
            foreach (TreeNode tn in pNode.Nodes) {
                if (tn.Checked) {
                    var dept = (DepartmentInfo)tn.Tag;
                    if (dept != null) { SelectedItems.Add(dept); }
                }

                CheckDepartmentsTreeView(tn);
            }
        }

        
    }
}
