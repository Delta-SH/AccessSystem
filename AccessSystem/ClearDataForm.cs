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
    public partial class ClearDataForm : Form
    {
        /// <summary>
        /// Class Constructor
        /// </summary>
        public ClearDataForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void ClearDataForm_Load(object sender, EventArgs e) {
            try {
                BindLogTypeCombobox1();
                BindLogTypeCombobox2();
                BeginDateDTP1.Value = DateTime.Today.AddDays(-60);
                EndDateDTP1.Value = DateTime.Today.AddDays(-29).AddSeconds(-1);
                BeginDateDTP2.Value = DateTime.Today.AddDays(-60);
                EndDateDTP2.Value = DateTime.Today.AddDays(-30);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ClearDataForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Log Type Combobox.
        /// </summary>
        private void BindLogTypeCombobox1() {
            var data = new List<object>();
            data.Add(new {
                ID = -1,
                Name = "所有类型"
            });

            foreach (EnmMsgType type in Enum.GetValues(typeof(EnmMsgType))) {
                data.Add(new {
                    ID = (int)type,
                    Name = ComUtility.GetLogTypeText(type)
                });
            }

            LogTypeCB1.ValueMember = "ID";
            LogTypeCB1.DisplayMember = "Name";
            LogTypeCB1.DataSource = data;
        }

        /// <summary>
        /// Bind Log Type Combobox.
        /// </summary>
        private void BindLogTypeCombobox2() {
            var data = new List<object>();
            data.Add(new {
                ID = -1,
                Name = "所有类型"
            });
            data.Add(new {
                ID = 0,
                Name = "系统日志"
            });
            data.Add(new {
                ID = 1,
                Name = "运行日志"
            });

            LogTypeCB2.ValueMember = "ID";
            LogTypeCB2.DisplayMember = "Name";
            LogTypeCB2.DataSource = data;
        }

        /// <summary>
        /// Clear Database Logs.
        /// </summary>
        private void ClearBtn1_Click(object sender, EventArgs e) {
            try {
                var beginDate = BeginDateDTP1.Value;
                var endDate = EndDateDTP1.Value;
                var logType = (Int32)LogTypeCB1.SelectedValue;
                var logTypeName = LogTypeCB1.Text;
                if (DateTime.Today.Subtract(new DateTime(beginDate.Year, beginDate.Month, beginDate.Day)).Days < 30
                || DateTime.Today.Subtract(new DateTime(endDate.Year, endDate.Month, endDate.Day)).Days < 30) {
                    MessageBox.Show("仅能清理30天前的日志记录", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("您确定要清理日志记录吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var result = Common.ShowWait(() => {
                        new Log().ClearDBLog(beginDate, endDate, logType);
                    }, default(String), "正在清理，请稍后...", default(Int32), default(Int32));

                    if (result == DialogResult.OK) {
                        Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.ClearDataForm.ClearBtn1.Click", String.Format("清理日志记录[开始日期:{0} 结束日期:{1} 日志类型:{2}]", Common.GetDateString(beginDate), Common.GetDateString(endDate), logTypeName), null);
                        MessageBox.Show("数据清理完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("数据清理失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ClearDataForm.ClearBtn1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clear Text Log Files.
        /// </summary>
        private void ClearBtn2_Click(object sender, EventArgs e) {
            try {
                var beginDate = BeginDateDTP2.Value;
                var endDate = EndDateDTP2.Value;
                var logType = (Int32)LogTypeCB2.SelectedValue;
                var logTypeName = LogTypeCB2.Text;
                if (DateTime.Today.Subtract(new DateTime(beginDate.Year, beginDate.Month, beginDate.Day)).Days < 30
                || DateTime.Today.Subtract(new DateTime(endDate.Year, endDate.Month, endDate.Day)).Days < 30) {
                    MessageBox.Show("仅能清理30天前的日志文件", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("您确定要清理日志文件吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var result = Common.ShowWait(() => {
                        new Log().ClearTxtLog(beginDate, endDate, logType);
                    }, default(String), "正在清理，请稍后...", default(Int32), default(Int32));

                    if (result == DialogResult.OK) {
                        Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.ClearDataForm.ClearBtn2.Click", String.Format("清理日志文件[开始日期:{0} 结束日期:{1} 日志类型:{2}]", Common.GetDateString(beginDate), Common.GetDateString(endDate), logTypeName), null);
                        MessageBox.Show("文件清理完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("文件清理失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ClearDataForm.ClearBtn2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
