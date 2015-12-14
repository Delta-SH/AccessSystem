namespace Delta.MPS.AccessSystem
{
    partial class SaveUserForm
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
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lineLbl = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.UserTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UserCommentTB = new System.Windows.Forms.TextBox();
            this.UserCommentLbl = new System.Windows.Forms.Label();
            this.UserEmailTB = new System.Windows.Forms.TextBox();
            this.UserMobileTB = new System.Windows.Forms.TextBox();
            this.UserEmailLbl = new System.Windows.Forms.Label();
            this.UserMobileLbl = new System.Windows.Forms.Label();
            this.UserCPasswordTB = new System.Windows.Forms.TextBox();
            this.UserPasswordTB = new System.Windows.Forms.TextBox();
            this.UserCPasswordLbl = new System.Windows.Forms.Label();
            this.UserRemarkNameTB = new System.Windows.Forms.TextBox();
            this.UserRemarkNameLbl = new System.Windows.Forms.Label();
            this.UserRoleLbl = new System.Windows.Forms.Label();
            this.UserNameTB = new System.Windows.Forms.TextBox();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.UserIDLbl = new System.Windows.Forms.Label();
            this.UserIDTB = new System.Windows.Forms.TextBox();
            this.UserRoleCB = new System.Windows.Forms.ComboBox();
            this.BehaviorPanel = new System.Windows.Forms.Panel();
            this.UserPasswordCB = new System.Windows.Forms.CheckBox();
            this.UserPasswordLbl = new System.Windows.Forms.Label();
            this.UserLimitLbl = new System.Windows.Forms.Label();
            this.UserLimitDTP = new System.Windows.Forms.DateTimePicker();
            this.NeverCB = new System.Windows.Forms.CheckBox();
            this.UserStatusCB = new System.Windows.Forms.CheckBox();
            this.MainTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.UserTableLayoutPanel.SuspendLayout();
            this.BehaviorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.lineLbl, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.UserTableLayoutPanel, 0, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 3;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(584, 362);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainTableLayoutPanel.SetColumnSpan(this.lineLbl, 5);
            this.lineLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lineLbl.Location = new System.Drawing.Point(10, 310);
            this.lineLbl.Margin = new System.Windows.Forms.Padding(0);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(564, 2);
            this.lineLbl.TabIndex = 22;
            // 
            // BottomPanel
            // 
            this.MainTableLayoutPanel.SetColumnSpan(this.BottomPanel, 5);
            this.BottomPanel.Controls.Add(this.SaveBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 312);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(564, 50);
            this.BottomPanel.TabIndex = 2;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SaveBtn.Location = new System.Drawing.Point(376, 10);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(90, 30);
            this.SaveBtn.TabIndex = 23;
            this.SaveBtn.Text = "保存(&S)";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(475, 10);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 24;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // UserTableLayoutPanel
            // 
            this.UserTableLayoutPanel.ColumnCount = 5;
            this.UserTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.UserTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UserTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.UserTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.UserTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UserTableLayoutPanel.Controls.Add(this.UserCommentTB, 1, 10);
            this.UserTableLayoutPanel.Controls.Add(this.UserCommentLbl, 0, 10);
            this.UserTableLayoutPanel.Controls.Add(this.UserEmailTB, 4, 6);
            this.UserTableLayoutPanel.Controls.Add(this.UserMobileTB, 1, 6);
            this.UserTableLayoutPanel.Controls.Add(this.UserEmailLbl, 3, 6);
            this.UserTableLayoutPanel.Controls.Add(this.UserMobileLbl, 0, 6);
            this.UserTableLayoutPanel.Controls.Add(this.UserCPasswordTB, 4, 4);
            this.UserTableLayoutPanel.Controls.Add(this.UserPasswordTB, 1, 4);
            this.UserTableLayoutPanel.Controls.Add(this.UserCPasswordLbl, 3, 4);
            this.UserTableLayoutPanel.Controls.Add(this.UserRemarkNameTB, 4, 2);
            this.UserTableLayoutPanel.Controls.Add(this.UserRemarkNameLbl, 3, 2);
            this.UserTableLayoutPanel.Controls.Add(this.UserRoleLbl, 0, 2);
            this.UserTableLayoutPanel.Controls.Add(this.UserNameTB, 4, 0);
            this.UserTableLayoutPanel.Controls.Add(this.UserNameLbl, 3, 0);
            this.UserTableLayoutPanel.Controls.Add(this.UserIDLbl, 0, 0);
            this.UserTableLayoutPanel.Controls.Add(this.UserIDTB, 1, 0);
            this.UserTableLayoutPanel.Controls.Add(this.UserRoleCB, 1, 2);
            this.UserTableLayoutPanel.Controls.Add(this.BehaviorPanel, 0, 4);
            this.UserTableLayoutPanel.Controls.Add(this.UserLimitLbl, 0, 8);
            this.UserTableLayoutPanel.Controls.Add(this.UserLimitDTP, 1, 8);
            this.UserTableLayoutPanel.Controls.Add(this.NeverCB, 3, 8);
            this.UserTableLayoutPanel.Controls.Add(this.UserStatusCB, 3, 10);
            this.UserTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserTableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this.UserTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UserTableLayoutPanel.Name = "UserTableLayoutPanel";
            this.UserTableLayoutPanel.RowCount = 11;
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.UserTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.UserTableLayoutPanel.Size = new System.Drawing.Size(564, 287);
            this.UserTableLayoutPanel.TabIndex = 1;
            // 
            // UserCommentTB
            // 
            this.UserCommentTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserCommentTB.Location = new System.Drawing.Point(100, 175);
            this.UserCommentTB.Margin = new System.Windows.Forms.Padding(0);
            this.UserCommentTB.Multiline = true;
            this.UserCommentTB.Name = "UserCommentTB";
            this.UserCommentTB.Size = new System.Drawing.Size(172, 112);
            this.UserCommentTB.TabIndex = 21;
            // 
            // UserCommentLbl
            // 
            this.UserCommentLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserCommentLbl.Location = new System.Drawing.Point(3, 175);
            this.UserCommentLbl.Name = "UserCommentLbl";
            this.UserCommentLbl.Size = new System.Drawing.Size(94, 25);
            this.UserCommentLbl.TabIndex = 20;
            this.UserCommentLbl.Text = "描      述(&D):";
            this.UserCommentLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserEmailTB
            // 
            this.UserEmailTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserEmailTB.Location = new System.Drawing.Point(392, 107);
            this.UserEmailTB.Margin = new System.Windows.Forms.Padding(0);
            this.UserEmailTB.MaxLength = 50;
            this.UserEmailTB.Name = "UserEmailTB";
            this.UserEmailTB.Size = new System.Drawing.Size(172, 23);
            this.UserEmailTB.TabIndex = 16;
            // 
            // UserMobileTB
            // 
            this.UserMobileTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserMobileTB.Location = new System.Drawing.Point(100, 107);
            this.UserMobileTB.Margin = new System.Windows.Forms.Padding(0);
            this.UserMobileTB.MaxLength = 20;
            this.UserMobileTB.Name = "UserMobileTB";
            this.UserMobileTB.Size = new System.Drawing.Size(172, 23);
            this.UserMobileTB.TabIndex = 14;
            // 
            // UserEmailLbl
            // 
            this.UserEmailLbl.Location = new System.Drawing.Point(295, 105);
            this.UserEmailLbl.Name = "UserEmailLbl";
            this.UserEmailLbl.Size = new System.Drawing.Size(94, 25);
            this.UserEmailLbl.TabIndex = 15;
            this.UserEmailLbl.Text = "Email(&E):";
            this.UserEmailLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserMobileLbl
            // 
            this.UserMobileLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserMobileLbl.Location = new System.Drawing.Point(3, 105);
            this.UserMobileLbl.Name = "UserMobileLbl";
            this.UserMobileLbl.Size = new System.Drawing.Size(94, 25);
            this.UserMobileLbl.TabIndex = 13;
            this.UserMobileLbl.Text = "联系电话(&M):";
            this.UserMobileLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserCPasswordTB
            // 
            this.UserCPasswordTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserCPasswordTB.Location = new System.Drawing.Point(392, 72);
            this.UserCPasswordTB.Margin = new System.Windows.Forms.Padding(0);
            this.UserCPasswordTB.MaxLength = 50;
            this.UserCPasswordTB.Name = "UserCPasswordTB";
            this.UserCPasswordTB.PasswordChar = '●';
            this.UserCPasswordTB.Size = new System.Drawing.Size(172, 23);
            this.UserCPasswordTB.TabIndex = 12;
            // 
            // UserPasswordTB
            // 
            this.UserPasswordTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserPasswordTB.Location = new System.Drawing.Point(100, 72);
            this.UserPasswordTB.Margin = new System.Windows.Forms.Padding(0);
            this.UserPasswordTB.MaxLength = 50;
            this.UserPasswordTB.Name = "UserPasswordTB";
            this.UserPasswordTB.PasswordChar = '●';
            this.UserPasswordTB.Size = new System.Drawing.Size(172, 23);
            this.UserPasswordTB.TabIndex = 10;
            // 
            // UserCPasswordLbl
            // 
            this.UserCPasswordLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserCPasswordLbl.Location = new System.Drawing.Point(295, 70);
            this.UserCPasswordLbl.Name = "UserCPasswordLbl";
            this.UserCPasswordLbl.Size = new System.Drawing.Size(94, 25);
            this.UserCPasswordLbl.TabIndex = 11;
            this.UserCPasswordLbl.Text = "确认密码(&F):";
            this.UserCPasswordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserRemarkNameTB
            // 
            this.UserRemarkNameTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserRemarkNameTB.Location = new System.Drawing.Point(392, 37);
            this.UserRemarkNameTB.Margin = new System.Windows.Forms.Padding(0);
            this.UserRemarkNameTB.MaxLength = 50;
            this.UserRemarkNameTB.Name = "UserRemarkNameTB";
            this.UserRemarkNameTB.Size = new System.Drawing.Size(172, 23);
            this.UserRemarkNameTB.TabIndex = 8;
            // 
            // UserRemarkNameLbl
            // 
            this.UserRemarkNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRemarkNameLbl.Location = new System.Drawing.Point(295, 35);
            this.UserRemarkNameLbl.Name = "UserRemarkNameLbl";
            this.UserRemarkNameLbl.Size = new System.Drawing.Size(94, 25);
            this.UserRemarkNameLbl.TabIndex = 7;
            this.UserRemarkNameLbl.Text = "备注名称(&K):";
            this.UserRemarkNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserRoleLbl
            // 
            this.UserRoleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRoleLbl.Location = new System.Drawing.Point(3, 35);
            this.UserRoleLbl.Name = "UserRoleLbl";
            this.UserRoleLbl.Size = new System.Drawing.Size(94, 25);
            this.UserRoleLbl.TabIndex = 5;
            this.UserRoleLbl.Text = "所属角色(&R):";
            this.UserRoleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserNameTB
            // 
            this.UserNameTB.BackColor = System.Drawing.Color.White;
            this.UserNameTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserNameTB.Location = new System.Drawing.Point(392, 2);
            this.UserNameTB.Margin = new System.Windows.Forms.Padding(0);
            this.UserNameTB.MaxLength = 50;
            this.UserNameTB.Name = "UserNameTB";
            this.UserNameTB.Size = new System.Drawing.Size(172, 23);
            this.UserNameTB.TabIndex = 4;
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserNameLbl.Location = new System.Drawing.Point(295, 0);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(94, 25);
            this.UserNameLbl.TabIndex = 3;
            this.UserNameLbl.Text = "用户名称(&N):";
            this.UserNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserIDLbl
            // 
            this.UserIDLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserIDLbl.Location = new System.Drawing.Point(3, 0);
            this.UserIDLbl.Name = "UserIDLbl";
            this.UserIDLbl.Size = new System.Drawing.Size(94, 25);
            this.UserIDLbl.TabIndex = 1;
            this.UserIDLbl.Text = "用户标识(&I):";
            this.UserIDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserIDTB
            // 
            this.UserIDTB.BackColor = System.Drawing.Color.White;
            this.UserIDTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserIDTB.Location = new System.Drawing.Point(100, 2);
            this.UserIDTB.Margin = new System.Windows.Forms.Padding(0);
            this.UserIDTB.MaxLength = 50;
            this.UserIDTB.Name = "UserIDTB";
            this.UserIDTB.ReadOnly = true;
            this.UserIDTB.Size = new System.Drawing.Size(172, 23);
            this.UserIDTB.TabIndex = 2;
            // 
            // UserRoleCB
            // 
            this.UserRoleCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserRoleCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserRoleCB.FormattingEnabled = true;
            this.UserRoleCB.Location = new System.Drawing.Point(100, 35);
            this.UserRoleCB.Margin = new System.Windows.Forms.Padding(0);
            this.UserRoleCB.Name = "UserRoleCB";
            this.UserRoleCB.Size = new System.Drawing.Size(172, 25);
            this.UserRoleCB.TabIndex = 6;
            // 
            // BehaviorPanel
            // 
            this.BehaviorPanel.Controls.Add(this.UserPasswordCB);
            this.BehaviorPanel.Controls.Add(this.UserPasswordLbl);
            this.BehaviorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BehaviorPanel.Location = new System.Drawing.Point(0, 70);
            this.BehaviorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BehaviorPanel.Name = "BehaviorPanel";
            this.BehaviorPanel.Size = new System.Drawing.Size(100, 25);
            this.BehaviorPanel.TabIndex = 0;
            // 
            // UserPasswordCB
            // 
            this.UserPasswordCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPasswordCB.Location = new System.Drawing.Point(0, 0);
            this.UserPasswordCB.Margin = new System.Windows.Forms.Padding(0);
            this.UserPasswordCB.Name = "UserPasswordCB";
            this.UserPasswordCB.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UserPasswordCB.Size = new System.Drawing.Size(100, 25);
            this.UserPasswordCB.TabIndex = 9;
            this.UserPasswordCB.Text = "重置密码(&P):";
            this.UserPasswordCB.UseVisualStyleBackColor = true;
            this.UserPasswordCB.CheckedChanged += new System.EventHandler(this.UserPasswordCB_CheckedChanged);
            // 
            // UserPasswordLbl
            // 
            this.UserPasswordLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPasswordLbl.Location = new System.Drawing.Point(0, 0);
            this.UserPasswordLbl.Name = "UserPasswordLbl";
            this.UserPasswordLbl.Size = new System.Drawing.Size(100, 25);
            this.UserPasswordLbl.TabIndex = 10;
            this.UserPasswordLbl.Text = "密      码(&P):";
            this.UserPasswordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserLimitLbl
            // 
            this.UserLimitLbl.Location = new System.Drawing.Point(3, 140);
            this.UserLimitLbl.Name = "UserLimitLbl";
            this.UserLimitLbl.Size = new System.Drawing.Size(94, 25);
            this.UserLimitLbl.TabIndex = 17;
            this.UserLimitLbl.Text = "有效日期(&X):";
            this.UserLimitLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserLimitDTP
            // 
            this.UserLimitDTP.CustomFormat = "yyyy/MM/dd";
            this.UserLimitDTP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserLimitDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.UserLimitDTP.Location = new System.Drawing.Point(100, 142);
            this.UserLimitDTP.Margin = new System.Windows.Forms.Padding(0);
            this.UserLimitDTP.Name = "UserLimitDTP";
            this.UserLimitDTP.Size = new System.Drawing.Size(172, 23);
            this.UserLimitDTP.TabIndex = 18;
            this.UserLimitDTP.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // NeverCB
            // 
            this.NeverCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NeverCB.Location = new System.Drawing.Point(292, 140);
            this.NeverCB.Margin = new System.Windows.Forms.Padding(0);
            this.NeverCB.Name = "NeverCB";
            this.NeverCB.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.NeverCB.Size = new System.Drawing.Size(100, 25);
            this.NeverCB.TabIndex = 19;
            this.NeverCB.Text = "永不过期(&V)";
            this.NeverCB.UseVisualStyleBackColor = true;
            this.NeverCB.CheckedChanged += new System.EventHandler(this.NeverCB_CheckedChanged);
            // 
            // UserStatusCB
            // 
            this.UserStatusCB.Dock = System.Windows.Forms.DockStyle.Top;
            this.UserStatusCB.Location = new System.Drawing.Point(292, 175);
            this.UserStatusCB.Margin = new System.Windows.Forms.Padding(0);
            this.UserStatusCB.Name = "UserStatusCB";
            this.UserStatusCB.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UserStatusCB.Size = new System.Drawing.Size(100, 25);
            this.UserStatusCB.TabIndex = 22;
            this.UserStatusCB.Text = "启用用户(&Y)";
            this.UserStatusCB.UseVisualStyleBackColor = true;
            // 
            // SaveUserForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 360);
            this.Name = "SaveUserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Shown += new System.EventHandler(this.SaveUserForm_Shown);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.UserTableLayoutPanel.ResumeLayout(false);
            this.UserTableLayoutPanel.PerformLayout();
            this.BehaviorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel UserTableLayoutPanel;
        private System.Windows.Forms.TextBox UserCommentTB;
        private System.Windows.Forms.Label UserCommentLbl;
        private System.Windows.Forms.TextBox UserEmailTB;
        private System.Windows.Forms.TextBox UserMobileTB;
        private System.Windows.Forms.Label UserEmailLbl;
        private System.Windows.Forms.Label UserMobileLbl;
        private System.Windows.Forms.TextBox UserCPasswordTB;
        private System.Windows.Forms.TextBox UserPasswordTB;
        private System.Windows.Forms.Label UserCPasswordLbl;
        private System.Windows.Forms.TextBox UserRemarkNameTB;
        private System.Windows.Forms.Label UserRemarkNameLbl;
        private System.Windows.Forms.Label UserRoleLbl;
        private System.Windows.Forms.TextBox UserNameTB;
        private System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.Label UserIDLbl;
        private System.Windows.Forms.TextBox UserIDTB;
        private System.Windows.Forms.ComboBox UserRoleCB;
        private System.Windows.Forms.CheckBox UserStatusCB;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Panel BehaviorPanel;
        private System.Windows.Forms.Label UserPasswordLbl;
        private System.Windows.Forms.CheckBox UserPasswordCB;
        private System.Windows.Forms.Label UserLimitLbl;
        private System.Windows.Forms.DateTimePicker UserLimitDTP;
        private System.Windows.Forms.CheckBox NeverCB;


    }
}