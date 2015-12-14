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
    public partial class BatchOutCardsForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Card CardEntity;
        private List<OutEmployeeInfo> Employees;
        private Dictionary<String, CardInfo> ExistCards;
        private List<IDValuePair<CardInfo, OutEmployeeInfo>> Cards;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public BatchOutCardsForm() {
            InitializeComponent();
            CardEntity = new Card();
            Employees = new List<OutEmployeeInfo>();
            ExistCards = new Dictionary<String, CardInfo>();
            Cards = new List<IDValuePair<CardInfo, OutEmployeeInfo>>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void BatchOutCardsForm_Load(object sender, EventArgs e) {
            try {
                BindCardTypeCombobox();
                BindCardReasonCombobox();
                CardTypeCB.SelectedValue = (Int32)EnmCardType.LSK;
                BeginTimeDTP.Value = DateTime.Now;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set Employees Button Click
        /// </summary>
        private void SetEmpBtn_Click(object sender, EventArgs e) {
            try {
                var Dialog = new OutEmployeeDialog(true);
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    Employees.Clear();
                    if (Dialog.SelectedItems.Count > 0) {
                        Employees.AddRange(Dialog.SelectedItems);
                    }
                    BindEmployeesToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.SetEmpBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Employee GridView CellValue Needed Event.
        /// </summary>
        private void EmpGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > Employees.Count - 1) { return; }
                switch (EmpGridView.Columns[e.ColumnIndex].Name) {
                    case "EIDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "EEIDColumn":
                        e.Value = Employees[e.RowIndex].EmpId;
                        break;
                    case "EENameColumn":
                        e.Value = String.Format("{0} - {1}", Employees[e.RowIndex].EmpId, Employees[e.RowIndex].EmpName);
                        break;
                    case "EDeptColumn":
                        e.Value = String.Format("{0} - {1}", Employees[e.RowIndex].DepId, Employees[e.RowIndex].DepName);
                        break;
                    case "PEIDColumn":
                        e.Value = String.Format("{0} - {1}", Employees[e.RowIndex].ParentEmpId, Employees[e.RowIndex].ParentEmpName);
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.EmpGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Operation Context Menu Opening Event.
        /// </summary>
        private void OperationContext_Opening(object sender, CancelEventArgs e) {
            try {
                OpMenuItem1.Enabled = EmpGridView.SelectedRows.Count > 0;
                OpMenuItem2.Enabled = EmpGridView.Rows.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.OperationContext.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Remove Selected Employees.
        /// </summary>
        private void OpMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (EmpGridView.SelectedRows.Count > 0) {
                    var adEmps = new Dictionary<Int32, OutEmployeeInfo>();
                    foreach (DataGridViewRow row in EmpGridView.SelectedRows) {
                        var key = (String)row.Cells["EEIDColumn"].Value;
                        var obj = Employees.Find(ee => ee.EmpId.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                        if (obj != null) { adEmps[row.Index] = obj; }
                    }

                    if (adEmps.Count > 0) {
                        if (MessageBox.Show("选中人员将被移除，您确定要移除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                            foreach (var ae in adEmps) {
                                Employees.Remove(ae.Value);
                                EmpGridView.Rows.RemoveAt(ae.Key);
                            }
                        }
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.OpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Remove All Employees.
        /// </summary>
        private void OpMenuItem2_Click(object sender, EventArgs e) {
            try {
                if (MessageBox.Show("您确定要全部移除吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    Employees.Clear();
                    EmpGridView.Rows.Clear();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.OpMenuItem2.Click", err.Message, err.StackTrace);
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
        /// Begin Reason CheckBox SelectedIndex Changed Event.
        /// </summary>
        private void BeginReasonCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                BeginReasonTB.Enabled = Convert.ToInt32(BeginReasonCB.SelectedValue) == 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.BeginReasonCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CardID TextBox KeyDown Event.
        /// </summary>
        private void CardIDTB_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyCode == Keys.Enter && ReadBtn.Tag.Equals("1") && !String.IsNullOrWhiteSpace(CardIDTB.Text)) {
                    ReadCard();
                    CardIDTB.Clear();
                    CardIDTB.Focus();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.CardIDTB.KeyDown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CardID TextBox Key Press Event.
        /// </summary>
        private void CardIDTB_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar);
        }

        /// <summary>
        /// CardID TextBox Text Changed Event.
        /// </summary>
        private void CardIDTB_TextChanged(object sender, EventArgs e) {
            try {
                CardXIDTB.TextChanged -= CardXIDTB_TextChanged;
                if (String.IsNullOrWhiteSpace(CardIDTB.Text)) {
                    CardXIDTB.Clear();
                } else {
                    CardXIDTB.Text = Common.GetCardSn10to16(CardIDTB.Text);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.CardIDTB.TextChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                CardXIDTB.TextChanged += CardXIDTB_TextChanged;
            }
        }

        /// <summary>
        /// CardXID TextBox Key Down Event.
        /// </summary>
        private void CardXIDTB_KeyDown(object sender, KeyEventArgs e) {
            try {
                if (e.KeyCode == Keys.Enter && ReadBtn.Tag.Equals("1") && !String.IsNullOrWhiteSpace(CardIDTB.Text)) {
                    ReadCard();
                    CardXIDTB.Clear();
                    CardXIDTB.Focus();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.CardXIDTB.KeyDown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CardXID TextBox Key Press Event.
        /// </summary>
        private void CardXIDTB_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) && (e.KeyChar < 'a' || e.KeyChar > 'f') && (e.KeyChar < 'A' || e.KeyChar > 'F');
        }

        /// <summary>
        /// CardXID TextBox Text Changed Event.
        /// </summary>
        private void CardXIDTB_TextChanged(object sender, EventArgs e) {
            try {
                CardIDTB.TextChanged -= CardIDTB_TextChanged;
                if (String.IsNullOrWhiteSpace(CardXIDTB.Text)) {
                    CardIDTB.Clear();
                } else {
                    CardIDTB.Text = Common.GetCardSn16to10(CardXIDTB.Text);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchCardsForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                CardIDTB.TextChanged += CardIDTB_TextChanged;
            }
        }

        /// <summary>
        /// Enabled CardXID Checked Changed Event.
        /// </summary>
        private void EnabledXIDCB_CheckedChanged(object sender, EventArgs e) {
            CardIDTB.Enabled = !EnabledXIDCB.Checked;
            CardXIDTB.Enabled = EnabledXIDCB.Checked;
        }

        /// <summary>
        /// Read Card Button Click Event.
        /// </summary>
        private void ReadBtn_Click(object sender, EventArgs e) {
            try {
                if (ReadBtn.Tag.Equals("0") && EmpGridView.Rows.Count == 0) {
                    MessageBox.Show("请选择需要发卡的员工", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SetEmpBtn.Enabled =
                EmpGridView.Enabled =
                CardTypeCB.Enabled =
                BeginTimeDTP.Enabled =
                BeginReasonCB.Enabled =
                EnabledXIDCB.Enabled =
                OKBtn.Enabled =
                CardUIDTB.Enabled =
                CardPwdTB.Enabled = !ReadBtn.Tag.Equals("0");
                BeginReasonTB.Enabled = !ReadBtn.Tag.Equals("0") && Convert.ToInt32(BeginReasonCB.SelectedValue) == 0;
                if (ReadBtn.Tag.Equals("0")) {
                    ExistCards.Clear();
                    if (EnabledXIDCB.Checked) {
                        CardXIDTB.Focus();
                    } else {
                        CardIDTB.Focus();
                    }

                    ReadBtn.Tag = "1";
                    ReadBtn.Text = "停止读卡(&P)";
                } else {
                    ReadBtn.Tag = "0";
                    ReadBtn.Text = "开始读卡(&R)";
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.ReadBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Read Card.
        /// </summary>
        private void ReadCard() {
            if (EmpGridView.Rows.Count == 0) {
                MessageBox.Show("请选择需要发卡的人员", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var key = (String)EmpGridView.Rows[0].Cells["EEIDColumn"].Value;
            var obj = Employees.Find(es => es.EmpId.Equals(key, StringComparison.CurrentCultureIgnoreCase));
            if (obj == null) {
                MessageBox.Show(String.Format("未查询到人员信息[工号: {0}]", key), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Cards.Any(c => c.ID.CardSn.Equals(CardIDTB.Text.Trim()))) {
                MessageBox.Show("完成列表中已存在该卡号", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var card = new CardInfo() {
                WorkerId = obj.EmpId,
                WorkerType = EnmWorkerType.WXRY,
                WorkerName = obj.EmpName,
                DepId = obj.DepId,
                DepName = obj.DepName,
                CardSn = CardIDTB.Text.Trim(),
                CardType = ComUtility.DBNullCardTypeHandler(CardTypeCB.SelectedValue),
                UID = String.IsNullOrWhiteSpace(CardUIDTB.Text) ? "00000000" : CardUIDTB.Text.Trim().PadLeft(8, '0'),
                Pwd = String.IsNullOrWhiteSpace(CardPwdTB.Text) ? "0000" : CardPwdTB.Text.Trim().PadLeft(4, '0'),
                BeginTime = BeginTimeDTP.Value,
                BeginReason = Convert.ToInt32(BeginReasonCB.SelectedValue) == 0 ? BeginReasonTB.Text.Trim() : BeginReasonCB.Text,
                Comment = "批量发卡",
                Enabled = true
            };

            EmpGridView.Rows.RemoveAt(0);
            Employees.Remove(obj);
            Cards.Add(new IDValuePair<CardInfo, OutEmployeeInfo>(card, obj));
            BindCardsToGridView();

            if (EmpGridView.Rows.Count == 0) {
                Employees.Clear();
                MessageBox.Show("批量发卡已完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadBtn_Click(null, null);
            }
        }

        /// <summary>
        /// Cards GridView CellValue Needed Event.
        /// </summary>
        private void CardsGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > Cards.Count - 1) { return; }
                switch (CardsGridView.Columns[e.ColumnIndex].Name) {
                    case "SIDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "SENameColumn":
                        e.Value = String.Format("{0} - {1}", Cards[e.RowIndex].Value.EmpId, Cards[e.RowIndex].Value.EmpName);
                        break;
                    case "CardSnColumn":
                        e.Value = Cards[e.RowIndex].ID.CardSn;
                        if (ExistCards.ContainsKey(e.Value.ToString())) {
                            CardsGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Salmon;
                        }
                        break;
                    case "SDeptColumn":
                        e.Value = String.Format("{0} - {1}", Cards[e.RowIndex].Value.DepId, Cards[e.RowIndex].Value.DepName);
                        break;
                    case "CardTypeColumn":
                        e.Value = ComUtility.GetCardTypeText(Cards[e.RowIndex].ID.CardType);
                        break;
                    case "BeginTimeColumn":
                        e.Value = Common.GetDateTimeString(Cards[e.RowIndex].ID.BeginTime);
                        break;
                    case "BeginReasonColumn":
                        e.Value = Cards[e.RowIndex].ID.BeginReason;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.CardsGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sign Cards Context Menu Opening Event.
        /// </summary>
        private void SignContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            try {
                SignToolStripMenuItem1.Enabled = CardsGridView.SelectedRows.Count > 0;
                SignToolStripMenuItem2.Enabled = CardsGridView.Rows.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.SignContextMenuStrip.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reread Selected Cards.
        /// </summary>
        private void SignToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (CardsGridView.SelectedRows.Count > 0 && MessageBox.Show("您确定要对选中行重新读卡吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    foreach (DataGridViewRow row in CardsGridView.SelectedRows) {
                        var key = (String)row.Cells["CardSnColumn"].Value;
                        var obj = Cards.Find(c => c.ID.CardSn.Equals(key, StringComparison.CurrentCultureIgnoreCase));
                        if (obj != null) {
                            Cards.Remove(obj);
                            if (!Employees.Any(es => es.EmpId.Equals(obj.Value.EmpId, StringComparison.CurrentCultureIgnoreCase))) {
                                Employees.Add(obj.Value);
                            }
                        }
                    }

                    BindEmployeesToGridView();
                    BindCardsToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.SignToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reread All Cards.
        /// </summary>
        private void SignToolStripMenuItem2_Click(object sender, EventArgs e) {
            try {
                if (CardsGridView.Rows.Count > 0 && MessageBox.Show("您确定要对所有行重新读卡吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    foreach (var c in Cards) {
                        if (!Employees.Any(es => es.EmpId.Equals(c.Value.EmpId, StringComparison.CurrentCultureIgnoreCase))) {
                            Employees.Add(c.Value);
                        }
                    }

                    Cards.Clear();
                    BindEmployeesToGridView();
                    BindCardsToGridView();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.SignToolStripMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Employees To GridView.
        /// </summary>
        private void BindEmployeesToGridView() {
            EmpGridView.Rows.Clear();
            EmpGridView.RowCount = Employees.Count;
        }

        /// <summary>
        /// Bind Cards To GridView.
        /// </summary>
        private void BindCardsToGridView() {
            CardsGridView.Rows.Clear();
            CardsGridView.RowCount = Cards.Count;
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
        /// Save Cards.
        /// </summary>
        private void OKBtn_Click(object sender, EventArgs e) {
            try {
                if (CardsGridView.Rows.Count == 0) {
                    Cards.Clear();
                    MessageBox.Show("无发卡记录", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ExistCards.Clear();
                foreach (var c in Cards) {
                    if (CardEntity.ExistCard(c.ID.CardSn)) {
                        ExistCards[c.ID.CardSn] = c.ID;
                    }
                }

                if (ExistCards.Count > 0) {
                    BindCardsToGridView();
                    CardsGridView.ClearSelection();
                    MessageBox.Show("卡号已注册，请对红色标记的记录重新读卡。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = Common.ShowWait(() => {
                    CardEntity.SaveCards(Cards.Select(c => c.ID).ToList());
                }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                if (result == DialogResult.OK) {
                    foreach (var c in Cards) {
                        Common.WriteLog(DateTime.Now, EnmMsgType.Cardin, Common.CurUser.UserName, "Delta.MPS.AccessSystem.BatchOutCardsForm.OKBtn.Click", String.Format("新增卡片:[{0} - {1},{2}]", c.ID.CardSn, c.ID.WorkerId, c.ID.WorkerName), null);
                    }

                    MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                } else {
                    MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.BatchOutCardsForm.OKBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
