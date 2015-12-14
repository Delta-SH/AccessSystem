namespace Delta.MPS.AccessSystem
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.copyBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.registerBox = new System.Windows.Forms.GroupBox();
            this.registerCode = new System.Windows.Forms.TextBox();
            this.machineCode = new System.Windows.Forms.TextBox();
            this.registerCodeLbl = new System.Windows.Forms.Label();
            this.machineCodeLbl = new System.Windows.Forms.Label();
            this.registerFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.topPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.tipBox = new System.Windows.Forms.GroupBox();
            this.tipLbl = new System.Windows.Forms.Label();
            this.licenseLbl = new System.Windows.Forms.Label();
            this.registerBox.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.tipBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyBtn
            // 
            this.copyBtn.Enabled = false;
            this.copyBtn.Location = new System.Drawing.Point(10, 405);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(100, 30);
            this.copyBtn.TabIndex = 3;
            this.copyBtn.Text = "复制机器码(&C)";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(294, 405);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(100, 30);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "注册(&O)";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(188, 405);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(100, 30);
            this.exportBtn.TabIndex = 4;
            this.exportBtn.Text = "导入授权(&E)";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // registerBox
            // 
            this.registerBox.Controls.Add(this.registerCode);
            this.registerBox.Controls.Add(this.machineCode);
            this.registerBox.Controls.Add(this.registerCodeLbl);
            this.registerBox.Controls.Add(this.machineCodeLbl);
            this.registerBox.Location = new System.Drawing.Point(10, 195);
            this.registerBox.Name = "registerBox";
            this.registerBox.Size = new System.Drawing.Size(384, 200);
            this.registerBox.TabIndex = 0;
            this.registerBox.TabStop = false;
            // 
            // registerCode
            // 
            this.registerCode.AcceptsReturn = true;
            this.registerCode.AcceptsTab = true;
            this.registerCode.Location = new System.Drawing.Point(90, 65);
            this.registerCode.MaxLength = 50000;
            this.registerCode.Multiline = true;
            this.registerCode.Name = "registerCode";
            this.registerCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.registerCode.Size = new System.Drawing.Size(280, 120);
            this.registerCode.TabIndex = 2;
            // 
            // machineCode
            // 
            this.machineCode.Location = new System.Drawing.Point(90, 25);
            this.machineCode.MaxLength = 50;
            this.machineCode.Multiline = true;
            this.machineCode.Name = "machineCode";
            this.machineCode.ReadOnly = true;
            this.machineCode.Size = new System.Drawing.Size(280, 25);
            this.machineCode.TabIndex = 2;
            this.machineCode.TextChanged += new System.EventHandler(this.machineCode_TextChanged);
            // 
            // registerCodeLbl
            // 
            this.registerCodeLbl.Location = new System.Drawing.Point(5, 65);
            this.registerCodeLbl.Name = "registerCodeLbl";
            this.registerCodeLbl.Size = new System.Drawing.Size(80, 26);
            this.registerCodeLbl.TabIndex = 1;
            this.registerCodeLbl.Text = "注册码(&R)";
            this.registerCodeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // machineCodeLbl
            // 
            this.machineCodeLbl.Location = new System.Drawing.Point(5, 25);
            this.machineCodeLbl.Name = "machineCodeLbl";
            this.machineCodeLbl.Size = new System.Drawing.Size(80, 25);
            this.machineCodeLbl.TabIndex = 1;
            this.machineCodeLbl.Text = "机器码(&M)";
            this.machineCodeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // registerFileDialog
            // 
            this.registerFileDialog.DefaultExt = "key";
            this.registerFileDialog.FileName = "register.key";
            this.registerFileDialog.Filter = "授权文件|*.key|所有文件|*.*";
            this.registerFileDialog.Title = "打开文件";
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
            this.topPanel.TabIndex = 6;
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
            // tipBox
            // 
            this.tipBox.Controls.Add(this.tipLbl);
            this.tipBox.Controls.Add(this.licenseLbl);
            this.tipBox.Location = new System.Drawing.Point(10, 80);
            this.tipBox.Name = "tipBox";
            this.tipBox.Size = new System.Drawing.Size(384, 105);
            this.tipBox.TabIndex = 0;
            this.tipBox.TabStop = false;
            this.tipBox.Text = "注册说明";
            // 
            // tipLbl
            // 
            this.tipLbl.AutoEllipsis = true;
            this.tipLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tipLbl.ForeColor = System.Drawing.Color.DimGray;
            this.tipLbl.Location = new System.Drawing.Point(3, 44);
            this.tipLbl.Name = "tipLbl";
            this.tipLbl.Size = new System.Drawing.Size(378, 58);
            this.tipLbl.TabIndex = 0;
            this.tipLbl.Text = "感谢您使用本产品，本产品试用期为30天，试用到期后，需注册后才能继续使用。如果您尚未注册，建议您尽快从服务商处获取注册码注册本产品，以免耽误您的正常使用，谢谢！";
            // 
            // licenseLbl
            // 
            this.licenseLbl.AutoEllipsis = true;
            this.licenseLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.licenseLbl.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.licenseLbl.ForeColor = System.Drawing.Color.Red;
            this.licenseLbl.Location = new System.Drawing.Point(3, 19);
            this.licenseLbl.Name = "licenseLbl";
            this.licenseLbl.Size = new System.Drawing.Size(378, 25);
            this.licenseLbl.TabIndex = 0;
            this.licenseLbl.Text = "注册说明";
            this.licenseLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegisterForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 442);
            this.Controls.Add(this.tipBox);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.registerBox);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "软件注册";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.registerBox.ResumeLayout(false);
            this.registerBox.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.tipBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.GroupBox registerBox;
        private System.Windows.Forms.TextBox registerCode;
        private System.Windows.Forms.TextBox machineCode;
        private System.Windows.Forms.Label registerCodeLbl;
        private System.Windows.Forms.Label machineCodeLbl;
        private System.Windows.Forms.OpenFileDialog registerFileDialog;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.GroupBox tipBox;
        private System.Windows.Forms.Label tipLbl;
        private System.Windows.Forms.Label licenseLbl;


    }
}