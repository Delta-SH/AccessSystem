namespace Delta.MPS.AccessSystem
{
    partial class GridGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridGroupForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.GridMgrBtn = new System.Windows.Forms.Button();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.GridTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.RightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.GridGroupGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Area2NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area3NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OperationContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.GridBottomPanel = new System.Windows.Forms.Panel();
            this.lineLbl = new System.Windows.Forms.Label();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.TreeViewContextMenuStrip.SuspendLayout();
            this.RightTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridGroupGridView)).BeginInit();
            this.OperationContext.SuspendLayout();
            this.GridBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.MainSplitContainer, 0, 0);
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
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Controls.Add(this.GridMgrBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 462);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(764, 50);
            this.BottomPanel.TabIndex = 1;
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
            // GridMgrBtn
            // 
            this.GridMgrBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GridMgrBtn.Location = new System.Drawing.Point(0, 10);
            this.GridMgrBtn.Margin = new System.Windows.Forms.Padding(0);
            this.GridMgrBtn.Name = "GridMgrBtn";
            this.GridMgrBtn.Size = new System.Drawing.Size(90, 30);
            this.GridMgrBtn.TabIndex = 1;
            this.GridMgrBtn.Text = "网格管理(&G)";
            this.GridMgrBtn.UseVisualStyleBackColor = true;
            this.GridMgrBtn.Click += new System.EventHandler(this.GridMgrBtn_Click);
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
            this.MainSplitContainer.Panel1.Controls.Add(this.GridTreeView);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.RightTableLayoutPanel);
            this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MainSplitContainer.Size = new System.Drawing.Size(764, 452);
            this.MainSplitContainer.SplitterDistance = 250;
            this.MainSplitContainer.TabIndex = 1;
            // 
            // GridTreeView
            // 
            this.GridTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.GridTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridTreeView.HideSelection = false;
            this.GridTreeView.ImageKey = "Grid";
            this.GridTreeView.ImageList = this.TreeImages;
            this.GridTreeView.Location = new System.Drawing.Point(0, 0);
            this.GridTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.GridTreeView.Name = "GridTreeView";
            this.GridTreeView.SelectedImageKey = "Grid";
            this.GridTreeView.ShowLines = false;
            this.GridTreeView.ShowPlusMinus = false;
            this.GridTreeView.ShowRootLines = false;
            this.GridTreeView.Size = new System.Drawing.Size(245, 452);
            this.GridTreeView.TabIndex = 0;
            this.GridTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.GridTreeView_AfterSelect);
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
            this.TVToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.TVToolStripMenuItem1.Text = "查找节点";
            this.TVToolStripMenuItem1.Click += new System.EventHandler(this.TVToolStripMenuItem1_Click);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "Grid");
            // 
            // RightTableLayoutPanel
            // 
            this.RightTableLayoutPanel.ColumnCount = 1;
            this.RightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.Controls.Add(this.GridGroupGridView, 0, 0);
            this.RightTableLayoutPanel.Controls.Add(this.GridBottomPanel, 0, 1);
            this.RightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTableLayoutPanel.Location = new System.Drawing.Point(5, 0);
            this.RightTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightTableLayoutPanel.Name = "RightTableLayoutPanel";
            this.RightTableLayoutPanel.RowCount = 2;
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTableLayoutPanel.Size = new System.Drawing.Size(505, 452);
            this.RightTableLayoutPanel.TabIndex = 2;
            // 
            // GridGroupGridView
            // 
            this.GridGroupGridView.AllowUserToAddRows = false;
            this.GridGroupGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GridGroupGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.GridGroupGridView.BackgroundColor = System.Drawing.Color.White;
            this.GridGroupGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.GridGroupGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridGroupGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.GridGroupGridView.ColumnHeadersHeight = 25;
            this.GridGroupGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.DeleteColumn,
            this.Area2NameColumn,
            this.Area3NameColumn,
            this.StaIDColumn,
            this.StaNameColumn});
            this.GridGroupGridView.ContextMenuStrip = this.OperationContext;
            this.GridGroupGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridGroupGridView.GridColor = System.Drawing.SystemColors.Control;
            this.GridGroupGridView.Location = new System.Drawing.Point(0, 0);
            this.GridGroupGridView.Margin = new System.Windows.Forms.Padding(0);
            this.GridGroupGridView.Name = "GridGroupGridView";
            this.GridGroupGridView.ReadOnly = true;
            this.GridGroupGridView.RowHeadersVisible = false;
            this.GridGroupGridView.RowTemplate.Height = 25;
            this.GridGroupGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridGroupGridView.Size = new System.Drawing.Size(505, 402);
            this.GridGroupGridView.TabIndex = 1;
            this.GridGroupGridView.VirtualMode = true;
            this.GridGroupGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridGroupGridView_CellContentClick);
            this.GridGroupGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.GridGroupGridView_CellValueNeeded);
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DeleteColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.DeleteColumn.HeaderText = "";
            this.DeleteColumn.Name = "DeleteColumn";
            this.DeleteColumn.ReadOnly = true;
            this.DeleteColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DeleteColumn.Text = "删除";
            this.DeleteColumn.UseColumnTextForLinkValue = true;
            this.DeleteColumn.Width = 60;
            // 
            // Area2NameColumn
            // 
            this.Area2NameColumn.HeaderText = "所属地区";
            this.Area2NameColumn.Name = "Area2NameColumn";
            this.Area2NameColumn.ReadOnly = true;
            // 
            // Area3NameColumn
            // 
            this.Area3NameColumn.HeaderText = "所属县市";
            this.Area3NameColumn.Name = "Area3NameColumn";
            this.Area3NameColumn.ReadOnly = true;
            // 
            // StaIDColumn
            // 
            this.StaIDColumn.HeaderText = "StaID";
            this.StaIDColumn.Name = "StaIDColumn";
            this.StaIDColumn.ReadOnly = true;
            this.StaIDColumn.Visible = false;
            // 
            // StaNameColumn
            // 
            this.StaNameColumn.HeaderText = "局站名称";
            this.StaNameColumn.Name = "StaNameColumn";
            this.StaNameColumn.ReadOnly = true;
            this.StaNameColumn.Width = 150;
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
            // GridBottomPanel
            // 
            this.GridBottomPanel.Controls.Add(this.lineLbl);
            this.GridBottomPanel.Controls.Add(this.ExportBtn);
            this.GridBottomPanel.Controls.Add(this.DeleteBtn);
            this.GridBottomPanel.Controls.Add(this.AddBtn);
            this.GridBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridBottomPanel.Location = new System.Drawing.Point(0, 402);
            this.GridBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.GridBottomPanel.Name = "GridBottomPanel";
            this.GridBottomPanel.Size = new System.Drawing.Size(505, 50);
            this.GridBottomPanel.TabIndex = 2;
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lineLbl.Location = new System.Drawing.Point(0, 48);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(505, 2);
            this.lineLbl.TabIndex = 0;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ExportBtn.Location = new System.Drawing.Point(415, 10);
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
            this.AddBtn.Text = "添加(&S)...";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // GridGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "GridGroupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "局站网格管理";
            this.Shown += new System.EventHandler(this.GridGroupForm_Shown);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            this.RightTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridGroupGridView)).EndInit();
            this.OperationContext.ResumeLayout(false);
            this.GridBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Button GridMgrBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.TableLayoutPanel RightTableLayoutPanel;
        private System.Windows.Forms.DataGridView GridGroupGridView;
        private System.Windows.Forms.Panel GridBottomPanel;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TreeView GridTreeView;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area2NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area3NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaNameColumn;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip OperationContext;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem2;
        private System.Windows.Forms.ToolStripSeparator OpSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem3;
    }
}