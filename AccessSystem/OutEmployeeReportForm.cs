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

namespace Delta.MPS.AccessSystem
{
    public partial class OutEmployeeReportForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private List<ValuesPair<OutEmployeeInfo, CardInfo, Int32, object, object>> CurRecords;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public OutEmployeeReportForm() {
            InitializeComponent();
            CurRecords = new List<ValuesPair<OutEmployeeInfo, CardInfo, Int32, object, object>>();
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void OutEmployeeReportForm_Load(object sender, EventArgs e) {
            try {
                BindDeptToCombobox();
                BindQueryTypeToCombobox();
                BindCardTypeToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeReportForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Deptments Button Click Event.
        /// </summary>
        private void DeptBtn_Click(object sender, EventArgs e) {
            try {
                var Dialog = new DepartmentDialog(true);
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    if (Dialog.SelectedItems.Count > 0) {
                        var data = new List<IDValuePair<String, String>>();
                        foreach (var dept in Dialog.SelectedItems) {
                            data.Add(new IDValuePair<String, String>(dept.DepId, dept.DepName));
                        }

                        DeptLB.DataSource = data;
                        DeptLB.ValueMember = "ID";
                        DeptLB.DisplayMember = "Value";
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeReportForm.DeptBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Query Button Click Event.
        /// </summary>
        private void QueryBtn_Click(object sender, EventArgs e) {
            try {
                CurRecords.Clear();
                EmpGridView.Rows.Clear();

                var departments = new List<String>();
                foreach (IDValuePair<String, String> dt in DeptLB.Items) {
                    departments.Add(dt.ID);
                }

                var cardType = (Int32)CardTypeCB.SelectedValue;
                var queryIndex = (Int32)QueryTypeCB.SelectedValue;
                var queryText = QueryTypeTB.Text;

                var result = Common.ShowWait(() => {
                    var employees = new Employee().GetOutEmployees(Common.CurUser.Role.RoleID);
                    var cardAuths = new CardAuth().GetCardAuthCount();
                    var cards = from c in Common.CurUser.Role.Cards
                                join ca in cardAuths on c.CardSn equals ca.ID into tp
                                from ta in tp.DefaultIfEmpty()
                                where c.WorkerType == EnmWorkerType.WXRY
                                select new {
                                    Card = c,
                                    Auth = ta
                                };

                    CurRecords = (from emp in employees
                                  join dep in departments on emp.DepId equals dep
                                  join c in cards on emp.EmpId equals c.Card.WorkerId into tp
                                  from tc in tp.DefaultIfEmpty()
                                  where cardType == 0 || (cardType == 1 && tc != null) || (cardType == 2 && tc == null)
                                  orderby emp.EmpId
                                  select new ValuesPair<OutEmployeeInfo, CardInfo, Int32, object, object> {
                                      Value1 = emp,
                                      Value2 = tc != null ? tc.Card : null,
                                      Value3 = tc != null && tc.Auth != null ? tc.Auth.Value : 0,
                                      Value4 = null,
                                      Value5 = null
                                  }).ToList();

                    if (!String.IsNullOrWhiteSpace(queryText)) {
                        var filters = queryText.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        switch (queryIndex) {
                            case 0:
                                CurRecords = CurRecords.FindAll(rec => {
                                    foreach (var f in filters) {
                                        if (rec.Value1.EmpId.Contains(f.Trim())) { return true; }
                                    }
                                    return false;
                                });
                                break;
                            case 1:
                                CurRecords = CurRecords.FindAll(rec => {
                                    foreach (var f in filters) {
                                        if (rec.Value1.EmpName.Equals(f.Trim(), StringComparison.CurrentCultureIgnoreCase)) { return true; }
                                    }
                                    return false;
                                });
                                break;
                            case 2:
                                CurRecords = CurRecords.FindAll(rec => {
                                    if (String.IsNullOrWhiteSpace(rec.Value1.ParentEmpId)) { return false; }
                                    foreach (var f in filters) {
                                        if (rec.Value1.ParentEmpId.Contains(f.Trim())) { return true; }
                                    }
                                    return false;
                                });
                                break;
                            case 3:
                                CurRecords = CurRecords.FindAll(rec => {
                                    if (String.IsNullOrWhiteSpace(rec.Value1.ParentEmpName)) { return false; }
                                    foreach (var f in filters) {
                                        if (rec.Value1.ParentEmpName.Equals(f.Trim(), StringComparison.CurrentCultureIgnoreCase)) { return true; }
                                    }
                                    return false;
                                });
                                break;
                            case 4:
                                CurRecords = CurRecords.FindAll(rec => {
                                    if (rec.Value2 == null) { return false; }
                                    foreach (var f in filters) {
                                        if (rec.Value2.CardSn.Contains(f.Trim())) { return true; }
                                    }
                                    return false;
                                });
                                break;
                            default:
                                break;
                        }
                    }
                }, default(string), "正在查询，请稍后...", default(int), default(int));

                if (result == DialogResult.OK) {
                    EmpGridView.RowCount = CurRecords.Count;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeReportForm.DeptBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employees GridView Cell Value Needed Event.
        /// </summary>
        private void EmpGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurRecords.Count - 1) { return; }
                switch (EmpGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EIDColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.EmpId;
                        break;
                    case "NameColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.EmpName;
                        break;
                    case "SexColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase) ? "男" : "女";
                        break;
                    case "CardIDColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.CardId;
                        break;
                    case "CardAddressColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.CardAddress;
                        break;
                    case "CardIssueColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.CardIssue;
                        break;
                    case "HometownColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.Hometown;
                        break;
                    case "CompanyNameColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.CompanyName;
                        break;
                    case "ProjectNameColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.ProjectName;
                        break;
                    case "OfficePhoneColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.OfficePhone;
                        break;
                    case "MobilePhoneColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.MobilePhone;
                        break;
                    case "EmailColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.Email;
                        break;
                    case "ParentNameColumn":
                        e.Value = String.Format("{0} - {1}", CurRecords[e.RowIndex].Value1.ParentEmpId, CurRecords[e.RowIndex].Value1.ParentEmpName);
                        break;
                    case "DepNameColumn":
                        e.Value = String.Format("{0} - {1}", CurRecords[e.RowIndex].Value1.DepId, CurRecords[e.RowIndex].Value1.DepName);
                        break;
                    case "CommentColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.Comment;
                        break;
                    case "EnabledColumn":
                        e.Value = CurRecords[e.RowIndex].Value1.Enabled ? "启用" : "禁用";
                        break;
                    case "CardSnColumn":
                        e.Value = CurRecords[e.RowIndex].Value2 != null ? CurRecords[e.RowIndex].Value2.CardSn : String.Empty;
                        break;
                    case "CardAuthColumn":
                        e.Value = CurRecords[e.RowIndex].Value3;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeReportForm.EmpGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employees GridView Cell Double Click Event.
        /// </summary>
        private void EmpGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }
                if (!EmpGridView.Columns[e.ColumnIndex].Name.Equals("CardAuthColumn")) { return; }
                var key = (String)EmpGridView.Rows[e.RowIndex].Cells["EIDColumn"].Value;
                var obj = CurRecords.Find(rec => rec.Value1.EmpId.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                if (obj == null) {
                    MessageBox.Show("未找到相关数据项", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                new DevAuthDetailDialog(obj.Value1).ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeReportForm.EmpGridView.CellDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Menu Opening Event.
        /// </summary>
        private void RecordContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            RecMenuItem1.Enabled = EmpGridView.Rows.Count > 0;
        }

        /// <summary>
        /// Menu Item Click Event.
        /// </summary>
        private void RecMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (CurRecords.Count > 0) {
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
                    data.Columns.Add("关联卡片", typeof(String));
                    data.Columns.Add("授权设备", typeof(String));
                    for (var i = 0; i < CurRecords.Count; i++) {
                        var dr = data.NewRow();
                        dr["序号"] = i + 1;
                        dr["工号"] = CurRecords[i].Value1.EmpId;
                        dr["姓名"] = CurRecords[i].Value1.EmpName;
                        dr["性别"] = CurRecords[i].Value1.Sex.Equals("M", StringComparison.CurrentCultureIgnoreCase) ? "男" : "女";
                        dr["身份证号"] = CurRecords[i].Value1.CardId;
                        dr["身份证住址"] = CurRecords[i].Value1.CardAddress;
                        dr["身份证签发机关"] = CurRecords[i].Value1.CardIssue;
                        dr["籍贯"] = CurRecords[i].Value1.Hometown;
                        dr["所属公司"] = CurRecords[i].Value1.CompanyName;
                        dr["所属项目"] = CurRecords[i].Value1.ProjectName;
                        dr["办公电话"] = CurRecords[i].Value1.OfficePhone;
                        dr["手机"] = CurRecords[i].Value1.MobilePhone;
                        dr["Email"] = CurRecords[i].Value1.Email;
                        dr["责任人"] = String.Format("{0} - {1}", CurRecords[i].Value1.ParentEmpId, CurRecords[i].Value1.ParentEmpName);
                        dr["所属部门"] = String.Format("{0} - {1}", CurRecords[i].Value1.DepId, CurRecords[i].Value1.DepName);
                        dr["备注"] = CurRecords[i].Value1.Comment;
                        dr["状态"] = CurRecords[i].Value1.Enabled ? "启用" : "禁用";
                        dr["关联卡片"] = CurRecords[i].Value2 != null ? CurRecords[i].Value2.CardSn : String.Empty;
                        dr["授权设备"] = CurRecords[i].Value3.ToString();
                        data.Rows.Add(dr);
                    }

                    Common.ExportDataToExcel(null, "外协人员信息", "智能门禁管理系统 外协人员信息报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.OutEmployeeReportForm.ExportBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Record Type To Combobox.
        /// </summary>
        private void BindDeptToCombobox() {
            var data = new List<IDValuePair<String, String>>();
            foreach (var dept in Common.CurUser.Role.Departments) {
                data.Add(new IDValuePair<String, String>(dept.DepId, dept.DepName));
            }

            DeptLB.DataSource = data;
            DeptLB.ValueMember = "ID";
            DeptLB.DisplayMember = "Value";
        }

        /// <summary>
        /// Bind Query Type To Combobox.
        /// </summary>
        private void BindQueryTypeToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(0, "按外协工号查询"));
            data.Add(new IDValuePair<Int32, String>(1, "按外协姓名查询"));
            data.Add(new IDValuePair<Int32, String>(2, "按责任人工号查询"));
            data.Add(new IDValuePair<Int32, String>(3, "按责任人姓名查询"));
            data.Add(new IDValuePair<Int32, String>(4, "按卡号查询"));

            QueryTypeCB.ValueMember = "ID";
            QueryTypeCB.DisplayMember = "Value";
            QueryTypeCB.DataSource = data;
        }

        /// <summary>
        /// Bind Card Type To Combobox.
        /// </summary>
        private void BindCardTypeToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(0, "全部人员"));
            data.Add(new IDValuePair<Int32, String>(1, "已发卡人员"));
            data.Add(new IDValuePair<Int32, String>(2, "未发卡人员"));

            CardTypeCB.ValueMember = "ID";
            CardTypeCB.DisplayMember = "Value";
            CardTypeCB.DataSource = data;
        }
    }
}
