namespace Delta.MPS.AccessSystem
{
    partial class FinderDialog
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
            this.FContentLbl = new System.Windows.Forms.Label();
            this.FContentTB = new System.Windows.Forms.TextBox();
            this.OptionGBPanel = new System.Windows.Forms.GroupBox();
            this.OptionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DXXCB = new System.Windows.Forms.CheckBox();
            this.QZCB = new System.Windows.Forms.CheckBox();
            this.XSCB = new System.Windows.Forms.CheckBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.FindBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.OptionGBPanel.SuspendLayout();
            this.OptionTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.FContentLbl, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.FContentTB, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.OptionGBPanel, 0, 3);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 5);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 6;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(304, 237);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // FContentLbl
            // 
            this.FContentLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FContentLbl.Location = new System.Drawing.Point(10, 10);
            this.FContentLbl.Margin = new System.Windows.Forms.Padding(0);
            this.FContentLbl.Name = "FContentLbl";
            this.FContentLbl.Size = new System.Drawing.Size(284, 25);
            this.FContentLbl.TabIndex = 1;
            this.FContentLbl.Text = "查找内容(&N):";
            this.FContentLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FContentTB
            // 
            this.FContentTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FContentTB.Location = new System.Drawing.Point(10, 37);
            this.FContentTB.Margin = new System.Windows.Forms.Padding(0);
            this.FContentTB.Name = "FContentTB";
            this.FContentTB.Size = new System.Drawing.Size(284, 23);
            this.FContentTB.TabIndex = 2;
            this.FContentTB.TextChanged += new System.EventHandler(this.FContentTB_TextChanged);
            // 
            // OptionGBPanel
            // 
            this.OptionGBPanel.Controls.Add(this.OptionTableLayoutPanel);
            this.OptionGBPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionGBPanel.Location = new System.Drawing.Point(10, 70);
            this.OptionGBPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OptionGBPanel.Name = "OptionGBPanel";
            this.OptionGBPanel.Size = new System.Drawing.Size(284, 107);
            this.OptionGBPanel.TabIndex = 3;
            this.OptionGBPanel.TabStop = false;
            this.OptionGBPanel.Text = "查找选项(&O)";
            // 
            // OptionTableLayoutPanel
            // 
            this.OptionTableLayoutPanel.ColumnCount = 1;
            this.OptionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OptionTableLayoutPanel.Controls.Add(this.DXXCB, 0, 0);
            this.OptionTableLayoutPanel.Controls.Add(this.QZCB, 0, 1);
            this.OptionTableLayoutPanel.Controls.Add(this.XSCB, 0, 2);
            this.OptionTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.OptionTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OptionTableLayoutPanel.Name = "OptionTableLayoutPanel";
            this.OptionTableLayoutPanel.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.OptionTableLayoutPanel.RowCount = 4;
            this.OptionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.OptionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.OptionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.OptionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.OptionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.OptionTableLayoutPanel.Size = new System.Drawing.Size(278, 85);
            this.OptionTableLayoutPanel.TabIndex = 0;
            // 
            // DXXCB
            // 
            this.DXXCB.Dock = System.Windows.Forms.DockStyle.Left;
            this.DXXCB.Location = new System.Drawing.Point(6, 3);
            this.DXXCB.Margin = new System.Windows.Forms.Padding(0);
            this.DXXCB.Name = "DXXCB";
            this.DXXCB.Size = new System.Drawing.Size(105, 25);
            this.DXXCB.TabIndex = 1;
            this.DXXCB.Text = "大小写匹配(&C)";
            this.DXXCB.UseVisualStyleBackColor = true;
            this.DXXCB.CheckedChanged += new System.EventHandler(this.DXXCB_CheckedChanged);
            // 
            // QZCB
            // 
            this.QZCB.Dock = System.Windows.Forms.DockStyle.Left;
            this.QZCB.Location = new System.Drawing.Point(6, 28);
            this.QZCB.Margin = new System.Windows.Forms.Padding(0);
            this.QZCB.Name = "QZCB";
            this.QZCB.Size = new System.Drawing.Size(105, 25);
            this.QZCB.TabIndex = 2;
            this.QZCB.Text = "全字匹配(&W)";
            this.QZCB.UseVisualStyleBackColor = true;
            this.QZCB.CheckedChanged += new System.EventHandler(this.QZCB_CheckedChanged);
            // 
            // XSCB
            // 
            this.XSCB.Dock = System.Windows.Forms.DockStyle.Left;
            this.XSCB.Location = new System.Drawing.Point(6, 53);
            this.XSCB.Margin = new System.Windows.Forms.Padding(0);
            this.XSCB.Name = "XSCB";
            this.XSCB.Size = new System.Drawing.Size(105, 25);
            this.XSCB.TabIndex = 3;
            this.XSCB.Text = "向上搜索(&U)";
            this.XSCB.UseVisualStyleBackColor = true;
            this.XSCB.CheckedChanged += new System.EventHandler(this.XSCB_CheckedChanged);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Controls.Add(this.FindBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 187);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(284, 50);
            this.BottomPanel.TabIndex = 4;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(174, 10);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(110, 30);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "关闭(&X)";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // FindBtn
            // 
            this.FindBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FindBtn.Location = new System.Drawing.Point(54, 10);
            this.FindBtn.Margin = new System.Windows.Forms.Padding(0);
            this.FindBtn.Name = "FindBtn";
            this.FindBtn.Size = new System.Drawing.Size(110, 30);
            this.FindBtn.TabIndex = 1;
            this.FindBtn.Text = "查找下一个(&F)";
            this.FindBtn.UseVisualStyleBackColor = true;
            this.FindBtn.Click += new System.EventHandler(this.FindBtn_Click);
            // 
            // FinderDialog
            // 
            this.AcceptButton = this.FindBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(304, 237);
            this.ControlBox = false;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FinderDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找对话框";
            this.Load += new System.EventHandler(this.FinderDialog_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.OptionGBPanel.ResumeLayout(false);
            this.OptionTableLayoutPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Label FContentLbl;
        private System.Windows.Forms.TextBox FContentTB;
        private System.Windows.Forms.GroupBox OptionGBPanel;
        private System.Windows.Forms.TableLayoutPanel OptionTableLayoutPanel;
        private System.Windows.Forms.CheckBox DXXCB;
        private System.Windows.Forms.CheckBox QZCB;
        private System.Windows.Forms.CheckBox XSCB;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button FindBtn;
    }
}