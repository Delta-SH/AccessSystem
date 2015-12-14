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
    public partial class GridManagerForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private List<IDValuePair<Int32, String>> TotalGrids;

        /// <summary>
        /// Class Constructor.
        /// </summary>
        public GridManagerForm() {
            InitializeComponent();
            TotalGrids = new List<IDValuePair<Int32, String>>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void GridManagerForm_Load(object sender, EventArgs e) {
            try {
                BindGridTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridManagerForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void GridManagerForm_Shown(object sender, EventArgs e) {
            try {
                DeleteBtn.Enabled = EditBtn.Enabled = GridTreeView.Nodes.Count > 0 && GridTreeView.SelectedNode != null;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridManagerForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add Grid.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                var dialog = new SaveGridForm(EnmSaveBehavior.Add, new IDValuePair<Int32, String>(0, String.Empty));
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    BindGridTreeView();
                    SelectTreeNodeByText(dialog.Grid.Value);
                    DeleteBtn.Enabled = EditBtn.Enabled = GridTreeView.Nodes.Count > 0 && GridTreeView.SelectedNode != null;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridManagerForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Grid.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                var node = GridTreeView.SelectedNode;
                if (node == null) {
                    MessageBox.Show("请选择需要删除的网格", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var tag = (IDValuePair<Int32, String>)node.Tag;
                if (MessageBox.Show(String.Format("\"{0}\"将被删除，您确定要删除吗？", tag.Value), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    new Grid().DeleteGrids(new List<IDValuePair<Int32, String>>() { tag });
                    GridTreeView.Nodes.RemoveByKey(tag.ID.ToString());
                    GridTreeView.Focus();
                    DeleteBtn.Enabled = EditBtn.Enabled = GridTreeView.Nodes.Count > 0 && GridTreeView.SelectedNode != null;
                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.GridManagerForm.DeleteBtn.Click", String.Format("删除网格:[{0} - {1}]", tag.ID, tag.Value), null);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridManagerForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Edit Grid.
        /// </summary>
        private void EditBtn_Click(object sender, EventArgs e) {
            try {
                var node = GridTreeView.SelectedNode;
                if (node == null) {
                    MessageBox.Show("请选择需要修改的网格", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialog = new SaveGridForm(EnmSaveBehavior.Edit, (IDValuePair<Int32, String>)node.Tag);
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    BindGridTreeView();
                    SelectTreeNodeByID(dialog.Grid.ID);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridManagerForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Grid TreeView.
        /// </summary>
        private void BindGridTreeView() {
            GridTreeView.Nodes.Clear();
            TotalGrids = new Grid().GetGrids();
            foreach (var tg in TotalGrids) {
                var node = GridTreeView.Nodes.Add(tg.ID.ToString(), tg.Value);
                node.Tag = tg;
            }
        }

        /// <summary>
        /// Select TreeView Node By Node ID.
        /// </summary>
        /// <param name="nodeId">node id</param>
        private void SelectTreeNodeByID(Int32 nodeId) {
            var nodes = GridTreeView.Nodes.Find(nodeId.ToString(), false);
            if (nodes != null && nodes.Length > 0) {
                GridTreeView.SelectedNode = nodes[0];
                GridTreeView.Focus();
            }
        }

        /// <summary>
        /// Select TreeView Node By Node Text.
        /// </summary>
        /// <param name="text">node text</param>
        private void SelectTreeNodeByText(String text) {
            foreach (TreeNode tn in GridTreeView.Nodes) {
                if (tn.Text.Equals(text)) {
                    GridTreeView.SelectedNode = tn;
                    GridTreeView.Focus();
                    break;
                }
            }
        }
    }
}