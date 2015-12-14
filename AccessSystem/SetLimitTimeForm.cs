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
using Delta.MPS.DBUtility;

namespace Delta.MPS.AccessSystem
{
    public partial class SetLimitTimeForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private List<LimitTimeInfo> CurTimes;
        private Boolean ValueChangedLocked;

        /// <summary>
        /// DTM
        /// </summary>
        private LimitTimeInfo DTMTime;
        private Int32 DTMLimitIndex;

        /// <summary>
        /// WTMG
        /// </summary>
        private LimitTimeInfo WTMGTime;
        private Int32 WTMGLimitIndex;
        private Int32 WTMGWeekIndex;

        /// <summary>
        /// IRTM
        /// </summary>
        private LimitTimeInfo IRTMTime;

        /// <summary>
        /// SWD
        /// </summary>
        private LimitTimeInfo SWDTime;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public SetLimitTimeForm() {
            InitializeComponent();
            CurTimes = new List<LimitTimeInfo>();
        }

        /// <summary>
        /// Form Load Event
        /// </summary>
        private void SetLimitTimeForm_Load(object sender, EventArgs e) {
            try {
                BindNodesTreeView(NodeTreeView.Nodes, 0, Common.CurUser.Role.Nodes);
                BindLimitIndexCombobox();
                BindSWDWeekCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nodes TreeView AfterSelect Event.
        /// </summary>
        private void NodesTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                e.Node.Expand();
                CurTimes.Clear();
                var tag = (IDValuePair<Int32, EnmNodeType>)e.Node.Tag;
                if (tag != null && tag.Value == EnmNodeType.Dev) { CurTimes = new LimitTime().GetLimitTimes(tag.ID); }

                //DTM
                DTMRB1.Checked = false;
                DTMRB1.Checked = true;

                //WTMG
                WTMGRB1.Checked = false;
                WTMGRB1.Checked = true;

                //IRTM
                IRTMRB_CheckedChanged();

                //SHD
                SHDRB_CheckedChanged();

                //SWD
                SWDRB_CheckedChanged();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.NodesTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nodes TreeView AfterCheck Event.
        /// </summary>
        private void NodesTreeView_AfterCheck(object sender, TreeViewEventArgs e) {
            try {
                if (e.Action == TreeViewAction.ByMouse) {
                    e.Node.Expand();
                    SetChildNodeCheckedState(e.Node);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.NodesTreeView.AfterCheck", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// RadioButton Checked Changed Event.
        /// </summary>
        private void DTMRB_CheckedChanged(object sender, EventArgs e) {
            try {
                ValueChangedLocked = true;
                var target = (RadioButton)sender;
                if (target.Checked) {
                    DTMTime = null;
                    DTMLimitIndex = Convert.ToInt32(target.Tag);
                    DTMBeginTimeDTP1.Value = DTMBeginTimeDTP2.Value = DTMBeginTimeDTP3.Value = DTMBeginTimeDTP4.Value = DateTime.Today;
                    DTMEndTimeDTP1.Value = DTMEndTimeDTP2.Value = DTMEndTimeDTP3.Value = DTMEndTimeDTP4.Value = DateTime.Today;
                    SetDTMTimes();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.DTMRB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                ValueChangedLocked = false;
            }
        }

        /// <summary>
        /// RadioButton Checked Changed Event.
        /// </summary>
        private void WTMGRB_CheckedChanged(object sender, EventArgs e) {
            try {
                ValueChangedLocked = true;
                var target = (RadioButton)sender;
                if (target.Checked) {
                    WTMGTime = null;
                    WTMGWeekIndex = Convert.ToInt32(target.Tag);
                    WTMGBeginTimeDTP1.Value = WTMGBeginTimeDTP2.Value = WTMGBeginTimeDTP3.Value = WTMGBeginTimeDTP4.Value = WTMGBeginTimeDTP5.Value = WTMGBeginTimeDTP6.Value = DateTime.Today;
                    WTMGEndTimeDTP1.Value = WTMGEndTimeDTP2.Value = WTMGEndTimeDTP3.Value = WTMGEndTimeDTP4.Value = WTMGEndTimeDTP5.Value = WTMGEndTimeDTP6.Value = DateTime.Today;
                    SetWTMGTimes();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.WTMGRB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                ValueChangedLocked = false;
            }
        }

        /// <summary>
        /// RadioButton Checked Changed Event.
        /// </summary>
        private void IRTMRB_CheckedChanged() {
            try {
                ValueChangedLocked = true;
                IRTMTime = null;
                IRTMBeginTimeDTP1.Value = IRTMBeginTimeDTP2.Value = IRTMBeginTimeDTP3.Value = IRTMBeginTimeDTP4.Value = DateTime.Today;
                IRTMEndTimeDTP1.Value = IRTMEndTimeDTP2.Value = IRTMEndTimeDTP3.Value = IRTMEndTimeDTP4.Value = DateTime.Today;
                SetIRTMTimes();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.IRTMRB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                ValueChangedLocked = false;
            }
        }

        /// <summary>
        /// RadioButton Checked Changed Event.
        /// </summary>
        private void SHDRB_CheckedChanged() {
            try {
                SHDBeginDateDTP.Value = SHDEndDateDTP.Value = new DateTime(DateTime.Today.Year, 1, 1);
                SetSHDTimes();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.SHDRB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// RadioButton Checked Changed Event.
        /// </summary>
        private void SWDRB_CheckedChanged() {
            try {
                ValueChangedLocked = true;
                SWDWeekCB1.SelectedIndex = 1;
                SWDWeekCB2.SelectedIndex = 1;
                SWDWeekCB3.SelectedIndex = 1;
                SWDWeekCB4.SelectedIndex = 1;
                SWDWeekCB5.SelectedIndex = 1;
                SWDWeekCB6.SelectedIndex = 1;
                SWDWeekCB7.SelectedIndex = 1;
                SetSWDTimes();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.SWDRB.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                ValueChangedLocked = false;
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void WTMGLimitIndexCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                ValueChangedLocked = true;
                WTMGTime = null;
                WTMGLimitIndex = Convert.ToInt32(WTMGLimitIndexCB.SelectedValue);
                WTMGBeginTimeDTP1.Value = WTMGBeginTimeDTP2.Value = WTMGBeginTimeDTP3.Value = WTMGBeginTimeDTP4.Value = WTMGBeginTimeDTP5.Value = WTMGBeginTimeDTP6.Value = DateTime.Today;
                WTMGEndTimeDTP1.Value = WTMGEndTimeDTP2.Value = WTMGEndTimeDTP3.Value = WTMGEndTimeDTP4.Value = WTMGEndTimeDTP5.Value = WTMGEndTimeDTP6.Value = DateTime.Today;
                SetWTMGTimes();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.WTMGLimitIndexCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                ValueChangedLocked = false;
            }
        }

        /// <summary>
        /// DateTimePicker Value Changed Event.
        /// </summary>
        private void DTMTime_ValueChanged(object sender, EventArgs e) {
            try {
                if (ValueChangedLocked) { return; }
                if (DTMTime == null) {
                    DTMTime = new LimitTimeInfo();
                    DTMTime.ID = 0;
                    DTMTime.DevId = 0;
                    DTMTime.LimitId = DTMRB1.Checked ? EnmLimitID.NDTM : EnmLimitID.DTM;
                    DTMTime.LimitIndex = DTMLimitIndex;
                    DTMTime.LimitDesc = DTMTime.LimitIndex > 0 ? "工作日时段" : "非工作日时段";
                    DTMTime.WeekIndex = ComUtility.DefaultInt32;
                    DTMTime.StartTime5 = ComUtility.DefaultString;
                    DTMTime.EndTime5 = ComUtility.DefaultString;
                    DTMTime.StartTime6 = ComUtility.DefaultString;
                    DTMTime.EndTime6 = ComUtility.DefaultString;
                    CurTimes.Add(DTMTime);
                }

                DTMTime.StartTime1 = DTMBeginTimeDTP1.Value.ToString("HHmm");
                DTMTime.EndTime1 = DTMEndTimeDTP1.Value.ToString("HHmm");
                DTMTime.StartTime2 = DTMBeginTimeDTP2.Value.ToString("HHmm");
                DTMTime.EndTime2 = DTMEndTimeDTP2.Value.ToString("HHmm");
                DTMTime.StartTime3 = DTMBeginTimeDTP3.Value.ToString("HHmm");
                DTMTime.EndTime3 = DTMEndTimeDTP3.Value.ToString("HHmm");
                DTMTime.StartTime4 = DTMBeginTimeDTP4.Value.ToString("HHmm");
                DTMTime.EndTime4 = DTMEndTimeDTP4.Value.ToString("HHmm");
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.DTMTime.ValueChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DateTimePicker Value Changed Event.
        /// </summary>
        private void WTMGTime_ValueChanged(object sender, EventArgs e) {
            try {
                if (ValueChangedLocked) { return; }
                if (WTMGTime == null) {
                    WTMGTime = new LimitTimeInfo();
                    WTMGTime.ID = 0;
                    WTMGTime.DevId = 0;
                    WTMGTime.LimitId = EnmLimitID.WTMG;
                    WTMGTime.LimitIndex = WTMGLimitIndex;
                    WTMGTime.LimitDesc = "星期时段";
                    WTMGTime.WeekIndex = WTMGWeekIndex;
                    CurTimes.Add(WTMGTime);
                }

                WTMGTime.StartTime1 = WTMGBeginTimeDTP1.Value.ToString("HHmm");
                WTMGTime.EndTime1 = WTMGEndTimeDTP1.Value.ToString("HHmm");
                WTMGTime.StartTime2 = WTMGBeginTimeDTP2.Value.ToString("HHmm");
                WTMGTime.EndTime2 = WTMGEndTimeDTP2.Value.ToString("HHmm");
                WTMGTime.StartTime3 = WTMGBeginTimeDTP3.Value.ToString("HHmm");
                WTMGTime.EndTime3 = WTMGEndTimeDTP3.Value.ToString("HHmm");
                WTMGTime.StartTime4 = WTMGBeginTimeDTP4.Value.ToString("HHmm");
                WTMGTime.EndTime4 = WTMGEndTimeDTP4.Value.ToString("HHmm");
                WTMGTime.StartTime5 = WTMGBeginTimeDTP5.Value.ToString("HHmm");
                WTMGTime.EndTime5 = WTMGEndTimeDTP5.Value.ToString("HHmm");
                WTMGTime.StartTime6 = WTMGBeginTimeDTP6.Value.ToString("HHmm");
                WTMGTime.EndTime6 = WTMGEndTimeDTP6.Value.ToString("HHmm");
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.WTMGTime.ValueChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DateTimePicker Value Changed Event.
        /// </summary>
        private void IRTMTime_ValueChanged(object sender, EventArgs e) {
            try {
                if (ValueChangedLocked) { return; }
                if (IRTMTime == null) {
                    IRTMTime = new LimitTimeInfo();
                    IRTMTime.ID = 0;
                    IRTMTime.DevId = 0;
                    IRTMTime.LimitId = EnmLimitID.IRTM;
                    IRTMTime.LimitIndex = 0;
                    IRTMTime.LimitDesc = "门磁/红外时段";
                    IRTMTime.WeekIndex = ComUtility.DefaultInt32;
                    IRTMTime.StartTime5 = ComUtility.DefaultString;
                    IRTMTime.EndTime5 = ComUtility.DefaultString;
                    IRTMTime.StartTime6 = ComUtility.DefaultString;
                    IRTMTime.EndTime6 = ComUtility.DefaultString;
                    CurTimes.Add(IRTMTime);
                }

                IRTMTime.StartTime1 = IRTMBeginTimeDTP1.Value.ToString("HHmm");
                IRTMTime.EndTime1 = IRTMEndTimeDTP1.Value.ToString("HHmm");
                IRTMTime.StartTime2 = IRTMBeginTimeDTP2.Value.ToString("HHmm");
                IRTMTime.EndTime2 = IRTMEndTimeDTP2.Value.ToString("HHmm");
                IRTMTime.StartTime3 = IRTMBeginTimeDTP3.Value.ToString("HHmm");
                IRTMTime.EndTime3 = IRTMEndTimeDTP3.Value.ToString("HHmm");
                IRTMTime.StartTime4 = IRTMBeginTimeDTP4.Value.ToString("HHmm");
                IRTMTime.EndTime4 = IRTMEndTimeDTP4.Value.ToString("HHmm");
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.IRTMTime.ValueChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Combobox SelectedIndex Changed Event.
        /// </summary>
        private void SWDWeekCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (ValueChangedLocked) { return; }
                if (SWDTime == null) {
                    SWDTime = new LimitTimeInfo();
                    SWDTime.ID = 0;
                    SWDTime.DevId = 0;
                    SWDTime.LimitId = EnmLimitID.SWD;
                    SWDTime.LimitIndex = 0;
                    SWDTime.LimitDesc = "周末时段";
                    SWDTime.WeekIndex = ComUtility.DefaultInt32;
                    SWDTime.EndTime1 = ComUtility.DefaultString;
                    SWDTime.StartTime2 = ComUtility.DefaultString;
                    SWDTime.EndTime2 = ComUtility.DefaultString;
                    SWDTime.StartTime3 = ComUtility.DefaultString;
                    SWDTime.EndTime3 = ComUtility.DefaultString;
                    SWDTime.StartTime4 = ComUtility.DefaultString;
                    SWDTime.EndTime4 = ComUtility.DefaultString;
                    SWDTime.StartTime5 = ComUtility.DefaultString;
                    SWDTime.EndTime5 = ComUtility.DefaultString;
                    SWDTime.StartTime6 = ComUtility.DefaultString;
                    SWDTime.EndTime6 = ComUtility.DefaultString;
                    CurTimes.Add(SWDTime);
                }

                SWDTime.StartTime1 = String.Empty;
                if (SWDWeekCB1.SelectedIndex == 0) {
                    SWDTime.StartTime1 += SWDWeekCB1.Tag.ToString();
                }

                if (SWDWeekCB2.SelectedIndex == 0) {
                    SWDTime.StartTime1 += SWDWeekCB2.Tag.ToString();
                }

                if (SWDWeekCB3.SelectedIndex == 0) {
                    SWDTime.StartTime1 += SWDWeekCB3.Tag.ToString();
                }

                if (SWDWeekCB4.SelectedIndex == 0) {
                    SWDTime.StartTime1 += SWDWeekCB4.Tag.ToString();
                }

                if (SWDWeekCB5.SelectedIndex == 0) {
                    SWDTime.StartTime1 += SWDWeekCB5.Tag.ToString();
                }

                if (SWDWeekCB6.SelectedIndex == 0) {
                    SWDTime.StartTime1 += SWDWeekCB6.Tag.ToString();
                }

                if (SWDWeekCB7.SelectedIndex == 0) {
                    SWDTime.StartTime1 += SWDWeekCB7.Tag.ToString();
                }

                if (SWDTime.StartTime1.Length >= 4) {
                    SWDTime.StartTime1 = SWDTime.StartTime1.Substring(0, 4);
                } else if (SWDTime.StartTime1.Length == 2) {
                    SWDTime.StartTime1 += "FF";
                } else {
                    SWDTime.StartTime1 = "0000";
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.SWDWeekCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add SHD Button Click Event.
        /// </summary>
        private void SHDAddBtn_Click(object sender, EventArgs e) {
            try {
                var startDate = SHDBeginDateDTP.Value;
                var endDate = SHDEndDateDTP.Value;
                if (endDate < startDate) {
                    MessageBox.Show("开始日期必须小于或等于结束日期", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (endDate.Subtract(startDate).TotalDays >= 30) {
                    MessageBox.Show("节假日不能大于30天", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                while (startDate <= endDate) {
                    var date = startDate.ToString("MMdd");
                    if (!CurTimes.Any(t => t.LimitId == EnmLimitID.SHD && t.StartTime1.Equals(date))) {
                        CurTimes.Add(new LimitTimeInfo() {
                            ID = 0,
                            DevId = 0,
                            LimitId = EnmLimitID.SHD,
                            LimitIndex = 0,
                            LimitDesc = "节假日时段",
                            WeekIndex = ComUtility.DefaultInt32,
                            StartTime1 = date,
                            EndTime1 = ComUtility.DefaultString,
                            StartTime2 = ComUtility.DefaultString,
                            EndTime2 = ComUtility.DefaultString,
                            StartTime3 = ComUtility.DefaultString,
                            EndTime3 = ComUtility.DefaultString,
                            StartTime4 = ComUtility.DefaultString,
                            EndTime4 = ComUtility.DefaultString,
                            StartTime5 = ComUtility.DefaultString,
                            EndTime5 = ComUtility.DefaultString,
                            StartTime6 = ComUtility.DefaultString,
                            EndTime6 = ComUtility.DefaultString,
                        });
                    }

                    startDate = startDate.AddDays(1);
                }

                SetSHDTimes();
                MessageBox.Show("节假日添加完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.SHDAddBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// SHDContext Menu Opening Event.
        /// </summary>
        private void SHDContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            try {
                SHDToolStripMenuItem1.Enabled = SHDDataGridView.SelectedRows.Count > 0;
                SHDToolStripMenuItem2.Enabled = SHDDataGridView.Rows.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.SHDContextMenuStrip.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// SHD ToolStrip Menu Item Click Event.
        /// </summary>
        private void SHDToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (SHDDataGridView.SelectedRows.Count > 0 && MessageBox.Show("您确定要删除选中行吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var dates = new List<String>();
                    foreach (DataGridViewRow row in SHDDataGridView.SelectedRows) {
                        dates.Add(row.Cells["SHDColumn"].Value.ToString().Replace("-", ""));
                    }

                    CurTimes.RemoveAll(t => t.LimitId == EnmLimitID.SHD && dates.Any(d => d.Equals(t.StartTime1)));
                    SetSHDTimes();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.SHDToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// SHD ToolStrip Menu Item Click Event.
        /// </summary>
        private void SHDToolStripMenuItem2_Click(object sender, EventArgs e) {
            try {
                if (SHDDataGridView.Rows.Count > 0 && MessageBox.Show("您确定要删除所有行吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    CurTimes.RemoveAll(t => t.LimitId == EnmLimitID.SHD);
                    SetSHDTimes();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.SHDToolStripMenuItem2.Click", err.Message, err.StackTrace);
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
                    Finder = new FinderDialog(NodeTreeView); 
                }

                if (!Finder.Visible) {
                    Finder.Show(this);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.TVToolStripMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set DTM Times.
        /// </summary>
        private void SetDTMTimes() {
            var dtm = DTMRB1.Checked ? EnmLimitID.NDTM : EnmLimitID.DTM;
            var dtmTimes = CurTimes.FindAll(t => t.LimitId == dtm);
            if (dtmTimes.Count > 0) {
                DTMTime = dtmTimes.Find(t => t.LimitIndex == DTMLimitIndex);
                if (DTMTime != null) {
                    DTMBeginTimeDTP1.Value = Common.GetDateValue(DTMTime.StartTime1, 1);
                    DTMEndTimeDTP1.Value = Common.GetDateValue(DTMTime.EndTime1, 1);
                    DTMBeginTimeDTP2.Value = Common.GetDateValue(DTMTime.StartTime2, 1);
                    DTMEndTimeDTP2.Value = Common.GetDateValue(DTMTime.EndTime2, 1);
                    DTMBeginTimeDTP3.Value = Common.GetDateValue(DTMTime.StartTime3, 1);
                    DTMEndTimeDTP3.Value = Common.GetDateValue(DTMTime.EndTime3, 1);
                    DTMBeginTimeDTP4.Value = Common.GetDateValue(DTMTime.StartTime4, 1);
                    DTMEndTimeDTP4.Value = Common.GetDateValue(DTMTime.EndTime4, 1);
                }
            }
        }

        /// <summary>
        /// Set WTMG Times.
        /// </summary>
        private void SetWTMGTimes() {
            var dtmTimes = CurTimes.FindAll(t => t.LimitId == EnmLimitID.WTMG);
            if (dtmTimes.Count > 0) {
                WTMGTime = dtmTimes.Find(t => t.LimitIndex == WTMGLimitIndex && t.WeekIndex == WTMGWeekIndex);
                if (WTMGTime != null) {
                    WTMGBeginTimeDTP1.Value = Common.GetDateValue(WTMGTime.StartTime1, 1);
                    WTMGEndTimeDTP1.Value = Common.GetDateValue(WTMGTime.EndTime1, 1);
                    WTMGBeginTimeDTP2.Value = Common.GetDateValue(WTMGTime.StartTime2, 1);
                    WTMGEndTimeDTP2.Value = Common.GetDateValue(WTMGTime.EndTime2, 1);
                    WTMGBeginTimeDTP3.Value = Common.GetDateValue(WTMGTime.StartTime3, 1);
                    WTMGEndTimeDTP3.Value = Common.GetDateValue(WTMGTime.EndTime3, 1);
                    WTMGBeginTimeDTP4.Value = Common.GetDateValue(WTMGTime.StartTime4, 1);
                    WTMGEndTimeDTP4.Value = Common.GetDateValue(WTMGTime.EndTime4, 1);
                    WTMGBeginTimeDTP5.Value = Common.GetDateValue(WTMGTime.StartTime5, 1);
                    WTMGEndTimeDTP5.Value = Common.GetDateValue(WTMGTime.EndTime5, 1);
                    WTMGBeginTimeDTP6.Value = Common.GetDateValue(WTMGTime.StartTime6, 1);
                    WTMGEndTimeDTP6.Value = Common.GetDateValue(WTMGTime.EndTime6, 1);
                }
            }
        }

        /// <summary>
        /// Set IRTM Times.
        /// </summary>
        private void SetIRTMTimes() {
            IRTMTime = CurTimes.Find(t => t.LimitId == EnmLimitID.IRTM);
            if (IRTMTime != null) {
                IRTMBeginTimeDTP1.Value = Common.GetDateValue(IRTMTime.StartTime1, 1);
                IRTMEndTimeDTP1.Value = Common.GetDateValue(IRTMTime.EndTime1, 1);
                IRTMBeginTimeDTP2.Value = Common.GetDateValue(IRTMTime.StartTime2, 1);
                IRTMEndTimeDTP2.Value = Common.GetDateValue(IRTMTime.EndTime2, 1);
                IRTMBeginTimeDTP3.Value = Common.GetDateValue(IRTMTime.StartTime3, 1);
                IRTMEndTimeDTP3.Value = Common.GetDateValue(IRTMTime.EndTime3, 1);
                IRTMBeginTimeDTP4.Value = Common.GetDateValue(IRTMTime.StartTime4, 1);
                IRTMEndTimeDTP4.Value = Common.GetDateValue(IRTMTime.EndTime4, 1);
            }
        }

        /// <summary>
        /// Set SHD Times.
        /// </summary>
        private void SetSHDTimes() {
            SHDDataGridView.Rows.Clear();
            var shdTimes = CurTimes.FindAll(t => t.LimitId == EnmLimitID.SHD);
            foreach (var time in shdTimes) {
                var rowIndex = SHDDataGridView.Rows.Add(1);
                SHDDataGridView.Rows[rowIndex].Cells["SHDColumn"].Value = Common.GetDateValue(time.StartTime1, 2).ToString("MM-dd");
            }
        }

        /// <summary>
        /// Set SWD Times.
        /// </summary>
        private void SetSWDTimes() {
            SWDTime = CurTimes.Find(t => t.LimitId == EnmLimitID.SWD);
            if (SWDTime != null && SWDTime.StartTime1 != null && SWDTime.StartTime1.Length == 4) {
                var w1 = SWDTime.StartTime1.Substring(0, 2);
                var w2 = SWDTime.StartTime1.Substring(2, 2);
                if (SWDWeekCB1.Tag.ToString().Equals(w1) || SWDWeekCB1.Tag.ToString().Equals(w2)) {
                    SWDWeekCB1.SelectedIndex = 0;
                }

                if (SWDWeekCB2.Tag.ToString().Equals(w1) || SWDWeekCB2.Tag.ToString().Equals(w2)) {
                    SWDWeekCB2.SelectedIndex = 0;
                }

                if (SWDWeekCB3.Tag.ToString().Equals(w1) || SWDWeekCB3.Tag.ToString().Equals(w2)) {
                    SWDWeekCB3.SelectedIndex = 0;
                }

                if (SWDWeekCB4.Tag.ToString().Equals(w1) || SWDWeekCB4.Tag.ToString().Equals(w2)) {
                    SWDWeekCB4.SelectedIndex = 0;
                }

                if (SWDWeekCB5.Tag.ToString().Equals(w1) || SWDWeekCB5.Tag.ToString().Equals(w2)) {
                    SWDWeekCB5.SelectedIndex = 0;
                }

                if (SWDWeekCB6.Tag.ToString().Equals(w1) || SWDWeekCB6.Tag.ToString().Equals(w2)) {
                    SWDWeekCB6.SelectedIndex = 0;
                }

                if (SWDWeekCB7.Tag.ToString().Equals(w1) || SWDWeekCB7.Tag.ToString().Equals(w2)) {
                    SWDWeekCB7.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Save Limit Times.
        /// </summary>
        private void SaveBtn_Click(object sender, EventArgs e) {
            try {
                var node = NodeTreeView.SelectedNode;
                if (node == null) {
                    MessageBox.Show("请选择需要应用参数的设备", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var devIds = new List<Int32>();
                var tag = (IDValuePair<Int32, EnmNodeType>)node.Tag;
                if (tag.Value == EnmNodeType.Dev) {
                    devIds.Add(tag.ID);
                } else {
                    CheckDevTreeView(node.Nodes, devIds);
                    if (devIds.Count == 0) {
                        MessageBox.Show(String.Format("请勾选[{0}]节点下需要应用参数的设备", node.Text), "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NodeTreeView.Focus();
                        return;
                    }
                }

                var limitIds = new List<EnmLimitID>();
                if (AllCB.Checked || RightTabControl.SelectedIndex == 0) {
                    limitIds.Add(EnmLimitID.DTM);
                    limitIds.Add(EnmLimitID.NDTM);
                }

                if (AllCB.Checked || RightTabControl.SelectedIndex == 1) {
                    limitIds.Add(EnmLimitID.WTMG);
                }

                if (AllCB.Checked || RightTabControl.SelectedIndex == 2) {
                    limitIds.Add(EnmLimitID.IRTM);
                }

                if (AllCB.Checked || RightTabControl.SelectedIndex == 3) {
                    limitIds.Add(EnmLimitID.SHD);
                }

                if (AllCB.Checked || RightTabControl.SelectedIndex == 4) {
                    limitIds.Add(EnmLimitID.SWD);
                }

                var times = CurTimes.FindAll(t => limitIds.Any(l => t.LimitId == l));
                if (times.Count == 0) {
                    MessageBox.Show("未设置任何参数，请先设置参数。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!AllCB.Checked || MessageBox.Show("您确定要对设备应用全部时段吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                    var result = Common.ShowWait(() => {
                        new LimitTime().SaveLimitTimes(devIds, limitIds, times);
                    }, default(String), "正在保存，请稍后...", default(Int32), default(Int32));

                    if (result == DialogResult.OK) {
                        foreach (var devId in devIds) {
                            foreach (var limitId in limitIds) {
                                Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.SetLimitTimeForm.SaveBtn.Click", String.Format("配置设备[ID:{0}]准进时段[{1}]", devId, ComUtility.GetLimitIDText(limitId)), null);
                            }
                        }
                        MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("数据保存失败", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.SetLimitTimeForm.SaveBtn.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Nodes TreeView.
        /// </summary>
        /// <param name="collection">parent collection</param>
        /// <param name="lastId">parent id</param>
        /// <param name="nodes">nodes</param>
        private void BindNodesTreeView(TreeNodeCollection collection, Int32 lastId, List<NodeLevelInfo> nodes) {
            if (nodes != null && nodes.Count > 0) {
                var SubNodes = nodes.FindAll(n => { return n.LastNodeID == lastId; }).OrderBy(a => a.SortIndex).ToList();
                if (SubNodes.Count > 0) {
                    foreach (var sn in SubNodes) {
                        var treeNode = new TreeNode();
                        treeNode.Text = Common.GetTreeNodeName(sn);
                        treeNode.Tag = new IDValuePair<Int32, EnmNodeType>(sn.NodeID, sn.NodeType);
                        treeNode.ImageKey = sn.NodeType == EnmNodeType.Dev ? "Device" : "Area";
                        treeNode.SelectedImageKey = sn.NodeType == EnmNodeType.Dev ? "Device" : "Area";
                        collection.Add(treeNode);

                        BindNodesTreeView(treeNode.Nodes, sn.NodeID, nodes);
                    }
                }
            }
        }

        /// <summary>
        /// Set child node checked state.
        /// </summary>
        /// <param name="currNode">current node</param>
        private void SetChildNodeCheckedState(TreeNode currNode) {
            foreach (TreeNode tn in currNode.Nodes) {
                tn.Checked = currNode.Checked;
                SetChildNodeCheckedState(tn);
            }
        }

        /// <summary>
        /// Bind Limit Index Combobox.
        /// </summary>
        private void BindLimitIndexCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            for (var i = 0; i < 16; i++) {
                data.Add(new IDValuePair<Int32, String>(i, String.Format("第{0}组", i + 1)));
            }

            WTMGLimitIndexCB.ValueMember = "ID";
            WTMGLimitIndexCB.DisplayMember = "Value";
            WTMGLimitIndexCB.DataSource = data;
        }

        /// <summary>
        /// Bind SWD Week Combobox.
        /// </summary>
        private void BindSWDWeekCombobox() {
            try {
                ValueChangedLocked = true;
                var data = new List<IDValuePair<Int32, String>>();
                data.Add(new IDValuePair<Int32, String>(0, "0-休息"));
                data.Add(new IDValuePair<Int32, String>(1, "1-全天工作"));

                SWDWeekCB1.ValueMember = "ID";
                SWDWeekCB1.DisplayMember = "Value";
                SWDWeekCB1.DataSource = data;

                var data2 = new List<IDValuePair<Int32, String>>(data);
                SWDWeekCB2.ValueMember = "ID";
                SWDWeekCB2.DisplayMember = "Value";
                SWDWeekCB2.DataSource = data2;

                var data3 = new List<IDValuePair<Int32, String>>(data);
                SWDWeekCB3.ValueMember = "ID";
                SWDWeekCB3.DisplayMember = "Value";
                SWDWeekCB3.DataSource = data3;

                var data4 = new List<IDValuePair<Int32, String>>(data);
                SWDWeekCB4.ValueMember = "ID";
                SWDWeekCB4.DisplayMember = "Value";
                SWDWeekCB4.DataSource = data4;

                var data5 = new List<IDValuePair<Int32, String>>(data);
                SWDWeekCB5.ValueMember = "ID";
                SWDWeekCB5.DisplayMember = "Value";
                SWDWeekCB5.DataSource = data5;

                var data6 = new List<IDValuePair<Int32, String>>(data);
                SWDWeekCB6.ValueMember = "ID";
                SWDWeekCB6.DisplayMember = "Value";
                SWDWeekCB6.DataSource = data6;

                var data7 = new List<IDValuePair<Int32, String>>(data);
                SWDWeekCB7.ValueMember = "ID";
                SWDWeekCB7.DisplayMember = "Value";
                SWDWeekCB7.DataSource = data7;
            } finally {
                ValueChangedLocked = false;
            }
        }

        /// <summary>
        /// Get Device TreeView Checked Nodes
        /// </summary>
        /// <param name="collection">Current Nodes</param>
        /// <param name="devIds">Result Device Ids</param>
        private void CheckDevTreeView(TreeNodeCollection collection, List<Int32> devIds) {
            foreach (TreeNode tn in collection) {
                if (tn.Checked) {
                    var tag = (IDValuePair<Int32, EnmNodeType>)tn.Tag;
                    if (tag != null && tag.Value == EnmNodeType.Dev) { devIds.Add(tag.ID); }
                }

                CheckDevTreeView(tn.Nodes, devIds);
            }
        }
    }
}
