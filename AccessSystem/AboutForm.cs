using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Windows.Forms;
using Delta.MPS.Model;

namespace Delta.MPS.AccessSystem
{
    public partial class AboutForm : Form
    {
        public AboutForm() {
            InitializeComponent();
            this.Text = "关于 - 智能门禁管理系统";
            this.productNameLbl.Text = "智能门禁管理系统";
            this.versionLbl.Text = String.Format("版本 {0}", ConfigurationManager.AppSettings["Version"]);
            this.companyNameLbl.Text = "Delta GreenTech(China) Co., Ltd.";
            this.copyrightLbl.Text = "All Rights Reserved ©2013";
            registerLbl.Visible = Common.IsCheckLicense;
        }

        private void registerLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                if (!Common.IsCheckLicense) { return; }
                if (Common.LicenseStatus == EnmLicenseStatus.Licensed) {
                    var sb = new StringBuilder();
                    sb.AppendLine("软件授权信息");
                    sb.AppendLine();
                    sb.AppendFormat("用户: {0}{1}", Common.CurLicense.Name, Environment.NewLine);
                    sb.AppendFormat("公司: {0}{1}", Common.CurLicense.Company, Environment.NewLine);
                    sb.AppendFormat("Email: {0}{1}", Common.CurLicense.Email, Environment.NewLine);
                    sb.AppendFormat("有效期: {0}", new DateTime(2099, 12, 31).Equals(Common.CurLicense.Expiration) ? "永不过期" : Common.GetDateString(Common.CurLicense.Expiration));
                    MessageBox.Show(sb.ToString(), "授权信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else if (Common.LicenseStatus == EnmLicenseStatus.Expired) {
                    var sb = new StringBuilder();
                    sb.AppendLine(String.Format("软件已过期，请重新注册。", Common.CurLicense.Expiration));
                    sb.AppendLine();
                    sb.AppendFormat("用户: {0}{1}", Common.CurLicense.Name, Environment.NewLine);
                    sb.AppendFormat("公司: {0}{1}", Common.CurLicense.Company, Environment.NewLine);
                    sb.AppendFormat("Email: {0}{1}", Common.CurLicense.Email, Environment.NewLine);
                    sb.AppendFormat("有效期: {0}", new DateTime(2099, 12, 31).Equals(Common.CurLicense.Expiration) ? "永不过期" : Common.GetDateString(Common.CurLicense.Expiration));
                    MessageBox.Show(sb.ToString(), "授权信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else if (Common.LicenseStatus == EnmLicenseStatus.Evaluation) {
                    MessageBox.Show(String.Format("软件为试用版，离试用期结束还有{0}天。", Common.CurApplication.AppFirstTime.AddDays(30).Subtract(Common.CurApplication.AppLastTime).Days), "授权信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else {
                    MessageBox.Show(String.Format("软件试用期已到，请注册后使用。", Common.CurApplication.AppFirstTime.AddDays(30).Subtract(Common.CurApplication.AppLastTime).Days), "授权信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.AboutForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}