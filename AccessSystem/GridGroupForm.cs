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
    public partial class GridGroupForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private List<StaInfo> CurStations;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public GridGroupForm() {
            InitializeComponent();
            CurStations = new List<StaInfo>();
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void GridGroupForm_Shown(object sender, EventArgs e) {
            try {
                BindGridTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Grid TreeView AfterSelect Event.
        /// </summary>
        private void GridTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                BindStationsToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.GridTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Grid Group GridView CellContent Click Event.
        /// </summary>
        private void GridGroupGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key = (Int32)GridGroupGridView.Rows[e.RowIndex].Cells["StaIDColumn"].Value;
                var obj = CurStations.Find(d => d.StaID == key);
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (GridGroupGridView.Columns[e.ColumnIndex].Name) {
                    case "DeleteColumn":
                        if (MessageBox.Show("您确定要删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                new Grid().DeleteStaGrid(new List<Int32>() { obj.StaID });
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                CurStations.Remove(obj);
                                GridGroupGridView.Rows.RemoveAt(e.RowIndex);
                            }
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.GridGroupGridView.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Grid Group GridView CellValue Needed Event.
        /// </summary>
        private void GridGroupGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurStations.Count - 1) { return; }
                switch (GridGroupGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "Area2NameColumn":
                        e.Value = CurStations[e.RowIndex].Area2Name;
                        break;
                    case "Area3NameColumn":
                        e.Value = CurStations[e.RowIndex].Area3Name;
                        break;
                    case "StaIDColumn":
                        e.Value = CurStations[e.RowIndex].StaID;
                        break;
                    case "StaNameColumn":
                        e.Value = CurStations[e.RowIndex].StaName;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.GridGroupGridView.CellValueNeeded", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(GridTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add Stations To Grid.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                var node = GridTreeView.SelectedNode;
                if (node == null) {
                    MessageBox.Show("请选择所属网格", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (new SaveStaGridForm((IDValuePair<Int32, String>)node.Tag).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    BindStationsToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Stations From Grid.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                if (GridGroupGridView.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            new Grid().DeleteStaGrid(CurStations.Select(s => s.StaID).ToList());
                        }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            CurStations.Clear();
                            GridGroupGridView.Rows.Clear();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export Data To Excel.
        /// </summary>
        private void ExportBtn_Click(object sender, EventArgs e) {
            try {
                if (CurStations.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("所属地区", typeof(String));
                    data.Columns.Add("所属县市", typeof(String));
                    data.Columns.Add("局站编号", typeof(String));
                    data.Columns.Add("局站名称", typeof(String));
                    data.Columns.Add("网格编号", typeof(String));
                    data.Columns.Add("网格名称", typeof(String));
                    for (var i = 0; i < CurStations.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["所属地区"] = CurStations[i].Area2Name;
                        dr["所属县市"] = CurStations[i].Area3Name;
                        dr["局站编号"] = CurStations[i].StaID;
                        dr["局站名称"] = CurStations[i].StaName;
                        dr["网格编号"] = CurStations[i].NetGridID;
                        dr["网格名称"] = CurStations[i].NetGridName;
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "局站网格信息", String.Format("智能门禁管理系统 局站网格信息报表"), String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.ExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Grid Manager Button Click Event.
        /// </summary>
        private void GridMgrBtn_Click(object sender, EventArgs e) {
            try {
                new GridManagerForm().ShowDialog(this);
                BindGridTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.GridMgrBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Opening Event.
        /// </summary>
        private void OperationContext_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = GridGroupGridView.SelectedRows.Count > 0;
                OpMenuItem2.Enabled = GridGroupGridView.Rows.Count > 0;
                OpMenuItem3.Enabled = CurStations.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.OperationContext.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Selected Stations.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (GridGroupGridView.Rows.Count > 0) {
                    var adEmps = new Dictionary<Int32, StaInfo>();
                    foreach (DataGridViewRow row in GridGroupGridView.SelectedRows) {
                        var key = (Int32)row.Cells["StaIDColumn"].Value;
                        var obj = CurStations.Find(s => s.StaID == key);
                        if (obj != null) { adEmps[row.Index] = obj; }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中局站将被删除，您确定要删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                new Grid().DeleteStaGrid(adEmps.Select(s => s.Value.StaID).ToList());
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            foreach (var ae in adEmps) {
                                CurStations.Remove(ae.Value);
                                GridGroupGridView.Rows.RemoveAt(ae.Key);
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.GridGroupForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Stations.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            DeleteBtn_Click(sender, e);
        }

        /// <summary>
        /// Export Data To Excel.
        /// </summary>
        private void OpMenuItem3_Click(object sender, EventArgs e) {
            ExportBtn_Click(sender, e);
        }

        /// <summary>
        /// Bind Grid TreeView.
        /// </summary>
        private void BindGridTreeView() {
            GridTreeView.Nodes.Clear();
            var totalGrids = new Grid().GetGrids();
            foreach (var tg in totalGrids) {
                var node = GridTreeView.Nodes.Add(tg.ID.ToString(), tg.Value);
                node.Tag = tg;
            }

            if (GridTreeView.Nodes.Count > 0) {
                GridTreeView.SelectedNode = GridTreeView.Nodes[0];
            }
        }

        /// <summary>
        /// Bind Stations To GridView.
        /// </summary>
        private void BindStationsToGridView() {
            CurStations.Clear();
            GridGroupGridView.Rows.Clear();
            if (GridTreeView.SelectedNode != null) {
                var tag = (IDValuePair<Int32, String>)GridTreeView.SelectedNode.Tag;
                if (tag != null) {
                    CurStations.AddRange(new Grid().GetGridStations(Common.CurUser.Role.RoleID, tag.ID));
                }
            }

            GridGroupGridView.RowCount = CurStations.Count;
        }
    }
}