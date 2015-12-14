namespace Delta.MPS.AccessSystem
{
    partial class BatchOutCardsForm
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
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.LeftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.EmpGridView = new System.Windows.Forms.DataGridView();
            this.EIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EEIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EENameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDeptColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PEIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.OpMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.SetEmpBtn = new System.Windows.Forms.Button();
            this.RightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RightBottomPanel = new System.Windows.Forms.GroupBox();
            this.CardsGridView = new System.Windows.Forms.DataGridView();
            this.SIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SENameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardSnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDeptColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginReasonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SignContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SignToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.SignToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SignToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.RightTopPanel = new System.Windows.Forms.GroupBox();
            this.RightTopTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BeginReasonCB = new System.Windows.Forms.ComboBox();
            this.CardPwdTB = new System.Windows.Forms.TextBox();
            this.CardPwdLbl = new System.Windows.Forms.Label();
            this.CardUIDLbl = new System.Windows.Forms.Label();
            this.BeginTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.BeginReasonLbl = new System.Windows.Forms.Label();
            this.CardIDLbl = new System.Windows.Forms.Label();
            this.CardTypeLbl = new System.Windows.Forms.Label();
            this.CardTypeCB = new System.Windows.Forms.ComboBox();
            this.CardIDTB = new System.Windows.Forms.TextBox();
            this.BeginTimeLbl = new System.Windows.Forms.Label();
            this.CardXIDLbl = new System.Windows.Forms.Label();
            this.CardXIDTB = new System.Windows.Forms.TextBox();
            this.OperationPanel = new System.Windows.Forms.Panel();
            this.EnabledXIDCB = new System.Windows.Forms.CheckBox();
            this.ReadBtn = new System.Windows.Forms.Button();
            this.CardUIDTB = new System.Windows.Forms.TextBox();
            this.BeginReasonTB = new System.Windows.Forms.TextBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.lineLbl = new System.Windows.Forms.Label();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.LeftTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmpGridView)).BeginInit();
            this.OperationContext.SuspendLayout();
            this.RightTableLayoutPanel.SuspendLayout();
            this.RightBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardsGridView)).BeginInit();
            this.SignContextMenuStrip.SuspendLayout();
            this.RightTopPanel.SuspendLayout();
            this.RightTopTableLayoutPanel.SuspendLayout();
            this.OperationPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.MainSplitContainer, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 2);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 3;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(784, 512);
            this.MainTableLayoutPanel.TabIndex = 2;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.MainSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.LeftTableLayoutPanel);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.RightTableLayoutPanel);
            this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MainSplitContainer.Size = new System.Drawing.Size(764, 447);
            this.MainSplitContainer.SplitterDistance = 280;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // LeftTableLayoutPanel
            // 
            this.LeftTableLayoutPanel.ColumnCount = 1;
            this.LeftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftTableLayoutPanel.Controls.Add(this.EmpGridView, 0, 2);
            this.LeftTableLayoutPanel.Controls.Add(this.SetEmpBtn, 0, 0);
            this.LeftTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LeftTableLayoutPanel.Name = "LeftTableLayoutPanel";
            this.LeftTableLayoutPanel.RowCount = 3;
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftTableLayoutPanel.Size = new System.Drawing.Size(275, 447);
            this.LeftTableLayoutPanel.TabIndex = 1;
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
            this.EIDColumn,
            this.EEIDColumn,
            this.EENameColumn,
            this.EDeptColumn,
            this.PEIDColumn});
            this.EmpGridView.ContextMenuStrip = this.OperationContext;
            this.EmpGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmpGridView.GridColor = System.Drawing.SystemColors.Control;
            this.EmpGridView.Location = new System.Drawing.Point(0, 30);
            this.EmpGridView.Margin = new System.Windows.Forms.Padding(0);
            this.EmpGridView.Name = "EmpGridView";
            this.EmpGridView.ReadOnly = true;
            this.EmpGridView.RowHeadersVisible = false;
            this.EmpGridView.RowTemplate.Height = 25;
            this.EmpGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EmpGridView.Size = new System.Drawing.Size(275, 417);
            this.EmpGridView.TabIndex = 2;
            this.EmpGridView.VirtualMode = true;
            this.EmpGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.EmpGridView_CellValueNeeded);
            // 
            // EIDColumn
            // 
            this.EIDColumn.HeaderText = "序号";
            this.EIDColumn.Name = "EIDColumn";
            this.EIDColumn.ReadOnly = true;
            this.EIDColumn.Width = 60;
            // 
            // EEIDColumn
            // 
            this.EEIDColumn.HeaderText = "工号";
            this.EEIDColumn.Name = "EEIDColumn";
            this.EEIDColumn.ReadOnly = true;
            this.EEIDColumn.Visible = false;
            // 
            // EENameColumn
            // 
            this.EENameColumn.HeaderText = "姓名";
            this.EENameColumn.Name = "EENameColumn";
            this.EENameColumn.ReadOnly = true;
            // 
            // EDeptColumn
            // 
            this.EDeptColumn.HeaderText = "所属部门";
            this.EDeptColumn.Name = "EDeptColumn";
            this.EDeptColumn.ReadOnly = true;
            // 
            // PEIDColumn
            // 
            this.PEIDColumn.HeaderText = "责任人";
            this.PEIDColumn.Name = "PEIDColumn";
            this.PEIDColumn.ReadOnly = true;
            this.PEIDColumn.Width = 200;
            // 
            // OperationContext
            // 
            this.OperationContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpMenuItem1,
            this.OpToolStripSeparator,
            this.OpMenuItem2});
            this.OperationContext.Name = "OperationContext";
            this.OperationContext.Size = new System.Drawing.Size(137, 54);
            this.OperationContext.Opening += new System.ComponentModel.CancelEventHandler(this.OperationContext_Opening);
            // 
            // OpMenuItem1
            // 
            this.OpMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.remove;
            this.OpMenuItem1.Name = "OpMenuItem1";
            this.OpMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.OpMenuItem1.Text = "移除选中行";
            this.OpMenuItem1.Click += new System.EventHandler(this.OpMenuItem1_Click);
            // 
            // OpToolStripSeparator
            // 
            this.OpToolStripSeparator.Name = "OpToolStripSeparator";
            this.OpToolStripSeparator.Size = new System.Drawing.Size(133, 6);
            // 
            // OpMenuItem2
            // 
            this.OpMenuItem2.Image = global::Delta.MPS.AccessSystem.Properties.Resources.clear;
            this.OpMenuItem2.Name = "OpMenuItem2";
            this.OpMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.OpMenuItem2.Text = "移除所有行";
            this.OpMenuItem2.Click += new System.EventHandler(this.OpMenuItem2_Click);
            // 
            // SetEmpBtn
            // 
            this.SetEmpBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetEmpBtn.Location = new System.Drawing.Point(0, 0);
            this.SetEmpBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SetEmpBtn.Name = "SetEmpBtn";
            this.SetEmpBtn.Size = new System.Drawing.Size(275, 25);
            this.SetEmpBtn.TabIndex = 1;
            this.SetEmpBtn.Text = "选择需要发卡的人员...";
            this.SetEmpBtn.UseVisualStyleBackColor = true;
            this.SetEmpBtn.Click += new System.EventHandler(this.SetEmpBtn_Click);
            // 
            // RightTableLayoutPanel
            // 
            this.RightTableLayoutPanel.ColumnCount = 1;
            this.RightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.Controls.Add(this.RightBottomPanel, 0, 2);
            this.RightTableLayoutPanel.Controls.Add(this.RightTopPanel, 0, 0);
            this.RightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTableLayoutPanel.Location = new System.Drawing.Point(5, 0);
            this.RightTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightTableLayoutPanel.Name = "RightTableLayoutPanel";
            this.RightTableLayoutPanel.RowCount = 3;
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.Size = new System.Drawing.Size(475, 447);
            this.RightTableLayoutPanel.TabIndex = 1;
            // 
            // RightBottomPanel
            // 
            this.RightBottomPanel.Controls.Add(this.CardsGridView);
            this.RightBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightBottomPanel.Location = new System.Drawing.Point(0, 185);
            this.RightBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightBottomPanel.Name = "RightBottomPanel";
            this.RightBottomPanel.Padding = new System.Windows.Forms.Padding(5);
            this.RightBottomPanel.Size = new System.Drawing.Size(475, 262);
            this.RightBottomPanel.TabIndex = 2;
            this.RightBottomPanel.TabStop = false;
            this.RightBottomPanel.Text = "已完成读卡列表";
            // 
            // CardsGridView
            // 
            this.CardsGridView.AllowUserToAddRows = false;
            this.CardsGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CardsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.CardsGridView.BackgroundColor = System.Drawing.Color.White;
            this.CardsGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CardsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CardsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.CardsGridView.ColumnHeadersHeight = 25;
            this.CardsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SIDColumn,
            this.SENameColumn,
            this.CardSnColumn,
            this.SDeptColumn,
            this.CardTypeColumn,
            this.BeginTimeColumn,
            this.BeginReasonColumn});
            this.CardsGridView.ContextMenuStrip = this.SignContextMenuStrip;
            this.CardsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardsGridView.GridColor = System.Drawing.SystemColors.Control;
            this.CardsGridView.Location = new System.Drawing.Point(5, 21);
            this.CardsGridView.Margin = new System.Windows.Forms.Padding(0);
            this.CardsGridView.Name = "CardsGridView";
            this.CardsGridView.ReadOnly = true;
            this.CardsGridView.RowHeadersVisible = false;
            this.CardsGridView.RowTemplate.Height = 25;
            this.CardsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CardsGridView.Size = new System.Drawing.Size(465, 236);
            this.CardsGridView.TabIndex = 1;
            this.CardsGridView.VirtualMode = true;
            this.CardsGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.CardsGridView_CellValueNeeded);
            // 
            // SIDColumn
            // 
            this.SIDColumn.HeaderText = "序号";
            this.SIDColumn.Name = "SIDColumn";
            this.SIDColumn.ReadOnly = true;
            this.SIDColumn.Width = 60;
            // 
            // SENameColumn
            // 
            this.SENameColumn.HeaderText = "持卡人";
            this.SENameColumn.Name = "SENameColumn";
            this.SENameColumn.ReadOnly = true;
            // 
            // CardSnColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardSnColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.CardSnColumn.HeaderText = "卡号";
            this.CardSnColumn.Name = "CardSnColumn";
            this.CardSnColumn.ReadOnly = true;
            // 
            // SDeptColumn
            // 
            this.SDeptColumn.HeaderText = "所属部门";
            this.SDeptColumn.Name = "SDeptColumn";
            this.SDeptColumn.ReadOnly = true;
            // 
            // CardTypeColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardTypeColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.CardTypeColumn.HeaderText = "卡片类型";
            this.CardTypeColumn.Name = "CardTypeColumn";
            this.CardTypeColumn.ReadOnly = true;
            // 
            // BeginTimeColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BeginTimeColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.BeginTimeColumn.HeaderText = "发卡日期";
            this.BeginTimeColumn.Name = "BeginTimeColumn";
            this.BeginTimeColumn.ReadOnly = true;
            // 
            // BeginReasonColumn
            // 
            this.BeginReasonColumn.HeaderText = "发卡原因";
            this.BeginReasonColumn.Name = "BeginReasonColumn";
            this.BeginReasonColumn.ReadOnly = true;
            // 
            // SignContextMenuStrip
            // 
            this.SignContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SignToolStripMenuItem1,
            this.SignToolStripSeparator1,
            this.SignToolStripMenuItem2});
            this.SignContextMenuStrip.Name = "contextMenuStrip1";
            this.SignContextMenuStrip.Size = new System.Drawing.Size(137, 54);
            this.SignContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.SignContextMenuStrip_Opening);
            // 
            // SignToolStripMenuItem1
            // 
            this.SignToolStripMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.redo1;
            this.SignToolStripMenuItem1.Name = "SignToolStripMenuItem1";
            this.SignToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.SignToolStripMenuItem1.Text = "重读选中行";
            this.SignToolStripMenuItem1.Click += new System.EventHandler(this.SignToolStripMenuItem1_Click);
            // 
            // SignToolStripSeparator1
            // 
            this.SignToolStripSeparator1.Name = "SignToolStripSeparator1";
            this.SignToolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // SignToolStripMenuItem2
            // 
            this.SignToolStripMenuItem2.Image = global::Delta.MPS.AccessSystem.Properties.Resources.redo2;
            this.SignToolStripMenuItem2.Name = "SignToolStripMenuItem2";
            this.SignToolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.SignToolStripMenuItem2.Text = "重读所有行";
            this.SignToolStripMenuItem2.Click += new System.EventHandler(this.SignToolStripMenuItem2_Click);
            // 
            // RightTopPanel
            // 
            this.RightTopPanel.Controls.Add(this.RightTopTableLayoutPanel);
            this.RightTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTopPanel.Location = new System.Drawing.Point(0, 0);
            this.RightTopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightTopPanel.Name = "RightTopPanel";
            this.RightTopPanel.Padding = new System.Windows.Forms.Padding(5);
            this.RightTopPanel.Size = new System.Drawing.Size(475, 175);
            this.RightTopPanel.TabIndex = 1;
            this.RightTopPanel.TabStop = false;
            this.RightTopPanel.Text = "基本信息";
            // 
            // RightTopTableLayoutPanel
            // 
            this.RightTopTableLayoutPanel.ColumnCount = 5;
            this.RightTopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.RightTopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightTopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightTopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.RightTopTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightTopTableLayoutPanel.Controls.Add(this.BeginReasonCB, 1, 4);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardPwdTB, 4, 2);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardPwdLbl, 3, 2);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardUIDLbl, 0, 2);
            this.RightTopTableLayoutPanel.Controls.Add(this.BeginTimeDTP, 4, 0);
            this.RightTopTableLayoutPanel.Controls.Add(this.BeginReasonLbl, 0, 4);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardIDLbl, 0, 6);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardTypeLbl, 0, 0);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardTypeCB, 1, 0);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardIDTB, 1, 6);
            this.RightTopTableLayoutPanel.Controls.Add(this.BeginTimeLbl, 3, 0);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardXIDLbl, 0, 8);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardXIDTB, 1, 8);
            this.RightTopTableLayoutPanel.Controls.Add(this.OperationPanel, 3, 6);
            this.RightTopTableLayoutPanel.Controls.Add(this.CardUIDTB, 1, 2);
            this.RightTopTableLayoutPanel.Controls.Add(this.BeginReasonTB, 3, 4);
            this.RightTopTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTopTableLayoutPanel.Location = new System.Drawing.Point(5, 21);
            this.RightTopTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightTopTableLayoutPanel.Name = "RightTopTableLayoutPanel";
            this.RightTopTableLayoutPanel.RowCount = 10;
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightTopTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTopTableLayoutPanel.Size = new System.Drawing.Size(465, 149);
            this.RightTopTableLayoutPanel.TabIndex = 1;
            // 
            // BeginReasonCB
            // 
            this.BeginReasonCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginReasonCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BeginReasonCB.FormattingEnabled = true;
            this.BeginReasonCB.Location = new System.Drawing.Point(80, 60);
            this.BeginReasonCB.Margin = new System.Windows.Forms.Padding(0);
            this.BeginReasonCB.Name = "BeginReasonCB";
            this.BeginReasonCB.Size = new System.Drawing.Size(147, 25);
            this.BeginReasonCB.TabIndex = 10;
            this.BeginReasonCB.SelectedIndexChanged += new System.EventHandler(this.BeginReasonCB_SelectedIndexChanged);
            // 
            // CardPwdTB
            // 
            this.CardPwdTB.BackColor = System.Drawing.Color.White;
            this.CardPwdTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CardPwdTB.Location = new System.Drawing.Point(317, 32);
            this.CardPwdTB.Margin = new System.Windows.Forms.Padding(0);
            this.CardPwdTB.MaxLength = 4;
            this.CardPwdTB.Name = "CardPwdTB";
            this.CardPwdTB.Size = new System.Drawing.Size(148, 23);
            this.CardPwdTB.TabIndex = 8;
            this.CardPwdTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CardPwdTB_KeyPress);
            // 
            // CardPwdLbl
            // 
            this.CardPwdLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardPwdLbl.Location = new System.Drawing.Point(237, 30);
            this.CardPwdLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CardPwdLbl.Name = "CardPwdLbl";
            this.CardPwdLbl.Size = new System.Drawing.Size(80, 25);
            this.CardPwdLbl.TabIndex = 7;
            this.CardPwdLbl.Text = "开门密码(&P):";
            this.CardPwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardUIDLbl
            // 
            this.CardUIDLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardUIDLbl.Location = new System.Drawing.Point(0, 30);
            this.CardUIDLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CardUIDLbl.Name = "CardUIDLbl";
            this.CardUIDLbl.Size = new System.Drawing.Size(80, 25);
            this.CardUIDLbl.TabIndex = 5;
            this.CardUIDLbl.Text = "开门UID(&U):";
            this.CardUIDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BeginTimeDTP
            // 
            this.BeginTimeDTP.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.BeginTimeDTP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BeginTimeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginTimeDTP.Location = new System.Drawing.Point(317, 2);
            this.BeginTimeDTP.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimeDTP.Name = "BeginTimeDTP";
            this.BeginTimeDTP.Size = new System.Drawing.Size(148, 23);
            this.BeginTimeDTP.TabIndex = 4;
            this.BeginTimeDTP.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // BeginReasonLbl
            // 
            this.BeginReasonLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginReasonLbl.Location = new System.Drawing.Point(0, 60);
            this.BeginReasonLbl.Margin = new System.Windows.Forms.Padding(0);
            this.BeginReasonLbl.Name = "BeginReasonLbl";
            this.BeginReasonLbl.Size = new System.Drawing.Size(80, 25);
            this.BeginReasonLbl.TabIndex = 9;
            this.BeginReasonLbl.Text = "发卡原因(&M):";
            this.BeginReasonLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardIDLbl
            // 
            this.CardIDLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardIDLbl.Location = new System.Drawing.Point(0, 90);
            this.CardIDLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CardIDLbl.Name = "CardIDLbl";
            this.CardIDLbl.Size = new System.Drawing.Size(80, 25);
            this.CardIDLbl.TabIndex = 12;
            this.CardIDLbl.Text = "十进制卡号:";
            this.CardIDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardTypeLbl
            // 
            this.CardTypeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardTypeLbl.Location = new System.Drawing.Point(0, 0);
            this.CardTypeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CardTypeLbl.Name = "CardTypeLbl";
            this.CardTypeLbl.Size = new System.Drawing.Size(80, 25);
            this.CardTypeLbl.TabIndex = 1;
            this.CardTypeLbl.Text = "卡片类型(&T):";
            this.CardTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardTypeCB
            // 
            this.CardTypeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CardTypeCB.FormattingEnabled = true;
            this.CardTypeCB.Location = new System.Drawing.Point(80, 0);
            this.CardTypeCB.Margin = new System.Windows.Forms.Padding(0);
            this.CardTypeCB.Name = "CardTypeCB";
            this.CardTypeCB.Size = new System.Drawing.Size(147, 25);
            this.CardTypeCB.TabIndex = 2;
            // 
            // CardIDTB
            // 
            this.CardIDTB.BackColor = System.Drawing.Color.White;
            this.CardIDTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CardIDTB.Location = new System.Drawing.Point(80, 92);
            this.CardIDTB.Margin = new System.Windows.Forms.Padding(0);
            this.CardIDTB.MaxLength = 10;
            this.CardIDTB.Name = "CardIDTB";
            this.CardIDTB.Size = new System.Drawing.Size(147, 23);
            this.CardIDTB.TabIndex = 8;
            this.CardIDTB.TextChanged += new System.EventHandler(this.CardIDTB_TextChanged);
            this.CardIDTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CardIDTB_KeyDown);
            this.CardIDTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CardIDTB_KeyPress);
            // 
            // BeginTimeLbl
            // 
            this.BeginTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginTimeLbl.Location = new System.Drawing.Point(237, 0);
            this.BeginTimeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimeLbl.Name = "BeginTimeLbl";
            this.BeginTimeLbl.Size = new System.Drawing.Size(80, 25);
            this.BeginTimeLbl.TabIndex = 3;
            this.BeginTimeLbl.Text = "发卡日期(&D):";
            this.BeginTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardXIDLbl
            // 
            this.CardXIDLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardXIDLbl.Location = new System.Drawing.Point(0, 120);
            this.CardXIDLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CardXIDLbl.Name = "CardXIDLbl";
            this.CardXIDLbl.Size = new System.Drawing.Size(80, 25);
            this.CardXIDLbl.TabIndex = 13;
            this.CardXIDLbl.Text = "十六进制(&X):";
            this.CardXIDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CardXIDTB
            // 
            this.CardXIDTB.BackColor = System.Drawing.Color.White;
            this.CardXIDTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CardXIDTB.Enabled = false;
            this.CardXIDTB.Location = new System.Drawing.Point(80, 122);
            this.CardXIDTB.Margin = new System.Windows.Forms.Padding(0);
            this.CardXIDTB.MaxLength = 10;
            this.CardXIDTB.Name = "CardXIDTB";
            this.CardXIDTB.Size = new System.Drawing.Size(147, 23);
            this.CardXIDTB.TabIndex = 14;
            this.CardXIDTB.TextChanged += new System.EventHandler(this.CardXIDTB_TextChanged);
            this.CardXIDTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CardXIDTB_KeyDown);
            this.CardXIDTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CardXIDTB_KeyPress);
            // 
            // OperationPanel
            // 
            this.RightTopTableLayoutPanel.SetColumnSpan(this.OperationPanel, 2);
            this.OperationPanel.Controls.Add(this.EnabledXIDCB);
            this.OperationPanel.Controls.Add(this.ReadBtn);
            this.OperationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationPanel.Location = new System.Drawing.Point(237, 90);
            this.OperationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OperationPanel.Name = "OperationPanel";
            this.RightTopTableLayoutPanel.SetRowSpan(this.OperationPanel, 3);
            this.OperationPanel.Size = new System.Drawing.Size(228, 55);
            this.OperationPanel.TabIndex = 15;
            // 
            // EnabledXIDCB
            // 
            this.EnabledXIDCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EnabledXIDCB.Location = new System.Drawing.Point(105, 19);
            this.EnabledXIDCB.Margin = new System.Windows.Forms.Padding(0);
            this.EnabledXIDCB.Name = "EnabledXIDCB";
            this.EnabledXIDCB.Size = new System.Drawing.Size(100, 18);
            this.EnabledXIDCB.TabIndex = 2;
            this.EnabledXIDCB.Text = "十六进制卡号";
            this.EnabledXIDCB.UseVisualStyleBackColor = true;
            this.EnabledXIDCB.CheckedChanged += new System.EventHandler(this.EnabledXIDCB_CheckedChanged);
            // 
            // ReadBtn
            // 
            this.ReadBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ReadBtn.Location = new System.Drawing.Point(0, 12);
            this.ReadBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(90, 30);
            this.ReadBtn.TabIndex = 1;
            this.ReadBtn.Tag = "0";
            this.ReadBtn.Text = "开始读卡(&R)";
            this.ReadBtn.UseVisualStyleBackColor = true;
            this.ReadBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // CardUIDTB
            // 
            this.CardUIDTB.BackColor = System.Drawing.Color.White;
            this.CardUIDTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CardUIDTB.Location = new System.Drawing.Point(80, 32);
            this.CardUIDTB.Margin = new System.Windows.Forms.Padding(0);
            this.CardUIDTB.MaxLength = 8;
            this.CardUIDTB.Name = "CardUIDTB";
            this.CardUIDTB.Size = new System.Drawing.Size(147, 23);
            this.CardUIDTB.TabIndex = 6;
            this.CardUIDTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CardUIDTB_KeyPress);
            // 
            // BeginReasonTB
            // 
            this.BeginReasonTB.BackColor = System.Drawing.Color.White;
            this.RightTopTableLayoutPanel.SetColumnSpan(this.BeginReasonTB, 2);
            this.BeginReasonTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BeginReasonTB.Location = new System.Drawing.Point(237, 62);
            this.BeginReasonTB.Margin = new System.Windows.Forms.Padding(0);
            this.BeginReasonTB.Name = "BeginReasonTB";
            this.BeginReasonTB.Size = new System.Drawing.Size(228, 23);
            this.BeginReasonTB.TabIndex = 11;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.OKBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Controls.Add(this.lineLbl);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 462);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(764, 50);
            this.BottomPanel.TabIndex = 2;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OKBtn.Location = new System.Drawing.Point(574, 10);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(90, 30);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "保存(&S)";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(674, 10);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineLbl.Location = new System.Drawing.Point(0, 0);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(764, 2);
            this.lineLbl.TabIndex = 4;
            // 
            // BatchOutCardsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "BatchOutCardsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量发卡管理 - [外协人员]";
            this.Load += new System.EventHandler(this.BatchOutCardsForm_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.LeftTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmpGridView)).EndInit();
            this.OperationContext.ResumeLayout(false);
            this.RightTableLayoutPanel.ResumeLayout(false);
            this.RightBottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CardsGridView)).EndInit();
            this.SignContextMenuStrip.ResumeLayout(false);
            this.RightTopPanel.ResumeLayout(false);
            this.RightTopTableLayoutPanel.ResumeLayout(false);
            this.RightTopTableLayoutPanel.PerformLayout();
            this.OperationPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.TableLayoutPanel LeftTableLayoutPanel;
        private System.Windows.Forms.DataGridView EmpGridView;
        private System.Windows.Forms.Button SetEmpBtn;
        private System.Windows.Forms.TableLayoutPanel RightTableLayoutPanel;
        private System.Windows.Forms.GroupBox RightBottomPanel;
        private System.Windows.Forms.DataGridView CardsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SENameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardSnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDeptColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginReasonColumn;
        private System.Windows.Forms.GroupBox RightTopPanel;
        private System.Windows.Forms.TableLayoutPanel RightTopTableLayoutPanel;
        private System.Windows.Forms.ComboBox BeginReasonCB;
        private System.Windows.Forms.TextBox CardPwdTB;
        private System.Windows.Forms.Label CardPwdLbl;
        private System.Windows.Forms.Label CardUIDLbl;
        private System.Windows.Forms.DateTimePicker BeginTimeDTP;
        private System.Windows.Forms.Label BeginReasonLbl;
        private System.Windows.Forms.Label CardIDLbl;
        private System.Windows.Forms.Label CardTypeLbl;
        private System.Windows.Forms.ComboBox CardTypeCB;
        private System.Windows.Forms.TextBox CardIDTB;
        private System.Windows.Forms.Label BeginTimeLbl;
        private System.Windows.Forms.Label CardXIDLbl;
        private System.Windows.Forms.TextBox CardXIDTB;
        private System.Windows.Forms.Panel OperationPanel;
        private System.Windows.Forms.CheckBox EnabledXIDCB;
        private System.Windows.Forms.Button ReadBtn;
        private System.Windows.Forms.TextBox CardUIDTB;
        private System.Windows.Forms.TextBox BeginReasonTB;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.ContextMenuStrip SignContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SignToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator SignToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SignToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip OperationContext;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem1;
        private System.Windows.Forms.ToolStripSeparator OpToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EEIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EENameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDeptColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PEIDColumn;
    }
}