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
    public partial class SaveDepartmentForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private EnmSaveBehavior CurBehavior = EnmSaveBehavior.Null;
        private Department DeptEntity;
        private DepartmentInfo CurDept;
        private DepartmentInfo OriDept;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveDepartmentForm(EnmSaveBehavior Behavior, DepartmentInfo Dept) {
            InitializeComponent();
            DeptEntity = new Department();
            CurBehavior = Behavior;
            CurDept = new DepartmentInfo();
            OriDept = Dept;
            Common.CopyObjectValues(OriDept, CurDept);
            Text = Behavior == EnmSaveBehavior.Add ? "新增部门信息" : "编辑部门信息";
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void SaveDepartmentForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                if (CurBehavior == EnmSaveBehavior.Null || CurDept == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                DepIDTB.ReadOnly = CurBehavior == EnmSaveBehavior.Edit;
                DepIDTB.Text = CurDept.DepId;
                DepNameTB.Text = CurDept.DepName;
                DepCommentTB.Text = CurDept.Comment;
                EnabledCB.Checked = CurDept.Enabled;

                var dept = Common.CurUser.Role.Departments.Find(d => d.DepId.Equals(CurDept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                LastDeptTB.Text = dept != null ? String.Format("{0} - {1}", dept.DepId, dept.DepName) : String.Empty;
                CurDept.LastDepId = dept != null ? dept.DepId : String.Empty;
                ParentDeptCB.Checked = dept == null;
                SaveBtn.Enabled = true;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveDepartmentForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save Department.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(DepIDTB.Text)) {
                    DepIDTB.Focus();
                    MessageBox.Show("部门编码不能为空", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(DepNameTB.Text)) {
                    DepNameTB.Focus();
                    MessageBox.Show("部门名称不能为空", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CurBehavior == EnmSaveBehavior.Add && DeptEntity.ExistDepartment(DepIDTB.Text.Trim())) {
                    DepIDTB.Focus();
                    MessageBox.Show("部门已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ParentDeptCB.Checked) { CurDept.LastDepId = "0"; }
                if (String.IsNullOrWhiteSpace(CurDept.LastDepId)) {
                    LastDeptTB.Clear();
                    CurDept.LastDepId = String.Empty;
                    MessageBox.Show("请选择上级部门", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CurBehavior == EnmSaveBehavior.Edit && CurDept.DepId.Equals(CurDept.LastDepId, StringComparison.CurrentCultureIgnoreCase)) {
                    LastDeptTB.Clear();
                    CurDept.LastDepId = String.Empty;
                    MessageBox.Show("当前部门不能作为其上级部门", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CurDept.DepId = DepIDTB.Text.Trim();
                CurDept.DepName = DepNameTB.Text.Trim();
                //CurDept.LastDepId = null;
                CurDept.Comment = DepCommentTB.Text.Trim();
                CurDept.Enabled = EnabledCB.Checked;
                var result = Common.ShowWait(() => {
                    DeptEntity.SaveDepartments(new List<DepartmentInfo> { CurDept });
                    if (CurBehavior == EnmSaveBehavior.Add) { Common.CurUser.Role.Departments.Add(CurDept); }
                }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                if (result == DialogResult.OK) {
                    Common.CopyObjectValues(CurDept, OriDept);
                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveDepartmentForm.SaveBtn.Click", String.Format("{0}部门:[{1},{2}]", CurBehavior == EnmSaveBehavior.Add ? "新增" : "更新", CurDept.DepId, CurDept.DepName), null);
                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveDepartmentForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Last Department Button Click Event.
        /// </summary>
        private void SetLastDeptBtn_Click(object sender, EventArgs e) {
            try {
                var Dialog = new DepartmentDialog(false);
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    if (Dialog.SelectedItems.Count > 0) {
                        var Dept = Dialog.SelectedItems[0];
                        CurDept.LastDepId = Dept.DepId;
                        LastDeptTB.Text = String.Format("{0} - {1}", Dept.DepId, Dept.DepName);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveDepartmentForm.SetLastDeptBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Department TextBox Double Click Event.
        /// </summary>
        private void LastDeptTB_DoubleClick(object sender, EventArgs e) {
            SetLastDeptBtn_Click(sender, e);
        }

        /// <summary>
        /// Parent Department Checked Changed Event.
        /// </summary>
        private void ParentDeptCB_CheckedChanged(object sender, EventArgs e) {
            try {
                LastDeptTB.Enabled = SetLastDeptBtn.Enabled = !ParentDeptCB.Checked;
                LastDeptTB.Clear();
                CurDept.LastDepId = String.Empty;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveDepartmentForm.ParentDeptCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}