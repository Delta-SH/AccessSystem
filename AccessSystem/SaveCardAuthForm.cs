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
    public partial class SaveCardAuthForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private CardAuth CardAuthEntity;
        private EnmSaveBehavior CurBehavior;
        private CardAuthInfo CurCardAuth;
        private CardAuthInfo OriCardAuth;
        private CardInfo CurCard;
        private List<CardInfo> CurCards;
        private List<DepartmentInfo> CurDepartments;
        private List<OrgEmployeeInfo> CurOrgEmployees;
        private List<OutEmployeeInfo> CurOutEmployees;
        private Dictionary<String, Int32> CurExistsCards;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveCardAuthForm(EnmSaveBehavior Behavior, CardInfo Card, CardAuthInfo CardAuth, List<CardInfo> Cards, List<DepartmentInfo> Departments, List<OrgEmployeeInfo> OrgEmployees, List<OutEmployeeInfo> OutEmployees) {
            InitializeComponent();
            CardAuthEntity = new CardAuth();
            CurBehavior = Behavior;
            CurCardAuth = new CardAuthInfo();
            OriCardAuth = CardAuth;
            CurCard = Card;
            Common.CopyObjectValues(OriCardAuth, CurCardAuth);
            CurCards = Cards;
            CurDepartments = Departments;
            CurOrgEmployees = OrgEmployees;
            CurOutEmployees = OutEmployees;
            CurExistsCards = new Dictionary<String, Int32>();
            Text = Behavior == EnmSaveBehavior.Add ? "新增授权信息" : "编辑授权信息";
        }

        /// <summary>
        /// Form Shown Event
        /// </summary>
        private void SaveCardAuthForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                if (CurBehavior == EnmSaveBehavior.Null || CurCardAuth == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                BindLimitTypeCombobox();
                CardsTreeView1.CheckBoxes = CurBehavior == EnmSaveBehavior.Add;
                BeginTimeDTP.Value = CurCardAuth.BeginTime;
                EndTimeDTP.Value = CurCardAuth.EndTime;
                LimitTypeCB.SelectedValue = (Int32)CurCardAuth.LimitId;
                LimitIndexCB.SelectedValue = CurCardAuth.LimitIndex;
                PwdCB.Text = CurCardAuth.Password;
                EnabledCB.Checked = CurCardAuth.Enabled;

                var TempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    if (CurBehavior == EnmSaveBehavior.Add) {
                        CurExistsCards = CardAuthEntity.GetDevAuthCards(CurCardAuth.DevId);
                        if (CurCard.WorkerType == EnmWorkerType.WXRY) {
                            BindOutCardsToTreeView(TempTreeView);
                        } else {
                            BindOrgCardsToTreeView(TempTreeView);
                        }
                    } else {
                        BindCardAuthTreeView(TempTreeView);
                    }
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    CardsTreeView1.Nodes.Clear();
                    foreach (TreeNode tn in TempTreeView.Nodes) {
                        CardsTreeView1.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (CardsTreeView1.Nodes.Count > 0) {
                        var root = CardsTreeView1.Nodes[0];
                        CardsTreeView1.SelectedNode = root;
                        if (CurBehavior == EnmSaveBehavior.Add) {
                            root.Expand();
                        } else {
                            root.ExpandAll();
                        }
                    }
                    SaveBtn.Enabled = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardAuthForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            if (CurExistsCards.ContainsKey(sc.CardSn)) { continue; }
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
                                if (CurExistsCards.ContainsKey(sc.CardSn)) { continue; }
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
                            if (CurExistsCards.ContainsKey(sc.CardSn)) { continue; }
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
                                if (CurExistsCards.ContainsKey(sc.CardSn)) { continue; }
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
        /// Bind Card Auth TreeView.
        /// </summary>
        private void BindCardAuthTreeView(TreeView TempTreeView) {
            if (CurCard != null) {
                var node1 = TempTreeView.Nodes.Add(String.Format("delta_department_{0}", CurCard.DepId), CurCard.DepName);
                node1.Tag = new IDValuePair<Int32, String>(0, CurCard.DepId);
                node1.ImageKey = "Department";
                node1.SelectedImageKey = "Department";

                var node2 = node1.Nodes.Add(String.Format("delta_employee_{0}", CurCard.WorkerId), CurCard.WorkerName);
                node2.Tag = new IDValuePair<Int32, String>(1, CurCard.WorkerId);
                node2.ImageKey = CurCard.WorkerType == EnmWorkerType.WXRY ? "OutEmployee" : "Employee";
                node2.SelectedImageKey = CurCard.WorkerType == EnmWorkerType.WXRY ? "OutEmployee" : "Employee";

                var node3 = node2.Nodes.Add(String.Format("delta_card_{0}", CurCard.CardSn), String.Format("卡片: {0}", CurCard.CardSn));
                node3.Tag = new IDValuePair<Int32, String>(2, CurCard.CardSn);
                node3.ImageKey = "Card";
                node3.SelectedImageKey = "Card";
            }
        }

        /// <summary>
        /// Card TreeView After Check Event.
        /// </summary>
        private void CardsTreeView1_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                e.Node.Expand();
                SetChildNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Bind Limit Type Combobox.
        /// </summary>
        private void BindLimitTypeCombobox() {
            var data = new List<object>();
            data.Add(new {
                ID = (Int32)EnmLimitID.TQ,
                Name = ComUtility.GetLimitIDText(EnmLimitID.TQ)
            });
            data.Add(new {
                ID = (Int32)EnmLimitID.WTMG,
                Name = ComUtility.GetLimitIDText(EnmLimitID.WTMG)
            });
            data.Add(new {
                ID = (Int32)EnmLimitID.DTM,
                Name = ComUtility.GetLimitIDText(EnmLimitID.DTM)
            });

            LimitTypeCB.ValueMember = "ID";
            LimitTypeCB.DisplayMember = "Name";
            LimitTypeCB.DataSource = data;
        }

        /// <summary>
        /// Limit Type SelectedIndex Changed Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LimitTypeCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (LimitTypeCB.SelectedValue != null) {
                    var type = (Int32)LimitTypeCB.SelectedValue;
                    BindLimitIndexCombobox((EnmLimitID)type);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardAuthForm.LimitTypeCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Limit Index Combobox By Limit Id.
        /// </summary>
        /// <param name="limitId">Limit Id</param>
        private void BindLimitIndexCombobox(EnmLimitID limitId) {
            LimitIndexCB.Enabled = true;
            var data = new List<IDValuePair<Int32, String>>();
            switch (limitId) {
                case EnmLimitID.TQ:
                    LimitIndexCB.Enabled = false;
                    break;
                case EnmLimitID.WTMG:
                    for (var i = 0; i < 16; i++) {
                        data.Add(new IDValuePair<Int32, String>(i, String.Format("第{0}组", i + 1)));
                    }
                    break;
                case EnmLimitID.DTM:
                    for (var i = 1; i <= 4; i++) {
                        data.Add(new IDValuePair<Int32, String>(i, String.Format("第{0}组", i)));
                    }
                    break;
                default:
                    break;
            }

            LimitIndexCB.ValueMember = "ID";
            LimitIndexCB.DisplayMember = "Value";
            LimitIndexCB.DataSource = data;
        }

        /// <summary>
        /// Save Button Click Event.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                CurCardAuth.BeginTime = BeginTimeDTP.Value;
                CurCardAuth.EndTime = EndTimeDTP.Value;
                CurCardAuth.Password = PwdCB.Text.Trim();
                CurCardAuth.Enabled = EnabledCB.Checked;
                var limitId = (Int32)LimitTypeCB.SelectedValue;
                switch ((EnmLimitID)limitId) {
                    case EnmLimitID.TQ:
                        CurCardAuth.LimitId = EnmLimitID.TQ;
                        CurCardAuth.LimitIndex = ComUtility.DefaultInt32;
                        break;
                    case EnmLimitID.WTMG:
                        CurCardAuth.LimitId = EnmLimitID.WTMG;
                        CurCardAuth.LimitIndex = Convert.ToInt32(LimitIndexCB.SelectedValue);
                        break;
                    case EnmLimitID.DTM:
                        CurCardAuth.LimitId = EnmLimitID.DTM;
                        CurCardAuth.LimitIndex = Convert.ToInt32(LimitIndexCB.SelectedValue);
                        break;
                }

                var SaveCardAuth = new List<CardAuthInfo>();
                if (CurBehavior == EnmSaveBehavior.Add) {
                    var Cards = new List<String>();
                    CheckCardsTreeView(CardsTreeView1.Nodes, Cards);
                    if (Cards.Count == 0) {
                        MessageBox.Show("请勾选需要授权的卡片", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (var card in Cards) {
                        var ca = new CardAuthInfo();
                        ca.CardSn = card;
                        ca.DevId = CurCardAuth.DevId;
                        ca.LimitId = CurCardAuth.LimitId;
                        ca.LimitIndex = CurCardAuth.LimitIndex;
                        ca.BeginTime = CurCardAuth.BeginTime;
                        ca.EndTime = CurCardAuth.EndTime;
                        ca.Password = CurCardAuth.Password;
                        ca.Enabled = CurCardAuth.Enabled;
                        SaveCardAuth.Add(ca);
                    }
                } else {
                    SaveCardAuth.Add(CurCardAuth);
                }

                var result = Common.ShowWait(() => {
                    new CardAuth().SaveCardAuth(SaveCardAuth, false);
                }, default(string), "正在保存，请稍后...", default(int), default(int));

                if (result == DialogResult.OK) {
                    foreach(var ca in SaveCardAuth){
                        Common.WriteLog(DateTime.Now, CurBehavior == EnmSaveBehavior.Add ? EnmMsgType.Authin : EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveCardAuthForm.SaveBtn.Click", String.Format("{0}卡片授权[设备:{1} 卡号:{2}]", CurBehavior == EnmSaveBehavior.Add ? "新增" : "更新", ca.DevId, ca.CardSn), null);
                    }

                    if (CurBehavior == EnmSaveBehavior.Edit) {
                        Common.CopyObjectValues(CurCardAuth, OriCardAuth);
                    }
                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardAuthForm.SaveBtn.Click", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(CardsTreeView1);
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
        /// Get Cards TreeView Checked Nodes
        /// </summary>
        /// <param name="collection">Current Nodes</param>
        /// <param name="Cards">Result Cards</param>
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
