namespace Delta.MPS.AccessSystem
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.topPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.optionBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.lineLbl = new System.Windows.Forms.Label();
            this.remeberCK = new System.Windows.Forms.CheckBox();
            this.codeImage = new System.Windows.Forms.PictureBox();
            this.codeTxtBox = new System.Windows.Forms.TextBox();
            this.pwdTxtBox = new System.Windows.Forms.TextBox();
            this.userTxtCombo = new System.Windows.Forms.ComboBox();
            this.codeLbl = new System.Windows.Forms.Label();
            this.pwdLbl = new System.Windows.Forms.Label();
            this.userLbl = new System.Windows.Forms.Label();
            this.msgTip = new System.Windows.Forms.ToolTip(this.components);
            this.loginPanel = new System.Windows.Forms.Panel();
            this.languageLbl = new System.Windows.Forms.Label();
            this.LanguageCombo = new System.Windows.Forms.ComboBox();
            this.tipLbl = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeImage)).BeginInit();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.BackgroundImage = global::Delta.MPS.AccessSystem.Properties.Resources.title;
            this.topPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.topPanel.Controls.Add(this.logoPanel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(404, 70);
            this.topPanel.TabIndex = 0;
            // 
            // logoPanel
            // 
            this.logoPanel.BackgroundImage = global::Delta.MPS.AccessSystem.Properties.Resources.logo;
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(404, 70);
            this.logoPanel.TabIndex = 0;
            // 
            // optionBtn
            // 
            this.optionBtn.Location = new System.Drawing.Point(302, 305);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(90, 25);
            this.optionBtn.TabIndex = 12;
            this.optionBtn.Text = "选项(&O) >>";
            this.optionBtn.UseVisualStyleBackColor = true;
            this.optionBtn.Click += new System.EventHandler(this.optionBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(221, 305);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 25);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "取消(&C)";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(140, 305);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 25);
            this.loginBtn.TabIndex = 10;
            this.loginBtn.Text = "登录(&L)";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineLbl.Location = new System.Drawing.Point(12, 290);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(380, 2);
            this.lineLbl.TabIndex = 0;
            // 
            // remeberCK
            // 
            this.remeberCK.AutoSize = true;
            this.remeberCK.BackColor = System.Drawing.Color.Transparent;
            this.remeberCK.Location = new System.Drawing.Point(140, 175);
            this.remeberCK.Name = "remeberCK";
            this.remeberCK.Size = new System.Drawing.Size(95, 21);
            this.remeberCK.TabIndex = 9;
            this.remeberCK.Text = "记住密码(&M)";
            this.remeberCK.UseVisualStyleBackColor = false;
            // 
            // codeImage
            // 
            this.codeImage.BackColor = System.Drawing.Color.Transparent;
            this.codeImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.codeImage.Location = new System.Drawing.Point(280, 100);
            this.codeImage.Name = "codeImage";
            this.codeImage.Size = new System.Drawing.Size(80, 25);
            this.codeImage.TabIndex = 14;
            this.codeImage.TabStop = false;
            this.msgTip.SetToolTip(this.codeImage, "看不清，点击换一张");
            this.codeImage.Click += new System.EventHandler(this.codeImage_Click);
            // 
            // codeTxtBox
            // 
            this.codeTxtBox.Location = new System.Drawing.Point(140, 100);
            this.codeTxtBox.MaxLength = 10;
            this.codeTxtBox.Name = "codeTxtBox";
            this.codeTxtBox.Size = new System.Drawing.Size(120, 23);
            this.codeTxtBox.TabIndex = 6;
            // 
            // pwdTxtBox
            // 
            this.pwdTxtBox.Location = new System.Drawing.Point(140, 60);
            this.pwdTxtBox.MaxLength = 50;
            this.pwdTxtBox.Name = "pwdTxtBox";
            this.pwdTxtBox.PasswordChar = '●';
            this.pwdTxtBox.Size = new System.Drawing.Size(220, 23);
            this.pwdTxtBox.TabIndex = 4;
            // 
            // userTxtCombo
            // 
            this.userTxtCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.userTxtCombo.IntegralHeight = false;
            this.userTxtCombo.Location = new System.Drawing.Point(140, 20);
            this.userTxtCombo.Name = "userTxtCombo";
            this.userTxtCombo.Size = new System.Drawing.Size(220, 25);
            this.userTxtCombo.TabIndex = 2;
            this.userTxtCombo.SelectedValueChanged += new System.EventHandler(this.userTxtCombo_SelectedValueChanged);
            this.userTxtCombo.TextChanged += new System.EventHandler(this.userTxtCombo_TextChanged);
            // 
            // codeLbl
            // 
            this.codeLbl.Location = new System.Drawing.Point(45, 100);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(80, 25);
            this.codeLbl.TabIndex = 5;
            this.codeLbl.Text = "验证码(&A)";
            this.codeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pwdLbl
            // 
            this.pwdLbl.Location = new System.Drawing.Point(45, 60);
            this.pwdLbl.Name = "pwdLbl";
            this.pwdLbl.Size = new System.Drawing.Size(80, 25);
            this.pwdLbl.TabIndex = 3;
            this.pwdLbl.Text = "密  码(&P)";
            this.pwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userLbl
            // 
            this.userLbl.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.userLbl.Location = new System.Drawing.Point(45, 20);
            this.userLbl.Name = "userLbl";
            this.userLbl.Size = new System.Drawing.Size(80, 25);
            this.userLbl.TabIndex = 1;
            this.userLbl.Text = "用户名(&U)";
            this.userLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // msgTip
            // 
            this.msgTip.AutoPopDelay = 10000;
            this.msgTip.InitialDelay = 500;
            this.msgTip.ReshowDelay = 100;
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.languageLbl);
            this.loginPanel.Controls.Add(this.LanguageCombo);
            this.loginPanel.Controls.Add(this.pwdLbl);
            this.loginPanel.Controls.Add(this.userLbl);
            this.loginPanel.Controls.Add(this.codeLbl);
            this.loginPanel.Controls.Add(this.userTxtCombo);
            this.loginPanel.Controls.Add(this.pwdTxtBox);
            this.loginPanel.Controls.Add(this.codeTxtBox);
            this.loginPanel.Controls.Add(this.remeberCK);
            this.loginPanel.Controls.Add(this.codeImage);
            this.loginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginPanel.Location = new System.Drawing.Point(0, 70);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(404, 200);
            this.loginPanel.TabIndex = 0;
            // 
            // languageLbl
            // 
            this.languageLbl.Location = new System.Drawing.Point(45, 140);
            this.languageLbl.Name = "languageLbl";
            this.languageLbl.Size = new System.Drawing.Size(80, 25);
            this.languageLbl.TabIndex = 7;
            this.languageLbl.Text = "语  言(&L)";
            this.languageLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LanguageCombo
            // 
            this.LanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageCombo.IntegralHeight = false;
            this.LanguageCombo.Location = new System.Drawing.Point(140, 140);
            this.LanguageCombo.Name = "LanguageCombo";
            this.LanguageCombo.Size = new System.Drawing.Size(120, 25);
            this.LanguageCombo.TabIndex = 8;
            // 
            // tipLbl
            // 
            this.tipLbl.AutoEllipsis = true;
            this.tipLbl.BackColor = System.Drawing.Color.Transparent;
            this.tipLbl.ForeColor = System.Drawing.Color.Black;
            this.tipLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tipLbl.Location = new System.Drawing.Point(0, 270);
            this.tipLbl.Margin = new System.Windows.Forms.Padding(0);
            this.tipLbl.Name = "tipLbl";
            this.tipLbl.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.tipLbl.Size = new System.Drawing.Size(404, 20);
            this.tipLbl.TabIndex = 0;
            this.tipLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.loginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(404, 342);
            this.Controls.Add(this.lineLbl);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.tipLbl);
            this.Controls.Add(this.optionBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.LocationChanged += new System.EventHandler(this.LoginForm_LocationChanged);
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codeImage)).EndInit();
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Button optionBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.CheckBox remeberCK;
        private System.Windows.Forms.PictureBox codeImage;
        private System.Windows.Forms.TextBox codeTxtBox;
        private System.Windows.Forms.TextBox pwdTxtBox;
        private System.Windows.Forms.ComboBox userTxtCombo;
        private System.Windows.Forms.Label codeLbl;
        private System.Windows.Forms.Label pwdLbl;
        private System.Windows.Forms.Label userLbl;
        private System.Windows.Forms.ToolTip msgTip;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label languageLbl;
        private System.Windows.Forms.ComboBox LanguageCombo;
        private System.Windows.Forms.Label tipLbl;
    }
}