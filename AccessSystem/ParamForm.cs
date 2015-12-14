using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Reflection;
using Delta.MPS.Model;
using Delta.MPS.SQLiteDAL;
using Delta.MPS.DBUtility;

namespace Delta.MPS.AccessSystem
{
    public partial class ParamForm : Form
    {
        /// <summary>
        /// Gloal variables.
        /// </summary>
        private RegistryDatabase registryEntity;
        private LoginForm parentForm;
        private EnmTestStatus TestStatus;
        private bool joined = true;
        private bool actived = false;
        private const int WM_EXITSIZEMOVE = 0x0232;
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == WM_EXITSIZEMOVE) {
                if (joined) {
                    this.MinimizeBox = false;
                    this.ShowInTaskbar = false;
                } else {
                    this.MinimizeBox = true;
                    this.ShowInTaskbar = true;
                }
            }
        }

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="parentForm">parent form</param>
        public ParamForm(LoginForm parentForm) {
            InitializeComponent();
            this.parentForm = parentForm;
            SetDesktopLocation(parentForm.Location.X + parentForm.Width, parentForm.Location.Y);
        }

        /// <summary>
        /// The load event of this form.
        /// </summary>
        private void ParamForm_Load(object sender, EventArgs e) {
            try {
                registryEntity = new RegistryDatabase();
                BindDBTypeCombobox();
                BindDatasource();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ParamForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form closed.
        /// </summary>
        private void ParamForm_FormClosed(object sender, FormClosedEventArgs e) {
            parentForm.ChildForm = null;
            parentForm.SetOptionText(null);
        }

        /// <summary>
        /// Location changed.
        /// </summary>
        private void ParamForm_LocationChanged(object sender, EventArgs e) {
            if (!this.Actived) { return; }

            joined = false;
            if (parentForm != null && parentForm.Visible) {
                if (Math.Abs(this.Location.Y - parentForm.Location.Y) < 30
                    && Math.Abs(this.Location.X - parentForm.Location.X - parentForm.Width) < 30) {
                    this.SetDesktopLocation(parentForm.Location.X + parentForm.Width, parentForm.Location.Y);
                    joined = true;
                }
            }
        }

        /// <summary>
        /// Form activated.
        /// </summary>
        private void ParamForm_Activated(object sender, EventArgs e) {
            this.Actived = true;
        }

        /// <summary>
        /// Form deactivated.
        /// </summary>
        private void ParamForm_Deactivate(object sender, EventArgs e) {
            this.Actived = false;
        }

        /// <summary>
        /// Tab control selected index changed.
        /// </summary>
        private void paramTab_SelectedIndexChanged(object sender, EventArgs e) {
            if (paramTab.SelectedIndex != 0 && paramTab.SelectedIndex != 1) {
                TestBtn.Visible = false;
            } else {
                TestBtn.Visible = true;
            }
        }
        
        /// <summary>
        /// Test database connection.
        /// </summary>
        private void TestBtn_Click(object sender, EventArgs e) {
            try {
                if (paramTab.SelectedIndex != 0 && paramTab.SelectedIndex != 1) {
                    return;
                }

                if (paramTab.SelectedIndex == 0) {
                    if (String.IsNullOrWhiteSpace(masterDBServer.Text)) {
                        masterDBServer.Focus();
                        MessageBox.Show("数据库地址不能为空", "主数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(masterDBName.Text)) {
                        masterDBName.Focus();
                        MessageBox.Show("数据库名称不能为空", "主数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(masterDBUser.Text)) {
                        masterDBUser.Focus();
                        MessageBox.Show("登录名不能为空", "主数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(masterDBPwd.Text)) {
                        masterDBPwd.Focus();
                        MessageBox.Show("密码不能为空", "主数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var database = new DatabaseServerInfo();
                    database.UniqueID = Guid.NewGuid();
                    database.DatabaseIntention = EnmDBIntention.Master;
                    database.DatabaseType = ComUtility.DBNullDBTypeHandler(masterDBType.SelectedValue);
                    database.DatabaseIP = masterDBServer.Text;
                    database.DatabasePort = (int)masterDBPort.Value;
                    database.DatabaseName = masterDBName.Text;
                    database.DatabaseUser = masterDBUser.Text;
                    database.DatabasePwd = masterDBPwd.Text;
                    database.UpdateTime = DateTime.Now;

                    paramTab.Enabled = false;
                    TestBtn.Enabled = false;
                    OKBtn.Enabled = false;
                    var connectionString = Common.CreateConnectionString(database);
                    var testthread = new Thread(() => {
                        try {
                            var message = "";
                            var timeout = 60;
                            var thread = new Thread(() => {
                                using (var conn = new SqlConnection(connectionString)) {
                                    try {
                                        conn.Open();
                                        conn.Close();
                                        TestStatus = EnmTestStatus.Success;
                                    } catch (Exception err) {
                                        TestStatus = EnmTestStatus.Failure;
                                        message = err.Message;
                                    }
                                }
                            });
                            TestStatus = EnmTestStatus.Testing;
                            thread.IsBackground = true;
                            thread.Start();

                            var sw = System.Diagnostics.Stopwatch.StartNew();
                            var ts = TimeSpan.FromSeconds(timeout);
                            while (sw.Elapsed < ts) {
                                thread.Join(TimeSpan.FromMilliseconds(1000));
                                if (TestStatus != EnmTestStatus.Testing) { break; }
                            }
                            sw.Stop();

                            if (TestStatus == EnmTestStatus.Testing) {
                                MessageBox.Show("SQL Server服务器连接超时", "主数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            } else if (TestStatus == EnmTestStatus.Success) {
                                MessageBox.Show("测试连接成功", "主数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } else if (TestStatus == EnmTestStatus.Failure) {
                                MessageBox.Show(message, "主数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } catch (Exception err) {
                            MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } finally {
                            this.Invoke(new MethodInvoker(delegate {
                                paramTab.Enabled = true;
                                TestBtn.Enabled = true;
                                OKBtn.Enabled = true;
                                CancelBtn.Enabled = true;
                            }));
                            TestStatus = EnmTestStatus.Default;
                        }
                    });
                    testthread.IsBackground = true;
                    testthread.Start();
                } else {
                    if (String.IsNullOrWhiteSpace(hisDBServer.Text)) {
                        hisDBServer.Focus();
                        MessageBox.Show("数据库地址不能为空", "历史数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(hisDBName.Text)) {
                        hisDBName.Focus();
                        MessageBox.Show("数据库名称不能为空", "历史数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(hisDBUser.Text)) {
                        hisDBUser.Focus();
                        MessageBox.Show("登录名不能为空", "历史数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (String.IsNullOrWhiteSpace(masterDBPwd.Text)) {
                        hisDBPwd.Focus();
                        MessageBox.Show("密码不能为空", "历史数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var database = new DatabaseServerInfo();
                    database.UniqueID = Guid.NewGuid();
                    database.DatabaseIntention = EnmDBIntention.History;
                    database.DatabaseType = ComUtility.DBNullDBTypeHandler(hisDBType.SelectedValue);
                    database.DatabaseIP = hisDBServer.Text;
                    database.DatabasePort = (int)hisDBPort.Value;
                    database.DatabaseName = hisDBName.Text;
                    database.DatabaseUser = hisDBUser.Text;
                    database.DatabasePwd = hisDBPwd.Text;
                    database.UpdateTime = DateTime.Now;

                    paramTab.Enabled = false;
                    TestBtn.Enabled = false;
                    OKBtn.Enabled = false;
                    var connectionString = Common.CreateConnectionString(database);
                    var testthread = new Thread(() => {
                        try {
                            var message = "";
                            var timeout = 60;
                            var thread = new Thread(() => {
                                using (var conn = new SqlConnection(connectionString)) {
                                    try {
                                        conn.Open();
                                        conn.Close();
                                        TestStatus = EnmTestStatus.Success;
                                    } catch (Exception err) {
                                        TestStatus = EnmTestStatus.Failure;
                                        message = err.Message;
                                    }
                                }
                            });
                            TestStatus = EnmTestStatus.Testing;
                            thread.IsBackground = true;
                            thread.Start();

                            var sw = System.Diagnostics.Stopwatch.StartNew();
                            var ts = TimeSpan.FromSeconds(timeout);
                            while (sw.Elapsed < ts) {
                                thread.Join(TimeSpan.FromMilliseconds(1000));
                                if (TestStatus != EnmTestStatus.Testing) { break; }
                            }
                            sw.Stop();

                            if (TestStatus == EnmTestStatus.Testing) {
                                MessageBox.Show("SQL Server服务器连接超时", "历史数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            } else if (TestStatus == EnmTestStatus.Success) {
                                MessageBox.Show("测试连接成功", "历史数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            } else if (TestStatus == EnmTestStatus.Failure) {
                                MessageBox.Show(message, "历史数据库测试", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        } catch (Exception err) {
                            MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } finally {
                            this.Invoke(new MethodInvoker(delegate {
                                paramTab.Enabled = true;
                                TestBtn.Enabled = true;
                                OKBtn.Enabled = true;
                                CancelBtn.Enabled = true;
                            }));
                            TestStatus = EnmTestStatus.Default;
                        }
                    });
                    testthread.IsBackground = true;
                    testthread.Start();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ParamForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save system paramters information.
        /// </summary>
        private void OKBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(masterDBServer.Text)) {
                    if (paramTab.SelectedIndex != 0) { paramTab.SelectedIndex = 0; }
                    masterDBServer.Focus();
                    MessageBox.Show("数据库地址不能为空", "主数据库配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(masterDBName.Text)) {
                    if (paramTab.SelectedIndex != 0) { paramTab.SelectedIndex = 0; }
                    masterDBName.Focus();
                    MessageBox.Show("数据库名称不能为空", "主数据库配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(masterDBUser.Text)) {
                    if (paramTab.SelectedIndex != 0) { paramTab.SelectedIndex = 0; }
                    masterDBUser.Focus();
                    MessageBox.Show("登录名不能为空", "主数据库配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(masterDBPwd.Text)) {
                    if (paramTab.SelectedIndex != 0) { paramTab.SelectedIndex = 0; }
                    masterDBPwd.Focus();
                    MessageBox.Show("密码不能为空", "主数据库配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(hisDBServer.Text)) {
                    if (paramTab.SelectedIndex != 1) { paramTab.SelectedIndex = 1; }
                    hisDBServer.Focus();
                    MessageBox.Show("数据库地址不能为空", "历史数据库配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(hisDBName.Text)) {
                    if (paramTab.SelectedIndex != 1) { paramTab.SelectedIndex = 1; }
                    hisDBName.Focus();
                    MessageBox.Show("数据库名称不能为空", "历史数据库配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(hisDBUser.Text)) {
                    if (paramTab.SelectedIndex != 1) { paramTab.SelectedIndex = 1; }
                    hisDBUser.Focus();
                    MessageBox.Show("登录名不能为空", "历史数据库配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(hisDBPwd.Text)) {
                    if (paramTab.SelectedIndex != 1) { paramTab.SelectedIndex = 1; }
                    hisDBPwd.Focus();
                    MessageBox.Show("密码不能为空", "历史数据库配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(interfaceServer.Text)) {
                    if (paramTab.SelectedIndex != 2) { paramTab.SelectedIndex = 2; }
                    interfaceServer.Focus();
                    MessageBox.Show("通信地址不能为空", "接口配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(interfaceUser.Text)) {
                    if (paramTab.SelectedIndex != 2) { paramTab.SelectedIndex = 2; }
                    interfaceUser.Focus();
                    MessageBox.Show("登录用户不能为空", "接口配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(interfacePwd.Text)) {
                    if (paramTab.SelectedIndex != 2) { paramTab.SelectedIndex = 2; }
                    interfacePwd.Focus();
                    MessageBox.Show("登录密码不能为空", "接口配置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var masterDB = new DatabaseServerInfo();
                masterDB.UniqueID = Guid.NewGuid();
                masterDB.DatabaseIntention = EnmDBIntention.Master;
                masterDB.DatabaseType = ComUtility.DBNullDBTypeHandler(masterDBType.SelectedValue);
                masterDB.DatabaseIP = masterDBServer.Text;
                masterDB.DatabasePort = (int)masterDBPort.Value;
                masterDB.DatabaseName = masterDBName.Text;
                masterDB.DatabaseUser = masterDBUser.Text;
                masterDB.DatabasePwd = masterDBPwd.Text;
                masterDB.UpdateTime = DateTime.Now;

                var hisDB = new DatabaseServerInfo();
                hisDB.UniqueID = Guid.NewGuid();
                hisDB.DatabaseIntention = EnmDBIntention.History;
                hisDB.DatabaseType = ComUtility.DBNullDBTypeHandler(hisDBType.SelectedValue);
                hisDB.DatabaseIP = hisDBServer.Text;
                hisDB.DatabasePort = (int)hisDBPort.Value;
                hisDB.DatabaseName = hisDBName.Text;
                hisDB.DatabaseUser = hisDBUser.Text;
                hisDB.DatabasePwd = hisDBPwd.Text;
                hisDB.UpdateTime = DateTime.Now;

                var paramter = new InterfaceInfo();
                paramter.UniqueID = Guid.NewGuid();
                paramter.InterfaceIP = interfaceServer.Text;
                paramter.InterfacePort = (int)interfacePort.Value;
                paramter.InterfaceUser = interfaceUser.Text;
                paramter.InterfacePwd = interfacePwd.Text;
                paramter.InterfaceDetect = (int)interfaceDetect.Value;
                paramter.InterfaceInterrupt = (int)interfaceInterrupt.Value;
                paramter.InterfaceSyncTime = interfaceSyncTime.Checked;
                paramter.UpdateTime = DateTime.Now;

                registryEntity.SaveDatabaseServers(new List<DatabaseServerInfo>() { masterDB, hisDB });
                registryEntity.SaveInterfaceParamters(paramter);
                MessageBox.Show("数据保存完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ParamForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Close this Form.
        /// </summary>
        private void CancelBtn_Click(object sender, EventArgs e) {
            try {
                if (TestStatus != EnmTestStatus.Default) {
                    CancelBtn.Enabled = false;
                    TestStatus = EnmTestStatus.Stop;
                } else {
                    Close();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.ParamForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bind Datasource Type Combobox.
        /// </summary>
        private void BindDBTypeCombobox() {
            try {
                var masterData = new List<object>();
                var hisData = new List<object>();
                foreach (EnmDBType dbType in Enum.GetValues(typeof(EnmDBType))) {
                    masterData.Add(new { ID = (int)dbType, Name = dbType.ToString() });
                    hisData.Add(new { ID = (int)dbType, Name = dbType.ToString() });
                }

                masterDBType.ValueMember = "ID";
                masterDBType.DisplayMember = "Name";
                masterDBType.DataSource = masterData;

                hisDBType.ValueMember = "ID";
                hisDBType.DisplayMember = "Name";
                hisDBType.DataSource = hisData;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Bind Datasource.
        /// </summary>
        private void BindDatasource() {
            try {
                var databases = registryEntity.GetDatabaseServers();
                var masterDB = databases.Find(db => {
                    return db.DatabaseIntention == EnmDBIntention.Master;
                });
                if (masterDB != null) {
                    masterDBType.SelectedValue = (int)masterDB.DatabaseType;
                    masterDBServer.Text = masterDB.DatabaseIP;
                    masterDBPort.Value = masterDB.DatabasePort;
                    masterDBName.Text = masterDB.DatabaseName;
                    masterDBUser.Text = masterDB.DatabaseUser;
                    masterDBPwd.Text = masterDB.DatabasePwd;
                }

                var hisDB = databases.Find(db => {
                    return db.DatabaseIntention == EnmDBIntention.History;
                });
                if (hisDB != null) {
                    hisDBType.SelectedValue = (int)hisDB.DatabaseType;
                    hisDBServer.Text = hisDB.DatabaseIP;
                    hisDBPort.Value = hisDB.DatabasePort;
                    hisDBName.Text = hisDB.DatabaseName;
                    hisDBUser.Text = hisDB.DatabaseUser;
                    hisDBPwd.Text = hisDB.DatabasePwd;
                }

                var param = registryEntity.GetInterfaceParamter();
                if (param != null) {
                    interfaceServer.Text = param.InterfaceIP;
                    interfacePort.Value = param.InterfacePort;
                    interfaceUser.Text = param.InterfaceUser;
                    interfacePwd.Text = param.InterfacePwd;
                    interfaceDetect.Value = param.InterfaceDetect;
                    interfaceInterrupt.Value = param.InterfaceInterrupt;
                    interfaceSyncTime.Checked = param.InterfaceSyncTime;
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Joined
        /// </summary>
        public bool Joined {
            get { return joined; }
            set { joined = value; }
        }

        /// <summary>
        /// Actived
        /// </summary>
        public bool Actived {
            get { return actived; }
            set { actived = value; }
        }
    }
}
