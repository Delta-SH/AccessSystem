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
    public partial class ChangePasswordForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private MemberShip MemberShipEntity;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public ChangePasswordForm() {
            InitializeComponent();
            MemberShipEntity = new MemberShip();
        }

        /// <summary>
        /// Change User Password.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(OriginalPasswordTB.Text)) {
                    OriginalPasswordTB.Focus();
                    MessageBox.Show("原密码不能为空", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(NewPasswordTB.Text)) {
                    NewPasswordTB.Focus();
                    MessageBox.Show("新密码不能为空", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!NewPasswordTB.Text.Equals(NewCPasswordTB.Text)) {
                    NewPasswordTB.Focus();
                    MessageBox.Show("两次输入密码不一致", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!MemberShipEntity.CheckPassword(Common.CurUser.Password, OriginalPasswordTB.Text, Common.CurUser.PasswordFormat, Common.CurUser.PasswordSalt)) {
                    OriginalPasswordTB.Focus();
                    MessageBox.Show("原密码输入错误", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var User = new UserInfo() {
                    UserID = Common.CurUser.UserID,
                    UserName = Common.CurUser.UserName,
                    PasswordFormat = Common.CurUser.PasswordFormat,
                    PasswordSalt = MemberShipEntity.GenerateSalt(),
                    Password = NewPasswordTB.Text.Trim(),
                    LastPasswordChangedDate = DateTime.Now
                };

                User.Password = MemberShipEntity.EncodePassword(User.Password, User.PasswordFormat, User.PasswordSalt);
                MemberShipEntity.ChangePassword(User);

                Common.CurUser.Password = User.Password;
                Common.CurUser.PasswordSalt = User.PasswordSalt;
                Common.CurUser.LastPasswordChangedDate = User.LastPasswordChangedDate;
                MessageBox.Show("密码修改完成,下次登录请使用新密码。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.ChangePasswordForm.SaveBtn.Click", String.Format("用户[{0}]修改密码", User.UserName), null);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ChangePasswordForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
