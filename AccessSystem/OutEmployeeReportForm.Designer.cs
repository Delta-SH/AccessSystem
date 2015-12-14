namespace Delta.MPS.AccessSystem
{
    partial class OutEmployeeReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.EmpGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardAddressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardIssueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HometownColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OfficePhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobilePhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnabledColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardSnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardAuthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConditionPanel = new System.Windows.Forms.GroupBox();
            this.ConditionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CBPanel1 = new System.Windows.Forms.Panel();
            this.DeptLB = new System.Windows.Forms.ListBox();
            this.DeptNameLbl = new System.Windows.Forms.Label();
            this.CBPanel2 = new System.Windows.Forms.Panel();
            this.DeptBtn = new System.Windows.Forms.Button();
            this.CBPanel5 = new System.Windows.Forms.Panel();
            this.CardTypeLbl = new System.Windows.Forms.Label();
            this.CardTypeCB = new System.Windows.Forms.ComboBox();
            this.CBPanel3 = new System.Windows.Forms.Panel();
            this.QueryTypeLbl = new System.Windows.Forms.Label();
            this.QueryTypeCB = new System.Windows.Forms.ComboBox();
            this.CBPanel4 = new System.Windows.Forms.Panel();
            this.QueryTypeTB = new System.Windows.Forms.TextBox();
            this.CBPanel6 = new System.Windows.Forms.Panel();
            this.QueryBtn = new System.Windows.Forms.Button();
            this.RecordContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RecMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmpGridView)).BeginInit();
            this.ConditionPanel.SuspendLayout();
            this.ConditionFlowLayoutPanel.SuspendLayout();
            this.CBPanel1.SuspendLayout();
            this.CBPanel2.SuspendLayout();
            this.CBPanel5.SuspendLayout();
            this.CBPanel3.SuspendLayout();
            this.CBPanel4.SuspendLayout();
            this.CBPanel6.SuspendLayout();
            this.RecordContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.EmpGridView);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.ConditionPanel);
            this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.MainSplitContainer.Size = new System.Drawing.Size(784, 512);
            this.MainSplitContainer.SplitterDistance = 534;
            this.MainSplitContainer.TabIndex = 4;
            // 
            // EmpGridView
            // 
            this.EmpGridView.AllowUserToAddRows = false;
            this.EmpGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.EmpGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.EmpGridView.BackgroundColor = System.Drawing.Color.White;
            this.EmpGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EmpGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.EmpGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.EmpGridView.ColumnHeadersHeight = 25;
            this.EmpGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.EIDColumn,
            this.NameColumn,
            this.SexColumn,
            this.CardIDColumn,
            this.CardAddressColumn,
            this.CardIssueColumn,
            this.HometownColumn,
            this.CompanyNameColumn,
            this.ProjectNameColumn,
            this.OfficePhoneColumn,
            this.MobilePhoneColumn,
            this.EmailColumn,
            this.ParentNameColumn,
            this.DepNameColumn,
            this.CommentColumn,
            this.EnabledColumn,
            this.CardSnColumn,
            this.CardAuthColumn});
            this.EmpGridView.ContextMenuStrip = this.RecordContextMenuStrip;
            this.EmpGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmpGridView.GridColor = System.Drawing.SystemColors.Control;
            this.EmpGridView.Location = new System.Drawing.Point(5, 5);
            this.EmpGridView.Margin = new System.Windows.Forms.Padding(0);
            this.EmpGridView.Name = "EmpGridView";
            this.EmpGridView.ReadOnly = true;
            this.EmpGridView.RowHeadersVisible = false;
            this.EmpGridView.RowTemplate.Height = 25;
            this.EmpGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.EmpGridView.Size = new System.Drawing.Size(524, 502);
            this.EmpGridView.TabIndex = 5;
            this.EmpGridView.VirtualMode = true;
            this.EmpGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmpGridView_CellDoubleClick);
            this.EmpGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.EmpGridView_CellValueNeeded);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "序号";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 60;
            // 
            // EIDColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EIDColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.EIDColumn.HeaderText = "工号";
            this.EIDColumn.Name = "EIDColumn";
            this.EIDColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.NameColumn.HeaderText = "姓名";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // SexColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SexColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.SexColumn.HeaderText = "性别";
            this.SexColumn.Name = "SexColumn";
            this.SexColumn.ReadOnly = true;
            this.SexColumn.Width = 60;
            // 
            // CardIDColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardIDColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.CardIDColumn.HeaderText = "身份证号";
            this.CardIDColumn.Name = "CardIDColumn";
            this.CardIDColumn.ReadOnly = true;
            // 
            // CardAddressColumn
            // 
            this.CardAddressColumn.HeaderText = "身份证住址";
            this.CardAddressColumn.Name = "CardAddressColumn";
            this.CardAddressColumn.ReadOnly = true;
            // 
            // CardIssueColumn
            // 
            this.CardIssueColumn.HeaderText = "身份证签发机关";
            this.CardIssueColumn.Name = "CardIssueColumn";
            this.CardIssueColumn.ReadOnly = true;
            // 
            // HometownColumn
            // 
            this.HometownColumn.HeaderText = "籍贯";
            this.HometownColumn.Name = "HometownColumn";
            this.HometownColumn.ReadOnly = true;
            // 
            // CompanyNameColumn
            // 
            this.CompanyNameColumn.HeaderText = "所属公司";
            this.CompanyNameColumn.Name = "CompanyNameColumn";
            this.CompanyNameColumn.ReadOnly = true;
            // 
            // ProjectNameColumn
            // 
            this.ProjectNameColumn.HeaderText = "所属项目";
            this.ProjectNameColumn.Name = "ProjectNameColumn";
            this.ProjectNameColumn.ReadOnly = true;
            // 
            // OfficePhoneColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.OfficePhoneColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.OfficePhoneColumn.HeaderText = "办公电话";
            this.OfficePhoneColumn.Name = "OfficePhoneColumn";
            this.OfficePhoneColumn.ReadOnly = true;
            // 
            // MobilePhoneColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MobilePhoneColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.MobilePhoneColumn.HeaderText = "手机";
            this.MobilePhoneColumn.Name = "MobilePhoneColumn";
            this.MobilePhoneColumn.ReadOnly = true;
            // 
            // EmailColumn
            // 
            this.EmailColumn.HeaderText = "Email";
            this.EmailColumn.Name = "EmailColumn";
            this.EmailColumn.ReadOnly = true;
            // 
            // ParentNameColumn
            // 
            this.ParentNameColumn.HeaderText = "责任人";
            this.ParentNameColumn.Name = "ParentNameColumn";
            this.ParentNameColumn.ReadOnly = true;
            // 
            // DepNameColumn
            // 
            this.DepNameColumn.HeaderText = "所属部门";
            this.DepNameColumn.Name = "DepNameColumn";
            this.DepNameColumn.ReadOnly = true;
            // 
            // CommentColumn
            // 
            this.CommentColumn.HeaderText = "备注";
            this.CommentColumn.Name = "CommentColumn";
            this.CommentColumn.ReadOnly = true;
            // 
            // EnabledColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EnabledColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.EnabledColumn.HeaderText = "状态";
            this.EnabledColumn.Name = "EnabledColumn";
            this.EnabledColumn.ReadOnly = true;
            this.EnabledColumn.Width = 60;
            // 
            // CardSnColumn
            // 
            this.CardSnColumn.HeaderText = "关联卡片";
            this.CardSnColumn.Name = "CardSnColumn";
            this.CardSnColumn.ReadOnly = true;
            // 
            // CardAuthColumn
            // 
            this.CardAuthColumn.HeaderText = "授权设备";
            this.CardAuthColumn.Name = "CardAuthColumn";
            this.CardAuthColumn.ReadOnly = true;
            // 
            // ConditionPanel
            // 
            this.ConditionPanel.Controls.Add(this.ConditionFlowLayoutPanel);
            this.ConditionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionPanel.Location = new System.Drawing.Point(5, 5);
            this.ConditionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionPanel.Name = "ConditionPanel";
            this.ConditionPanel.Size = new System.Drawing.Size(236, 502);
            this.ConditionPanel.TabIndex = 1;
            this.ConditionPanel.TabStop = false;
            this.ConditionPanel.Text = "筛选条件";
            // 
            // ConditionFlowLayoutPanel
            // 
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel1);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel2);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel5);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel3);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel4);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel6);
            this.ConditionFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionFlowLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.ConditionFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionFlowLayoutPanel.Name = "ConditionFlowLayoutPanel";
            this.ConditionFlowLayoutPanel.Size = new System.Drawing.Size(230, 480);
            this.ConditionFlowLayoutPanel.TabIndex = 0;
            // 
            // CBPanel1
            // 
            this.CBPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.CBPanel1.Controls.Add(this.DeptLB);
            this.CBPanel1.Controls.Add(this.DeptNameLbl);
            this.CBPanel1.Location = new System.Drawing.Point(3, 3);
            this.CBPanel1.Name = "CBPanel1";
            this.CBPanel1.Size = new System.Drawing.Size(210, 191);
            this.CBPanel1.TabIndex = 1;
            // 
            // DeptLB
            // 
            this.DeptLB.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeptLB.FormattingEnabled = true;
            this.DeptLB.ItemHeight = 17;
            this.DeptLB.Location = new System.Drawing.Point(60, 0);
            this.DeptLB.Margin = new System.Windows.Forms.Padding(0);
            this.DeptLB.Name = "DeptLB";
            this.DeptLB.Size = new System.Drawing.Size(150, 191);
            this.DeptLB.TabIndex = 2;
            // 
            // DeptNameLbl
            // 
            this.DeptNameLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.DeptNameLbl.Location = new System.Drawing.Point(0, 0);
            this.DeptNameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.DeptNameLbl.Name = "DeptNameLbl";
            this.DeptNameLbl.Size = new System.Drawing.Size(60, 191);
            this.DeptNameLbl.TabIndex = 1;
            this.DeptNameLbl.Text = "部门名称";
            // 
            // CBPanel2
            // 
            this.CBPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.CBPanel2.Controls.Add(this.DeptBtn);
            this.CBPanel2.Location = new System.Drawing.Point(3, 200);
            this.CBPanel2.Name = "CBPanel2";
            this.CBPanel2.Size = new System.Drawing.Size(210, 30);
            this.CBPanel2.TabIndex = 2;
            // 
            // DeptBtn
            // 
            this.DeptBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.DeptBtn.Location = new System.Drawing.Point(60, 0);
            this.DeptBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DeptBtn.Name = "DeptBtn";
            this.DeptBtn.Size = new System.Drawing.Size(150, 30);
            this.DeptBtn.TabIndex = 2;
            this.DeptBtn.Text = "选择部门...";
            this.DeptBtn.UseVisualStyleBackColor = true;
            this.DeptBtn.Click += new System.EventHandler(this.DeptBtn_Click);
            // 
            // CBPanel5
            // 
            this.CBPanel5.Controls.Add(this.CardTypeLbl);
            this.CBPanel5.Controls.Add(this.CardTypeCB);
            this.CBPanel5.Location = new System.Drawing.Point(3, 236);
            this.CBPanel5.Name = "CBPanel5";
            this.CBPanel5.Size = new System.Drawing.Size(210, 25);
            this.CBPanel5.TabIndex = 5;
            // 
            // CardTypeLbl
            // 
            this.CardTypeLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.CardTypeLbl.Location = new System.Drawing.Point(0, 0);
            this.CardTypeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CardTypeLbl.Name = "CardTypeLbl";
            this.CardTypeLbl.Size = new System.Drawing.Size(60, 25);
            this.CardTypeLbl.TabIndex = 1;
            this.CardTypeLbl.Text = "员工发卡";
            this.CardTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardTypeCB
            // 
            this.CardTypeCB.Dock = System.Windows.Forms.DockStyle.Right;
            this.CardTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CardTypeCB.FormattingEnabled = true;
            this.CardTypeCB.Location = new System.Drawing.Point(60, 0);
            this.CardTypeCB.Margin = new System.Windows.Forms.Padding(0);
            this.CardTypeCB.Name = "CardTypeCB";
            this.CardTypeCB.Size = new System.Drawing.Size(150, 25);
            this.CardTypeCB.TabIndex = 2;
            // 
            // CBPanel3
            // 
            this.CBPanel3.Controls.Add(this.QueryTypeLbl);
            this.CBPanel3.Controls.Add(this.QueryTypeCB);
            this.CBPanel3.Location = new System.Drawing.Point(3, 267);
            this.CBPanel3.Name = "CBPanel3";
            this.CBPanel3.Size = new System.Drawing.Size(210, 25);
            this.CBPanel3.TabIndex = 3;
            // 
            // QueryTypeLbl
            // 
            this.QueryTypeLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.QueryTypeLbl.Location = new System.Drawing.Point(0, 0);
            this.QueryTypeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.QueryTypeLbl.Name = "QueryTypeLbl";
            this.QueryTypeLbl.Size = new System.Drawing.Size(60, 25);
            this.QueryTypeLbl.TabIndex = 1;
            this.QueryTypeLbl.Text = "模糊筛选";
            this.QueryTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // QueryTypeCB
            // 
            this.QueryTypeCB.Dock = System.Windows.Forms.DockStyle.Right;
            this.QueryTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.QueryTypeCB.FormattingEnabled = true;
            this.QueryTypeCB.Location = new System.Drawing.Point(60, 0);
            this.QueryTypeCB.Margin = new System.Windows.Forms.Padding(0);
            this.QueryTypeCB.Name = "QueryTypeCB";
            this.QueryTypeCB.Size = new System.Drawing.Size(150, 25);
            this.QueryTypeCB.TabIndex = 2;
            this.QueryTypeCB.Tag = "";
            // 
            // CBPanel4
            // 
            this.CBPanel4.Controls.Add(this.QueryTypeTB);
            this.CBPanel4.Location = new System.Drawing.Point(3, 298);
            this.CBPanel4.Name = "CBPanel4";
            this.CBPanel4.Size = new System.Drawing.Size(210, 80);
            this.CBPanel4.TabIndex = 4;
            // 
            // QueryTypeTB
            // 
            this.QueryTypeTB.Dock = System.Windows.Forms.DockStyle.Right;
            this.QueryTypeTB.Location = new System.Drawing.Point(60, 0);
            this.QueryTypeTB.Margin = new System.Windows.Forms.Padding(0);
            this.QueryTypeTB.Multiline = true;
            this.QueryTypeTB.Name = "QueryTypeTB";
            this.QueryTypeTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QueryTypeTB.Size = new System.Drawing.Size(150, 80);
            this.QueryTypeTB.TabIndex = 2;
            // 
            // CBPanel6
            // 
            this.CBPanel6.Controls.Add(this.QueryBtn);
            this.CBPanel6.Location = new System.Drawing.Point(3, 384);
            this.CBPanel6.Name = "CBPanel6";
            this.CBPanel6.Size = new System.Drawing.Size(210, 30);
            this.CBPanel6.TabIndex = 6;
            // 
            // QueryBtn
            // 
            this.QueryBtn.Location = new System.Drawing.Point(60, 0);
            this.QueryBtn.Margin = new System.Windows.Forms.Padding(0);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(150, 30);
            this.QueryBtn.TabIndex = 2;
            this.QueryBtn.Text = "查询(&Q)";
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // RecordContextMenuStrip
            // 
            this.RecordContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RecMenuItem1});
            this.RecordContextMenuStrip.Name = "contextMenuStrip1";
            this.RecordContextMenuStrip.Size = new System.Drawing.Size(153, 48);
            this.RecordContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.RecordContextMenuStrip_Opening);
            // 
            // RecMenuItem1
            // 
            this.RecMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.disk;
            this.RecMenuItem1.Name = "RecMenuItem1";
            this.RecMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.RecMenuItem1.Text = "数据导出";
            this.RecMenuItem1.Click += new System.EventHandler(this.RecMenuItem1_Click);
            // 
            // OutEmployeeReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainSplitContainer);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "OutEmployeeReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "外协报表";
            this.Load += new System.EventHandler(this.OutEmployeeReportForm_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmpGridView)).EndInit();
            this.ConditionPanel.ResumeLayout(false);
            this.ConditionFlowLayoutPanel.ResumeLayout(false);
            this.CBPanel1.ResumeLayout(false);
            this.CBPanel2.ResumeLayout(false);
            this.CBPanel5.ResumeLayout(false);
            this.CBPanel3.ResumeLayout(false);
            this.CBPanel4.ResumeLayout(false);
            this.CBPanel4.PerformLayout();
            this.CBPanel6.ResumeLayout(false);
            this.RecordContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.GroupBox ConditionPanel;
        private System.Windows.Forms.FlowLayoutPanel ConditionFlowLayoutPanel;
        private System.Windows.Forms.Panel CBPanel1;
        private System.Windows.Forms.ListBox DeptLB;
        private System.Windows.Forms.Label DeptNameLbl;
        private System.Windows.Forms.Panel CBPanel2;
        private System.Windows.Forms.Button DeptBtn;
        private System.Windows.Forms.Panel CBPanel5;
        private System.Windows.Forms.Label CardTypeLbl;
        private System.Windows.Forms.ComboBox CardTypeCB;
        private System.Windows.Forms.Panel CBPanel3;
        private System.Windows.Forms.Label QueryTypeLbl;
        private System.Windows.Forms.ComboBox QueryTypeCB;
        private System.Windows.Forms.Panel CBPanel4;
        private System.Windows.Forms.TextBox QueryTypeTB;
        private System.Windows.Forms.Panel CBPanel6;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.DataGridView EmpGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardAddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardIssueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HometownColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OfficePhoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobilePhoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardSnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardAuthColumn;
        private System.Windows.Forms.ContextMenuStrip RecordContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RecMenuItem1;
    }
}