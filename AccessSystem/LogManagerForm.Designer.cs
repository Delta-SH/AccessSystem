namespace Delta.MPS.AccessSystem
{
    partial class LogManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.EventGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperatorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SourceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MessageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StackTraceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConditionPanel = new System.Windows.Forms.GroupBox();
            this.ConditionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BeginTimeLbl = new System.Windows.Forms.Label();
            this.BeginTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.EndTimeLbl = new System.Windows.Forms.Label();
            this.EndTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.LogTypeLbl = new System.Windows.Forms.Label();
            this.LogTypeCB = new System.Windows.Forms.ComboBox();
            this.MHSXCB = new System.Windows.Forms.ComboBox();
            this.MHSXTB = new System.Windows.Forms.TextBox();
            this.MHSXLbl = new System.Windows.Forms.Label();
            this.QueryBtn = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.ExportExcelBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventGridView)).BeginInit();
            this.ConditionPanel.SuspendLayout();
            this.ConditionTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.EventGridView, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.ConditionPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 3);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 4;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(784, 512);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // EventGridView
            // 
            this.EventGridView.AllowUserToAddRows = false;
            this.EventGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EventGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EventGridView.BackgroundColor = System.Drawing.Color.White;
            this.EventGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EventGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EventGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EventGridView.ColumnHeadersHeight = 25;
            this.EventGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.EventIdColumn,
            this.EventTimeColumn,
            this.EventTypeColumn,
            this.OperatorColumn,
            this.SourceColumn,
            this.MessageColumn,
            this.StackTraceColumn});
            this.EventGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventGridView.GridColor = System.Drawing.SystemColors.Control;
            this.EventGridView.Location = new System.Drawing.Point(10, 110);
            this.EventGridView.Margin = new System.Windows.Forms.Padding(0);
            this.EventGridView.MultiSelect = false;
            this.EventGridView.Name = "EventGridView";
            this.EventGridView.ReadOnly = true;
            this.EventGridView.RowHeadersVisible = false;
            this.EventGridView.RowTemplate.Height = 25;
            this.EventGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EventGridView.Size = new System.Drawing.Size(764, 352);
            this.EventGridView.TabIndex = 2;
            this.EventGridView.Tag = "";
            this.EventGridView.VirtualMode = true;
            this.EventGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.EventGridView_CellFormatting);
            this.EventGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.EventGridView_CellValueNeeded);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "序号";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 60;
            // 
            // EventIdColumn
            // 
            this.EventIdColumn.HeaderText = "标识";
            this.EventIdColumn.Name = "EventIdColumn";
            this.EventIdColumn.ReadOnly = true;
            this.EventIdColumn.Visible = false;
            // 
            // EventTimeColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EventTimeColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.EventTimeColumn.HeaderText = "日志时间";
            this.EventTimeColumn.Name = "EventTimeColumn";
            this.EventTimeColumn.ReadOnly = true;
            this.EventTimeColumn.Width = 150;
            // 
            // EventTypeColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EventTypeColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.EventTypeColumn.HeaderText = "日志类型";
            this.EventTypeColumn.Name = "EventTypeColumn";
            this.EventTypeColumn.ReadOnly = true;
            // 
            // OperatorColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OperatorColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.OperatorColumn.HeaderText = "触发对象";
            this.OperatorColumn.Name = "OperatorColumn";
            this.OperatorColumn.ReadOnly = true;
            // 
            // SourceColumn
            // 
            this.SourceColumn.HeaderText = "触发来源";
            this.SourceColumn.Name = "SourceColumn";
            this.SourceColumn.ReadOnly = true;
            // 
            // MessageColumn
            // 
            this.MessageColumn.HeaderText = "日志描述";
            this.MessageColumn.Name = "MessageColumn";
            this.MessageColumn.ReadOnly = true;
            this.MessageColumn.Width = 300;
            // 
            // StackTraceColumn
            // 
            this.StackTraceColumn.HeaderText = "详细信息";
            this.StackTraceColumn.Name = "StackTraceColumn";
            this.StackTraceColumn.ReadOnly = true;
            this.StackTraceColumn.Width = 300;
            // 
            // ConditionPanel
            // 
            this.ConditionPanel.Controls.Add(this.ConditionTableLayoutPanel);
            this.ConditionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionPanel.Location = new System.Drawing.Point(10, 10);
            this.ConditionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionPanel.Name = "ConditionPanel";
            this.ConditionPanel.Size = new System.Drawing.Size(764, 95);
            this.ConditionPanel.TabIndex = 1;
            this.ConditionPanel.TabStop = false;
            this.ConditionPanel.Text = "筛选条件";
            // 
            // ConditionTableLayoutPanel
            // 
            this.ConditionTableLayoutPanel.ColumnCount = 8;
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ConditionTableLayoutPanel.Controls.Add(this.BeginTimeLbl, 0, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.BeginTimeDTP, 1, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.EndTimeLbl, 3, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.EndTimeDTP, 4, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.LogTypeLbl, 6, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.LogTypeCB, 7, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.MHSXCB, 1, 2);
            this.ConditionTableLayoutPanel.Controls.Add(this.MHSXTB, 3, 2);
            this.ConditionTableLayoutPanel.Controls.Add(this.MHSXLbl, 0, 2);
            this.ConditionTableLayoutPanel.Controls.Add(this.QueryBtn, 6, 2);
            this.ConditionTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.ConditionTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionTableLayoutPanel.Name = "ConditionTableLayoutPanel";
            this.ConditionTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ConditionTableLayoutPanel.RowCount = 3;
            this.ConditionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConditionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.ConditionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConditionTableLayoutPanel.Size = new System.Drawing.Size(758, 73);
            this.ConditionTableLayoutPanel.TabIndex = 1;
            // 
            // BeginTimeLbl
            // 
            this.BeginTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginTimeLbl.Location = new System.Drawing.Point(5, 5);
            this.BeginTimeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimeLbl.Name = "BeginTimeLbl";
            this.BeginTimeLbl.Size = new System.Drawing.Size(80, 26);
            this.BeginTimeLbl.TabIndex = 1;
            this.BeginTimeLbl.Text = "开始时间(&B):";
            this.BeginTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BeginTimeDTP
            // 
            this.BeginTimeDTP.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.BeginTimeDTP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BeginTimeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginTimeDTP.Location = new System.Drawing.Point(85, 6);
            this.BeginTimeDTP.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.BeginTimeDTP.Name = "BeginTimeDTP";
            this.BeginTimeDTP.Size = new System.Drawing.Size(162, 23);
            this.BeginTimeDTP.TabIndex = 2;
            this.BeginTimeDTP.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // EndTimeLbl
            // 
            this.EndTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndTimeLbl.Location = new System.Drawing.Point(257, 5);
            this.EndTimeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.EndTimeLbl.Name = "EndTimeLbl";
            this.EndTimeLbl.Size = new System.Drawing.Size(80, 26);
            this.EndTimeLbl.TabIndex = 3;
            this.EndTimeLbl.Text = "结束时间(&D):";
            this.EndTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndTimeDTP
            // 
            this.EndTimeDTP.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.EndTimeDTP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EndTimeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTimeDTP.Location = new System.Drawing.Point(337, 6);
            this.EndTimeDTP.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.EndTimeDTP.Name = "EndTimeDTP";
            this.EndTimeDTP.Size = new System.Drawing.Size(162, 23);
            this.EndTimeDTP.TabIndex = 4;
            this.EndTimeDTP.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // LogTypeLbl
            // 
            this.LogTypeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTypeLbl.Location = new System.Drawing.Point(509, 5);
            this.LogTypeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.LogTypeLbl.Name = "LogTypeLbl";
            this.LogTypeLbl.Size = new System.Drawing.Size(80, 26);
            this.LogTypeLbl.TabIndex = 5;
            this.LogTypeLbl.Text = "日志类型(&T):";
            this.LogTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogTypeCB
            // 
            this.LogTypeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LogTypeCB.FormattingEnabled = true;
            this.LogTypeCB.Location = new System.Drawing.Point(589, 5);
            this.LogTypeCB.Margin = new System.Windows.Forms.Padding(0);
            this.LogTypeCB.Name = "LogTypeCB";
            this.LogTypeCB.Size = new System.Drawing.Size(164, 25);
            this.LogTypeCB.TabIndex = 6;
            // 
            // MHSXCB
            // 
            this.MHSXCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MHSXCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MHSXCB.FormattingEnabled = true;
            this.MHSXCB.Location = new System.Drawing.Point(85, 41);
            this.MHSXCB.Margin = new System.Windows.Forms.Padding(0);
            this.MHSXCB.Name = "MHSXCB";
            this.MHSXCB.Size = new System.Drawing.Size(162, 25);
            this.MHSXCB.TabIndex = 8;
            // 
            // MHSXTB
            // 
            this.ConditionTableLayoutPanel.SetColumnSpan(this.MHSXTB, 2);
            this.MHSXTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MHSXTB.Location = new System.Drawing.Point(257, 43);
            this.MHSXTB.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.MHSXTB.Name = "MHSXTB";
            this.MHSXTB.Size = new System.Drawing.Size(242, 23);
            this.MHSXTB.TabIndex = 9;
            // 
            // MHSXLbl
            // 
            this.MHSXLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MHSXLbl.Location = new System.Drawing.Point(5, 41);
            this.MHSXLbl.Margin = new System.Windows.Forms.Padding(0);
            this.MHSXLbl.Name = "MHSXLbl";
            this.MHSXLbl.Size = new System.Drawing.Size(80, 27);
            this.MHSXLbl.TabIndex = 7;
            this.MHSXLbl.Text = "模糊筛选(&M):";
            this.MHSXLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // QueryBtn
            // 
            this.ConditionTableLayoutPanel.SetColumnSpan(this.QueryBtn, 2);
            this.QueryBtn.Location = new System.Drawing.Point(509, 41);
            this.QueryBtn.Margin = new System.Windows.Forms.Padding(0);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(90, 25);
            this.QueryBtn.TabIndex = 10;
            this.QueryBtn.Text = "查询(&Q)";
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.ExportExcelBtn);
            this.BottomPanel.Controls.Add(this.ExportBtn);
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 462);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(764, 50);
            this.BottomPanel.TabIndex = 3;
            // 
            // ExportExcelBtn
            // 
            this.ExportExcelBtn.Location = new System.Drawing.Point(110, 10);
            this.ExportExcelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ExportExcelBtn.Name = "ExportExcelBtn";
            this.ExportExcelBtn.Size = new System.Drawing.Size(100, 30);
            this.ExportExcelBtn.TabIndex = 1;
            this.ExportExcelBtn.Text = "导出到Excel(&E)";
            this.ExportExcelBtn.UseVisualStyleBackColor = true;
            this.ExportExcelBtn.Click += new System.EventHandler(this.ExportExcelBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(0, 10);
            this.ExportBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(100, 30);
            this.ExportBtn.TabIndex = 1;
            this.ExportBtn.Text = "导出到文本(&X)";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(674, 10);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 30);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // LogManagerForm
            // 
            this.AcceptButton = this.QueryBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "LogManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统日志";
            this.Load += new System.EventHandler(this.LogManagerForm_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EventGridView)).EndInit();
            this.ConditionPanel.ResumeLayout(false);
            this.ConditionTableLayoutPanel.ResumeLayout(false);
            this.ConditionTableLayoutPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.GroupBox ConditionPanel;
        private System.Windows.Forms.DataGridView EventGridView;
        private System.Windows.Forms.TableLayoutPanel ConditionTableLayoutPanel;
        private System.Windows.Forms.Label BeginTimeLbl;
        private System.Windows.Forms.DateTimePicker BeginTimeDTP;
        private System.Windows.Forms.Label EndTimeLbl;
        private System.Windows.Forms.DateTimePicker EndTimeDTP;
        private System.Windows.Forms.Label LogTypeLbl;
        private System.Windows.Forms.ComboBox LogTypeCB;
        private System.Windows.Forms.ComboBox MHSXCB;
        private System.Windows.Forms.TextBox MHSXTB;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.Label MHSXLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OperatorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MessageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StackTraceColumn;
        private System.Windows.Forms.Button ExportExcelBtn;
    }
}