namespace Delta.MPS.AccessSystem
{
    partial class SaveCardAuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveCardAuthForm));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CardsTreeView1 = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.RightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RightCenterGroupBox = new System.Windows.Forms.GroupBox();
            this.RightCenterTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BeginTimeLbl = new System.Windows.Forms.Label();
            this.EndTimeLbl = new System.Windows.Forms.Label();
            this.LimitTypeLbl = new System.Windows.Forms.Label();
            this.LimitIndexLbl = new System.Windows.Forms.Label();
            this.PwdLbl = new System.Windows.Forms.Label();
            this.BeginTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.EndTimeDTP = new System.Windows.Forms.DateTimePicker();
            this.LimitTypeCB = new System.Windows.Forms.ComboBox();
            this.LimitIndexCB = new System.Windows.Forms.ComboBox();
            this.PwdCB = new System.Windows.Forms.TextBox();
            this.EnabledCB = new System.Windows.Forms.CheckBox();
            this.RightBottomPanel = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.TreeViewContextMenuStrip.SuspendLayout();
            this.RightTableLayoutPanel.SuspendLayout();
            this.RightCenterGroupBox.SuspendLayout();
            this.RightCenterTableLayoutPanel.SuspendLayout();
            this.RightBottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.MainSplitContainer, 0, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainTableLayoutPanel.RowCount = 1;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 392F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(584, 412);
            this.MainTableLayoutPanel.TabIndex = 0;
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
            this.MainSplitContainer.Panel1.Controls.Add(this.CardsTreeView1);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.RightTableLayoutPanel);
            this.MainSplitContainer.Size = new System.Drawing.Size(564, 392);
            this.MainSplitContainer.SplitterDistance = 320;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // CardsTreeView1
            // 
            this.CardsTreeView1.CheckBoxes = true;
            this.CardsTreeView1.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.CardsTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardsTreeView1.HideSelection = false;
            this.CardsTreeView1.ImageKey = "Department";
            this.CardsTreeView1.ImageList = this.TreeImages;
            this.CardsTreeView1.Location = new System.Drawing.Point(0, 0);
            this.CardsTreeView1.Margin = new System.Windows.Forms.Padding(0);
            this.CardsTreeView1.Name = "CardsTreeView1";
            this.CardsTreeView1.SelectedImageKey = "Department";
            this.CardsTreeView1.Size = new System.Drawing.Size(315, 392);
            this.CardsTreeView1.TabIndex = 0;
            this.CardsTreeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.CardsTreeView1_AfterCheck);
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
            this.TreeImages.Images.SetKeyName(0, "Department");
            this.TreeImages.Images.SetKeyName(1, "Employee");
            this.TreeImages.Images.SetKeyName(2, "OutEmployee");
            this.TreeImages.Images.SetKeyName(3, "Card");
            // 
            // RightTableLayoutPanel
            // 
            this.RightTableLayoutPanel.ColumnCount = 1;
            this.RightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.RightTableLayoutPanel.Controls.Add(this.RightCenterGroupBox, 0, 0);
            this.RightTableLayoutPanel.Controls.Add(this.RightBottomPanel, 0, 1);
            this.RightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.RightTableLayoutPanel.Name = "RightTableLayoutPanel";
            this.RightTableLayoutPanel.RowCount = 2;
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.RightTableLayoutPanel.Size = new System.Drawing.Size(240, 392);
            this.RightTableLayoutPanel.TabIndex = 2;
            // 
            // RightCenterGroupBox
            // 
            this.RightCenterGroupBox.Controls.Add(this.RightCenterTableLayoutPanel);
            this.RightCenterGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightCenterGroupBox.Location = new System.Drawing.Point(0, 0);
            this.RightCenterGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.RightCenterGroupBox.Name = "RightCenterGroupBox";
            this.RightCenterGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.RightCenterGroupBox.Size = new System.Drawing.Size(240, 352);
            this.RightCenterGroupBox.TabIndex = 1;
            this.RightCenterGroupBox.TabStop = false;
            this.RightCenterGroupBox.Text = "授权信息";
            // 
            // RightCenterTableLayoutPanel
            // 
            this.RightCenterTableLayoutPanel.ColumnCount = 1;
            this.RightCenterTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightCenterTableLayoutPanel.Controls.Add(this.BeginTimeLbl, 0, 0);
            this.RightCenterTableLayoutPanel.Controls.Add(this.EndTimeLbl, 0, 3);
            this.RightCenterTableLayoutPanel.Controls.Add(this.LimitTypeLbl, 0, 6);
            this.RightCenterTableLayoutPanel.Controls.Add(this.LimitIndexLbl, 0, 9);
            this.RightCenterTableLayoutPanel.Controls.Add(this.PwdLbl, 0, 12);
            this.RightCenterTableLayoutPanel.Controls.Add(this.BeginTimeDTP, 0, 1);
            this.RightCenterTableLayoutPanel.Controls.Add(this.EndTimeDTP, 0, 4);
            this.RightCenterTableLayoutPanel.Controls.Add(this.LimitTypeCB, 0, 7);
            this.RightCenterTableLayoutPanel.Controls.Add(this.LimitIndexCB, 0, 10);
            this.RightCenterTableLayoutPanel.Controls.Add(this.PwdCB, 0, 13);
            this.RightCenterTableLayoutPanel.Controls.Add(this.EnabledCB, 0, 15);
            this.RightCenterTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightCenterTableLayoutPanel.Location = new System.Drawing.Point(5, 21);
            this.RightCenterTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightCenterTableLayoutPanel.Name = "RightCenterTableLayoutPanel";
            this.RightCenterTableLayoutPanel.RowCount = 16;
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.RightCenterTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightCenterTableLayoutPanel.Size = new System.Drawing.Size(230, 326);
            this.RightCenterTableLayoutPanel.TabIndex = 1;
            // 
            // BeginTimeLbl
            // 
            this.BeginTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginTimeLbl.Location = new System.Drawing.Point(0, 0);
            this.BeginTimeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimeLbl.Name = "BeginTimeLbl";
            this.BeginTimeLbl.Size = new System.Drawing.Size(230, 25);
            this.BeginTimeLbl.TabIndex = 1;
            this.BeginTimeLbl.Text = "开始日期(&B):";
            this.BeginTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndTimeLbl
            // 
            this.EndTimeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndTimeLbl.Location = new System.Drawing.Point(0, 60);
            this.EndTimeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.EndTimeLbl.Name = "EndTimeLbl";
            this.EndTimeLbl.Size = new System.Drawing.Size(230, 25);
            this.EndTimeLbl.TabIndex = 3;
            this.EndTimeLbl.Text = "结束日期(&E):";
            this.EndTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LimitTypeLbl
            // 
            this.LimitTypeLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimitTypeLbl.Location = new System.Drawing.Point(0, 120);
            this.LimitTypeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.LimitTypeLbl.Name = "LimitTypeLbl";
            this.LimitTypeLbl.Size = new System.Drawing.Size(230, 25);
            this.LimitTypeLbl.TabIndex = 5;
            this.LimitTypeLbl.Text = "权限类型(&T):";
            this.LimitTypeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LimitIndexLbl
            // 
            this.LimitIndexLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimitIndexLbl.Location = new System.Drawing.Point(0, 180);
            this.LimitIndexLbl.Margin = new System.Windows.Forms.Padding(0);
            this.LimitIndexLbl.Name = "LimitIndexLbl";
            this.LimitIndexLbl.Size = new System.Drawing.Size(230, 25);
            this.LimitIndexLbl.TabIndex = 7;
            this.LimitIndexLbl.Text = "权限分组(&G):";
            this.LimitIndexLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PwdLbl
            // 
            this.PwdLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PwdLbl.Location = new System.Drawing.Point(0, 240);
            this.PwdLbl.Margin = new System.Windows.Forms.Padding(0);
            this.PwdLbl.Name = "PwdLbl";
            this.PwdLbl.Size = new System.Drawing.Size(230, 25);
            this.PwdLbl.TabIndex = 9;
            this.PwdLbl.Text = "个人密码(&P):";
            this.PwdLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BeginTimeDTP
            // 
            this.BeginTimeDTP.CustomFormat = "yyyy/MM/dd";
            this.BeginTimeDTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BeginTimeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BeginTimeDTP.Location = new System.Drawing.Point(0, 25);
            this.BeginTimeDTP.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimeDTP.Name = "BeginTimeDTP";
            this.BeginTimeDTP.Size = new System.Drawing.Size(230, 23);
            this.BeginTimeDTP.TabIndex = 2;
            this.BeginTimeDTP.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            // 
            // EndTimeDTP
            // 
            this.EndTimeDTP.CustomFormat = "yyyy/MM/dd";
            this.EndTimeDTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndTimeDTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTimeDTP.Location = new System.Drawing.Point(0, 85);
            this.EndTimeDTP.Margin = new System.Windows.Forms.Padding(0);
            this.EndTimeDTP.Name = "EndTimeDTP";
            this.EndTimeDTP.Size = new System.Drawing.Size(230, 23);
            this.EndTimeDTP.TabIndex = 4;
            this.EndTimeDTP.Value = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            // 
            // LimitTypeCB
            // 
            this.LimitTypeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimitTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LimitTypeCB.FormattingEnabled = true;
            this.LimitTypeCB.Location = new System.Drawing.Point(0, 145);
            this.LimitTypeCB.Margin = new System.Windows.Forms.Padding(0);
            this.LimitTypeCB.Name = "LimitTypeCB";
            this.LimitTypeCB.Size = new System.Drawing.Size(230, 25);
            this.LimitTypeCB.TabIndex = 6;
            this.LimitTypeCB.SelectedIndexChanged += new System.EventHandler(this.LimitTypeCB_SelectedIndexChanged);
            // 
            // LimitIndexCB
            // 
            this.LimitIndexCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LimitIndexCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LimitIndexCB.FormattingEnabled = true;
            this.LimitIndexCB.Location = new System.Drawing.Point(0, 205);
            this.LimitIndexCB.Margin = new System.Windows.Forms.Padding(0);
            this.LimitIndexCB.Name = "LimitIndexCB";
            this.LimitIndexCB.Size = new System.Drawing.Size(230, 25);
            this.LimitIndexCB.TabIndex = 8;
            // 
            // PwdCB
            // 
            this.PwdCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PwdCB.Location = new System.Drawing.Point(0, 265);
            this.PwdCB.Margin = new System.Windows.Forms.Padding(0);
            this.PwdCB.MaxLength = 20;
            this.PwdCB.Name = "PwdCB";
            this.PwdCB.Size = new System.Drawing.Size(230, 23);
            this.PwdCB.TabIndex = 10;
            // 
            // EnabledCB
            // 
            this.EnabledCB.AutoSize = true;
            this.EnabledCB.Checked = true;
            this.EnabledCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnabledCB.Location = new System.Drawing.Point(3, 303);
            this.EnabledCB.Name = "EnabledCB";
            this.EnabledCB.Size = new System.Drawing.Size(66, 20);
            this.EnabledCB.TabIndex = 11;
            this.EnabledCB.Text = "启用(&Y)";
            this.EnabledCB.UseVisualStyleBackColor = true;
            // 
            // RightBottomPanel
            // 
            this.RightBottomPanel.Controls.Add(this.SaveBtn);
            this.RightBottomPanel.Controls.Add(this.CancelBtn);
            this.RightBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightBottomPanel.Location = new System.Drawing.Point(0, 352);
            this.RightBottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RightBottomPanel.Name = "RightBottomPanel";
            this.RightBottomPanel.Size = new System.Drawing.Size(240, 40);
            this.RightBottomPanel.TabIndex = 2;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SaveBtn.Location = new System.Drawing.Point(0, 10);
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
            this.CancelBtn.Location = new System.Drawing.Point(151, 10);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveCardAuthForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "SaveCardAuthForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "卡片授权管理";
            this.Shown += new System.EventHandler(this.SaveCardAuthForm_Shown);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            this.RightTableLayoutPanel.ResumeLayout(false);
            this.RightCenterGroupBox.ResumeLayout(false);
            this.RightCenterTableLayoutPanel.ResumeLayout(false);
            this.RightCenterTableLayoutPanel.PerformLayout();
            this.RightBottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel RightBottomPanel;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TableLayoutPanel RightTableLayoutPanel;
        private System.Windows.Forms.GroupBox RightCenterGroupBox;
        private System.Windows.Forms.TableLayoutPanel RightCenterTableLayoutPanel;
        private System.Windows.Forms.Label BeginTimeLbl;
        private System.Windows.Forms.Label EndTimeLbl;
        private System.Windows.Forms.Label LimitTypeLbl;
        private System.Windows.Forms.Label LimitIndexLbl;
        private System.Windows.Forms.Label PwdLbl;
        private System.Windows.Forms.DateTimePicker EndTimeDTP;
        private System.Windows.Forms.ComboBox LimitTypeCB;
        private System.Windows.Forms.ComboBox LimitIndexCB;
        private System.Windows.Forms.TextBox PwdCB;
        private System.Windows.Forms.DateTimePicker BeginTimeDTP;
        private System.Windows.Forms.CheckBox EnabledCB;
        private System.Windows.Forms.TreeView CardsTreeView1;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem1;
    }
}