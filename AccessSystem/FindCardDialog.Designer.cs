namespace Delta.MPS.AccessSystem
{
    partial class FindCardDialog
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
            this.CardXSnTB = new System.Windows.Forms.TextBox();
            this.CardXSnLbl = new System.Windows.Forms.Label();
            this.CardSnTB = new System.Windows.Forms.TextBox();
            this.CardSnLbl = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.CardXSnTB, 1, 2);
            this.MainTableLayoutPanel.Controls.Add(this.CardXSnLbl, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.CardSnTB, 1, 0);
            this.MainTableLayoutPanel.Controls.Add(this.CardSnLbl, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 4);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 5;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(334, 122);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // CardXSnTB
            // 
            this.CardXSnTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CardXSnTB.Location = new System.Drawing.Point(100, 47);
            this.CardXSnTB.Margin = new System.Windows.Forms.Padding(0);
            this.CardXSnTB.MaxLength = 10;
            this.CardXSnTB.Name = "CardXSnTB";
            this.CardXSnTB.Size = new System.Drawing.Size(224, 23);
            this.CardXSnTB.TabIndex = 4;
            this.CardXSnTB.TextChanged += new System.EventHandler(this.CardXSnTB_TextChanged);
            this.CardXSnTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CardXSnTB_KeyPress);
            // 
            // CardXSnLbl
            // 
            this.CardXSnLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardXSnLbl.Location = new System.Drawing.Point(10, 45);
            this.CardXSnLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CardXSnLbl.Name = "CardXSnLbl";
            this.CardXSnLbl.Size = new System.Drawing.Size(90, 25);
            this.CardXSnLbl.TabIndex = 3;
            this.CardXSnLbl.Text = "十六进制卡号:";
            this.CardXSnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardSnTB
            // 
            this.CardSnTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CardSnTB.Location = new System.Drawing.Point(100, 12);
            this.CardSnTB.Margin = new System.Windows.Forms.Padding(0);
            this.CardSnTB.MaxLength = 10;
            this.CardSnTB.Name = "CardSnTB";
            this.CardSnTB.Size = new System.Drawing.Size(224, 23);
            this.CardSnTB.TabIndex = 2;
            this.CardSnTB.TextChanged += new System.EventHandler(this.CardSnTB_TextChanged);
            this.CardSnTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CardSnTB_KeyPress);
            // 
            // CardSnLbl
            // 
            this.CardSnLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardSnLbl.Location = new System.Drawing.Point(10, 10);
            this.CardSnLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CardSnLbl.Name = "CardSnLbl";
            this.CardSnLbl.Size = new System.Drawing.Size(90, 25);
            this.CardSnLbl.TabIndex = 1;
            this.CardSnLbl.Text = "十进制卡号:";
            this.CardSnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BottomPanel
            // 
            this.MainTableLayoutPanel.SetColumnSpan(this.BottomPanel, 2);
            this.BottomPanel.Controls.Add(this.OKBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 82);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(314, 40);
            this.BottomPanel.TabIndex = 5;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OKBtn.Location = new System.Drawing.Point(124, 5);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(90, 30);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "确定(&O)";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(224, 5);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // FindCardDialog
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(334, 122);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindCardDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找卡片";
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Label CardSnLbl;
        private System.Windows.Forms.TextBox CardSnTB;
        private System.Windows.Forms.Label CardXSnLbl;
        private System.Windows.Forms.TextBox CardXSnTB;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}