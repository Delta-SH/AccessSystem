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
    public partial class SaveGridForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private EnmSaveBehavior CurBehavior = EnmSaveBehavior.Null;
        private IDValuePair<Int32, String> CurGrid;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SaveGridForm(EnmSaveBehavior Behavior, IDValuePair<Int32, String> Grid) {
            InitializeComponent();
            CurBehavior = Behavior;
            CurGrid = new IDValuePair<Int32, String>(Grid.ID, Grid.Value);
            Text = Behavior == EnmSaveBehavior.Add ? "新建网格" : "编辑网格";
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void SaveGridForm_Load(object sender, EventArgs e) {
            try {
                if (CurBehavior == EnmSaveBehavior.Null || CurGrid == null) {
                    MessageBox.Show("非法的构造参数", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = System.Windows.Forms.DialogResult.Abort;
                    return;
                }

                GridNameTB.Text = CurGrid.Value;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveGridForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save Grid.
        /// </summary>
        private void OKBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(GridNameTB.Text)) {
                    GridNameTB.Focus();
                    MessageBox.Show("请输入网格名称", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (new Grid().ExistGridName(GridNameTB.Text.Trim())) {
                    GridNameTB.Focus();
                    MessageBox.Show("名称已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CurGrid = new IDValuePair<Int32, String>(CurGrid.ID, GridNameTB.Text.Trim());
                if (CurBehavior == EnmSaveBehavior.Add)
                    new Grid().AddGrids(new List<IDValuePair<Int32, String>> { CurGrid });
                else
                    new Grid().UpdateGrids(new List<IDValuePair<Int32, String>> { CurGrid });

                Common.WriteLog(DateTime.Now, CurBehavior == EnmSaveBehavior.Add ? EnmMsgType.Cardin : EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SaveGridForm.SaveBtn.Click", String.Format("{0}网格:[{1}]", CurBehavior == EnmSaveBehavior.Add ? "新增" : "更新", CurGrid.Value), null);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SaveCardForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saved Grid.
        /// </summary>
        public IDValuePair<Int32, String> Grid {
            get { return CurGrid; }
        }
    }
}