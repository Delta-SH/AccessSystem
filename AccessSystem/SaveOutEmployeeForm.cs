using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Delta.MPS.Model;
using Delta.MPS.SQLServerDAL;
using System.Text.RegularExpressions;

namespace Delta.MPS.AccessSystem
{
    public partial class SaveOutEmployeeForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private EnmSaveBehavior CurBehavior;
        private Employee EmpEntity;
        private OutEmployeeInfo CurEmployee;
        private OutEmployeeInfo OriEmployee;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveOutEmployeeForm(EnmSaveBehavior Behavior, OutEmployeeInfo Employee) {
            InitializeComponent();
            CurBehavior = Behavior;
            EmpEntity = new Employee();
            CurEmployee = new OutEmployeeInfo();
            OriEmployee = Employee;
            Common.CopyObjectValues(OriEmployee, CurEmployee);
            Text = Behavior == EnmSaveBehavior.Add ? "新增外协人员" : "编辑外协人员";
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void SaveOutEmployeeForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                if (CurBehavior == EnmSaveBehavior.Null || CurEmployee == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                EmpIDTB.ReadOnly = CurBehavior == EnmSaveBehavior.Edit;
                EmpIDTB.Text = CurEmployee.EmpId;
                EmpNameTB.Text =  CurEmployee.EmpName;
                SexMRB.Checked = CurEmployee.Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase);
                SexFRB.Checked = !CurEmployee.Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase);
                HometownTB.Text = CurEmployee.Hometown;
                CardIDTB.Text = CurEmployee.CardId;
                CardIssueTB.Text = CurEmployee.CardIssue;
                CardAddressTB.Text = CurEmployee.CardAddress;
                CompanyNameTB.Text = CurEmployee.CompanyName;
                ProjectNameTB.Text = CurEmployee.ProjectName;
                OfficePhoneTB.Text = CurEmployee.OfficePhone;
                MobilePhoneTB.Text = CurEmployee.MobilePhone;
                EmailTB.Text = CurEmployee.Email;
                PEmpNameTB.Text = String.IsNullOrWhiteSpace(CurEmployee.ParentEmpId) ? String.Empty : String.Format("{0} - {1}", CurEmployee.ParentEmpId, CurEmployee.ParentEmpName);
                EmpStatusCB.Checked = CurEmployee.Enabled;
                RemarkTB.Text = CurEmployee.Comment;
                PhotoPanel.BackgroundImageLayout = (ImageLayout)CurEmployee.PhotoLayout;
                if (CurEmployee.Photo != null) {
                    using (var ms = new MemoryStream(CurEmployee.Photo)) {
                        PhotoPanel.BackgroundImage = Image.FromStream(ms);
                    }
                }
                SaveBtn.Enabled = true;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOutEmployeeForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employee ID TextBox Leave Event.
        /// </summary>
        private void EmpIDTB_Leave(object sender, EventArgs e) {
            if (CurBehavior == EnmSaveBehavior.Add && !String.IsNullOrWhiteSpace(EmpIDTB.Text) && EmpEntity.ExistOutEmployee(EmpIDTB.Text.Trim())) {
                EmpIDTB.BackColor = Color.MistyRose;
                EmpIDTB.Focus();
                MessageBox.Show("工号已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EmpIDTB.BackColor = String.IsNullOrWhiteSpace(EmpIDTB.Text) ? Color.MistyRose : Color.White;
        }

        /// <summary>
        /// Employee Name TextBox Leave Event.
        /// </summary>
        private void EmpNameTB_Leave(object sender, EventArgs e) {
            EmpNameTB.BackColor = String.IsNullOrWhiteSpace(EmpNameTB.Text) ? Color.MistyRose : SystemColors.Window;
        }

        /// <summary>
        /// MobilePhone TextBox Leave Event.
        /// </summary>
        private void MobilePhoneTB_Leave(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(MobilePhoneTB.Text) && !Regex.IsMatch(MobilePhoneTB.Text.Trim(), @"^1[358][0-9]{9}$", RegexOptions.IgnoreCase)) {
                MobilePhoneTB.BackColor = Color.MistyRose;
                MobilePhoneTB.Focus();
                MessageBox.Show("请输入正确的手机号码", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MobilePhoneTB.BackColor = String.IsNullOrWhiteSpace(MobilePhoneTB.Text) ? Color.MistyRose : SystemColors.Window;
        }

        /// <summary>
        /// Email TextBox Leave Event.
        /// </summary>
        private void EmailTB_Leave(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(EmailTB.Text) && !Regex.IsMatch(EmailTB.Text.Trim(), @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$", RegexOptions.IgnoreCase)) {
                EmailTB.BackColor = Color.MistyRose;
                EmailTB.Focus();
                MessageBox.Show("请输入正确的Email", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EmailTB.BackColor = String.IsNullOrWhiteSpace(EmailTB.Text) ? Color.MistyRose : SystemColors.Window;
        }

        /// <summary>
        /// CardID TextBox Leave Event.
        /// </summary>
        private void CardIDTB_Leave(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(CardIDTB.Text) && !Regex.IsMatch(CardIDTB.Text.Trim(), @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)) {
                CardIDTB.BackColor = Color.MistyRose;
                CardIDTB.Focus();
                MessageBox.Show("请输入正确的身份证号码", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                CardIDTB.BackColor = SystemColors.Window;
            }
        }

        /// <summary>
        /// Set Photo Layout.
        /// </summary>
        private void PhotoPanel_Click(object sender, EventArgs e) {
            try {
                if (PhotoPanel.BackgroundImageLayout == ImageLayout.Zoom) {
                    PhotoPanel.BackgroundImageLayout = ImageLayout.Stretch;
                } else if (PhotoPanel.BackgroundImageLayout == ImageLayout.Stretch) {
                    PhotoPanel.BackgroundImageLayout = ImageLayout.Center;
                } else if (PhotoPanel.BackgroundImageLayout == ImageLayout.Center) {
                    PhotoPanel.BackgroundImageLayout = ImageLayout.Zoom;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOutEmployeeForm.PhotoPanel.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set New Photo.
        /// </summary>
        private void SetPhotoBtn_Click(object sender, EventArgs e) {
            try {
                if (PhotoFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    var file = new FileInfo(PhotoFileDialog.FileName);
                    if (!file.Exists) {
                        MessageBox.Show("文件不存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (file.Length / 1024 > 1024) {
                        MessageBox.Show("文件不能大于1M", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    CurEmployee.Photo = new byte[file.Length];
                    using (var fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read)) {
                        using (var br = new BinaryReader(fs)) {
                            br.Read(CurEmployee.Photo, 0, CurEmployee.Photo.Length);
                            PhotoPanel.BackgroundImage = Image.FromStream(fs);
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOutEmployeeForm.SetPhotoBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Default Photo.
        /// </summary>
        private void SetDefaultPhotoBtn_Click(object sender, EventArgs e) {
            try {
                CurEmployee.Photo = null;
                PhotoPanel.BackgroundImage = global::Delta.MPS.AccessSystem.Properties.Resources.DefaultEmployee;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOutEmployeeForm.SetDefaultPhotoBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save Out Employee.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(EmpIDTB.Text)
                    || String.IsNullOrWhiteSpace(EmpNameTB.Text)
                    || String.IsNullOrWhiteSpace(MobilePhoneTB.Text)
                    || String.IsNullOrWhiteSpace(EmailTB.Text)) {

                    if (String.IsNullOrWhiteSpace(EmailTB.Text)) {
                        EmailTB.BackColor = Color.MistyRose;
                        EmailTB.Focus();
                    }
                    if (String.IsNullOrWhiteSpace(MobilePhoneTB.Text)) {
                        MobilePhoneTB.BackColor = Color.MistyRose;
                        MobilePhoneTB.Focus();
                    }
                    if (String.IsNullOrWhiteSpace(EmpNameTB.Text)) {
                        EmpNameTB.BackColor = Color.MistyRose;
                        EmpNameTB.Focus();
                    }
                    if (String.IsNullOrWhiteSpace(EmpIDTB.Text)) {
                        EmpIDTB.BackColor = Color.MistyRose;
                        EmpIDTB.Focus();
                    }

                    MessageBox.Show("请输入必填项(红色标示区域)", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CurBehavior == EnmSaveBehavior.Add && EmpEntity.ExistOutEmployee(EmpIDTB.Text.Trim())) {
                    EmpIDTB.BackColor = Color.MistyRose;
                    EmpIDTB.Focus();
                    MessageBox.Show("工号已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(CurEmployee.ParentEmpId)) {
                    PEmpNameTB.Clear();
                    CurEmployee.DepId = String.Empty;
                    CurEmployee.DepName = String.Empty;
                    CurEmployee.ParentEmpId = String.Empty;
                    CurEmployee.ParentEmpName = String.Empty;
                    MessageBox.Show("请选择外协人员的责任人", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CurEmployee.EmpId = EmpIDTB.Text.Trim();
                CurEmployee.EmpName = EmpNameTB.Text.Trim();
                CurEmployee.Sex = SexMRB.Checked ? "M" : "F";
                CurEmployee.Hometown = HometownTB.Text.Trim();
                CurEmployee.CardId = CardIDTB.Text.Trim();
                CurEmployee.CardIssue = CardIssueTB.Text.Trim();
                CurEmployee.CardAddress = CardAddressTB.Text.Trim();
                CurEmployee.CompanyName = CompanyNameTB.Text.Trim();
                CurEmployee.ProjectName = ProjectNameTB.Text.Trim();
                CurEmployee.OfficePhone = OfficePhoneTB.Text.Trim();
                CurEmployee.MobilePhone = MobilePhoneTB.Text.Trim();
                CurEmployee.Email = EmailTB.Text.Trim();
                //CurEmployee.ParentEmpName = null;
                CurEmployee.Enabled = EmpStatusCB.Checked;
                CurEmployee.Comment = RemarkTB.Text.Trim();
                //CurEmployee.Photo = null;
                CurEmployee.PhotoLayout = (int)PhotoPanel.BackgroundImageLayout;

                var result = Common.ShowWait(() => {
                    EmpEntity.SaveOutEmployees(new List<OutEmployeeInfo> { CurEmployee });
                }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                if (result == DialogResult.OK) {
                    Common.CopyObjectValues(CurEmployee, OriEmployee);
                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveOutEmployeeForm.SaveBtn.Click", String.Format("{0}外协人员:[{1},{2}]", CurBehavior == EnmSaveBehavior.Add ? "新增" : "更新", CurEmployee.EmpId, CurEmployee.EmpName), null);
                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOutEmployeeForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Parent Employee.
        /// </summary>
        private void SetEmpBtn_Click(object sender, EventArgs e) {
            try {
                var Dialog = new OrgEmployeeDialog(false);
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    if (Dialog.SelectedItems.Count > 0) {
                        var ParentEmployee = Dialog.SelectedItems[0];
                        CurEmployee.DepId = ParentEmployee.DepId;
                        CurEmployee.DepName = ParentEmployee.DepName;
                        CurEmployee.ParentEmpId = ParentEmployee.EmpId;
                        CurEmployee.ParentEmpName = ParentEmployee.EmpName;
                        PEmpNameTB.Text = String.Format("{0} - {1}", ParentEmployee.EmpId, ParentEmployee.EmpName);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOutEmployeeForm.SetEmpBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Parent Employee
        /// </summary>
        private void PEmpNameTB_DoubleClick(object sender, EventArgs e) {
            SetEmpBtn_Click(sender, e);
        }
    }
}