namespace Delta.MPS.AccessSystem
{
    partial class DeviceForm
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
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DevGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardCntColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.CBPanel10 = new System.Windows.Forms.Panel();
            this.QueryBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevGridView)).BeginInit();
            this.RecordContextMenuStrip.SuspendLayout();
            this.ConditionPanel.SuspendLayout();
            this.ConditionFlowLayoutPanel.SuspendLayout();
            this.CBPanel1.SuspendLayout();
            this.CBPanel2.SuspendLayout();
            this.CBPanel3.SuspendLayout();
            this.CBPanel4.SuspendLayout();
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
            this.MainSplitContainer.Panel1.Controls.Add(this.DevGridView);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.ConditionPanel);
            this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.MainSplitContainer.Size = new System.Drawing.Size(784, 512);
            this.MainSplitContainer.SplitterDistance = 534;
            this.MainSplitContainer.TabIndex = 3;
            // 
            // DevGridView
            // 
            this.DevGridView.AllowUserToAddRows = false;
            this.DevGridView.AllowUserToDeleteRows = false;
            this.DevGridView.BackgroundColor = System.Drawing.Color.White;
            this.DevGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DevGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DevGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DevGridView.ColumnHeadersHeight = 25;
            this.DevGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.RegionNameColumn,
            this.CityNameColumn,
            this.StaNameColumn,
            this.DevIDColumn,
            this.DevNameColumn,
            this.CardCntColumn});
            this.DevGridView.ContextMenuStrip = this.RecordContextMenuStrip;
            this.DevGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevGridView.GridColor = System.Drawing.SystemColors.Control;
            this.DevGridView.Location = new System.Drawing.Point(5, 5);
            this.DevGridView.MultiSelect = false;
            this.DevGridView.Name = "DevGridView";
            this.DevGridView.ReadOnly = true;
            this.DevGridView.RowHeadersVisible = false;
            this.DevGridView.RowTemplate.Height = 25;
            this.DevGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DevGridView.Size = new System.Drawing.Size(524, 502);
            this.DevGridView.TabIndex = 2;
            this.DevGridView.VirtualMode = true;
            this.DevGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DevGridView_CellDoubleClick);
            this.DevGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DevGridView_CellValueNeeded);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "序号";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 60;
            // 
            // RegionNameColumn
            // 
            this.RegionNameColumn.HeaderText = "地区";
            this.RegionNameColumn.Name = "RegionNameColumn";
            this.RegionNameColumn.ReadOnly = true;
            // 
            // CityNameColumn
            // 
            this.CityNameColumn.HeaderText = "县市";
            this.CityNameColumn.Name = "CityNameColumn";
            this.CityNameColumn.ReadOnly = true;
            // 
            // StaNameColumn
            // 
            this.StaNameColumn.HeaderText = "局站";
            this.StaNameColumn.Name = "StaNameColumn";
            this.StaNameColumn.ReadOnly = true;
            // 
            // DevIDColumn
            // 
            this.DevIDColumn.HeaderText = "设备编号";
            this.DevIDColumn.Name = "DevIDColumn";
            this.DevIDColumn.ReadOnly = true;
            // 
            // DevNameColumn
            // 
            this.DevNameColumn.HeaderText = "设备名称";
            this.DevNameColumn.Name = "DevNameColumn";
            this.DevNameColumn.ReadOnly = true;
            // 
            // CardCntColumn
            // 
            this.CardCntColumn.HeaderText = "授权卡片";
            this.CardCntColumn.Name = "CardCntColumn";
            this.CardCntColumn.ReadOnly = true;
            // 
            // RecordContextMenuStrip
            // 
            this.RecordContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RecMenuItem1});
            this.RecordContextMenuStrip.Name = "contextMenuStrip1";
            this.RecordContextMenuStrip.Size = new System.Drawing.Size(125, 26);
            this.RecordContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.RecordContextMenuStrip_Opening);
            // 
            // RecMenuItem1
            // 
            this.RecMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.disk;
            this.RecMenuItem1.Name = "RecMenuItem1";
            this.RecMenuItem1.Size = new System.Drawing.Size(124, 22);
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
            // CBPanel10
            // 
            this.CBPanel10.Controls.Add(this.QueryBtn);
            this.CBPanel10.Location = new System.Drawing.Point(3, 127);
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
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.MainSplitContainer);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "DeviceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备报表";
            this.Load += new System.EventHandler(this.DeviceForm_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DevGridView)).EndInit();
            this.RecordContextMenuStrip.ResumeLayout(false);
            this.ConditionPanel.ResumeLayout(false);
            this.ConditionFlowLayoutPanel.ResumeLayout(false);
            this.CBPanel1.ResumeLayout(false);
            this.CBPanel2.ResumeLayout(false);
            this.CBPanel3.ResumeLayout(false);
            this.CBPanel4.ResumeLayout(false);
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
        private System.Windows.Forms.Panel CBPanel10;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.DataGridView DevGridView;
        private System.Windows.Forms.ContextMenuStrip RecordContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RecMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardCntColumn;
    }
}