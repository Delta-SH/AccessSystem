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
    public partial class OutEmployeeManagerForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Employee EmpEntity;
        private List<DepartmentInfo> Departments;
        private List<OrgEmployeeInfo> OrgEmployees;
        private List<OutEmployeeInfo> OutEmployees;
        private List<OutEmployeeInfo> GridEmployees;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public OutEmployeeManagerForm() {
            InitializeComponent();
            EmpEntity = new Employee();
            Departments = new List<DepartmentInfo>();
            OrgEmployees = new List<OrgEmployeeInfo>();
            OutEmployees = new List<OutEmployeeInfo>();
            GridEmployees = new List<OutEmployeeInfo>();
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void OutEmployeeManagerForm_Shown(object sender, EventArgs e) {
            try {
                BindSearchType();
                var TempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    Departments = Common.CurUser.Role.Departments;
                    OrgEmployees = EmpEntity.GetOrgEmployees(Common.CurUser.Role.RoleID);
                    OutEmployees = EmpEntity.GetOutEmployees(Common.CurUser.Role.RoleID);
                    BindEmployeesToTreeView(TempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    EmpTreeView.Nodes.Clear();
                    foreach (TreeNode tn in TempTreeView.Nodes) {
                        EmpTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (EmpTreeView.Nodes.Count > 0) {
                        var root = EmpTreeView.Nodes[0];
                        EmpTreeView.SelectedNode = root;
                        root.Expand();
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// OrgEmployees TreeView AfterSelect Event.
        /// </summary>
        private void EmpTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                //AddBtn.Enabled = ((IDValuePair<Int32, String>)e.Node.Tag).ID == 1;
                SearchText.Clear();
                BindOutEmployeesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.EmpTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sub Out Employees Checked Changed Event.
        /// </summary>
        private void SubEmpCB_CheckedChanged(object sender, EventArgs e) {
            try {
                BindOutEmployeesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.SubEmpCB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search Out Employees Click Event.
        /// </summary>
        private void SearchBtn_Click(object sender, EventArgs e) {
            try {
                BindOutEmployeesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.SeachBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Search Type SelectedIndex Changed Event.
        /// </summary>
        private void SearchType_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(SearchText.Text)) { return; }
                BindOutEmployeesToGridView();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.SearchType.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Out Employee GridView CellValue Needed Event.
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
                    case "SexColumn":
                        e.Value = GridEmployees[e.RowIndex].Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase) ? "男" : "女";
                        break;
                    case "CardIDColumn":
                        e.Value = GridEmployees[e.RowIndex].CardId;
                        break;
                    case "CardAddressColumn":
                        e.Value = GridEmployees[e.RowIndex].CardAddress;
                        break;
                    case "CardIssueColumn":
                        e.Value = GridEmployees[e.RowIndex].CardIssue;
                        break;
                    case "HometownColumn":
                        e.Value = GridEmployees[e.RowIndex].Hometown;
                        break;
                    case "CompanyNameColumn":
                        e.Value = GridEmployees[e.RowIndex].CompanyName;
                        break;
                    case "ProjectNameColumn":
                        e.Value = GridEmployees[e.RowIndex].ProjectName;
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
                    case "ParentNameColumn":
                        e.Value = String.Format("{0} - {1}", GridEmployees[e.RowIndex].ParentEmpId, GridEmployees[e.RowIndex].ParentEmpName);
                        break;
                    case "DepNameColumn":
                        e.Value = String.Format("{0} - {1}", GridEmployees[e.RowIndex].DepId, GridEmployees[e.RowIndex].DepName);
                        break;
                    case "CommentColumn":
                        e.Value = GridEmployees[e.RowIndex].Comment;
                        break;
                    case "EnabledColumn":
                        e.Value = GridEmployees[e.RowIndex].Enabled ? "启用" : "禁用";
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.EmpGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Out Employees GridView CellContent Click Event.
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
                        if (MessageBox.Show(String.Format("外协人员[{0},{1}]将被删除，您确定要删除吗?", obj.EmpId, obj.EmpName), "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                EmpEntity.DeleteOutEmployees(new List<OutEmployeeInfo>() { obj });
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                OutEmployees.Remove(obj);
                                GridEmployees.Remove(obj);
                                EmpGridView.Rows.RemoveAt(e.RowIndex);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OutEmployeeManagerForm.EmpGridView.CellContentClick", String.Format("删除外协人员:[{0},{1}]", obj.EmpId, obj.EmpName), null);
                            }
                        }
                        break;
                    case "EditColumn":
                        if (new SaveOutEmployeeForm(EnmSaveBehavior.Edit, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                            EmpGridView.InvalidateRow(e.RowIndex);
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.EmpGridView.CellContentClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add Out Employee.
        /// </summary>
        private void AddBtn_Click(object sender, EventArgs e) {
            try {
                var maxId = EmpEntity.GetMaxOutEmployeeID() + 1;
                OrgEmployeeInfo Employee = null;
                if (EmpTreeView.SelectedNode != null) {
                    var tag = (IDValuePair<Int32, String>)EmpTreeView.SelectedNode.Tag;
                    if (tag != null && tag.ID == 1) {
                        Employee = OrgEmployees.Find(oe => oe.EmpId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase));
                    }
                }

                var obj = new OutEmployeeInfo() {
                    ID = maxId,
                    EmpId = String.Format("{0:D8}", maxId),
                    EmpName = String.Empty,
                    Sex = "M",
                    CardId = String.Empty,
                    CardAddress = String.Empty,
                    CardIssue = String.Empty,
                    Hometown = String.Empty,
                    CompanyName = String.Empty,
                    ProjectName = String.Empty,
                    OfficePhone = String.Empty,
                    MobilePhone = String.Empty,
                    Email = String.Empty,
                    Comment = String.Empty,
                    DepId = Employee != null ? Employee.DepId : String.Empty,
                    DepName = Employee != null ? Employee.DepName : String.Empty,
                    ParentEmpId = Employee != null ? Employee.EmpId : String.Empty,
                    ParentEmpName = Employee != null ? Employee.EmpName : String.Empty,
                    Photo = null,
                    PhotoLayout = (int)ImageLayout.Zoom,
                    Enabled = true
                };

                if (new SaveOutEmployeeForm(EnmSaveBehavior.Add, obj).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    OutEmployees.Add(obj);
                    BindOutEmployeesToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.AddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Employees.
        /// </summary>
        private void DeleteBtn_Click(object sender, EventArgs e) {
            try {
                if (EmpGridView.Rows.Count > 0) {
                    if (MessageBox.Show("您确定要全部删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                        var result = Common.ShowWait(() => {
                            EmpEntity.DeleteOutEmployees(GridEmployees);
                        }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                        if (result == System.Windows.Forms.DialogResult.OK) {
                            foreach (var ge in GridEmployees) {
                                OutEmployees.Remove(ge);
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OutEmployeeManagerForm.DeleteBtn.Click", String.Format("删除外协人员:[{0},{1}]", ge.EmpId, ge.EmpName), null);
                            }
                            GridEmployees.Clear();
                            EmpGridView.Rows.Clear();
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.DeleteBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Export sub employees to excel.
        /// </summary>
        private void ExportBtn_Click(object sender, EventArgs e) {
            try {
                if (GridEmployees.Count > 0) {
                    var data = new DataTable();
                    data.Columns.Add("序号", typeof(String));
                    data.Columns.Add("工号", typeof(String));
                    data.Columns.Add("姓名", typeof(String));
                    data.Columns.Add("性别", typeof(String));
                    data.Columns.Add("身份证号", typeof(String));
                    data.Columns.Add("身份证住址", typeof(String));
                    data.Columns.Add("身份证签发机关", typeof(String));
                    data.Columns.Add("籍贯", typeof(String));
                    data.Columns.Add("所属公司", typeof(String));
                    data.Columns.Add("所属项目", typeof(String));
                    data.Columns.Add("办公电话", typeof(String));
                    data.Columns.Add("手机", typeof(String));
                    data.Columns.Add("Email", typeof(String));
                    data.Columns.Add("责任人", typeof(String));
                    data.Columns.Add("所属部门", typeof(String));
                    data.Columns.Add("备注", typeof(String));
                    data.Columns.Add("状态", typeof(String));
                    for (var i = 0; i < GridEmployees.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["工号"] = GridEmployees[i].EmpId;
                        dr["姓名"] = GridEmployees[i].EmpName;
                        dr["性别"] = GridEmployees[i].Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase) ? "男" : "女";
                        dr["身份证号"] = GridEmployees[i].CardId;
                        dr["身份证住址"] = GridEmployees[i].CardAddress;
                        dr["身份证签发机关"] = GridEmployees[i].CardIssue;
                        dr["籍贯"] = GridEmployees[i].Hometown;
                        dr["所属公司"] = GridEmployees[i].CompanyName;
                        dr["所属项目"] = GridEmployees[i].ProjectName;
                        dr["办公电话"] = GridEmployees[i].OfficePhone;
                        dr["手机"] = GridEmployees[i].MobilePhone;
                        dr["Email"] = GridEmployees[i].Email;
                        dr["责任人"] = String.Format("{0} - {1}", GridEmployees[i].ParentEmpId, GridEmployees[i].ParentEmpName);
                        dr["所属部门"] = String.Format("{0} - {1}", GridEmployees[i].DepId, GridEmployees[i].DepName);
                        dr["备注"] = GridEmployees[i].Comment;
                        dr["状态"] = GridEmployees[i].Enabled ? "启用" : "禁用";
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "外协人员信息", "智能门禁管理系统 外协人员信息报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.ExportBtn.Click", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(EmpTreeView);
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DepartmentManagerForm.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
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
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.OperationContext.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Selected Employees.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (EmpGridView.SelectedRows.Count > 0) {
                    var adEmps = new Dictionary<Int32, OutEmployeeInfo>();
                    foreach (DataGridViewRow row in EmpGridView.SelectedRows) {
                        var key = (String)row.Cells["EIDColumn"].Value;
                        var obj = GridEmployees.Find(ge => ge.EmpId.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                        if (obj != null) { adEmps[row.Index] = obj; }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中外协人员将被删除，您确定要删除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            var result = Common.ShowWait(() => {
                                EmpEntity.DeleteOutEmployees(adEmps.Select(ad => ad.Value).ToList());
                            }, default(String), "正在删除，请稍后...", default(Int32), default(Int32));

                            if (result == System.Windows.Forms.DialogResult.OK) {
                                foreach (var ae in adEmps) {
                                    OutEmployees.Remove(ae.Value);
                                    GridEmployees.Remove(ae.Value);
                                    EmpGridView.Rows.RemoveAt(ae.Key);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.OutEmployeeManagerForm.OpMenuItem1.Click", String.Format("删除外协人员:[{0},{1}]", ae.Value.EmpId, ae.Value.EmpName), null);
                                }
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeManagerForm.OpMenuItem1.Click", err.Message, err.StackTrace);
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
            if (new ImportDataForm(EnmImportType.Out).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                OutEmployees = EmpEntity.GetOutEmployees(Common.CurUser.Role.RoleID);
                BindOutEmployeesToGridView();
            }
        }

        /// <summary>
        /// Export Data Button Click Event.
        /// </summary>
        private void BExportBtn_Click(object sender, EventArgs e) {
            try {
                var data = new Employee().ExportOutEmployees(Common.CurUser.Role.RoleID);
                Common.ExportDataToExcel(null, "外协人员信息", "智能门禁管理系统 外协人员信息", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OrgEmployeeManagerForm.BExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind search type.
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
        /// Bind OrgEmployees To TreeView.
        /// </summary>
        private void BindEmployeesToTreeView(TreeView TempTreeView) {
            var root = TempTreeView.Nodes.Add("所有外协人员");
            root.Tag = new IDValuePair<Int32, String>(-1, "0");
            foreach (var dept in Departments) {
                var pDepat = Departments.Find(d => d.DepId.Equals(dept.LastDepId, StringComparison.CurrentCultureIgnoreCase));
                if (pDepat == null) {
                    var dnode = root.Nodes.Add(dept.DepName);
                    dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                    dnode.ImageKey = "Department";
                    dnode.SelectedImageKey = "Department";

                    BindEmployeesRecursion(dnode, dept.DepId);
                    var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                    foreach (var se in SubEmployees) {
                        var enode = dnode.Nodes.Add(se.EmpName);
                        enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                        enode.ImageKey = "Employee";
                        enode.SelectedImageKey = "Employee";
                    }
                }
            }
        }

        /// <summary>
        /// Bind Employees Recursion.
        /// </summary>
        private void BindEmployeesRecursion(TreeNode pNode, String pId) {
            if (Departments != null && Departments.Count > 0) {
                var SubDepartments = Departments.FindAll(d => d.LastDepId.Equals(pId, StringComparison.CurrentCultureIgnoreCase));
                if (SubDepartments.Count > 0) {
                    foreach (var dept in SubDepartments) {
                        var dnode = pNode.Nodes.Add(dept.DepName);
                        dnode.Tag = new IDValuePair<Int32, String>(0, dept.DepId);
                        dnode.ImageKey = "Department";
                        dnode.SelectedImageKey = "Department";

                        BindEmployeesRecursion(dnode, dept.DepId);
                        var SubEmployees = OrgEmployees.FindAll(emp => emp.DepId == dept.DepId);
                        foreach (var se in SubEmployees) {
                            var enode = dnode.Nodes.Add(se.EmpName);
                            enode.Tag = new IDValuePair<Int32, String>(1, se.EmpId);
                            enode.ImageKey = "Employee";
                            enode.SelectedImageKey = "Employee";
                        }
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
        /// Bind Out Employees To GridView.
        /// </summary>
        private void BindOutEmployeesToGridView() {
            GridEmployees.Clear();
            EmpGridView.Rows.Clear();
            if (EmpTreeView.SelectedNode != null) {
                var tag = (IDValuePair<Int32, String>)EmpTreeView.SelectedNode.Tag;
                if (tag != null) {
                    if (tag.ID == -1) {
                        GridEmployees.AddRange(OutEmployees);
                    } else if (tag.ID == 0) {
                        GridEmployees.AddRange(OutEmployees.FindAll(oe => oe.DepId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase)));
                        if (SubEmpCB.Checked) {
                            var SubDept = new List<DepartmentInfo>();
                            FindSubDeptRecursion(tag.Value, SubDept);
                            foreach (var sd in SubDept) {
                                GridEmployees.AddRange(OutEmployees.FindAll(e => e.DepId.Equals(sd.DepId, StringComparison.CurrentCultureIgnoreCase)));
                            }
                        }
                    } else if (tag.ID == 1) {
                        GridEmployees.AddRange(OutEmployees.FindAll(oe => oe.ParentEmpId.Equals(tag.Value, StringComparison.CurrentCultureIgnoreCase)));
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