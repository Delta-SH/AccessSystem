namespace Delta.MPS.AccessSystem
{
    partial class ImportDataForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ImportDataGridView = new System.Windows.Forms.DataGridView();
            this.ConditionPanel = new System.Windows.Forms.GroupBox();
            this.ConditionTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FileLbl = new System.Windows.Forms.Label();
            this.SheetCB = new System.Windows.Forms.ComboBox();
            this.SheetLbl = new System.Windows.Forms.Label();
            this.FileTB = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.BrowserBtn = new System.Windows.Forms.Button();
            this.QueryBtn = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.RowCountLbl = new System.Windows.Forms.Label();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.DataFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImportDataGridView)).BeginInit();
            this.ConditionPanel.SuspendLayout();
            this.ConditionTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.ImportDataGridView, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.ConditionPanel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 3);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 4;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(534, 362);
            this.MainTableLayoutPanel.TabIndex = 2;
            // 
            // ImportDataGridView
            // 
            this.ImportDataGridView.AllowUserToAddRows = false;
            this.ImportDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ImportDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ImportDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.ImportDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImportDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ImportDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ImportDataGridView.ColumnHeadersHeight = 25;
            this.ImportDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportDataGridView.GridColor = System.Drawing.SystemColors.Control;
            this.ImportDataGridView.Location = new System.Drawing.Point(10, 107);
            this.ImportDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.ImportDataGridView.Name = "ImportDataGridView";
            this.ImportDataGridView.ReadOnly = true;
            this.ImportDataGridView.RowHeadersVisible = false;
            this.ImportDataGridView.RowTemplate.Height = 25;
            this.ImportDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ImportDataGridView.Size = new System.Drawing.Size(514, 205);
            this.ImportDataGridView.TabIndex = 8;
            this.ImportDataGridView.Tag = "";
            // 
            // ConditionPanel
            // 
            this.ConditionPanel.Controls.Add(this.ConditionTableLayoutPanel);
            this.ConditionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionPanel.Location = new System.Drawing.Point(10, 10);
            this.ConditionPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionPanel.Name = "ConditionPanel";
            this.ConditionPanel.Size = new System.Drawing.Size(514, 92);
            this.ConditionPanel.TabIndex = 1;
            this.ConditionPanel.TabStop = false;
            this.ConditionPanel.Text = "筛选条件";
            // 
            // ConditionTableLayoutPanel
            // 
            this.ConditionTableLayoutPanel.ColumnCount = 6;
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.ConditionTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ConditionTableLayoutPanel.Controls.Add(this.FileLbl, 0, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.SheetCB, 1, 2);
            this.ConditionTableLayoutPanel.Controls.Add(this.SheetLbl, 0, 2);
            this.ConditionTableLayoutPanel.Controls.Add(this.FileTB, 1, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.SaveBtn, 5, 2);
            this.ConditionTableLayoutPanel.Controls.Add(this.BrowserBtn, 5, 0);
            this.ConditionTableLayoutPanel.Controls.Add(this.QueryBtn, 3, 2);
            this.ConditionTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConditionTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.ConditionTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ConditionTableLayoutPanel.Name = "ConditionTableLayoutPanel";
            this.ConditionTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ConditionTableLayoutPanel.RowCount = 3;
            this.ConditionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConditionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.ConditionTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ConditionTableLayoutPanel.Size = new System.Drawing.Size(508, 70);
            this.ConditionTableLayoutPanel.TabIndex = 1;
            // 
            // FileLbl
            // 
            this.FileLbl.Location = new System.Drawing.Point(5, 5);
            this.FileLbl.Margin = new System.Windows.Forms.Padding(0);
            this.FileLbl.Name = "FileLbl";
            this.FileLbl.Size = new System.Drawing.Size(80, 25);
            this.FileLbl.TabIndex = 1;
            this.FileLbl.Text = "数据文件(&F):";
            this.FileLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SheetCB
            // 
            this.SheetCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SheetCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SheetCB.FormattingEnabled = true;
            this.SheetCB.Location = new System.Drawing.Point(85, 40);
            this.SheetCB.Margin = new System.Windows.Forms.Padding(0);
            this.SheetCB.Name = "SheetCB";
            this.SheetCB.Size = new System.Drawing.Size(238, 25);
            this.SheetCB.TabIndex = 5;
            this.SheetCB.SelectedIndexChanged += new System.EventHandler(this.SheetCB_SelectedIndexChanged);
            // 
            // SheetLbl
            // 
            this.SheetLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SheetLbl.Location = new System.Drawing.Point(5, 40);
            this.SheetLbl.Margin = new System.Windows.Forms.Padding(0);
            this.SheetLbl.Name = "SheetLbl";
            this.SheetLbl.Size = new System.Drawing.Size(80, 25);
            this.SheetLbl.TabIndex = 4;
            this.SheetLbl.Text = "表单名称(&N):";
            this.SheetLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileTB
            // 
            this.FileTB.BackColor = System.Drawing.Color.White;
            this.ConditionTableLayoutPanel.SetColumnSpan(this.FileTB, 3);
            this.FileTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FileTB.Location = new System.Drawing.Point(85, 7);
            this.FileTB.Margin = new System.Windows.Forms.Padding(0);
            this.FileTB.Name = "FileTB";
            this.FileTB.ReadOnly = true;
            this.FileTB.Size = new System.Drawing.Size(328, 23);
            this.FileTB.TabIndex = 2;
            this.FileTB.DoubleClick += new System.EventHandler(this.FileTB_DoubleClick);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(423, 40);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(80, 25);
            this.SaveBtn.TabIndex = 7;
            this.SaveBtn.Text = "保存(&S)";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // BrowserBtn
            // 
            this.BrowserBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserBtn.Location = new System.Drawing.Point(423, 5);
            this.BrowserBtn.Margin = new System.Windows.Forms.Padding(0);
            this.BrowserBtn.Name = "BrowserBtn";
            this.BrowserBtn.Size = new System.Drawing.Size(80, 25);
            this.BrowserBtn.TabIndex = 3;
            this.BrowserBtn.Text = "浏览...";
            this.BrowserBtn.UseVisualStyleBackColor = true;
            this.BrowserBtn.Click += new System.EventHandler(this.BrowserBtn_Click);
            // 
            // QueryBtn
            // 
            this.QueryBtn.Location = new System.Drawing.Point(333, 40);
            this.QueryBtn.Margin = new System.Windows.Forms.Padding(0);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(80, 25);
            this.QueryBtn.TabIndex = 6;
            this.QueryBtn.Text = "预览(&P)";
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.RowCountLbl);
            this.BottomPanel.Controls.Add(this.CloseBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 312);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(514, 50);
            this.BottomPanel.TabIndex = 3;
            // 
            // RowCountLbl
            // 
            this.RowCountLbl.AutoSize = true;
            this.RowCountLbl.Location = new System.Drawing.Point(0, 5);
            this.RowCountLbl.Margin = new System.Windows.Forms.Padding(0);
            this.RowCountLbl.Name = "RowCountLbl";
            this.RowCountLbl.Size = new System.Drawing.Size(83, 17);
            this.RowCountLbl.TabIndex = 0;
            this.RowCountLbl.Text = "共计 0 条记录";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(424, 10);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 30);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // DataFileDialog
            // 
            this.DataFileDialog.DefaultExt = "xls";
            this.DataFileDialog.Filter = "Excel 文件|*.xl*;*.xls;*.xlsx|所有文件|*.*";
            this.DataFileDialog.Title = "打开文件";
            // 
            // ImportDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(534, 362);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "ImportDataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量数据导入";
            this.Load += new System.EventHandler(this.ImportDataForm_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImportDataGridView)).EndInit();
            this.ConditionPanel.ResumeLayout(false);
            this.ConditionTableLayoutPanel.ResumeLayout(false);
            this.ConditionTableLayoutPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.DataGridView ImportDataGridView;
        private System.Windows.Forms.GroupBox ConditionPanel;
        private System.Windows.Forms.TableLayoutPanel ConditionTableLayoutPanel;
        private System.Windows.Forms.Label FileLbl;
        private System.Windows.Forms.ComboBox SheetCB;
        private System.Windows.Forms.Label SheetLbl;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TextBox FileTB;
        private System.Windows.Forms.Button BrowserBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.OpenFileDialog DataFileDialog;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.Label RowCountLbl;
    }
}