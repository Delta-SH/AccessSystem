namespace Delta.MPS.AccessSystem
{
    partial class DevAuthDetailDialog
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
            this.RecordContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RecMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DevGridView = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecordContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DevGridView)).BeginInit();
            this.SuspendLayout();
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
            this.DevNameColumn});
            this.DevGridView.ContextMenuStrip = this.RecordContextMenuStrip;
            this.DevGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevGridView.GridColor = System.Drawing.SystemColors.Control;
            this.DevGridView.Location = new System.Drawing.Point(0, 0);
            this.DevGridView.MultiSelect = false;
            this.DevGridView.Name = "DevGridView";
            this.DevGridView.ReadOnly = true;
            this.DevGridView.RowHeadersVisible = false;
            this.DevGridView.RowTemplate.Height = 25;
            this.DevGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DevGridView.Size = new System.Drawing.Size(784, 512);
            this.DevGridView.TabIndex = 3;
            this.DevGridView.VirtualMode = true;
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
            // DevAuthDetailDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 512);
            this.Controls.Add(this.DevGridView);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "DevAuthDetailDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "授权设备详单";
            this.Load += new System.EventHandler(this.DevAuthDetailDialog_Load);
            this.RecordContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DevGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip RecordContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RecMenuItem1;
        private System.Windows.Forms.DataGridView DevGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevNameColumn;
    }
}