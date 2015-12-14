using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLServerDAL;
using Excel = org.in2bits.MyXls;

namespace Delta.MPS.AccessSystem
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private Node NodeEntity;
        private Card CardEntity;
        private ComboBoxData ComboEntity;
        private List<NodeInfo> CurNodes;
        private List<NodeInfo> DINodes;
        private List<NodeInfo> DONodes;
        private List<NodeInfo> AINodes;
        private List<NodeInfo> AONodes;
        private List<AlarmInfo> CurAlarms;
        private List<AlarmInfo> GridAlarms;
        private List<DeviceInfo> CurDevices;
        private List<DeviceInfo> GMDevices;
        private List<DeviceInfo> KMDevices;
        private List<DeviceInfo> LJDevices;
        private List<DeviceInfo> QZDevices;
        private List<DeviceInfo> YCDevices;
        private Dictionary<Int32, NodeInfo> StatusNodes;
        private Dictionary<Int32, NodeInfo> RemoteNodes;
        private Dictionary<Int32, CardRecordInfo> CardRecords;
        private List<CardRecordInfo> HisCardRecords;

        #region Panel Style
        /// <summary>
        /// Panel Style
        /// </summary>
        private LayoutStyle PanelStyle = new LayoutStyle() {
            Panel1 = true,
            Panel2 = true,
            Panel3 = true,
            Panel4 = true
        };
        #endregion

        /// <summary>
        /// Class Constructor
        /// </summary>
        public MainForm() {
            InitializeComponent();

            SetDoubleBuffered(DevGridView1);
            SetDoubleBuffered(DevGridView2);
            SetDoubleBuffered(DevGridView3);
            SetDoubleBuffered(DevGridView4);
            SetDoubleBuffered(DevGridView5);
            SetDoubleBuffered(DevGridView6);

            SetDoubleBuffered(NodeGridView);
            SetDoubleBuffered(DIGridView);
            SetDoubleBuffered(DOGridView);
            SetDoubleBuffered(AIGridView);
            SetDoubleBuffered(AOGridView);

            SetDoubleBuffered(AlarmGridView);
            SetDoubleBuffered(HisCardGridView);

            NodeEntity = new Node();
            CardEntity = new Card();
            ComboEntity = new ComboBoxData();
            CurNodes = new List<NodeInfo>();
            DINodes = new List<NodeInfo>();
            DONodes = new List<NodeInfo>();
            AINodes = new List<NodeInfo>();
            AONodes = new List<NodeInfo>();
            CurAlarms = new List<AlarmInfo>();
            GridAlarms = new List<AlarmInfo>();
            CurDevices = new List<DeviceInfo>();
            GMDevices = new List<DeviceInfo>();
            KMDevices = new List<DeviceInfo>();
            LJDevices = new List<DeviceInfo>();
            QZDevices = new List<DeviceInfo>();
            YCDevices = new List<DeviceInfo>();
            CardRecords = new Dictionary<Int32, CardRecordInfo>();
            HisCardRecords = new List<CardRecordInfo>();

            ViewMenu.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            HelpMenuItem3.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
            MainToolBar1.OverflowButton.DropDown.Closing += new ToolStripDropDownClosingEventHandler(OverFlow_Closing);
            MainToolBar1DefindItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e) {
            try {
                //设置登录时间
                Common.CurApplication.AppLoginTime = DateTime.Now;

                //设置窗体状态栏
                RolesStatusLbl.Text = Common.CurUser.Role.RoleName;
                ConnectionStatusLbl.Image = global::Delta.MPS.AccessSystem.Properties.Resources.disconnect;
                ConnectionStatusLbl.Text = "[已断开]";
                CompanyStatusLbl.Text = "中达电通股份有限公司｜台达集团 版权所有 ©2013-2014";
                DateTimeStatusLbl.Text = "登录时长：0000. 00:00:00";

                //设置权限菜单
                SetMenuItem();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form Shown Event.
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e) {
            try {
                #region CheckLicense
                if (Common.IsCheckLicense && Common.LicenseStatus != EnmLicenseStatus.Licensed) {
                    Text = String.Format("{0} - [未注册软件]", Text);
                }

                if (Common.IsCheckLicense && !((Common.LicenseStatus == EnmLicenseStatus.Evaluation && Common.CurApplication.AppFirstTime.AddDays(30).Subtract(Common.CurApplication.AppLastTime).Days > 5) || (Common.LicenseStatus == EnmLicenseStatus.Licensed && Common.CurLicense.Expiration.Subtract(Common.CurApplication.AppLastTime).Days > 5))) {
                    new RegisterForm().ShowDialog(this);
                    if (Common.LicenseStatus != EnmLicenseStatus.Evaluation && Common.LicenseStatus != EnmLicenseStatus.Licensed) {
                        Application.Exit();
                        return;
                    }
                }
                #endregion

                //加载数据
                var TempTreeView = new TreeView();
                var result = Common.ShowWait(() => {
                    StatusNodes = NodeEntity.GetStatusNodes(Common.CurUser.Role.RoleID);
                    RemoteNodes = NodeEntity.GetRemoteNodes(Common.CurUser.Role.RoleID);
                    Common.CurUser.Role.Cards = CardEntity.GetOrgCards(Common.CurUser.Role.RoleID);
                    Common.CurUser.Role.Cards.AddRange(CardEntity.GetOutCards(Common.CurUser.Role.RoleID));
                    BindDeviceToTreeView(TempTreeView);
                });

                if (result == System.Windows.Forms.DialogResult.OK) {
                    DeviceTreeView.Nodes.Clear();
                    foreach (TreeNode tn in TempTreeView.Nodes) {
                        DeviceTreeView.Nodes.Add((TreeNode)tn.Clone());
                    }

                    if (DeviceTreeView.Nodes.Count > 0) {
                        var root = DeviceTreeView.Nodes[0];
                        DeviceTreeView.SelectedNode = root;
                        root.Expand();
                    }

                    //加载Combobox
                    BindAlarmLevelToCombobox();
                    BindArea2ToCombobox();

                    //启动通信模块
                    OnStart();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.MainForm.Shown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form Closing Event.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                if (MessageBox.Show("您确定要退出系统吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK) {
                    e.Cancel = true;
                    return;
                }

                //停止定时线程
                MainTimer.Tag = "0";
                MainTimer.Stop();
                StatusTimer.Tag = "0";
                StatusTimer.Stop();
                var result = Common.ShowWait(() => {
                    OnStop();
                    Common.WriteLog(DateTime.Now, EnmMsgType.Logout, Common.CurUser.UserName, "Delta.MPS.AccessSystem.MainForm.FormClosing", String.Format("{0} - {1} 退出系统{2}", Common.CurUser.Role.RoleName, Common.CurUser.UserName, Environment.NewLine), null);
                }, default(String), "正在退出系统，请稍后...", default(Int32), default(Int32));
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.FormClosing", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Main Timer Tick Event.
        /// </summary>
        private void MainTimer_Tick(object sender, EventArgs e) {
            try {
                MainTimer.Stop();

                #region
                if (DateTime.Now >= new DateTime(2014, 11, 1)) {
                    Environment.Exit(-1);
                    return;
                }
                #endregion

                //更新登录时长
                DateTimeStatusLbl.Text = String.Format("登录时长：{0}", Common.GetTimeInterval(Common.CurApplication.AppLoginTime, DateTime.Now));

                //更新设备告警状态
                if ("1".Equals(AlarmGridView.Tag)) { BindAlarmsToGridView(); }

                //更新设备树告警图标
                SetTreeViewIcon();

                //更新最近刷卡记录
                BindHisCardRecordsToGridView();

                //请求实时测点状态值
                if (CurNodes.Count > 0
                    && runState == EnmRunState.Run
                    && workerClient.LinkState == EnmLinkState.Authentication) {
                    var RequestNodes = new List<NodeInfo>();
                    lock (CurNodes) { RequestNodes.AddRange(CurNodes); }
                    lock (orderQueue) {
                        for (var i = 0; i < RequestNodes.Count; i++) {
                            orderQueue.Enqueue(new OrderInfo() {
                                TargetID = RequestNodes[i].NodeID,
                                TargetType = RequestNodes[i].NodeType,
                                OrderType = EnmActType.RequestNode
                            });
                        }
                    }
                }
            } catch { } finally {
                if ("1".Equals(MainTimer.Tag)) { MainTimer.Start(); }
            }
        }

        /// <summary>
        /// Status Timer Tick Event.
        /// </summary>
        private void StatusTimer_Tick(object sender, EventArgs e) {
            try {
                StatusTimer.Stop();

                //更新门禁设备状态
                BindDevicesToGridView();

                //更新设备测点状态
                BindNodesToGridView();
            } catch { } finally {
                if ("1".Equals(StatusTimer.Tag)) { StatusTimer.Start(); }
            }
        }

        /// <summary>
        /// Device TreeView AfterSelect Event.
        /// </summary>
        private void DeviceTreeView_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                StatusTimer.Stop();

                DevGridView1.Rows.Clear();
                DevGridView2.Rows.Clear();
                DevGridView3.Rows.Clear();
                DevGridView4.Rows.Clear();
                DevGridView5.Rows.Clear();
                DevGridView6.Rows.Clear();

                NodeGridView.Rows.Clear();
                DIGridView.Rows.Clear();
                DOGridView.Rows.Clear();
                AIGridView.Rows.Clear();
                AOGridView.Rows.Clear();

                lock (CurDevices) { CurDevices.Clear(); }
                lock (CurNodes) { CurNodes.Clear(); }

                var data = (NodeLevelInfo)e.Node.Tag;
                if (data != null) {
                    if (data.NodeType == EnmNodeType.Dev) {
                        DevTabControl.Visible = false;
                        DevTabControl.Dock = DockStyle.None;
                        NodeTabControl.Visible = true;
                        NodeTabControl.Dock = DockStyle.Fill;

                        if (Common.CurUser.Role.Devices.ContainsKey(data.NodeID)) {
                            var NodeDev = Common.CurUser.Role.Devices[data.NodeID];
                            if (NodeDev.Nodes == null) {
                                var nodes = NodeEntity.GetNodes(data.NodeID);
                                NodeDev.Nodes = nodes.OrderBy(n => n.NodeType).ThenBy(n => n.DotID).ToList();
                            }

                            if (NodeDev.Nodes != null && NodeDev.Nodes.Count > 0) {
                                lock (CurNodes) { CurNodes.AddRange(NodeDev.Nodes); }
                                BindNodesToGridView();
                                NodeGridView.ClearSelection();
                                DIGridView.ClearSelection();
                                DOGridView.ClearSelection();
                                AIGridView.ClearSelection();
                                AOGridView.ClearSelection();
                            }
                        }
                    } else {
                        DevTabControl.Visible = true;
                        DevTabControl.Dock = DockStyle.Fill;
                        NodeTabControl.Visible = false;
                        NodeTabControl.Dock = DockStyle.None;

                        IEnumerable<KeyValuePair<Int32, DeviceInfo>> NodeDevs = null;
                        if (data.NodeType == EnmNodeType.Area && data.Remark.Equals("1")) {
                            NodeDevs = Common.CurUser.Role.Devices.Where(d => d.Value.Area1ID == data.NodeID);
                        } else if (data.NodeType == EnmNodeType.Area && data.Remark.Equals("2")) {
                            NodeDevs = Common.CurUser.Role.Devices.Where(d => d.Value.Area2ID == data.NodeID);
                        } else if (data.NodeType == EnmNodeType.Area) {
                            NodeDevs = Common.CurUser.Role.Devices.Where(d => d.Value.Area3ID == data.NodeID);
                        } else if (data.NodeType == EnmNodeType.Sta) {
                            NodeDevs = Common.CurUser.Role.Devices.Where(d => d.Value.StaID == data.NodeID);
                        }

                        if (NodeDevs != null && NodeDevs.Any()) {
                            var tempNodes = new List<NodeInfo>();
                            var tempDevs = new List<DeviceInfo>();
                            foreach (var nd in NodeDevs) {
                                if (StatusNodes.ContainsKey(nd.Key)) {
                                    var StatusNode = StatusNodes[nd.Key];
                                    nd.Value.StatusNode = StatusNode;
                                    tempNodes.Add(StatusNode);
                                }

                                if (RemoteNodes.ContainsKey(nd.Key)) {
                                    var RemoteNode = RemoteNodes[nd.Key];
                                    nd.Value.RemoteNode = RemoteNode;
                                    tempNodes.Add(RemoteNode);
                                }

                                tempDevs.Add(nd.Value);
                            }

                            lock (CurDevices) { CurDevices.AddRange(tempDevs); }
                            lock (CurNodes) { CurNodes.AddRange(tempNodes); }

                            GetLastCardRecords();
                            BindDevicesToGridView();
                            DevGridView1.ClearSelection();
                            DevGridView2.ClearSelection();
                            DevGridView3.ClearSelection();
                            DevGridView4.ClearSelection();
                            DevGridView5.ClearSelection();
                            DevGridView6.ClearSelection();
                        }
                    }
                }

                if ("1".Equals(StatusTimer.Tag)) { StatusTimer.Start(); }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DeviceTreeView.AfterSelect", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView1 Cell Value Needed Event.
        /// </summary>
        private void DevGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurDevices.Count - 1) { return; }
                switch (DevGridView1.Columns[e.ColumnIndex].Name) {
                    case "IDColumn1":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "RegionNameColumn1":
                        e.Value = CurDevices[e.RowIndex].Area2Name;
                        break;
                    case "CityNameColumn1":
                        e.Value = CurDevices[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn1":
                        e.Value = CurDevices[e.RowIndex].StaName;
                        break;
                    case "DevIDColumn1":
                        e.Value = CurDevices[e.RowIndex].DevID;
                        break;
                    case "DevNameColumn1":
                        e.Value = CurDevices[e.RowIndex].DevName;
                        break;
                    case "StatusColumn1":
                        e.Value = CurDevices[e.RowIndex].StatusNode != null ? ComUtility.GetDesc(CurDevices[e.RowIndex].StatusNode.Remark, ((Int32)CurDevices[e.RowIndex].StatusNode.Value).ToString()) : String.Empty;
                        DevGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = DevMenuItem4.Checked && CurDevices[e.RowIndex].StatusNode != null ? Common.GetStateColor(CurDevices[e.RowIndex].StatusNode.Status) : Color.White;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView1.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView2 Cell Value Needed Event.
        /// </summary>
        private void DevGridView2_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > GMDevices.Count - 1) { return; }
                switch (DevGridView2.Columns[e.ColumnIndex].Name) {
                    case "IDColumn2":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "RegionNameColumn2":
                        e.Value = GMDevices[e.RowIndex].Area2Name;
                        break;
                    case "CityNameColumn2":
                        e.Value = GMDevices[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn2":
                        e.Value = GMDevices[e.RowIndex].StaName;
                        break;
                    case "DevIDColumn2":
                        e.Value = GMDevices[e.RowIndex].DevID;
                        break;
                    case "DevNameColumn2":
                        e.Value = GMDevices[e.RowIndex].DevName;
                        break;
                    case "StatusColumn2":
                        e.Value = GMDevices[e.RowIndex].StatusNode != null ? ComUtility.GetDesc(GMDevices[e.RowIndex].StatusNode.Remark, ((Int32)GMDevices[e.RowIndex].StatusNode.Value).ToString()) : String.Empty;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView2.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView3 Cell Value Needed Event.
        /// </summary>
        private void DevGridView3_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > KMDevices.Count - 1) { return; }
                switch (DevGridView3.Columns[e.ColumnIndex].Name) {
                    case "IDColumn3":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "RegionNameColumn3":
                        e.Value = KMDevices[e.RowIndex].Area2Name;
                        break;
                    case "CityNameColumn3":
                        e.Value = KMDevices[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn3":
                        e.Value = KMDevices[e.RowIndex].StaName;
                        break;
                    case "DevIDColumn3":
                        e.Value = KMDevices[e.RowIndex].DevID;
                        break;
                    case "DevNameColumn3":
                        e.Value = KMDevices[e.RowIndex].DevName;
                        break;
                    case "RecDescColumn3":
                        e.Value = KMDevices[e.RowIndex].CardRecord != null ? KMDevices[e.RowIndex].CardRecord.Remark : String.Empty;
                        break;
                    case "RecTimeColumn3":
                        e.Value = KMDevices[e.RowIndex].CardRecord != null ? Common.GetDateTimeString(KMDevices[e.RowIndex].CardRecord.CardTime) : String.Empty;
                        break;
                    case "RecCardSnColumn3":
                        e.Value = KMDevices[e.RowIndex].CardRecord != null ? KMDevices[e.RowIndex].CardRecord.CardSn : String.Empty;
                        break;
                    case "WorkerColumn3":
                        e.Value = KMDevices[e.RowIndex].CardRecord != null && KMDevices[e.RowIndex].CardRecord.Card != null ? String.Format("{0} - {1}", KMDevices[e.RowIndex].CardRecord.Card.WorkerId, KMDevices[e.RowIndex].CardRecord.Card.WorkerName) : String.Empty;
                        break;
                    case "WorkerTypeColumn3":
                        e.Value = KMDevices[e.RowIndex].CardRecord != null && KMDevices[e.RowIndex].CardRecord.Card != null ? ComUtility.GetWorkerTypeText(KMDevices[e.RowIndex].CardRecord.Card.WorkerType) : String.Empty;
                        break;
                    case "DeptColumn3":
                        e.Value = KMDevices[e.RowIndex].CardRecord != null && KMDevices[e.RowIndex].CardRecord.Card != null ? String.Format("{0} - {1}", KMDevices[e.RowIndex].CardRecord.Card.DepId, KMDevices[e.RowIndex].CardRecord.Card.DepName) : String.Empty;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView3.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView4 Cell Value Needed Event.
        /// </summary>
        private void DevGridView4_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > LJDevices.Count - 1) { return; }
                switch (DevGridView4.Columns[e.ColumnIndex].Name) {
                    case "IDColumn4":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "RegionNameColumn4":
                        e.Value = LJDevices[e.RowIndex].Area2Name;
                        break;
                    case "CityNameColumn4":
                        e.Value = LJDevices[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn4":
                        e.Value = LJDevices[e.RowIndex].StaName;
                        break;
                    case "DevIDColumn4":
                        e.Value = LJDevices[e.RowIndex].DevID;
                        break;
                    case "DevNameColumn4":
                        e.Value = LJDevices[e.RowIndex].DevName;
                        break;
                    case "StatusColumn4":
                        e.Value = LJDevices[e.RowIndex].StatusNode != null ? ComUtility.GetDesc(LJDevices[e.RowIndex].StatusNode.Remark, ((Int32)LJDevices[e.RowIndex].StatusNode.Value).ToString()) : String.Empty;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView4.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView5 Cell Value Needed Event.
        /// </summary>
        private void DevGridView5_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > QZDevices.Count - 1) { return; }
                switch (DevGridView5.Columns[e.ColumnIndex].Name) {
                    case "IDColumn5":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "RegionNameColumn5":
                        e.Value = QZDevices[e.RowIndex].Area2Name;
                        break;
                    case "CityNameColumn5":
                        e.Value = QZDevices[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn5":
                        e.Value = QZDevices[e.RowIndex].StaName;
                        break;
                    case "DevIDColumn5":
                        e.Value = QZDevices[e.RowIndex].DevID;
                        break;
                    case "DevNameColumn5":
                        e.Value = QZDevices[e.RowIndex].DevName;
                        break;
                    case "RecDescColumn5":
                        e.Value = QZDevices[e.RowIndex].CardRecord != null ? QZDevices[e.RowIndex].CardRecord.Remark : String.Empty;
                        break;
                    case "RecTimeColumn5":
                        e.Value = QZDevices[e.RowIndex].CardRecord != null ? Common.GetDateTimeString(QZDevices[e.RowIndex].CardRecord.CardTime) : String.Empty;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView5.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView6 Cell Value Needed Event.
        /// </summary>
        private void DevGridView6_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > YCDevices.Count - 1) { return; }
                switch (DevGridView6.Columns[e.ColumnIndex].Name) {
                    case "IDColumn6":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "RegionNameColumn6":
                        e.Value = YCDevices[e.RowIndex].Area2Name;
                        break;
                    case "CityNameColumn6":
                        e.Value = YCDevices[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn6":
                        e.Value = YCDevices[e.RowIndex].StaName;
                        break;
                    case "DevIDColumn6":
                        e.Value = YCDevices[e.RowIndex].DevID;
                        break;
                    case "DevNameColumn6":
                        e.Value = YCDevices[e.RowIndex].DevName;
                        break;
                    case "RecDescColumn6":
                        e.Value = YCDevices[e.RowIndex].CardRecord != null ? YCDevices[e.RowIndex].CardRecord.Remark : String.Empty;
                        break;
                    case "RecTimeColumn6":
                        e.Value = YCDevices[e.RowIndex].CardRecord != null ? Common.GetDateTimeString(YCDevices[e.RowIndex].CardRecord.CardTime) : String.Empty;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView6.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView Cell Content Double Click Event.
        /// </summary>
        private void DevGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex < 0) { return; }
                var devId = DevGridView1.Rows[e.RowIndex].Cells["DevIDColumn1"].Value.ToString();
                var nodes = DeviceTreeView.Nodes.Find(devId, true);
                if (nodes != null && nodes.Length > 0) {
                    DeviceTreeView.SelectedNode = nodes[0];
                } else {
                    MessageBox.Show("未找到相关匹配项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView1.CellContentDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView Cell Content Double Click Event.
        /// </summary>
        private void DevGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex < 0) { return; }
                var devId = DevGridView2.Rows[e.RowIndex].Cells["DevIDColumn2"].Value.ToString();
                var nodes = DeviceTreeView.Nodes.Find(devId, true);
                if (nodes != null && nodes.Length > 0) {
                    DeviceTreeView.SelectedNode = nodes[0];
                } else {
                    MessageBox.Show("未找到相关匹配项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView2.CellContentDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView Cell Content Double Click Event.
        /// </summary>
        private void DevGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex < 0) { return; }
                var devId = DevGridView3.Rows[e.RowIndex].Cells["DevIDColumn3"].Value.ToString();
                var nodes = DeviceTreeView.Nodes.Find(devId, true);
                if (nodes != null && nodes.Length > 0) {
                    DeviceTreeView.SelectedNode = nodes[0];
                } else {
                    MessageBox.Show("未找到相关匹配项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView3.CellContentDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView Cell Content Double Click Event.
        /// </summary>
        private void DevGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex < 0) { return; }
                var devId = DevGridView4.Rows[e.RowIndex].Cells["DevIDColumn4"].Value.ToString();
                var nodes = DeviceTreeView.Nodes.Find(devId, true);
                if (nodes != null && nodes.Length > 0) {
                    DeviceTreeView.SelectedNode = nodes[0];
                } else {
                    MessageBox.Show("未找到相关匹配项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView4.CellContentDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView Cell Content Double Click Event.
        /// </summary>
        private void DevGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex < 0) { return; }
                var devId = DevGridView5.Rows[e.RowIndex].Cells["DevIDColumn5"].Value.ToString();
                var nodes = DeviceTreeView.Nodes.Find(devId, true);
                if (nodes != null && nodes.Length > 0) {
                    DeviceTreeView.SelectedNode = nodes[0];
                } else {
                    MessageBox.Show("未找到相关匹配项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView5.CellContentDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView Cell Content Double Click Event.
        /// </summary>
        private void DevGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex < 0) { return; }
                var devId = DevGridView6.Rows[e.RowIndex].Cells["DevIDColumn6"].Value.ToString();
                var nodes = DeviceTreeView.Nodes.Find(devId, true);
                if (nodes != null && nodes.Length > 0) {
                    DeviceTreeView.SelectedNode = nodes[0];
                } else {
                    MessageBox.Show("未找到相关匹配项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevGridView6.CellContentDoubleClick", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device Context Menu Opening Event.
        /// </summary>
        private void DevContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            try {
                DevMenuItem1.Enabled = false;
                DevMenuItem2.Enabled = false;
                DevMenuItem3.Enabled = false;
                switch (DevTabControl.SelectedIndex) {
                    case 0:
                        if (DevGridView1.SelectedRows.Count > 0
                            && runState == EnmRunState.Run
                            && workerClient.LinkState == EnmLinkState.Authentication) {
                            var index = DevGridView1.SelectedRows[0].Index;
                            if (CurDevices.Count > index) {
                                DevMenuItem1.Enabled = CurDevices[index].StatusNode != null && CurDevices[index].StatusNode.Value == 0F && CurDevices[index].StatusNode.Status != EnmState.Invalid;
                            }
                        }
                        DevMenuItem2.Enabled = DevGridView1.SelectedRows.Count > 0;
                        DevMenuItem3.Enabled = DevGridView1.Rows.Count > 0;
                        DevMenuItem4.Enabled = true;
                        break;
                    case 1:
                        if (DevGridView2.SelectedRows.Count > 0
                            && runState == EnmRunState.Run
                            && workerClient.LinkState == EnmLinkState.Authentication) {
                            var index = DevGridView2.SelectedRows[0].Index;
                            if (GMDevices.Count > index) {
                                DevMenuItem1.Enabled = GMDevices[index].StatusNode != null && GMDevices[index].StatusNode.Status != EnmState.Invalid;
                            }
                        }
                        DevMenuItem2.Enabled = DevGridView2.SelectedRows.Count > 0;
                        DevMenuItem3.Enabled = DevGridView2.Rows.Count > 0;
                        DevMenuItem4.Enabled = false;
                        break;
                    case 2:
                        DevMenuItem2.Enabled = DevGridView3.SelectedRows.Count > 0;
                        DevMenuItem3.Enabled = DevGridView3.Rows.Count > 0;
                        DevMenuItem4.Enabled = false;
                        break;
                    case 3:
                        DevMenuItem2.Enabled = DevGridView4.SelectedRows.Count > 0;
                        DevMenuItem3.Enabled = DevGridView4.Rows.Count > 0;
                        DevMenuItem4.Enabled = false;
                        break;
                    case 4:
                        DevMenuItem2.Enabled = DevGridView5.SelectedRows.Count > 0;
                        DevMenuItem3.Enabled = DevGridView5.Rows.Count > 0;
                        DevMenuItem4.Enabled = false;
                        break;
                    case 5:
                        DevMenuItem2.Enabled = DevGridView6.SelectedRows.Count > 0;
                        DevMenuItem3.Enabled = DevGridView6.Rows.Count > 0;
                        DevMenuItem4.Enabled = false;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevContextMenuStrip.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device Menu Item1 Click Event.
        /// </summary>
        private void DevMenuItem1_Click(object sender, EventArgs e) {
            try {
                var Lsc = NodeEntity.GetLsc();
                if (Lsc.Count == 0) {
                    MessageBox.Show("未找到Lsc配置信息", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (DevTabControl.SelectedIndex) {
                    case 0:
                        if (DevGridView1.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要远程开门的设备", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index1 = DevGridView1.SelectedRows[0].Index;
                        if (CurDevices.Count > index1) {
                            var dev = CurDevices[index1];
                            if (dev.RemoteNode == null) {
                                MessageBox.Show("未找到设备的远程开门测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (MessageBox.Show("您确定要远程开门吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                                lock (orderQueue) {
                                    orderQueue.Enqueue(new OrderInfo() {
                                        TargetID = dev.RemoteNode.NodeID,
                                        TargetType = dev.RemoteNode.NodeType,
                                        OrderType = EnmActType.SetDoc,
                                        RelValue1 = "0",
                                        RelValue2 = Lsc.First().Key.ToString(),
                                        RelValue3 = "0",
                                        RelValue4 = Common.CurUser.UserName,
                                        RelValue5 = String.Empty
                                    });
                                }

                                Common.WriteLog(DateTime.Now, EnmMsgType.Remote, Common.CurUser.UserName, "Delta.MPS.AccessSystem.MainForm.DevMenuItem1.Click", String.Format("下发远程开门指令[设备:{0} 用户:{1}]", dev.RemoteNode.NodeID, Common.CurUser.UserName), null);
                                MessageBox.Show("远程开门指令已下发", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case 1:
                        if (DevGridView2.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要远程开门的设备", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index2 = DevGridView2.SelectedRows[0].Index;
                        if (GMDevices.Count > index2) {
                            var dev = GMDevices[index2];
                            if (dev.RemoteNode == null) {
                                MessageBox.Show("未找到设备的远程开门测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (MessageBox.Show("您确定要远程开门吗？", "确认对话框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK) {
                                lock (orderQueue) {
                                    orderQueue.Enqueue(new OrderInfo() {
                                        TargetID = dev.RemoteNode.NodeID,
                                        TargetType = dev.RemoteNode.NodeType,
                                        OrderType = EnmActType.SetDoc,
                                        RelValue1 = "0",
                                        RelValue2 = Lsc.First().Key.ToString(),
                                        RelValue3 = "0",
                                        RelValue4 = Common.CurUser.UserName,
                                        RelValue5 = String.Empty
                                    });
                                }

                                Common.WriteLog(DateTime.Now, EnmMsgType.Remote, Common.CurUser.UserName, "Delta.MPS.AccessSystem.MainForm.DevMenuItem1.Click", String.Format("下发远程开门指令[设备:{0} 用户:{1}]", dev.RemoteNode.NodeID, Common.CurUser.UserName), null);
                                MessageBox.Show("远程开门指令已下发", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device Menu Item2 Click Event.
        /// </summary>
        private void DevMenuItem2_Click(object sender, EventArgs e) {
            try {
                DeviceInfo TargetDev = null;
                switch (DevTabControl.SelectedIndex) {
                    case 0:
                        if (DevGridView1.SelectedRows.Count > 0) {
                            var index = DevGridView1.SelectedRows[0].Index;
                            if (CurDevices.Count > index) {
                                TargetDev = CurDevices[index];
                            }
                        }
                        break;
                    case 1:
                        if (DevGridView2.SelectedRows.Count > 0) {
                            var index = DevGridView2.SelectedRows[0].Index;
                            if (GMDevices.Count > index) {
                                TargetDev = GMDevices[index];
                            }
                        }
                        break;
                    case 2:
                        if (DevGridView3.SelectedRows.Count > 0) {
                            var index = DevGridView3.SelectedRows[0].Index;
                            if (KMDevices.Count > index) {
                                TargetDev = KMDevices[index];
                            }
                        }
                        break;
                    case 3:
                        if (DevGridView4.SelectedRows.Count > 0) {
                            var index = DevGridView4.SelectedRows[0].Index;
                            if (LJDevices.Count > index) {
                                TargetDev = LJDevices[index];
                            }
                        }
                        break;
                    case 4:
                        if (DevGridView5.SelectedRows.Count > 0) {
                            var index = DevGridView5.SelectedRows[0].Index;
                            if (QZDevices.Count > index) {
                                TargetDev = QZDevices[index];
                            }
                        }
                        break;
                    case 5:
                        if (DevGridView6.SelectedRows.Count > 0) {
                            var index = DevGridView6.SelectedRows[0].Index;
                            if (YCDevices.Count > index) {
                                TargetDev = YCDevices[index];
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (TargetDev == null) {
                    MessageBox.Show("请选择需要查询的设备", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                new HisCardRecordsForm(TargetDev).ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device Menu Item3 Click Event.
        /// </summary>
        private void DevMenuItem3_Click(object sender, EventArgs e) {
            try {
                var data = new DataTable();
                var colors = new Dictionary<Int32, Excel.Color>();
                switch (DevTabControl.SelectedIndex) {
                    case 0:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("地区", typeof(String));
                        data.Columns.Add("县市", typeof(String));
                        data.Columns.Add("局站", typeof(String));
                        data.Columns.Add("设备编号", typeof(String));
                        data.Columns.Add("设备名称", typeof(String));
                        data.Columns.Add("状态", typeof(String));
                        for (var i = 0; i < CurDevices.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = i + 1;
                            dr["地区"] = CurDevices[i].Area2Name;
                            dr["县市"] = CurDevices[i].Area3Name;
                            dr["局站"] = CurDevices[i].StaName;
                            dr["设备编号"] = CurDevices[i].DevID.ToString();
                            dr["设备名称"] = CurDevices[i].DevName;
                            dr["状态"] = CurDevices[i].StatusNode != null ? ComUtility.GetDesc(CurDevices[i].StatusNode.Remark, ((Int32)CurDevices[i].StatusNode.Value).ToString()) : String.Empty;
                            data.Rows.Add(dr);

                            if (DevMenuItem4.Checked) {
                                colors[i] = CurDevices[i].StatusNode != null ? Common.GetExcelStateColor(CurDevices[i].StatusNode.Status) : Excel.Colors.White;
                            }
                        }

                        Common.ExportDataToExcel(null, "所有门禁状态信息", "智能门禁管理系统 所有门禁状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 1:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("地区", typeof(String));
                        data.Columns.Add("县市", typeof(String));
                        data.Columns.Add("局站", typeof(String));
                        data.Columns.Add("设备编号", typeof(String));
                        data.Columns.Add("设备名称", typeof(String));
                        data.Columns.Add("状态", typeof(String));
                        for (var i = 0; i < GMDevices.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = i + 1;
                            dr["地区"] = GMDevices[i].Area2Name;
                            dr["县市"] = GMDevices[i].Area3Name;
                            dr["局站"] = GMDevices[i].StaName;
                            dr["设备编号"] = GMDevices[i].DevID.ToString();
                            dr["设备名称"] = GMDevices[i].DevName;
                            dr["状态"] = GMDevices[i].StatusNode != null ? ComUtility.GetDesc(GMDevices[i].StatusNode.Remark, ((Int32)GMDevices[i].StatusNode.Value).ToString()) : String.Empty;
                            data.Rows.Add(dr);
                        }

                        Common.ExportDataToExcel(null, "已关门禁状态信息", "智能门禁管理系统 已关门禁状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 2:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("地区", typeof(String));
                        data.Columns.Add("县市", typeof(String));
                        data.Columns.Add("局站", typeof(String));
                        data.Columns.Add("设备编号", typeof(String));
                        data.Columns.Add("设备名称", typeof(String));
                        data.Columns.Add("开门描述", typeof(String));
                        data.Columns.Add("开门时间", typeof(String));
                        data.Columns.Add("开门卡号", typeof(String));
                        data.Columns.Add("开门人员", typeof(String));
                        data.Columns.Add("人员类型", typeof(String));
                        data.Columns.Add("所属部门", typeof(String));
                        for (var i = 0; i < KMDevices.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = i + 1;
                            dr["地区"] = KMDevices[i].Area2Name;
                            dr["县市"] = KMDevices[i].Area3Name;
                            dr["局站"] = KMDevices[i].StaName;
                            dr["设备编号"] = KMDevices[i].DevID.ToString();
                            dr["设备名称"] = KMDevices[i].DevName;
                            dr["开门描述"] = KMDevices[i].CardRecord != null ? KMDevices[i].CardRecord.Remark : String.Empty;
                            dr["开门时间"] = KMDevices[i].CardRecord != null ? Common.GetDateTimeString(KMDevices[i].CardRecord.CardTime) : String.Empty;
                            dr["开门卡号"] = KMDevices[i].CardRecord != null ? KMDevices[i].CardRecord.CardSn : String.Empty;
                            dr["开门人员"] = KMDevices[i].CardRecord != null && KMDevices[i].CardRecord.Card != null ? String.Format("{0} - {1}", KMDevices[i].CardRecord.Card.WorkerId, KMDevices[i].CardRecord.Card.WorkerName) : String.Empty;
                            dr["人员类型"] = KMDevices[i].CardRecord != null && KMDevices[i].CardRecord.Card != null ? ComUtility.GetWorkerTypeText(KMDevices[i].CardRecord.Card.WorkerType) : String.Empty;
                            dr["所属部门"] = KMDevices[i].CardRecord != null && KMDevices[i].CardRecord.Card != null ? String.Format("{0} - {1}", KMDevices[i].CardRecord.Card.DepId, KMDevices[i].CardRecord.Card.DepName) : String.Empty;
                            data.Rows.Add(dr);
                        }

                        Common.ExportDataToExcel(null, "已开门禁状态信息", "智能门禁管理系统 已开门禁状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 3:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("地区", typeof(String));
                        data.Columns.Add("县市", typeof(String));
                        data.Columns.Add("局站", typeof(String));
                        data.Columns.Add("设备编号", typeof(String));
                        data.Columns.Add("设备名称", typeof(String));
                        data.Columns.Add("状态", typeof(String));
                        for (var i = 0; i < LJDevices.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = i + 1;
                            dr["地区"] = LJDevices[i].Area2Name;
                            dr["县市"] = LJDevices[i].Area3Name;
                            dr["局站"] = LJDevices[i].StaName;
                            dr["设备编号"] = LJDevices[i].DevID.ToString();
                            dr["设备名称"] = LJDevices[i].DevName;
                            dr["状态"] = LJDevices[i].StatusNode != null ? ComUtility.GetDesc(LJDevices[i].StatusNode.Remark, ((Int32)LJDevices[i].StatusNode.Value).ToString()) : String.Empty;
                            data.Rows.Add(dr);
                        }

                        Common.ExportDataToExcel(null, "连接异常门禁状态信息", "智能门禁管理系统 连接异常门禁状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 4:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("地区", typeof(String));
                        data.Columns.Add("县市", typeof(String));
                        data.Columns.Add("局站", typeof(String));
                        data.Columns.Add("设备编号", typeof(String));
                        data.Columns.Add("设备名称", typeof(String));
                        data.Columns.Add("开门描述", typeof(String));
                        data.Columns.Add("开门时间", typeof(String));
                        for (var i = 0; i < QZDevices.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = i + 1;
                            dr["地区"] = QZDevices[i].Area2Name;
                            dr["县市"] = QZDevices[i].Area3Name;
                            dr["局站"] = QZDevices[i].StaName;
                            dr["设备编号"] = QZDevices[i].DevID.ToString();
                            dr["设备名称"] = QZDevices[i].DevName;
                            dr["开门描述"] = QZDevices[i].CardRecord != null ? QZDevices[i].CardRecord.Remark : String.Empty;
                            dr["开门时间"] = QZDevices[i].CardRecord != null ? Common.GetDateTimeString(QZDevices[i].CardRecord.CardTime) : String.Empty;
                            data.Rows.Add(dr);
                        }

                        Common.ExportDataToExcel(null, "强制开门门禁状态信息", "智能门禁管理系统 强制开门门禁状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 5:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("地区", typeof(String));
                        data.Columns.Add("县市", typeof(String));
                        data.Columns.Add("局站", typeof(String));
                        data.Columns.Add("设备编号", typeof(String));
                        data.Columns.Add("设备名称", typeof(String));
                        data.Columns.Add("开门描述", typeof(String));
                        data.Columns.Add("开门时间", typeof(String));
                        for (var i = 0; i < YCDevices.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = i + 1;
                            dr["地区"] = YCDevices[i].Area2Name;
                            dr["县市"] = YCDevices[i].Area3Name;
                            dr["局站"] = YCDevices[i].StaName;
                            dr["设备编号"] = YCDevices[i].DevID.ToString();
                            dr["设备名称"] = YCDevices[i].DevName;
                            dr["开门描述"] = YCDevices[i].CardRecord != null ? YCDevices[i].CardRecord.Remark : String.Empty;
                            dr["开门时间"] = YCDevices[i].CardRecord != null ? Common.GetDateTimeString(YCDevices[i].CardRecord.CardTime) : String.Empty;
                            data.Rows.Add(dr);
                        }

                        Common.ExportDataToExcel(null, "远程开门门禁状态信息", "智能门禁管理系统 远程开门门禁状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device Menu Item4 Checked Changed Event.
        /// </summary>
        private void DevMenuItem4_CheckedChanged(object sender, EventArgs e) {
            try {
                DevGridView1.Invalidate(DevGridView1.DisplayRectangle);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevMenuItem4.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Node GridView Cell Value Needed Event.
        /// </summary>
        private void NodeGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurNodes.Count - 1) { return; }
                switch (NodeGridView.Columns[e.ColumnIndex].Name) {
                    case "DotIDColumn1":
                        e.Value = CurNodes[e.RowIndex].DotID;
                        break;
                    case "NodeTypeColumn1":
                        e.Value = Common.GetNodeTypeName(CurNodes[e.RowIndex].NodeType);
                        break;
                    case "NodeIDColumn1":
                        e.Value = CurNodes[e.RowIndex].NodeID;
                        break;
                    case "NodeNameColumn1":
                        e.Value = CurNodes[e.RowIndex].NodeName;
                        if (FilterNodeId != -1) {
                            var index = CurNodes.FindIndex(n => n.NodeID == FilterNodeId); 
                            if (index > -1 && index < NodeGridView.Rows.Count) {
                                NodeGridView.FirstDisplayedScrollingRowIndex = index;
                                NodeGridView.Rows[index].Selected = true;
                            }
                            FilterNodeId = -1;
                        }
                        break;
                    case "NodeValueColumn1":
                        e.Value = Common.GetNodeValue(CurNodes[e.RowIndex]);
                        NodeGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = NodeMenuItem5.Checked ? Common.GetStateColor(CurNodes[e.RowIndex].Status) : Color.White;
                        break;
                    case "NodeTimeColumn1":
                        e.Value = Common.GetDateTimeString(CurNodes[e.RowIndex].DateTime);
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.NodeGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DI GridView Cell Value Needed Event.
        /// </summary>
        private void DIGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > DINodes.Count - 1) { return; }
                switch (DIGridView.Columns[e.ColumnIndex].Name) {
                    case "DotIDColumn2":
                        e.Value = DINodes[e.RowIndex].DotID;
                        break;
                    case "NodeIDColumn2":
                        e.Value = DINodes[e.RowIndex].NodeID;
                        break;
                    case "NodeNameColumn2":
                        e.Value = DINodes[e.RowIndex].NodeName;
                        break;
                    case "NodeValueColumn2":
                        e.Value = Common.GetNodeValue(DINodes[e.RowIndex]);
                        DIGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = NodeMenuItem5.Checked ? Common.GetStateColor(DINodes[e.RowIndex].Status) : Color.White;
                        break;
                    case "NodeTimeColumn2":
                        e.Value = Common.GetDateTimeString(DINodes[e.RowIndex].DateTime);
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DIGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DO GridView Cell Value Needed Event.
        /// </summary>
        private void DOGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > DONodes.Count - 1) { return; }
                switch (DOGridView.Columns[e.ColumnIndex].Name) {
                    case "DotIDColumn3":
                        e.Value = DONodes[e.RowIndex].DotID;
                        break;
                    case "NodeIDColumn3":
                        e.Value = DONodes[e.RowIndex].NodeID;
                        break;
                    case "NodeNameColumn3":
                        e.Value = DONodes[e.RowIndex].NodeName;
                        break;
                    case "NodeValueColumn3":
                        e.Value = Common.GetNodeValue(DONodes[e.RowIndex]);
                        DOGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = NodeMenuItem5.Checked ? Common.GetStateColor(DONodes[e.RowIndex].Status) : Color.White;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DOGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// AI GridView Cell Value Needed Event.
        /// </summary>
        private void AIGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > AINodes.Count - 1) { return; }
                switch (AIGridView.Columns[e.ColumnIndex].Name) {
                    case "DotIDColumn4":
                        e.Value = AINodes[e.RowIndex].DotID;
                        break;
                    case "NodeIDColumn4":
                        e.Value = AINodes[e.RowIndex].NodeID;
                        break;
                    case "NodeNameColumn4":
                        e.Value = AINodes[e.RowIndex].NodeName;
                        break;
                    case "NodeValueColumn4":
                        e.Value = Common.GetNodeValue(AINodes[e.RowIndex]);
                        AIGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = NodeMenuItem5.Checked ? Common.GetStateColor(AINodes[e.RowIndex].Status) : Color.White;
                        break;
                    case "NodeTimeColumn4":
                        e.Value = Common.GetDateTimeString(AINodes[e.RowIndex].DateTime);
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.AIGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// AO GridView Cell Value Needed Event.
        /// </summary>
        private void AOGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > AONodes.Count - 1) { return; }
                switch (AOGridView.Columns[e.ColumnIndex].Name) {
                    case "DotIDColumn5":
                        e.Value = AONodes[e.RowIndex].DotID;
                        break;
                    case "NodeIDColumn5":
                        e.Value = AONodes[e.RowIndex].NodeID;
                        break;
                    case "NodeNameColumn5":
                        e.Value = AONodes[e.RowIndex].NodeName;
                        break;
                    case "NodeValueColumn5":
                        e.Value = Common.GetNodeValue(AONodes[e.RowIndex]);
                        AOGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = NodeMenuItem5.Checked ? Common.GetStateColor(AONodes[e.RowIndex].Status) : Color.White;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.AOGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Node Context Menu Opening Event.
        /// </summary>
        private void NodeContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            try {
                NodeMenuItem1.Enabled = false;
                NodeMenuItem2.Enabled = false;
                NodeMenuItem3.Enabled = false;
                NodeMenuItem4.Enabled = false;
                switch (NodeTabControl.SelectedIndex) {
                    case 0:
                        if (NodeGridView.SelectedRows.Count > 0
                            && runState == EnmRunState.Run
                            && workerClient.LinkState == EnmLinkState.Authentication) {
                            var index = NodeGridView.SelectedRows[0].Index;
                            if (CurNodes.Count > index) {
                                NodeMenuItem1.Enabled = CurNodes[index].NodeType == EnmNodeType.Doc;
                                NodeMenuItem2.Enabled = CurNodes[index].NodeType == EnmNodeType.Aoc;
                            }
                        }
                        NodeMenuItem3.Enabled = NodeGridView.SelectedRows.Count > 0;
                        NodeMenuItem4.Enabled = NodeGridView.Rows.Count > 0;
                        break;
                    case 1:
                        NodeMenuItem3.Enabled = DIGridView.SelectedRows.Count > 0;
                        NodeMenuItem4.Enabled = DIGridView.Rows.Count > 0;
                        break;
                    case 2:
                        if (DOGridView.SelectedRows.Count > 0
                            && runState == EnmRunState.Run
                            && workerClient.LinkState == EnmLinkState.Authentication) {
                            var index = DOGridView.SelectedRows[0].Index;
                            if (DONodes.Count > index) {
                                NodeMenuItem1.Enabled = DONodes[index].NodeType == EnmNodeType.Doc;
                            }
                        }
                        NodeMenuItem3.Enabled = DOGridView.SelectedRows.Count > 0;
                        NodeMenuItem4.Enabled = DOGridView.Rows.Count > 0;
                        break;
                    case 3:
                        NodeMenuItem3.Enabled = AIGridView.SelectedRows.Count > 0;
                        NodeMenuItem4.Enabled = AIGridView.Rows.Count > 0;
                        break;
                    case 4:
                        if (AOGridView.SelectedRows.Count > 0
                            && runState == EnmRunState.Run
                            && workerClient.LinkState == EnmLinkState.Authentication) {
                            var index = AOGridView.SelectedRows[0].Index;
                            if (AONodes.Count > index) {
                                NodeMenuItem2.Enabled = AONodes[index].NodeType == EnmNodeType.Aoc;
                            }
                        }
                        NodeMenuItem3.Enabled = AOGridView.SelectedRows.Count > 0;
                        NodeMenuItem4.Enabled = AOGridView.Rows.Count > 0;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.NodeContextMenuStrip.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Node Menu Item1 Click Event.
        /// </summary>
        private void NodeMenuItem1_Click(object sender, EventArgs e) {
            try {
                NodeInfo SetNode = null;
                switch (NodeTabControl.SelectedIndex) {
                    case 0:
                        if (NodeGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要远程控制的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index1 = NodeGridView.SelectedRows[0].Index;
                        if (CurNodes.Count > index1) { SetNode = CurNodes[index1]; }
                        break;
                    case 2:
                        if (DOGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要远程控制的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index2 = DOGridView.SelectedRows[0].Index;
                        if (DONodes.Count > index2) { SetNode = DONodes[index2]; }
                        break;
                    default:
                        break;
                }

                if (SetNode == null) {
                    MessageBox.Show("请选择需要远程控制的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var Dialog = new SetDOForm(SetNode);
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    if (Dialog.Orders.Count > 0) {
                        lock (orderQueue) {
                            for (var i = 0; i < Dialog.Orders.Count; i++) {
                                orderQueue.Enqueue(Dialog.Orders[i]);
                            }
                        }

                        Common.WriteLog(DateTime.Now, EnmMsgType.Remote, Common.CurUser.UserName, "Delta.MPS.AccessSystem.MainForm.NodeMenuItem1.Click", String.Format("下发远程控制指令[测点:{0} 用户:{1}]", SetNode.NodeID, Common.CurUser.UserName), null);
                        MessageBox.Show("远程控制指令已下发", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.NodeMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Node Menu Item2 Click Event.
        /// </summary>
        private void NodeMenuItem2_Click(object sender, EventArgs e) {
            try {
                NodeInfo SetNode = null;
                switch (NodeTabControl.SelectedIndex) {
                    case 0:
                        if (NodeGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要设置参数的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index1 = NodeGridView.SelectedRows[0].Index;
                        if (CurNodes.Count > index1) { SetNode = CurNodes[index1]; }
                        break;
                    case 4:
                        if (AOGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要设置参数的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index2 = AOGridView.SelectedRows[0].Index;
                        if (AONodes.Count > index2) { SetNode = AONodes[index2]; }
                        break;
                    default:
                        break;
                }

                if (SetNode == null) {
                    MessageBox.Show("请选择需要设置参数的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var Dialog = new SetAOForm(SetNode);
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    if (Dialog.Orders.Count > 0) {
                        lock (orderQueue) {
                            for (var i = 0; i < Dialog.Orders.Count; i++) {
                                orderQueue.Enqueue(Dialog.Orders[i]);
                            }
                        }

                        Common.WriteLog(DateTime.Now, EnmMsgType.Remote, Common.CurUser.UserName, "Delta.MPS.AccessSystem.MainForm.NodeMenuItem2.Click", String.Format("下发参数设置指令[测点:{0} 用户:{1}]", SetNode.NodeID, Common.CurUser.UserName), null);
                        MessageBox.Show("参数设置指令已下发", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.NodeMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Node Menu Item3 Click Event.
        /// </summary>
        private void NodeMenuItem3_Click(object sender, EventArgs e) {
            try {
                NodeInfo SetNode = null;
                switch (NodeTabControl.SelectedIndex) {
                    case 0:
                        if (NodeGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要查询的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index1 = NodeGridView.SelectedRows[0].Index;
                        if (CurNodes.Count > index1) { SetNode = CurNodes[index1]; }
                        break;
                    case 1:
                        if (DIGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要查询的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index2 = DIGridView.SelectedRows[0].Index;
                        if (DINodes.Count > index2) { SetNode = DINodes[index2]; }
                        break;
                    case 2:
                        if (DOGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要查询的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index3 = DOGridView.SelectedRows[0].Index;
                        if (DONodes.Count > index3) { SetNode = DONodes[index3]; }
                        break;
                    case 3:
                        if (AIGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要查询的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index4 = AIGridView.SelectedRows[0].Index;
                        if (AINodes.Count > index4) { SetNode = AINodes[index4]; }
                        break;
                    case 4:
                        if (AOGridView.SelectedRows.Count == 0) {
                            MessageBox.Show("请选择需要查询的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var index5 = AOGridView.SelectedRows[0].Index;
                        if (AONodes.Count > index5) { SetNode = AONodes[index5]; }
                        break;
                    default:
                        break;
                }

                if (SetNode == null) {
                    MessageBox.Show("请选择需要查询的测点", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                new HisAlarmForm(SetNode).ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.NodeMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Node Menu Item4 Click Event.
        /// </summary>
        private void NodeMenuItem4_Click(object sender, EventArgs e) {
            try {
                var data = new DataTable();
                var colors = new Dictionary<Int32, Excel.Color>();
                switch (NodeTabControl.SelectedIndex) {
                    case 0:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("类型", typeof(String));
                        data.Columns.Add("测点名称", typeof(String));
                        data.Columns.Add("监测值", typeof(String));
                        data.Columns.Add("告警时间", typeof(String));
                        for (var i = 0; i < CurNodes.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = CurNodes[i].DotID;
                            dr["类型"] = Common.GetNodeTypeName(CurNodes[i].NodeType);
                            dr["测点名称"] = CurNodes[i].NodeName;
                            dr["监测值"] = Common.GetNodeValue(CurNodes[i]);
                            dr["告警时间"] = Common.GetDateTimeString(CurNodes[i].DateTime);
                            data.Rows.Add(dr);

                            if (NodeMenuItem5.Checked) {
                                colors[i] = Common.GetExcelStateColor(CurNodes[i].Status);
                            }
                        }

                        Common.ExportDataToExcel(null, "所有测点状态信息", "智能门禁管理系统 所有测点状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 1:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("测点名称", typeof(String));
                        data.Columns.Add("状态", typeof(String));
                        data.Columns.Add("告警时间", typeof(String));
                        for (var i = 0; i < DINodes.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = DINodes[i].DotID;
                            dr["测点名称"] = DINodes[i].NodeName;
                            dr["状态"] = Common.GetNodeValue(DINodes[i]);
                            dr["告警时间"] = Common.GetDateTimeString(DINodes[i].DateTime);
                            data.Rows.Add(dr);

                            if (NodeMenuItem5.Checked) {
                                colors[i] = Common.GetExcelStateColor(DINodes[i].Status);
                            }
                        }

                        Common.ExportDataToExcel(null, "遥信测点状态信息", "智能门禁管理系统 遥信测点状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 2:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("测点名称", typeof(String));
                        data.Columns.Add("状态", typeof(String));
                        for (var i = 0; i < DONodes.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = DONodes[i].DotID;
                            dr["测点名称"] = DONodes[i].NodeName;
                            dr["状态"] = Common.GetNodeValue(DONodes[i]);
                            data.Rows.Add(dr);

                            if (NodeMenuItem5.Checked) {
                                colors[i] = Common.GetExcelStateColor(DONodes[i].Status);
                            }
                        }

                        Common.ExportDataToExcel(null, "遥控测点状态信息", "智能门禁管理系统 遥控测点状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 3:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("测点名称", typeof(String));
                        data.Columns.Add("监测值", typeof(String));
                        data.Columns.Add("告警时间", typeof(String));
                        for (var i = 0; i < AINodes.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = AINodes[i].DotID;
                            dr["测点名称"] = AINodes[i].NodeName;
                            dr["监测值"] = Common.GetNodeValue(AINodes[i]);
                            dr["告警时间"] = Common.GetDateTimeString(AINodes[i].DateTime);
                            data.Rows.Add(dr);

                            if (NodeMenuItem5.Checked) {
                                colors[i] = Common.GetExcelStateColor(AINodes[i].Status);
                            }
                        }

                        Common.ExportDataToExcel(null, "遥测测点状态信息", "智能门禁管理系统 遥测测点状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    case 4:
                        data.Columns.Add("序号", typeof(String));
                        data.Columns.Add("测点名称", typeof(String));
                        data.Columns.Add("监测值", typeof(String));
                        for (var i = 0; i < AONodes.Count; i++) {
                            var dr = data.NewRow();
                            dr["序号"] = AONodes[i].DotID;
                            dr["测点名称"] = AONodes[i].NodeName;
                            dr["监测值"] = Common.GetNodeValue(AONodes[i]);
                            data.Rows.Add(dr);

                            if (NodeMenuItem5.Checked) {
                                colors[i] = Common.GetExcelStateColor(AONodes[i].Status);
                            }
                        }

                        Common.ExportDataToExcel(null, "遥调测点状态信息", "智能门禁管理系统 遥调测点状态报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.NodeMenuItem4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Node Menu Item5 Checked Changed Event.
        /// </summary>
        private void NodeMenuItem5_CheckedChanged(object sender, EventArgs e) {
            try {
                switch (NodeTabControl.SelectedIndex) {
                    case 0:
                        NodeGridView.Invalidate(NodeGridView.DisplayRectangle);
                        break;
                    case 1:
                        DIGridView.Invalidate(DIGridView.DisplayRectangle);
                        break;
                    case 2:
                        DOGridView.Invalidate(DOGridView.DisplayRectangle);
                        break;
                    case 3:
                        AIGridView.Invalidate(AIGridView.DisplayRectangle);
                        break;
                    case 4:
                        AOGridView.Invalidate(AOGridView.DisplayRectangle);
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.NodeMenuItem5.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// GridView Cell Mouse Down Event.
        /// </summary>
        private void GridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            try {
                if (e.Button == MouseButtons.Right && e.RowIndex > -1) {
                    var obj = (DataGridView)sender;
                    obj.ClearSelection();
                    obj.Rows[e.RowIndex].Selected = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.GridView.CellMouseDown", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Area2 Name Combobox SelectedIndex Changed Event.
        /// </summary>
        private void Area2NameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                AlarmGridView.Tag = "0";
                BindArea3ToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.Area2NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Area3 Name Combobox SelectedIndex Changed Event.
        /// </summary>
        private void Area3NameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                AlarmGridView.Tag = "0";
                BindStaToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.Area3NameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Station Name Combobox SelectedIndex Changed Event.
        /// </summary>
        private void StaNameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                AlarmGridView.Tag = "0";
                BindDevToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.StaNameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device Name Combobox SelectedIndex Changed Event.
        /// </summary>
        private void DevNameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                AlarmGridView.Tag = "0";
                BindNodeToCombobox();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DevNameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Node Name Combobox SelectedIndex Changed Event.
        /// </summary>
        private void NodeNameCB_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                AlarmGridView.Tag = "1";
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.NodeNameCB.SelectedIndexChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Alarm Level Name Combobox SelectedIndex Changed Event.
        /// </summary>
        private void AlarmLevelCB_SelectedIndexChanged(object sender, EventArgs e) {

        }

        /// <summary>
        /// Alarm GridView Cell Value Needed Event.
        /// </summary>
        private void AlarmGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > GridAlarms.Count - 1) { return; }
                switch (AlarmGridView.Columns[e.ColumnIndex].Name) {
                    case "AIDColumn":
                        e.Value = e.RowIndex + 1;
                        AlarmGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Common.GetLevelColor(GridAlarms[e.RowIndex].AlarmLevel);
                        break;
                    case "SerialNOColumn":
                        e.Value = GridAlarms[e.RowIndex].SerialNO;
                        break;
                    case "Area2Column":
                        e.Value = GridAlarms[e.RowIndex].Area2Name;
                        break;
                    case "Area3Column":
                        e.Value = GridAlarms[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn":
                        e.Value = GridAlarms[e.RowIndex].StaName;
                        break;
                    case "DevNameColumn":
                        e.Value = GridAlarms[e.RowIndex].DevName;
                        break;
                    case "NodeIDColumn":
                        e.Value = GridAlarms[e.RowIndex].NodeID;
                        break;
                    case "NodeNameColumn":
                        e.Value = GridAlarms[e.RowIndex].NodeName;
                        break;
                    case "AlarmDescColumn":
                        e.Value = GridAlarms[e.RowIndex].AlarmDesc;
                        break;
                    case "AlarmLevelColumn":
                        e.Value = (Int32)GridAlarms[e.RowIndex].AlarmLevel;
                        break;
                    case "AlarmTimeColumn":
                        e.Value = Common.GetDateTimeString(GridAlarms[e.RowIndex].StartTime);
                        break;
                    case "AlarmIntervalColumn":
                        e.Value = Common.GetTimeInterval(GridAlarms[e.RowIndex].StartTime, DateTime.Now);
                        break;
                    case "ConfirmMarkingColumn":
                        e.Value = Common.GetConfirmMarkingName(GridAlarms[e.RowIndex].ConfirmMarking);
                        break;
                    case "ConfirmTimeColumn":
                        e.Value = Common.GetDateTimeString(GridAlarms[e.RowIndex].ConfirmTime);
                        break;
                    case "ConfirmNameColumn":
                        e.Value = GridAlarms[e.RowIndex].ConfirmName;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.AlarmGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Alarm ContextMenuStrip Opening Event.
        /// </summary>
        private void AlarmContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            try {
                AlarmMenuItem1.Enabled = runState == EnmRunState.Run && workerClient.LinkState == EnmLinkState.Authentication && AlarmGridView.SelectedRows.Count > 0;
                AlarmMenuItem2.Enabled = AlarmGridView.SelectedRows.Count > 0;
                AlarmMenuItem3.Enabled = AlarmGridView.Rows.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.AlarmContextMenuStrip.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Alarm Menu Item1 Click Event.
        /// </summary>
        private void AlarmMenuItem1_Click(object sender, EventArgs e) {
            try {
                if (AlarmGridView.SelectedRows.Count == 0) {
                    MessageBox.Show("请选择需要确认的告警", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var SerialNO = (Int32)AlarmGridView.SelectedRows[0].Cells["SerialNOColumn"].Value;
                lock (orderQueue) {
                    orderQueue.Enqueue(new OrderInfo() {
                        TargetID = SerialNO,
                        TargetType = EnmNodeType.Null,
                        OrderType = EnmActType.ConfirmAlarm,
                        RelValue1 = ((Int32)EnmConfirmMarking.NotDispatch).ToString(),
                        RelValue2 = Common.CurUser.UserName,
                        RelValue3 = String.Empty,
                        RelValue4 = String.Empty,
                        RelValue5 = String.Empty
                    });
                }

                Common.WriteLog(DateTime.Now, EnmMsgType.Remote, Common.CurUser.UserName, "Delta.MPS.AccessSystem.MainForm.AlarmMenuItem1.Click", String.Format("下发告警确认指令[告警标识:{0} 用户:{1}]", SerialNO, Common.CurUser.UserName), null);
                MessageBox.Show("告警确认指令已下发", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.AlarmMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Alarm Menu Item2 Click Event.
        /// </summary>
        private Int32 FilterNodeId = -1;
        private void AlarmMenuItem2_Click(object sender, EventArgs e) {
            try {
                if (AlarmGridView.SelectedRows.Count == 0) {
                    MessageBox.Show("请选择需要确认的告警", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FilterNodeId = (Int32)AlarmGridView.SelectedRows[0].Cells["NodeIDColumn"].Value;
                var devId = Common.GetDevID(FilterNodeId);
                var nodes = DeviceTreeView.Nodes.Find(devId.ToString(), true);
                if (nodes != null && nodes.Length > 0) {
                    NodeTabControl.SelectedIndex = 0;
                    DeviceTreeView.SelectedNode = nodes[0];
                } else {
                    MessageBox.Show("未找到相关匹配项", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.AlarmMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Alarm Menu Item3 Click Event.
        /// </summary>
        private void AlarmMenuItem3_Click(object sender, EventArgs e) {
            try {
                var data = new DataTable();
                var colors = new Dictionary<Int32, Excel.Color>();

                data.Columns.Add("序号", typeof(String));
                data.Columns.Add("告警标识", typeof(String));
                data.Columns.Add("所属地区", typeof(String));
                data.Columns.Add("所属县市", typeof(String));
                data.Columns.Add("所属局站", typeof(String));
                data.Columns.Add("所属设备", typeof(String));
                data.Columns.Add("测点编号", typeof(String));
                data.Columns.Add("测点名称", typeof(String));
                data.Columns.Add("告警描述", typeof(String));
                data.Columns.Add("告警级别", typeof(String));
                data.Columns.Add("告警时间", typeof(String));
                data.Columns.Add("告警历时", typeof(String));
                data.Columns.Add("处理标识", typeof(String));
                data.Columns.Add("处理时间", typeof(String));
                data.Columns.Add("处理人员", typeof(String));

                for (var i = 0; i < GridAlarms.Count; i++) {
                    var dr = data.NewRow();
                    dr["序号"] = i + 1;
                    dr["告警标识"] = GridAlarms[i].SerialNO.ToString();
                    dr["所属地区"] = GridAlarms[i].Area2Name;
                    dr["所属县市"] = GridAlarms[i].Area3Name;
                    dr["所属局站"] = GridAlarms[i].StaName;
                    dr["所属设备"] = GridAlarms[i].DevName;
                    dr["测点编号"] = GridAlarms[i].NodeID.ToString();
                    dr["测点名称"] = GridAlarms[i].NodeName;
                    dr["告警描述"] = GridAlarms[i].AlarmDesc;
                    dr["告警级别"] = ((Int32)GridAlarms[i].AlarmLevel).ToString();
                    dr["告警时间"] = Common.GetDateTimeString(GridAlarms[i].StartTime);
                    dr["告警历时"] = Common.GetTimeInterval(GridAlarms[i].StartTime, DateTime.Now);
                    dr["处理标识"] = Common.GetConfirmMarkingName(GridAlarms[i].ConfirmMarking);
                    dr["处理时间"] = Common.GetDateTimeString(GridAlarms[i].ConfirmTime);
                    dr["处理人员"] = GridAlarms[i].ConfirmName;
                    colors[i] = Common.GetExcelAlarmColor(GridAlarms[i].AlarmLevel);
                    data.Rows.Add(dr);
                }

                Common.ExportDataToExcel(null, "实时告警信息", "智能门禁管理系统 实时告警信息报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data, colors);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.AlarmMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// History Cards GridView Cell Value Needed Event.
        /// </summary>
        private void HisCardGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > HisCardRecords.Count - 1) { return; }
                switch (HisCardGridView.Columns[e.ColumnIndex].Name) {
                    case "HCIDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "HCRecIDColumn":
                        e.Value = HisCardRecords[e.RowIndex].ID;
                        break;
                    case "HCArea2Column":
                        e.Value = HisCardRecords[e.RowIndex].Device.Area2Name;
                        break;
                    case "HCArea3Column":
                        e.Value = HisCardRecords[e.RowIndex].Device.Area3Name;
                        break;
                    case "HCStaNameColumn":
                        e.Value = HisCardRecords[e.RowIndex].Device.StaName;
                        break;
                    case "HCDevIDColumn":
                        e.Value = HisCardRecords[e.RowIndex].Device.DevID;
                        break;
                    case "HCDevNameColumn":
                        e.Value = HisCardRecords[e.RowIndex].Device.DevName;
                        break;
                    case "HCDescColumn":
                        e.Value = HisCardRecords[e.RowIndex].Remark;
                        break;
                    case "HCCardSnColumn":
                        e.Value = HisCardRecords[e.RowIndex].CardSn;
                        break;
                    case "HCTimeColumn":
                        e.Value = Common.GetDateTimeString(HisCardRecords[e.RowIndex].CardTime);
                        break;
                    case "HCWorkerColumn":
                        e.Value = HisCardRecords[e.RowIndex].Card != null ? String.Format("{0} - {1}", HisCardRecords[e.RowIndex].Card.WorkerId, HisCardRecords[e.RowIndex].Card.WorkerName) : String.Empty;
                        break;
                    case "HCWorkerTypeColumn":
                        e.Value = HisCardRecords[e.RowIndex].Card != null ? ComUtility.GetWorkerTypeText(HisCardRecords[e.RowIndex].Card.WorkerType) : String.Empty;
                        break;
                    case "HCDeptColumn":
                        e.Value = HisCardRecords[e.RowIndex].Card != null ? String.Format("{0} - {1}", HisCardRecords[e.RowIndex].Card.DepId, HisCardRecords[e.RowIndex].Card.DepName) : String.Empty;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.HisCardGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// History Card Records Context Menu Opening Event.
        /// </summary>
        private void HisCardContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            try {
                HisCardMenuItem2.Enabled = HisCardGridView.Rows.Count > 0;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.HisCardContextMenuStrip.Opening", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// History Card Menu Item1 Click Event.
        /// </summary>
        private void HisCardMenuItem1_Click(object sender, EventArgs e) {
            new HisCardRecordsForm().ShowDialog(this);
        }

        /// <summary>
        /// History Card Menu Item2 Click Event.
        /// </summary>
        private void HisCardMenuItem2_Click(object sender, EventArgs e) {
            try {
                var data = new DataTable();
                data.Columns.Add("序号", typeof(String));
                data.Columns.Add("所属地区", typeof(String));
                data.Columns.Add("所属县市", typeof(String));
                data.Columns.Add("所属局站", typeof(String));
                data.Columns.Add("设备编号", typeof(String));
                data.Columns.Add("设备名称", typeof(String));
                data.Columns.Add("刷卡描述", typeof(String));
                data.Columns.Add("刷卡卡号", typeof(String));
                data.Columns.Add("刷卡时间", typeof(String));
                data.Columns.Add("刷卡人员", typeof(String));
                data.Columns.Add("人员类型", typeof(String));
                data.Columns.Add("所属部门", typeof(String));

                for (var i = 0; i < HisCardRecords.Count; i++) {
                    var dr = data.NewRow();
                    dr["序号"] = i + 1;
                    dr["所属地区"] = HisCardRecords[i].Device.Area2Name;
                    dr["所属县市"] = HisCardRecords[i].Device.Area3Name;
                    dr["所属局站"] = HisCardRecords[i].Device.StaName;
                    dr["设备编号"] = HisCardRecords[i].Device.DevID.ToString();
                    dr["设备名称"] = HisCardRecords[i].Device.DevName;
                    dr["刷卡描述"] = HisCardRecords[i].Remark;
                    dr["刷卡卡号"] = HisCardRecords[i].CardSn;
                    dr["刷卡时间"] = Common.GetDateTimeString(HisCardRecords[i].CardTime);
                    dr["刷卡人员"] = HisCardRecords[i].Card != null ? String.Format("{0} - {1}", HisCardRecords[i].Card.WorkerId, HisCardRecords[i].Card.WorkerName) : String.Empty;
                    dr["人员类型"] = HisCardRecords[i].Card != null ? ComUtility.GetWorkerTypeText(HisCardRecords[i].Card.WorkerType) : String.Empty;
                    dr["所属部门"] = HisCardRecords[i].Card != null ? String.Format("{0} - {1}", HisCardRecords[i].Card.DepId, HisCardRecords[i].Card.DepName) : String.Empty;
                    data.Rows.Add(dr);
                }

                Common.ExportDataToExcel(null, "最近刷卡记录", "智能门禁管理系统 最近刷卡记录报表", String.Format("操作员:{0}{1}  日期:{2}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now)), data);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.HisCardMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Device To TreeView.
        /// </summary>
        private void BindDeviceToTreeView(TreeView TempTreeView) {
            BindDeviceRecursion(TempTreeView.Nodes, 0);
        }

        /// <summary>
        /// Bind Device With Recursion.
        /// </summary>
        private void BindDeviceRecursion(TreeNodeCollection collection, Int32 parentId) {
            var nodes = Common.CurUser.Role.Nodes.FindAll(n => n.LastNodeID == parentId);
            foreach (var node in nodes) {
                var tn = collection.Add(node.NodeID.ToString(), Common.GetTreeNodeName(node));
                tn.Tag = node;
                BindDeviceRecursion(tn.Nodes, node.NodeID);
            }
        }

        /// <summary>
        /// Set Device TreeView Icon
        /// </summary>
        private void SetTreeViewIcon() {
            for (var i = 0; i < Common.CurUser.Role.Nodes.Count; i++) {
                Common.CurUser.Role.Nodes[i].Status = EnmAlarmLevel.NoAlarm;
            }

            var tempAlarms = new List<AlarmInfo>();
            lock (CurAlarms) { tempAlarms.AddRange(CurAlarms); }
            for (var i = 0; i < Common.CurUser.Role.Nodes.Count; i++) {
                var node = Common.CurUser.Role.Nodes[i];
                if (node.NodeType != EnmNodeType.Dev) { continue; }

                var alarms = tempAlarms.FindAll(ca => Common.GetDevID(ca.NodeID) == node.NodeID);
                if (alarms != null && alarms.Count > 0) {
                    node.Status = alarms.Min(ta => ta.AlarmLevel);
                    TreeViewIconRecursion(node);
                }
            }

            foreach (TreeNode n in DeviceTreeView.Nodes) {
                SetTreeViewIconRecursion(n);
            }
        }

        /// <summary>
        /// Device TreeView Icon Recursion.
        /// </summary>
        /// <param name="node">node</param>
        private void TreeViewIconRecursion(NodeLevelInfo node) {
            var pNode = Common.CurUser.Role.Nodes.Find(n => { return n.NodeID == node.LastNodeID; });
            if (pNode != null && (pNode.Status == EnmAlarmLevel.NoAlarm || pNode.Status > node.Status)) {
                pNode.Status = node.Status;
                TreeViewIconRecursion(pNode);
            }
        }

        /// <summary>
        /// Set Device TreeView Icon Recursion.
        /// </summary>
        /// <param name="tn">tree node</param>
        private void SetTreeViewIconRecursion(TreeNode tn) {
            var data = (NodeLevelInfo)tn.Tag;
            if (data != null) { tn.ImageKey = tn.SelectedImageKey = Common.GetTreeViewIcon(data.Status); }
            foreach (TreeNode n in tn.Nodes) {
                SetTreeViewIconRecursion(n);
            }
        }

        /// <summary>
        /// Bind Devices To GridView.
        /// </summary>
        private void BindDevicesToGridView() {
            GMDevices.Clear();
            KMDevices.Clear();
            LJDevices.Clear();
            QZDevices.Clear();
            YCDevices.Clear();
            if (!DevTabControl.Visible) { return; }

            DevGridView1.RowCount = CurDevices.Count;
            DevGridView1.Invalidate(DevGridView1.DisplayRectangle);

            for (var i = 0; i < CurDevices.Count; i++) {
                if (CurDevices[i].StatusNode != null && CurDevices[i].StatusNode.Value == 0F) {
                    GMDevices.Add(CurDevices[i]);
                }
            }
            DevGridView2.RowCount = GMDevices.Count;
            DevGridView2.Invalidate(DevGridView2.DisplayRectangle);

            lock (CardRecords) {
                for (var i = 0; i < CurDevices.Count; i++) {
                    if (CurDevices[i].StatusNode != null && CurDevices[i].StatusNode.Value == 1F) {
                        if (CardRecords.ContainsKey(CurDevices[i].DevID)) {
                            CurDevices[i].CardRecord = CardRecords[CurDevices[i].DevID];
                        }
                        KMDevices.Add(CurDevices[i]);
                    }
                }
            }
            DevGridView3.RowCount = KMDevices.Count;
            DevGridView3.Invalidate(DevGridView3.DisplayRectangle);

            for (var i = 0; i < CurDevices.Count; i++) {
                if (CurDevices[i].StatusNode != null && CurDevices[i].StatusNode.Status == EnmState.Invalid) {
                    LJDevices.Add(CurDevices[i]);
                }
            }
            DevGridView4.RowCount = LJDevices.Count;
            DevGridView4.Invalidate(DevGridView4.DisplayRectangle);

            for (var i = 0; i < KMDevices.Count; i++) {
                if (KMDevices[i].CardRecord != null) {
                    if (KMDevices[i].CardRecord.Remark.Contains("手动开门记录")
                        || KMDevices[i].CardRecord.Remark.Contains("非正常开门")
                        || KMDevices[i].CardRecord.Remark.Contains("非法开门")) {
                        QZDevices.Add(KMDevices[i]);
                    }
                }
            }
            DevGridView5.RowCount = QZDevices.Count;
            DevGridView5.Invalidate(DevGridView5.DisplayRectangle);

            for (var i = 0; i < KMDevices.Count; i++) {
                if (KMDevices[i].CardRecord != null) {
                    if (KMDevices[i].CardRecord.Remark.Contains("远程(由SU)开门记录")
                        || KMDevices[i].CardRecord.Remark.Contains("按钮开门")) {
                        YCDevices.Add(KMDevices[i]);
                    }
                }
            }
            DevGridView6.RowCount = YCDevices.Count;
            DevGridView6.Invalidate(DevGridView6.DisplayRectangle);
        }

        /// <summary>
        /// Bind Nodes To GridView.
        /// </summary>
        private void BindNodesToGridView() {
            DINodes.Clear();
            DONodes.Clear();
            AINodes.Clear();
            AONodes.Clear();
            if (!NodeTabControl.Visible) { return; }

            var GridNodes = new List<NodeInfo>();
            lock (CurNodes) { GridNodes.AddRange(CurNodes); }

            NodeGridView.RowCount = GridNodes.Count;
            NodeGridView.Invalidate(NodeGridView.DisplayRectangle);

            DINodes.AddRange(GridNodes.FindAll(n => n.NodeType == EnmNodeType.Dic));
            DIGridView.RowCount = DINodes.Count;
            DIGridView.Invalidate(DIGridView.DisplayRectangle);

            DONodes.AddRange(GridNodes.FindAll(n => n.NodeType == EnmNodeType.Doc));
            DOGridView.RowCount = DONodes.Count;
            DOGridView.Invalidate(DOGridView.DisplayRectangle);

            AINodes.AddRange(GridNodes.FindAll(n => n.NodeType == EnmNodeType.Aic));
            AIGridView.RowCount = AINodes.Count;
            AIGridView.Invalidate(AIGridView.DisplayRectangle);

            AONodes.AddRange(GridNodes.FindAll(n => n.NodeType == EnmNodeType.Aoc));
            AOGridView.RowCount = AONodes.Count;
            AOGridView.Invalidate(AOGridView.DisplayRectangle);
        }

        /// <summary>
        /// Bind Area2 To Combobox.
        /// </summary>
        private void BindArea2ToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var dict = ComboEntity.GetArea2(ComUtility.DefaultInt32, Common.CurUser.Role.RoleID);
            if (dict != null && dict.Count > 0) {
                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            Area2NameCB.ValueMember = "ID";
            Area2NameCB.DisplayMember = "Value";
            Area2NameCB.DataSource = data;
        }

        /// <summary>
        /// Bind Area3 To Combobox.
        /// </summary>
        private void BindArea3ToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var area2Id = Area2NameCB.SelectedIndex > 0 ? (Int32)Area2NameCB.SelectedValue : ComUtility.DefaultInt32;
            var dict = ComboEntity.GetArea3(area2Id, Common.CurUser.Role.RoleID);
            if (dict != null && dict.Count > 0) {
                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            Area3NameCB.ValueMember = "ID";
            Area3NameCB.DisplayMember = "Value";
            Area3NameCB.DataSource = data;
        }

        /// <summary>
        /// Bind Station To Combobox.
        /// </summary>
        private void BindStaToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var area3Id = Area3NameCB.SelectedIndex > 0 ? (Int32)Area3NameCB.SelectedValue : ComUtility.DefaultInt32;
            var dict = ComboEntity.GetStations(area3Id, Common.CurUser.Role.RoleID);
            if (dict != null && dict.Count > 0) {
                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            StaNameCB.ValueMember = "ID";
            StaNameCB.DisplayMember = "Value";
            StaNameCB.DataSource = data;
        }

        /// <summary>
        /// Bind Device To Combobox.
        /// </summary>
        private void BindDevToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            var area3Id = Area3NameCB.SelectedIndex > 0 ? (Int32)Area3NameCB.SelectedValue : ComUtility.DefaultInt32;
            var staId = StaNameCB.SelectedIndex > 0 ? (Int32)StaNameCB.SelectedValue : ComUtility.DefaultInt32;
            var dict = ComboEntity.GetDevices(area3Id, staId, Common.CurUser.Role.RoleID);
            if (dict != null && dict.Count > 0) {
                if (StaNameCB.SelectedIndex == 0) {
                    dict = dict.GroupBy(item => item.Value).ToDictionary(x => x.Min(y => y.Key), x => x.Key);
                }

                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            DevNameCB.ValueMember = "ID";
            DevNameCB.DisplayMember = "Value";
            DevNameCB.DataSource = data;
        }

        /// <summary>
        /// Bind Node To Combobox.
        /// </summary>
        private void BindNodeToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "--"));

            if (StaNameCB.SelectedIndex > 0 && DevNameCB.SelectedIndex > 0) {
                var devId = (Int32)DevNameCB.SelectedValue;
                var dict = ComboEntity.GetNodes(devId, true, false, true, false);
                if (dict != null && dict.Count > 0) {
                    foreach (var d in dict) {
                        data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                    }
                }
            }

            NodeNameCB.ValueMember = "ID";
            NodeNameCB.DisplayMember = "Value";
            NodeNameCB.DataSource = data;
        }

        /// <summary>
        /// Bind Alarm Level To Combobox.
        /// </summary>
        private void BindAlarmLevelToCombobox() {
            var data = new List<IDValuePair<Int32, String>>();
            data.Add(new IDValuePair<Int32, String>(Int32.MinValue, "所有告警"));

            var dict = ComboEntity.GetAlarmLevels();
            if (dict != null && dict.Count > 0) {
                foreach (var d in dict) {
                    data.Add(new IDValuePair<Int32, String>(d.Key, d.Value));
                }
            }

            AlarmLevelCB.ValueMember = "ID";
            AlarmLevelCB.DisplayMember = "Value";
            AlarmLevelCB.DataSource = data;
        }

        /// <summary>
        /// Bind Alarms To GridView.
        /// </summary>
        private void BindAlarmsToGridView() {
            var TempAlarms = new List<AlarmInfo>();
            lock (GridAlarms) { GridAlarms.Clear(); }
            lock (CurAlarms) { TempAlarms.AddRange(CurAlarms); }

            var enmAlarmLevel = EnmAlarmLevel.NoAlarm;
            if (AlarmLevelCB.SelectedIndex > 0) {
                var alarmLevel = (Int32)AlarmLevelCB.SelectedValue;
                enmAlarmLevel = Enum.IsDefined(typeof(EnmAlarmLevel), alarmLevel) ? (EnmAlarmLevel)alarmLevel : EnmAlarmLevel.NoAlarm;
            }

            var alarms = from alarm in TempAlarms
                         where ((Area2NameCB.SelectedIndex < 0 && alarm.Area2Name.ToLower().Contains(Area2NameCB.Text.Trim().ToLower())) || Area2NameCB.SelectedIndex == 0 || (Area2NameCB.SelectedIndex > 0 && alarm.Area2Name.Equals(Area2NameCB.Text)))
                         && ((Area3NameCB.SelectedIndex < 0 && alarm.Area3Name.ToLower().Contains(Area3NameCB.Text.Trim().ToLower())) || Area3NameCB.SelectedIndex == 0 || (Area3NameCB.SelectedIndex > 0 && alarm.Area3Name.Equals(Area3NameCB.Text)))
                         && ((StaNameCB.SelectedIndex < 0 && alarm.StaName.ToLower().Contains(StaNameCB.Text.Trim().ToLower())) || StaNameCB.SelectedIndex == 0 || (StaNameCB.SelectedIndex > 0 && alarm.StaName.Equals(StaNameCB.Text)))
                         && ((DevNameCB.SelectedIndex < 0 && alarm.DevName.ToLower().Contains(DevNameCB.Text.Trim().ToLower())) || DevNameCB.SelectedIndex == 0 || (DevNameCB.SelectedIndex > 0 && alarm.DevName.Equals(DevNameCB.Text)))
                         && ((NodeNameCB.SelectedIndex < 0 && alarm.NodeName.ToLower().Contains(NodeNameCB.Text.Trim().ToLower())) || NodeNameCB.SelectedIndex == 0 || (NodeNameCB.SelectedIndex > 0 && alarm.NodeName.Equals(NodeNameCB.Text)))
                         && (AlarmLevelCB.SelectedIndex <= 0 || alarm.AlarmLevel == enmAlarmLevel)
                         orderby alarm.StartTime descending
                         select alarm;

            lock (GridAlarms) {
                GridAlarms.AddRange(alarms);
                AlarmGridView.RowCount = GridAlarms.Count;
                AlarmGridView.Invalidate(AlarmGridView.DisplayRectangle);
            }
        }

        /// <summary>
        /// Bind History Card Records To GridView.
        /// </summary>List<IDValuePair<CardRecordInfo, DeviceInfo>>
        private void BindHisCardRecordsToGridView() {
            lock (HisCardRecords) { HisCardRecords.Clear(); }
            var tpRecords1 = CardEntity.GetHisCardRecords(DateTime.Now.AddDays(-1), DateTime.Now);
            var tpRecords2 = new List<CardRecordInfo>();
            lock(Common.CurUser.Role.Cards){
                tpRecords2.AddRange(
                from tr in tpRecords1
                join dev in Common.CurUser.Role.Devices on tr.DevID equals dev.Key
                join cd in Common.CurUser.Role.Cards on tr.CardSn equals cd.CardSn into tp
                from td in tp.DefaultIfEmpty()
                orderby tr.CardTime descending
                select new CardRecordInfo {
                    Card = td,
                    Device = dev.Value,
                    DevID = tr.DevID,
                    CardSn = tr.CardSn,
                    CardTime = tr.CardTime,
                    Status = tr.Status,
                    Remark = tr.Remark,
                    Direction = tr.Direction,
                    GrantPunch = tr.GrantPunch
                });
            }

            lock (HisCardRecords) {
                HisCardRecords.AddRange(tpRecords2);
                HisCardGridView.RowCount = HisCardRecords.Count;
                HisCardGridView.Invalidate(HisCardGridView.DisplayRectangle);
            }
        }

        /// <summary>
        /// Get Last Card Records Per Device.
        /// </summary>
        private void GetLastCardRecords() {
            var tpRecords1 = CardEntity.GetLastCardRecords(DateTime.Now.AddDays(-5), DateTime.Now);
            var tpRecords2 = new List<CardRecordInfo>();
            lock (Common.CurUser.Role.Cards) {
                tpRecords2.AddRange(
                from tr in tpRecords1
                join dev in Common.CurUser.Role.Devices on tr.DevID equals dev.Key
                join cd in Common.CurUser.Role.Cards on tr.CardSn equals cd.CardSn into tp
                from td in tp.DefaultIfEmpty()
                select new CardRecordInfo {
                    Card = td,
                    Device = dev.Value,
                    DevID = tr.DevID,
                    CardSn = tr.CardSn,
                    CardTime = tr.CardTime,
                    Status = tr.Status,
                    Remark = tr.Remark,
                    Direction = tr.Direction,
                    GrantPunch = tr.GrantPunch
                });
            }

            lock (CardRecords) {
                CardRecords.Clear();
                for (var i = 0; i < tpRecords2.Count; i++) {
                    CardRecords[tpRecords2[i].DevID] = tpRecords2[i];
                }
            }
        }

        /// <summary>
        /// Set Double Buffered.
        /// </summary>
        /// <param name="view">DataGridView</param>
        private void SetDoubleBuffered(DataGridView view) {
            var type = view.GetType();
            var pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(view, true, null);
        }

        #region 数据通信
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private EventWaitHandle allDone;
        private EnmRunState runState = EnmRunState.Stop;
        private Thread workerThread;
        private List<Thread> workerThreads;
        private ClientInfo workerClient;
        private Dictionary<Int32, Int32> totalSeries;
        private DateTime ServerDateTime;
        private DateTime LastSyncTime;
        private Int32 SyncTimeInterval;
        private Queue<Byte[]> settingQueue;
        private Queue<Byte[]> alarmQueue;
        private Queue<Byte[]> nodeQueue;
        private Queue<Byte[]> cardQueue;
        private Queue<Byte[]> timeQueue;
        private Queue<OrderInfo> orderQueue;
        private Queue<LogInfo> logQueue;

        /// <summary>
        /// Start Service
        /// </summary>
        private void OnStart() {
            try {
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "启动数据通信模块...", null);

                //初始化全局变量
                allDone = new EventWaitHandle(false, EventResetMode.ManualReset);
                allDone.Reset();
                runState = EnmRunState.Start;
                workerThreads = new List<Thread>();
                workerClient = new ClientInfo(Common.CurInterfaceParamter);
                totalSeries = new Dictionary<Int32, Int32>();
                ServerDateTime = DateTime.Now;
                LastSyncTime = new DateTime(2013, 1, 1);
                SyncTimeInterval = 300;
                settingQueue = new Queue<Byte[]>();
                alarmQueue = new Queue<Byte[]>();
                nodeQueue = new Queue<Byte[]>();
                cardQueue = new Queue<Byte[]>();
                timeQueue = new Queue<Byte[]>();
                orderQueue = new Queue<OrderInfo>();
                logQueue = new Queue<LogInfo>();

                //创建线程初始化数据
                workerThreads = new List<Thread>();
                workerThread = new Thread(new ThreadStart(DoInitData));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "初始化数据线程创建成功", null);

                //创建线程监听链路
                workerThread = new Thread(new ThreadStart(HeartBeat));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "Tcp链路侦测线程创建成功", null);

                //创建线程监听命令表
                workerThread = new Thread(new ThreadStart(DoOrder));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "命令监听线程创建成功", null);

                //创建线程处理状态量数据包
                workerThread = new Thread(new ThreadStart(DoNodeQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "数据包(状态量)处理线程创建成功", null);

                //创建线程处理告警量数据包
                workerThread = new Thread(new ThreadStart(DoAlarmQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "数据包(告警量)处理线程创建成功", null);

                //创建线程处理设置量数据包
                workerThread = new Thread(new ThreadStart(DoSettingQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "数据包(参数设置量)处理线程创建成功", null);

                //创建线程处理刷卡数据包
                workerThread = new Thread(new ThreadStart(DoCardQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "数据包(刷卡消息)处理线程创建成功", null);

                if (workerClient.Config.InterfaceSyncTime) {
                    //创建线程处理时间同步
                    workerThread = new Thread(new ThreadStart(DoSyncTime));
                    workerThread.IsBackground = true;
                    workerThread.Start();
                    workerThreads.Add(workerThread);
                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "时间同步线程创建成功", null);
                }

                //创建线程处理日志数据包
                workerThread = new Thread(new ThreadStart(DoLogQueue));
                workerThread.IsBackground = true;
                workerThread.Start();
                workerThreads.Add(workerThread);
                Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", "日志处理线程创建成功", null);

                //置标志位
                runState = EnmRunState.Init;

                //启动定时线程
                if (MainTimer.Tag.ToString().Equals("1")) {
                    MainTimer.Start();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.OnStart", err.Message, err.StackTrace);
            }
        }

        /// <summary>
        /// Stop Service
        /// </summary>
        private void OnStop() {
            try {
                WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStop", "正在停止数据通信模块...", null);
                runState = EnmRunState.Stop;
                allDone.Set();

                for (var i = 0; i < workerThreads.Count; i++) {
                    if (workerThreads[i] != null && workerThreads[i].IsAlive) {
                        workerThreads[i].Join(10000);
                    }
                }

                if (workerClient.LinkState == EnmLinkState.Connected) {
                    TcpClose();
                }

                if (workerClient.LinkState == EnmLinkState.Authentication) {
                    TcpLogout();
                }

                WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStop", "数据通信模块已停止", null);
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.OnStop", err.Message, err.StackTrace);
            } finally {
                try {
                    lock (logQueue) {
                        while (logQueue.Count > 0) {
                            var log = logQueue.Dequeue();
                            Common.WriteLog(log.EventTime, log.EventType, log.Operator, log.Source, log.Message, log.StackTrace);
                        }
                    }
                } catch { }
            }
        }

        /// <summary>
        /// Do Init Data
        /// </summary>
        private void DoInitData() {
            while (runState < EnmRunState.Run) {
                try {
                    if (runState == EnmRunState.Init) {
                        Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.DoInitData", "数据初始化...", null);
                        var totalAlarms = new Alarm().GetAlarms();
                        for (var i = 0; i < totalAlarms.Count; i++) {
                            if (Common.CurUser.Role.Devices.ContainsKey(Common.GetDevID(totalAlarms[i].NodeID))) {
                                CurAlarms.Add(totalAlarms[i]);
                            }
                        }

                        runState = EnmRunState.Run;
                        Common.WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.DoInitData", "数据初始化完成", null);
                        allDone.Set();
                    }
                } catch (Exception err) {
                    Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoInitData", err.Message, err.StackTrace);
                    break;
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Node Queue
        /// </summary>
        private void DoNodeQueue() {
            allDone.WaitOne();
            var Bytes = new List<byte[]>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (nodeQueue) {
                            while (nodeQueue.Count > 0) {
                                Bytes.Add(nodeQueue.Dequeue());
                            }
                        }

                        foreach (var bytes in Bytes) {
                            try {
                                if (bytes.Length > 33) {
                                    var result = BitConverter.ToInt32(bytes, 24);
                                    var enmResult = Enum.IsDefined(typeof(EnmResult), result) ? (EnmResult)result : EnmResult.Failure;
                                    if (enmResult == EnmResult.Success) {
                                        var cnt = BitConverter.ToInt32(bytes, 28);
                                        var curIndex = 32;
                                        for (var i = 1; i <= cnt; i++) {
                                            try {
                                                var nodeType = BitConverter.ToInt32(bytes, curIndex);
                                                var enmNodeType = ComUtility.DBNullNodeTypeHandler(nodeType);
                                                var nodeId = BitConverter.ToInt32(bytes, curIndex + 4);
                                                var alarmTime = ComUtility.DefaultDateTime;
                                                lock (CurAlarms) {
                                                    var targetAlarms = CurAlarms.FindAll(a => {
                                                        return a.NodeID == nodeId;
                                                    });

                                                    if (targetAlarms != null && targetAlarms.Count > 0) {
                                                        alarmTime = targetAlarms.Max(a => a.StartTime);
                                                    }
                                                }

                                                lock (CurNodes) {
                                                    var targetNode = CurNodes.Find(tn => tn.NodeID == nodeId && tn.NodeType == enmNodeType);
                                                    if (targetNode != null) {
                                                        switch (enmNodeType) {
                                                            case EnmNodeType.Dic:
                                                            case EnmNodeType.Doc:
                                                                targetNode.Value = Convert.ToInt16(bytes[curIndex + 8]);
                                                                targetNode.Status = ComUtility.DBNullStateHandler(bytes[curIndex + 9]);
                                                                targetNode.DateTime = alarmTime;
                                                                targetNode.UpdateTime = DateTime.Now;

                                                                curIndex += 10;
                                                                break;
                                                            case EnmNodeType.Aic:
                                                            case EnmNodeType.Aoc:
                                                                targetNode.Value = BitConverter.ToSingle(bytes, curIndex + 8);
                                                                targetNode.Status = ComUtility.DBNullStateHandler(bytes[curIndex + 12]);
                                                                targetNode.DateTime = alarmTime;
                                                                targetNode.UpdateTime = DateTime.Now;

                                                                curIndex += 13;
                                                                break;
                                                            default:
                                                                break;
                                                        }
                                                    }
                                                }
                                            } catch (Exception err) {
                                                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoNodeQueue.01", err.Message, err.StackTrace);
                                            }
                                        }
                                    }
                                }
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoNodeQueue.02", err.Message, err.StackTrace);
                            }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoNodeQueue.03", err.Message, err.StackTrace);
                } finally {
                    Bytes.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Alarm Queue
        /// </summary>
        private void DoAlarmQueue() {
            allDone.WaitOne();
            var trim = Convert.ToChar(0);
            var Bytes = new List<byte[]>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (alarmQueue) {
                            while (alarmQueue.Count > 0) {
                                Bytes.Add(alarmQueue.Dequeue());
                            }
                        }

                        foreach (var bytes in Bytes) {
                            try {
                                var cnt = BitConverter.ToInt32(bytes, 16);
                                if (22 + cnt * 453 != bytes.Length)
                                    continue;

                                var curIndex = 20;
                                var totalCnt = 0;
                                for (var i = 0; i < cnt; i++) {
                                    try {
                                        var revAlarm = new AlarmInfo();
                                        revAlarm.SerialNO = BitConverter.ToInt32(bytes, curIndex);
                                        var nodeType = BitConverter.ToInt32(bytes, curIndex + 4);
                                        revAlarm.NodeType = ComUtility.DBNullNodeTypeHandler(nodeType);
                                        revAlarm.NodeID = BitConverter.ToInt32(bytes, curIndex + 8);
                                        revAlarm.NodeName = ASCIIEncoding.Default.GetString(bytes, curIndex + 12, 40).Trim(trim);
                                        revAlarm.Area1Name = ASCIIEncoding.Default.GetString(bytes, curIndex + 52, 40).Trim(trim);
                                        revAlarm.Area2Name = ASCIIEncoding.Default.GetString(bytes, curIndex + 92, 40).Trim(trim);
                                        revAlarm.Area3Name = ASCIIEncoding.Default.GetString(bytes, curIndex + 132, 40).Trim(trim);
                                        revAlarm.Area4Name = ComUtility.DefaultString;
                                        revAlarm.StaName = ASCIIEncoding.Default.GetString(bytes, curIndex + 172, 40).Trim(trim);
                                        revAlarm.DevName = ASCIIEncoding.Default.GetString(bytes, curIndex + 212, 40).Trim(trim);
                                        revAlarm.DevDesc = ComUtility.DefaultString;
                                        revAlarm.StartTime = Convert.ToDateTime(String.Format("{0}-{1}-{2} {3}:{4}:{5}", BitConverter.ToInt16(bytes, curIndex + 252), bytes[curIndex + 254], bytes[curIndex + 255], bytes[curIndex + 256], bytes[curIndex + 257], bytes[curIndex + 258]));
                                        var alarmLevel = BitConverter.ToInt32(bytes, curIndex + 259);
                                        revAlarm.AlarmLevel = ComUtility.DBNullAlarmLevelHandler(alarmLevel);
                                        var alarmStatus = BitConverter.ToInt32(bytes, curIndex + 263);
                                        revAlarm.AlarmStatus = ComUtility.DBNullAlarmStatusHandler(alarmStatus);
                                        revAlarm.AlarmDesc = ASCIIEncoding.Default.GetString(bytes, curIndex + 267, 40).Trim(trim);
                                        revAlarm.AuxAlarmDesc = ComUtility.DefaultString;
                                        revAlarm.AlarmValue = BitConverter.ToSingle(bytes, curIndex + 307);
                                        revAlarm.ConfirmName = ASCIIEncoding.Default.GetString(bytes, curIndex + 311, 20).Trim(trim);
                                        var confirmMarking = BitConverter.ToInt32(bytes, curIndex + 331);
                                        revAlarm.ConfirmMarking = ComUtility.DBNullConfirmMarkingHandler(confirmMarking);
                                        revAlarm.ConfirmTime = ComUtility.DefaultDateTime;
                                        revAlarm.AlarmID = BitConverter.ToInt32(bytes, curIndex + 335);
                                        var dspClearDelay = BitConverter.ToInt32(bytes, curIndex + 339);
                                        revAlarm.ProjName = ASCIIEncoding.Default.GetString(bytes, curIndex + 343, 20).Trim(trim);
                                        revAlarm.AuxSet = ASCIIEncoding.Default.GetString(bytes, curIndex + 363, 80).Trim(trim);
                                        revAlarm.TaskID = ComUtility.DefaultString;
                                        revAlarm.TurnCount = BitConverter.ToInt32(bytes, curIndex + 443);
                                        revAlarm.TotalCount = totalCnt = BitConverter.ToInt32(bytes, curIndex + 447);
                                        revAlarm.IsSyncAlarm = BitConverter.ToBoolean(bytes, curIndex + 451);
                                        revAlarm.IsSyncAlarmFirst = BitConverter.ToBoolean(bytes, curIndex + 452);
                                        revAlarm.UpdateTime = DateTime.Now;
                                        if (revAlarm.NodeType == EnmNodeType.Aic || revAlarm.NodeType == EnmNodeType.Aoc) {
                                            revAlarm.AlarmDesc = String.Format("{0}(触发值:{1})", revAlarm.AlarmDesc, revAlarm.AlarmValue);
                                        }

                                        lock (CurAlarms) {
                                            if (revAlarm.IsSyncAlarmFirst) {
                                                WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.DoAlarmQueue", "同步告警信息成功", null);
                                                CurAlarms.Clear();
                                                totalSeries.Clear();
                                            }

                                            switch (revAlarm.AlarmStatus) {
                                                case EnmAlarmStatus.Start:
                                                    totalSeries[revAlarm.SerialNO] = revAlarm.NodeID;
                                                    if (Common.CurUser.Role.Devices.ContainsKey(Common.GetDevID(revAlarm.NodeID))) {
                                                        CurAlarms.Add(revAlarm);
                                                    }
                                                    break;
                                                case EnmAlarmStatus.Confirm:
                                                    var targetAlarm = CurAlarms.Find(a => {
                                                        return a.SerialNO == revAlarm.SerialNO;
                                                    });

                                                    if (targetAlarm != null) {
                                                        targetAlarm.ConfirmName = revAlarm.ConfirmName;
                                                        targetAlarm.ConfirmMarking = revAlarm.ConfirmMarking;
                                                        targetAlarm.ConfirmTime = revAlarm.StartTime;
                                                        targetAlarm.UpdateTime = DateTime.Now;
                                                    }
                                                    break;
                                                case EnmAlarmStatus.Ended:
                                                    totalSeries.Remove(revAlarm.SerialNO);
                                                    CurAlarms.RemoveAll(a => a.SerialNO == revAlarm.SerialNO);
                                                    break;
                                                case EnmAlarmStatus.Invalid:
                                                default:
                                                    break;
                                            }
                                        }
                                    } catch (Exception err) {
                                        WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoAlarmQueue.01", err.Message, err.StackTrace);
                                    } finally {
                                        curIndex += 453;
                                    }
                                }

                                if (workerClient != null && workerClient.LinkState == EnmLinkState.Authentication) {
                                    if (totalSeries.Count != totalCnt && DateTime.Now >= LastSyncTime.AddMinutes(5)) {
                                        WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.DoAlarmQueue", "请求同步告警信息", null);
                                        var sedPack = ComUtility.GetSyncAlarmPack(workerClient.CurPackNo);
                                        if (sedPack != null) {
                                            workerClient.Send(sedPack);
                                            LastSyncTime = DateTime.Now;
                                        }
                                    }
                                }
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoAlarmQueue.02", err.Message, err.StackTrace);
                            }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoAlarmQueue.02", err.Message, err.StackTrace);
                } finally {
                    Bytes.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Setting Queue
        /// </summary>
        private void DoSettingQueue() {
            allDone.WaitOne();
            var Bytes = new List<byte[]>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (settingQueue) {
                            while (settingQueue.Count > 0) {
                                Bytes.Add(settingQueue.Dequeue());
                            }
                        }

                        foreach (var bytes in Bytes) {
                            try {
                                if (bytes.Length == 30) {
                                    var nodeId = BitConverter.ToInt32(bytes, 20);
                                    var result = BitConverter.ToInt32(bytes, 24);
                                    var enmResult = Enum.IsDefined(typeof(EnmResult), result) ? (EnmResult)result : EnmResult.Failure;
                                    WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.DoSettingQueue", String.Format("测点设置{0}[ID: {1}]", enmResult == EnmResult.Success ? "成功" : "失败", nodeId), null);
                                }
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoSettingQueue.01", err.Message, err.StackTrace);
                            }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoSettingQueue.02", err.Message, err.StackTrace);
                } finally {
                    Bytes.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Card Queue
        /// </summary>
        private void DoCardQueue() {
            allDone.WaitOne();
            var trim = Convert.ToChar(0);
            var Bytes = new List<byte[]>();
            var Records = new List<CardRecordInfo>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (cardQueue) {
                            while (cardQueue.Count > 0) {
                                Bytes.Add(cardQueue.Dequeue());
                            }
                        }

                        foreach (var bytes in Bytes) {
                            try {
                                var cnt = BitConverter.ToInt32(bytes, 16);
                                if (22 + cnt * 293 != bytes.Length) { continue; }

                                var curIndex = 20;
                                for (var i = 0; i < cnt; i++) {
                                    var rec = new CardRecordInfo();
                                    rec.DevID = BitConverter.ToInt32(bytes, curIndex);
                                    //rec.Area1Name = ASCIIEncoding.Default.GetString(bytes, curIndex + 4, 40).Trim(trim);
                                    //rec.Area2Name = ASCIIEncoding.Default.GetString(bytes, curIndex + 44, 40).Trim(trim);
                                    //rec.Area3Name = ASCIIEncoding.Default.GetString(bytes, curIndex + 84, 40).Trim(trim);
                                    //rec.StaName = ASCIIEncoding.Default.GetString(bytes, curIndex + 124, 40).Trim(trim);
                                    //rec.DevName = ASCIIEncoding.Default.GetString(bytes, curIndex + 164, 40).Trim(trim);
                                    //rec.EmpName = ASCIIEncoding.Default.GetString(bytes, curIndex + 204, 40).Trim(trim);
                                    //rec.EmpNO = ASCIIEncoding.Default.GetString(bytes, curIndex + 244, 20).Trim(trim);
                                    rec.CardTime = Convert.ToDateTime(String.Format("{0}-{1}-{2} {3}:{4}:{5}", BitConverter.ToInt16(bytes, curIndex + 264), bytes[curIndex + 266], bytes[curIndex + 267], bytes[curIndex + 268], bytes[curIndex + 269], bytes[curIndex + 270]));
                                    rec.CardSn = ASCIIEncoding.Default.GetString(bytes, curIndex + 271, 10).Trim(trim);
                                    rec.Status = BitConverter.ToInt32(bytes, curIndex + 281).ToString();
                                    rec.Remark = BitConverter.ToInt32(bytes, curIndex + 285).ToString();
                                    rec.Direction = ComUtility.DBNullDirectionHandler(BitConverter.ToInt32(bytes, curIndex + 289));
                                    Records.Add(rec);
                                }
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoCardQueue.01", err.Message, err.StackTrace);
                            }
                        }

                        if (Records.Count > 0) { GetLastCardRecords(); }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoCardQueue.02", err.Message, err.StackTrace);
                } finally {
                    Bytes.Clear();
                    Records.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Sync Time
        /// </summary>
        private void DoSyncTime() {
            allDone.WaitOne();
            var Cnt = 0;
            var Bytes = new List<byte[]>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (timeQueue) {
                            while (timeQueue.Count > 0) {
                                Bytes.Add(timeQueue.Dequeue());
                            }
                        }

                        foreach (var bytes in Bytes) {
                            try {
                                if (bytes.Length != 25) { continue; }
                                ServerDateTime = Convert.ToDateTime(String.Format("{0}-{1}-{2} {3}:{4}:{5}", BitConverter.ToInt16(bytes, 16), bytes[18], bytes[19], bytes[20], bytes[21], bytes[22]));
                                ServerDateTime = ServerDateTime.ToUniversalTime();
                                var sysTime = new SYSTEMTIME();
                                GetSystemTime(ref sysTime);

                                sysTime.wYear = (UInt16)ServerDateTime.Year;
                                sysTime.wMonth = (UInt16)ServerDateTime.Month;
                                sysTime.wDay = (UInt16)ServerDateTime.Day;
                                sysTime.wHour = (UInt16)ServerDateTime.Hour;
                                sysTime.wMinute = (UInt16)ServerDateTime.Minute;
                                sysTime.wSecond = (UInt16)ServerDateTime.Second;
                                SetSystemTime(ref sysTime);
                            } catch (Exception err) {
                                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoSyncTime.01", err.Message, err.StackTrace);
                            }
                        }

                        if (Cnt == 0 || Cnt >= SyncTimeInterval) {
                            Cnt = 0;
                            if (workerClient == null || workerClient.LinkState != EnmLinkState.Authentication)
                                continue;

                            var sedPack = ComUtility.GetServerDateTimePackage(workerClient.CurPackNo);
                            if (sedPack != null) { workerClient.Send(sedPack); }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoSyncTime.02", err.Message, err.StackTrace);
                } finally {
                    Bytes.Clear();
                }

                Cnt++;
                Thread.Sleep(1000);
            }
        }

        #region Set Sytem DateTime
        [DllImport("Kernel32.dll")]
        private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("Kernel32.dll")]
        private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

        private struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }
        #endregion

        /// <summary>
        /// Do Log Queue
        /// </summary>
        private void DoLogQueue() {
            allDone.WaitOne();
            var logs = new List<LogInfo>();

            while (runState < EnmRunState.Stop) {
                try {
                    lock (logQueue) {
                        while (logQueue.Count > 0) {
                            logs.Add(logQueue.Dequeue());
                        }
                    }

                    foreach (var log in logs) {
                        Common.WriteLog(log.EventTime, log.EventType, log.Operator, log.Source, log.Message, log.StackTrace);
                    }
                } catch {
                } finally {
                    logs.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Do Order
        /// </summary>
        private void DoOrder() {
            allDone.WaitOne();
            var orders = new List<OrderInfo>();
            var rNodes = new List<OrderInfo>();
            var rConfirms = new List<OrderInfo>();
            var rAocs = new List<OrderInfo>();
            var rDocs = new List<OrderInfo>();

            while (runState < EnmRunState.Stop) {
                try {
                    if (runState == EnmRunState.Run) {
                        lock (orderQueue) {
                            while (orderQueue.Count > 0) {
                                orders.Add(orderQueue.Dequeue());
                            }
                        }

                        if (orders.Count > 0) {
                            if (workerClient == null || workerClient.LinkState != EnmLinkState.Authentication)
                                continue;

                            foreach (var order in orders) {
                                switch (order.OrderType) {
                                    case EnmActType.RequestNode:
                                        rNodes.Add(order);
                                        break;
                                    case EnmActType.ConfirmAlarm:
                                        rConfirms.Add(order);
                                        break;
                                    case EnmActType.SetAoc:
                                        rAocs.Add(order);
                                        break;
                                    case EnmActType.SetDoc:
                                        rDocs.Add(order);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (rNodes.Count > 0) {
                                try {
                                    var nodes = new Dictionary<int, int>();
                                    foreach (var node in rNodes) {
                                        if (!nodes.ContainsKey(node.TargetID))
                                            nodes.Add(node.TargetID, (int)node.TargetType);
                                    }

                                    var sedPack = ComUtility.GetNodePack(0, 0, (byte)EnmAcceMode.Ask_Answer, 2, workerClient.CurPackNo, nodes);
                                    if (sedPack != null) {
                                        workerClient.Send(sedPack);
                                    }
                                } catch (Exception err) {
                                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoOrder.01", err.Message, err.StackTrace);
                                } finally {
                                    rNodes.Clear();
                                }
                            }

                            if (rConfirms.Count > 0) {
                                try {
                                    var confirmsGroup = rConfirms.GroupBy(c => new { c.RelValue1, c.RelValue2 });
                                    foreach (var confirmGroup in confirmsGroup) {
                                        var ids = confirmGroup.Select(c => c.TargetID).ToList();
                                        var dispatchNO = Convert.ToInt32(confirmGroup.Key.RelValue1);
                                        var userName = confirmGroup.Key.RelValue2;

                                        var sedPack = ComUtility.GetConfirmAlarmPack(ids, dispatchNO, userName, workerClient.CurPackNo);
                                        if (sedPack != null) {
                                            workerClient.Send(sedPack);
                                        }
                                    }
                                } catch (Exception err) {
                                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoOrder.02", err.Message, err.StackTrace);
                                } finally {
                                    rConfirms.Clear();
                                }
                            }

                            if (rAocs.Count > 0) {
                                try {
                                    foreach (var order in rAocs) {
                                        var setValue = Convert.ToSingle(order.RelValue1);
                                        var lscId = Convert.ToInt32(order.RelValue2);
                                        var userId = Convert.ToInt32(order.RelValue3);
                                        var userName = order.RelValue4;

                                        var sedPack = ComUtility.GetSetAOPack(order.TargetID, setValue, lscId, userId, userName, workerClient.CurPackNo);
                                        if (sedPack != null) {
                                            workerClient.Send(sedPack);
                                        }
                                    }
                                } catch (Exception err) {
                                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoOrder.03", err.Message, err.StackTrace);
                                } finally {
                                    rAocs.Clear();
                                }
                            }

                            if (rDocs.Count > 0) {
                                try {
                                    foreach (var order in rDocs) {
                                        var setValue = Convert.ToByte(order.RelValue1);
                                        var lscId = Convert.ToInt32(order.RelValue2);
                                        var userId = Convert.ToInt32(order.RelValue3);
                                        var userName = order.RelValue4;

                                        var sedPack = ComUtility.GetSetDOPack(order.TargetID, setValue, lscId, userId, userName, workerClient.CurPackNo);
                                        if (sedPack != null) {
                                            workerClient.Send(sedPack);
                                        }
                                    }
                                } catch (Exception err) {
                                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoOrder.04", err.Message, err.StackTrace);
                                } finally {
                                    rDocs.Clear();
                                }
                            }
                        }
                    }
                } catch (Exception err) {
                    WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.DoOrder.05", err.Message, err.StackTrace);
                } finally {
                    orders.Clear();
                }

                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Tcp Login
        /// </summary>
        private void TcpLogin() {
            try {
                if (workerClient.LinkState == EnmLinkState.Connected) {
                    WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.TcpLogin", "Tcp连接已建立，用户验证中...", null);
                    var sedPack = ComUtility.GetLoginPack(workerClient.Config.InterfaceUser, workerClient.Config.InterfacePwd, workerClient.CurPackNo);
                    if (sedPack != null) {
                        workerClient.Send(sedPack, TcpLoginSendAck);
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.TcpLogin", err.Message, err.StackTrace);
                TcpClose();
            }
        }

        /// <summary>
        /// Tcp Login Send Ack
        /// </summary>
        /// <param name="iar">IAsyncResult</param>
        private void TcpLoginSendAck(IAsyncResult iar) {
            try {
                var clientInfo = (ClientInfo)iar.AsyncState;
                if (clientInfo != null && clientInfo.NetStream != null) {
                    clientInfo.NetStream.EndWrite(iar);
                    if (clientInfo.LinkState == EnmLinkState.Connected) {
                        clientInfo.Read(TcpLoginAck);
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.TcpLoginSendAck", err.Message, err.StackTrace);
            }
        }

        /// <summary>
        /// Tcp Login Ack
        /// </summary>
        /// <param name="iar">IAsyncResult</param>
        private void TcpLoginAck(IAsyncResult iar) {
            try {
                var clientInfo = (ClientInfo)iar.AsyncState;
                if (clientInfo != null && clientInfo.NetStream != null) {
                    byte[] revPack = null;
                    var revLen = clientInfo.NetStream.EndRead(iar);
                    if (ComUtility.CheckSinglePackage(clientInfo.ReadBuffer, revLen)) {
                        revPack = new byte[revLen];
                        Buffer.BlockCopy(clientInfo.ReadBuffer, 0, revPack, 0, revLen);
                    } else {
                        for (var i = 0; i < revLen; i++) {
                            clientInfo.BytesBuffer.Add(clientInfo.ReadBuffer[i]);
                        }
                        revPack = clientInfo.GetReceivePack();
                    }

                    if (revPack != null) {
                        var packType = BitConverter.ToInt32(revPack, 12);
                        var enmPackType = Enum.IsDefined(typeof(EnmTcpMsgType), packType) ? (EnmTcpMsgType)packType : EnmTcpMsgType.Pack;
                        if (enmPackType == EnmTcpMsgType.packLoginAck && revPack.Length == 22) {
                            switch (BitConverter.ToInt32(revPack, 16)) {
                                case (int)EnmRightMode.Level1:
                                case (int)EnmRightMode.Level2:
                                case (int)EnmRightMode.Level3:
                                    WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.TcpLoginAck", "用户验证成功，等待接收数据包...", null);
                                    clientInfo.LinkState = EnmLinkState.Authentication;
                                    clientInfo.LoginCnt = 0;
                                    clientInfo.Read(RevPackAck);
                                    break;
                                case (int)EnmRightMode.Invalid:
                                default:
                                    break;
                            }
                        }
                    }
                }

                if (clientInfo.LinkState != EnmLinkState.Authentication) {
                    clientInfo.LinkState = EnmLinkState.Disconnect;
                    WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.TcpLoginAck", "用户验证失败，稍后重试...", null);
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.TcpLoginAck", err.Message, err.StackTrace);
            }
        }

        /// <summary>
        /// Reveice Packages ack
        /// </summary>
        /// <param name="iar">IAsyncResult</param>
        private void RevPackAck(IAsyncResult iar) {
            try {
                var clientInfo = (ClientInfo)iar.AsyncState;
                if (clientInfo != null && clientInfo.NetStream != null) {
                    byte[] revPack = null;
                    var revLen = clientInfo.NetStream.EndRead(iar);
                    if (ComUtility.CheckSinglePackage(clientInfo.ReadBuffer, revLen)) {
                        revPack = new byte[revLen];
                        Buffer.BlockCopy(clientInfo.ReadBuffer, 0, revPack, 0, revLen);
                    } else {
                        for (var i = 0; i < revLen; i++) {
                            clientInfo.BytesBuffer.Add(clientInfo.ReadBuffer[i]);
                        }
                        revPack = clientInfo.GetReceivePack();
                    }

                    if (revPack != null) {
                        var serialsNO = BitConverter.ToInt32(revPack, 8);
                        var packType = BitConverter.ToInt32(revPack, 12);
                        var enmPackType = Enum.IsDefined(typeof(EnmTcpMsgType), packType) ? (EnmTcpMsgType)packType : EnmTcpMsgType.Pack;
                        switch (enmPackType) {
                            case EnmTcpMsgType.packSetAcceModeAck2:
                                if (runState == EnmRunState.Run) {
                                    lock (nodeQueue) {
                                        nodeQueue.Enqueue(revPack);
                                    }
                                    //WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.RevPackAck", "接收到状态量数据包", null);
                                }
                                break;
                            case EnmTcpMsgType.packSendAlarm:
                                if (runState == EnmRunState.Run) {
                                    lock (alarmQueue) {
                                        alarmQueue.Enqueue(revPack);
                                    }
                                    //WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.RevPackAck", "接收到告警量数据包", null);
                                }
                                break;
                            case EnmTcpMsgType.packSetPointAck:
                                if (runState == EnmRunState.Run) {
                                    lock (settingQueue) {
                                        settingQueue.Enqueue(revPack);
                                    }
                                    //WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.RevPackAck", "接收到参数设置量数据包", null);
                                }
                                break;
                            case EnmTcpMsgType.packSendPunch:
                                if (runState == EnmRunState.Run) {
                                    lock (cardQueue) {
                                        cardQueue.Enqueue(revPack);
                                    }
                                }
                                break;
                            case EnmTcpMsgType.packGetServerTimeAck:
                                if (runState == EnmRunState.Run) {
                                    lock (timeQueue) {
                                        timeQueue.Enqueue(revPack);
                                    }
                                }
                                break;
                            case EnmTcpMsgType.packHeartbeat:
                                HeartBeatAck(revPack);
                                break;
                            case EnmTcpMsgType.packHeartbeatAck:
                                clientInfo.HeartBeatCnt = 0;
                                break;
                            case EnmTcpMsgType.packLogoutAck:
                                TcpLogoutAck(revPack);
                                break;
                            default:
                                break;
                        }
                    }

                    if (clientInfo.LinkState == EnmLinkState.Authentication) {
                        clientInfo.Read(RevPackAck);
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.RevPackAck", err.Message, err.StackTrace);
            }
        }

        /// <summary>
        /// HeartBeat
        /// </summary>
        private void HeartBeat() {
            allDone.WaitOne();

            while (runState < EnmRunState.Stop) {
                try {
                    if (workerClient.LinkState == EnmLinkState.Disconnect) {
                        this.Invoke(new MethodInvoker(delegate {
                            ConnectionStatusLbl.Image = global::Delta.MPS.AccessSystem.Properties.Resources.disconnect;
                            ConnectionStatusLbl.Text = "[已断开]";
                        }));

                        if (workerClient.ConnectCnt++ % 5 == 0) {
                            workerClient.Connect();
                        }
                    }

                    if (workerClient.LinkState == EnmLinkState.Connected) {
                        this.Invoke(new MethodInvoker(delegate {
                            ConnectionStatusLbl.Image = global::Delta.MPS.AccessSystem.Properties.Resources.connecting;
                            ConnectionStatusLbl.Text = "[正在连接...]";
                        }));

                        if (workerClient.LoginCnt++ % 5 == 0) {
                            TcpLogin();
                        }
                    }

                    if (workerClient.LinkState == EnmLinkState.Authentication) {
                        this.Invoke(new MethodInvoker(delegate {
                            ConnectionStatusLbl.Image = global::Delta.MPS.AccessSystem.Properties.Resources.connect;
                            ConnectionStatusLbl.Text = "[已连接]";
                        }));

                        workerClient.HeartBeatCnt++;
                        if (workerClient.HeartBeatCnt % workerClient.Config.InterfaceDetect == 0) {
                            var sedPack = ComUtility.GetHeartBeatPack(workerClient.CurPackNo);
                            if (sedPack != null) { workerClient.Send(sedPack); }
                        } else if (workerClient.HeartBeatCnt >= workerClient.Config.InterfaceDetect + workerClient.Config.InterfaceInterrupt) {
                            TcpClose();
                        }
                    }
                } catch { }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// HeartBeatAck
        /// </summary>
        /// <param name="revPack">revPack</param>
        private void HeartBeatAck(byte[] revPack) {
            try {
                if (workerClient.LinkState == EnmLinkState.Authentication) {
                    var sedPack = ComUtility.GetHeartBeatAckPack(revPack);
                    if (sedPack != null) {
                        workerClient.Send(sedPack);
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.HeartBeatAck", err.Message, err.StackTrace);
            }
        }

        /// <summary>
        /// Tcp Logout
        /// </summary>
        private void TcpLogout() {
            try {
                if (workerClient.LinkState == EnmLinkState.Authentication) {
                    WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.TcpLogout", "用户注销中...", null);
                    var sedPack = ComUtility.GetLogOutPack(workerClient.CurPackNo);
                    if (sedPack != null) {
                        workerClient.Send(sedPack);
                        while (true) {
                            if (workerClient.LinkState == EnmLinkState.Connected || workerClient.LogoutCnt++ >= 50) {
                                break;
                            }
                            Thread.Sleep(100);
                        }
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.TcpLogout", err.Message, err.StackTrace);
            } finally {
                TcpClose();
            }
        }

        /// <summary>
        /// Tcp Logout Ack
        /// </summary>
        /// <param name="revPack">revPack</param>
        private void TcpLogoutAck(byte[] revPack) {
            try {
                var packType = BitConverter.ToInt32(revPack, 12);
                var enmPackType = Enum.IsDefined(typeof(EnmTcpMsgType), packType) ? (EnmTcpMsgType)packType : EnmTcpMsgType.Pack;
                if (enmPackType == EnmTcpMsgType.packLogoutAck && revPack.Length == 22) {
                    var result = BitConverter.ToInt32(workerClient.ReadBuffer, 16);
                    var enmResult = Enum.IsDefined(typeof(EnmResult), result) ? (EnmResult)result : EnmResult.Failure;
                    if (enmResult == EnmResult.Success) {
                        workerClient.LinkState = EnmLinkState.Connected;
                        WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.TcpLogoutAck", "用户注销成功", null);
                    } else {
                        WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.TcpLogoutAck", "用户注销失败", null);
                    }
                }
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.TcpLogoutAck", err.Message, err.StackTrace);
            }
        }

        /// <summary>
        /// Tcp Close
        /// </summary>
        private void TcpClose() {
            try {
                WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.TcpClose", "Tcp连接断开中...", null);
                workerClient.ClientDispose();
                workerClient.LinkState = EnmLinkState.Disconnect;
                WriteLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.MainForm.TcpClose", "Tcp连接断开成功", null);
            } catch (Exception err) {
                WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.TcpClose", err.Message, err.StackTrace);
            }
        }

        /// <summary>
        /// Write log information.
        /// </summary>
        /// <param name="msgTime">message datetime</param>
        /// <param name="msgType">message type</param>
        /// <param name="msgOperator">message operator</param>
        /// <param name="msgSource">message source</param>
        /// <param name="message">message</param>
        /// <param name="trace">stack trace</param>
        private void WriteLog(DateTime msgTime, EnmMsgType msgType, String msgOperator, String msgSource, String message, String trace) {
            lock (logQueue) {
                logQueue.Enqueue(new LogInfo() {
                    EventTime = msgTime,
                    EventType = msgType,
                    Operator = msgOperator,
                    Source = msgSource,
                    Message = message,
                    StackTrace = trace
                });
            }
        }
        #endregion

        #region 树节点查询
        /// <summary>
        /// Variables
        /// </summary>
        private Int32 FilterIndex = 0;
        private List<TreeNode> FilterNodes = null;

        /// <summary>
        /// Device Top ToolStrip Size Changed Event.
        /// </summary>
        private void DeviceTopToolStrip_SizeChanged(object sender, EventArgs e) {
            FilterTextBox.TextBox.Width = DeviceTopToolStrip.Width - DeviceFilterToolStripBtn.Width - 25;
        }

        /// <summary>
        /// Filter TextBox Text Changed Event.
        /// </summary>
        private void FilterTextBox_TextChanged(object sender, EventArgs e) {
            FilterNodes = null;
        }

        /// <summary>
        /// Device Filter ToolStrip Button Click Event.
        /// </summary>
        private void DeviceFilterToolStripBtn_Click(object sender, EventArgs e) {
            var filter = FilterTextBox.TextBox.Text;
            if (String.IsNullOrWhiteSpace(filter)) { return; }
            if (FilterNodes == null) {
                FilterNodes = new List<TreeNode>();
                FilterIndex = 0;
                foreach (TreeNode n in DeviceTreeView.Nodes) {
                    FindFilterNodesRecursion(n, filter, FilterNodes);
                }
            }

            if (FilterNodes.Count == 0) {
                MessageBox.Show(String.Format("未找到匹配项：\"{0}\"", filter), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FilterIndex >= FilterNodes.Count) { FilterIndex = 0; }
            DeviceTreeView.SelectedNode = FilterNodes[FilterIndex++];
        }

        /// <summary>
        /// Find Filter Nodes Recursion
        /// </summary>
        /// <param name="node">tree node</param>
        /// <param name="txt">search text</param>
        /// <param name="result">result nodes</param>
        private void FindFilterNodesRecursion(TreeNode node, String txt, List<TreeNode> result) {
            if (node.Text.ToLower().Contains(txt.ToLower())) {
                result.Add(node);
            }

            foreach (TreeNode n in node.Nodes) {
                FindFilterNodesRecursion(n, txt, result);
            }
        }
        #endregion

        #region 设置菜单项
        private void SetMenuItem() {
            HelpMenuItem2.Available = Common.IsCheckLicense;
            if (Common.CurUser.Role.RoleID == ComUtility.SuperRoleID) { return; }

            SystemMenuItem1.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(SystemMenuItem1.Tag));
            SystemMenuItem2.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(SystemMenuItem2.Tag));
            MainToolBar1Item1.Available = SystemMenuItem2.Available;
            MainToolBar1DefindItem1.Available = SystemMenuItem2.Available;
            SystemMenuItem3.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(SystemMenuItem3.Tag));
            MainToolBar1Item2.Available = SystemMenuItem3.Available;
            MainToolBar1DefindItem2.Available = SystemMenuItem3.Available;
            //SystemMenuItem4.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(SystemMenuItem4.Tag));
            SystemSeparator1.Available = (SystemMenuItem1.Available || SystemMenuItem2.Available || SystemMenuItem3.Available) && SystemMenuItem4.Available;
            MainToolBar1Separator1.Available = (MainToolBar1Item1.Available || MainToolBar1Item2.Available);
            SystemMenu.Available = (SystemMenuItem1.Available || SystemMenuItem2.Available || SystemMenuItem3.Available || SystemMenuItem4.Available);

            MaintainMenuItem1.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(MaintainMenuItem1.Tag));
            MainToolBar1Item3.Available = MaintainMenuItem1.Available;
            MainToolBar1DefindItem3.Available = MainToolBar1Item3.Available;
            MaintainMenuItem2.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(MaintainMenuItem2.Tag));
            MainToolBar1Item4.Available = MaintainMenuItem2.Available;
            MainToolBar1DefindItem4.Available = MainToolBar1Item4.Available;
            MaintainMenuItem3.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(MaintainMenuItem3.Tag));
            MainToolBar1Item5.Available = MaintainMenuItem3.Available;
            MainToolBar1DefindItem5.Available = MainToolBar1Item5.Available;
            MaintainMenuItem4.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(MaintainMenuItem4.Tag));
            MainToolBar1Item6.Available = MaintainMenuItem4.Available;
            MainToolBar1DefindItem6.Available = MainToolBar1Item6.Available;
            MaintainSeparator1.Available = MaintainMenuItem1.Available || MaintainMenuItem2.Available;
            MaintainSeparator2.Available = MaintainMenuItem3.Available && MaintainMenuItem4.Available;
            MainToolBar1Separator2.Available = (MaintainMenuItem1.Available || MaintainMenuItem2.Available);
            MainToolBar1Separator3.Available = MaintainMenuItem3.Available;
            MainToolBar1Separator4.Available = MaintainMenuItem4.Available;
            MaintainMenu.Available = (MaintainMenuItem1.Available || MaintainMenuItem2.Available || MaintainMenuItem3.Available || MaintainMenuItem4.Available);

            CardMenuItem1.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(CardMenuItem1.Tag));
            MainToolBar1Item7.Available = CardMenuItem1.Available;
            MainToolBar1DefindItem7.Available = MainToolBar1Item7.Available;
            CardMenuItem2.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(CardMenuItem2.Tag));
            MainToolBar1Item8.Available = CardMenuItem2.Available;
            MainToolBar1DefindItem8.Available = MainToolBar1Item8.Available;
            CardMenuItem3.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(CardMenuItem3.Tag));
            MainToolBar1Item9.Available = CardMenuItem3.Available;
            MainToolBar1DefindItem9.Available = MainToolBar1Item9.Available;
            CardMenuItem4.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(CardMenuItem4.Tag));
            MainToolBar1Item10.Available = CardMenuItem4.Available;
            MainToolBar1DefindItem10.Available = MainToolBar1Item10.Available;
            CardMenuItem5.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(CardMenuItem5.Tag));
            MainToolBar1Item11.Available = CardMenuItem5.Available;
            MainToolBar1DefindItem11.Available = MainToolBar1Item11.Available;
            CardMenuItem6.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(CardMenuItem6.Tag));
            MainToolBar1Item12.Available = CardMenuItem6.Available;
            MainToolBar1DefindItem12.Available = MainToolBar1Item12.Available;
            CardMenuItem7.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(CardMenuItem7.Tag));
            MainToolBar1Item13.Available = CardMenuItem7.Available;
            MainToolBar1DefindItem13.Available = MainToolBar1Item13.Available;
            CardSeparator1.Available = (CardMenuItem1.Available || CardMenuItem2.Available || CardMenuItem3.Available);
            CardSeparator2.Available = (CardMenuItem4.Available || CardMenuItem5.Available);
            MainToolBar1Separator5.Available = (CardMenuItem1.Available || CardMenuItem2.Available || CardMenuItem3.Available);
            MainToolBar1Separator6.Available = (CardMenuItem4.Available || CardMenuItem5.Available);
            CardMenu.Available = (CardMenuItem1.Available || CardMenuItem2.Available || CardMenuItem3.Available || CardMenuItem4.Available || CardMenuItem5.Available || CardMenuItem6.Available || CardMenuItem7.Available);

            ReportMenuItem1.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ReportMenuItem1.Tag));
            ReportMenuItem2.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ReportMenuItem2.Tag));
            ReportMenuItem3.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ReportMenuItem3.Tag));
            ReportMenuItem4.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ReportMenuItem4.Tag));
            ReportMenuItem5.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ReportMenuItem5.Tag));
            ReportMenuItem6.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ReportMenuItem6.Tag));
            ReportSeparator1.Available = (ReportMenuItem2.Available || ReportMenuItem3.Available || ReportMenuItem4.Available);
            ReportSeparator2.Available = (ReportMenuItem5.Available || ReportMenuItem6.Available);
            ReportMenu.Available = (ReportMenuItem1.Available || ReportMenuItem2.Available || ReportMenuItem3.Available || ReportMenuItem4.Available || ReportMenuItem5.Available || ReportMenuItem6.Available || ReportMenuItem6.Available);

            ViewMenuItem1.Available = ViewMenuItem1.Checked = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ViewMenuItem1.Tag));
            ViewMenuItem2.Available = ViewMenuItem2.Checked = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ViewMenuItem2.Tag));
            ViewMenuItem3.Available = ViewMenuItem3.Checked = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(ViewMenuItem3.Tag));
            ViewMenu.Available = (ViewMenuItem1.Available || ViewMenuItem2.Available || ViewMenuItem3.Available);

            //HelpMenuItem1.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(HelpMenuItem1.Tag));
            //HelpMenuItem2.Available = Common.IsCheckLicense && Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(HelpMenuItem2.Tag));
            //HelpMenuItem3.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(HelpMenuItem3.Tag));
            //HelpMenuItem4.Available = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(HelpMenuItem4.Tag));
            //HelpSeparator1.Available = (HelpMenuItem1.Available || HelpMenuItem2.Available);
            //HelpSeparator2.Available = HelpMenuItem3.Available;
            //HelpMenu.Available = (HelpMenuItem1.Available || HelpMenuItem2.Available || HelpMenuItem3.Available || HelpMenuItem4.Available);

            DevMenuItem1.Visible = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(DevMenuItem1.Tag));
            DevStripSeparator1.Visible = DevMenuItem1.Visible;
            NodeMenuItem1.Visible = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(NodeMenuItem1.Tag));
            NodeMenuItem2.Visible = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(NodeMenuItem2.Tag));
            NodeStripSeparator1.Visible = (NodeMenuItem1.Visible || NodeMenuItem2.Visible);
            AlarmMenuItem1.Visible = Common.CurUser.Role.Authorizations.Any(a => a.Enabled && a.AuthId.ToString().Equals(AlarmMenuItem1.Tag));
        }

        private void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            try {
                if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked) {
                    e.Cancel = true;
                    ((ToolStripDropDownMenu)sender).Invalidate();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OverFlow_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            try {
                if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked) {
                    e.Cancel = true;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SystemMenuItem1_Click(object sender, EventArgs e) {
            try {
                new ChangePasswordForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.SystemMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SystemMenuItem2_Click(object sender, EventArgs e) {
            try {
                new UserManagerForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.SystemMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SystemMenuItem3_Click(object sender, EventArgs e) {
            try {
                new RoleManagerForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.SystemMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SystemMenuItem4_Click(object sender, EventArgs e) {
            try {
                Close();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.SystemMenuItem4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaintainMenuItem1_Click(object sender, EventArgs e) {
            try {
                new SetLimitTimeForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.MaintainMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaintainMenuItem2_Click(object sender, EventArgs e) {
            try {
                new LogManagerForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.MaintainMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaintainMenuItem3_Click(object sender, EventArgs e) {
            try {
                new GridGroupForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.MaintainMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MaintainMenuItem4_Click(object sender, EventArgs e) {
            try {
                new ClearDataForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.MaintainMenuItem4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardMenuItem1_Click(object sender, EventArgs e) {
            try {
                new DepartmentManagerForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.CardMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardMenuItem2_Click(object sender, EventArgs e) {
            try {
                new OrgEmployeeManagerForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.CardMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardMenuItem3_Click(object sender, EventArgs e) {
            try {
                new OutEmployeeManagerForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.CardMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardMenuItem4_Click(object sender, EventArgs e) {
            try {
                new OrgCardManagerForm().ShowDialog(this);
                lock (Common.CurUser.Role.Cards) {
                    Common.CurUser.Role.Cards.RemoveAll(c => c.WorkerType != EnmWorkerType.WXRY);
                    Common.CurUser.Role.Cards.AddRange(CardEntity.GetOrgCards(Common.CurUser.Role.RoleID));
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.CardMenuItem4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardMenuItem5_Click(object sender, EventArgs e) {
            try {
                new OutCardManagerForm().ShowDialog(this);
                lock (Common.CurUser.Role.Cards) {
                    Common.CurUser.Role.Cards.RemoveAll(c => c.WorkerType == EnmWorkerType.WXRY);
                    Common.CurUser.Role.Cards.AddRange(CardEntity.GetOutCards(Common.CurUser.Role.RoleID));
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.CardMenuItem5.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardMenuItem6_Click(object sender, EventArgs e) {
            try {
                new CardAuthManagerForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.CardMenuItem6.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardMenuItem7_Click(object sender, EventArgs e) {
            try {
                new CopyAuthForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.CardMenuItem7.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportMenuItem1_Click(object sender, EventArgs e) {
            try {
                new HisAlarmForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ReportMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportMenuItem2_Click(object sender, EventArgs e) {
            try {
                new DeviceForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ReportMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportMenuItem3_Click(object sender, EventArgs e) {
            try {
                new OrgEmployeeReportForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ReportMenuItem3.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportMenuItem4_Click(object sender, EventArgs e) {
            try {
                new OutEmployeeReportForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ReportMenuItem4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportMenuItem5_Click(object sender, EventArgs e) {
            try {
                new HisCardRecordsForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ReportMenuItem5.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReportMenuItem6_Click(object sender, EventArgs e) {
            try {
                new CardRecordsCountForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ReportMenuItem6.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewMenuItem1_CheckedChanged(object sender, EventArgs e) {
            try {
                PanelStyle.Panel1 = ViewMenuItem1.Checked;
                PanelStyle.Panel3 = PanelStyle.Panel1 || PanelStyle.Panel2;
                MainHSplitContainer.Visible = PanelStyle.Panel3 || PanelStyle.Panel4;
                if (MainHSplitContainer.Visible) {
                    if (PanelStyle.Panel3) {
                        if (PanelStyle.Panel1) {
                            MainVSplitContainer.Panel1Collapsed = false;
                        } else {
                            MainVSplitContainer.Panel1Collapsed = true;
                        }
                        if (!PanelStyle.Panel2) {
                            MainVSplitContainer.Panel2Collapsed = true;
                        }
                        MainHSplitContainer.Panel1Collapsed = false;
                    } else {
                        MainHSplitContainer.Panel1Collapsed = true;
                    }

                    if (!PanelStyle.Panel4) {
                        MainHSplitContainer.Panel2Collapsed = true;
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ViewMenuItem1.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewMenuItem2_CheckedChanged(object sender, EventArgs e) {
            try {
                PanelStyle.Panel2 = ViewMenuItem2.Checked;
                PanelStyle.Panel3 = PanelStyle.Panel1 || PanelStyle.Panel2;
                MainHSplitContainer.Visible = PanelStyle.Panel3 || PanelStyle.Panel4;
                if (MainHSplitContainer.Visible) {
                    if (PanelStyle.Panel3) {
                        if (PanelStyle.Panel2) {
                            MainVSplitContainer.Panel2Collapsed = false;
                        } else {
                            MainVSplitContainer.Panel2Collapsed = true;
                        }
                        if (!PanelStyle.Panel1) {
                            MainVSplitContainer.Panel1Collapsed = true;
                        }
                        MainHSplitContainer.Panel1Collapsed = false;
                    } else {
                        MainHSplitContainer.Panel1Collapsed = true;
                    }

                    if (!PanelStyle.Panel4) {
                        MainHSplitContainer.Panel2Collapsed = true;
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ViewMenuItem2.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewMenuItem3_CheckedChanged(object sender, EventArgs e) {
            try {
                PanelStyle.Panel4 = ViewMenuItem3.Checked;
                MainHSplitContainer.Visible = PanelStyle.Panel3 || PanelStyle.Panel4;
                if (MainHSplitContainer.Visible) {
                    if (PanelStyle.Panel4) {
                        MainHSplitContainer.Panel2Collapsed = false;
                    } else {
                        MainHSplitContainer.Panel2Collapsed = true;
                    }
                    if (!PanelStyle.Panel3) {
                        MainHSplitContainer.Panel1Collapsed = true;
                    }
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.ViewMenuItem3.CheckedChanged", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HelpMenuItem1_Click(object sender, EventArgs e) {
            try {
                Help.ShowHelp(this, String.Format(@"file://{0}\Doc\Help.chm", Environment.CurrentDirectory));
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.HelpMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HelpMenuItem2_Click(object sender, EventArgs e) {
            try {
                new RegisterForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.HelpMenuItem2.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HelpMenuItem31_Click(object sender, EventArgs e) {
            HelpMenuItem31.Checked = true;
            HelpMenuItem32.Checked = false;
        }

        private void HelpMenuItem32_Click(object sender, EventArgs e) {
            HelpMenuItem31.Checked = false;
            HelpMenuItem32.Checked = true;
        }

        private void HelpMenuItem4_Click(object sender, EventArgs e) {
            try {
                new AboutForm().ShowDialog(this);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.MainForm.HelpMenuItem4.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainToolBar1DefindItem_ButtonClick(object sender, EventArgs e) {
            MainToolBar1DefindItem.Select();
            MainToolBar1DefindItem.ShowDropDown();
        }

        private void MainToolBar1DefindItem1_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item1.Visible = MainToolBar1DefindItem1.Checked;
            MainToolBar1Separator1.Visible = (MainToolBar1Item1.Visible || MainToolBar1Item2.Visible);
        }

        private void MainToolBar1DefindItem2_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item2.Visible = MainToolBar1DefindItem2.Checked;
            MainToolBar1Separator1.Visible = (MainToolBar1Item1.Visible || MainToolBar1Item2.Visible);
        }

        private void MainToolBar1DefindItem3_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item3.Visible = MainToolBar1DefindItem3.Checked;
            MainToolBar1Separator2.Visible = (MainToolBar1Item3.Visible || MainToolBar1Item4.Visible);
        }

        private void MainToolBar1DefindItem4_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item4.Visible = MainToolBar1DefindItem4.Checked;
            MainToolBar1Separator2.Visible = (MainToolBar1Item3.Visible || MainToolBar1Item4.Visible);
        }

        private void MainToolBar1DefindItem5_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item5.Visible = MainToolBar1DefindItem5.Checked;
            MainToolBar1Separator3.Visible = MainToolBar1Item5.Visible;
        }

        private void MainToolBar1DefindItem6_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item6.Visible = MainToolBar1DefindItem6.Checked;
            MainToolBar1Separator4.Visible = MainToolBar1Item6.Visible;
        }

        private void MainToolBar1DefindItem7_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item7.Visible = MainToolBar1DefindItem7.Checked;
            MainToolBar1Separator5.Visible = (MainToolBar1Item7.Visible || MainToolBar1Item8.Visible || MainToolBar1Item9.Visible);
        }

        private void MainToolBar1DefindItem8_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item8.Visible = MainToolBar1DefindItem8.Checked;
            MainToolBar1Separator5.Visible = (MainToolBar1Item7.Visible || MainToolBar1Item8.Visible || MainToolBar1Item9.Visible);
        }

        private void MainToolBar1DefindItem9_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item9.Visible = MainToolBar1DefindItem9.Checked;
            MainToolBar1Separator5.Visible = (MainToolBar1Item7.Visible || MainToolBar1Item8.Visible || MainToolBar1Item9.Visible);
        }

        private void MainToolBar1DefindItem10_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item10.Visible = MainToolBar1DefindItem10.Checked;
            MainToolBar1Separator6.Visible = (MainToolBar1Item10.Visible || MainToolBar1Item11.Visible);
        }

        private void MainToolBar1DefindItem11_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item11.Visible = MainToolBar1DefindItem11.Checked;
            MainToolBar1Separator6.Visible = (MainToolBar1Item10.Visible || MainToolBar1Item11.Visible);
        }

        private void MainToolBar1DefindItem12_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item12.Visible = MainToolBar1DefindItem12.Checked;
        }

        private void MainToolBar1DefindItem13_CheckedChanged(object sender, EventArgs e) {
            MainToolBar1Item13.Visible = MainToolBar1DefindItem13.Checked;
        }
        #endregion
    }
    
    #region Layout Style Class
    public class LayoutStyle
    {
        /// <summary>
        /// Panel1
        /// </summary>
        public Boolean Panel1 { get; set; }

        /// <summary>
        /// Panel2
        /// </summary>
        public Boolean Panel2 { get; set; }

        /// <summary>
        /// Panel3
        /// </summary>
        public Boolean Panel3 { get; set; }

        /// <summary>
        /// Panel4
        /// </summary>
        public Boolean Panel4 { get; set; }
    }
    #endregion
}