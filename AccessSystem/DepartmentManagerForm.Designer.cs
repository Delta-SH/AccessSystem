namespace Delta.MPS.AccessSystem
{
    partial class DepartmentManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.DepSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DeptTreeView = new System.Windows.Forms.TreeView();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.RightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RolesGridViewPanel = new System.Windows.Forms.Panel();
            this.DeptGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnabledColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.SubDeptCB = new System.Windows.Forms.CheckBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DepSplitContainer)).BeginInit();
            this.DepSplitContainer.Panel1.SuspendLayout();
            this.DepSplitContainer.Panel2.SuspendLayout();
            this.DepSplitContainer.SuspendLayout();
            this.RightTableLayoutPanel.SuspendLayout();
            this.RolesGridViewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeptGridView)).BeginInit();
            this.OperationContext.SuspendLayout();
            this.OperationPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.TreeViewContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.DepSplitContainer, 0, 0);
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
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // DepSplitContainer
            // 
            this.DepSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.DepSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.DepSplitContainer.Name = "DepSplitContainer";
            // 
            // DepSplitContainer.Panel1
            // 
            this.DepSplitContainer.Panel1.Controls.Add(this.DeptTreeView);
            this.DepSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // DepSplitContainer.Panel2
            // 
            this.DepSplitContainer.Panel2.Controls.Add(this.RightTableLayoutPanel);
            this.DepSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.DepSplitContainer.Size = new System.Drawing.Size(764, 452);
            this.DepSplitContainer.SplitterDistance = 200;
            this.DepSplitContainer.TabIndex = 0;
            // 
            // DeptTreeView
            // 
            this.DeptTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.DeptTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeptTreeView.HideSelection = false;
            this.DeptTreeView.ImageKey = "Department";
            this.DeptTreeView.ImageList = this.TreeImages;
            this.DeptTreeView.Location = new System.Drawing.Point(0, 0);
            this.DeptTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.DeptTreeView.Name = "DeptTreeView";
            this.DeptTreeView.SelectedImageKey = "Department";
            this.DeptTreeView.Size = new System.Drawing.Size(195, 452);
            this.DeptTreeView.TabIndex = 0;
            this.DeptTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DeptTreeView_AfterSelect);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "Department");
            // 
            // RightTableLayoutPanel
            // 
            this.RightTableLayoutPanel.ColumnCount = 1;
            this.RightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.Controls.Add(this.RolesGridViewPanel, 0, 0);
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
            // RolesGridViewPanel
            // 
            this.RolesGridViewPanel.Controls.Add(this.DeptGridView);
            this.RolesGridViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RolesGridViewPanel.Location = new System.Drawing.Point(0, 0);
            this.RolesGridViewPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RolesGridViewPanel.Name = "RolesGridViewPanel";
            this.RolesGridViewPanel.Size = new System.Drawing.Size(555, 402);
            this.RolesGridViewPanel.TabIndex = 5;
            // 
            // DeptGridView
            // 
            this.DeptGridView.AllowUserToAddRows = false;
            this.DeptGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.DeptGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DeptGridView.BackgroundColor = System.Drawing.Color.White;
            this.DeptGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeptGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeptGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DeptGridView.ColumnHeadersHeight = 25;
            this.DeptGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.DeleteColumn,
            this.EditColumn,
            this.DIDColumn,
            this.NameColumn,
            this.CommentColumn,
            this.EnabledColumn});
            this.DeptGridView.ContextMenuStrip = this.OperationContext;
            this.DeptGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeptGridView.GridColor = System.Drawing.SystemColors.Control;
            this.DeptGridView.Location = new System.Drawing.Point(0, 0);
            this.DeptGridView.Margin = new System.Windows.Forms.Padding(0);
            this.DeptGridView.Name = "DeptGridView";
            this.DeptGridView.ReadOnly = true;
            this.DeptGridView.RowHeadersVisible = false;
            this.DeptGridView.RowTemplate.Height = 25;
            this.DeptGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DeptGridView.Size = new System.Drawing.Size(555, 402);
            this.DeptGridView.TabIndex = 0;
            this.DeptGridView.VirtualMode = true;
            this.DeptGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeptGridView_CellContentClick);
            this.DeptGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DeptGridView_CellValueNeeded);
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
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeleteColumn.DefaultCellStyle = dataGridViewCellStyle17;
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
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EditColumn.DefaultCellStyle = dataGridViewCellStyle18;
            this.EditColumn.HeaderText = "";
            this.EditColumn.Name = "EditColumn";
            this.EditColumn.ReadOnly = true;
            this.EditColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EditColumn.Text = "编辑";
            this.EditColumn.UseColumnTextForLinkValue = true;
            this.EditColumn.Width = 60;
            // 
            // DIDColumn
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DIDColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.DIDColumn.HeaderText = "部门编号";
            this.DIDColumn.Name = "DIDColumn";
            this.DIDColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "部门名称";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 150;
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
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EnabledColumn.DefaultCellStyle = dataGridViewCellStyle20;
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
            this.BottomPanel.Controls.Add(this.SubDeptCB);
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 462);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(764, 50);
            this.BottomPanel.TabIndex = 1;
            // 
            // SubDeptCB
            // 
            this.SubDeptCB.BackColor = System.Drawing.Color.Transparent;
            this.SubDeptCB.Location = new System.Drawing.Point(0, 0);
            this.SubDeptCB.Margin = new System.Windows.Forms.Padding(0);
            this.SubDeptCB.Name = "SubDeptCB";
            this.SubDeptCB.Size = new System.Drawing.Size(180, 20);
            this.SubDeptCB.TabIndex = 4;
            this.SubDeptCB.Text = "显示所有的子级部门";
            this.SubDeptCB.UseVisualStyleBackColor = false;
            this.SubDeptCB.CheckedChanged += new System.EventHandler(this.SubDeptCB_CheckedChanged);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(674, 10);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 30);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // TreeViewContextMenuStrip
            // 
            this.TreeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVToolStripMenuItem1});
            this.TreeViewContextMenuStrip.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // TVToolStripMenuItem1
            // 
            this.TVToolStripMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.find;
            this.TVToolStripMenuItem1.Name = "TVToolStripMenuItem1";
            this.TVToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.TVToolStripMenuItem1.Text = "查找节点";
            this.TVToolStripMenuItem1.Click += new System.EventHandler(this.TVToolStripMenuItem1_Click);
            // 
            // DepartmentManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "DepartmentManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "部门管理";
            this.Load += new System.EventHandler(this.DepartmentManagerForm_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.DepSplitContainer.Panel1.ResumeLayout(false);
            this.DepSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DepSplitContainer)).EndInit();
            this.DepSplitContainer.ResumeLayout(false);
            this.RightTableLayoutPanel.ResumeLayout(false);
            this.RolesGridViewPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeptGridView)).EndInit();
            this.OperationContext.ResumeLayout(false);
            this.OperationPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.SplitContainer DepSplitContainer;
        private System.Windows.Forms.TreeView DeptTreeView;
        private System.Windows.Forms.TableLayoutPanel RightTableLayoutPanel;
        private System.Windows.Forms.CheckBox SubDeptCB;
        private System.Windows.Forms.Panel RolesGridViewPanel;
        private System.Windows.Forms.DataGridView DeptGridView;
        private System.Windows.Forms.Panel OperationPanel;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteColumn;
        private System.Windows.Forms.DataGridViewLinkColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnabledColumn;
        private System.Windows.Forms.ContextMenuStrip OperationContext;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem2;
        private System.Windows.Forms.ToolStripSeparator OpSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem3;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem1;
    }
}