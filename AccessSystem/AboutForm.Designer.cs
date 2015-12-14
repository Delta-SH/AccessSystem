namespace Delta.MPS.AccessSystem
{
    partial class AboutForm
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
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.registerLbl = new System.Windows.Forms.LinkLabel();
            this.okBtn = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.aboutTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.productNameLbl = new System.Windows.Forms.Label();
            this.versionLbl = new System.Windows.Forms.Label();
            this.companyNameLbl = new System.Windows.Forms.Label();
            this.copyrightLbl = new System.Windows.Forms.Label();
            this.descriptionLbl = new System.Windows.Forms.Label();
            this.bottomPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.aboutTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.SystemColors.Control;
            this.bottomPanel.Controls.Add(this.registerLbl);
            this.bottomPanel.Controls.Add(this.okBtn);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 242);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(404, 40);
            this.bottomPanel.TabIndex = 0;
            // 
            // registerLbl
            // 
            this.registerLbl.AutoSize = true;
            this.registerLbl.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.registerLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.registerLbl.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.registerLbl.Location = new System.Drawing.Point(12, 12);
            this.registerLbl.Margin = new System.Windows.Forms.Padding(0);
            this.registerLbl.Name = "registerLbl";
            this.registerLbl.Size = new System.Drawing.Size(56, 17);
            this.registerLbl.TabIndex = 2;
            this.registerLbl.TabStop = true;
            this.registerLbl.Text = "授权信息";
            this.registerLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerLbl_LinkClicked);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(320, 8);
            this.okBtn.Margin = new System.Windows.Forms.Padding(0);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 25);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "确定(&O)";
            this.okBtn.UseVisualStyleBackColor = true;
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
            this.topPanel.TabIndex = 1;
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
            // aboutTableLayout
            // 
            this.aboutTableLayout.ColumnCount = 1;
            this.aboutTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.aboutTableLayout.Controls.Add(this.productNameLbl, 0, 0);
            this.aboutTableLayout.Controls.Add(this.versionLbl, 0, 1);
            this.aboutTableLayout.Controls.Add(this.companyNameLbl, 0, 2);
            this.aboutTableLayout.Controls.Add(this.copyrightLbl, 0, 3);
            this.aboutTableLayout.Controls.Add(this.descriptionLbl, 0, 5);
            this.aboutTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutTableLayout.Location = new System.Drawing.Point(0, 70);
            this.aboutTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.aboutTableLayout.Name = "aboutTableLayout";
            this.aboutTableLayout.RowCount = 6;
            this.aboutTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.aboutTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.aboutTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.aboutTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.aboutTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.aboutTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.aboutTableLayout.Size = new System.Drawing.Size(404, 172);
            this.aboutTableLayout.TabIndex = 0;
            // 
            // productNameLbl
            // 
            this.productNameLbl.AutoSize = true;
            this.productNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productNameLbl.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.productNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(77)))));
            this.productNameLbl.Location = new System.Drawing.Point(0, 0);
            this.productNameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.productNameLbl.Name = "productNameLbl";
            this.productNameLbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.productNameLbl.Size = new System.Drawing.Size(404, 30);
            this.productNameLbl.TabIndex = 0;
            this.productNameLbl.Text = "Product Name";
            this.productNameLbl.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // versionLbl
            // 
            this.versionLbl.AutoSize = true;
            this.versionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(77)))));
            this.versionLbl.Location = new System.Drawing.Point(0, 30);
            this.versionLbl.Margin = new System.Windows.Forms.Padding(0);
            this.versionLbl.Name = "versionLbl";
            this.versionLbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.versionLbl.Size = new System.Drawing.Size(404, 20);
            this.versionLbl.TabIndex = 1;
            this.versionLbl.Text = "Version";
            this.versionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // companyNameLbl
            // 
            this.companyNameLbl.AutoSize = true;
            this.companyNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.companyNameLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(77)))));
            this.companyNameLbl.Location = new System.Drawing.Point(0, 50);
            this.companyNameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.companyNameLbl.Name = "companyNameLbl";
            this.companyNameLbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.companyNameLbl.Size = new System.Drawing.Size(404, 20);
            this.companyNameLbl.TabIndex = 2;
            this.companyNameLbl.Text = "Company Name";
            this.companyNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // copyrightLbl
            // 
            this.copyrightLbl.AutoSize = true;
            this.copyrightLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.copyrightLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(77)))));
            this.copyrightLbl.Location = new System.Drawing.Point(0, 70);
            this.copyrightLbl.Margin = new System.Windows.Forms.Padding(0);
            this.copyrightLbl.Name = "copyrightLbl";
            this.copyrightLbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.copyrightLbl.Size = new System.Drawing.Size(404, 20);
            this.copyrightLbl.TabIndex = 3;
            this.copyrightLbl.Text = "Copyright";
            this.copyrightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLbl
            // 
            this.descriptionLbl.AutoSize = true;
            this.descriptionLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(71)))), ((int)(((byte)(77)))));
            this.descriptionLbl.Location = new System.Drawing.Point(0, 110);
            this.descriptionLbl.Margin = new System.Windows.Forms.Padding(0);
            this.descriptionLbl.Name = "descriptionLbl";
            this.descriptionLbl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.descriptionLbl.Size = new System.Drawing.Size(404, 62);
            this.descriptionLbl.TabIndex = 4;
            this.descriptionLbl.Text = "本计算机程序受著作权法保护。\r\n未经授权不得擅自复制或传播本程序（或其中任何部分）。\r\n版权所有，侵权必究。";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.okBtn;
            this.ClientSize = new System.Drawing.Size(404, 282);
            this.Controls.Add(this.aboutTableLayout);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.bottomPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于...";
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.aboutTableLayout.ResumeLayout(false);
            this.aboutTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.LinkLabel registerLbl;
        private System.Windows.Forms.TableLayoutPanel aboutTableLayout;
        private System.Windows.Forms.Label productNameLbl;
        private System.Windows.Forms.Label versionLbl;
        private System.Windows.Forms.Label companyNameLbl;
        private System.Windows.Forms.Label copyrightLbl;
        private System.Windows.Forms.Label descriptionLbl;
    }
}