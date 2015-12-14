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
    public partial class SaveStaGridForm : Form
    {
        /// <summary>
        /// Gloal variables.
        /// </summary>
        private IDValuePair<Int32,String> CurGrid;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveStaGridForm(IDValuePair<Int32, String> Grid) {
            InitializeComponent();
            CurGrid = Grid;
            //Text = String.Format("添加\"{0}\"所含局站", CurGrid.Value);
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void SaveStaGridForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                var TempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    BindStationToTreeView(TempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    StaTreeView.Nodes.Clear();
                    foreach (TreeNode tn in TempTreeView.Nodes) {
                        StaTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (StaTreeView.Nodes.Count > 0) {
                        var root = StaTreeView.Nodes[0];
                        StaTreeView.SelectedNode = root;
                        root.Expand();
                    }
                    SaveBtn.Enabled = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveStaGridForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Station TreeView AfterCheck Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StaTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                e.Node.Expand();
                SetChildNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// TreeView Menu Item1 Click Event.
        /// </summary>
        private FinderDialog Finder = null;
        private void TVToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(StaTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveStaGridForm.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save Station Grid.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                var Stations = new List<Int32>();
                CheckStaTreeView(StaTreeView.Nodes, Stations);

                var result = Common.ShowWait(() => {
                    new Grid().UpdateStaGrid(CurGrid.ID, Stations);
                }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                if (result == DialogResult.OK) {
                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveStaGridForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Station To TreeView.
        /// </summary>
        private void BindStationToTreeView(TreeView TempTreeView) {
            BindStationRecursion(TempTreeView.Nodes, 0);
        }

        /// <summary>
        /// Bind Station With Recursion.
        /// </summary>
        /// <param name="collection">collection</param>
        /// <param name="parentId">parent id</param>
        private void BindStationRecursion(TreeNodeCollection collection, Int32 pId) {
            var nodes = Common.CurUser.Role.Nodes.FindAll(n => n.LastNodeID == pId);
            foreach (var node in nodes) {
                if (node.NodeType == EnmNodeType.Dev) { continue; }
                var tn = collection.Add(Common.GetTreeNodeName(node));
                tn.Tag = new IDValuePair<Int32, EnmNodeType>(node.NodeID, node.NodeType);

                BindStationRecursion(tn.Nodes, node.NodeID);
            }
        }

        /// <summary>
        /// Set Child Nodes Checked.
        /// </summary>
        /// <param name="currNode">Current Node</param>
        private void SetChildNodeCheckedState(TreeNode currNode) {
            foreach (TreeNode tn in currNode.Nodes) {
                tn.Checked = currNode.Checked;
                SetChildNodeCheckedState(tn);
            }
        }

        /// <summary>
        /// Get Stations TreeView Checked Nodes
        /// </summary>
        /// <param name="collection">Current Nodes</param>
        /// <param name="Stations">Result Stations</param>
        private void CheckStaTreeView(TreeNodeCollection collection, List<Int32> Stations) {
            foreach (TreeNode tn in collection) {
                if (tn.Checked) {
                    var tag = (IDValuePair<Int32, EnmNodeType>)tn.Tag;
                    if (tag != null && tag.Value == EnmNodeType.Sta) {
                        Stations.Add(tag.ID);
                    }
                }
                CheckStaTreeView(tn.Nodes, Stations);
            }
        }
    }
}
