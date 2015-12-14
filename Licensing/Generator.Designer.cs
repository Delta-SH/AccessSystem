namespace Licensing
{
    partial class Generator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generator));
            this.topPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.authCodeBox = new System.Windows.Forms.GroupBox();
            this.neverTimeCK = new System.Windows.Forms.CheckBox();
            this.periodTime = new System.Windows.Forms.DateTimePicker();
            this.email = new System.Windows.Forms.TextBox();
            this.companyName = new System.Windows.Forms.TextBox();
            this.emailLbl = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.companyNameLbl = new System.Windows.Forms.Label();
            this.periodTimeLbl = new System.Windows.Forms.Label();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.authCode = new System.Windows.Forms.TextBox();
            this.machineCode = new System.Windows.Forms.TextBox();
            this.authCodeLbl = new System.Windows.Forms.Label();
            this.machineCodeLbl = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.createFileBtn = new System.Windows.Forms.Button();
            this.authFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.topPanel.SuspendLayout();
            this.authCodeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.BackgroundImage = global::Licensing.Properties.Resources.title;
            this.topPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topPanel.Controls.Add(this.logoPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(404, 70);
            this.topPanel.TabIndex = 1;
            // 
            // logoPanel
            // 
            this.logoPanel.BackgroundImage = global::Licensing.Properties.Resources.logo;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(404, 70);
            this.logoPanel.TabIndex = 0;
            // 
            // authCodeBox
            // 
            this.authCodeBox.Controls.Add(this.neverTimeCK);
            this.authCodeBox.Controls.Add(this.periodTime);
            this.authCodeBox.Controls.Add(this.email);
            this.authCodeBox.Controls.Add(this.companyName);
            this.authCodeBox.Controls.Add(this.emailLbl);
            this.authCodeBox.Controls.Add(this.userName);
            this.authCodeBox.Controls.Add(this.companyNameLbl);
            this.authCodeBox.Controls.Add(this.periodTimeLbl);
            this.authCodeBox.Controls.Add(this.userNameLbl);
            this.authCodeBox.Controls.Add(this.authCode);
            this.authCodeBox.Controls.Add(this.machineCode);
            this.authCodeBox.Controls.Add(this.authCodeLbl);
            this.authCodeBox.Controls.Add(this.machineCodeLbl);
            this.authCodeBox.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.authCodeBox.Location = new System.Drawing.Point(12, 82);
            this.authCodeBox.Name = "authCodeBox";
            this.authCodeBox.Size = new System.Drawing.Size(380, 295);
            this.authCodeBox.TabIndex = 0;
            this.authCodeBox.TabStop = false;
            this.authCodeBox.Text = "注册码生成器";
            // 
            // neverTimeCK
            // 
            this.neverTimeCK.AutoSize = true;
            this.neverTimeCK.Location = new System.Drawing.Point(258, 113);
            this.neverTimeCK.Name = "neverTimeCK";
            this.neverTimeCK.Size = new System.Drawing.Size(99, 17);
            this.neverTimeCK.TabIndex = 9;
            this.neverTimeCK.Text = "永不过期(&N)";
            this.neverTimeCK.UseVisualStyleBackColor = true;
            this.neverTimeCK.CheckedChanged += new System.EventHandler(this.neverTimeCK_CheckedChanged);
            // 
            // periodTime
            // 
            this.periodTime.CustomFormat = "yyyy/MM/dd";
            this.periodTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.periodTime.Location = new System.Drawing.Point(107, 108);
            this.periodTime.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.periodTime.Name = "periodTime";
            this.periodTime.Size = new System.Drawing.Size(140, 22);
            this.periodTime.TabIndex = 8;
            this.periodTime.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.periodTime.ValueChanged += new System.EventHandler(this.DateTime_ValueChanged);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(107, 80);
            this.email.MaxLength = 50;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(250, 22);
            this.email.TabIndex = 6;
            this.email.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // companyName
            // 
            this.companyName.Location = new System.Drawing.Point(107, 52);
            this.companyName.MaxLength = 50;
            this.companyName.Name = "companyName";
            this.companyName.Size = new System.Drawing.Size(250, 22);
            this.companyName.TabIndex = 4;
            this.companyName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // emailLbl
            // 
            this.emailLbl.Location = new System.Drawing.Point(16, 80);
            this.emailLbl.Name = "emailLbl";
            this.emailLbl.Size = new System.Drawing.Size(80, 22);
            this.emailLbl.TabIndex = 5;
            this.emailLbl.Text = "Email(&E)";
            this.emailLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(107, 24);
            this.userName.MaxLength = 50;
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(250, 22);
            this.userName.TabIndex = 2;
            this.userName.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // companyNameLbl
            // 
            this.companyNameLbl.Location = new System.Drawing.Point(16, 52);
            this.companyNameLbl.Name = "companyNameLbl";
            this.companyNameLbl.Size = new System.Drawing.Size(80, 22);
            this.companyNameLbl.TabIndex = 3;
            this.companyNameLbl.Text = "公司名称(&L)";
            this.companyNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // periodTimeLbl
            // 
            this.periodTimeLbl.Location = new System.Drawing.Point(17, 108);
            this.periodTimeLbl.Name = "periodTimeLbl";
            this.periodTimeLbl.Size = new System.Drawing.Size(80, 22);
            this.periodTimeLbl.TabIndex = 7;
            this.periodTimeLbl.Text = "有效期(&P)";
            this.periodTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userNameLbl
            // 
            this.userNameLbl.Location = new System.Drawing.Point(16, 24);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Size = new System.Drawing.Size(80, 22);
            this.userNameLbl.TabIndex = 1;
            this.userNameLbl.Text = "用户名称(&U)";
            this.userNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // authCode
            // 
            this.authCode.Location = new System.Drawing.Point(107, 164);
            this.authCode.MaxLength = 50000;
            this.authCode.Multiline = true;
            this.authCode.Name = "authCode";
            this.authCode.ReadOnly = true;
            this.authCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.authCode.Size = new System.Drawing.Size(250, 120);
            this.authCode.TabIndex = 13;
            this.authCode.TextChanged += new System.EventHandler(this.authCode_TextChanged);
            // 
            // machineCode
            // 
            this.machineCode.Location = new System.Drawing.Point(107, 136);
            this.machineCode.MaxLength = 32;
            this.machineCode.Name = "machineCode";
            this.machineCode.Size = new System.Drawing.Size(250, 22);
            this.machineCode.TabIndex = 11;
            this.machineCode.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // authCodeLbl
            // 
            this.authCodeLbl.Location = new System.Drawing.Point(16, 164);
            this.authCodeLbl.Name = "authCodeLbl";
            this.authCodeLbl.Size = new System.Drawing.Size(80, 22);
            this.authCodeLbl.TabIndex = 12;
            this.authCodeLbl.Text = "注册码(&R)";
            this.authCodeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // machineCodeLbl
            // 
            this.machineCodeLbl.Location = new System.Drawing.Point(16, 136);
            this.machineCodeLbl.Name = "machineCodeLbl";
            this.machineCodeLbl.Size = new System.Drawing.Size(80, 22);
            this.machineCodeLbl.TabIndex = 10;
            this.machineCodeLbl.Text = "机器码(&M)";
            this.machineCodeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(292, 385);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(100, 25);
            this.generateBtn.TabIndex = 16;
            this.generateBtn.Text = "生成注册码(&G)";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Enabled = false;
            this.copyBtn.Location = new System.Drawing.Point(12, 385);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(100, 25);
            this.copyBtn.TabIndex = 14;
            this.copyBtn.Text = "复制注册码(C)";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // createFileBtn
            // 
            this.createFileBtn.Location = new System.Drawing.Point(186, 385);
            this.createFileBtn.Name = "createFileBtn";
            this.createFileBtn.Size = new System.Drawing.Size(100, 25);
            this.createFileBtn.TabIndex = 15;
            this.createFileBtn.Text = "导出授权(&E)";
            this.createFileBtn.UseVisualStyleBackColor = true;
            this.createFileBtn.Click += new System.EventHandler(this.createFileBtn_Click);
            // 
            // authFileDialog
            // 
            this.authFileDialog.DefaultExt = "key";
            this.authFileDialog.FileName = "register.key";
            this.authFileDialog.Filter = "授权文件|*.key|所有文件|*.*";
            this.authFileDialog.Title = "文件另存为";
            // 
            // Generator
            // 
            this.AcceptButton = this.generateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 422);
            this.Controls.Add(this.createFileBtn);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.authCodeBox);
            this.Controls.Add(this.topPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Generator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能门禁管理系统";
            this.Load += new System.EventHandler(this.Generator_Load);
            this.topPanel.ResumeLayout(false);
            this.authCodeBox.ResumeLayout(false);
            this.authCodeBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.GroupBox authCodeBox;
        private System.Windows.Forms.TextBox authCode;
        private System.Windows.Forms.TextBox machineCode;
        private System.Windows.Forms.Label authCodeLbl;
        private System.Windows.Forms.Label machineCodeLbl;
        private System.Windows.Forms.CheckBox neverTimeCK;
        private System.Windows.Forms.DateTimePicker periodTime;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox companyName;
        private System.Windows.Forms.Label emailLbl;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label companyNameLbl;
        private System.Windows.Forms.Label periodTimeLbl;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button createFileBtn;
        private System.Windows.Forms.SaveFileDialog authFileDialog;

    }
}