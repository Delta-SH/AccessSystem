using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using Delta.MPS.Model;
using Delta.MPS.SQLServerDAL;

namespace Delta.MPS.AccessSystem
{
    public partial class ImportDataForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private DataTable ExcelDataTable;
        private EnmImportType ImportType; 

        /// <summary>
        /// Class Constructor
        /// </summary>
        public ImportDataForm(EnmImportType importType) {
            InitializeComponent();
            ImportType = importType;
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void ImportDataForm_Load(object sender, EventArgs e) {
            try {
                SheetCB.Enabled = false;
                QueryBtn.Enabled = false;
                SaveBtn.Enabled = false;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ImportDataForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// File TextBox Double Click Event.
        /// </summary>
        private void FileTB_DoubleClick(object sender, EventArgs e) {
            BrowserBtn_Click(sender, e);
        }

        /// <summary>
        /// Browser Button Click Event.
        /// </summary>
        private void BrowserBtn_Click(object sender, EventArgs e) {
            try {
                if (DataFileDialog.ShowDialog() == DialogResult.OK) {
                    var filePath = DataFileDialog.FileName;
                    var sheetNames = GetSheetNames(filePath);
                    if (sheetNames != null) {
                        FileTB.Text = filePath;
                        SheetCB.Enabled = sheetNames.Count > 0;
                        QueryBtn.Enabled = sheetNames.Count > 0;
                        SaveBtn.Enabled = false;
                        SheetCB.DataSource = sheetNames;
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ImportDataForm.BrowserBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Query Button Click Event.
        /// </summary>
        private void QueryBtn_Click(object sender, EventArgs e) {
            try {
                ExcelDataTable = GetDataTable(FileTB.Text, SheetCB.Text);
                ImportDataGridView.DataSource = ExcelDataTable;
                SaveBtn.Enabled = ExcelDataTable != null && ExcelDataTable.Rows.Count > 0;
                if (ExcelDataTable != null && ExcelDataTable.Rows.Count > 0) {
                    SaveBtn.Enabled = true;
                    RowCountLbl.Text = String.Format("共计 {0} 条记录", ExcelDataTable.Rows.Count);
                } else {
                    SaveBtn.Enabled = false;
                    RowCountLbl.Text = "共计 0 条记录";
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ImportDataForm.QueryBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save Button Click Event.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                if (ExcelDataTable == null || ExcelDataTable.Rows.Count == 0) {
                    MessageBox.Show("无数据记录", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("您确定要保存吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var result = Common.ShowWait(() => {
                        switch (ImportType) {
                            case EnmImportType.Org:
                                new Employee().ImportOrgEmployees(ExcelDataTable);
                                break;
                            case EnmImportType.Out:
                                new Employee().ImportOutEmployees(ExcelDataTable);
                                break;
                            default:
                                break;
                        }
                    }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                    if (result == DialogResult.OK) {
                        MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    } else {
                        MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ImportDataForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sheet Combobox SelectedIndex Changed Event.
        /// </summary>
        private void SheetCB_SelectedIndexChanged(object sender, EventArgs e) {
            QueryBtn_Click(sender, e);
        }

        /// <summary>
        /// Get OleDbConnection String.
        /// </summary>
        private String GetOleDbConnectionString(String filePath) {
            var extension = Path.GetExtension(filePath);
            var excelObject = "Provider=Microsoft.Ace.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel {1};HDR=YES\"";
            if (extension.Equals(".xls", StringComparison.CurrentCultureIgnoreCase)) {
                return String.Format(excelObject, filePath, "8.0");
            } else if (extension.Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase)) {
                return String.Format(excelObject, filePath, "12.0");
            } else {
                MessageBox.Show(String.Format("不支持{0}文件格式", extension), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        /// <summary>
        /// Get Sheet Names.
        /// </summary>
        private List<object> GetSheetNames(String filePath) {
            var connectionString = GetOleDbConnectionString(filePath);
            if (!String.IsNullOrWhiteSpace(connectionString)) {
                using (var conn = new OleDbConnection(connectionString)) {
                    if (conn.State != ConnectionState.Open) { conn.Open(); }
                    var dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                    if (dtSchema != null) {
                        return (from dr in dtSchema.AsEnumerable() select dr["TABLE_NAME"]).ToList();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get Excel DateTable.
        /// </summary>
        private DataTable GetDataTable(String filePath, String tableName) {
            var connectionString = GetOleDbConnectionString(filePath);
            if (!String.IsNullOrWhiteSpace(connectionString)) {
                using (var conn = new OleDbConnection(connectionString)) {
                    if (conn.State != ConnectionState.Open) { conn.Open(); }
                    using (var cmd = new OleDbCommand(String.Format("Select * from [{0}]", tableName), conn)) {
                        var dtResult = new DataTable();
                        var adpt = new OleDbDataAdapter(cmd);
                        adpt.Fill(dtResult);
                        return dtResult;
                    }
                }
            }
            return null;
        }
    }
}
