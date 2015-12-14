namespace Delta.MPS.AccessSystem
{
    partial class CardAuthDetailDialog
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
            this.AuthGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardSnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimitIndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnabledColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RecMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.AuthGridView)).BeginInit();
            this.RecordContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AuthGridView
            // 
            this.AuthGridView.AllowUserToAddRows = false;
            this.AuthGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.AuthGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.AuthGridView.BackgroundColor = System.Drawing.Color.White;
            this.AuthGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AuthGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AuthGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.AuthGridView.ColumnHeadersHeight = 25;
            this.AuthGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.EIDColumn,
            this.NameColumn,
            this.DepNameColumn,
            this.CardSnColumn,
            this.BeginTimeColumn,
            this.EndTimeColumn,
            this.LimitColumn,
            this.LimitIndexColumn,
            this.EnabledColumn});
            this.AuthGridView.ContextMenuStrip = this.RecordContextMenuStrip;
            this.AuthGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AuthGridView.GridColor = System.Drawing.SystemColors.Control;
            this.AuthGridView.Location = new System.Drawing.Point(0, 0);
            this.AuthGridView.Margin = new System.Windows.Forms.Padding(0);
            this.AuthGridView.Name = "AuthGridView";
            this.AuthGridView.ReadOnly = true;
            this.AuthGridView.RowHeadersVisible = false;
            this.AuthGridView.RowTemplate.Height = 25;
            this.AuthGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuthGridView.Size = new System.Drawing.Size(784, 512);
            this.AuthGridView.TabIndex = 3;
            this.AuthGridView.VirtualMode = true;
            this.AuthGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.AuthGridView_CellValueNeeded);
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
            this.NameColumn.HeaderText = "姓名";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            // 
            // DepNameColumn
            // 
            this.DepNameColumn.HeaderText = "部门";
            this.DepNameColumn.Name = "DepNameColumn";
            this.DepNameColumn.ReadOnly = true;
            // 
            // CardSnColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CardSnColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.CardSnColumn.HeaderText = "卡号";
            this.CardSnColumn.Name = "CardSnColumn";
            this.CardSnColumn.ReadOnly = true;
            // 
            // BeginTimeColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BeginTimeColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.BeginTimeColumn.HeaderText = "开始日期";
            this.BeginTimeColumn.Name = "BeginTimeColumn";
            this.BeginTimeColumn.ReadOnly = true;
            // 
            // EndTimeColumn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.EndTimeColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.EndTimeColumn.HeaderText = "结束日期";
            this.EndTimeColumn.Name = "EndTimeColumn";
            this.EndTimeColumn.ReadOnly = true;
            // 
            // LimitColumn
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LimitColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.LimitColumn.HeaderText = "权限类型";
            this.LimitColumn.Name = "LimitColumn";
            this.LimitColumn.ReadOnly = true;
            // 
            // LimitIndexColumn
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LimitIndexColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.LimitIndexColumn.HeaderText = "权限分组";
            this.LimitIndexColumn.Name = "LimitIndexColumn";
            this.LimitIndexColumn.ReadOnly = true;
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
            // CardAuthDetailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.AuthGridView);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "CardAuthDetailDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "授权卡片详单";
            this.Load += new System.EventHandler(this.CardAuthDetailDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AuthGridView)).EndInit();
            this.RecordContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AuthGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardSnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimitColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimitIndexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnabledColumn;
        private System.Windows.Forms.ContextMenuStrip RecordContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RecMenuItem1;
    }
}