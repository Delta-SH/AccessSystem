using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLServerDAL;

namespace Delta.MPS.AccessSystem
{
    public partial class SaveUserForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private EnmSaveBehavior CurBehavior = EnmSaveBehavior.Null;
        private MemberShip MemberShipEntity;
        private UserInfo CurUser;
        private UserInfo OriUser;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveUserForm(EnmSaveBehavior Behavior, UserInfo User) {
            InitializeComponent();
            MemberShipEntity = new MemberShip();
            CurBehavior = Behavior;
            CurUser = new UserInfo();
            OriUser = User;
            Common.CopyObjectValues(OriUser, CurUser);
            Text = Behavior == EnmSaveBehavior.Add ? "新增用户信息" : "编辑用户信息";
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void SaveUserForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                if (CurBehavior == EnmSaveBehavior.Null || CurUser == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                if (CurBehavior == EnmSaveBehavior.Edit) {
                    UserNameTB.ReadOnly = true;
                    UserPasswordLbl.Visible = false;
                    UserPasswordCB.Visible = true;
                    UserPasswordCB.Checked = false;
                    UserPasswordTB.Enabled = false;
                    UserCPasswordTB.Enabled = false;
                } else if (CurBehavior == EnmSaveBehavior.Add) {
                    UserNameTB.ReadOnly = false;
                    UserPasswordLbl.Visible = true;
                    UserPasswordCB.Visible = false;
                }
                
                BindRolesToCombobox(CurUser.Role.RoleID);
                UserIDTB.Text = CurUser.UserID.ToString().ToUpper();
                UserNameTB.Text = CurUser.UserName;
                UserRemarkNameTB.Text = CurUser.RemarkName;
                UserMobileTB.Text = CurUser.MobilePhone;
                UserEmailTB.Text = CurUser.Email;
                UserCommentTB.Text = CurUser.Comment;
                UserStatusCB.Checked = CurUser.Enabled;
                if (CurUser.LimitDate == new DateTime(2099, 12, 31)) {
                    UserLimitDTP.Value = DateTime.Today;
                    UserLimitDTP.Enabled = false;
                    NeverCB.Checked = true;
                } else {
                    UserLimitDTP.Value = CurUser.LimitDate;
                    UserLimitDTP.Enabled = true;
                    NeverCB.Checked = false;
                }
                SaveBtn.Enabled = true;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveUserForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reset Password Checked Changed Event.
        /// </summary>
        private void UserPasswordCB_CheckedChanged(object sender, EventArgs e) {
            try {
                UserPasswordTB.Enabled = UserCPasswordTB.Enabled = UserPasswordCB.Checked;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveUserForm.UserPasswordCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Never Expires Checked Changed Event.
        /// </summary>
        private void NeverCB_CheckedChanged(object sender, EventArgs e) {
            try {
                UserLimitDTP.Enabled = !NeverCB.Checked;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveUserForm.NeverCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save User.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(UserNameTB.Text)) {
                    UserNameTB.Focus();
                    MessageBox.Show("用户名不能为空", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var UserName = UserNameTB.Text.Trim();
                if (CurBehavior == EnmSaveBehavior.Add || (CurBehavior == EnmSaveBehavior.Edit && !CurUser.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase))) {
                    if (MemberShipEntity.UserExists(UserName)) {
                        UserNameTB.Focus();
                        MessageBox.Show("用户名已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (CurBehavior == EnmSaveBehavior.Add || (CurBehavior == EnmSaveBehavior.Edit && UserPasswordCB.Checked)) {
                    if (String.IsNullOrWhiteSpace(UserPasswordTB.Text)) {
                        UserPasswordTB.Focus();
                        MessageBox.Show("密码不能为空", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!UserPasswordTB.Text.Equals(UserCPasswordTB.Text)) {
                        UserPasswordTB.Focus();
                        MessageBox.Show("两次输入密码不一致", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (!String.IsNullOrWhiteSpace(UserMobileTB.Text) && UserMobileTB.Text.Trim().Length != 11) {
                    UserMobileTB.Focus();
                    MessageBox.Show("请输入正确的手机号码", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!String.IsNullOrWhiteSpace(UserEmailTB.Text) && !Regex.IsMatch(UserEmailTB.Text.Trim(), @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$", RegexOptions.IgnoreCase)) {
                    UserEmailTB.Focus();
                    MessageBox.Show("请输入正确的Email", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!NeverCB.Checked && UserLimitDTP.Value <= DateTime.Now) {
                    UserLimitDTP.Focus();
                    MessageBox.Show("用户有效日期无效，请选择大于当前时间的有效日期。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CurBehavior == EnmSaveBehavior.Add) {
                    CurUser.Role.RoleID = (Guid)UserRoleCB.SelectedValue;
                    CurUser.Role.RoleName = UserRoleCB.Text;
                    CurUser.UserName = UserNameTB.Text.Trim();
                    CurUser.RemarkName = UserRemarkNameTB.Text.Trim();
                    CurUser.Password = MemberShipEntity.EncodePassword(UserPasswordTB.Text.Trim(), CurUser.PasswordFormat, CurUser.PasswordSalt);
                    CurUser.MobilePhone = UserMobileTB.Text.Trim();
                    CurUser.Email = UserEmailTB.Text.Trim();
                    CurUser.CreateDate = DateTime.Now;
                    CurUser.LimitDate = NeverCB.Checked ? new DateTime(2099, 12, 31) : UserLimitDTP.Value;
                    CurUser.LastLoginDate = ComUtility.DefaultDateTime;
                    CurUser.LastPasswordChangedDate = ComUtility.DefaultDateTime;
                    CurUser.FailedPasswordAttemptCount = 0;
                    CurUser.IsLockedOut = false;
                    CurUser.LastLockoutDate = ComUtility.DefaultDateTime;
                    CurUser.Comment = UserCommentTB.Text.Trim();
                    CurUser.Enabled = UserStatusCB.Checked;

                    var result = Common.ShowWait(() => {
                        MemberShipEntity.CreateUser(CurUser);
                    }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                    if (result == DialogResult.OK) {
                        Common.CopyObjectValues(CurUser, OriUser);
                        Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveUserForm.SaveBtn.Click", String.Format("新增用户:[{0}]", CurUser.UserName), null);
                        MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    } else {
                        MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else if (CurBehavior == EnmSaveBehavior.Edit) {
                    var IsChangePwd = UserPasswordCB.Checked;
                    if (!IsChangePwd || MessageBox.Show("您确定要重置用户密码吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        CurUser.Role.RoleID = (Guid)UserRoleCB.SelectedValue;
                        CurUser.Role.RoleName = UserRoleCB.Text;
                        CurUser.UserName = UserNameTB.Text.Trim();
                        CurUser.RemarkName = UserRemarkNameTB.Text.Trim();
                        if (IsChangePwd) {
                            CurUser.PasswordFormat = EnmPasswordFormat.Hashed;
                            CurUser.PasswordSalt = MemberShipEntity.GenerateSalt();
                            CurUser.Password = MemberShipEntity.EncodePassword(UserPasswordTB.Text.Trim(), CurUser.PasswordFormat, CurUser.PasswordSalt);
                            CurUser.LastPasswordChangedDate = DateTime.Now;
                        }
                        CurUser.MobilePhone = UserMobileTB.Text.Trim();
                        CurUser.Email = UserEmailTB.Text.Trim();
                        CurUser.LimitDate = NeverCB.Checked ? new DateTime(2099, 12, 31) : UserLimitDTP.Value;
                        CurUser.Comment = UserCommentTB.Text.Trim();
                        CurUser.Enabled = UserStatusCB.Checked;

                        var result = Common.ShowWait(() => {
                            MemberShipEntity.SaveUser(CurUser);
                            if (IsChangePwd) { MemberShipEntity.ChangePassword(CurUser); }
                        }, default(string), "正在保存，请稍后...", default(int), default(int));

                        if (result == DialogResult.OK) {
                            Common.CopyObjectValues(CurUser, OriUser);
                            Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveUserForm.SaveBtn.Click", String.Format("更新用户:[{0}]", CurUser.UserName), null);
                            MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = System.Windows.Forms.DialogResult.OK;
                        } else {
                            MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveUserForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Roles To Combobox.
        /// </summary>
        private void BindRolesToCombobox(Guid _SelectedValue) {
            var data = new List<object>();
            data.Add(new {
                ID = Common.CurUser.Role.RoleID,
                Name = Common.CurUser.Role.RoleName
            });

            var SelectedValue = Common.CurUser.Role.RoleID;
            var Roles = MemberShipEntity.GetSubRoles(Common.CurUser.Role.RoleID);
            if (Roles.Count > 0) {
                foreach (var R in Roles) {
                    data.Add(new {
                        ID = R.RoleID,
                        Name = R.RoleName
                    });

                    if (R.RoleID.Equals(_SelectedValue)) { SelectedValue = R.RoleID; }
                }
            }

            UserRoleCB.ValueMember = "ID";
            UserRoleCB.DisplayMember = "Name";
            UserRoleCB.DataSource = data;
            UserRoleCB.SelectedValue = SelectedValue;
        }
    }
}