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
    public partial class CopyAuthForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private CardAuth CardAuthEntity;
        private List<CardInfo> OrgCards;
        private List<CardInfo> OutCards;
        private List<NodeLevelInfo> Nodes;
        private List<DepartmentInfo> Departments;
        private List<OrgEmployeeInfo> OrgEmployees;
        private List<OutEmployeeInfo> OutEmployees;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public CopyAuthForm() {
            InitializeComponent();
            CardAuthEntity = new CardAuth();
            OrgCards = new List<CardInfo>();
            OutCards = new List<CardInfo>();
            Nodes = new List<NodeLevelInfo>();
            Departments = new List<DepartmentInfo>();
            OrgEmployees = new List<OrgEmployeeInfo>();
            OutEmployees = new List<OutEmployeeInfo>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void CopyAuthForm_Load(object sender, EventArgs e) {
            try {
                CopyBtn1.Enabled = false;
                CopyBtn2.Enabled = false;
                CopyBtn3.Enabled = false;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void CopyAuthForm_Shown(object sender, EventArgs e) {
            try {
                var DevTempTreeView = new TreeView();
                var OrgEmpTempTreeView = new TreeView();
                var OutEmpTempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    Nodes = Common.CurUser.Role.Nodes;
                    Departments = Common.CurUser.Role.Departments;
                    OrgCards = new Card().GetOrgCards(Common.CurUser.Role.RoleID);
                    OutCards = new Card().GetOutCards(Common.CurUser.Role.RoleID);
                    OrgEmployees = new Employee().GetOrgEmployees(Common.CurUser.Role.RoleID);
                    OutEmployees = new Employee().GetOutEmployees(Common.CurUser.Role.RoleID);

                    BindDeviceToTreeView(DevTempTreeView);
                    BindOrgCardsToTreeView(OrgEmpTempTreeView);
                    BindOutCardsToTreeView(OutEmpTempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    SourceTreeView1.Nodes.Clear();
                    SourceTreeView2.Nodes.Clear();
                    SourceTreeView3.Nodes.Clear();
                    TargetTreeView1.Nodes.Clear();
                    TargetTreeView2.Nodes.Clear();
                    TargetTreeView3.Nodes.Clear();
                    foreach (TreeNode tn in DevTempTreeView.Nodes) {
                        SourceTreeView1.Nodes.Add((TreeNode)tn.Clone());
                        TargetTreeView1.Nodes.Add((TreeNode)tn.Clone());
                    }

                    foreach (TreeNode tn in OrgEmpTempTreeView.Nodes) {
                        SourceTreeView2.Nodes.Add((TreeNode)tn.Clone());
                        TargetTreeView2.Nodes.Add((TreeNode)tn.Clone());
                    }

                    foreach (TreeNode tn in OutEmpTempTreeView.Nodes) {
                        SourceTreeView3.Nodes.Add((TreeNode)tn.Clone());
                        TargetTreeView3.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (SourceTreeView1.Nodes.Count > 0) {
                        var root = SourceTreeView1.Nodes[0];
                        SourceTreeView1.SelectedNode = root;
                        root.Expand();
                    }

                    if (SourceTreeView2.Nodes.Count > 0) {
                        var root = SourceTreeView2.Nodes[0];
                        SourceTreeView2.SelectedNode = root;
                        root.Expand();
                    }

                    if (SourceTreeView3.Nodes.Count > 0) {
                        var root = SourceTreeView3.Nodes[0];
                        SourceTreeView3.SelectedNode = root;
                        root.Expand();
                    }

                    if (TargetTreeView1.Nodes.Count > 0) {
                        var root = TargetTreeView1.Nodes[0];
                        TargetTreeView1.SelectedNode = root;
                        root.Expand();
                    }

                    if (TargetTreeView2.Nodes.Count > 0) {
                        var root = TargetTreeView2.Nodes[0];
                        TargetTreeView2.SelectedNode = root;
                        root.Expand();
                    }

                    if (TargetTreeView3.Nodes.Count > 0) {
                        var root = TargetTreeView3.Nodes[0];
                        TargetTreeView3.SelectedNode = root;
                        root.Expand();
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Source TreeView1 AfterSelect Event.
        /// </summary>
        private void SourceTreeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                var tag = (IDValuePair<Int32, EnmNodeType>)e.Node.Tag;
                CopyBtn1.Enabled = tag != null && tag.Value == EnmNodeType.Dev;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.SourceTreeView1.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Source TreeView2 AfterSelect Event.
        /// </summary>
        private void SourceTreeView2_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                var tag = (IDValuePair<Int32, String>)e.Node.Tag;
                CopyBtn2.Enabled = tag != null && tag.ID == 2;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.SourceTreeView2.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Source TreeView3 AfterSelect Event.
        /// </summary>
        private void SourceTreeView3_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                var tag = (IDValuePair<Int32, String>)e.Node.Tag;
                CopyBtn3.Enabled = tag != null && tag.ID == 2;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.SourceTreeView3.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Target TreeView1 AfterCheck Event.
        /// </summary>
        private void TargetTreeView1_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                e.Node.Expand();
                SetChildNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Target TreeView2 AfterCheck Event.
        /// </summary>
        private void TargetTreeView2_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                e.Node.Expand();
                SetChildNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Target TreeView3 AfterCheck Event.
        /// </summary>
        private void TargetTreeView3_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                e.Node.Expand();
                SetChildNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Copy Button1 Click Event.
        /// </summary>
        private void CopyBtn1_Click(object sender, EventArgs e) {
            try {
                var source = new List<Int32>();
                if (SourceTreeView1.SelectedNode != null) {
                    var tag = (IDValuePair<Int32, EnmNodeType>)SourceTreeView1.SelectedNode.Tag;
                    if (tag != null && tag.Value == EnmNodeType.Dev) {
                        source.Add(tag.ID);
                    }
                }

                if (source.Count == 0) {
                    MessageBox.Show("请选择源授权设备", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                var target = new List<Int32>();
                CheckDevTreeView(TargetTreeView1.Nodes, target);
                if (target.Count == 0) {
                    MessageBox.Show("请勾选目的授权设备", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(String.Format("源设备[{0}]权限将被复制，您确定要复制吗？",source[0]), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var result = Common.ShowWait(() => {
                        CardAuthEntity.CopyAuthByDev(source, target, DeleteOriAuthCB.Checked);
                    }, default(String), "正在复制，请稍后...", default(Int32), default(Int32));

                    if (result == DialogResult.OK) {
                        foreach (var s in source) {
                            foreach (var t in target) {
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authin, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CopyAuthForm.CopyBtn1.Click", String.Format("权限复制：设备[{0}] --> 设备[{1}]", s, t), null);
                            }
                        }

                        MessageBox.Show("权限复制完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("权限复制失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.CopyBtn1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Copy Button2 Click Event.
        /// </summary>
        private void CopyBtn2_Click(object sender, EventArgs e) {
            try {
                var sourceIds = new List<String>();
                if (SourceTreeView2.SelectedNode != null) {
                    var tag = (IDValuePair<Int32, String>)SourceTreeView2.SelectedNode.Tag;
                    if (tag != null && tag.ID == 2) {
                        sourceIds.Add(tag.Value);
                    }
                }

                if (sourceIds.Count == 0) {
                    MessageBox.Show("请选择源授权卡片", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var source = from c in OrgCards
                             join id in sourceIds on c.CardSn equals id
                             select c;

                if (!source.Any()) {
                    MessageBox.Show("源授权卡片无效", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var targetIds = new List<String>();
                CheckCardsTreeView(TargetTreeView2.Nodes, targetIds);
                if (targetIds.Count == 0) {
                    MessageBox.Show("请勾选目的授权卡片", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var target = from c in OrgCards
                             join id in targetIds on c.CardSn equals id
                             select c;

                if (!target.Any()) {
                    MessageBox.Show("目的授权卡片无效", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var scard = source.First();
                if (MessageBox.Show(String.Format("源卡片[{0} - {1},{2}]权限将被复制，您确定要复制吗？", scard.CardSn, scard.WorkerId, scard.WorkerName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var result = Common.ShowWait(() => {
                        CardAuthEntity.CopyAuthByCard(source.Select(s => s.CardSn).ToList(), target.Select(t => t.CardSn).ToList(), DeleteOriAuthCB.Checked);
                    }, default(String), "正在复制，请稍后...", default(Int32), default(Int32));

                    if (result == DialogResult.OK) {
                        foreach (var s in source) {
                            foreach (var t in target) {
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authin, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CopyAuthForm.CopyBtn2.Click", String.Format("权限复制：卡片[{0} - {1},{2}] --> 卡片[{3} - {4},{5}]", s.CardSn, s.WorkerId, s.WorkerName, t.CardSn, t.WorkerId, t.WorkerName), null);
                            }
                        }

                        MessageBox.Show("权限复制完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("权限复制失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.CopyBtn2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Copy Button3 Click Event.
        /// </summary>
        private void CopyBtn3_Click(object sender, EventArgs e) {
            try {
                var sourceIds = new List<String>();
                if (SourceTreeView3.SelectedNode != null) {
                    var tag = (IDValuePair<Int32, String>)SourceTreeView3.SelectedNode.Tag;
                    if (tag != null && tag.ID == 2) {
                        sourceIds.Add(tag.Value);
                    }
                }

                if (sourceIds.Count == 0) {
                    MessageBox.Show("请选择源授权卡片", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var source = from c in OutCards
                             join id in sourceIds on c.CardSn equals id
                             select c;

                if (!source.Any()) {
                    MessageBox.Show("源授权卡片无效", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var targetIds = new List<String>();
                CheckCardsTreeView(TargetTreeView3.Nodes, targetIds);
                if (targetIds.Count == 0) {
                    MessageBox.Show("请勾选目的授权卡片", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var target = from c in OutCards
                             join id in targetIds on c.CardSn equals id
                             select c;

                if (!target.Any()) {
                    MessageBox.Show("目的授权卡片无效", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var scard = source.First();
                if (MessageBox.Show(String.Format("源卡片[{0} - {1},{2}]权限将被复制，您确定要复制吗？", scard.CardSn, scard.WorkerId, scard.WorkerName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var result = Common.ShowWait(() => {
                        CardAuthEntity.CopyAuthByCard(source.Select(s => s.CardSn).ToList(), target.Select(t => t.CardSn).ToList(), DeleteOriAuthCB.Checked);
                    }, default(String), "正在复制，请稍后...", default(Int32), default(Int32));

                    if (result == DialogResult.OK) {
                        foreach (var s in source) {
                            foreach (var t in target) {
                                Common.WriteLog(DateTime.Now, EnmMsgType.Authin, Common.CurUser.UserName, "Delta.MPS.AccessSystem.CopyAuthForm.CopyBtn3.Click", String.Format("权限复制：卡片[{0} - {1},{2}] --> 卡片[{3} - {4},{5}]", s.CardSn, s.WorkerId, s.WorkerName, t.CardSn, t.WorkerId, t.WorkerName), null);
                            }
                        }

                        MessageBox.Show("权限复制完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("权限复制失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.CopyBtn3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// MainTabControl SelectedIndex Changed Event.
        /// </summary>
        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (Finder != null && !Finder.IsDisposed) { Finder.Close(); }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.MainTabControl.SelectedIndexChanged", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(SourceTreeView1);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.TVToolStripMenuItem11.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item21 Click Event.
        /// </summary>
        private void TVToolStripMenuItem21_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(TargetTreeView1);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.TVToolStripMenuItem21.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item31 Click Event.
        /// </summary>
        private void TVToolStripMenuItem31_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(SourceTreeView2);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.TVToolStripMenuItem31.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item41 Click Event.
        /// </summary>
        private void TVToolStripMenuItem41_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(TargetTreeView2);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.TVToolStripMenuItem41.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item51 Click Event.
        /// </summary>
        private void TVToolStripMenuItem51_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(SourceTreeView3);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.TVToolStripMenuItem51.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item61 Click Event.
        /// </summary>
        private void TVToolStripMenuItem61_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(TargetTreeView3);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.CopyAuthForm.TVToolStripMenuItem61.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Device To TreeView.
        /// </summary>
        private void BindDeviceToTreeView(TreeView TempTreeView) {
            var root = TempTreeView.Nodes.Add("所有设备");
            root.Tag = new IDValuePair<Int32, EnmNodeType>(-1, EnmNodeType.Null);
            BindDeviceRecursion(root, 0);
        }

        /// <summary>
        /// Bind Device With Recursion.
        /// </summary>
        private void BindDeviceRecursion(TreeNode pNode, Int32 pId) {
            var SubNodes = Nodes.FindAll(n => n.LastNodeID == pId);
            foreach (var node in SubNodes) {
                var tnode = pNode.Nodes.Add(Common.GetTreeNodeName(node));
                tnode.Tag = new IDValuePair<Int32, EnmNodeType>(node.NodeID, node.NodeType);
                tnode.ImageKey = node.NodeType == EnmNodeType.Dev ? "Device" : "Area";
                tnode.SelectedImageKey = node.NodeType == EnmNodeType.Dev ? "Device" : "Area";

                BindDeviceRecursion(tnode, node.NodeID);
            }
        }

        /// <summary>
        /// Bind OrgEmployee Cards To TreeView.
        /// </summary>
        private void BindOrgCardsToTreeView(TreeView TempTreeView) {
            var root = TempTreeView.Nodes.Add("delta_cards_0", "所有卡片");
            root.Tag = new IDValuePair<Int32, String>(-1, "0");
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = root.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindOrgCardsRecursion(dnode, dept.DepId);
                    var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(String.Format("delta_employee_{0}", se.EmpId), se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "Employee";
                        enode.SelectedImageKey = "Employee";

                        var SubCards = OrgCards.FindAll(oc => oc.WorkerId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
                        foreach (var sc in SubCards) {
                            var cnode = enode.Nodes.Add(String.Format("delta_card_{0}", sc.CardSn), String.Format("卡片: {0}", sc.CardSn));
                            cnode.Tag = new IDValuePair<Int32, String>(2, sc.CardSn);
                            cnode.ImageKey = "Card";
                            cnode.SelectedImageKey = "Card";
                        }

                        if (enode.Nodes.Count == 0) { dnode.Nodes.Remove(enode); }
                    }

                    if (dnode.Nodes.Count == 0) { root.Nodes.Remove(dnode); }
                }
            }
        }

        /// <summary>
        /// Bind OrgEmployee Cards Recursion.
        /// </summary>
        private void BindOrgCardsRecursion(TreeNode pNode, String pId) {
            if (Departments.Count > 0) {
                var SubDepartments = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (SubDepartments.Count > 0) {
                    foreach (var dept in SubDepartments) {
                        var dnode = pNode.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                        dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                        dnode.ImageKey = "Department";
                        dnode.SelectedImageKey = "Department";

                        BindOrgCardsRecursion(dnode, dept.DepId);
                        var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                        foreach (var se in SubEmployees) {
                            var enode = dnode.Nodes.Add(String.Format("delta_employee_{0}", se.EmpId), se.EmpName);
                            enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                            enode.ImageKey = "Employee";
                            enode.SelectedImageKey = "Employee";

                            var SubCards = OrgCards.FindAll(oc => oc.WorkerId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
                            foreach (var sc in SubCards) {
                                var cnode = enode.Nodes.Add(String.Format("delta_card_{0}", sc.CardSn), String.Format("卡片: {0}", sc.CardSn));
                                cnode.Tag = new IDValuePair<Int32, String>(2, sc.CardSn);
                                cnode.ImageKey = "Card";
                                cnode.SelectedImageKey = "Card";
                            }

                            if (enode.Nodes.Count == 0) { dnode.Nodes.Remove(enode); }
                        }

                        if (dnode.Nodes.Count == 0) { pNode.Nodes.Remove(dnode); }
                    }
                }
            }
        }

        /// <summary>
        /// Bind OutEmployee Cards To TreeView.
        /// </summary>
        private void BindOutCardsToTreeView(TreeView TempTreeView) {
            var root = TempTreeView.Nodes.Add("delta_cards_0", "所有卡片");
            root.Tag = new IDValuePair<Int32, String>(-1, "0");
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = root.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindOutCardsRecursion(dnode, dept.DepId);
                    var SubEmployees = OutEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(String.Format("delta_out_employee_{0}", se.EmpId), se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "OutEmployee";
                        enode.SelectedImageKey = "OutEmployee";

                        var SubCards = OutCards.FindAll(oc => oc.WorkerId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
                        foreach (var sc in SubCards) {
                            var cnode = enode.Nodes.Add(String.Format("delta_card_{0}", sc.CardSn), String.Format("卡片: {0}", sc.CardSn));
                            cnode.Tag = new IDValuePair<Int32, String>(2, sc.CardSn);
                            cnode.ImageKey = "Card";
                            cnode.SelectedImageKey = "Card";
                        }

                        if (enode.Nodes.Count == 0) { dnode.Nodes.Remove(enode); }
                    }

                    if (dnode.Nodes.Count == 0) { root.Nodes.Remove(dnode); }
                }
            }
        }

        /// <summary>
        /// Bind OutEmployee Cards Recursion.
        /// </summary>
        private void BindOutCardsRecursion(TreeNode pNode, String pId) {
            if (Departments.Count > 0) {
                var SubDepartments = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (SubDepartments.Count > 0) {
                    foreach (var dept in SubDepartments) {
                        var dnode = pNode.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                        dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                        dnode.ImageKey = "Department";
                        dnode.SelectedImageKey = "Department";

                        BindOutCardsRecursion(dnode, dept.DepId);
                        var SubEmployees = OutEmployees.FindAll(emp => emp.DepId == dept.DepId);
                        foreach (var se in SubEmployees) {
                            var enode = dnode.Nodes.Add(String.Format("delta_out_employee_{0}", se.EmpId), se.EmpName);
                            enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                            enode.ImageKey = "OutEmployee";
                            enode.SelectedImageKey = "OutEmployee";

                            var SubCards = OutCards.FindAll(oc => oc.WorkerId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
                            foreach (var sc in SubCards) {
                                var cnode = enode.Nodes.Add(String.Format("delta_card_{0}", sc.CardSn), String.Format("卡片: {0}", sc.CardSn));
                                cnode.Tag = new IDValuePair<Int32, String>(2, sc.CardSn);
                                cnode.ImageKey = "Card";
                                cnode.SelectedImageKey = "Card";
                            }

                            if (enode.Nodes.Count == 0) { dnode.Nodes.Remove(enode); }
                        }

                        if (dnode.Nodes.Count == 0) { pNode.Nodes.Remove(dnode); }
                    }
                }
            }
        }

        /// <summary>
        /// Set Child Nodes Checked.
        /// </summary>
        private void SetChildNodeCheckedState(TreeNode currNode) {
            foreach (TreeNode tn in currNode.Nodes) {
                tn.Checked = currNode.Checked;
                SetChildNodeCheckedState(tn);
            }
        }

        /// <summary>
        /// Get Devices TreeView Checked Nodes
        /// </summary>
        private void CheckDevTreeView(TreeNodeCollection collection, List<Int32> Devices) {
            foreach (TreeNode tn in collection) {
                if (tn.Checked) {
                    var tag = (IDValuePair<Int32, EnmNodeType>)tn.Tag;
                    if (tag != null && tag.Value == EnmNodeType.Dev) {
                        Devices.Add(tag.ID);
                    }
                }
                CheckDevTreeView(tn.Nodes, Devices);
            }
        }

        /// <summary>
        /// Get Cards TreeView Checked Nodes
        /// </summary>
        private void CheckCardsTreeView(TreeNodeCollection collection, List<String> Cards) {
            foreach (TreeNode tn in collection) {
                if (tn.Checked) {
                    var tag = (IDValuePair<Int32, String>)tn.Tag;
                    if (tag != null && tag.ID == 2) {
                        Cards.Add(tag.Value);
                    }
                }
                CheckCardsTreeView(tn.Nodes, Cards);
            }
        }
    }
}
