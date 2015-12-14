namespace Delta.MPS.AccessSystem
{
    partial class HisCardRecordsForm
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
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.HisCardGridView = new System.Windows.Forms.DataGridView();
            this.HCIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCRecIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCArea2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCArea3Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCStaNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCDevIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCDevNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCDescColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCCardSnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCWorkerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCWorkerTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCDeptColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RecMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ConditionPanel = new System.Windows.Forms.GroupBox();
            this.ConditionFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CBPanel1 = new System.Windows.Forms.Panel();
            this.Area2NameLbl = new System.Windows.Forms.Label();
            this.Area2NameCB = new System.Windows.Forms.ComboBox();
            this.CBPanel2 = new System.Windows.Forms.Panel();
            this.Area3NameLbl = new System.Windows.Forms.Label();
            this.Area3NameCB = new System.Windows.Forms.ComboBox();
            this.CBPanel3 = new System.Windows.Forms.Panel();
            this.StaNameLbl = new System.Windows.Forms.Label();
            this.StaNameCB = new System.Windows.Forms.ComboBox();
            this.CBPanel4 = new System.Windows.Forms.Panel();
            this.DevNameLbl = new System.Windows.Forms.Label();
            this.DevNameCB = new System.Windows.Forms.ComboBox();
            this.CBPanel5 = new System.Windows.Forms.Panel();
            this.BeginFromTime = new System.Windows.Forms.DateTimePicker();
            this.AlarmTimeLbl = new System.Windows.Forms.Label();
            this.CBPanel6 = new System.Windows.Forms.Panel();
            this.BeginToTime = new System.Windows.Forms.DateTimePicker();
            this.CBPanel7 = new System.Windows.Forms.Panel();
            this.QueryTypeLbl = new System.Windows.Forms.Label();
            this.QueryTypeCB = new System.Windows.Forms.ComboBox();
            this.CBPanel8 = new System.Windows.Forms.Panel();
            this.QueryTypeTB = new System.Windows.Forms.TextBox();
            this.CBPanel9 = new System.Windows.Forms.Panel();
            this.RecTypeCL = new System.Windows.Forms.CheckedListBox();
            this.RecTypeLbl = new System.Windows.Forms.Label();
            this.CBPanel10 = new System.Windows.Forms.Panel();
            this.QueryBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HisCardGridView)).BeginInit();
            this.RecordContextMenuStrip.SuspendLayout();
            this.ConditionPanel.SuspendLayout();
            this.ConditionFlowLayoutPanel.SuspendLayout();
            this.CBPanel1.SuspendLayout();
            this.CBPanel2.SuspendLayout();
            this.CBPanel3.SuspendLayout();
            this.CBPanel4.SuspendLayout();
            this.CBPanel5.SuspendLayout();
            this.CBPanel6.SuspendLayout();
            this.CBPanel7.SuspendLayout();
            this.CBPanel8.SuspendLayout();
            this.CBPanel9.SuspendLayout();
            this.CBPanel10.SuspendLayout();
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
            this.MainSplitContainer.Panel1.Controls.Add(this.HisCardGridView);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.ConditionPanel);
            this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.MainSplitContainer.Size = new System.Drawing.Size(784, 512);
            this.MainSplitContainer.SplitterDistance = 534;
            this.MainSplitContainer.TabIndex = 2;
            // 
            // HisCardGridView
            // 
            this.HisCardGridView.AllowUserToAddRows = false;
            this.HisCardGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.HisCardGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.HisCardGridView.BackgroundColor = System.Drawing.Color.White;
            this.HisCardGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HisCardGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.HisCardGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.HisCardGridView.ColumnHeadersHeight = 25;
            this.HisCardGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HCIDColumn,
            this.HCRecIDColumn,
            this.HCArea2Column,
            this.HCArea3Column,
            this.HCStaNameColumn,
            this.HCDevIDColumn,
            this.HCDevNameColumn,
            this.HCDescColumn,
            this.HCCardSnColumn,
            this.HCTimeColumn,
            this.HCWorkerColumn,
            this.HCWorkerTypeColumn,
            this.HCDeptColumn});
            this.HisCardGridView.ContextMenuStrip = this.RecordContextMenuStrip;
            this.HisCardGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HisCardGridView.GridColor = System.Drawing.SystemColors.Control;
            this.HisCardGridView.Location = new System.Drawing.Point(5, 5);
            this.HisCardGridView.Margin = new System.Windows.Forms.Padding(0);
            this.HisCardGridView.MultiSelect = false;
            this.HisCardGridView.Name = "HisCardGridView";
            this.HisCardGridView.ReadOnly = true;
            this.HisCardGridView.RowHeadersVisible = false;
            this.HisCardGridView.RowTemplate.Height = 25;
            this.HisCardGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HisCardGridView.Size = new System.Drawing.Size(524, 502);
            this.HisCardGridView.TabIndex = 2;
            this.HisCardGridView.VirtualMode = true;
            this.HisCardGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.HisCardGridView_CellValueNeeded);
            // 
            // HCIDColumn
            // 
            this.HCIDColumn.HeaderText = "序号";
            this.HCIDColumn.Name = "HCIDColumn";
            this.HCIDColumn.ReadOnly = true;
            this.HCIDColumn.Width = 60;
            // 
            // HCRecIDColumn
            // 
            this.HCRecIDColumn.HeaderText = "标识";
            this.HCRecIDColumn.Name = "HCRecIDColumn";
            this.HCRecIDColumn.ReadOnly = true;
            this.HCRecIDColumn.Visible = false;
            // 
            // HCArea2Column
            // 
            this.HCArea2Column.HeaderText = "所属地区";
            this.HCArea2Column.Name = "HCArea2Column";
            this.HCArea2Column.ReadOnly = true;
            // 
            // HCArea3Column
            // 
            this.HCArea3Column.HeaderText = "所属县市";
            this.HCArea3Column.Name = "HCArea3Column";
            this.HCArea3Column.ReadOnly = true;
            // 
            // HCStaNameColumn
            // 
            this.HCStaNameColumn.HeaderText = "所属局站";
            this.HCStaNameColumn.Name = "HCStaNameColumn";
            this.HCStaNameColumn.ReadOnly = true;
            // 
            // HCDevIDColumn
            // 
            this.HCDevIDColumn.HeaderText = "设备编号";
            this.HCDevIDColumn.Name = "HCDevIDColumn";
            this.HCDevIDColumn.ReadOnly = true;
            // 
            // HCDevNameColumn
            // 
            this.HCDevNameColumn.HeaderText = "设备名称";
            this.HCDevNameColumn.Name = "HCDevNameColumn";
            this.HCDevNameColumn.ReadOnly = true;
            // 
            // HCDescColumn
            // 
            this.HCDescColumn.HeaderText = "刷卡描述";
            this.HCDescColumn.Name = "HCDescColumn";
            this.HCDescColumn.ReadOnly = true;
            // 
            // HCCardSnColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HCCardSnColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.HCCardSnColumn.HeaderText = "刷卡卡号";
            this.HCCardSnColumn.Name = "HCCardSnColumn";
            this.HCCardSnColumn.ReadOnly = true;
            // 
            // HCTimeColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HCTimeColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.HCTimeColumn.HeaderText = "刷卡时间";
            this.HCTimeColumn.Name = "HCTimeColumn";
            this.HCTimeColumn.ReadOnly = true;
            this.HCTimeColumn.Width = 150;
            // 
            // HCWorkerColumn
            // 
            this.HCWorkerColumn.HeaderText = "刷卡人员";
            this.HCWorkerColumn.Name = "HCWorkerColumn";
            this.HCWorkerColumn.ReadOnly = true;
            // 
            // HCWorkerTypeColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.HCWorkerTypeColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.HCWorkerTypeColumn.HeaderText = "人员类型";
            this.HCWorkerTypeColumn.Name = "HCWorkerTypeColumn";
            this.HCWorkerTypeColumn.ReadOnly = true;
            // 
            // HCDeptColumn
            // 
            this.HCDeptColumn.HeaderText = "所属部门";
            this.HCDeptColumn.Name = "HCDeptColumn";
            this.HCDeptColumn.ReadOnly = true;
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
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel3);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel4);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel5);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel6);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel9);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel7);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel8);
            this.ConditionFlowLayoutPanel.Controls.Add(this.CBPanel10);
            this.ConditionFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionFlowLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.ConditionFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionFlowLayoutPanel.Name = "ConditionFlowLayoutPanel";
            this.ConditionFlowLayoutPanel.Size = new System.Drawing.Size(230, 480);
            this.ConditionFlowLayoutPanel.TabIndex = 0;
            // 
            // CBPanel1
            // 
            this.CBPanel1.Controls.Add(this.Area2NameLbl);
            this.CBPanel1.Controls.Add(this.Area2NameCB);
            this.CBPanel1.Location = new System.Drawing.Point(3, 3);
            this.CBPanel1.Name = "CBPanel1";
            this.CBPanel1.Size = new System.Drawing.Size(210, 25);
            this.CBPanel1.TabIndex = 1;
            // 
            // Area2NameLbl
            // 
            this.Area2NameLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.Area2NameLbl.Location = new System.Drawing.Point(0, 0);
            this.Area2NameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.Area2NameLbl.Name = "Area2NameLbl";
            this.Area2NameLbl.Size = new System.Drawing.Size(60, 25);
            this.Area2NameLbl.TabIndex = 1;
            this.Area2NameLbl.Text = "地区名称";
            this.Area2NameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Area2NameCB
            // 
            this.Area2NameCB.Dock = System.Windows.Forms.DockStyle.Right;
            this.Area2NameCB.FormattingEnabled = true;
            this.Area2NameCB.Location = new System.Drawing.Point(60, 0);
            this.Area2NameCB.Margin = new System.Windows.Forms.Padding(0);
            this.Area2NameCB.Name = "Area2NameCB";
            this.Area2NameCB.Size = new System.Drawing.Size(150, 25);
            this.Area2NameCB.TabIndex = 2;
            this.Area2NameCB.SelectedIndexChanged += new System.EventHandler(this.Area2NameCB_SelectedIndexChanged);
            // 
            // CBPanel2
            // 
            this.CBPanel2.Controls.Add(this.Area3NameLbl);
            this.CBPanel2.Controls.Add(this.Area3NameCB);
            this.CBPanel2.Location = new System.Drawing.Point(3, 34);
            this.CBPanel2.Name = "CBPanel2";
            this.CBPanel2.Size = new System.Drawing.Size(210, 25);
            this.CBPanel2.TabIndex = 2;
            // 
            // Area3NameLbl
            // 
            this.Area3NameLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.Area3NameLbl.Location = new System.Drawing.Point(0, 0);
            this.Area3NameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.Area3NameLbl.Name = "Area3NameLbl";
            this.Area3NameLbl.Size = new System.Drawing.Size(60, 25);
            this.Area3NameLbl.TabIndex = 1;
            this.Area3NameLbl.Text = "县市名称";
            this.Area3NameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Area3NameCB
            // 
            this.Area3NameCB.Dock = System.Windows.Forms.DockStyle.Right;
            this.Area3NameCB.FormattingEnabled = true;
            this.Area3NameCB.Location = new System.Drawing.Point(60, 0);
            this.Area3NameCB.Margin = new System.Windows.Forms.Padding(0);
            this.Area3NameCB.Name = "Area3NameCB";
            this.Area3NameCB.Size = new System.Drawing.Size(150, 25);
            this.Area3NameCB.TabIndex = 2;
            this.Area3NameCB.SelectedIndexChanged += new System.EventHandler(this.Area3NameCB_SelectedIndexChanged);
            // 
            // CBPanel3
            // 
            this.CBPanel3.Controls.Add(this.StaNameLbl);
            this.CBPanel3.Controls.Add(this.StaNameCB);
            this.CBPanel3.Location = new System.Drawing.Point(3, 65);
            this.CBPanel3.Name = "CBPanel3";
            this.CBPanel3.Size = new System.Drawing.Size(210, 25);
            this.CBPanel3.TabIndex = 3;
            // 
            // StaNameLbl
            // 
            this.StaNameLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.StaNameLbl.Location = new System.Drawing.Point(0, 0);
            this.StaNameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.StaNameLbl.Name = "StaNameLbl";
            this.StaNameLbl.Size = new System.Drawing.Size(60, 25);
            this.StaNameLbl.TabIndex = 1;
            this.StaNameLbl.Text = "局站名称";
            this.StaNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StaNameCB
            // 
            this.StaNameCB.Dock = System.Windows.Forms.DockStyle.Right;
            this.StaNameCB.FormattingEnabled = true;
            this.StaNameCB.Location = new System.Drawing.Point(60, 0);
            this.StaNameCB.Margin = new System.Windows.Forms.Padding(0);
            this.StaNameCB.Name = "StaNameCB";
            this.StaNameCB.Size = new System.Drawing.Size(150, 25);
            this.StaNameCB.TabIndex = 2;
            this.StaNameCB.SelectedIndexChanged += new System.EventHandler(this.StaNameCB_SelectedIndexChanged);
            // 
            // CBPanel4
            // 
            this.CBPanel4.Controls.Add(this.DevNameLbl);
            this.CBPanel4.Controls.Add(this.DevNameCB);
            this.CBPanel4.Location = new System.Drawing.Point(3, 96);
            this.CBPanel4.Name = "CBPanel4";
            this.CBPanel4.Size = new System.Drawing.Size(210, 25);
            this.CBPanel4.TabIndex = 4;
            // 
            // DevNameLbl
            // 
            this.DevNameLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.DevNameLbl.Location = new System.Drawing.Point(0, 0);
            this.DevNameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.DevNameLbl.Name = "DevNameLbl";
            this.DevNameLbl.Size = new System.Drawing.Size(60, 25);
            this.DevNameLbl.TabIndex = 1;
            this.DevNameLbl.Text = "设备名称";
            this.DevNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DevNameCB
            // 
            this.DevNameCB.Dock = System.Windows.Forms.DockStyle.Right;
            this.DevNameCB.FormattingEnabled = true;
            this.DevNameCB.Location = new System.Drawing.Point(60, 0);
            this.DevNameCB.Margin = new System.Windows.Forms.Padding(0);
            this.DevNameCB.Name = "DevNameCB";
            this.DevNameCB.Size = new System.Drawing.Size(150, 25);
            this.DevNameCB.TabIndex = 2;
            this.DevNameCB.SelectedIndexChanged += new System.EventHandler(this.DevNameCB_SelectedIndexChanged);
            // 
            // CBPanel5
            // 
            this.CBPanel5.Controls.Add(this.BeginFromTime);
            this.CBPanel5.Controls.Add(this.AlarmTimeLbl);
            this.CBPanel5.Location = new System.Drawing.Point(3, 127);
            this.CBPanel5.Name = "CBPanel5";
            this.CBPanel5.Size = new System.Drawing.Size(210, 25);
            this.CBPanel5.TabIndex = 5;
            // 
            // BeginFromTime
            // 
            this.BeginFromTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.BeginFromTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.BeginFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginFromTime.Location = new System.Drawing.Point(60, 0);
            this.BeginFromTime.Margin = new System.Windows.Forms.Padding(0);
            this.BeginFromTime.Name = "BeginFromTime";
            this.BeginFromTime.Size = new System.Drawing.Size(150, 23);
            this.BeginFromTime.TabIndex = 2;
            this.BeginFromTime.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // AlarmTimeLbl
            // 
            this.AlarmTimeLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.AlarmTimeLbl.Location = new System.Drawing.Point(0, 0);
            this.AlarmTimeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.AlarmTimeLbl.Name = "AlarmTimeLbl";
            this.AlarmTimeLbl.Size = new System.Drawing.Size(60, 25);
            this.AlarmTimeLbl.TabIndex = 1;
            this.AlarmTimeLbl.Text = "刷卡时间";
            this.AlarmTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CBPanel6
            // 
            this.CBPanel6.Controls.Add(this.BeginToTime);
            this.CBPanel6.Location = new System.Drawing.Point(3, 158);
            this.CBPanel6.Name = "CBPanel6";
            this.CBPanel6.Size = new System.Drawing.Size(210, 25);
            this.CBPanel6.TabIndex = 6;
            // 
            // BeginToTime
            // 
            this.BeginToTime.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.BeginToTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.BeginToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginToTime.Location = new System.Drawing.Point(60, 0);
            this.BeginToTime.Margin = new System.Windows.Forms.Padding(0);
            this.BeginToTime.Name = "BeginToTime";
            this.BeginToTime.Size = new System.Drawing.Size(150, 23);
            this.BeginToTime.TabIndex = 2;
            this.BeginToTime.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // CBPanel7
            // 
            this.CBPanel7.Controls.Add(this.QueryTypeLbl);
            this.CBPanel7.Controls.Add(this.QueryTypeCB);
            this.CBPanel7.Location = new System.Drawing.Point(3, 275);
            this.CBPanel7.Name = "CBPanel7";
            this.CBPanel7.Size = new System.Drawing.Size(210, 25);
            this.CBPanel7.TabIndex = 7;
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
            // CBPanel8
            // 
            this.CBPanel8.Controls.Add(this.QueryTypeTB);
            this.CBPanel8.Location = new System.Drawing.Point(3, 306);
            this.CBPanel8.Name = "CBPanel8";
            this.CBPanel8.Size = new System.Drawing.Size(210, 80);
            this.CBPanel8.TabIndex = 8;
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
            // CBPanel9
            // 
            this.CBPanel9.Controls.Add(this.RecTypeCL);
            this.CBPanel9.Controls.Add(this.RecTypeLbl);
            this.CBPanel9.Location = new System.Drawing.Point(3, 189);
            this.CBPanel9.Name = "CBPanel9";
            this.CBPanel9.Size = new System.Drawing.Size(210, 80);
            this.CBPanel9.TabIndex = 9;
            // 
            // RecTypeCL
            // 
            this.RecTypeCL.CheckOnClick = true;
            this.RecTypeCL.Dock = System.Windows.Forms.DockStyle.Right;
            this.RecTypeCL.FormattingEnabled = true;
            this.RecTypeCL.Location = new System.Drawing.Point(60, 0);
            this.RecTypeCL.Margin = new System.Windows.Forms.Padding(0);
            this.RecTypeCL.Name = "RecTypeCL";
            this.RecTypeCL.Size = new System.Drawing.Size(150, 80);
            this.RecTypeCL.TabIndex = 2;
            // 
            // RecTypeLbl
            // 
            this.RecTypeLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.RecTypeLbl.Location = new System.Drawing.Point(0, 0);
            this.RecTypeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.RecTypeLbl.Name = "RecTypeLbl";
            this.RecTypeLbl.Size = new System.Drawing.Size(60, 80);
            this.RecTypeLbl.TabIndex = 1;
            this.RecTypeLbl.Text = "记录类型";
            // 
            // CBPanel10
            // 
            this.CBPanel10.Controls.Add(this.QueryBtn);
            this.CBPanel10.Location = new System.Drawing.Point(3, 392);
            this.CBPanel10.Name = "CBPanel10";
            this.CBPanel10.Size = new System.Drawing.Size(210, 30);
            this.CBPanel10.TabIndex = 10;
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
            // HisCardRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainSplitContainer);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "HisCardRecordsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刷卡记录查询";
            this.Load += new System.EventHandler(this.HisCardRecordsForm_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HisCardGridView)).EndInit();
            this.RecordContextMenuStrip.ResumeLayout(false);
            this.ConditionPanel.ResumeLayout(false);
            this.ConditionFlowLayoutPanel.ResumeLayout(false);
            this.CBPanel1.ResumeLayout(false);
            this.CBPanel2.ResumeLayout(false);
            this.CBPanel3.ResumeLayout(false);
            this.CBPanel4.ResumeLayout(false);
            this.CBPanel5.ResumeLayout(false);
            this.CBPanel6.ResumeLayout(false);
            this.CBPanel7.ResumeLayout(false);
            this.CBPanel8.ResumeLayout(false);
            this.CBPanel8.PerformLayout();
            this.CBPanel9.ResumeLayout(false);
            this.CBPanel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.GroupBox ConditionPanel;
        private System.Windows.Forms.FlowLayoutPanel ConditionFlowLayoutPanel;
        private System.Windows.Forms.Panel CBPanel1;
        private System.Windows.Forms.Label Area2NameLbl;
        private System.Windows.Forms.ComboBox Area2NameCB;
        private System.Windows.Forms.Panel CBPanel2;
        private System.Windows.Forms.Label Area3NameLbl;
        private System.Windows.Forms.ComboBox Area3NameCB;
        private System.Windows.Forms.Panel CBPanel3;
        private System.Windows.Forms.Label StaNameLbl;
        private System.Windows.Forms.ComboBox StaNameCB;
        private System.Windows.Forms.Panel CBPanel4;
        private System.Windows.Forms.Label DevNameLbl;
        private System.Windows.Forms.ComboBox DevNameCB;
        private System.Windows.Forms.Panel CBPanel7;
        private System.Windows.Forms.Label QueryTypeLbl;
        private System.Windows.Forms.ComboBox QueryTypeCB;
        private System.Windows.Forms.Panel CBPanel8;
        private System.Windows.Forms.Panel CBPanel5;
        private System.Windows.Forms.DateTimePicker BeginFromTime;
        private System.Windows.Forms.Label AlarmTimeLbl;
        private System.Windows.Forms.Panel CBPanel6;
        private System.Windows.Forms.DateTimePicker BeginToTime;
        private System.Windows.Forms.Label RecTypeLbl;
        private System.Windows.Forms.Panel CBPanel9;
        private System.Windows.Forms.Panel CBPanel10;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.DataGridView HisCardGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCRecIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCArea2Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCArea3Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCStaNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCDevIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCDevNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCDescColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCCardSnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCWorkerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCWorkerTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCDeptColumn;
        private System.Windows.Forms.CheckedListBox RecTypeCL;
        private System.Windows.Forms.TextBox QueryTypeTB;
        private System.Windows.Forms.ContextMenuStrip RecordContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RecMenuItem1;
    }
}