using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLiteDAL;

namespace Delta.MPS.AccessSystem
{
    public partial class RegisterForm : Form
    {
        /// <summary>
        /// Class Constructor
        /// </summary>
        public RegisterForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Form loaded.
        /// </summary>
        private void RegisterForm_Load(object sender, EventArgs e) {
            try {
                machineCode.Text = Common.CurApplication.UniqueID.ToString("N").ToUpper();
                if (Common.LicenseStatus == EnmLicenseStatus.Licensed) {
                    if (Common.CurLicense.Expiration.Equals(DateTime.MaxValue)) {
                        licenseLbl.Text = "本软件已注册，永不过期。";
                    } else if (Common.CurLicense.Expiration.Subtract(Common.CurApplication.AppLastTime).Days <= 30) {
                        licenseLbl.Text = String.Format("本软件已注册，离有效期结束还有{0}天。", Common.CurLicense.Expiration.Subtract(Common.CurApplication.AppLastTime).Days);
                    } else {
                        licenseLbl.Text = String.Format("本软件已注册，有效期至{0:yyyy/MM/dd}。", Common.CurLicense.Expiration);
                    }
                } else if (Common.LicenseStatus == EnmLicenseStatus.Expired) {
                    licenseLbl.Text = String.Format("本软件已于{0:yyyy/MM/dd}到期，请重新注册。", Common.CurLicense.Expiration);
                } else if (Common.LicenseStatus == EnmLicenseStatus.Evaluation) {
                    licenseLbl.Text = String.Format("本软件为试用版，离试用期结束还有{0}天。", Common.CurApplication.AppFirstTime.AddDays(30).Subtract(Common.CurApplication.AppLastTime).Days);
                } else {
                    licenseLbl.Text = "本软件试用期已到，请注册后使用。";
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RegisterForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Register software.
        /// </summary>
        private void okBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(registerCode.Text)) {
                    registerCode.Focus();
                    MessageBox.Show("注册码不能为空，请输入注册码。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lcode = registerCode.Text.Trim();
                Common.CheckLicense(lcode);
                if (Common.LicenseStatus == EnmLicenseStatus.Licensed) {
                    Common.CurApplication.AppLicense = lcode;
                    var registryEntity = new RegistryDatabase();
                    registryEntity.SaveSystemApplication(Common.CurApplication);

                    var sb = new StringBuilder();
                    sb.AppendLine("软件注册成功！");
                    sb.AppendLine();
                    sb.AppendFormat("用户: {0}{1}", Common.CurLicense.Name, Environment.NewLine);
                    sb.AppendFormat("公司: {0}{1}", Common.CurLicense.Company, Environment.NewLine);
                    sb.AppendFormat("Email: {0}{1}", Common.CurLicense.Email, Environment.NewLine);
                    sb.AppendFormat("有效期: {0}", new DateTime(2099, 12, 31).Equals(Common.CurLicense.Expiration) ? "永不过期" : Common.GetDateString(Common.CurLicense.Expiration));

                    Common.WriteLog(DateTime.Now, EnmMsgType.Warning, "System", "Delta.MPS.AccessSystem.RegisterForm", sb.ToString().Replace(Environment.NewLine, " "), null);
                    MessageBox.Show(sb.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                } else if (Common.LicenseStatus == EnmLicenseStatus.Expired) {
                    MessageBox.Show("注册码已过期，注册失败。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    MessageBox.Show("无效的注册码，注册失败。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RegisterForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Copy machine code to clipboard.
        /// </summary>
        private void copyBtn_Click(object sender, EventArgs e) {
            try {
                Clipboard.SetDataObject(machineCode.Text, true);
                MessageBox.Show("机器码已复制到剪贴板", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RegisterForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export register file.
        /// </summary>
        private void exportBtn_Click(object sender, EventArgs e) {
            try {
                if (registerFileDialog.ShowDialog() == DialogResult.OK) {
                    var lcode = File.ReadAllText(registerFileDialog.FileName);
                    if (String.IsNullOrWhiteSpace(lcode)) {
                        registerCode.Clear();
                        MessageBox.Show("注册码不能为空，请输入注册码。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    registerCode.Text = lcode;
                    Common.CheckLicense(lcode);
                    if (Common.LicenseStatus == EnmLicenseStatus.Licensed) {
                        Common.CurApplication.AppLicense = lcode;
                        var registryEntity = new RegistryDatabase();
                        registryEntity.SaveSystemApplication(Common.CurApplication);

                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("软件注册成功！");
                        sb.AppendLine();
                        sb.AppendFormat("用户: {0}{1}", Common.CurLicense.Name, Environment.NewLine);
                        sb.AppendFormat("公司: {0}{1}", Common.CurLicense.Company, Environment.NewLine);
                        sb.AppendFormat("Email: {0}{1}", Common.CurLicense.Email, Environment.NewLine);
                        sb.AppendFormat("有效期: {0}", new DateTime(2099, 12, 31).Equals(Common.CurLicense.Expiration) ? "永不过期" : Common.GetDateString(Common.CurLicense.Expiration));

                        Common.WriteLog(DateTime.Now, EnmMsgType.Warning, "System", "Delta.MPS.AccessSystem.RegisterForm", sb.ToString().Replace(Environment.NewLine, " "), null);
                        MessageBox.Show(sb.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    } else if (Common.LicenseStatus == EnmLicenseStatus.Expired) {
                        MessageBox.Show("注册码已过期，注册失败。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        MessageBox.Show("无效的注册码，注册失败。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.RegisterForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Machine code changed.
        /// </summary>
        private void machineCode_TextChanged(object sender, EventArgs e) {
            registerCode.Clear();
            copyBtn.Enabled = !String.IsNullOrWhiteSpace(machineCode.Text);
        }
    }
}