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
    public partial class SaveCardDevAuthForm : Form
    {
        /// <summary>
        /// Gloal variables.
        /// </summary>
        private CardAuth CardAuthEntity;
        private List<CardAuthInfo> CurCardAuth;
        private List<CardAuthInfo> OriCardAuth;
        private List<NodeLevelInfo> CurNodes;
        private EnmSaveBehavior CurBehavior;
        private Dictionary<Int32, String> CurExistsNodes;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveCardDevAuthForm(EnmSaveBehavior Behavior, List<CardAuthInfo> CardAuth, List<NodeLevelInfo> Nodes) {
            InitializeComponent();
            CardAuthEntity = new CardAuth();
            CurBehavior = Behavior;
            OriCardAuth = CardAuth;
            CurCardAuth = new List<CardAuthInfo>();
            CurNodes = Nodes;
            foreach (var oc in OriCardAuth) {
                var newCardAuth = new CardAuthInfo();
                Common.CopyObjectValues(oc, newCardAuth);
                CurCardAuth.Add(newCardAuth);
            }
            Text = Behavior == EnmSaveBehavior.Add ? "新增授权信息" : "编辑授权信息";
            CurExistsNodes = new Dictionary<Int32, String>();
        }

        /// <summary>
        /// Form Shown Event
        /// </summary>
        private void SaveCardDevAuthForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                if (CurBehavior == EnmSaveBehavior.Null || CurCardAuth.Count == 0) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                BindLimitTypeCombobox();
                DeviceTreeView.CheckBoxes = CardsTreeView.CheckBoxes = CurBehavior == EnmSaveBehavior.Add;
                var cardSn = String.Empty;
                foreach (var ca in CurCardAuth) {
                    cardSn = ca.CardSn;
                    BeginTimeDTP.Value = ca.BeginTime;
                    EndTimeDTP.Value = ca.EndTime;
                    LimitTypeCB.SelectedValue = (Int32)ca.LimitId;
                    LimitIndexCB.SelectedValue = ca.LimitIndex;
                    PwdCB.Text = ca.Password;
                    EnabledCB.Checked = ca.Enabled;
                }

                var DevTempTreeView = new TreeView();
                var CardTempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    CurExistsNodes = CardAuthEntity.GetCardAuthDevs(cardSn);
                    BindDeviceToTreeView(DevTempTreeView);
                    BindCardsToTreeView(CardTempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    DeviceTreeView.Nodes.Clear();
                    foreach (TreeNode tn in DevTempTreeView.Nodes) {
                        DeviceTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    CardsTreeView.Nodes.Clear();
                    foreach (TreeNode tn in CardTempTreeView.Nodes) {
                        CardsTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (DeviceTreeView.Nodes.Count > 0) {
                        var root = DeviceTreeView.Nodes[0];
                        DeviceTreeView.SelectedNode = root;
                        if (CurBehavior == EnmSaveBehavior.Add) {
                            root.Expand();
                        } else {
                            root.ExpandAll();
                        }
                    }
                    SaveBtn.Enabled = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardDevAuthForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Device To TreeView.
        /// </summary>
        private void BindDeviceToTreeView(TreeView TempTreeView) {
            BindDeviceRecursion(TempTreeView.Nodes, 0);
        }

        /// <summary>
        /// Bind Device With Recursion.
        /// </summary>
        /// <param name="collection">collection</param>
        /// <param name="parentId">parent id</param>
        /// <param name="nodes">result node</param>
        private void BindDeviceRecursion(TreeNodeCollection collection, Int32 pId) {
            var SubNodes = CurNodes.FindAll(n => n.LastNodeID == pId);
            foreach (var node in SubNodes) {
                if (CurBehavior == EnmSaveBehavior.Add && node.NodeType == EnmNodeType.Dev && CurExistsNodes.ContainsKey(node.NodeID)) { continue; }
                var tnode = new TreeNode(Common.GetTreeNodeName(node));
                tnode.Tag = new IDValuePair<Int32, EnmNodeType>(node.NodeID, node.NodeType);
                tnode.ImageKey = node.NodeType == EnmNodeType.Dev ? "Device" : "Area";
                tnode.SelectedImageKey = node.NodeType == EnmNodeType.Dev ? "Device" : "Area";

                BindDeviceRecursion(tnode.Nodes, node.NodeID);
                if (CurBehavior == EnmSaveBehavior.Edit) {
                    if (tnode.Nodes.Count > 0 || (node.NodeType == EnmNodeType.Dev && CurCardAuth.Any(c => c.DevId == node.NodeID))) {
                        tnode.Checked = true;
                        collection.Add(tnode);
                    }
                } else if (CurBehavior == EnmSaveBehavior.Add) {
                    if (tnode.Nodes.Count > 0 || node.NodeType == EnmNodeType.Dev) {
                        collection.Add(tnode);
                    }
                }
            }
        }

        /// <summary>
        /// Bind Cards To TreeView.
        /// </summary>
        private void BindCardsToTreeView(TreeView TempTreeView) {
            foreach (var card in CurCardAuth) {
                var cnode = new TreeNode(String.Format("卡片: {0}", card.CardSn));
                cnode.Tag = card.CardSn;
                cnode.Checked = true;
                cnode.ImageKey = "Card";
                cnode.SelectedImageKey = "Card";
                TempTreeView.Nodes.Add(cnode);
            }
        }

        /// <summary>
        /// Device TreeView After Check Event.
        /// </summary>
        private void DeviceTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardDevAuthForm.LimitTypeCB.SelectedIndexChanged", err.Message, err.StackTrace);
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
                var target = new CardAuthInfo();
                target.BeginTime = BeginTimeDTP.Value;
                target.EndTime = EndTimeDTP.Value;
                target.Password = PwdCB.Text.Trim();
                target.Enabled = EnabledCB.Checked;
                var limitId = (Int32)LimitTypeCB.SelectedValue;
                switch ((EnmLimitID)limitId) {
                    case EnmLimitID.TQ:
                        target.LimitId = EnmLimitID.TQ;
                        target.LimitIndex = ComUtility.DefaultInt32;
                        break;
                    case EnmLimitID.WTMG:
                        target.LimitId = EnmLimitID.WTMG;
                        target.LimitIndex = Convert.ToInt32(LimitIndexCB.SelectedValue);
                        break;
                    case EnmLimitID.DTM:
                        target.LimitId = EnmLimitID.DTM;
                        target.LimitIndex = Convert.ToInt32(LimitIndexCB.SelectedValue);
                        break;
                }

                var SaveCardAuth = new List<CardAuthInfo>();
                if (CurBehavior == EnmSaveBehavior.Add) {
                    var Devices = new List<Int32>();
                    CheckDevTreeView(DeviceTreeView.Nodes, Devices);
                    if (Devices.Count == 0) {
                        MessageBox.Show("请勾选需要授权的设备", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var Cards = new List<String>();
                    CheckCardsTreeView(CardsTreeView.Nodes, Cards);
                    if (Cards.Count == 0) {
                        MessageBox.Show("请勾选需要授权的卡片", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (var dev in Devices) {
                        foreach (var card in Cards) {
                            var ca = new CardAuthInfo();
                            ca.CardSn = card;
                            ca.DevId = dev;
                            ca.LimitId = target.LimitId;
                            ca.LimitIndex = target.LimitIndex;
                            ca.BeginTime = target.BeginTime;
                            ca.EndTime = target.EndTime;
                            ca.Password = target.Password;
                            ca.Enabled = target.Enabled;
                            SaveCardAuth.Add(ca);
                        }
                    }
                } else {
                    foreach (var ca in CurCardAuth) {
                        ca.LimitId = target.LimitId;
                        ca.LimitIndex = target.LimitIndex;
                        ca.BeginTime = target.BeginTime;
                        ca.EndTime = target.EndTime;
                        ca.Password = target.Password;
                        ca.Enabled = target.Enabled;
                    }
                    SaveCardAuth.AddRange(CurCardAuth);
                }

                var IsSync = SyncCB.Checked;
                var result = Common.ShowWait(() => {
                    CardAuthEntity.SaveCardAuth(SaveCardAuth, IsSync);
                }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                if (result == DialogResult.OK) {
                    foreach (var ca in SaveCardAuth) {
                        Common.WriteLog(DateTime.Now, CurBehavior == EnmSaveBehavior.Add ? EnmMsgType.Authin : EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveCardDevAuthForm.SaveBtn.Click", String.Format("{0}卡片授权[设备:{1} 卡号:{2}]", CurBehavior == EnmSaveBehavior.Add ? "新增" : "更新", ca.DevId, ca.CardSn), null);
                    }

                    if (CurBehavior == EnmSaveBehavior.Edit) {
                        foreach (var cc in CurCardAuth) {
                            var OriCA = OriCardAuth.Find(oc => oc.CardSn.Equals(cc.CardSn) && oc.DevId == cc.DevId);
                            if (OriCA != null) { Common.CopyObjectValues(cc, OriCA); }
                        }
                    }
                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardDevAuthForm.SaveBtn.Click", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(DeviceTreeView);
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
                    var tag = (String)tn.Tag;
                    if (!String.IsNullOrEmpty(tag)) { Cards.Add(tag); }
                }
                CheckCardsTreeView(tn.Nodes, Cards);
            }
        }

        /// <summary>
        /// Get Devices TreeView Checked Nodes
        /// </summary>
        /// <param name="collection">Current Nodes</param>
        /// <param name="Devices">Result Devices</param>
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
    }
}
