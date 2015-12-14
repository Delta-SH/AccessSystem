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
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLiteDAL;
using Delta.MPS.SQLServerDAL;

namespace Delta.MPS.AccessSystem
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Gloal variables.
        /// </summary>
        private RegistryDatabase registryEntity;
        private List<RecentUserInfo> recentUsers;
        private RecentUserInfo lastUser;
        private ParamForm childForm;
        private Thread loginThread;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public LoginForm() {
            InitializeComponent();
        }

        /// <summary>
        /// Form loaded.
        /// </summary>
        private void LoginForm_Load(object sender, EventArgs e) {
            try {
                registryEntity = new RegistryDatabase();
                recentUsers = registryEntity.GetRecentUsers(20);
                bindLanguages();
                bindRecentUsers();
                generateCodeImage();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LoginForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Changed an new image.
        /// </summary>
        private void codeImage_Click(object sender, EventArgs e) {
            try {
                generateCodeImage();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LoginForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Text changed.
        /// </summary>
        private void userTxtCombo_TextChanged(object sender, EventArgs e) {
            pwdTxtBox.Text = String.Empty;
            codeTxtBox.Text = String.Empty;
            remeberCK.Checked = false;
        }

        /// <summary>
        /// Selected value changed.
        /// </summary>
        private void userTxtCombo_SelectedValueChanged(object sender, EventArgs e) {
            if (userTxtCombo.SelectedValue != null) {
                var selectedGuid = new Guid(userTxtCombo.SelectedValue.ToString());
                if (ComUtility.DefaultGuid.Equals(selectedGuid)) {
                    registryEntity.ClearRecentUsers();
                    recentUsers.Clear();
                    userTxtCombo.DataSource = null;
                    pwdTxtBox.Clear();
                    codeTxtBox.Clear();
                    LanguageCombo.SelectedIndex = 0;
                    remeberCK.Checked = false;
                } else {
                    var recentUser = recentUsers.Find(user => {
                        return user.UniqueID.Equals(selectedGuid);
                    });
                    if (recentUser != null) {
                        pwdTxtBox.Text = recentUser.RecentPwd;
                        LanguageCombo.SelectedValue = recentUser.RecentLan;
                        remeberCK.Checked = recentUser.RecentRmb;
                    }
                }
            }
        }

        /// <summary>
        /// Bind recent users.
        /// </summary>
        private void bindRecentUsers() {
            try {
                var data = new List<object>();
                if (recentUsers != null && recentUsers.Count > 0) {
                    foreach (var user in recentUsers) {
                        data.Add(new {
                            ID = user.UniqueID,
                            Name = user.RecentUser
                        });
                    }

                    data.Add(new {
                        ID = ComUtility.DefaultGuid,
                        Name = "<清空历史记录...>"
                    });
                }

                userTxtCombo.ValueMember = "ID";
                userTxtCombo.DisplayMember = "Name";
                userTxtCombo.DataSource = data;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Bind languages.
        /// </summary>
        private void bindLanguages() {
            try {
                var data = new List<object>();
                data.Add(new {
                    ID = "zh-cn",
                    Name = "中文"
                });
                data.Add(new {
                    ID = "en-us",
                    Name = "English"
                });

                LanguageCombo.ValueMember = "ID";
                LanguageCombo.DisplayMember = "Name";
                LanguageCombo.DataSource = data;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Generate code image.
        /// </summary>
        private void generateCodeImage() {
            try {
                if (this.InvokeRequired) {
                    this.Invoke(new MethodInvoker(delegate { generateCodeImage(); }));
                } else {
                    codeImage.Image = Common.CreateCodeImage(5);
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Set message tips.
        /// </summary>
        /// <param name="msg">message</param>
        /// <param name="msgType">message type</param>
        private void setMsgTip(string msg, EnmMsgType msgType) {
            try {
                if (this.InvokeRequired) {
                    this.Invoke(new MethodInvoker(delegate { setMsgTip(msg, msgType); }));
                } else {
                    switch (msgType) {
                        case EnmMsgType.Error:
                            tipLbl.ForeColor = Color.Red;
                            break;
                        case EnmMsgType.Warning:
                            tipLbl.ForeColor = Color.OrangeRed;
                            break;
                        default:
                            tipLbl.ForeColor = Color.Black;
                            break;
                    }

                    tipLbl.Text = msg;
                    tipLbl.Refresh();
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Set login status.
        /// </summary>
        /// <param name="status">login status</param>
        private void setLoginStatus(EnmLoginStatus status) {
            try {
                if (this.InvokeRequired) {
                    this.Invoke(new MethodInvoker(delegate { setLoginStatus(status); }));
                } else {
                    Common.LoginStatus = status;
                    switch (status) {
                        case EnmLoginStatus.Logining:
                        case EnmLoginStatus.Logined:
                        case EnmLoginStatus.Loading:
                        case EnmLoginStatus.Loaded:
                            loginPanel.Enabled = false;
                            loginBtn.Enabled = false;
                            cancelBtn.Enabled = true;
                            optionBtn.Enabled = false;
                            break;
                        case EnmLoginStatus.Offing:
                            loginPanel.Enabled = false;
                            loginBtn.Enabled = false;
                            cancelBtn.Enabled = false;
                            optionBtn.Enabled = false;
                            break;
                        case EnmLoginStatus.Off:
                            loginPanel.Enabled = true;
                            loginBtn.Enabled = true;
                            cancelBtn.Enabled = true;
                            optionBtn.Enabled = true;
                            break;
                        default:
                            break;
                    }
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// The click event of the login button.
        /// </summary>
        private void loginBtn_Click(object sender, EventArgs e) {
            try {
                if (String.IsNullOrWhiteSpace(userTxtCombo.Text)) {
                    userTxtCombo.Focus();
                    setMsgTip("用户名不能为空", EnmMsgType.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(pwdTxtBox.Text)) {
                    pwdTxtBox.Focus();
                    setMsgTip("密码不能为空", EnmMsgType.Warning);
                    return;
                }

                if (String.IsNullOrWhiteSpace(codeTxtBox.Text)) {
                    codeTxtBox.Focus();
                    setMsgTip("验证码不能为空", EnmMsgType.Warning);
                    return;
                }

                if (!Common.CheckCodeString.Equals(codeTxtBox.Text, StringComparison.CurrentCultureIgnoreCase)) {
                    codeTxtBox.Focus();
                    setMsgTip("验证码输入错误", EnmMsgType.Warning);
                    generateCodeImage();
                    return;
                }

                lastUser = new RecentUserInfo();
                lastUser.UniqueID = Guid.NewGuid();
                lastUser.RecentUser = Common.InputText(userTxtCombo.Text, 50);
                lastUser.RecentPwd = Common.InputText(pwdTxtBox.Text, 50);
                lastUser.RecentLan = LanguageCombo.SelectedValue.ToString();
                lastUser.RecentRmb = remeberCK.Checked;
                lastUser.UpdateTime = DateTime.Now;
                loginThread = new Thread(() => {
                    try {
                        if (lastUser == null) { return; }

                        setLoginStatus(EnmLoginStatus.Logining);
                        setMsgTip("验证系统配置，请稍等...", EnmMsgType.Info);
                        Thread.Sleep(500);

                        var databaseServers = registryEntity.GetDatabaseServers();
                        var masterDB = databaseServers.Find(db => { return db.DatabaseIntention == EnmDBIntention.Master; });
                        if (masterDB == null) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("主数据库未配置", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }
                        SQLHelper.ConnectionStringLocalTransaction = Common.CreateConnectionString(masterDB);

                        var hisDB = databaseServers.Find(db => { return db.DatabaseIntention == EnmDBIntention.History; });
                        if (hisDB == null) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("历史数据库未配置", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }
                        SQLHelper.HisConnectionStringLocalTransaction = Common.CreateConnectionString(hisDB);

                        Common.CurInterfaceParamter = registryEntity.GetInterfaceParamter();
                        if (Common.CurInterfaceParamter == null) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("接口参数未配置", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        var memberShipEntity = new MemberShip();
                        var users = memberShipEntity.GetClientUsers(Common.CurInterfaceParamter.InterfaceUser);
                        if (users == null || users.Count == 0) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("接口参数配置错误，登录用户不存在", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        var client = users.Find(u => u.Pwd.Equals(Common.CurInterfaceParamter.InterfacePwd, StringComparison.CurrentCultureIgnoreCase));
                        if (client == null) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("接口参数配置错误，登录密码错误", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        if (client.PortVer != 7) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("接口参数配置错误，登录用户非门禁浏览器用户", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        setMsgTip("正在登录，请稍等...", EnmMsgType.Info);
                        Thread.Sleep(500);

                        Common.CurUser = memberShipEntity.GetUser(lastUser.RecentUser);
                        if (Common.CurUser == null) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("用户名不存在，登录失败。", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        if (!Common.CurUser.Enabled) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("用户已禁用，请与管理员联系。", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        if (Common.CurUser.LimitDate < DateTime.Today) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("用户已过期，请与管理员联系。", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        if (Common.IsCheckFailedPasswordAttemptCount) {
                            if (Common.CurUser.IsLockedOut
                            && DateTime.Now.Subtract(Common.CurUser.FailedPasswordDate).TotalSeconds >= 3600 * Common.MaxLockedOutHours) {
                                Common.CurUser.FailedPasswordAttemptCount = 0;
                                Common.CurUser.IsLockedOut = false;
                                memberShipEntity.UpdateUser(Common.CurUser);
                            }

                            if (!Common.CurUser.IsLockedOut && Common.CurUser.FailedPasswordAttemptCount > 0
                            && DateTime.Now.Subtract(Common.CurUser.FailedPasswordDate).TotalSeconds >= 3600) {
                                Common.CurUser.FailedPasswordAttemptCount = 0;
                                memberShipEntity.UpdateUser(Common.CurUser);
                            }
                        }

                        if (Common.IsCheckFailedPasswordAttemptCount && Common.CurUser.IsLockedOut) {
                            var ts = Common.CurUser.FailedPasswordDate.AddSeconds(3600 * Common.MaxLockedOutHours).Subtract(DateTime.Now);
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip(String.Format("用户已锁定，还有{0}小时{1}分钟将自动解锁。", ts.Hours, ts.Minutes), EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        if (!memberShipEntity.CheckPassword(Common.CurUser.Password, lastUser.RecentPwd, Common.CurUser.PasswordFormat, Common.CurUser.PasswordSalt)) {
                            if (Common.IsCheckFailedPasswordAttemptCount) {
                                Common.CurUser.FailedPasswordAttemptCount++;
                                Common.CurUser.FailedPasswordDate = DateTime.Now;
                                Common.CurUser.IsLockedOut = Common.CurUser.FailedPasswordAttemptCount >= Common.MaxFailedPasswordAttemptCount;
                                if (Common.CurUser.IsLockedOut) { 
                                    Common.CurUser.LastLockoutDate = DateTime.Now; 
                                }
                                memberShipEntity.UpdateUser(Common.CurUser);

                                if (!Common.CurUser.IsLockedOut) {
                                    setLoginStatus(EnmLoginStatus.Off);
                                    setMsgTip(String.Format("密码错误，还可以再输入{0}次。", Common.MaxFailedPasswordAttemptCount - Common.CurUser.FailedPasswordAttemptCount), EnmMsgType.Warning);
                                    generateCodeImage();
                                    return;
                                } else {
                                    setLoginStatus(EnmLoginStatus.Off);
                                    setMsgTip(String.Format("密码错误，用户已锁定，将在{0}小时后自动解锁。", Common.MaxLockedOutHours), EnmMsgType.Warning);
                                    Common.WriteLog(DateTime.Now, EnmMsgType.Info, Common.CurUser.UserName, "Delta.MPS.AccessSystem.LoginForm", String.Format("用户已锁定，将在{0}小时后自动解锁。", Common.MaxLockedOutHours), null);
                                    generateCodeImage();
                                    return;
                                }
                            } else {
                                setLoginStatus(EnmLoginStatus.Off);
                                setMsgTip("密码错误，登录失败。", EnmMsgType.Warning);
                                generateCodeImage();
                                return;
                            }
                        }

                        //登录成功，重置密码输入错误次数。
                        if (Common.IsCheckFailedPasswordAttemptCount) {
                            Common.CurUser.FailedPasswordAttemptCount = 0;
                            Common.CurUser.IsLockedOut = false;
                            memberShipEntity.UpdateUser(Common.CurUser);
                        }

                        //验证角色
                        Common.CurUser.Role = memberShipEntity.GetRole(Common.CurUser.Role.RoleID);
                        if (Common.CurUser.Role == null) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("用户未授权角色，请与管理员联系。", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        if (!Common.CurUser.Role.Enabled) {
                            setLoginStatus(EnmLoginStatus.Off);
                            setMsgTip("授权角色已禁用，请与管理员联系。", EnmMsgType.Warning);
                            generateCodeImage();
                            return;
                        }

                        lastUser.RecentPwd = lastUser.RecentRmb ? lastUser.RecentPwd : String.Empty;
                        registryEntity.SaveRecentUsers(new List<RecentUserInfo>() { lastUser });
                        recentUsers.RemoveAll(user => { return user.RecentUser.Equals(lastUser.RecentUser); });
                        recentUsers.Add(lastUser);

                        setLoginStatus(EnmLoginStatus.Logined);
                        setMsgTip("登录成功，准备加载数据...", EnmMsgType.Info);
                        Common.WriteLog(DateTime.Now, EnmMsgType.Login, Common.CurUser.UserName, "Delta.MPS.AccessSystem.MainForm", String.Format("{0} - {1} 登录系统", Common.CurUser.Role.RoleName, Common.CurUser.UserName), null);

                        setLoginStatus(EnmLoginStatus.Loading);
                        setMsgTip("加载角色信息(1/5)...", EnmMsgType.Info);
                        Common.CurUser.Role.Authorizations = memberShipEntity.GetRoleAuthorizations(Common.CurUser.Role.RoleID);
                        Common.CurUser.Role.Nodes = memberShipEntity.GetRoleNodes(Common.CurUser.Role.RoleID);

                        setMsgTip("加载部门信息(2/5)...", EnmMsgType.Info);
                        Common.CurUser.Role.Departments = memberShipEntity.GetRoleDepartments(Common.CurUser.Role.RoleID);

                        setMsgTip("加载设备信息(3/5)...", EnmMsgType.Info);
                        Common.CurUser.Role.Devices = memberShipEntity.GetRoleDevices(Common.CurUser.Role.RoleID);

                        setMsgTip("系统数据校验(4/5)...", EnmMsgType.Info);
                        new MemberShip().VerifySystemData();

                        setMsgTip("软件授权校验(5/5)...", EnmMsgType.Info);
                        if (Common.IsCheckLicense) {
                            Common.CurApplication.UniqueID = Common.GetMachineCode();
                            var lastApplication = registryEntity.GetSystemApplication(Common.CurApplication.UniqueID);
                            if (lastApplication != null) {
                                Common.CurApplication.AppLicense = lastApplication.AppLicense;
                                Common.CurApplication.AppFirstTime = lastApplication.AppFirstTime;
                            }
                            registryEntity.SaveSystemApplication(Common.CurApplication);
                            Common.CheckLicense(Common.CurApplication.AppLicense);
                        }

                        setLoginStatus(EnmLoginStatus.Loaded);
                        setMsgTip("正在启动主程序...", EnmMsgType.Info);

                        this.Invoke(new MethodInvoker(delegate {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }));
                    } catch (ThreadAbortException) {
                    } catch (Exception err) {
                        Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LoginForm", err.Message, err.StackTrace);
                        MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });

                loginThread.IsBackground = true;
                loginThread.Start();
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LoginForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The click event of the cancel button.
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e) {
            try {
                if (Common.LoginStatus != EnmLoginStatus.Off) {
                    setLoginStatus(EnmLoginStatus.Offing);
                    setMsgTip("正在取消...", EnmMsgType.Info);
                    if (loginThread != null && loginThread.IsAlive) {
                        loginThread.Abort();
                    }

                    setLoginStatus(EnmLoginStatus.Off);
                    setMsgTip("操作已取消", EnmMsgType.Info);
                    this.DialogResult = DialogResult.None;
                    generateCodeImage();
                } else {
                    this.DialogResult = DialogResult.Cancel;
                    this.Dispose();
                    this.Close();
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LoginForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// The click event of the option button.
        /// </summary>
        private void optionBtn_Click(object sender, EventArgs e) {
            try {
                if (ChildForm == null) {
                    ChildForm = new ParamForm(this);
                    ChildForm.Show(this);
                } else {
                    ChildForm.Dispose();
                    ChildForm.Close();
                    ChildForm = null;
                }

                SetOptionText(null);
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.LoginForm", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Location changed.
        /// </summary>
        private void LoginForm_LocationChanged(object sender, EventArgs e) {
            if (ChildForm != null && ChildForm.Visible && ChildForm.Joined) {
                ChildForm.SetDesktopLocation(this.Location.X + this.Width, this.Location.Y);
            }
        }

        /// <summary>
        /// Set option button text.
        /// </summary>
        /// <param name="text">button text</param>
        public void SetOptionText(string text) {
            text = String.IsNullOrWhiteSpace(text) ? "选项(&O)" : text;
            optionBtn.Text = String.Format("{0} {1}", text, ChildForm != null ? "<<" : ">>");
        }

        /// <summary>
        /// Child form.
        /// </summary>
        public ParamForm ChildForm {
            get { return childForm; }
            set { childForm = value; }
        }
    }
}
