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
    public partial class SaveRoleForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private EnmSaveBehavior CurBehavior = EnmSaveBehavior.Null;
        private RoleInfo CurRole;
        private RoleInfo OriRole;
        private TreeView AuthorizationsTreeView;
        private TreeView NodesTreeView;
        private TreeView DepartmentTreeView;
        private MemberShip MemberShipEntity;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveRoleForm(EnmSaveBehavior Behavior, RoleInfo Role) {
            InitializeComponent();
            AuthorizationsTreeView = new TreeView();
            AuthorizationsTreeView.CheckBoxes = true;
            AuthorizationsTreeView.Dock = DockStyle.Fill;
            AuthorizationsTreeView.ImageKey = "Default";
            AuthorizationsTreeView.ImageList = TreeImages;
            AuthorizationsTreeView.SelectedImageKey = "Default";
            AuthorizationsTreeView.ContextMenuStrip = TreeViewContextMenuStrip1;
            AuthorizationsTreeView.HideSelection = false;
            AuthorizationsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(authorizationsTreeView_AfterCheck);

            NodesTreeView = new TreeView();
            NodesTreeView.CheckBoxes = true;
            NodesTreeView.Dock = DockStyle.Fill;
            NodesTreeView.ImageKey = "Default";
            NodesTreeView.ImageList = TreeImages;
            NodesTreeView.SelectedImageKey = "Default";
            NodesTreeView.ContextMenuStrip = TreeViewContextMenuStrip2;
            NodesTreeView.HideSelection = false;
            NodesTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(nodesTreeView_AfterCheck);

            DepartmentTreeView = new TreeView();
            DepartmentTreeView.CheckBoxes = true;
            DepartmentTreeView.Dock = DockStyle.Fill;
            DepartmentTreeView.ImageKey = "Default";
            DepartmentTreeView.ImageList = TreeImages;
            DepartmentTreeView.SelectedImageKey = "Default";
            DepartmentTreeView.ContextMenuStrip = TreeViewContextMenuStrip3;
            DepartmentTreeView.HideSelection = false;
            DepartmentTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(departmentTreeView_AfterCheck);

            MemberShipEntity = new MemberShip();
            CurBehavior = Behavior;
            CurRole = new RoleInfo();
            OriRole = Role;
            Common.CopyObjectValues(OriRole, CurRole);
            Text = Behavior == EnmSaveBehavior.Add ? "新增角色权限" : "编辑角色权限";
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void SaveRoleForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                if (CurBehavior == EnmSaveBehavior.Null || CurRole == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                var result = Common.ShowWait(() => {
                    if (CurBehavior == EnmSaveBehavior.Edit) {
                        CurRole.Authorizations = MemberShipEntity.GetRoleAuthorizations(CurRole.RoleID);
                        CurRole.Nodes = MemberShipEntity.GetRoleNodes(CurRole.RoleID);
                        CurRole.Departments = MemberShipEntity.GetRoleDepartments(CurRole.RoleID);
                    }

                    foreach (var auth in Common.CurUser.Role.Authorizations) {
                        var pAuth = Common.CurUser.Role.Authorizations.Find(a => a.AuthId == auth.LastAuthId);
                        if (pAuth == null) {
                            if (!auth.Enabled) { continue; }

                            var node = new TreeNode();
                            node.Tag = auth.AuthId;
                            node.Text = auth.AuthName;
                            node.Checked = CurRole.Authorizations.Any(a => a.AuthId == auth.AuthId);
                            node.ImageKey = "Menu";
                            node.SelectedImageKey = "Menu";
                            AuthorizationsTreeView.Nodes.Add(node);
                            BindAuthorizationsTreeView(node, auth.AuthId);
                        }
                    }
                    AuthorizationsTreeView.ExpandAll();

                    BindNodesTreeView(NodesTreeView.Nodes, 0, Common.CurUser.Role.Nodes);

                    foreach (var dept in Common.CurUser.Role.Departments) {
                        var pDepat = Common.CurUser.Role.Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                        if (pDepat == null) {
                            var node = new TreeNode();
                            node.Tag = dept.DepId;
                            node.Text = dept.DepName;
                            node.Checked = CurRole.Departments.Any(d => d.DepId == dept.DepId);
                            node.ImageKey = "Department";
                            node.SelectedImageKey = "Department";
                            DepartmentTreeView.Nodes.Add(node);

                            BindDepartmentsTreeView(node, dept.DepId);
                        }
                    }
                    DepartmentTreeView.ExpandAll();
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    RoleIDTB.Text = CurRole.RoleID.ToString().ToUpper();
                    RoleNameTB.Text = CurRole.RoleName;
                    RoleCommentTB.Text = CurRole.Comment;
                    EnabledCB.Checked = CurRole.Enabled;

                    AuthorizationTabPage.Controls.Add(AuthorizationsTreeView);
                    NodeTabPage.Controls.Add(NodesTreeView);
                    DepartmentTabPage.Controls.Add(DepartmentTreeView);
                    SaveBtn.Enabled = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveRoleForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Authorizations TreeView.
        /// </summary>
        /// <param name="pNode">parent node</param>
        /// <param name="pId">parent id</param>
        private void BindAuthorizationsTreeView(TreeNode pNode, Int32 pId) {
            var sns = Common.CurUser.Role.Authorizations.FindAll(a => { return a.LastAuthId == pId; });
            if (sns.Count > 0) {
                foreach (var sn in sns) {
                    if (!sn.Enabled) { continue; }

                    var node = new TreeNode();
                    node.Tag = sn.AuthId;
                    node.Text = sn.AuthName;
                    node.Checked = CurRole.Authorizations.Any(a => a.AuthId == sn.AuthId);
                    node.ImageKey = "Menu";
                    node.SelectedImageKey = "Menu";
                    pNode.Nodes.Add(node);

                    BindAuthorizationsTreeView(node, sn.AuthId);
                }
            }
        }

        /// <summary>
        /// Get Checked Authorizations TreeNodes.
        /// </summary>
        /// <param name="collection">tree node collection</param>
        /// <param name="lastId">parent id</param>
        /// <param name="authorizations">authorizations</param>
        private void CheckAuthorizationsTreeView(TreeNodeCollection collection, int lastId, List<AuthorizationInfo> authorizations) {
            foreach (TreeNode tn in collection) {
                var id = Convert.ToInt32(tn.Tag);
                if (tn.Checked) { authorizations.Add(new AuthorizationInfo() { AuthId = id }); }
                CheckAuthorizationsTreeView(tn.Nodes, id, authorizations);
            }
        }

        /// <summary>
        /// Bind Nodes TreeView.
        /// </summary>
        /// <param name="collection">parent collection</param>
        /// <param name="lastId">parent id</param>
        /// <param name="nodes">nodes</param>
        private void BindNodesTreeView(TreeNodeCollection collection, int lastId, List<NodeLevelInfo> nodes) {
            if (nodes != null && nodes.Count > 0) {
                var SubNodes = nodes.FindAll(n => { return n.LastNodeID == lastId; }).OrderBy(a => a.SortIndex).ToList();
                if (SubNodes.Count > 0) {
                    foreach (var sn in SubNodes) {
                        if (sn.NodeType != EnmNodeType.Area) { continue; }
                        var treeNode = new TreeNode();
                        treeNode.Tag = sn;
                        treeNode.Text = sn.NodeName;
                        treeNode.Checked = CurRole.Nodes.Any(n => n.NodeID == sn.NodeID && n.NodeType == sn.NodeType);
                        treeNode.ImageKey = sn.NodeType == EnmNodeType.Dev ? "Device" : "Area";
                        treeNode.SelectedImageKey = sn.NodeType == EnmNodeType.Dev ? "Device" : "Area";
                        collection.Add(treeNode);

                        BindNodesTreeView(treeNode.Nodes, sn.NodeID, nodes);
                        if (sn.NodeType == EnmNodeType.Area) { treeNode.Expand(); }
                    }
                }
            }
        }

        /// <summary>
        /// Get Checked Nodes TreeNodes.
        /// </summary>
        /// <param name="collection">tree node collection</param>
        /// <param name="lastId">parent id</param>
        /// <param name="sortIndex">sort index</param>
        /// <param name="nodes">nodes</param>
        private void CheckNodesTreeView(TreeNodeCollection collection, int lastId, ref int sortIndex, List<NodeLevelInfo> nodes) {
            foreach (TreeNode tn in collection) {
                if (tn.Checked) {
                    var node = tn.Tag as NodeLevelInfo;
                    node.LastNodeID = lastId;
                    node.SortIndex = ++sortIndex;
                    nodes.Add(node);

                    var nextIndex = 0;
                    CheckNodesTreeView(tn.Nodes, node.NodeID, ref nextIndex, nodes);
                } else {
                    CheckNodesTreeView(tn.Nodes, lastId, ref sortIndex, nodes);
                }
            }
        }

        /// <summary>
        /// Bind Departments TreeView.
        /// </summary>
        /// <param name="pNode">parent node</param>
        /// <param name="pId">parent id</param>
        private void BindDepartmentsTreeView(TreeNode pNode, String pId) {
            var sns = Common.CurUser.Role.Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
            if (sns.Count > 0) {
                foreach (var sn in sns) {
                    var node = new TreeNode();
                    node.Tag = sn.DepId;
                    node.Text = sn.DepName;
                    node.Checked = CurRole.Departments.Any(d => d.DepId == sn.DepId);
                    node.ImageKey = "Department";
                    node.SelectedImageKey = "Department";
                    pNode.Nodes.Add(node);

                    BindDepartmentsTreeView(node, sn.DepId);
                }
            }
        }

        /// <summary>
        /// Get Checked Departments TreeNodes.
        /// </summary>
        /// <param name="collection">tree node collection</param>
        /// <param name="lastId">parent id</param>
        /// <param name="departments">departments</param>
        private void CheckDepartmentsTreeView(TreeNodeCollection collection, string lastId, List<DepartmentInfo> departments) {
            foreach (TreeNode tn in collection) {
                var id = Convert.ToString(tn.Tag);
                if (tn.Checked) { departments.Add(new DepartmentInfo() { DepId = id }); }
                CheckDepartmentsTreeView(tn.Nodes, id, departments);
            }
        }

        /// <summary>
        /// Authorizations TreeView AfterCheck Event.
        /// </summary>
        private void authorizationsTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                setChildNodeCheckedState(e.Node);
                setParentNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Nodes TreeView AfterCheck Event.
        /// </summary>
        private void nodesTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                setChildNodeCheckedState(e.Node);
                setParentNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Department TreeView AfterCheck Event.
        /// </summary>
        private void departmentTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
            if (e.Action == TreeViewAction.ByMouse) {
                setChildNodeCheckedState(e.Node);
            }
        }

        /// <summary>
        /// Set ChildNodes Checked.
        /// </summary>
        /// <param name="currNode">current node</param>
        private void setChildNodeCheckedState(TreeNode currNode) {
            foreach (TreeNode tn in currNode.Nodes) {
                tn.Checked = currNode.Checked;
                setChildNodeCheckedState(tn);
            }
        }

        /// <summary>
        /// Set ParentNode Checked.
        /// </summary>
        /// <param name="currNode">current node</param>
        private void setParentNodeCheckedState(TreeNode currNode) {
            if (currNode.Parent != null) {
                if (currNode.Checked) {
                    currNode.Parent.Checked = currNode.Checked;
                    setParentNodeCheckedState(currNode.Parent);
                } else {
                    var pChecked = false;
                    foreach (TreeNode tn in currNode.Parent.Nodes) {
                        if (tn.Checked) { pChecked = true; break; }
                    }

                    if (!pChecked) {
                        currNode.Parent.Checked = false;
                        setParentNodeCheckedState(currNode.Parent);
                    }
                }
            }
        }

        /// <summary>
        /// Save Role.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(RoleIDTB.Text)) {
                    MessageBox.Show("角色标识不能为空", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(RoleNameTB.Text)) {
                    MessageBox.Show("角色名称不能为空", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var RoleName = RoleNameTB.Text.Trim();
                if (CurBehavior == EnmSaveBehavior.Add || (CurBehavior == EnmSaveBehavior.Edit && !CurRole.RoleName.Equals(RoleName,StringComparison.CurrentCultureIgnoreCase))) {
                    if (MemberShipEntity.RoleExists(RoleName)) {
                        MessageBox.Show("角色已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                CurRole.RoleName = RoleNameTB.Text.Trim();
                CurRole.Comment = RoleCommentTB.Text.Trim();
                CurRole.Enabled = EnabledCB.Checked;
                CurRole.Authorizations.Clear();
                CheckAuthorizationsTreeView(AuthorizationsTreeView.Nodes, 0, CurRole.Authorizations);
                if (CurRole.Authorizations.Count == 0) {
                    MessageBox.Show("操作权限未授权", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RoleTabControl.SelectedIndex = 0;
                    return;
                }

                var sortIndex = 0;
                CurRole.Nodes.Clear();
                CheckNodesTreeView(NodesTreeView.Nodes, 0, ref sortIndex, CurRole.Nodes);
                if (CurRole.Nodes.Count == 0) {
                    MessageBox.Show("设备权限未授权", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RoleTabControl.SelectedIndex = 1;
                    return;
                }

                CurRole.Departments.Clear();
                CheckDepartmentsTreeView(DepartmentTreeView.Nodes, "0", CurRole.Departments);
                if (CurRole.Departments.Count == 0) {
                    MessageBox.Show("部门权限未授权", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RoleTabControl.SelectedIndex = 2;
                    return;
                }

                var result = Common.ShowWait(() => {
                    CurRole.LastRoleID = Common.CurUser.Role.RoleID;
                    MemberShipEntity.SaveRoles(new List<RoleInfo> { CurRole });
                    if (CurBehavior == EnmSaveBehavior.Edit) { MemberShipEntity.VerifyRoles(new List<RoleInfo> { CurRole }); }
                }, default(string), "正在保存，请稍后...", default(int), default(int));

                if (result == DialogResult.OK) {
                    Common.CopyObjectValues(CurRole, OriRole);
                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveRoleForm.SaveBtn.Click", String.Format("{0}角色：[{1}]", CurBehavior == EnmSaveBehavior.Add ? "新增" : "更新", CurRole.RoleName), null);
                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveRoleForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Role TabControl SelectedIndex Changed Event.
        /// </summary>
        private void RoleTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (Finder != null && !Finder.IsDisposed) { Finder.Close(); }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveRoleForm.RoleTabControl.SelectedIndexChanged", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(AuthorizationsTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveRoleForm.TVToolStripMenuItem11.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item21 Click Event.
        /// </summary>
        private void TVToolStripMenuItem21_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(NodesTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveRoleForm.TVToolStripMenuItem21.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item31 Click Event.
        /// </summary>
        private void TVToolStripMenuItem31_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(DepartmentTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveRoleForm.TVToolStripMenuItem31.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
