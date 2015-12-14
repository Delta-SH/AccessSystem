namespace Delta.MPS.AccessSystem
{
    partial class ChangePasswordForm
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
            this.OriginalPasswordLbl = new System.Windows.Forms.Label();
            this.OriginalPasswordTB = new System.Windows.Forms.TextBox();
            this.NewPasswordLbl = new System.Windows.Forms.Label();
            this.NewPasswordTB = new System.Windows.Forms.TextBox();
            this.NewCPasswordLbl = new System.Windows.Forms.Label();
            this.NewCPasswordTB = new System.Windows.Forms.TextBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 4;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.Controls.Add(this.lineLbl, 1, 7);
            this.MainTableLayoutPanel.Controls.Add(this.OriginalPasswordLbl, 1, 1);
            this.MainTableLayoutPanel.Controls.Add(this.OriginalPasswordTB, 2, 1);
            this.MainTableLayoutPanel.Controls.Add(this.NewPasswordLbl, 1, 3);
            this.MainTableLayoutPanel.Controls.Add(this.NewPasswordTB, 2, 3);
            this.MainTableLayoutPanel.Controls.Add(this.NewCPasswordLbl, 1, 5);
            this.MainTableLayoutPanel.Controls.Add(this.NewCPasswordTB, 2, 5);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 1, 8);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 9;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(304, 167);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainTableLayoutPanel.SetColumnSpan(this.lineLbl, 2);
            this.lineLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lineLbl.Location = new System.Drawing.Point(10, 115);
            this.lineLbl.Margin = new System.Windows.Forms.Padding(0);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(284, 2);
            this.lineLbl.TabIndex = 23;
            // 
            // OriginalPasswordLbl
            // 
            this.OriginalPasswordLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalPasswordLbl.Location = new System.Drawing.Point(10, 10);
            this.OriginalPasswordLbl.Margin = new System.Windows.Forms.Padding(0);
            this.OriginalPasswordLbl.Name = "OriginalPasswordLbl";
            this.OriginalPasswordLbl.Size = new System.Drawing.Size(80, 25);
            this.OriginalPasswordLbl.TabIndex = 1;
            this.OriginalPasswordLbl.Text = "原密码(&R):";
            this.OriginalPasswordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OriginalPasswordTB
            // 
            this.OriginalPasswordTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalPasswordTB.Location = new System.Drawing.Point(90, 10);
            this.OriginalPasswordTB.Margin = new System.Windows.Forms.Padding(0);
            this.OriginalPasswordTB.MaxLength = 50;
            this.OriginalPasswordTB.Name = "OriginalPasswordTB";
            this.OriginalPasswordTB.PasswordChar = '●';
            this.OriginalPasswordTB.Size = new System.Drawing.Size(204, 23);
            this.OriginalPasswordTB.TabIndex = 2;
            // 
            // NewPasswordLbl
            // 
            this.NewPasswordLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewPasswordLbl.Location = new System.Drawing.Point(10, 45);
            this.NewPasswordLbl.Margin = new System.Windows.Forms.Padding(0);
            this.NewPasswordLbl.Name = "NewPasswordLbl";
            this.NewPasswordLbl.Size = new System.Drawing.Size(80, 25);
            this.NewPasswordLbl.TabIndex = 3;
            this.NewPasswordLbl.Text = "新密码(&P):";
            this.NewPasswordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewPasswordTB
            // 
            this.NewPasswordTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewPasswordTB.Location = new System.Drawing.Point(90, 45);
            this.NewPasswordTB.Margin = new System.Windows.Forms.Padding(0);
            this.NewPasswordTB.MaxLength = 50;
            this.NewPasswordTB.Name = "NewPasswordTB";
            this.NewPasswordTB.PasswordChar = '●';
            this.NewPasswordTB.Size = new System.Drawing.Size(204, 23);
            this.NewPasswordTB.TabIndex = 4;
            // 
            // NewCPasswordLbl
            // 
            this.NewCPasswordLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewCPasswordLbl.Location = new System.Drawing.Point(10, 80);
            this.NewCPasswordLbl.Margin = new System.Windows.Forms.Padding(0);
            this.NewCPasswordLbl.Name = "NewCPasswordLbl";
            this.NewCPasswordLbl.Size = new System.Drawing.Size(80, 25);
            this.NewCPasswordLbl.TabIndex = 5;
            this.NewCPasswordLbl.Text = "确认密码(&F):";
            this.NewCPasswordLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NewCPasswordTB
            // 
            this.NewCPasswordTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewCPasswordTB.Location = new System.Drawing.Point(90, 80);
            this.NewCPasswordTB.Margin = new System.Windows.Forms.Padding(0);
            this.NewCPasswordTB.MaxLength = 50;
            this.NewCPasswordTB.Name = "NewCPasswordTB";
            this.NewCPasswordTB.PasswordChar = '●';
            this.NewCPasswordTB.Size = new System.Drawing.Size(204, 23);
            this.NewCPasswordTB.TabIndex = 6;
            // 
            // BottomPanel
            // 
            this.MainTableLayoutPanel.SetColumnSpan(this.BottomPanel, 2);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Controls.Add(this.SaveBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 117);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(284, 50);
            this.BottomPanel.TabIndex = 0;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(194, 10);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(80, 10);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(90, 30);
            this.SaveBtn.TabIndex = 7;
            this.SaveBtn.Text = "确定(&O)";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ChangePasswordForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(304, 167);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更改密码";
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Label OriginalPasswordLbl;
        private System.Windows.Forms.TextBox OriginalPasswordTB;
        private System.Windows.Forms.Label NewPasswordLbl;
        private System.Windows.Forms.TextBox NewPasswordTB;
        private System.Windows.Forms.Label NewCPasswordLbl;
        private System.Windows.Forms.TextBox NewCPasswordTB;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
    }
}