namespace Delta.MPS.AccessSystem
{
    partial class CardRecordsDetailDialog
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
            ((System.ComponentModel.ISupportInitialize)(this.HisCardGridView)).BeginInit();
            this.RecordContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.HisCardGridView.Location = new System.Drawing.Point(0, 0);
            this.HisCardGridView.Margin = new System.Windows.Forms.Padding(0);
            this.HisCardGridView.MultiSelect = false;
            this.HisCardGridView.Name = "HisCardGridView";
            this.HisCardGridView.ReadOnly = true;
            this.HisCardGridView.RowHeadersVisible = false;
            this.HisCardGridView.RowTemplate.Height = 25;
            this.HisCardGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.HisCardGridView.Size = new System.Drawing.Size(784, 512);
            this.HisCardGridView.TabIndex = 3;
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
            // CardRecordsDetailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.HisCardGridView);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "CardRecordsDetailDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刷卡记录详单";
            this.Load += new System.EventHandler(this.CardRecordsDetailDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HisCardGridView)).EndInit();
            this.RecordContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.ContextMenuStrip RecordContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RecMenuItem1;
    }
}