using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Delta.MPS.SQLServerDAL;
using Delta.MPS.Model;

namespace Delta.MPS.AccessSystem
{
    public partial class RoleManagerForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private MemberShip MemberShipEntity;
        private List<RoleInfo> Roles;
        private List<RoleInfo> GridRoles;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public RoleManagerForm() {
            InitializeComponent();
            MemberShipEntity = new MemberShip();
            Roles = new List<RoleInfo>();
            GridRoles = new List<RoleInfo>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void RoleManagerForm_Load(object sender, EventArgs e) {
            try {
                Roles.AddRange(MemberShipEntity.GetSubRoles(Common.CurUser.Role.RoleID));
                BindRolesToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Role TreeView AfterSelect Event.
        /// </summary>
        private void RoleTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                GridRoles.Clear();
                FindSubRolesRecursion((Guid)e.Node.Tag, GridRoles);
                BindRolesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.RoleTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Role GridView Cell Value Needed Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > GridRoles.Count - 1) { return; }
                switch (RoleGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "GuidColumn":
                        e.Value = GridRoles[e.RowIndex].RoleID;
                        break;
                    case "NameColumn":
                        e.Value = GridRoles[e.RowIndex].RoleName;
                        break;
                    case "CommentColumn":
                        e.Value = GridRoles[e.RowIndex].Comment;
                        break;
                    case "EnabledColumn":
                        e.Value = GridRoles[e.RowIndex].Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.RoleGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Role GridView CellContent Click Event.
        /// </summary>
        private void RoleGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key = (Guid)RoleGridView.Rows[e.RowIndex].Cells["GuidColumn"].Value;
                var obj = GridRoles.Find(r => r.RoleID == key);
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (RoleGridView.Columns[e.ColumnIndex].Name) {
                    case "DeleteColumn":
                        if (MemberShipEntity.RoleUserExists(obj.RoleID)) {
                            MessageBox.Show(String.Format("角色[{0}]下存在用户，无法执行删除操作。",obj.RoleName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var SubRoles = new List<RoleInfo>();
                        FindSubRolesRecursion(obj.RoleID, SubRoles);
                        foreach (var sr in SubRoles) {
                            if (MemberShipEntity.RoleUserExists(sr.RoleID)) {
                                MessageBox.Show(String.Format("其子角色[{0}]下存在用户，无法执行删除操作。", sr.RoleName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        if (MessageBox.Show(String.Format("角色[{0}]{1}将被删除，您确定要删除吗?", obj.RoleName, SubRoles.Count > 0 ? "及其子角色" : String.Empty), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                SubRoles.Add(obj);
                                MemberShipEntity.DelRoles(SubRoles);
                            }, default(String), "正在删除，请稍后...", default(int), default(int));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var sr in SubRoles) {
                                    Roles.Remove(sr);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.RoleManagerForm.RoleGridView.CellContentClick", String.Format("删除角色:[{0}]", sr.RoleName), null);
                                }

                                BindRolesToTreeView();
                            }
                        }
                        break;
                    case "EditColumn":
                        if (new SaveRoleForm(EnmSaveBehavior.Edit, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            BindRolesToTreeView();
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.RoleGridView.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add Role.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                var obj = new RoleInfo() {
                    RoleID = Guid.NewGuid(),
                    RoleName = String.Empty,
                    Comment = String.Empty,
                    LastRoleID = Common.CurUser.Role.RoleID,
                    Enabled = true,
                    Authorizations = new List<AuthorizationInfo>(),
                    Nodes = new List<NodeLevelInfo>(),
                    Departments = new List<DepartmentInfo>() 
                };

                if (new SaveRoleForm(EnmSaveBehavior.Add, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    Roles.Add(obj);
                    BindRolesToTreeView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Roles.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                if (RoleGridView.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        foreach (var gr in GridRoles) {
                            if (MemberShipEntity.RoleUserExists(gr.RoleID)) {
                                MessageBox.Show(String.Format("角色[{0}]下存在用户，无法执行删除操作。", gr.RoleName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        var result = Common.ShowWait(() => {
                            MemberShipEntity.DelRoles(GridRoles);
                        }, default(string), "正在删除，请稍后...", default(int), default(int));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var gr in GridRoles) {
                                Roles.Remove(gr);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.RoleManagerForm.DeleteBtn.Click", String.Format("删除角色:[{0}]", gr.RoleName), null);
                            }

                            BindRolesToTreeView();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save All Roles To Excel.
        /// </summary>
        private void ExportBtn_Click(object sender, EventArgs e) {
            try {
                if (GridRoles.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("角色标识", typeof(String));
                    data.Columns.Add("角色名称", typeof(String));
                    data.Columns.Add("角色描述", typeof(String));
                    data.Columns.Add("状态", typeof(String));
                    for (var i = 0; i < GridRoles.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["角色标识"] = GridRoles[i].RoleID.ToString().ToUpper();
                        dr["角色名称"] = GridRoles[i].RoleName;
                        dr["角色描述"] = GridRoles[i].Comment;
                        dr["状态"] = GridRoles[i].Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "角色信息", "智能门禁管理系统 系统角色报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.ExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Opening Event.
        /// </summary>
        private void OperationContext_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = RoleGridView.SelectedRows.Count > 0;
                OpMenuItem2.Enabled = RoleGridView.Rows.Count > 0;
                OpMenuItem3.Enabled = GridRoles.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.OperationContext.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Selected Roles.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (RoleGridView.SelectedRows.Count > 0) {
                    var dRoles = new List<RoleInfo>();
                    foreach (DataGridViewRow row in RoleGridView.SelectedRows) {
                        var key = (Guid)row.Cells["GuidColumn"].Value;
                        var obj = GridRoles.Find(r => r.RoleID == key);
                        if (obj != null) { dRoles.Add(obj); }
                    }

                    if (dRoles.Count > 0) {
                        var adRoles = new Dictionary<Guid, RoleInfo>();
                        foreach (var dr in dRoles) {
                            if (MemberShipEntity.RoleUserExists(dr.RoleID)) {
                                MessageBox.Show(String.Format("角色[{0}]下存在用户，无法执行删除操作。", dr.RoleName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            adRoles[dr.RoleID] = dr;

                            var SubRoles = new List<RoleInfo>();
                            FindSubRolesRecursion(dr.RoleID, SubRoles);
                            foreach (var sr in SubRoles) {
                                if (MemberShipEntity.RoleUserExists(sr.RoleID)) {
                                    MessageBox.Show(String.Format("角色[{0}]的子角色[{1}]下存在用户，无法执行删除操作。", dr.RoleName, sr.RoleName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                adRoles[sr.RoleID] = sr;
                            }
                        }

                        if (MessageBox.Show("选中角色及其子角色将被删除，您确定要删除吗?", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                MemberShipEntity.DelRoles(adRoles.Select(dr => dr.Value.RoleID).ToList());
                            }, default(string), "正在删除，请稍后...", default(int), default(int));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var adr in adRoles) {
                                    Roles.Remove(adr.Value);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.RoleManagerForm.OpMenuItem1.Click", String.Format("删除角色:[{0}]", adr.Value.RoleName), null);
                                }

                                BindRolesToTreeView();
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RoleManagerForm.OpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Roles.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            DeleteBtn_Click(sender, e);
        }

        /// <summary>
        /// Save All Roles To Excel.
        /// </summary>
        private void OpMenuItem3_Click(object sender, EventArgs e) {
            ExportBtn_Click(sender, e);
        }

        /// <summary>
        /// Bind Roles To TreeView.
        /// </summary>
        private void BindRolesToTreeView() {
            RoleTreeView.Nodes.Clear();
            var root = RoleTreeView.Nodes.Add(Common.CurUser.Role.RoleID.ToString(), Common.CurUser.Role.RoleName);
            root.Tag = Common.CurUser.Role.RoleID;

            BindRolesRecursion(root, Common.CurUser.Role.RoleID);
            RoleTreeView.SelectedNode = root;
            RoleTreeView.ExpandAll();
        }

        /// <summary>
        /// Bind Roles Recursion.
        /// </summary>
        private void BindRolesRecursion(TreeNode pNode, Guid pId) {
            if (Roles != null && Roles.Count > 0) {
                var srs = Roles.FindAll(d => d.LastRoleID == pId);
                if (srs.Count > 0) {
                    foreach (var r in srs) {
                        var tnode = pNode.Nodes.Add(r.RoleID.ToString(), r.RoleName);
                        tnode.Tag = r.RoleID;
                        BindRolesRecursion(tnode, r.RoleID);
                    }
                }
            }
        }

        /// <summary>
        /// Find SubRoles Recursion.
        /// </summary>
        private void FindSubRolesRecursion(Guid pId,List<RoleInfo> sRoles) {
            var srs = Roles.FindAll(d => d.LastRoleID == pId);
            if (srs.Count > 0) {
                foreach (var r in srs) {
                    sRoles.Add(r);
                    FindSubRolesRecursion(r.RoleID, sRoles);
                }
            }
        }

        /// <summary>
        /// Bind Roles To GridView.
        /// </summary>
        private void BindRolesToGridView() {
            RoleGridView.Rows.Clear();
            RoleGridView.RowCount = GridRoles.Count;
        }
    }
}