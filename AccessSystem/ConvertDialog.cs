using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delta.MPS.Model;

namespace Delta.MPS.AccessSystem
{
    public partial class ConvertDialog : Form
    {
        /// <summary>
        /// XCardSn
        /// </summary>
        public String XCardSn { get; private set; }

        /// <summary>
        /// CardSn
        /// </summary>
        public String CardSn { get; private set; }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public ConvertDialog() {
            InitializeComponent();
        }

        /// <summary>
        /// CardXSn TextBox KeyPress Event.
        /// </summary>
        private void CardXSnTB_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && (e.KeyChar < 'a' || e.KeyChar > 'f') && (e.KeyChar < 'A' || e.KeyChar > 'F');
        }

        /// <summary>
        /// CardXSn TextBox Text Changed Event.
        /// </summary>
        private void CardXSnTB_TextChanged(object sender, EventArgs e) {
            try {
                CardSnTB.TextChanged -= CardSnTB_TextChanged;
                if (String.IsNullOrWhiteSpace(CardXSnTB.Text)) {
                    CardSnTB.Clear();
                    CardSnTB.ReadOnly = false;
                } else {
                    CardSnTB.Text = Common.GetCardSn16to10(CardXSnTB.Text);
                    CardSnTB.ReadOnly = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ConvertDialog.CardXIDTB.TextChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                CardSnTB.TextChanged += CardSnTB_TextChanged;
            }
        }

        /// <summary>
        /// CardSn TextBox KeyPress Event.
        /// </summary>
        private void CardSnTB_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar);
        }

        /// <summary>
        /// CardSn TextBox Text Changed Event.
        /// </summary>
        private void CardSnTB_TextChanged(object sender, EventArgs e) {
            try {
                CardXSnTB.TextChanged -= CardXSnTB_TextChanged;
                if (String.IsNullOrWhiteSpace(CardSnTB.Text)) {
                    CardXSnTB.Clear();
                    CardXSnTB.ReadOnly = false;
                } else {
                    CardXSnTB.Text = Common.GetCardSn10to16(CardSnTB.Text);
                    CardXSnTB.ReadOnly = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ConvertDialog.CardIDTB.TextChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                CardXSnTB.TextChanged += CardXSnTB_TextChanged;
            }
        }

        /// <summary>
        /// Ok Button Click Event.
        /// </summary>
        private void OKBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(CardSnTB.Text)) {
                    CardSnTB.Focus();
                    MessageBox.Show("请输入十进制卡号", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(CardXSnTB.Text)) {
                    CardXSnTB.Focus();
                    MessageBox.Show("请输入十六进制卡号", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CardSn = CardSnTB.Text.Trim();
                XCardSn = CardXSnTB.Text.Trim();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ConvertDialog.OKBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
