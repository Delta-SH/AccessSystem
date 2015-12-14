namespace Delta.MPS.AccessSystem
{
    partial class BatchCardAuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchCardAuthForm));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CenterGroupBox = new System.Windows.Forms.GroupBox();
            this.RightCenterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BeginTimeLbl = new System.Windows.Forms.Label();
            this.BeginTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.EndTimeLbl = new System.Windows.Forms.Label();
            this.EndTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.LimitTypeLbl = new System.Windows.Forms.Label();
            this.LimitTypeCB = new System.Windows.Forms.ComboBox();
            this.LimitIndexLbl = new System.Windows.Forms.Label();
            this.LimitIndexCB = new System.Windows.Forms.ComboBox();
            this.PwdLbl = new System.Windows.Forms.Label();
            this.PwdCB = new System.Windows.Forms.TextBox();
            this.EnabledLbl = new System.Windows.Forms.Label();
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.SyncCB = new System.Windows.Forms.CheckBox();
            this.EnabledCB = new System.Windows.Forms.CheckBox();
            this.TopSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DevTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.CardTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.CenterGroupBox.SuspendLayout();
            this.RightCenterTableLayoutPanel.SuspendLayout();
            this.PanelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopSplitContainer)).BeginInit();
            this.TopSplitContainer.Panel1.SuspendLayout();
            this.TopSplitContainer.Panel2.SuspendLayout();
            this.TopSplitContainer.SuspendLayout();
            this.TreeViewContextMenuStrip1.SuspendLayout();
            this.TreeViewContextMenuStrip2.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.CenterGroupBox, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.TopSplitContainer, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 3);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 4;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(584, 412);
            this.MainTableLayoutPanel.TabIndex = 1;
            // 
            // CenterGroupBox
            // 
            this.CenterGroupBox.Controls.Add(this.RightCenterTableLayoutPanel);
            this.CenterGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterGroupBox.Location = new System.Drawing.Point(10, 242);
            this.CenterGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.CenterGroupBox.Name = "CenterGroupBox";
            this.CenterGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.CenterGroupBox.Size = new System.Drawing.Size(564, 120);
            this.CenterGroupBox.TabIndex = 2;
            this.CenterGroupBox.TabStop = false;
            this.CenterGroupBox.Text = "授权信息";
            // 
            // RightCenterTableLayoutPanel
            // 
            this.RightCenterTableLayoutPanel.ColumnCount = 5;
            this.RightCenterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.RightCenterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightCenterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightCenterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.RightCenterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RightCenterTableLayoutPanel.Controls.Add(this.BeginTimeLbl, 0, 0);
            this.RightCenterTableLayoutPanel.Controls.Add(this.BeginTimeDTP, 1, 0);
            this.RightCenterTableLayoutPanel.Controls.Add(this.EndTimeLbl, 3, 0);
            this.RightCenterTableLayoutPanel.Controls.Add(this.EndTimeDTP, 4, 0);
            this.RightCenterTableLayoutPanel.Controls.Add(this.LimitTypeLbl, 0, 2);
            this.RightCenterTableLayoutPanel.Controls.Add(this.LimitTypeCB, 1, 2);
            this.RightCenterTableLayoutPanel.Controls.Add(this.LimitIndexLbl, 3, 2);
            this.RightCenterTableLayoutPanel.Controls.Add(this.LimitIndexCB, 4, 2);
            this.RightCenterTableLayoutPanel.Controls.Add(this.PwdLbl, 0, 4);
            this.RightCenterTableLayoutPanel.Controls.Add(this.PwdCB, 1, 4);
            this.RightCenterTableLayoutPanel.Controls.Add(this.EnabledLbl, 3, 4);
            this.RightCenterTableLayoutPanel.Controls.Add(this.PanelContainer, 4, 4);
            this.RightCenterTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightCenterTableLayoutPanel.Location = new System.Drawing.Point(5, 21);
            this.RightCenterTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightCenterTableLayoutPanel.Name = "RightCenterTableLayoutPanel";
            this.RightCenterTableLayoutPanel.RowCount = 7;
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightCenterTableLayoutPanel.Size = new System.Drawing.Size(554, 94);
            this.RightCenterTableLayoutPanel.TabIndex = 1;
            // 
            // BeginTimeLbl
            // 
            this.BeginTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginTimeLbl.Location = new System.Drawing.Point(0, 0);
            this.BeginTimeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimeLbl.Name = "BeginTimeLbl";
            this.BeginTimeLbl.Size = new System.Drawing.Size(80, 25);
            this.BeginTimeLbl.TabIndex = 1;
            this.BeginTimeLbl.Text = "开始日期(&B):";
            this.BeginTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BeginTimeDTP
            // 
            this.BeginTimeDTP.CustomFormat = "yyyy/MM/dd";
            this.BeginTimeDTP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BeginTimeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginTimeDTP.Location = new System.Drawing.Point(80, 2);
            this.BeginTimeDTP.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimeDTP.Name = "BeginTimeDTP";
            this.BeginTimeDTP.Size = new System.Drawing.Size(187, 23);
            this.BeginTimeDTP.TabIndex = 2;
            this.BeginTimeDTP.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // EndTimeLbl
            // 
            this.EndTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndTimeLbl.Location = new System.Drawing.Point(287, 0);
            this.EndTimeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.EndTimeLbl.Name = "EndTimeLbl";
            this.EndTimeLbl.Size = new System.Drawing.Size(80, 25);
            this.EndTimeLbl.TabIndex = 3;
            this.EndTimeLbl.Text = "结束日期(&E):";
            this.EndTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndTimeDTP
            // 
            this.EndTimeDTP.CustomFormat = "yyyy/MM/dd";
            this.EndTimeDTP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EndTimeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTimeDTP.Location = new System.Drawing.Point(367, 2);
            this.EndTimeDTP.Margin = new System.Windows.Forms.Padding(0);
            this.EndTimeDTP.Name = "EndTimeDTP";
            this.EndTimeDTP.Size = new System.Drawing.Size(187, 23);
            this.EndTimeDTP.TabIndex = 4;
            this.EndTimeDTP.Value = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            // 
            // LimitTypeLbl
            // 
            this.LimitTypeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimitTypeLbl.Location = new System.Drawing.Point(0, 35);
            this.LimitTypeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.LimitTypeLbl.Name = "LimitTypeLbl";
            this.LimitTypeLbl.Size = new System.Drawing.Size(80, 25);
            this.LimitTypeLbl.TabIndex = 5;
            this.LimitTypeLbl.Text = "权限类型(&T):";
            this.LimitTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LimitTypeCB
            // 
            this.LimitTypeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimitTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LimitTypeCB.FormattingEnabled = true;
            this.LimitTypeCB.Location = new System.Drawing.Point(80, 35);
            this.LimitTypeCB.Margin = new System.Windows.Forms.Padding(0);
            this.LimitTypeCB.Name = "LimitTypeCB";
            this.LimitTypeCB.Size = new System.Drawing.Size(187, 25);
            this.LimitTypeCB.TabIndex = 6;
            this.LimitTypeCB.SelectedIndexChanged += new System.EventHandler(this.LimitTypeCB_SelectedIndexChanged);
            // 
            // LimitIndexLbl
            // 
            this.LimitIndexLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimitIndexLbl.Location = new System.Drawing.Point(287, 35);
            this.LimitIndexLbl.Margin = new System.Windows.Forms.Padding(0);
            this.LimitIndexLbl.Name = "LimitIndexLbl";
            this.LimitIndexLbl.Size = new System.Drawing.Size(80, 25);
            this.LimitIndexLbl.TabIndex = 7;
            this.LimitIndexLbl.Text = "权限分组(&G):";
            this.LimitIndexLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LimitIndexCB
            // 
            this.LimitIndexCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimitIndexCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LimitIndexCB.FormattingEnabled = true;
            this.LimitIndexCB.Location = new System.Drawing.Point(367, 35);
            this.LimitIndexCB.Margin = new System.Windows.Forms.Padding(0);
            this.LimitIndexCB.Name = "LimitIndexCB";
            this.LimitIndexCB.Size = new System.Drawing.Size(187, 25);
            this.LimitIndexCB.TabIndex = 8;
            // 
            // PwdLbl
            // 
            this.PwdLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PwdLbl.Location = new System.Drawing.Point(0, 70);
            this.PwdLbl.Margin = new System.Windows.Forms.Padding(0);
            this.PwdLbl.Name = "PwdLbl";
            this.PwdLbl.Size = new System.Drawing.Size(80, 25);
            this.PwdLbl.TabIndex = 9;
            this.PwdLbl.Text = "个人密码(&P):";
            this.PwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PwdCB
            // 
            this.PwdCB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PwdCB.Location = new System.Drawing.Point(80, 72);
            this.PwdCB.Margin = new System.Windows.Forms.Padding(0);
            this.PwdCB.MaxLength = 20;
            this.PwdCB.Name = "PwdCB";
            this.PwdCB.Size = new System.Drawing.Size(187, 23);
            this.PwdCB.TabIndex = 10;
            // 
            // EnabledLbl
            // 
            this.EnabledLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnabledLbl.Location = new System.Drawing.Point(287, 70);
            this.EnabledLbl.Margin = new System.Windows.Forms.Padding(0);
            this.EnabledLbl.Name = "EnabledLbl";
            this.EnabledLbl.Size = new System.Drawing.Size(80, 25);
            this.EnabledLbl.TabIndex = 11;
            this.EnabledLbl.Text = "授权状态:";
            this.EnabledLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PanelContainer
            // 
            this.PanelContainer.Controls.Add(this.SyncCB);
            this.PanelContainer.Controls.Add(this.EnabledCB);
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContainer.Location = new System.Drawing.Point(367, 70);
            this.PanelContainer.Margin = new System.Windows.Forms.Padding(0);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(187, 25);
            this.PanelContainer.TabIndex = 12;
            // 
            // SyncCB
            // 
            this.SyncCB.Dock = System.Windows.Forms.DockStyle.Right;
            this.SyncCB.Location = new System.Drawing.Point(97, 0);
            this.SyncCB.Margin = new System.Windows.Forms.Padding(0);
            this.SyncCB.Name = "SyncCB";
            this.SyncCB.Size = new System.Drawing.Size(90, 25);
            this.SyncCB.TabIndex = 14;
            this.SyncCB.Text = "时间同步(&S)";
            this.SyncCB.UseVisualStyleBackColor = true;
            // 
            // EnabledCB
            // 
            this.EnabledCB.Checked = true;
            this.EnabledCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnabledCB.Dock = System.Windows.Forms.DockStyle.Left;
            this.EnabledCB.Location = new System.Drawing.Point(0, 0);
            this.EnabledCB.Margin = new System.Windows.Forms.Padding(0);
            this.EnabledCB.Name = "EnabledCB";
            this.EnabledCB.Size = new System.Drawing.Size(70, 25);
            this.EnabledCB.TabIndex = 13;
            this.EnabledCB.Text = "启用(&Y)";
            this.EnabledCB.UseVisualStyleBackColor = true;
            // 
            // TopSplitContainer
            // 
            this.TopSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.TopSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.TopSplitContainer.Name = "TopSplitContainer";
            // 
            // TopSplitContainer.Panel1
            // 
            this.TopSplitContainer.Panel1.Controls.Add(this.DevTreeView);
            this.TopSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // TopSplitContainer.Panel2
            // 
            this.TopSplitContainer.Panel2.Controls.Add(this.CardTreeView);
            this.TopSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.TopSplitContainer.Size = new System.Drawing.Size(564, 227);
            this.TopSplitContainer.SplitterDistance = 282;
            this.TopSplitContainer.TabIndex = 1;
            // 
            // DevTreeView
            // 
            this.DevTreeView.CheckBoxes = true;
            this.DevTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip1;
            this.DevTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DevTreeView.HideSelection = false;
            this.DevTreeView.ImageKey = "Area";
            this.DevTreeView.ImageList = this.TreeImages;
            this.DevTreeView.Location = new System.Drawing.Point(0, 0);
            this.DevTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.DevTreeView.Name = "DevTreeView";
            this.DevTreeView.SelectedImageKey = "Area";
            this.DevTreeView.Size = new System.Drawing.Size(277, 227);
            this.DevTreeView.TabIndex = 0;
            this.DevTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.DevTreeView_AfterCheck);
            // 
            // TreeViewContextMenuStrip1
            // 
            this.TreeViewContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVToolStripMenuItem11});
            this.TreeViewContextMenuStrip1.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // TVToolStripMenuItem11
            // 
            this.TVToolStripMenuItem11.Image = global::Delta.MPS.AccessSystem.Properties.Resources.find;
            this.TVToolStripMenuItem11.Name = "TVToolStripMenuItem11";
            this.TVToolStripMenuItem11.Size = new System.Drawing.Size(124, 22);
            this.TVToolStripMenuItem11.Text = "查找节点";
            this.TVToolStripMenuItem11.Click += new System.EventHandler(this.TVToolStripMenuItem11_Click);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "Area");
            this.TreeImages.Images.SetKeyName(1, "Device");
            this.TreeImages.Images.SetKeyName(2, "Department");
            this.TreeImages.Images.SetKeyName(3, "Employee");
            this.TreeImages.Images.SetKeyName(4, "OutEmployee");
            this.TreeImages.Images.SetKeyName(5, "Card");
            // 
            // CardTreeView
            // 
            this.CardTreeView.CheckBoxes = true;
            this.CardTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip2;
            this.CardTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardTreeView.HideSelection = false;
            this.CardTreeView.ImageKey = "Department";
            this.CardTreeView.ImageList = this.TreeImages;
            this.CardTreeView.Location = new System.Drawing.Point(5, 0);
            this.CardTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.CardTreeView.Name = "CardTreeView";
            this.CardTreeView.SelectedImageKey = "Department";
            this.CardTreeView.Size = new System.Drawing.Size(273, 227);
            this.CardTreeView.TabIndex = 0;
            this.CardTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.CardTreeView_AfterCheck);
            // 
            // TreeViewContextMenuStrip2
            // 
            this.TreeViewContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVToolStripMenuItem21});
            this.TreeViewContextMenuStrip2.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip2.Size = new System.Drawing.Size(125, 26);
            // 
            // TVToolStripMenuItem21
            // 
            this.TVToolStripMenuItem21.Image = global::Delta.MPS.AccessSystem.Properties.Resources.find;
            this.TVToolStripMenuItem21.Name = "TVToolStripMenuItem21";
            this.TVToolStripMenuItem21.Size = new System.Drawing.Size(124, 22);
            this.TVToolStripMenuItem21.Text = "查找节点";
            this.TVToolStripMenuItem21.Click += new System.EventHandler(this.TVToolStripMenuItem21_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.SaveBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 362);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(564, 50);
            this.BottomPanel.TabIndex = 3;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SaveBtn.Location = new System.Drawing.Point(374, 10);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(90, 30);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "保存(&S)";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(474, 10);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // BatchCardAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "BatchCardAuthForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量授权管理";
            this.Shown += new System.EventHandler(this.BatchCardAuthForm_Shown);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.CenterGroupBox.ResumeLayout(false);
            this.RightCenterTableLayoutPanel.ResumeLayout(false);
            this.RightCenterTableLayoutPanel.PerformLayout();
            this.PanelContainer.ResumeLayout(false);
            this.TopSplitContainer.Panel1.ResumeLayout(false);
            this.TopSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TopSplitContainer)).EndInit();
            this.TopSplitContainer.ResumeLayout(false);
            this.TreeViewContextMenuStrip1.ResumeLayout(false);
            this.TreeViewContextMenuStrip2.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.SplitContainer TopSplitContainer;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TreeView DevTreeView;
        private System.Windows.Forms.TreeView CardTreeView;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.GroupBox CenterGroupBox;
        private System.Windows.Forms.TableLayoutPanel RightCenterTableLayoutPanel;
        private System.Windows.Forms.Label BeginTimeLbl;
        private System.Windows.Forms.Label EndTimeLbl;
        private System.Windows.Forms.DateTimePicker BeginTimeDTP;
        private System.Windows.Forms.DateTimePicker EndTimeDTP;
        private System.Windows.Forms.Label LimitTypeLbl;
        private System.Windows.Forms.ComboBox LimitTypeCB;
        private System.Windows.Forms.Label LimitIndexLbl;
        private System.Windows.Forms.ComboBox LimitIndexCB;
        private System.Windows.Forms.Label PwdLbl;
        private System.Windows.Forms.TextBox PwdCB;
        private System.Windows.Forms.Label EnabledLbl;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem11;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem21;
        private System.Windows.Forms.Panel PanelContainer;
        private System.Windows.Forms.CheckBox EnabledCB;
        private System.Windows.Forms.CheckBox SyncCB;

    }
}