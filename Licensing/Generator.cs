using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.Security.Cryptography;
using System.IO;

namespace Licensing
{
    public partial class Generator : Form
    {
        /// <summary>
        /// Class Constructor
        /// </summary>
        public Generator() {
            InitializeComponent();
        }

        /// <summary>
        /// Form loaded.
        /// </summary>
        private void Generator_Load(object sender, EventArgs e) {
            periodTime.Value = DateTime.Today.AddMonths(3);
        }

        /// <summary>
        /// Generate register code.
        /// </summary>
        private void generateBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(userName.Text)) {
                    userName.Focus();
                    MessageBox.Show("用户名称不能为空。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(companyName.Text)) {
                    companyName.Focus();
                    MessageBox.Show("公司名称不能为空。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(email.Text)) {
                    email.Focus();
                    MessageBox.Show("Email不能为空。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(email.Text.Trim(), @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$")) {
                    userName.Focus();
                    MessageBox.Show("Email格式错误。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(machineCode.Text)) {
                    machineCode.Focus();
                    MessageBox.Show("机器码不能为空。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(machineCode.Text.Trim(), @"^[a-fA-F0-9]{32}$")) {
                    machineCode.Focus();
                    MessageBox.Show("机器码格式错误。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                authCode.Text = this.GetAuthCode();
            } catch (Exception err) {
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Create register file.
        /// </summary>
        private void createFileBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(userName.Text)) {
                    userName.Focus();
                    MessageBox.Show("用户名称不能为空。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(companyName.Text)) {
                    companyName.Focus();
                    MessageBox.Show("公司名称不能为空。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(email.Text)) {
                    email.Focus();
                    MessageBox.Show("Email不能为空。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(email.Text.Trim(), @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$")) {
                    userName.Focus();
                    MessageBox.Show("Email格式错误。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(machineCode.Text)) {
                    machineCode.Focus();
                    MessageBox.Show("机器码不能为空。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(machineCode.Text.Trim(), @"^[a-fA-F0-9]{32}$")) {
                    machineCode.Focus();
                    MessageBox.Show("机器码格式错误。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                authCode.Text = this.GetAuthCode();
                if (authFileDialog.ShowDialog() == DialogResult.OK) {
                    var regFile = new FileInfo(authFileDialog.FileName);
                    using (var sw = regFile.CreateText()) {
                        sw.WriteLine(authCode.Text.Trim());
                        sw.Close();
                    }
                    MessageBox.Show("授权文件导出成功。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Copy register code to clipboard.
        /// </summary>
        private void copyBtn_Click(object sender, EventArgs e) {
            try {
                if (!String.IsNullOrEmpty(authCode.Text.Trim())) {
                    Clipboard.SetDataObject(authCode.Text.Trim(), true);
                    MessageBox.Show("注册码已复制到剪贴板。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("您还未生成注册码！", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Text changed.
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e) {
            authCode.Clear();
        }

        /// <summary>
        /// Value changed.
        /// </summary>
        private void DateTime_ValueChanged(object sender, EventArgs e) {
            authCode.Clear();
        }

        /// <summary>
        /// Checked changed.
        /// </summary>
        private void neverTimeCK_CheckedChanged(object sender, EventArgs e) {
            authCode.Clear();
            periodTime.Enabled = !neverTimeCK.Checked;
        }

        /// <summary>
        /// Register code changed.
        /// </summary>
        private void authCode_TextChanged(object sender, EventArgs e) {
            copyBtn.Enabled = !String.IsNullOrWhiteSpace(authCode.Text);
        }

        /// <summary>
        /// Get Register Code.
        /// </summary>
        /// <returns>Register Code</returns>
        private String GetAuthCode() {
            var text = String.Format("{0}┋{1}┋{2}┋{3}", userName.Text.Trim().Replace("┋", "|"), companyName.Text.Trim().Replace("┋", "|"), email.Text.Trim().Replace("┋", "|"), neverTimeCK.Checked ? new DateTime(2099, 12, 31).Ticks : periodTime.Value.Ticks);
            var keys = machineCode.Text.Trim().ToUpper().ToCharArray().Reverse().ToArray();
            var aesKey = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", keys[3], keys[6], keys[9], keys[12], keys[13], keys[16], keys[19], keys[25], keys[29], keys[31], keys[7], keys[16], keys[12], keys[20], keys[2], keys[3]);
            var aesIV = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", keys[5], keys[8], keys[10], keys[14], keys[20], keys[21], keys[24], keys[25], keys[29], keys[30], keys[2], keys[5], keys[6], keys[17], keys[22], keys[10]);
            return this.Encrypt(text, aesKey, aesIV);
        }

        /// <summary>
        /// AES Encryption
        /// </summary>
        private String Encrypt(String text, String aesKey, String aesIV) {
            // AesCryptoServiceProvider
            var aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes(aesIV);
            aes.Key = Encoding.UTF8.GetBytes(aesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert string to byte array
            byte[] src = Encoding.Unicode.GetBytes(text);

            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor()) {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // Convert byte array to Base64 strings
                return Convert.ToBase64String(dest);
            }
        }

        /// <summary>
        /// AES Decryption
        /// </summary>
        private String Decrypt(String text, String aesKey, String aesIV) {
            // AesCryptoServiceProvider
            var aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = Encoding.UTF8.GetBytes(aesIV);
            aes.Key = Encoding.UTF8.GetBytes(aesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert Base64 strings to byte array
            byte[] src = System.Convert.FromBase64String(text);

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor()) {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }

        /// <summary>
        /// Format datetime string.
        /// </summary>
        /// <param name="dt">datetime</param>
        /// <returns>datetime format string</returns>
        private string DateTimeFormat(DateTime dt) {
            return DateTimeFormat(dt, null);
        }

        /// <summary>
        /// Format datetime string.
        /// </summary>
        /// <param name="dt">datetime</param>
        /// <param name="format">format</param>
        /// <returns>datetime format string</returns>
        private string DateTimeFormat(DateTime dt,string format) {
            if (String.IsNullOrWhiteSpace(format)) { return dt.ToString("yyyy/MM/dd HH:mm:ss"); }
            return dt.ToString(format);
        }
    }
}
