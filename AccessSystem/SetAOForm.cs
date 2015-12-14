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
    public partial class SetAOForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private NodeInfo CurNode;

        /// <summary>
        /// Orders
        /// </summary>
        public List<OrderInfo> Orders { get; private set; }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SetAOForm(NodeInfo Node) {
            InitializeComponent();
            CurNode = Node;
            Orders = new List<OrderInfo>();
            Text = String.Format("{0} - [{1}]", Text, Node.NodeName);
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void SetAOForm_Shown(object sender, EventArgs e) {
            try {
                OKBtn.Enabled = false;
                if (CurNode == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OKBtn.Enabled = true;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetAOForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set AO Orders.
        /// </summary>
        private void OKBtn_Click(object sender, EventArgs e) {
            try {
                var Lsc = new Node().GetLsc();
                if (Lsc.Count == 0) {
                    MessageBox.Show("未找到Lsc配置信息", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Orders.Clear();
                Orders.Add(new OrderInfo() {
                    TargetID = CurNode.NodeID,
                    TargetType = CurNode.NodeType,
                    OrderType = EnmActType.SetAoc,
                    RelValue1 = String.Format("{0:0.000}", ValueNUD.Value),
                    RelValue2 = Lsc.First().Key.ToString(),
                    RelValue3 = "0",
                    RelValue4 = Common.CurUser.UserName,
                    RelValue5 = String.Empty
                });
                DialogResult = System.Windows.Forms.DialogResult.OK;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetAOForm.OKBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
