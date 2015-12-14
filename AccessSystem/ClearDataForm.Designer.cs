namespace Delta.MPS.AccessSystem
{
    partial class ClearDataForm
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
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LogPanel1 = new System.Windows.Forms.GroupBox();
            this.CenterTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BeginDateDTP1 = new System.Windows.Forms.DateTimePicker();
            this.BeginDateLbl1 = new System.Windows.Forms.Label();
            this.EndDateLbl1 = new System.Windows.Forms.Label();
            this.LogTypeLbl1 = new System.Windows.Forms.Label();
            this.EndDateDTP1 = new System.Windows.Forms.DateTimePicker();
            this.LogTypeCB1 = new System.Windows.Forms.ComboBox();
            this.ClearBtn1 = new System.Windows.Forms.Button();
            this.LogPanel2 = new System.Windows.Forms.GroupBox();
            this.CenterTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BeginDateDTP2 = new System.Windows.Forms.DateTimePicker();
            this.BeginDateLbl2 = new System.Windows.Forms.Label();
            this.EndDateLbl2 = new System.Windows.Forms.Label();
            this.LogTypeLbl2 = new System.Windows.Forms.Label();
            this.EndDateDTP2 = new System.Windows.Forms.DateTimePicker();
            this.LogTypeCB2 = new System.Windows.Forms.ComboBox();
            this.ClearBtn2 = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.LogPanel1.SuspendLayout();
            this.CenterTableLayoutPanel1.SuspendLayout();
            this.LogPanel2.SuspendLayout();
            this.CenterTableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.LogPanel1, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.LogPanel2, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.CloseBtn, 0, 3);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 4;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(509, 262);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // LogPanel1
            // 
            this.LogPanel1.Controls.Add(this.CenterTableLayoutPanel1);
            this.LogPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPanel1.Location = new System.Drawing.Point(10, 10);
            this.LogPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.LogPanel1.Name = "LogPanel1";
            this.LogPanel1.Size = new System.Drawing.Size(489, 96);
            this.LogPanel1.TabIndex = 1;
            this.LogPanel1.TabStop = false;
            this.LogPanel1.Text = "清理日志(数据库记录)";
            // 
            // CenterTableLayoutPanel1
            // 
            this.CenterTableLayoutPanel1.ColumnCount = 4;
            this.CenterTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.CenterTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CenterTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.CenterTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CenterTableLayoutPanel1.Controls.Add(this.BeginDateDTP1, 1, 0);
            this.CenterTableLayoutPanel1.Controls.Add(this.BeginDateLbl1, 0, 0);
            this.CenterTableLayoutPanel1.Controls.Add(this.EndDateLbl1, 2, 0);
            this.CenterTableLayoutPanel1.Controls.Add(this.LogTypeLbl1, 0, 2);
            this.CenterTableLayoutPanel1.Controls.Add(this.EndDateDTP1, 3, 0);
            this.CenterTableLayoutPanel1.Controls.Add(this.LogTypeCB1, 1, 2);
            this.CenterTableLayoutPanel1.Controls.Add(this.ClearBtn1, 2, 2);
            this.CenterTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterTableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.CenterTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.CenterTableLayoutPanel1.Name = "CenterTableLayoutPanel1";
            this.CenterTableLayoutPanel1.RowCount = 4;
            this.CenterTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CenterTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.CenterTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CenterTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CenterTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CenterTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CenterTableLayoutPanel1.Size = new System.Drawing.Size(483, 74);
            this.CenterTableLayoutPanel1.TabIndex = 0;
            // 
            // BeginDateDTP1
            // 
            this.BeginDateDTP1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.BeginDateDTP1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BeginDateDTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginDateDTP1.Location = new System.Drawing.Point(85, 2);
            this.BeginDateDTP1.Margin = new System.Windows.Forms.Padding(0);
            this.BeginDateDTP1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.BeginDateDTP1.Name = "BeginDateDTP1";
            this.BeginDateDTP1.Size = new System.Drawing.Size(156, 23);
            this.BeginDateDTP1.TabIndex = 2;
            this.BeginDateDTP1.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // BeginDateLbl1
            // 
            this.BeginDateLbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginDateLbl1.Location = new System.Drawing.Point(3, 0);
            this.BeginDateLbl1.Name = "BeginDateLbl1";
            this.BeginDateLbl1.Size = new System.Drawing.Size(79, 25);
            this.BeginDateLbl1.TabIndex = 1;
            this.BeginDateLbl1.Text = "开始日期(&A):";
            this.BeginDateLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndDateLbl1
            // 
            this.EndDateLbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndDateLbl1.Location = new System.Drawing.Point(244, 0);
            this.EndDateLbl1.Name = "EndDateLbl1";
            this.EndDateLbl1.Size = new System.Drawing.Size(79, 25);
            this.EndDateLbl1.TabIndex = 3;
            this.EndDateLbl1.Text = "结束日期(&B):";
            this.EndDateLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogTypeLbl1
            // 
            this.LogTypeLbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTypeLbl1.Location = new System.Drawing.Point(3, 35);
            this.LogTypeLbl1.Name = "LogTypeLbl1";
            this.LogTypeLbl1.Size = new System.Drawing.Size(79, 25);
            this.LogTypeLbl1.TabIndex = 5;
            this.LogTypeLbl1.Text = "日志类型(&C):";
            this.LogTypeLbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndDateDTP1
            // 
            this.EndDateDTP1.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.EndDateDTP1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EndDateDTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDateDTP1.Location = new System.Drawing.Point(326, 2);
            this.EndDateDTP1.Margin = new System.Windows.Forms.Padding(0);
            this.EndDateDTP1.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.EndDateDTP1.Name = "EndDateDTP1";
            this.EndDateDTP1.Size = new System.Drawing.Size(157, 23);
            this.EndDateDTP1.TabIndex = 4;
            this.EndDateDTP1.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // LogTypeCB1
            // 
            this.LogTypeCB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTypeCB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LogTypeCB1.FormattingEnabled = true;
            this.LogTypeCB1.Location = new System.Drawing.Point(85, 35);
            this.LogTypeCB1.Margin = new System.Windows.Forms.Padding(0);
            this.LogTypeCB1.Name = "LogTypeCB1";
            this.LogTypeCB1.Size = new System.Drawing.Size(156, 25);
            this.LogTypeCB1.TabIndex = 6;
            // 
            // ClearBtn1
            // 
            this.ClearBtn1.Location = new System.Drawing.Point(246, 35);
            this.ClearBtn1.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ClearBtn1.Name = "ClearBtn1";
            this.ClearBtn1.Size = new System.Drawing.Size(75, 25);
            this.ClearBtn1.TabIndex = 7;
            this.ClearBtn1.Text = "清理(&D)";
            this.ClearBtn1.UseVisualStyleBackColor = true;
            this.ClearBtn1.Click += new System.EventHandler(this.ClearBtn1_Click);
            // 
            // LogPanel2
            // 
            this.LogPanel2.Controls.Add(this.CenterTableLayoutPanel2);
            this.LogPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogPanel2.Location = new System.Drawing.Point(10, 116);
            this.LogPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.LogPanel2.Name = "LogPanel2";
            this.LogPanel2.Size = new System.Drawing.Size(489, 96);
            this.LogPanel2.TabIndex = 2;
            this.LogPanel2.TabStop = false;
            this.LogPanel2.Text = "清理日志(文本文件)";
            // 
            // CenterTableLayoutPanel2
            // 
            this.CenterTableLayoutPanel2.ColumnCount = 4;
            this.CenterTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.CenterTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CenterTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.CenterTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CenterTableLayoutPanel2.Controls.Add(this.BeginDateDTP2, 1, 0);
            this.CenterTableLayoutPanel2.Controls.Add(this.BeginDateLbl2, 0, 0);
            this.CenterTableLayoutPanel2.Controls.Add(this.EndDateLbl2, 2, 0);
            this.CenterTableLayoutPanel2.Controls.Add(this.LogTypeLbl2, 0, 2);
            this.CenterTableLayoutPanel2.Controls.Add(this.EndDateDTP2, 3, 0);
            this.CenterTableLayoutPanel2.Controls.Add(this.LogTypeCB2, 1, 2);
            this.CenterTableLayoutPanel2.Controls.Add(this.ClearBtn2, 2, 2);
            this.CenterTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterTableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.CenterTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.CenterTableLayoutPanel2.Name = "CenterTableLayoutPanel2";
            this.CenterTableLayoutPanel2.RowCount = 4;
            this.CenterTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CenterTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.CenterTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.CenterTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CenterTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CenterTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.CenterTableLayoutPanel2.Size = new System.Drawing.Size(483, 74);
            this.CenterTableLayoutPanel2.TabIndex = 0;
            // 
            // BeginDateDTP2
            // 
            this.BeginDateDTP2.CustomFormat = "yyyy/MM/dd";
            this.BeginDateDTP2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BeginDateDTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginDateDTP2.Location = new System.Drawing.Point(85, 2);
            this.BeginDateDTP2.Margin = new System.Windows.Forms.Padding(0);
            this.BeginDateDTP2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.BeginDateDTP2.Name = "BeginDateDTP2";
            this.BeginDateDTP2.Size = new System.Drawing.Size(156, 23);
            this.BeginDateDTP2.TabIndex = 2;
            this.BeginDateDTP2.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // BeginDateLbl2
            // 
            this.BeginDateLbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginDateLbl2.Location = new System.Drawing.Point(3, 0);
            this.BeginDateLbl2.Name = "BeginDateLbl2";
            this.BeginDateLbl2.Size = new System.Drawing.Size(79, 25);
            this.BeginDateLbl2.TabIndex = 1;
            this.BeginDateLbl2.Text = "开始日期(&E):";
            this.BeginDateLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndDateLbl2
            // 
            this.EndDateLbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndDateLbl2.Location = new System.Drawing.Point(244, 0);
            this.EndDateLbl2.Name = "EndDateLbl2";
            this.EndDateLbl2.Size = new System.Drawing.Size(79, 25);
            this.EndDateLbl2.TabIndex = 3;
            this.EndDateLbl2.Text = "结束日期(&F):";
            this.EndDateLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogTypeLbl2
            // 
            this.LogTypeLbl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTypeLbl2.Location = new System.Drawing.Point(3, 35);
            this.LogTypeLbl2.Name = "LogTypeLbl2";
            this.LogTypeLbl2.Size = new System.Drawing.Size(79, 25);
            this.LogTypeLbl2.TabIndex = 5;
            this.LogTypeLbl2.Text = "日志类型(&G):";
            this.LogTypeLbl2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndDateDTP2
            // 
            this.EndDateDTP2.CustomFormat = "yyyy/MM/dd";
            this.EndDateDTP2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EndDateDTP2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDateDTP2.Location = new System.Drawing.Point(326, 2);
            this.EndDateDTP2.Margin = new System.Windows.Forms.Padding(0);
            this.EndDateDTP2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.EndDateDTP2.Name = "EndDateDTP2";
            this.EndDateDTP2.Size = new System.Drawing.Size(157, 23);
            this.EndDateDTP2.TabIndex = 4;
            this.EndDateDTP2.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // LogTypeCB2
            // 
            this.LogTypeCB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTypeCB2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LogTypeCB2.FormattingEnabled = true;
            this.LogTypeCB2.Location = new System.Drawing.Point(85, 35);
            this.LogTypeCB2.Margin = new System.Windows.Forms.Padding(0);
            this.LogTypeCB2.Name = "LogTypeCB2";
            this.LogTypeCB2.Size = new System.Drawing.Size(156, 25);
            this.LogTypeCB2.TabIndex = 6;
            // 
            // ClearBtn2
            // 
            this.ClearBtn2.Location = new System.Drawing.Point(246, 35);
            this.ClearBtn2.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ClearBtn2.Name = "ClearBtn2";
            this.ClearBtn2.Size = new System.Drawing.Size(75, 25);
            this.ClearBtn2.TabIndex = 7;
            this.ClearBtn2.Text = "清理(&H)";
            this.ClearBtn2.UseVisualStyleBackColor = true;
            this.ClearBtn2.Click += new System.EventHandler(this.ClearBtn2_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseBtn.Location = new System.Drawing.Point(409, 222);
            this.CloseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(90, 30);
            this.CloseBtn.TabIndex = 3;
            this.CloseBtn.Text = "关闭";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // ClearDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseBtn;
            this.ClientSize = new System.Drawing.Size(509, 262);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClearDataForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "清理数据";
            this.Load += new System.EventHandler(this.ClearDataForm_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.LogPanel1.ResumeLayout(false);
            this.CenterTableLayoutPanel1.ResumeLayout(false);
            this.LogPanel2.ResumeLayout(false);
            this.CenterTableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.GroupBox LogPanel1;
        private System.Windows.Forms.GroupBox LogPanel2;
        private System.Windows.Forms.TableLayoutPanel CenterTableLayoutPanel1;
        private System.Windows.Forms.Label BeginDateLbl1;
        private System.Windows.Forms.Label EndDateLbl1;
        private System.Windows.Forms.Label LogTypeLbl1;
        private System.Windows.Forms.DateTimePicker BeginDateDTP1;
        private System.Windows.Forms.DateTimePicker EndDateDTP1;
        private System.Windows.Forms.ComboBox LogTypeCB1;
        private System.Windows.Forms.Button ClearBtn1;
        private System.Windows.Forms.TableLayoutPanel CenterTableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker BeginDateDTP2;
        private System.Windows.Forms.Label BeginDateLbl2;
        private System.Windows.Forms.Label EndDateLbl2;
        private System.Windows.Forms.Label LogTypeLbl2;
        private System.Windows.Forms.DateTimePicker EndDateDTP2;
        private System.Windows.Forms.ComboBox LogTypeCB2;
        private System.Windows.Forms.Button ClearBtn2;
        private System.Windows.Forms.Button CloseBtn;

    }
}