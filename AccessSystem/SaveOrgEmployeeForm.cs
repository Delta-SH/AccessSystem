using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLServerDAL;
using System.Text.RegularExpressions;

namespace Delta.MPS.AccessSystem
{
    public partial class SaveOrgEmployeeForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Employee EmpEntity;
        private OrgEmployeeInfo CurEmployee;
        private OrgEmployeeInfo OriEmployee;
        private EnmSaveBehavior CurBehavior;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveOrgEmployeeForm(EnmSaveBehavior Behavior, OrgEmployeeInfo Employee) {
            InitializeComponent();
            CurBehavior = Behavior;
            EmpEntity = new Employee();
            CurEmployee = new OrgEmployeeInfo();
            OriEmployee = Employee;
            Common.CopyObjectValues(OriEmployee, CurEmployee);
            Text = Behavior == EnmSaveBehavior.Add ? "新增员工信息" : "编辑员工信息";
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void SaveOrgEmployeeForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                if (CurBehavior == EnmSaveBehavior.Null || CurEmployee == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                EmpIDTB.ReadOnly = CurBehavior == EnmSaveBehavior.Edit;
                BindMarriageTypeCombobox();
                BindEmpTypeCombobox();
                EmpIDTB.Text = CurEmployee.EmpId;
                EmpNameTB.Text = CurEmployee.EmpName;
                EmpEnglishNameTB.Text = CurEmployee.EnglishName;
                SexMRB.Checked = CurEmployee.Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase);
                SexFRB.Checked = !CurEmployee.Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase);
                CardIDTB.Text = CurEmployee.CardId;
                HometownTB.Text = CurEmployee.Hometown;
                BirthDayDTP.Value = CurEmployee.BirthDay;
                MarriageTypeCB.SelectedValue = (Int32)CurEmployee.Marriage;
                HomeAddressTB.Text = CurEmployee.HomeAddress;
                HomePhoneTB.Text = CurEmployee.HomePhone;
                EntryDayDTP.Value = CurEmployee.EntryDay;
                PositiveDayDTP.Value = CurEmployee.PositiveDay;
                EmpTypeCB.SelectedValue = (Int32)CurEmployee.EmpType;
                DeptTB.Text = String.IsNullOrWhiteSpace(CurEmployee.DepId) ? String.Empty : String.Format("{0} - {1}", CurEmployee.DepId, CurEmployee.DepName);
                DutyNameTB.Text = CurEmployee.DutyName;
                OfficePhoneTB.Text = CurEmployee.OfficePhone;
                MobilePhoneTB.Text = CurEmployee.MobilePhone;
                EmailTB.Text = CurEmployee.Email;
                RemarkTB.Text = CurEmployee.Comment;
                PhotoPanel.BackgroundImageLayout = (ImageLayout)CurEmployee.PhotoLayout;
                if (CurEmployee.Photo != null) {
                    using (var ms = new MemoryStream(CurEmployee.Photo)) {
                        PhotoPanel.BackgroundImage = Image.FromStream(ms);
                    }
                }
                EmpStatusCB.Checked = !CurEmployee.Enabled;
                if (EmpStatusCB.Checked) {
                    ResignationDateDTP.Value = CurEmployee.ResignationDate;
                    ResignationRemarkTB.Text = CurEmployee.ResignationRemark;
                }
                SaveBtn.Enabled = true;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOrgEmployeeForm.SaveEmployeeForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Employee ID TextBox Leave Event.
        /// </summary>
        private void EmpIDTB_Leave(object sender, EventArgs e) {
            if (CurBehavior == EnmSaveBehavior.Add && !String.IsNullOrWhiteSpace(EmpIDTB.Text) && EmpEntity.ExistOrgEmployee(EmpIDTB.Text.Trim())) {
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
        /// Set PhotoLayout Click Event.
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOrgEmployeeForm.PhotoPanel.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Photo Click Event.
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOrgEmployeeForm.SetPhotoBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set DefaultPhoto Click Event.
        /// </summary>
        private void SetDefaultPhotoBtn_Click(object sender, EventArgs e) {
            try {
                CurEmployee.Photo = null;
                PhotoPanel.BackgroundImage = global::Delta.MPS.AccessSystem.Properties.Resources.DefaultEmployee;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOrgEmployeeForm.SetDefaultPhotoBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employee Status Checked Changed Event.
        /// </summary>
        private void EmpStatusCB_CheckedChanged(object sender, EventArgs e) {
            try {
                ResignationRemarkTB.Enabled = ResignationDateDTP.Enabled = EmpStatusCB.Checked;
                if (!EmpStatusCB.Checked) {
                    ResignationDateDTP.Value = new DateTime(2013, 1, 1);
                    ResignationRemarkTB.Text = String.Empty;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOrgEmployeeForm.EmpStatusCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Department Button Click Event.
        /// </summary>
        private void SetDeptBtn_Click(object sender, EventArgs e) {
            try {
                var Dialog = new DepartmentDialog(false);
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    if (Dialog.SelectedItems.Count > 0) {
                        var Dept = Dialog.SelectedItems[0];
                        CurEmployee.DepId = Dept.DepId;
                        CurEmployee.DepName = Dept.DepName;
                        DeptTB.Text = String.Format("{0} - {1}", Dept.DepId, Dept.DepName);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveOrgEmployeeForm.SetDeptBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Department TextBox Double Click Event.
        /// </summary>
        private void DeptTB_DoubleClick(object sender, EventArgs e) {
            SetDeptBtn_Click(sender, e);
        }

        /// <summary>
        /// Save Employee.
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

                if (CurBehavior == EnmSaveBehavior.Add && EmpEntity.ExistOrgEmployee(EmpIDTB.Text.Trim())) {
                    EmpIDTB.BackColor = Color.MistyRose;
                    EmpIDTB.Focus();
                    MessageBox.Show("工号已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(CurEmployee.DepId)) {
                    DeptTB.Clear();
                    CurEmployee.DepId = String.Empty;
                    CurEmployee.DepName = String.Empty;
                    MessageBox.Show("请选择所属部门", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CurEmployee.EmpId = EmpIDTB.Text.Trim();
                CurEmployee.EmpType = ComUtility.DBNullWorkerTypeHandler(EmpTypeCB.SelectedValue);
                CurEmployee.EmpName = EmpNameTB.Text.Trim();
                CurEmployee.EnglishName = EmpEnglishNameTB.Text.Trim();
                CurEmployee.Sex = SexMRB.Checked ? "M" : "F";
                CurEmployee.CardId = CardIDTB.Text.Trim();
                CurEmployee.Hometown = HometownTB.Text.Trim();
                CurEmployee.BirthDay = BirthDayDTP.Value;
                CurEmployee.Marriage = ComUtility.DBNullMarriageTypeHandler(MarriageTypeCB.SelectedValue);
                CurEmployee.HomeAddress = HomeAddressTB.Text.Trim();
                CurEmployee.HomePhone = HomePhoneTB.Text.Trim();
                CurEmployee.EntryDay = EntryDayDTP.Value;
                CurEmployee.PositiveDay = PositiveDayDTP.Value;
                //CurEmployee.DepId = null;
                //CurEmployee.DepName = null;
                CurEmployee.DutyName = DutyNameTB.Text.Trim();
                CurEmployee.OfficePhone = OfficePhoneTB.Text.Trim();
                CurEmployee.MobilePhone = MobilePhoneTB.Text.Trim();
                CurEmployee.Email = EmailTB.Text.Trim();
                CurEmployee.Comment = RemarkTB.Text.Trim();
                //CurEmployee.Photo = null;
                CurEmployee.PhotoLayout = (int)PhotoPanel.BackgroundImageLayout;
                CurEmployee.Enabled = !EmpStatusCB.Checked;
                CurEmployee.ResignationDate = CurEmployee.Enabled ? ComUtility.DefaultDateTime : ResignationDateDTP.Value;
                CurEmployee.ResignationRemark = CurEmployee.Enabled ? ComUtility.DefaultString : ResignationRemarkTB.Text.Trim();

                var result = Common.ShowWait(() => {
                    EmpEntity.SaveOrgEmployees(new List<OrgEmployeeInfo> { CurEmployee });
                }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                if (result == DialogResult.OK) {
                    Common.CopyObjectValues(CurEmployee, OriEmployee);
                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveEmployeeForm.SaveBtn.Click", String.Format("{0}员工:[{1},{2}]", CurBehavior == EnmSaveBehavior.Add ? "新增" : "更新", CurEmployee.EmpId, CurEmployee.EmpName), null);
                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveEmployeeForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Marriage Type Combobox.
        /// </summary>
        private void BindMarriageTypeCombobox() {
            var data = new List<object>();
            foreach (EnmMarriageType type in Enum.GetValues(typeof(EnmMarriageType))) {
                data.Add(new {
                    ID = (int)type,
                    Name = ComUtility.GetMarriageTypeText(type)
                });
            }

            MarriageTypeCB.ValueMember = "ID";
            MarriageTypeCB.DisplayMember = "Name";
            MarriageTypeCB.DataSource = data;
        }

        /// <summary>
        /// Bind Employee Type Combobox.
        /// </summary>
        private void BindEmpTypeCombobox() {
            var data = new List<object>();
            foreach (EnmWorkerType type in Enum.GetValues(typeof(EnmWorkerType))) {
                if (type == EnmWorkerType.WXRY) { continue; }
                data.Add(new { ID = (Int32)type, Name = ComUtility.GetWorkerTypeText(type) });
            }

            EmpTypeCB.ValueMember = "ID";
            EmpTypeCB.DisplayMember = "Name";
            EmpTypeCB.DataSource = data;
        }
    }
}