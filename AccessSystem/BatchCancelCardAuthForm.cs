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
    public partial class BatchCancelCardAuthForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private CardAuth CardAuthEntity;
        private EnmWorkerType CurWorkerType;
        private List<CardInfo> CurCards;
        private List<NodeLevelInfo> CurNodes;
        private List<DepartmentInfo> CurDepartments;
        private List<OrgEmployeeInfo> CurOrgEmployees;
        private List<OutEmployeeInfo> CurOutEmployees;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public BatchCancelCardAuthForm(EnmWorkerType WorkerType, List<CardInfo> Cards, List<NodeLevelInfo> Nodes, List<DepartmentInfo> Departments, List<OrgEmployeeInfo> OrgEmployees, List<OutEmployeeInfo> OutEmployees) {
            InitializeComponent();
            CardAuthEntity = new CardAuth();
            CurWorkerType = WorkerType;
            CurCards = Cards;
            CurNodes = Nodes;
            CurDepartments = Departments;
            CurOrgEmployees = OrgEmployees;
            CurOutEmployees = OutEmployees;
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void BatchCancelCardAuthForm_Shown(object sender, EventArgs e) {
            try {
                DeleteBtn.Enabled = false;
                var DevTempTreeView = new TreeView();
                var CardTempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    BindDeviceToTreeView(DevTempTreeView);

                    if (CurWorkerType == EnmWorkerType.WXRY)
                        BindOutCardsToTreeView(CardTempTreeView);
                    else
                        BindOrgCardsToTreeView(CardTempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    DevTreeView.Nodes.Clear();
                    foreach (TreeNode tn in DevTempTreeView.Nodes) {
                        DevTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    CardTreeView.Nodes.Clear();
                    foreach (TreeNode tn in CardTempTreeView.Nodes) {
                        CardTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (DevTreeView.Nodes.Count > 0) {
                        var root = DevTreeView.Nodes[0];
                        DevTreeView.SelectedNode = root;
                        root.Expand();
                    }

                    if (CardTreeView.Nodes.Count > 0) {
                        var root = CardTreeView.Nodes[0];
                        CardTreeView.SelectedNode = root;
                        root.Expand();
                    }
                    DeleteBtn.Enabled = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchCancelCardAuthForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device TreeView After Check Event.
        /// </summary>
        private void DevTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                e.Node.Expand();
                SetChildNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Cards TreeView After Check Event.
        /// </summary>
        private void CardTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                e.Node.Expand();
                SetChildNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Cancel All CardAuth Button Click.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                var Devices = new List<Int32>();
                CheckDevTreeView(DevTreeView.Nodes, Devices);
                if (Devices.Count == 0) {
                    MessageBox.Show("请勾选需要撤权的设备", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var Cards = new List<String>();
                CheckCardsTreeView(CardTreeView.Nodes, Cards);
                if (Cards.Count == 0) {
                    MessageBox.Show("请勾选需要撤权的卡片", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("您确定要执行批量撤权操作吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var DelCardAuth = new List<IDValuePair<Int32, String>>();
                    foreach (var dev in Devices) {
                        foreach (var card in Cards) {
                            DelCardAuth.Add(new IDValuePair<Int32, String>(dev, card));
                        }
                    }

                    var result = Common.ShowWait(() => {
                        CardAuthEntity.DeleteCardAuth(DelCardAuth);
                    }, default(String), "正在撤权，请稍后...", default(Int32), default(Int32), 1800);

                    if (result == DialogResult.OK) {
                        foreach (var ca in DelCardAuth) {
                            Common.WriteLog(DateTime.Now, EnmMsgType.Authout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.BatchCancelCardAuthForm.DeleteBtn.Click", String.Format("删除卡片授权[设备:{0} 卡号:{1}]", ca.ID, ca.Value), null);
                        }

                        MessageBox.Show("授权撤销完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    } else {
                        MessageBox.Show("授权撤销失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchCancelCardAuthForm.DeleteBtn.Click", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(DevTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchCancelCardAuthForm.TVToolStripMenuItem11.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item21 Click Event.
        /// </summary>
        private void TVToolStripMenuItem21_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(CardTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchCancelCardAuthForm.TVToolStripMenuItem21.Click", err.Message, err.StackTrace);
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
            var SubNodes = CurNodes.FindAll(n => n.LastNodeID == pId);
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
            foreach (var dept in CurDepartments) {
                var pDepat = CurDepartments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = root.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindOrgCardsRecursion(dnode, dept.DepId);
                    var SubEmployees = CurOrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(String.Format("delta_employee_{0}", se.EmpId), se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "Employee";
                        enode.SelectedImageKey = "Employee";

                        var SubCards = CurCards.FindAll(oc => oc.WorkerId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
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
            if (CurDepartments.Count > 0) {
                var SubDepartments = CurDepartments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (SubDepartments.Count > 0) {
                    foreach (var dept in SubDepartments) {
                        var dnode = pNode.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                        dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                        dnode.ImageKey = "Department";
                        dnode.SelectedImageKey = "Department";

                        BindOrgCardsRecursion(dnode, dept.DepId);
                        var SubEmployees = CurOrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                        foreach (var se in SubEmployees) {
                            var enode = dnode.Nodes.Add(String.Format("delta_employee_{0}", se.EmpId), se.EmpName);
                            enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                            enode.ImageKey = "Employee";
                            enode.SelectedImageKey = "Employee";

                            var SubCards = CurCards.FindAll(oc => oc.WorkerId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
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
            foreach (var dept in CurDepartments) {
                var pDepat = CurDepartments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = root.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindOutCardsRecursion(dnode, dept.DepId);
                    var SubEmployees = CurOutEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(String.Format("delta_out_employee_{0}", se.EmpId), se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "OutEmployee";
                        enode.SelectedImageKey = "OutEmployee";

                        var SubCards = CurCards.FindAll(oc => oc.WorkerId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
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
            if (CurDepartments.Count > 0) {
                var SubDepartments = CurDepartments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (SubDepartments.Count > 0) {
                    foreach (var dept in SubDepartments) {
                        var dnode = pNode.Nodes.Add(String.Format("delta_department_{0}", dept.DepId), dept.DepName);
                        dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                        dnode.ImageKey = "Department";
                        dnode.SelectedImageKey = "Department";

                        BindOutCardsRecursion(dnode, dept.DepId);
                        var SubEmployees = CurOutEmployees.FindAll(emp => emp.DepId == dept.DepId);
                        foreach (var se in SubEmployees) {
                            var enode = dnode.Nodes.Add(String.Format("delta_out_employee_{0}", se.EmpId), se.EmpName);
                            enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                            enode.ImageKey = "OutEmployee";
                            enode.SelectedImageKey = "OutEmployee";

                            var SubCards = CurCards.FindAll(oc => oc.WorkerId.Equals(se.EmpId, StringComparison.CurrentCultureIgnoreCase));
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