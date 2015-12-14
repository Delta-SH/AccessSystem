namespace Delta.MPS.AccessSystem
{
    partial class ParamForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParamForm));
            this.paramTab = new System.Windows.Forms.TabControl();
            this.masterDBSetting = new System.Windows.Forms.TabPage();
            this.masterDBPort = new System.Windows.Forms.NumericUpDown();
            this.masterDBPortLbl = new System.Windows.Forms.Label();
            this.masterDBName = new System.Windows.Forms.TextBox();
            this.masterDBNameLbl = new System.Windows.Forms.Label();
            this.masterDBPwd = new System.Windows.Forms.TextBox();
            this.masterDBPwdLbl = new System.Windows.Forms.Label();
            this.masterDBUser = new System.Windows.Forms.TextBox();
            this.masterDBUserLbl = new System.Windows.Forms.Label();
            this.masterDBType = new System.Windows.Forms.ComboBox();
            this.DSServerLbl = new System.Windows.Forms.Label();
            this.masterDBServer = new System.Windows.Forms.TextBox();
            this.masterDBTypeLbl = new System.Windows.Forms.Label();
            this.hisDBSetting = new System.Windows.Forms.TabPage();
            this.hisDBPort = new System.Windows.Forms.NumericUpDown();
            this.hisDBPortLbl = new System.Windows.Forms.Label();
            this.hisDBName = new System.Windows.Forms.TextBox();
            this.hisDBNameLbl = new System.Windows.Forms.Label();
            this.hisDBPwd = new System.Windows.Forms.TextBox();
            this.hisDBPwdLbl = new System.Windows.Forms.Label();
            this.hisDBUser = new System.Windows.Forms.TextBox();
            this.hisDBUserLbl = new System.Windows.Forms.Label();
            this.hisDBType = new System.Windows.Forms.ComboBox();
            this.hisDBServerLbl = new System.Windows.Forms.Label();
            this.hisDBServer = new System.Windows.Forms.TextBox();
            this.hisDBTypeLbl = new System.Windows.Forms.Label();
            this.interfaceSetting = new System.Windows.Forms.TabPage();
            this.interfaceSyncTime = new System.Windows.Forms.CheckBox();
            this.interfaceInterrupt = new System.Windows.Forms.NumericUpDown();
            this.interfaceDetect = new System.Windows.Forms.NumericUpDown();
            this.interfaceSyncTimeLbl = new System.Windows.Forms.Label();
            this.interfaceInterruptLbl = new System.Windows.Forms.Label();
            this.interfaceDetectLbl = new System.Windows.Forms.Label();
            this.interfacePort = new System.Windows.Forms.NumericUpDown();
            this.interfacePortLbl = new System.Windows.Forms.Label();
            this.interfacePwd = new System.Windows.Forms.TextBox();
            this.interfacePwdLbl = new System.Windows.Forms.Label();
            this.interfaceUser = new System.Windows.Forms.TextBox();
            this.interfaceUserLbl = new System.Windows.Forms.Label();
            this.interfaceServerLbl = new System.Windows.Forms.Label();
            this.interfaceServer = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.TestBtn = new System.Windows.Forms.Button();
            this.paramTab.SuspendLayout();
            this.masterDBSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterDBPort)).BeginInit();
            this.hisDBSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hisDBPort)).BeginInit();
            this.interfaceSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interfaceInterrupt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interfaceDetect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interfacePort)).BeginInit();
            this.SuspendLayout();
            // 
            // paramTab
            // 
            this.paramTab.Controls.Add(this.masterDBSetting);
            this.paramTab.Controls.Add(this.hisDBSetting);
            this.paramTab.Controls.Add(this.interfaceSetting);
            this.paramTab.Location = new System.Drawing.Point(10, 10);
            this.paramTab.Name = "paramTab";
            this.paramTab.SelectedIndex = 0;
            this.paramTab.Size = new System.Drawing.Size(335, 290);
            this.paramTab.TabIndex = 0;
            this.paramTab.SelectedIndexChanged += new System.EventHandler(this.paramTab_SelectedIndexChanged);
            // 
            // masterDBSetting
            // 
            this.masterDBSetting.Controls.Add(this.masterDBPort);
            this.masterDBSetting.Controls.Add(this.masterDBPortLbl);
            this.masterDBSetting.Controls.Add(this.masterDBName);
            this.masterDBSetting.Controls.Add(this.masterDBNameLbl);
            this.masterDBSetting.Controls.Add(this.masterDBPwd);
            this.masterDBSetting.Controls.Add(this.masterDBPwdLbl);
            this.masterDBSetting.Controls.Add(this.masterDBUser);
            this.masterDBSetting.Controls.Add(this.masterDBUserLbl);
            this.masterDBSetting.Controls.Add(this.masterDBType);
            this.masterDBSetting.Controls.Add(this.DSServerLbl);
            this.masterDBSetting.Controls.Add(this.masterDBServer);
            this.masterDBSetting.Controls.Add(this.masterDBTypeLbl);
            this.masterDBSetting.Location = new System.Drawing.Point(4, 26);
            this.masterDBSetting.Name = "masterDBSetting";
            this.masterDBSetting.Size = new System.Drawing.Size(327, 260);
            this.masterDBSetting.TabIndex = 0;
            this.masterDBSetting.Text = "主数据库配置";
            this.masterDBSetting.UseVisualStyleBackColor = true;
            // 
            // masterDBPort
            // 
            this.masterDBPort.Location = new System.Drawing.Point(115, 85);
            this.masterDBPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.masterDBPort.Name = "masterDBPort";
            this.masterDBPort.Size = new System.Drawing.Size(200, 23);
            this.masterDBPort.TabIndex = 6;
            this.masterDBPort.Value = new decimal(new int[] {
            1433,
            0,
            0,
            0});
            // 
            // masterDBPortLbl
            // 
            this.masterDBPortLbl.Location = new System.Drawing.Point(10, 85);
            this.masterDBPortLbl.Name = "masterDBPortLbl";
            this.masterDBPortLbl.Size = new System.Drawing.Size(100, 25);
            this.masterDBPortLbl.TabIndex = 5;
            this.masterDBPortLbl.Text = "数据库端口(&R):";
            this.masterDBPortLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // masterDBName
            // 
            this.masterDBName.Location = new System.Drawing.Point(115, 120);
            this.masterDBName.MaxLength = 500;
            this.masterDBName.Name = "masterDBName";
            this.masterDBName.Size = new System.Drawing.Size(200, 23);
            this.masterDBName.TabIndex = 8;
            // 
            // masterDBNameLbl
            // 
            this.masterDBNameLbl.Location = new System.Drawing.Point(10, 120);
            this.masterDBNameLbl.Name = "masterDBNameLbl";
            this.masterDBNameLbl.Size = new System.Drawing.Size(100, 25);
            this.masterDBNameLbl.TabIndex = 7;
            this.masterDBNameLbl.Text = "数据库名称(&N):";
            this.masterDBNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // masterDBPwd
            // 
            this.masterDBPwd.Location = new System.Drawing.Point(115, 190);
            this.masterDBPwd.MaxLength = 50;
            this.masterDBPwd.Name = "masterDBPwd";
            this.masterDBPwd.PasswordChar = '●';
            this.masterDBPwd.Size = new System.Drawing.Size(200, 23);
            this.masterDBPwd.TabIndex = 12;
            // 
            // masterDBPwdLbl
            // 
            this.masterDBPwdLbl.Location = new System.Drawing.Point(10, 190);
            this.masterDBPwdLbl.Name = "masterDBPwdLbl";
            this.masterDBPwdLbl.Size = new System.Drawing.Size(100, 25);
            this.masterDBPwdLbl.TabIndex = 11;
            this.masterDBPwdLbl.Text = "密码(&P):";
            this.masterDBPwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // masterDBUser
            // 
            this.masterDBUser.Location = new System.Drawing.Point(115, 155);
            this.masterDBUser.MaxLength = 50;
            this.masterDBUser.Name = "masterDBUser";
            this.masterDBUser.Size = new System.Drawing.Size(200, 23);
            this.masterDBUser.TabIndex = 10;
            // 
            // masterDBUserLbl
            // 
            this.masterDBUserLbl.Location = new System.Drawing.Point(10, 155);
            this.masterDBUserLbl.Name = "masterDBUserLbl";
            this.masterDBUserLbl.Size = new System.Drawing.Size(100, 25);
            this.masterDBUserLbl.TabIndex = 9;
            this.masterDBUserLbl.Text = "登录名(&U):";
            this.masterDBUserLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // masterDBType
            // 
            this.masterDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.masterDBType.Location = new System.Drawing.Point(115, 15);
            this.masterDBType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.masterDBType.Name = "masterDBType";
            this.masterDBType.Size = new System.Drawing.Size(200, 25);
            this.masterDBType.TabIndex = 2;
            // 
            // DSServerLbl
            // 
            this.DSServerLbl.Location = new System.Drawing.Point(10, 50);
            this.DSServerLbl.Name = "DSServerLbl";
            this.DSServerLbl.Size = new System.Drawing.Size(100, 25);
            this.DSServerLbl.TabIndex = 3;
            this.DSServerLbl.Text = "数据库地址(&I):";
            this.DSServerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // masterDBServer
            // 
            this.masterDBServer.Location = new System.Drawing.Point(115, 50);
            this.masterDBServer.MaxLength = 500;
            this.masterDBServer.Name = "masterDBServer";
            this.masterDBServer.Size = new System.Drawing.Size(200, 23);
            this.masterDBServer.TabIndex = 4;
            // 
            // masterDBTypeLbl
            // 
            this.masterDBTypeLbl.Location = new System.Drawing.Point(10, 15);
            this.masterDBTypeLbl.Name = "masterDBTypeLbl";
            this.masterDBTypeLbl.Size = new System.Drawing.Size(100, 25);
            this.masterDBTypeLbl.TabIndex = 1;
            this.masterDBTypeLbl.Text = "数据库类型(&T):";
            this.masterDBTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hisDBSetting
            // 
            this.hisDBSetting.Controls.Add(this.hisDBPort);
            this.hisDBSetting.Controls.Add(this.hisDBPortLbl);
            this.hisDBSetting.Controls.Add(this.hisDBName);
            this.hisDBSetting.Controls.Add(this.hisDBNameLbl);
            this.hisDBSetting.Controls.Add(this.hisDBPwd);
            this.hisDBSetting.Controls.Add(this.hisDBPwdLbl);
            this.hisDBSetting.Controls.Add(this.hisDBUser);
            this.hisDBSetting.Controls.Add(this.hisDBUserLbl);
            this.hisDBSetting.Controls.Add(this.hisDBType);
            this.hisDBSetting.Controls.Add(this.hisDBServerLbl);
            this.hisDBSetting.Controls.Add(this.hisDBServer);
            this.hisDBSetting.Controls.Add(this.hisDBTypeLbl);
            this.hisDBSetting.Location = new System.Drawing.Point(4, 26);
            this.hisDBSetting.Name = "hisDBSetting";
            this.hisDBSetting.Size = new System.Drawing.Size(327, 260);
            this.hisDBSetting.TabIndex = 1;
            this.hisDBSetting.Text = "历史数据库配置";
            this.hisDBSetting.UseVisualStyleBackColor = true;
            // 
            // hisDBPort
            // 
            this.hisDBPort.Location = new System.Drawing.Point(115, 85);
            this.hisDBPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.hisDBPort.Name = "hisDBPort";
            this.hisDBPort.Size = new System.Drawing.Size(200, 23);
            this.hisDBPort.TabIndex = 6;
            this.hisDBPort.Value = new decimal(new int[] {
            1433,
            0,
            0,
            0});
            // 
            // hisDBPortLbl
            // 
            this.hisDBPortLbl.Location = new System.Drawing.Point(10, 85);
            this.hisDBPortLbl.Name = "hisDBPortLbl";
            this.hisDBPortLbl.Size = new System.Drawing.Size(100, 25);
            this.hisDBPortLbl.TabIndex = 5;
            this.hisDBPortLbl.Text = "数据库端口(&R):";
            this.hisDBPortLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hisDBName
            // 
            this.hisDBName.Location = new System.Drawing.Point(115, 120);
            this.hisDBName.MaxLength = 500;
            this.hisDBName.Name = "hisDBName";
            this.hisDBName.Size = new System.Drawing.Size(200, 23);
            this.hisDBName.TabIndex = 8;
            // 
            // hisDBNameLbl
            // 
            this.hisDBNameLbl.Location = new System.Drawing.Point(10, 120);
            this.hisDBNameLbl.Name = "hisDBNameLbl";
            this.hisDBNameLbl.Size = new System.Drawing.Size(100, 25);
            this.hisDBNameLbl.TabIndex = 7;
            this.hisDBNameLbl.Text = "数据库名称(&N):";
            this.hisDBNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hisDBPwd
            // 
            this.hisDBPwd.Location = new System.Drawing.Point(115, 190);
            this.hisDBPwd.MaxLength = 50;
            this.hisDBPwd.Name = "hisDBPwd";
            this.hisDBPwd.PasswordChar = '●';
            this.hisDBPwd.Size = new System.Drawing.Size(200, 23);
            this.hisDBPwd.TabIndex = 12;
            // 
            // hisDBPwdLbl
            // 
            this.hisDBPwdLbl.Location = new System.Drawing.Point(10, 190);
            this.hisDBPwdLbl.Name = "hisDBPwdLbl";
            this.hisDBPwdLbl.Size = new System.Drawing.Size(100, 25);
            this.hisDBPwdLbl.TabIndex = 11;
            this.hisDBPwdLbl.Text = "密码(&P):";
            this.hisDBPwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hisDBUser
            // 
            this.hisDBUser.Location = new System.Drawing.Point(115, 155);
            this.hisDBUser.MaxLength = 50;
            this.hisDBUser.Name = "hisDBUser";
            this.hisDBUser.Size = new System.Drawing.Size(200, 23);
            this.hisDBUser.TabIndex = 10;
            // 
            // hisDBUserLbl
            // 
            this.hisDBUserLbl.Location = new System.Drawing.Point(10, 155);
            this.hisDBUserLbl.Name = "hisDBUserLbl";
            this.hisDBUserLbl.Size = new System.Drawing.Size(100, 25);
            this.hisDBUserLbl.TabIndex = 9;
            this.hisDBUserLbl.Text = "登录名(&U):";
            this.hisDBUserLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hisDBType
            // 
            this.hisDBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hisDBType.Location = new System.Drawing.Point(115, 15);
            this.hisDBType.Name = "hisDBType";
            this.hisDBType.Size = new System.Drawing.Size(200, 25);
            this.hisDBType.TabIndex = 1;
            // 
            // hisDBServerLbl
            // 
            this.hisDBServerLbl.Location = new System.Drawing.Point(10, 50);
            this.hisDBServerLbl.Name = "hisDBServerLbl";
            this.hisDBServerLbl.Size = new System.Drawing.Size(100, 25);
            this.hisDBServerLbl.TabIndex = 3;
            this.hisDBServerLbl.Text = "数据库地址(&I):";
            this.hisDBServerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hisDBServer
            // 
            this.hisDBServer.Location = new System.Drawing.Point(115, 50);
            this.hisDBServer.MaxLength = 500;
            this.hisDBServer.Name = "hisDBServer";
            this.hisDBServer.Size = new System.Drawing.Size(200, 23);
            this.hisDBServer.TabIndex = 4;
            // 
            // hisDBTypeLbl
            // 
            this.hisDBTypeLbl.Location = new System.Drawing.Point(10, 15);
            this.hisDBTypeLbl.Name = "hisDBTypeLbl";
            this.hisDBTypeLbl.Size = new System.Drawing.Size(100, 25);
            this.hisDBTypeLbl.TabIndex = 1;
            this.hisDBTypeLbl.Text = "数据库类型(&T):";
            this.hisDBTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // interfaceSetting
            // 
            this.interfaceSetting.Controls.Add(this.interfaceSyncTime);
            this.interfaceSetting.Controls.Add(this.interfaceInterrupt);
            this.interfaceSetting.Controls.Add(this.interfaceDetect);
            this.interfaceSetting.Controls.Add(this.interfaceSyncTimeLbl);
            this.interfaceSetting.Controls.Add(this.interfaceInterruptLbl);
            this.interfaceSetting.Controls.Add(this.interfaceDetectLbl);
            this.interfaceSetting.Controls.Add(this.interfacePort);
            this.interfaceSetting.Controls.Add(this.interfacePortLbl);
            this.interfaceSetting.Controls.Add(this.interfacePwd);
            this.interfaceSetting.Controls.Add(this.interfacePwdLbl);
            this.interfaceSetting.Controls.Add(this.interfaceUser);
            this.interfaceSetting.Controls.Add(this.interfaceUserLbl);
            this.interfaceSetting.Controls.Add(this.interfaceServerLbl);
            this.interfaceSetting.Controls.Add(this.interfaceServer);
            this.interfaceSetting.Location = new System.Drawing.Point(4, 26);
            this.interfaceSetting.Name = "interfaceSetting";
            this.interfaceSetting.Size = new System.Drawing.Size(327, 260);
            this.interfaceSetting.TabIndex = 2;
            this.interfaceSetting.Text = "接口配置";
            this.interfaceSetting.UseVisualStyleBackColor = true;
            // 
            // interfaceSyncTime
            // 
            this.interfaceSyncTime.AutoSize = true;
            this.interfaceSyncTime.Location = new System.Drawing.Point(115, 229);
            this.interfaceSyncTime.Name = "interfaceSyncTime";
            this.interfaceSyncTime.Size = new System.Drawing.Size(51, 21);
            this.interfaceSyncTime.TabIndex = 14;
            this.interfaceSyncTime.Text = "启用";
            this.interfaceSyncTime.UseVisualStyleBackColor = true;
            // 
            // interfaceInterrupt
            // 
            this.interfaceInterrupt.Location = new System.Drawing.Point(115, 190);
            this.interfaceInterrupt.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.interfaceInterrupt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.interfaceInterrupt.Name = "interfaceInterrupt";
            this.interfaceInterrupt.Size = new System.Drawing.Size(200, 23);
            this.interfaceInterrupt.TabIndex = 12;
            this.interfaceInterrupt.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // interfaceDetect
            // 
            this.interfaceDetect.Location = new System.Drawing.Point(115, 155);
            this.interfaceDetect.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.interfaceDetect.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.interfaceDetect.Name = "interfaceDetect";
            this.interfaceDetect.Size = new System.Drawing.Size(200, 23);
            this.interfaceDetect.TabIndex = 10;
            this.interfaceDetect.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // interfaceSyncTimeLbl
            // 
            this.interfaceSyncTimeLbl.Location = new System.Drawing.Point(10, 225);
            this.interfaceSyncTimeLbl.Name = "interfaceSyncTimeLbl";
            this.interfaceSyncTimeLbl.Size = new System.Drawing.Size(100, 25);
            this.interfaceSyncTimeLbl.TabIndex = 13;
            this.interfaceSyncTimeLbl.Text = "时间同步(&Y):";
            this.interfaceSyncTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // interfaceInterruptLbl
            // 
            this.interfaceInterruptLbl.Location = new System.Drawing.Point(10, 190);
            this.interfaceInterruptLbl.Name = "interfaceInterruptLbl";
            this.interfaceInterruptLbl.Size = new System.Drawing.Size(100, 25);
            this.interfaceInterruptLbl.TabIndex = 11;
            this.interfaceInterruptLbl.Text = "中断延迟(秒)(&E):";
            this.interfaceInterruptLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // interfaceDetectLbl
            // 
            this.interfaceDetectLbl.Location = new System.Drawing.Point(10, 155);
            this.interfaceDetectLbl.Name = "interfaceDetectLbl";
            this.interfaceDetectLbl.Size = new System.Drawing.Size(100, 25);
            this.interfaceDetectLbl.TabIndex = 9;
            this.interfaceDetectLbl.Text = "检测延迟(秒)(&H):";
            this.interfaceDetectLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // interfacePort
            // 
            this.interfacePort.Location = new System.Drawing.Point(115, 50);
            this.interfacePort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.interfacePort.Name = "interfacePort";
            this.interfacePort.Size = new System.Drawing.Size(200, 23);
            this.interfacePort.TabIndex = 4;
            // 
            // interfacePortLbl
            // 
            this.interfacePortLbl.Location = new System.Drawing.Point(10, 50);
            this.interfacePortLbl.Name = "interfacePortLbl";
            this.interfacePortLbl.Size = new System.Drawing.Size(100, 25);
            this.interfacePortLbl.TabIndex = 3;
            this.interfacePortLbl.Text = "通信端口(&P):";
            this.interfacePortLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // interfacePwd
            // 
            this.interfacePwd.Location = new System.Drawing.Point(115, 120);
            this.interfacePwd.MaxLength = 50;
            this.interfacePwd.Name = "interfacePwd";
            this.interfacePwd.PasswordChar = '●';
            this.interfacePwd.Size = new System.Drawing.Size(200, 23);
            this.interfacePwd.TabIndex = 8;
            // 
            // interfacePwdLbl
            // 
            this.interfacePwdLbl.Location = new System.Drawing.Point(10, 120);
            this.interfacePwdLbl.Name = "interfacePwdLbl";
            this.interfacePwdLbl.Size = new System.Drawing.Size(100, 25);
            this.interfacePwdLbl.TabIndex = 7;
            this.interfacePwdLbl.Text = "登录密码(&N):";
            this.interfacePwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // interfaceUser
            // 
            this.interfaceUser.Location = new System.Drawing.Point(115, 85);
            this.interfaceUser.MaxLength = 50;
            this.interfaceUser.Name = "interfaceUser";
            this.interfaceUser.Size = new System.Drawing.Size(200, 23);
            this.interfaceUser.TabIndex = 6;
            // 
            // interfaceUserLbl
            // 
            this.interfaceUserLbl.Location = new System.Drawing.Point(10, 85);
            this.interfaceUserLbl.Name = "interfaceUserLbl";
            this.interfaceUserLbl.Size = new System.Drawing.Size(100, 25);
            this.interfaceUserLbl.TabIndex = 5;
            this.interfaceUserLbl.Text = "登录账户(&U):";
            this.interfaceUserLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // interfaceServerLbl
            // 
            this.interfaceServerLbl.Location = new System.Drawing.Point(10, 15);
            this.interfaceServerLbl.Name = "interfaceServerLbl";
            this.interfaceServerLbl.Size = new System.Drawing.Size(100, 25);
            this.interfaceServerLbl.TabIndex = 1;
            this.interfaceServerLbl.Text = "通信地址(&I):";
            this.interfaceServerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // interfaceServer
            // 
            this.interfaceServer.Location = new System.Drawing.Point(115, 15);
            this.interfaceServer.MaxLength = 500;
            this.interfaceServer.Name = "interfaceServer";
            this.interfaceServer.Size = new System.Drawing.Size(200, 23);
            this.interfaceServer.TabIndex = 2;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(270, 307);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 25);
            this.CancelBtn.TabIndex = 18;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(189, 307);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 25);
            this.OKBtn.TabIndex = 17;
            this.OKBtn.Text = "保存(&S)";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(10, 307);
            this.TestBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(90, 25);
            this.TestBtn.TabIndex = 16;
            this.TestBtn.Text = "测试连接(&D)";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // ParamForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(354, 342);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.paramTab);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ParamForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "系统参数";
            this.Activated += new System.EventHandler(this.ParamForm_Activated);
            this.Deactivate += new System.EventHandler(this.ParamForm_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParamForm_FormClosed);
            this.Load += new System.EventHandler(this.ParamForm_Load);
            this.LocationChanged += new System.EventHandler(this.ParamForm_LocationChanged);
            this.paramTab.ResumeLayout(false);
            this.masterDBSetting.ResumeLayout(false);
            this.masterDBSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterDBPort)).EndInit();
            this.hisDBSetting.ResumeLayout(false);
            this.hisDBSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hisDBPort)).EndInit();
            this.interfaceSetting.ResumeLayout(false);
            this.interfaceSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.interfaceInterrupt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interfaceDetect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interfacePort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl paramTab;
        private System.Windows.Forms.TabPage masterDBSetting;
        private System.Windows.Forms.TabPage hisDBSetting;
        private System.Windows.Forms.TabPage interfaceSetting;
        private System.Windows.Forms.NumericUpDown masterDBPort;
        private System.Windows.Forms.Label masterDBPortLbl;
        private System.Windows.Forms.TextBox masterDBName;
        private System.Windows.Forms.Label masterDBNameLbl;
        private System.Windows.Forms.TextBox masterDBPwd;
        private System.Windows.Forms.Label masterDBPwdLbl;
        private System.Windows.Forms.TextBox masterDBUser;
        private System.Windows.Forms.Label masterDBUserLbl;
        private System.Windows.Forms.ComboBox masterDBType;
        private System.Windows.Forms.Label DSServerLbl;
        private System.Windows.Forms.TextBox masterDBServer;
        private System.Windows.Forms.Label masterDBTypeLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button TestBtn;
        private System.Windows.Forms.CheckBox interfaceSyncTime;
        private System.Windows.Forms.NumericUpDown interfaceInterrupt;
        private System.Windows.Forms.NumericUpDown interfaceDetect;
        private System.Windows.Forms.Label interfaceSyncTimeLbl;
        private System.Windows.Forms.Label interfaceInterruptLbl;
        private System.Windows.Forms.Label interfaceDetectLbl;
        private System.Windows.Forms.NumericUpDown interfacePort;
        private System.Windows.Forms.Label interfacePortLbl;
        private System.Windows.Forms.TextBox interfacePwd;
        private System.Windows.Forms.Label interfacePwdLbl;
        private System.Windows.Forms.TextBox interfaceUser;
        private System.Windows.Forms.Label interfaceUserLbl;
        private System.Windows.Forms.Label interfaceServerLbl;
        private System.Windows.Forms.TextBox interfaceServer;
        private System.Windows.Forms.NumericUpDown hisDBPort;
        private System.Windows.Forms.Label hisDBPortLbl;
        private System.Windows.Forms.TextBox hisDBName;
        private System.Windows.Forms.Label hisDBNameLbl;
        private System.Windows.Forms.TextBox hisDBPwd;
        private System.Windows.Forms.Label hisDBPwdLbl;
        private System.Windows.Forms.TextBox hisDBUser;
        private System.Windows.Forms.Label hisDBUserLbl;
        private System.Windows.Forms.ComboBox hisDBType;
        private System.Windows.Forms.Label hisDBServerLbl;
        private System.Windows.Forms.TextBox hisDBServer;
        private System.Windows.Forms.Label hisDBTypeLbl;
    }
}