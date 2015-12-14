namespace Delta.MPS.AccessSystem
{
    partial class OrgCardManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrgCardManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.EmpTreeView = new System.Windows.Forms.TreeView();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.SubCardCB = new System.Windows.Forms.CheckBox();
            this.RightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CardsGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardSnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginReasonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnabledColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.SignedBottomPanel = new System.Windows.Forms.Panel();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.lineLbl = new System.Windows.Forms.Label();
            this.BatchAddBtn = new System.Windows.Forms.Button();
            this.FindCardBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.RightTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardsGridView)).BeginInit();
            this.OperationContext.SuspendLayout();
            this.SignedBottomPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.TreeViewContextMenuStrip.SuspendLayout();
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
            this.MainTableLayoutPanel.TabIndex = 1;
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
            this.MainSplitContainer.Panel1.Controls.Add(this.EmpTreeView);
            this.MainSplitContainer.Panel1.Controls.Add(this.SubCardCB);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.RightTableLayoutPanel);
            this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MainSplitContainer.Size = new System.Drawing.Size(764, 447);
            this.MainSplitContainer.SplitterDistance = 220;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // EmpTreeView
            // 
            this.EmpTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.EmpTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmpTreeView.HideSelection = false;
            this.EmpTreeView.ImageKey = "Department";
            this.EmpTreeView.ImageList = this.TreeImages;
            this.EmpTreeView.Location = new System.Drawing.Point(0, 0);
            this.EmpTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.EmpTreeView.Name = "EmpTreeView";
            this.EmpTreeView.SelectedImageKey = "Department";
            this.EmpTreeView.Size = new System.Drawing.Size(215, 427);
            this.EmpTreeView.TabIndex = 1;
            this.EmpTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.EmpTreeView_AfterSelect);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "Department");
            this.TreeImages.Images.SetKeyName(1, "Employee");
            // 
            // SubCardCB
            // 
            this.SubCardCB.BackColor = System.Drawing.Color.Transparent;
            this.SubCardCB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SubCardCB.Location = new System.Drawing.Point(0, 427);
            this.SubCardCB.Margin = new System.Windows.Forms.Padding(0);
            this.SubCardCB.Name = "SubCardCB";
            this.SubCardCB.Size = new System.Drawing.Size(215, 20);
            this.SubCardCB.TabIndex = 2;
            this.SubCardCB.Text = "显示所有子级部门的卡片信息";
            this.SubCardCB.UseVisualStyleBackColor = false;
            this.SubCardCB.CheckedChanged += new System.EventHandler(this.SubCardCB_CheckedChanged);
            // 
            // RightTableLayoutPanel
            // 
            this.RightTableLayoutPanel.ColumnCount = 1;
            this.RightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.Controls.Add(this.CardsGridView, 0, 0);
            this.RightTableLayoutPanel.Controls.Add(this.SignedBottomPanel, 0, 1);
            this.RightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTableLayoutPanel.Location = new System.Drawing.Point(5, 0);
            this.RightTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightTableLayoutPanel.Name = "RightTableLayoutPanel";
            this.RightTableLayoutPanel.RowCount = 2;
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTableLayoutPanel.Size = new System.Drawing.Size(535, 447);
            this.RightTableLayoutPanel.TabIndex = 1;
            // 
            // CardsGridView
            // 
            this.CardsGridView.AllowUserToAddRows = false;
            this.CardsGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CardsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.CardsGridView.BackgroundColor = System.Drawing.Color.White;
            this.CardsGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CardsGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CardsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.CardsGridView.ColumnHeadersHeight = 25;
            this.CardsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.DeleteColumn,
            this.EditColumn,
            this.EIDColumn,
            this.CardSnColumn,
            this.DepNameColumn,
            this.CardTypeColumn,
            this.BeginTimeColumn,
            this.BeginReasonColumn,
            this.CommentColumn,
            this.EnabledColumn});
            this.CardsGridView.ContextMenuStrip = this.OperationContext;
            this.CardsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardsGridView.GridColor = System.Drawing.SystemColors.Control;
            this.CardsGridView.Location = new System.Drawing.Point(0, 0);
            this.CardsGridView.Margin = new System.Windows.Forms.Padding(0);
            this.CardsGridView.Name = "CardsGridView";
            this.CardsGridView.ReadOnly = true;
            this.CardsGridView.RowHeadersVisible = false;
            this.CardsGridView.RowTemplate.Height = 25;
            this.CardsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CardsGridView.Size = new System.Drawing.Size(535, 397);
            this.CardsGridView.TabIndex = 1;
            this.CardsGridView.VirtualMode = true;
            this.CardsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CardsGridView_CellContentClick);
            this.CardsGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.CardsGridView_CellValueNeeded);
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
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeleteColumn.DefaultCellStyle = dataGridViewCellStyle11;
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
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EditColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.EditColumn.HeaderText = "";
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            this.EditColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EditColumn.Text = "编辑";
            this.EditColumn.UseColumnTextForLinkValue = true;
            this.EditColumn.Width = 60;
            // 
            // EIDColumn
            // 
            this.EIDColumn.HeaderText = "持卡人";
            this.EIDColumn.Name = "EIDColumn";
            this.EIDColumn.ReadOnly = true;
            // 
            // CardSnColumn
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardSnColumn.DefaultCellStyle = dataGridViewCellStyle13;
            this.CardSnColumn.HeaderText = "卡号";
            this.CardSnColumn.Name = "CardSnColumn";
            this.CardSnColumn.ReadOnly = true;
            // 
            // DepNameColumn
            // 
            this.DepNameColumn.HeaderText = "所属部门";
            this.DepNameColumn.Name = "DepNameColumn";
            this.DepNameColumn.ReadOnly = true;
            // 
            // CardTypeColumn
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardTypeColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.CardTypeColumn.HeaderText = "卡片类型";
            this.CardTypeColumn.Name = "CardTypeColumn";
            this.CardTypeColumn.ReadOnly = true;
            // 
            // BeginTimeColumn
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BeginTimeColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.BeginTimeColumn.HeaderText = "发卡时间";
            this.BeginTimeColumn.Name = "BeginTimeColumn";
            this.BeginTimeColumn.ReadOnly = true;
            this.BeginTimeColumn.Width = 150;
            // 
            // BeginReasonColumn
            // 
            this.BeginReasonColumn.HeaderText = "发卡原因";
            this.BeginReasonColumn.Name = "BeginReasonColumn";
            this.BeginReasonColumn.ReadOnly = true;
            this.BeginReasonColumn.Width = 150;
            // 
            // CommentColumn
            // 
            this.CommentColumn.HeaderText = "备注";
            this.CommentColumn.Name = "CommentColumn";
            this.CommentColumn.ReadOnly = true;
            this.CommentColumn.Width = 150;
            // 
            // EnabledColumn
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EnabledColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.EnabledColumn.HeaderText = "状态";
            this.EnabledColumn.Name = "EnabledColumn";
            this.EnabledColumn.ReadOnly = true;
            this.EnabledColumn.Width = 60;
            // 
            // OperationContext
            // 
            this.OperationContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpMenuItem1,
            this.OpMenuItem2,
            this.OpSeparator1,
            this.OpMenuItem3});
            this.OperationContext.Name = "OperationContext";
            this.OperationContext.Size = new System.Drawing.Size(137, 76);
            this.OperationContext.Opening += new System.ComponentModel.CancelEventHandler(this.OperationContext_Opening);
            // 
            // OpMenuItem1
            // 
            this.OpMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.remove;
            this.OpMenuItem1.Name = "OpMenuItem1";
            this.OpMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.OpMenuItem1.Text = "删除选中行";
            this.OpMenuItem1.Click += new System.EventHandler(this.OpMenuItem1_Click);
            // 
            // OpMenuItem2
            // 
            this.OpMenuItem2.Image = global::Delta.MPS.AccessSystem.Properties.Resources.clear;
            this.OpMenuItem2.Name = "OpMenuItem2";
            this.OpMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.OpMenuItem2.Text = "删除所有行";
            this.OpMenuItem2.Click += new System.EventHandler(this.OpMenuItem2_Click);
            // 
            // OpSeparator1
            // 
            this.OpSeparator1.Name = "OpSeparator1";
            this.OpSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // OpMenuItem3
            // 
            this.OpMenuItem3.Image = global::Delta.MPS.AccessSystem.Properties.Resources.disk;
            this.OpMenuItem3.Name = "OpMenuItem3";
            this.OpMenuItem3.Size = new System.Drawing.Size(136, 22);
            this.OpMenuItem3.Text = "数据导出";
            this.OpMenuItem3.Click += new System.EventHandler(this.OpMenuItem3_Click);
            // 
            // SignedBottomPanel
            // 
            this.SignedBottomPanel.Controls.Add(this.ExportBtn);
            this.SignedBottomPanel.Controls.Add(this.DeleteBtn);
            this.SignedBottomPanel.Controls.Add(this.AddBtn);
            this.SignedBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignedBottomPanel.Location = new System.Drawing.Point(0, 397);
            this.SignedBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SignedBottomPanel.Name = "SignedBottomPanel";
            this.SignedBottomPanel.Size = new System.Drawing.Size(535, 50);
            this.SignedBottomPanel.TabIndex = 2;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExportBtn.Location = new System.Drawing.Point(445, 10);
            this.ExportBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(90, 30);
            this.ExportBtn.TabIndex = 3;
            this.ExportBtn.Text = "数据导出(&E)";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeleteBtn.Location = new System.Drawing.Point(100, 10);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(90, 30);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "全部删除(&D)";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddBtn.Location = new System.Drawing.Point(0, 10);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(0);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(90, 30);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "发卡(&S)...";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.lineLbl);
            this.BottomPanel.Controls.Add(this.BatchAddBtn);
            this.BottomPanel.Controls.Add(this.FindCardBtn);
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 462);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(764, 50);
            this.BottomPanel.TabIndex = 2;
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineLbl.Location = new System.Drawing.Point(0, 0);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(764, 2);
            this.lineLbl.TabIndex = 0;
            // 
            // BatchAddBtn
            // 
            this.BatchAddBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BatchAddBtn.Location = new System.Drawing.Point(0, 10);
            this.BatchAddBtn.Margin = new System.Windows.Forms.Padding(0);
            this.BatchAddBtn.Name = "BatchAddBtn";
            this.BatchAddBtn.Size = new System.Drawing.Size(90, 30);
            this.BatchAddBtn.TabIndex = 1;
            this.BatchAddBtn.Text = "批量发卡(&B)";
            this.BatchAddBtn.UseVisualStyleBackColor = true;
            this.BatchAddBtn.Click += new System.EventHandler(this.BatchAddBtn_Click);
            // 
            // FindCardBtn
            // 
            this.FindCardBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FindCardBtn.Location = new System.Drawing.Point(100, 10);
            this.FindCardBtn.Margin = new System.Windows.Forms.Padding(0);
            this.FindCardBtn.Name = "FindCardBtn";
            this.FindCardBtn.Size = new System.Drawing.Size(90, 30);
            this.FindCardBtn.TabIndex = 2;
            this.FindCardBtn.Text = "查找门卡(&Q)";
            this.FindCardBtn.UseVisualStyleBackColor = true;
            this.FindCardBtn.Click += new System.EventHandler(this.FindCardBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(674, 10);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 30);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // TreeViewContextMenuStrip
            // 
            this.TreeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVToolStripMenuItem1});
            this.TreeViewContextMenuStrip.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // TVToolStripMenuItem1
            // 
            this.TVToolStripMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.find;
            this.TVToolStripMenuItem1.Name = "TVToolStripMenuItem1";
            this.TVToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.TVToolStripMenuItem1.Text = "查找节点";
            this.TVToolStripMenuItem1.Click += new System.EventHandler(this.TVToolStripMenuItem1_Click);
            // 
            // OrgCardManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "OrgCardManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工持卡管理";
            this.Shown += new System.EventHandler(this.OrgCardManagerForm_Shown);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.RightTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CardsGridView)).EndInit();
            this.OperationContext.ResumeLayout(false);
            this.SignedBottomPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button FindCardBtn;
        private System.Windows.Forms.Button BatchAddBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TableLayoutPanel RightTableLayoutPanel;
        private System.Windows.Forms.Panel SignedBottomPanel;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.DataGridView CardsGridView;
        private System.Windows.Forms.CheckBox SubCardCB;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.ContextMenuStrip OperationContext;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem2;
        private System.Windows.Forms.ToolStripSeparator OpSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteColumn;
        private System.Windows.Forms.DataGridViewLinkColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardSnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginReasonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnabledColumn;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.TreeView EmpTreeView;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem1;
    }
}