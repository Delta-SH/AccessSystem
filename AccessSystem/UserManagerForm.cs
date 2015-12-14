using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLServerDAL;

namespace Delta.MPS.AccessSystem
{
    public partial class UserManagerForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private MemberShip MemberShipEntity;
        private List<RoleInfo> Roles;
        private List<UserInfo> Users;
        private List<UserInfo> GridUsers;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public UserManagerForm() {
            InitializeComponent();
            MemberShipEntity = new MemberShip();
            Roles = new List<RoleInfo>();
            Users = new List<UserInfo>();
            GridUsers = new List<UserInfo>();
            if (!Common.IsCheckFailedPasswordAttemptCount) {
                LockedOutColumn.Visible = false;
                IsLockedOutColumn.Visible = false;
                LastLockoutDateColumn.Visible = false;
            }
        }

        /// <summary>
        /// Form Loaded.
        /// </summary>
        private void UserManagerForm_Load(object sender, EventArgs e) {
            try {
                Users = MemberShipEntity.GetUsers(Common.CurUser.Role.RoleID);
                BindRolesToTreeView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Role TreeView AfterSelect Event.
        /// </summary>
        private void RoleTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                BindUsersToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.RoleTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sub Users Checked Changed Event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubUsersCB_CheckedChanged(object sender, EventArgs e) {
            try {
                BindUsersToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.SubUsersCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// User GridView CellValue Needed Event. 
        /// </summary>
        private void UserGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > GridUsers.Count - 1) { return; }
                switch (UserGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "LockedOutColumn":
                        e.Value = GridUsers[e.RowIndex].IsLockedOut ? "解锁" : String.Empty;
                        break;
                    case "UIDColumn":
                        e.Value = GridUsers[e.RowIndex].UserID;
                        break;
                    case "NameColumn":
                        e.Value = GridUsers[e.RowIndex].UserName;
                        break;
                    case "RoleNameColumn":
                        e.Value = GridUsers[e.RowIndex].Role.RoleName;
                        break;
                    case "RemarkNameColumn":
                        e.Value = GridUsers[e.RowIndex].RemarkName;
                        break;
                    case "CommentColumn":
                        e.Value = GridUsers[e.RowIndex].Comment;
                        break;
                    case "MobilePhoneColumn":
                        e.Value = GridUsers[e.RowIndex].MobilePhone;
                        break;
                    case "EmailColumn":
                        e.Value = GridUsers[e.RowIndex].Email;
                        break;
                    case "CreateDateColumn":
                        e.Value = Common.GetDateTimeString(GridUsers[e.RowIndex].CreateDate);
                        break;
                    case "LimitDateColumn":
                        if (GridUsers[e.RowIndex].LimitDate < DateTime.Today) {
                            e.Value = String.Format("{0}({1})", Common.GetDateString(GridUsers[e.RowIndex].LimitDate),"已过期");
                            UserGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                        } else if (GridUsers[e.RowIndex].LimitDate.Equals(new DateTime(2099, 12, 31))) {
                            e.Value = "永不过期";
                        } else {
                            e.Value = Common.GetDateString(GridUsers[e.RowIndex].LimitDate);
                        }
                        break;
                    case "LastLoginDateColumn":
                        e.Value = Common.GetDateTimeString(GridUsers[e.RowIndex].LastLoginDate);
                        break;
                    case "LastPasswordChangedDateColumn":
                        e.Value = Common.GetDateTimeString(GridUsers[e.RowIndex].LastPasswordChangedDate);
                        break;
                    case "IsLockedOutColumn":
                        e.Value = GridUsers[e.RowIndex].IsLockedOut ? "锁定" : "正常";
                        break;
                    case "LastLockoutDateColumn":
                        e.Value = Common.GetDateTimeString(GridUsers[e.RowIndex].LastLockoutDate);
                        break;
                    case "EnableColumn":
                        e.Value = GridUsers[e.RowIndex].Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.UserGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// User GridView CellContent Click Event.
        /// </summary>
        private void UserGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key = (Guid)UserGridView.Rows[e.RowIndex].Cells["UIDColumn"].Value;
                var obj = GridUsers.Find(r => r.UserID == key);
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (UserGridView.Columns[e.ColumnIndex].Name) {
                    case "DeleteColumn":
                        if (key == Common.CurUser.UserID) {
                            MessageBox.Show("禁止删除当前用户", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (MessageBox.Show(String.Format("用户[{0}]将被删除，您确定要删除吗？",obj.UserName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                MemberShipEntity.DeleteUsers(new List<Guid> { obj.UserID });
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                Users.Remove(obj);
                                GridUsers.Remove(obj);
                                UserGridView.Rows.RemoveAt(e.RowIndex);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.UserManagerForm.UserGridView.CellContentClick", String.Format("删除用户:[{0}]", obj.UserName), null);
                            }
                        }
                        break;
                    case "EditColumn":
                        if (new SaveUserForm(EnmSaveBehavior.Edit, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            UserGridView.InvalidateRow(e.RowIndex);
                        }
                        break;
                    case "LockedOutColumn":
                        if (obj.IsLockedOut && MessageBox.Show(String.Format("您确定要对用户[{0}]解锁吗？", obj.UserName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            obj.FailedPasswordAttemptCount = 0;
                            obj.IsLockedOut = false;
                            MemberShipEntity.UpdateUser(obj);
                            UserGridView.InvalidateRow(e.RowIndex);
                            Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.UserManagerForm.UserGridView.CellContentClick", String.Format("解锁用户:[{0}]", obj.UserName), null);
                            MessageBox.Show("已解锁完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.UserGridView.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add user.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                var obj = new UserInfo() {
                    Role = new RoleInfo() { RoleID = RoleTreeView.SelectedNode != null ? (Guid)RoleTreeView.SelectedNode.Tag : Common.CurUser.Role.RoleID },
                    UserID = Guid.NewGuid(),
                    UserName = String.Empty,
                    RemarkName = String.Empty,
                    Password = String.Empty,
                    PasswordFormat = EnmPasswordFormat.Hashed,
                    PasswordSalt = MemberShipEntity.GenerateSalt(),
                    MobilePhone = String.Empty,
                    Email = String.Empty,
                    CreateDate = DateTime.Now,
                    LimitDate = new DateTime(2099, 12, 31),
                    LastLoginDate = ComUtility.DefaultDateTime,
                    LastPasswordChangedDate = ComUtility.DefaultDateTime,
                    FailedPasswordAttemptCount = 0,
                    IsLockedOut = false,
                    LastLockoutDate = ComUtility.DefaultDateTime,
                    Comment = String.Empty,
                    Enabled = true
                };

                if (new SaveUserForm(EnmSaveBehavior.Add, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    Users.Add(obj);
                    BindUsersToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Users.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                var dUsers = GridUsers.FindAll(u => u.UserID != Common.CurUser.UserID);
                if (dUsers.Count > 0) {
                    if (MessageBox.Show("您确定要全部删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            MemberShipEntity.DeleteUsers(dUsers.Select(u => u.UserID).ToList());
                        }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var du in dUsers) {
                                Users.Remove(du);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.UserManagerForm.DeleteBtn.Click", String.Format("删除用户:[{0}]", du.UserName), null);
                            }

                            BindUsersToGridView();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export users to excel.
        /// </summary>
        private void ExportBtn_Click(object sender, EventArgs e) {
            try {
                if (GridUsers.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("用户标识", typeof(String));
                    data.Columns.Add("用户名称", typeof(String));
                    data.Columns.Add("备注名称", typeof(String));
                    data.Columns.Add("用户描述", typeof(String));
                    data.Columns.Add("所属角色", typeof(String));
                    data.Columns.Add("手机", typeof(String));
                    data.Columns.Add("Email", typeof(String));
                    data.Columns.Add("创建时间", typeof(String));
                    data.Columns.Add("有效日期", typeof(String));
                    data.Columns.Add("最后登录时间", typeof(String));
                    data.Columns.Add("修改密码时间", typeof(String));
                    if (Common.IsCheckFailedPasswordAttemptCount) {
                        data.Columns.Add("锁定状态", typeof(String));
                        data.Columns.Add("锁定时间", typeof(String));
                    }
                    data.Columns.Add("状态", typeof(String));

                    for (var i = 0; i < GridUsers.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["用户标识"] = GridUsers[i].UserID.ToString().ToUpper();
                        dr["用户名称"] = GridUsers[i].UserName;
                        dr["备注名称"] = GridUsers[i].RemarkName;
                        dr["用户描述"] = GridUsers[i].Comment;
                        dr["所属角色"] = GridUsers[i].Role.RoleName;
                        dr["手机"] = GridUsers[i].MobilePhone;
                        dr["Email"] = GridUsers[i].Email;
                        dr["创建时间"] = Common.GetDateTimeString(GridUsers[i].CreateDate);
                        dr["有效日期"] = GridUsers[i].LimitDate.Equals(new DateTime(2099, 12, 31)) ? "永不过期" : Common.GetDateString(GridUsers[i].LimitDate);
                        dr["最后登录时间"] = Common.GetDateTimeString(GridUsers[i].LastLoginDate);
                        dr["修改密码时间"] = Common.GetDateTimeString(GridUsers[i].LastPasswordChangedDate);
                        if (Common.IsCheckFailedPasswordAttemptCount) {
                            dr["锁定状态"] = GridUsers[i].IsLockedOut ? "锁定" : "正常";
                            dr["锁定时间"] = Common.GetDateTimeString(GridUsers[i].LastLockoutDate);
                        }
                        dr["状态"] = GridUsers[i].Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "用户信息", "智能门禁管理系统 系统用户报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Opening Event.
        /// </summary>
        private void OperationContext_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = UserGridView.SelectedRows.Count > 0;
                OpMenuItem2.Enabled = UserGridView.Rows.Count > 0;
                OpMenuItem3.Enabled = GridUsers.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.OperationContext.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Selected Users.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (UserGridView.SelectedRows.Count > 0) {
                    var dUsers = new Dictionary<Int32, UserInfo>();
                    foreach (DataGridViewRow row in UserGridView.SelectedRows) {
                        var key = (Guid)row.Cells["UIDColumn"].Value;
                        var obj = GridUsers.Find(r => r.UserID == key);
                        if (obj != null && obj.UserID != Common.CurUser.UserID) { dUsers[row.Index] = obj; }
                    }

                    if (dUsers.Count > 0) {
                        if (MessageBox.Show("选中用户将被删除，您确定要删除吗?", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                MemberShipEntity.DeleteUsers(dUsers.Select(dr => dr.Value.UserID).ToList());
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var du in dUsers) {
                                    Users.Remove(du.Value);
                                    GridUsers.Remove(du.Value);
                                    UserGridView.Rows.RemoveAt(du.Key);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.UserManagerForm.OpMenuItem1.Click", String.Format("删除用户:[{0}]", du.Value.UserName), null);
                                }
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.UserManagerForm.OpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Users.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            DeleteBtn_Click(sender, e);
        }

        /// <summary>
        /// Save All Users To Excel.
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

            Roles = MemberShipEntity.GetSubRoles(Common.CurUser.Role.RoleID);
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
        private void FindSubRolesRecursion(Guid pId, List<RoleInfo> sRoles) {
            var srs = Roles.FindAll(d => d.LastRoleID == pId);
            if (srs.Count > 0) {
                foreach (var r in srs) {
                    sRoles.Add(r);
                    FindSubRolesRecursion(r.RoleID, sRoles);
                }
            }
        }

        /// <summary>
        /// Bind Users To GridView.
        /// </summary>
        private void BindUsersToGridView() {
            GridUsers.Clear();
            UserGridView.Rows.Clear();
            if (RoleTreeView.SelectedNode != null) {
                var rId = (Guid)RoleTreeView.SelectedNode.Tag;
                GridUsers.AddRange(Users.FindAll(u => u.Role.RoleID == rId));
                if (SubUsersCB.Checked) {
                    var SubRoles = new List<RoleInfo>();
                    FindSubRolesRecursion(rId, SubRoles);
                    foreach (var sr in SubRoles) {
                        GridUsers.AddRange(Users.FindAll(u => u.Role.RoleID == sr.RoleID));
                    }
                }
            }

            UserGridView.RowCount = GridUsers.Count;
        }
    }
}