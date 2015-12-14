namespace Delta.MPS.AccessSystem
{
    partial class RoleManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleManagerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.RoleTreeView = new System.Windows.Forms.TreeView();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.RightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OperationPanel = new System.Windows.Forms.Panel();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.LineLbl = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.RoleGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.GuidColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnabledColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.RightTableLayoutPanel.SuspendLayout();
            this.OperationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleGridView)).BeginInit();
            this.OperationContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.CloseBtn, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.MainSplitContainer, 0, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(784, 512);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(684, 472);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 30);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
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
            this.MainSplitContainer.Panel1.Controls.Add(this.RoleTreeView);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.RightTableLayoutPanel);
            this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MainSplitContainer.Size = new System.Drawing.Size(764, 452);
            this.MainSplitContainer.SplitterDistance = 200;
            this.MainSplitContainer.TabIndex = 0;
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
            this.RoleTreeView.TabIndex = 1;
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
            this.RightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTableLayoutPanel.Controls.Add(this.OperationPanel, 0, 1);
            this.RightTableLayoutPanel.Controls.Add(this.RoleGridView, 0, 0);
            this.RightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTableLayoutPanel.Location = new System.Drawing.Point(5, 0);
            this.RightTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightTableLayoutPanel.Name = "RightTableLayoutPanel";
            this.RightTableLayoutPanel.RowCount = 2;
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RightTableLayoutPanel.Size = new System.Drawing.Size(555, 452);
            this.RightTableLayoutPanel.TabIndex = 0;
            // 
            // OperationPanel
            // 
            this.OperationPanel.Controls.Add(this.ExportBtn);
            this.OperationPanel.Controls.Add(this.LineLbl);
            this.OperationPanel.Controls.Add(this.AddBtn);
            this.OperationPanel.Controls.Add(this.DeleteBtn);
            this.OperationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationPanel.Location = new System.Drawing.Point(0, 402);
            this.OperationPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OperationPanel.Name = "OperationPanel";
            this.OperationPanel.Size = new System.Drawing.Size(555, 50);
            this.OperationPanel.TabIndex = 2;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExportBtn.Location = new System.Drawing.Point(465, 10);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(90, 30);
            this.ExportBtn.TabIndex = 3;
            this.ExportBtn.Text = "数据导出(&E)";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // LineLbl
            // 
            this.LineLbl.BackColor = System.Drawing.Color.Transparent;
            this.LineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LineLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LineLbl.Location = new System.Drawing.Point(0, 48);
            this.LineLbl.Name = "LineLbl";
            this.LineLbl.Size = new System.Drawing.Size(555, 2);
            this.LineLbl.TabIndex = 3;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddBtn.Location = new System.Drawing.Point(0, 10);
            this.AddBtn.Margin = new System.Windows.Forms.Padding(0);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(90, 30);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "添加(&A)...";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeleteBtn.Location = new System.Drawing.Point(95, 10);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(90, 30);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "全部删除(&D)";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // RoleGridView
            // 
            this.RoleGridView.AllowUserToAddRows = false;
            this.RoleGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.RoleGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.RoleGridView.BackgroundColor = System.Drawing.Color.White;
            this.RoleGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RoleGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RoleGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.RoleGridView.ColumnHeadersHeight = 25;
            this.RoleGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.DeleteColumn,
            this.EditColumn,
            this.GuidColumn,
            this.NameColumn,
            this.CommentColumn,
            this.EnabledColumn});
            this.RoleGridView.ContextMenuStrip = this.OperationContext;
            this.RoleGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleGridView.GridColor = System.Drawing.SystemColors.Control;
            this.RoleGridView.Location = new System.Drawing.Point(0, 0);
            this.RoleGridView.Margin = new System.Windows.Forms.Padding(0);
            this.RoleGridView.Name = "RoleGridView";
            this.RoleGridView.ReadOnly = true;
            this.RoleGridView.RowHeadersVisible = false;
            this.RoleGridView.RowTemplate.Height = 25;
            this.RoleGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RoleGridView.Size = new System.Drawing.Size(555, 402);
            this.RoleGridView.TabIndex = 1;
            this.RoleGridView.VirtualMode = true;
            this.RoleGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleGridView_CellContentClick);
            this.RoleGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.RoleGridView_CellValueNeeded);
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
            // GuidColumn
            // 
            this.GuidColumn.HeaderText = "角色标识";
            this.GuidColumn.Name = "GuidColumn";
            this.GuidColumn.ReadOnly = true;
            this.GuidColumn.Visible = false;
            // 
            // NameColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NameColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.NameColumn.HeaderText = "角色名称";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // CommentColumn
            // 
            this.CommentColumn.HeaderText = "角色描述";
            this.CommentColumn.Name = "CommentColumn";
            this.CommentColumn.ReadOnly = true;
            this.CommentColumn.Width = 200;
            // 
            // EnabledColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EnabledColumn.DefaultCellStyle = dataGridViewCellStyle6;
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
            // RoleManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "RoleManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色权限管理";
            this.Load += new System.EventHandler(this.RoleManagerForm_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.RightTableLayoutPanel.ResumeLayout(false);
            this.OperationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleGridView)).EndInit();
            this.OperationContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.ContextMenuStrip OperationContext;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem2;
        private System.Windows.Forms.ToolStripSeparator OpSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem3;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.TableLayoutPanel RightTableLayoutPanel;
        private System.Windows.Forms.DataGridView RoleGridView;
        private System.Windows.Forms.Panel OperationPanel;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Label LineLbl;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteColumn;
        private System.Windows.Forms.DataGridViewLinkColumn EditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GuidColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnabledColumn;
        private System.Windows.Forms.TreeView RoleTreeView;
        private System.Windows.Forms.ImageList TreeImages;
    }
}