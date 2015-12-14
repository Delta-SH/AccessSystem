namespace Delta.MPS.AccessSystem
{
    partial class UserManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UsersSplitContainer = new System.Windows.Forms.SplitContainer();
            this.RoleTreeView = new System.Windows.Forms.TreeView();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.RightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.UsersGridViewPanel = new System.Windows.Forms.Panel();
            this.UserGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.LockedOutColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.UIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemarkNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobilePhoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimitDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastLoginDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPasswordChangedDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLockedOutColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastLockoutDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnableColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.OperationPanel = new System.Windows.Forms.Panel();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.lineLbl = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.SubUsersCB = new System.Windows.Forms.CheckBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersSplitContainer)).BeginInit();
            this.UsersSplitContainer.Panel1.SuspendLayout();
            this.UsersSplitContainer.Panel2.SuspendLayout();
            this.UsersSplitContainer.SuspendLayout();
            this.RightTableLayoutPanel.SuspendLayout();
            this.UsersGridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).BeginInit();
            this.OperationContext.SuspendLayout();
            this.OperationPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.UsersSplitContainer, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(784, 512);
            this.MainTableLayoutPanel.TabIndex = 8;
            // 
            // UsersSplitContainer
            // 
            this.UsersSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.UsersSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.UsersSplitContainer.Name = "UsersSplitContainer";
            // 
            // UsersSplitContainer.Panel1
            // 
            this.UsersSplitContainer.Panel1.Controls.Add(this.RoleTreeView);
            this.UsersSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // UsersSplitContainer.Panel2
            // 
            this.UsersSplitContainer.Panel2.Controls.Add(this.RightTableLayoutPanel);
            this.UsersSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.UsersSplitContainer.Size = new System.Drawing.Size(764, 452);
            this.UsersSplitContainer.SplitterDistance = 200;
            this.UsersSplitContainer.TabIndex = 0;
            // 
            // RoleTreeView
            // 
            this.RoleTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleTreeView.HideSelection = false;
            this.RoleTreeView.ImageKey = "Role";
            this.RoleTreeView.ImageList = this.TreeImages;
            this.RoleTreeView.Location = new System.Drawing.Point(0, 0);
            this.RoleTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.RoleTreeView.Name = "RoleTreeView";
            this.RoleTreeView.SelectedImageKey = "Role";
            this.RoleTreeView.Size = new System.Drawing.Size(195, 452);
            this.RoleTreeView.TabIndex = 0;
            this.RoleTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RoleTreeView_AfterSelect);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "Role");
            // 
            // RightTableLayoutPanel
            // 
            this.RightTableLayoutPanel.ColumnCount = 1;
            this.RightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.Controls.Add(this.UsersGridViewPanel, 0, 0);
            this.RightTableLayoutPanel.Controls.Add(this.OperationPanel, 0, 1);
            this.RightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTableLayoutPanel.Location = new System.Drawing.Point(5, 0);
            this.RightTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightTableLayoutPanel.Name = "RightTableLayoutPanel";
            this.RightTableLayoutPanel.RowCount = 2;
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTableLayoutPanel.Size = new System.Drawing.Size(555, 452);
            this.RightTableLayoutPanel.TabIndex = 0;
            // 
            // UsersGridViewPanel
            // 
            this.UsersGridViewPanel.Controls.Add(this.UserGridView);
            this.UsersGridViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersGridViewPanel.Location = new System.Drawing.Point(0, 0);
            this.UsersGridViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.UsersGridViewPanel.Name = "UsersGridViewPanel";
            this.UsersGridViewPanel.Size = new System.Drawing.Size(555, 402);
            this.UsersGridViewPanel.TabIndex = 5;
            // 
            // UserGridView
            // 
            this.UserGridView.AllowUserToAddRows = false;
            this.UserGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.UserGridView.BackgroundColor = System.Drawing.Color.White;
            this.UserGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UserGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.UserGridView.ColumnHeadersHeight = 25;
            this.UserGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.DeleteColumn,
            this.EditColumn,
            this.LockedOutColumn,
            this.UIDColumn,
            this.NameColumn,
            this.RoleNameColumn,
            this.RemarkNameColumn,
            this.CommentColumn,
            this.MobilePhoneColumn,
            this.EmailColumn,
            this.CreateDateColumn,
            this.LimitDateColumn,
            this.LastLoginDateColumn,
            this.LastPasswordChangedDateColumn,
            this.IsLockedOutColumn,
            this.LastLockoutDateColumn,
            this.EnableColumn});
            this.UserGridView.ContextMenuStrip = this.OperationContext;
            this.UserGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserGridView.GridColor = System.Drawing.SystemColors.Control;
            this.UserGridView.Location = new System.Drawing.Point(0, 0);
            this.UserGridView.Margin = new System.Windows.Forms.Padding(0);
            this.UserGridView.Name = "UserGridView";
            this.UserGridView.ReadOnly = true;
            this.UserGridView.RowHeadersVisible = false;
            this.UserGridView.RowTemplate.Height = 25;
            this.UserGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserGridView.Size = new System.Drawing.Size(555, 402);
            this.UserGridView.TabIndex = 0;
            this.UserGridView.VirtualMode = true;
            this.UserGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserGridView_CellContentClick);
            this.UserGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.UserGridView_CellValueNeeded);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "序号";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 60;
            // 
            // DeleteColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeleteColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.DeleteColumn.HeaderText = "";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.ReadOnly = true;
            this.DeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeleteColumn.Text = "删除";
            this.DeleteColumn.UseColumnTextForLinkValue = true;
            this.DeleteColumn.Width = 60;
            // 
            // EditColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EditColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.EditColumn.HeaderText = "";
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            this.EditColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EditColumn.Text = "编辑";
            this.EditColumn.UseColumnTextForLinkValue = true;
            this.EditColumn.Width = 60;
            // 
            // LockedOutColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LockedOutColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.LockedOutColumn.HeaderText = "";
            this.LockedOutColumn.Name = "LockedOutColumn";
            this.LockedOutColumn.ReadOnly = true;
            this.LockedOutColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LockedOutColumn.Text = "";
            this.LockedOutColumn.Width = 60;
            // 
            // UIDColumn
            // 
            this.UIDColumn.HeaderText = "用户标识";
            this.UIDColumn.Name = "UIDColumn";
            this.UIDColumn.ReadOnly = true;
            this.UIDColumn.Visible = false;
            // 
            // NameColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.NameColumn.HeaderText = "用户名称";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // RoleNameColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RoleNameColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.RoleNameColumn.HeaderText = "所属角色";
            this.RoleNameColumn.Name = "RoleNameColumn";
            this.RoleNameColumn.ReadOnly = true;
            // 
            // RemarkNameColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RemarkNameColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.RemarkNameColumn.HeaderText = "备注名称";
            this.RemarkNameColumn.Name = "RemarkNameColumn";
            this.RemarkNameColumn.ReadOnly = true;
            // 
            // CommentColumn
            // 
            this.CommentColumn.HeaderText = "用户描述";
            this.CommentColumn.Name = "CommentColumn";
            this.CommentColumn.ReadOnly = true;
            // 
            // MobilePhoneColumn
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MobilePhoneColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.MobilePhoneColumn.HeaderText = "手机";
            this.MobilePhoneColumn.Name = "MobilePhoneColumn";
            this.MobilePhoneColumn.ReadOnly = true;
            // 
            // EmailColumn
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EmailColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.EmailColumn.HeaderText = "Email";
            this.EmailColumn.Name = "EmailColumn";
            this.EmailColumn.ReadOnly = true;
            this.EmailColumn.Width = 150;
            // 
            // CreateDateColumn
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CreateDateColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.CreateDateColumn.HeaderText = "创建时间";
            this.CreateDateColumn.Name = "CreateDateColumn";
            this.CreateDateColumn.ReadOnly = true;
            this.CreateDateColumn.Width = 150;
            // 
            // LimitDateColumn
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LimitDateColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.LimitDateColumn.HeaderText = "有效日期";
            this.LimitDateColumn.Name = "LimitDateColumn";
            this.LimitDateColumn.ReadOnly = true;
            this.LimitDateColumn.Width = 150;
            // 
            // LastLoginDateColumn
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LastLoginDateColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.LastLoginDateColumn.HeaderText = "最后登录时间";
            this.LastLoginDateColumn.Name = "LastLoginDateColumn";
            this.LastLoginDateColumn.ReadOnly = true;
            this.LastLoginDateColumn.Width = 150;
            // 
            // LastPasswordChangedDateColumn
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LastPasswordChangedDateColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.LastPasswordChangedDateColumn.HeaderText = "修改密码时间";
            this.LastPasswordChangedDateColumn.Name = "LastPasswordChangedDateColumn";
            this.LastPasswordChangedDateColumn.ReadOnly = true;
            this.LastPasswordChangedDateColumn.Width = 150;
            // 
            // IsLockedOutColumn
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IsLockedOutColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.IsLockedOutColumn.HeaderText = "锁定状态";
            this.IsLockedOutColumn.Name = "IsLockedOutColumn";
            this.IsLockedOutColumn.ReadOnly = true;
            this.IsLockedOutColumn.Width = 60;
            // 
            // LastLockoutDateColumn
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LastLockoutDateColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.LastLockoutDateColumn.HeaderText = "锁定时间";
            this.LastLockoutDateColumn.Name = "LastLockoutDateColumn";
            this.LastLockoutDateColumn.ReadOnly = true;
            this.LastLockoutDateColumn.Width = 150;
            // 
            // EnableColumn
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EnableColumn.DefaultCellStyle = dataGridViewCellStyle17;
            this.EnableColumn.HeaderText = "状态";
            this.EnableColumn.Name = "EnableColumn";
            this.EnableColumn.ReadOnly = true;
            this.EnableColumn.Width = 60;
            // 
            // OperationContext
            // 
            this.OperationContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpMenuItem1,
            this.OpMenuItem2,
            this.OpSeparator1,
            this.OpMenuItem3});
            this.OperationContext.Name = "OperationContext";
            this.OperationContext.Size = new System.Drawing.Size(153, 98);
            this.OperationContext.Opening += new System.ComponentModel.CancelEventHandler(this.OperationContext_Opening);
            // 
            // OpMenuItem1
            // 
            this.OpMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.remove;
            this.OpMenuItem1.Name = "OpMenuItem1";
            this.OpMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.OpMenuItem1.Text = "删除选中行";
            this.OpMenuItem1.Click += new System.EventHandler(this.OpMenuItem1_Click);
            // 
            // OpMenuItem2
            // 
            this.OpMenuItem2.Image = global::Delta.MPS.AccessSystem.Properties.Resources.clear;
            this.OpMenuItem2.Name = "OpMenuItem2";
            this.OpMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.OpMenuItem2.Text = "删除所有行";
            this.OpMenuItem2.Click += new System.EventHandler(this.OpMenuItem2_Click);
            // 
            // OpSeparator1
            // 
            this.OpSeparator1.Name = "OpSeparator1";
            this.OpSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // OpMenuItem3
            // 
            this.OpMenuItem3.Image = global::Delta.MPS.AccessSystem.Properties.Resources.disk;
            this.OpMenuItem3.Name = "OpMenuItem3";
            this.OpMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.OpMenuItem3.Text = "数据导出";
            this.OpMenuItem3.Click += new System.EventHandler(this.OpMenuItem3_Click);
            // 
            // OperationPanel
            // 
            this.OperationPanel.Controls.Add(this.ExportBtn);
            this.OperationPanel.Controls.Add(this.lineLbl);
            this.OperationPanel.Controls.Add(this.AddBtn);
            this.OperationPanel.Controls.Add(this.DeleteBtn);
            this.OperationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationPanel.Location = new System.Drawing.Point(0, 402);
            this.OperationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OperationPanel.Name = "OperationPanel";
            this.OperationPanel.Size = new System.Drawing.Size(555, 50);
            this.OperationPanel.TabIndex = 0;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExportBtn.Location = new System.Drawing.Point(465, 10);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(90, 30);
            this.ExportBtn.TabIndex = 2;
            this.ExportBtn.Text = "数据导出(&E)";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lineLbl.Location = new System.Drawing.Point(0, 48);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(555, 2);
            this.lineLbl.TabIndex = 3;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddBtn.Location = new System.Drawing.Point(0, 10);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(90, 30);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "添加(&A)...";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeleteBtn.Location = new System.Drawing.Point(96, 10);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(90, 30);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "全部删除(&D)";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.SubUsersCB);
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 462);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(764, 50);
            this.BottomPanel.TabIndex = 1;
            // 
            // SubUsersCB
            // 
            this.SubUsersCB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SubUsersCB.BackColor = System.Drawing.Color.Transparent;
            this.SubUsersCB.Location = new System.Drawing.Point(0, 0);
            this.SubUsersCB.Margin = new System.Windows.Forms.Padding(0);
            this.SubUsersCB.Name = "SubUsersCB";
            this.SubUsersCB.Size = new System.Drawing.Size(180, 20);
            this.SubUsersCB.TabIndex = 1;
            this.SubUsersCB.Text = "显示所有子角色的用户";
            this.SubUsersCB.UseVisualStyleBackColor = false;
            this.SubUsersCB.CheckedChanged += new System.EventHandler(this.SubUsersCB_CheckedChanged);
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
            // UserManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "UserManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserManagerForm_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.UsersSplitContainer.Panel1.ResumeLayout(false);
            this.UsersSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersSplitContainer)).EndInit();
            this.UsersSplitContainer.ResumeLayout(false);
            this.RightTableLayoutPanel.ResumeLayout(false);
            this.UsersGridViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserGridView)).EndInit();
            this.OperationContext.ResumeLayout(false);
            this.OperationPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.SplitContainer UsersSplitContainer;
        private System.Windows.Forms.TreeView RoleTreeView;
        private System.Windows.Forms.TableLayoutPanel RightTableLayoutPanel;
        private System.Windows.Forms.Panel UsersGridViewPanel;
        private System.Windows.Forms.Panel OperationPanel;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.DataGridView UserGridView;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.CheckBox SubUsersCB;
        private System.Windows.Forms.ContextMenuStrip OperationContext;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem2;
        private System.Windows.Forms.ToolStripSeparator OpSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteColumn;
        private System.Windows.Forms.DataGridViewLinkColumn EditColumn;
        private System.Windows.Forms.DataGridViewLinkColumn LockedOutColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoleNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemarkNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobilePhoneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimitDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastLoginDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPasswordChangedDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsLockedOutColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastLockoutDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnableColumn;

    }
}