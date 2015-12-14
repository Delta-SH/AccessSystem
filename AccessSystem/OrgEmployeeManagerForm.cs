using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLServerDAL;
using System.Collections;

namespace Delta.MPS.AccessSystem
{
    public partial class OrgEmployeeManagerForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Employee EmpEntity;
        private List<DepartmentInfo> Departments;
        private List<OrgEmployeeInfo> Employees;
        private List<OrgEmployeeInfo> GridEmployees;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public OrgEmployeeManagerForm() {
            InitializeComponent();
            EmpEntity = new Employee();
            Departments = new List<DepartmentInfo>();
            Employees = new List<OrgEmployeeInfo>();
            GridEmployees = new List<OrgEmployeeInfo>();
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void OrgEmployeeManagerForm_Shown(object sender, EventArgs e) {
            try {
                BindSearchType();
                var TempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    Departments = Common.CurUser.Role.Departments;
                    Employees = EmpEntity.GetOrgEmployees(Common.CurUser.Role.RoleID);
                    BindDepartmentsToTreeView(TempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    DeptTreeView.Nodes.Clear();
                    foreach (TreeNode tn in TempTreeView.Nodes) {
                        DeptTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (DeptTreeView.Nodes.Count > 0) {
                        var root = DeptTreeView.Nodes[0];
                        DeptTreeView.SelectedNode = root;
                        root.Expand();
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Department TreeView AfterSelect Event.
        /// </summary>
        private void DeptTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                SearchText.Clear();
                BindEmployeesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.DeptTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Show All Children Employees.
        /// </summary>
        private void SubEmpCB_CheckedChanged(object sender, EventArgs e) {
            try {
                BindEmployeesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.SubEmpCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search Employees By Condition.
        /// </summary>
        private void SeachBtn_Click(object sender, EventArgs e) {
            try {
                BindEmployeesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.SeachBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search Type SelectedIndex Changed Event.
        /// </summary>
        private void SearchType_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(SearchText.Text)) { return; }
                BindEmployeesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.SearchType.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employee GridView CellValue Needed Event.
        /// </summary>
        private void EmpGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > GridEmployees.Count - 1) { return; }
                switch (EmpGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EIDColumn":
                        e.Value = GridEmployees[e.RowIndex].EmpId;
                        break;
                    case "NameColumn":
                        e.Value = GridEmployees[e.RowIndex].EmpName;
                        break;
                    case "TypeColumn":
                        e.Value = ComUtility.GetWorkerTypeText(GridEmployees[e.RowIndex].EmpType);
                        break;
                    case "EnglishNameColumn":
                        e.Value = GridEmployees[e.RowIndex].EnglishName;
                        break;
                    case "SexColumn":
                        e.Value = GridEmployees[e.RowIndex].Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase) ? "男" : "女";
                        break;
                    case "CardIDColumn":
                        e.Value = GridEmployees[e.RowIndex].CardId;
                        break;
                    case "HometownColumn":
                        e.Value = GridEmployees[e.RowIndex].Hometown;
                        break;
                    case "BirthDayColumn":
                        e.Value = Common.GetDateString(GridEmployees[e.RowIndex].BirthDay);
                        break;
                    case "MarriageColumn":
                        e.Value = ComUtility.GetMarriageTypeText(GridEmployees[e.RowIndex].Marriage);
                        break;
                    case "HomeAddressColumn":
                        e.Value = GridEmployees[e.RowIndex].HomeAddress;
                        break;
                    case "HomePhoneColumn":
                        e.Value = GridEmployees[e.RowIndex].HomePhone;
                        break;
                    case "EntryDayColumn":
                        e.Value = Common.GetDateString(GridEmployees[e.RowIndex].EntryDay);
                        break;
                    case "PositiveDayColumn":
                        e.Value = Common.GetDateString(GridEmployees[e.RowIndex].PositiveDay);
                        break;
                    case "DepNameColumn":
                        e.Value = String.Format("{0} - {1}", GridEmployees[e.RowIndex].DepId, GridEmployees[e.RowIndex].DepName);
                        break;
                    case "DutyNameColumn":
                        e.Value = GridEmployees[e.RowIndex].DutyName;
                        break;
                    case "OfficePhoneColumn":
                        e.Value = GridEmployees[e.RowIndex].OfficePhone;
                        break;
                    case "MobilePhoneColumn":
                        e.Value = GridEmployees[e.RowIndex].MobilePhone;
                        break;
                    case "EmailColumn":
                        e.Value = GridEmployees[e.RowIndex].Email;
                        break;
                    case "CommentColumn":
                        e.Value = GridEmployees[e.RowIndex].Comment;
                        break;
                    case "EnabledColumn":
                        e.Value = GridEmployees[e.RowIndex].Enabled ? "在职" : "离职";
                        break;
                    case "ResignationDateColumn":
                        e.Value = Common.GetDateString(GridEmployees[e.RowIndex].ResignationDate);
                        break;
                    case "ResignationRemarkColumn":
                        e.Value = GridEmployees[e.RowIndex].ResignationRemark;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.EmpGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employee GridView CellContent Click Event.
        /// </summary>
        private void EmpGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                var key = (String)EmpGridView.Rows[e.RowIndex].Cells["EIDColumn"].Value;
                var obj = GridEmployees.Find(d => d.EmpId.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (EmpGridView.Columns[e.ColumnIndex].Name) {
                    case "DeleteColumn":
                        if (EmpEntity.ExistOutEmployeesInOrgEmployees(key)) {
                            MessageBox.Show(String.Format("员工[{0},{1}]下已分配外协人员，无法执行删除操作。", obj.EmpId, obj.EmpName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (MessageBox.Show(String.Format("员工[{0},{1}]将被删除，您确定要删除吗?", obj.EmpId, obj.EmpName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                EmpEntity.DeleteOrgEmployees(new List<OrgEmployeeInfo>() { obj });
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                Employees.Remove(obj);
                                GridEmployees.Remove(obj);
                                EmpGridView.Rows.RemoveAt(e.RowIndex);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.EmpGridView.CellContentClick", String.Format("删除员工:[{0},{1}]", obj.EmpId, obj.EmpName), null);
                            }
                        }
                        break;
                    case "EditColumn":
                        if (new SaveOrgEmployeeForm(EnmSaveBehavior.Edit, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            EmpGridView.InvalidateRow(e.RowIndex);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.EmpGridView.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add employee.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                DepartmentInfo dept = null;
                if (DeptTreeView.SelectedNode != null) {
                    var dId = (String)DeptTreeView.SelectedNode.Tag;
                    dept = Departments.Find(d => d.DepId.Equals(dId, StringComparison.CurrentCultureIgnoreCase));
                }

                var maxId = EmpEntity.GetMaxOrgEmployeeID() + 1;
                var obj = new OrgEmployeeInfo() {
                    ID = maxId,
                    EmpId = String.Format("{0:D8}", maxId),
                    EmpType = EnmWorkerType.ZSYG,
                    EmpName = String.Empty,
                    EnglishName = String.Empty,
                    Sex = "M",
                    CardId = String.Empty,
                    Hometown = String.Empty,
                    BirthDay = new DateTime(1985, 1, 1),
                    Marriage = EnmMarriageType.SG,
                    HomeAddress = String.Empty,
                    HomePhone = String.Empty,
                    EntryDay = DateTime.Today,
                    PositiveDay = DateTime.Today.AddMonths(3),
                    DepId = dept != null ? dept.DepId : String.Empty,
                    DepName = dept != null ? dept.DepName : String.Empty,
                    DutyName = String.Empty,
                    OfficePhone = String.Empty,
                    MobilePhone = String.Empty,
                    Email = String.Empty,
                    Comment = String.Empty,
                    Photo = null,
                    PhotoLayout = (int)ImageLayout.Zoom,
                    Enabled = true,
                    ResignationDate = ComUtility.DefaultDateTime,
                    ResignationRemark = ComUtility.DefaultString
                };

                if (new SaveOrgEmployeeForm(EnmSaveBehavior.Add, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    Employees.Add(obj);
                    BindEmployeesToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Employees.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                if (EmpGridView.Rows.Count > 0) {
                    var adEmps = new Dictionary<String, OrgEmployeeInfo>();
                    foreach (var ge in GridEmployees) {
                        if (EmpEntity.ExistOutEmployeesInOrgEmployees(ge.EmpId)) {
                            MessageBox.Show(String.Format("员工[{0},{1}]下已分配外协人员，无法执行删除操作。", ge.EmpId, ge.EmpName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        adEmps[ge.EmpId] = ge;
                    }

                    if (MessageBox.Show("您确定要全部删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            EmpEntity.DeleteOrgEmployees(adEmps.Select(ad => ad.Value).ToList());
                        }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            GridEmployees.Clear();
                            EmpGridView.Rows.Clear();
                            foreach (var ad in adEmps) {
                                Employees.Remove(ad.Value);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.DeleteBtn.Click", String.Format("删除员工:[{0},{1}]", ad.Value.EmpId, ad.Value.EmpName), null);
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export Employees To Excel.
        /// </summary>
        private void ExportBtn_Click(object sender, EventArgs e) {
            try {
                if (GridEmployees.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("工号", typeof(String));
                    data.Columns.Add("姓名", typeof(String));
                    data.Columns.Add("类别", typeof(String));
                    data.Columns.Add("英文名", typeof(String));
                    data.Columns.Add("性别", typeof(String));
                    data.Columns.Add("身份证号", typeof(String));
                    data.Columns.Add("籍贯", typeof(String));
                    data.Columns.Add("出生日期", typeof(String));
                    data.Columns.Add("婚姻状况", typeof(String));
                    data.Columns.Add("家庭地址", typeof(String));
                    data.Columns.Add("家庭电话", typeof(String));
                    data.Columns.Add("入职日期", typeof(String));
                    data.Columns.Add("转正日期", typeof(String));
                    data.Columns.Add("部门名称", typeof(String));
                    data.Columns.Add("职务", typeof(String));
                    data.Columns.Add("办公电话", typeof(String));
                    data.Columns.Add("手机", typeof(String));
                    data.Columns.Add("Email", typeof(String));
                    data.Columns.Add("备注", typeof(String));
                    data.Columns.Add("状态", typeof(String));
                    data.Columns.Add("离职日期", typeof(String));
                    data.Columns.Add("离职原因", typeof(String));
                    for (var i = 0; i < GridEmployees.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["工号"] = GridEmployees[i].EmpId;
                        dr["姓名"] = GridEmployees[i].EmpName;
                        dr["类别"] = ComUtility.GetWorkerTypeText(GridEmployees[i].EmpType);
                        dr["英文名"] = GridEmployees[i].EnglishName;
                        dr["性别"] = GridEmployees[i].Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase) ? "男" : "女";
                        dr["身份证号"] = GridEmployees[i].CardId;
                        dr["籍贯"] = GridEmployees[i].Hometown;
                        dr["出生日期"] = Common.GetDateString(GridEmployees[i].BirthDay);
                        dr["婚姻状况"] = ComUtility.GetMarriageTypeText(GridEmployees[i].Marriage);
                        dr["家庭地址"] = GridEmployees[i].HomeAddress;
                        dr["家庭电话"] = GridEmployees[i].HomePhone;
                        dr["入职日期"] = Common.GetDateString(GridEmployees[i].EntryDay);
                        dr["转正日期"] = Common.GetDateString(GridEmployees[i].PositiveDay);
                        dr["部门名称"] = String.Format("{0} - {1}", GridEmployees[i].DepId, GridEmployees[i].DepName);
                        dr["职务"] = GridEmployees[i].DutyName;
                        dr["办公电话"] = GridEmployees[i].OfficePhone;
                        dr["手机"] = GridEmployees[i].MobilePhone;
                        dr["Email"] = GridEmployees[i].Email;
                        dr["备注"] = GridEmployees[i].Comment;
                        dr["状态"] = GridEmployees[i].Enabled ? "在职" : "离职";
                        dr["离职日期"] = Common.GetDateString(GridEmployees[i].ResignationDate);
                        dr["离职原因"] = GridEmployees[i].ResignationRemark;
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "员工信息", "智能门禁管理系统 员工信息报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.ExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Opening Event.
        /// </summary>
        private void OperationContext_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = EmpGridView.SelectedRows.Count > 0;
                OpMenuItem2.Enabled = EmpGridView.Rows.Count > 0;
                OpMenuItem3.Enabled = GridEmployees.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.OperationContext.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Selected Employees.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (EmpGridView.SelectedRows.Count > 0) {
                    var adEmps = new Dictionary<Int32, OrgEmployeeInfo>();
                    foreach (DataGridViewRow row in EmpGridView.SelectedRows) {
                        var key = (String)row.Cells["EIDColumn"].Value;
                        var obj = GridEmployees.Find(ge => ge.EmpId.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                        if (obj != null) {
                            if (EmpEntity.ExistOutEmployeesInOrgEmployees(obj.EmpId)) {
                                MessageBox.Show(String.Format("员工[{0},{1}]下已分配外协人员，无法执行删除操作。", obj.EmpId, obj.EmpName), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            adEmps[row.Index] = obj;
                        }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中员工将被删除，您确定要删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                EmpEntity.DeleteOrgEmployees(adEmps.Select(ad => ad.Value).ToList());
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var ae in adEmps) {
                                    Employees.Remove(ae.Value);
                                    GridEmployees.Remove(ae.Value);
                                    EmpGridView.Rows.RemoveAt(ae.Key);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.OpMenuItem1.Click", String.Format("删除员工:[{0},{1}]", ae.Value.EmpId, ae.Value.EmpName), null);
                                }
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.OpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete All Employees.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            DeleteBtn_Click(sender, e);
        }

        /// <summary>
        /// Save All Employees To Excel.
        /// </summary>
        private void OpMenuItem3_Click(object sender, EventArgs e) {
            ExportBtn_Click(sender, e);
        }

        /// <summary>
        /// Import Data Button Click Event.
        /// </summary>
        private void BImportBtn_Click(object sender, EventArgs e) {
            if (new ImportDataForm(EnmImportType.Org).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                Employees = EmpEntity.GetOrgEmployees(Common.CurUser.Role.RoleID);
                BindEmployeesToGridView();
            }
        }

        /// <summary>
        /// Export Data Button Click Event.
        /// </summary>
        private void BExportBtn_Click(object sender, EventArgs e) {
            try {
                var data = new Employee().ExportOrgEmployees(Common.CurUser.Role.RoleID);
                Common.ExportDataToExcel(null, "员工信息", "智能门禁管理系统 员工信息", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.BExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// TreeView Menu Item1 Click Event.
        /// </summary>
        private FinderDialog Finder = null;
        private void TVToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (Finder == null || Finder.IsDisposed) {
                    Finder = new FinderDialog(DeptTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Search Type.
        /// </summary>
        private void BindSearchType() {
            var data = new List<object>();
            data.Add(new {
                ID = 0,
                Name = "按姓名查询"
            });
            data.Add(new {
                ID = 1,
                Name = "按工号查询"
            });

            SearchType.ValueMember = "ID";
            SearchType.DisplayMember = "Name";
            SearchType.DataSource = data;
        }

        /// <summary>
        /// Bind Departments To TreeView.
        /// </summary>
        private void BindDepartmentsToTreeView(TreeView TempTreeView) {
            var root = TempTreeView.Nodes.Add("0", "所有员工");
            root.Tag = "0";
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var node = root.Nodes.Add(dept.DepId, dept.DepName);
                    node.Tag = dept.DepId;
                    dept.LastDepId = "0";

                    BindDepartmentsRecursion(node, dept.DepId);
                }
            }
        }

        /// <summary>
        /// Bind Departments Recursion.
        /// </summary>
        private void BindDepartmentsRecursion(TreeNode pNode, String pId) {
            if (Departments != null && Departments.Count > 0) {
                var sds = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (sds.Count > 0) {
                    foreach (var d in sds) {
                        var tnode = pNode.Nodes.Add(d.DepId, d.DepName);
                        tnode.Tag = d.DepId;
                        BindDepartmentsRecursion(tnode, d.DepId);
                    }
                }
            }
        }

        /// <summary>
        /// Find SubDepartments Recursion.
        /// </summary>
        private void FindSubDeptRecursion(String pId, List<DepartmentInfo> sDept) {
            var sds = Departments.FindAll(d => d.LastDepId == pId);
            if (sds.Count > 0) {
                foreach (var d in sds) {
                    sDept.Add(d);
                    FindSubDeptRecursion(d.DepId, sDept);
                }
            }
        }

        /// <summary>
        /// Bind Employees To GridView.
        /// </summary>
        private void BindEmployeesToGridView() {
            GridEmployees.Clear();
            EmpGridView.Rows.Clear();
            if (DeptTreeView.SelectedNode != null) {
                var dId = (String)DeptTreeView.SelectedNode.Tag;
                if (dId.Equals("0")) {
                    GridEmployees.AddRange(Employees);
                } else {
                    GridEmployees.AddRange(Employees.FindAll(e => e.DepId.Equals(dId, StringComparison.CurrentCultureIgnoreCase)));
                    if (SubEmpCB.Checked) {
                        var SubDept = new List<DepartmentInfo>();
                        FindSubDeptRecursion(dId, SubDept);
                        foreach (var sd in SubDept) {
                            GridEmployees.AddRange(Employees.FindAll(e => e.DepId.Equals(sd.DepId, StringComparison.CurrentCultureIgnoreCase)));
                        }
                    }
                }

                if (GridEmployees.Count > 0 && !String.IsNullOrWhiteSpace(SearchText.Text)) {
                    switch ((Int32)SearchType.SelectedValue) {
                        case 0:
                            GridEmployees = GridEmployees.FindAll(e => e.EmpName.ToLower().Contains(SearchText.Text.ToLower().Trim()));
                            break;
                        case 1:
                            GridEmployees = GridEmployees.FindAll(e => e.EmpId.ToLower().Contains(SearchText.Text.ToLower().Trim()));
                            break;
                        default:
                            break;
                    }
                }
            }

            EmpGridView.RowCount = GridEmployees.Count;
        }
    }
}