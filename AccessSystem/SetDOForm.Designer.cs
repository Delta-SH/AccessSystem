namespace Delta.MPS.AccessSystem
{
    partial class SetDOForm
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
            this.CKCB = new System.Windows.Forms.RadioButton();
            this.CBCB = new System.Windows.Forms.RadioButton();
            this.MCCB = new System.Windows.Forms.RadioButton();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.lineLbl = new System.Windows.Forms.Label();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.CKCB, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.CBCB, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.MCCB, 0, 4);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 7);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 8;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(334, 152);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // CKCB
            // 
            this.CKCB.AutoSize = true;
            this.CKCB.Checked = true;
            this.CKCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CKCB.Location = new System.Drawing.Point(10, 10);
            this.CKCB.Margin = new System.Windows.Forms.Padding(0);
            this.CKCB.Name = "CKCB";
            this.CKCB.Size = new System.Drawing.Size(314, 25);
            this.CKCB.TabIndex = 1;
            this.CKCB.TabStop = true;
            this.CKCB.Tag = "0";
            this.CKCB.Text = "常开控制(0)";
            this.CKCB.UseVisualStyleBackColor = true;
            // 
            // CBCB
            // 
            this.CBCB.AutoSize = true;
            this.CBCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBCB.Location = new System.Drawing.Point(10, 40);
            this.CBCB.Margin = new System.Windows.Forms.Padding(0);
            this.CBCB.Name = "CBCB";
            this.CBCB.Size = new System.Drawing.Size(314, 25);
            this.CBCB.TabIndex = 2;
            this.CBCB.Tag = "1";
            this.CBCB.Text = "常闭控制(1)";
            this.CBCB.UseVisualStyleBackColor = true;
            // 
            // MCCB
            // 
            this.MCCB.AutoSize = true;
            this.MCCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MCCB.Location = new System.Drawing.Point(10, 70);
            this.MCCB.Margin = new System.Windows.Forms.Padding(0);
            this.MCCB.Name = "MCCB";
            this.MCCB.Size = new System.Drawing.Size(314, 25);
            this.MCCB.TabIndex = 3;
            this.MCCB.Tag = "2";
            this.MCCB.Text = "脉冲控制(2)";
            this.MCCB.UseVisualStyleBackColor = true;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.lineLbl);
            this.BottomPanel.Controls.Add(this.OKBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 102);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(314, 50);
            this.BottomPanel.TabIndex = 1;
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineLbl.Location = new System.Drawing.Point(0, 0);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(314, 2);
            this.lineLbl.TabIndex = 1;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OKBtn.Location = new System.Drawing.Point(124, 10);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(90, 30);
            this.OKBtn.TabIndex = 0;
            this.OKBtn.Text = "保存(&S)";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(224, 10);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 0;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SetDOForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(334, 152);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetDOForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "远程控制";
            this.Shown += new System.EventHandler(this.SetDOForm_Shown);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.RadioButton CKCB;
        private System.Windows.Forms.RadioButton CBCB;
        private System.Windows.Forms.RadioButton MCCB;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label lineLbl;
    }
}