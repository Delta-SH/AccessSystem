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
    public partial class SaveCardForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Card CardEntity;
        private CardInfo CurCard;
        private CardInfo OriCard;
        private EnmSaveBehavior CurBehavior;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveCardForm(EnmSaveBehavior Behavior, CardInfo Card) {
            InitializeComponent();
            CurBehavior = Behavior;
            CardEntity = new Card();
            CurCard = new CardInfo();
            OriCard = Card;
            Common.CopyObjectValues(OriCard, CurCard);
            Text = Behavior == EnmSaveBehavior.Add ? "新增持卡信息" : "编辑持卡信息";
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void SaveCardForm_Shown(object sender, EventArgs e) {
            try {
                SaveBtn.Enabled = false;
                if (CurBehavior == EnmSaveBehavior.Null || CurCard == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                BindCardTypeCombobox();
                BindCardReasonCombobox();
                CardSnTB.Focus();
                CardSnTB.ReadOnly = CurBehavior == EnmSaveBehavior.Edit;
                SetCardBtn.Enabled = CurBehavior == EnmSaveBehavior.Add;
                EmpNameTB.Text = String.IsNullOrWhiteSpace(CurCard.WorkerId) ? String.Empty : String.Format("{0} - {1}", CurCard.WorkerId, CurCard.WorkerName);
                CardSnTB.Text = CurCard.CardSn;
                CardTypeCB.SelectedValue = (Int32)CurCard.CardType;
                BeginTimeDTP.Value = CurCard.BeginTime;
                CardUIDTB.Text = CurCard.UID;
                CardPwdTB.Text = CurCard.Pwd;
                var reasonId = GetCardReasonID(CurCard.BeginReason);
                if (reasonId == 0) { BeginReasonTB.Text = CurCard.BeginReason; }
                BeginReasonCB.SelectedValue = reasonId;
                CommentTB.Text = CurCard.Comment;
                EnabledCB.Checked = CurCard.Enabled;
                SaveBtn.Enabled = true;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Employee Button Click Event.
        /// </summary>
        private void SetEmpBtn_Click(object sender, EventArgs e) {
            try {
                if (CurCard.WorkerType == EnmWorkerType.WXRY) {
                    var Dialog = new OutEmployeeDialog(false);
                    if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                        if (Dialog.SelectedItems.Count > 0) {
                            var StEmployee = Dialog.SelectedItems[0];
                            CurCard.DepId = StEmployee.DepId;
                            CurCard.DepName = StEmployee.DepName;
                            CurCard.WorkerId = StEmployee.EmpId;
                            CurCard.WorkerName = StEmployee.EmpName;
                            EmpNameTB.Text = String.Format("{0} - {1}", StEmployee.EmpId, StEmployee.EmpName);
                        }
                    }
                } else {
                    var Dialog = new OrgEmployeeDialog(false);
                    if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                        if (Dialog.SelectedItems.Count > 0) {
                            var StEmployee = Dialog.SelectedItems[0];
                            CurCard.DepId = StEmployee.DepId;
                            CurCard.DepName = StEmployee.DepName;
                            CurCard.WorkerId = StEmployee.EmpId;
                            CurCard.WorkerName = StEmployee.EmpName;
                            CurCard.WorkerType = StEmployee.EmpType;
                            EmpNameTB.Text = String.Format("{0} - {1}", StEmployee.EmpId, StEmployee.EmpName);
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardForm.SetEmpBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employee Name TextBox Double Click Event.
        /// </summary>
        private void EmpNameTB_DoubleClick(object sender, EventArgs e) {
            SetEmpBtn_Click(sender, e);
        }

        /// <summary>
        /// Set Card Sn Button Click Event.
        /// </summary>
        private void SetCardBtn_Click(object sender, EventArgs e) {
            try {
                var Dialog = new ConvertDialog();
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    if (!String.IsNullOrWhiteSpace(Dialog.CardSn)) {
                        CardSnTB.Text = Dialog.CardSn;
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardForm.SetCardBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Card Sn TextBox Key Press Event.
        /// </summary>
        private void CardSnTB_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar);
        }

        /// <summary>
        /// Begin Reason CheckBox SelectedIndex Changed Event.
        /// </summary>
        private void BeginReasonCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                BeginReasonTB.Enabled = Convert.ToInt32(BeginReasonCB.SelectedValue) == 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardForm.BeginReasonCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Card UID TextBox Key Press Event.
        /// </summary>
        private void CardUIDTB_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar);
        }

        /// <summary>
        /// Card Pwd TextBox Key Press Event.
        /// </summary>
        private void CardPwdTB_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar);
        }

        /// <summary>
        /// Save Card.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(CurCard.WorkerId)) {
                    EmpNameTB.Clear();
                    CurCard.DepId = String.Empty;
                    CurCard.DepName = String.Empty;
                    CurCard.WorkerId = String.Empty;
                    CurCard.WorkerName = String.Empty;
                    MessageBox.Show("请选择持卡员工", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(CardSnTB.Text)) {
                    CardSnTB.Focus();
                    MessageBox.Show("请输入卡号", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (CurBehavior == EnmSaveBehavior.Add && CardEntity.ExistCard(CardSnTB.Text.Trim())) {
                    CardSnTB.Focus();
                    MessageBox.Show("卡号已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //CurCard.WorkerId = null;
                //CurCard.WorkerType = null;
                //CurCard.WorkerName = null;
                //CurCard.DepId = null;
                //CurCard.DepName = null;
                CurCard.CardSn = CardSnTB.Text.Trim();
                CurCard.CardType = ComUtility.DBNullCardTypeHandler(CardTypeCB.SelectedValue);
                CurCard.UID = String.IsNullOrWhiteSpace(CardUIDTB.Text) ? "00000000" : CardUIDTB.Text.Trim().PadLeft(8, '0');
                CurCard.Pwd = String.IsNullOrWhiteSpace(CardPwdTB.Text) ? "0000" : CardPwdTB.Text.Trim().PadLeft(4, '0');
                CurCard.BeginTime = BeginTimeDTP.Value;
                CurCard.BeginReason = Convert.ToInt32(BeginReasonCB.SelectedValue) == 0 ? BeginReasonTB.Text.Trim() : BeginReasonCB.Text;
                CurCard.Comment = CommentTB.Text.Trim();
                CurCard.Enabled = EnabledCB.Checked;
                var result = Common.ShowWait(() => {
                    CardEntity.SaveCards(new List<CardInfo> { CurCard });
                }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                if (result == DialogResult.OK) {
                    Common.CopyObjectValues(CurCard, OriCard);
                    Common.WriteLog(DateTime.Now, CurBehavior == EnmSaveBehavior.Add ? EnmMsgType.Cardin : EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveCardForm.SaveBtn.Click", String.Format("{0}卡片:[{1} - {2},{3}]", CurBehavior == EnmSaveBehavior.Add ? "新增" : "更新", CurCard.CardSn, CurCard.WorkerId, CurCard.WorkerName), null);
                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Card Type Combobox.
        /// </summary>
        private void BindCardTypeCombobox() {
            var data = new List<object>();
            foreach (EnmCardType type in Enum.GetValues(typeof(EnmCardType))) {
                data.Add(new {
                    ID = (Int32)type,
                    Name = ComUtility.GetCardTypeText(type)
                });
            }

            CardTypeCB.ValueMember = "ID";
            CardTypeCB.DisplayMember = "Name";
            CardTypeCB.DataSource = data;
        }

        /// <summary>
        /// Bind Card Reason Combobox.
        /// </summary>
        private void BindCardReasonCombobox() {
            var data = new List<object>();
            data.Add(new { ID = 1, Name = "员工入职" });
            data.Add(new { ID = 2, Name = "卡片丢失" });
            data.Add(new { ID = 3, Name = "卡片人为损坏" });
            data.Add(new { ID = 4, Name = "卡片自然损坏" });
            data.Add(new { ID = 0, Name = "其他原因" });

            BeginReasonCB.ValueMember = "ID";
            BeginReasonCB.DisplayMember = "Name";
            BeginReasonCB.DataSource = data;
        }

        /// <summary>
        /// Get Card Reason ID
        /// </summary>
        private Int32 GetCardReasonID(String reason) {
            reason = reason.Trim();
            switch (reason) {
                case "员工入职":
                    return 1;
                case "卡片丢失":
                    return 2;
                case "卡片认为损坏":
                    return 3;
                case "卡片自然损坏":
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
