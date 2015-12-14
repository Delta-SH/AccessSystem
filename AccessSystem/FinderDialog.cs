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
    public partial class FinderDialog : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private TreeView FindTreeView;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public FinderDialog(TreeView tv) {
            InitializeComponent();
            FindTreeView = tv;
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void FinderDialog_Load(object sender, EventArgs e) {
            try {
                FindBtn.Enabled = !String.IsNullOrEmpty(FContentTB.Text);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.FinderDialog.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Find Content TextBox TextChanged Event.
        /// </summary>
        private void FContentTB_TextChanged(object sender, EventArgs e) {
            try {
                FilterNodes = null;
                FindBtn.Enabled = !String.IsNullOrEmpty(FContentTB.Text);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.FContentTB.TextChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DXX CheckBox CheckedChanged Event.
        /// </summary>
        private void DXXCB_CheckedChanged(object sender, EventArgs e) {
            try {
                FilterNodes = null;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DXXCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// QZ CheckBox CheckedChanged Event.
        /// </summary>
        private void QZCB_CheckedChanged(object sender, EventArgs e) {
            try {
                FilterNodes = null;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.QZCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// XS CheckBox CheckedChanged Event.
        /// </summary>
        private void XSCB_CheckedChanged(object sender, EventArgs e) {
            try {
                if (FilterNodes == null || FilterNodes.Count == 0) { return; }
                FilterIndex = XSCB.Checked ? FilterIndex - 2 : FilterIndex + 2;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.XSCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Find Button Click Event.
        /// </summary>
        private Int32 FilterIndex = 0;
        private List<TreeNode> FilterNodes = null;
        private void FindBtn_Click(object sender, EventArgs e) {
            try {
                var filter = FContentTB.Text;
                if (String.IsNullOrEmpty(filter)) { return; }
                if (FilterNodes == null) {
                    FilterNodes = new List<TreeNode>();
                    foreach (TreeNode n in FindTreeView.Nodes) {
                        FindFilterNodesRecursion(n, filter, FilterNodes);
                    }

                    FilterIndex = XSCB.Checked ? FilterNodes.Count - 1 : 0;
                }

                if (FilterNodes.Count == 0) {
                    MessageBox.Show(String.Format("未找到匹配项：\"{0}\"", filter), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (FilterIndex >= FilterNodes.Count || FilterIndex < 0) { FilterIndex = XSCB.Checked ? FilterNodes.Count - 1 : 0; }
                FindTreeView.SelectedNode = FilterNodes[XSCB.Checked ? FilterIndex-- : FilterIndex++];
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.FindBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Close Button Click Event.
        /// </summary>
        private void CloseBtn_Click(object sender, EventArgs e) {
            Close();
        }

        /// <summary>
        /// Find Filter Nodes Recursion
        /// </summary>
        /// <param name="node">tree node</param>
        /// <param name="txt">search text</param>
        /// <param name="result">result nodes</param>
        private void FindFilterNodesRecursion(TreeNode node, String txt, List<TreeNode> result) {
            if (DXXCB.Checked) {
                if (QZCB.Checked) {
                    if (node.Text.Equals(txt)) { result.Add(node); }
                } else {
                    if (node.Text.Contains(txt)) { result.Add(node); }
                }
            } else {
                if (QZCB.Checked) {
                    if (node.Text.ToLower().Equals(txt.ToLower())) { result.Add(node); }
                } else {
                    if (node.Text.ToLower().Contains(txt.ToLower())) { result.Add(node); }
                }
            }
            

            foreach (TreeNode n in node.Nodes) {
                FindFilterNodesRecursion(n, txt, result);
            }
        }
    }
}
