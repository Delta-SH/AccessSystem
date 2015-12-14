namespace Delta.MPS.AccessSystem
{
    partial class SaveRoleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveRoleForm));
            this.EnabledCB = new System.Windows.Forms.CheckBox();
            this.RoleCommentTB = new System.Windows.Forms.TextBox();
            this.RoleStatusLbl = new System.Windows.Forms.Label();
            this.RoleNameLbl = new System.Windows.Forms.Label();
            this.RoleCommentLbl = new System.Windows.Forms.Label();
            this.RoleNameTB = new System.Windows.Forms.TextBox();
            this.RoleIDTB = new System.Windows.Forms.TextBox();
            this.LeftGroupBox = new System.Windows.Forms.GroupBox();
            this.LeftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RoleIDLbl = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RoleSplitContainer = new System.Windows.Forms.SplitContainer();
            this.RightGroupBox = new System.Windows.Forms.GroupBox();
            this.RoleTabControl = new System.Windows.Forms.TabControl();
            this.AuthorizationTabPage = new System.Windows.Forms.TabPage();
            this.NodeTabPage = new System.Windows.Forms.TabPage();
            this.DepartmentTabPage = new System.Windows.Forms.TabPage();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.TreeViewContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewContextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem31 = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftGroupBox.SuspendLayout();
            this.LeftTableLayoutPanel.SuspendLayout();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoleSplitContainer)).BeginInit();
            this.RoleSplitContainer.Panel1.SuspendLayout();
            this.RoleSplitContainer.Panel2.SuspendLayout();
            this.RoleSplitContainer.SuspendLayout();
            this.RightGroupBox.SuspendLayout();
            this.RoleTabControl.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.TreeViewContextMenuStrip1.SuspendLayout();
            this.TreeViewContextMenuStrip2.SuspendLayout();
            this.TreeViewContextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnabledCB
            // 
            this.EnabledCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnabledCB.Location = new System.Drawing.Point(90, 285);
            this.EnabledCB.Margin = new System.Windows.Forms.Padding(0);
            this.EnabledCB.Name = "EnabledCB";
            this.EnabledCB.Size = new System.Drawing.Size(99, 25);
            this.EnabledCB.TabIndex = 8;
            this.EnabledCB.Text = "启用";
            this.EnabledCB.UseVisualStyleBackColor = true;
            // 
            // RoleCommentTB
            // 
            this.LeftTableLayoutPanel.SetColumnSpan(this.RoleCommentTB, 2);
            this.RoleCommentTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleCommentTB.Location = new System.Drawing.Point(5, 165);
            this.RoleCommentTB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RoleCommentTB.MaxLength = 256;
            this.RoleCommentTB.Multiline = true;
            this.RoleCommentTB.Name = "RoleCommentTB";
            this.RoleCommentTB.Size = new System.Drawing.Size(179, 100);
            this.RoleCommentTB.TabIndex = 6;
            // 
            // RoleStatusLbl
            // 
            this.RoleStatusLbl.Location = new System.Drawing.Point(5, 285);
            this.RoleStatusLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RoleStatusLbl.Name = "RoleStatusLbl";
            this.RoleStatusLbl.Size = new System.Drawing.Size(80, 25);
            this.RoleStatusLbl.TabIndex = 7;
            this.RoleStatusLbl.Text = "角色状态(&T):";
            this.RoleStatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RoleNameLbl
            // 
            this.LeftTableLayoutPanel.SetColumnSpan(this.RoleNameLbl, 2);
            this.RoleNameLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleNameLbl.Location = new System.Drawing.Point(5, 70);
            this.RoleNameLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RoleNameLbl.Name = "RoleNameLbl";
            this.RoleNameLbl.Size = new System.Drawing.Size(179, 25);
            this.RoleNameLbl.TabIndex = 3;
            this.RoleNameLbl.Text = "角色名称(&N):";
            this.RoleNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RoleCommentLbl
            // 
            this.LeftTableLayoutPanel.SetColumnSpan(this.RoleCommentLbl, 2);
            this.RoleCommentLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleCommentLbl.Location = new System.Drawing.Point(5, 140);
            this.RoleCommentLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RoleCommentLbl.Name = "RoleCommentLbl";
            this.RoleCommentLbl.Size = new System.Drawing.Size(179, 25);
            this.RoleCommentLbl.TabIndex = 5;
            this.RoleCommentLbl.Text = "角色描述(&D):";
            this.RoleCommentLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RoleNameTB
            // 
            this.LeftTableLayoutPanel.SetColumnSpan(this.RoleNameTB, 2);
            this.RoleNameTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RoleNameTB.Location = new System.Drawing.Point(5, 97);
            this.RoleNameTB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RoleNameTB.MaxLength = 50;
            this.RoleNameTB.Name = "RoleNameTB";
            this.RoleNameTB.Size = new System.Drawing.Size(179, 23);
            this.RoleNameTB.TabIndex = 4;
            // 
            // RoleIDTB
            // 
            this.RoleIDTB.BackColor = System.Drawing.Color.White;
            this.LeftTableLayoutPanel.SetColumnSpan(this.RoleIDTB, 2);
            this.RoleIDTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RoleIDTB.Location = new System.Drawing.Point(5, 27);
            this.RoleIDTB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RoleIDTB.MaxLength = 50;
            this.RoleIDTB.Name = "RoleIDTB";
            this.RoleIDTB.ReadOnly = true;
            this.RoleIDTB.Size = new System.Drawing.Size(179, 23);
            this.RoleIDTB.TabIndex = 2;
            // 
            // LeftGroupBox
            // 
            this.LeftGroupBox.Controls.Add(this.LeftTableLayoutPanel);
            this.LeftGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftGroupBox.Location = new System.Drawing.Point(0, 0);
            this.LeftGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.LeftGroupBox.Name = "LeftGroupBox";
            this.LeftGroupBox.Size = new System.Drawing.Size(195, 352);
            this.LeftGroupBox.TabIndex = 0;
            this.LeftGroupBox.TabStop = false;
            this.LeftGroupBox.Text = "基本信息";
            // 
            // LeftTableLayoutPanel
            // 
            this.LeftTableLayoutPanel.ColumnCount = 2;
            this.LeftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.LeftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftTableLayoutPanel.Controls.Add(this.EnabledCB, 1, 9);
            this.LeftTableLayoutPanel.Controls.Add(this.RoleIDLbl, 0, 0);
            this.LeftTableLayoutPanel.Controls.Add(this.RoleStatusLbl, 0, 9);
            this.LeftTableLayoutPanel.Controls.Add(this.RoleIDTB, 0, 1);
            this.LeftTableLayoutPanel.Controls.Add(this.RoleNameLbl, 0, 3);
            this.LeftTableLayoutPanel.Controls.Add(this.RoleNameTB, 0, 4);
            this.LeftTableLayoutPanel.Controls.Add(this.RoleCommentLbl, 0, 6);
            this.LeftTableLayoutPanel.Controls.Add(this.RoleCommentTB, 1, 6);
            this.LeftTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTableLayoutPanel.Location = new System.Drawing.Point(3, 19);
            this.LeftTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LeftTableLayoutPanel.Name = "LeftTableLayoutPanel";
            this.LeftTableLayoutPanel.RowCount = 11;
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.LeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LeftTableLayoutPanel.Size = new System.Drawing.Size(189, 330);
            this.LeftTableLayoutPanel.TabIndex = 0;
            // 
            // RoleIDLbl
            // 
            this.LeftTableLayoutPanel.SetColumnSpan(this.RoleIDLbl, 2);
            this.RoleIDLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleIDLbl.Location = new System.Drawing.Point(5, 0);
            this.RoleIDLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.RoleIDLbl.Name = "RoleIDLbl";
            this.RoleIDLbl.Size = new System.Drawing.Size(179, 25);
            this.RoleIDLbl.TabIndex = 1;
            this.RoleIDLbl.Text = "角色标识(&I):";
            this.RoleIDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SaveBtn.Location = new System.Drawing.Point(428, 10);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(90, 30);
            this.SaveBtn.TabIndex = 9;
            this.SaveBtn.Text = "保存(&S)";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(524, 10);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 10;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.RoleSplitContainer, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(634, 412);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // RoleSplitContainer
            // 
            this.RoleSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.RoleSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.RoleSplitContainer.Name = "RoleSplitContainer";
            // 
            // RoleSplitContainer.Panel1
            // 
            this.RoleSplitContainer.Panel1.Controls.Add(this.LeftGroupBox);
            this.RoleSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // RoleSplitContainer.Panel2
            // 
            this.RoleSplitContainer.Panel2.Controls.Add(this.RightGroupBox);
            this.RoleSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.RoleSplitContainer.Size = new System.Drawing.Size(614, 352);
            this.RoleSplitContainer.SplitterDistance = 200;
            this.RoleSplitContainer.TabIndex = 0;
            // 
            // RightGroupBox
            // 
            this.RightGroupBox.Controls.Add(this.RoleTabControl);
            this.RightGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightGroupBox.Location = new System.Drawing.Point(5, 0);
            this.RightGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.RightGroupBox.Name = "RightGroupBox";
            this.RightGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.RightGroupBox.Size = new System.Drawing.Size(405, 352);
            this.RightGroupBox.TabIndex = 0;
            this.RightGroupBox.TabStop = false;
            this.RightGroupBox.Text = "权限信息";
            // 
            // RoleTabControl
            // 
            this.RoleTabControl.Controls.Add(this.AuthorizationTabPage);
            this.RoleTabControl.Controls.Add(this.NodeTabPage);
            this.RoleTabControl.Controls.Add(this.DepartmentTabPage);
            this.RoleTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleTabControl.Location = new System.Drawing.Point(5, 21);
            this.RoleTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.RoleTabControl.Name = "RoleTabControl";
            this.RoleTabControl.SelectedIndex = 0;
            this.RoleTabControl.Size = new System.Drawing.Size(395, 326);
            this.RoleTabControl.TabIndex = 0;
            this.RoleTabControl.SelectedIndexChanged += new System.EventHandler(this.RoleTabControl_SelectedIndexChanged);
            // 
            // AuthorizationTabPage
            // 
            this.AuthorizationTabPage.Location = new System.Drawing.Point(4, 26);
            this.AuthorizationTabPage.Name = "AuthorizationTabPage";
            this.AuthorizationTabPage.Size = new System.Drawing.Size(387, 296);
            this.AuthorizationTabPage.TabIndex = 0;
            this.AuthorizationTabPage.Text = "授权菜单";
            this.AuthorizationTabPage.UseVisualStyleBackColor = true;
            // 
            // NodeTabPage
            // 
            this.NodeTabPage.Location = new System.Drawing.Point(4, 26);
            this.NodeTabPage.Name = "NodeTabPage";
            this.NodeTabPage.Size = new System.Drawing.Size(387, 296);
            this.NodeTabPage.TabIndex = 1;
            this.NodeTabPage.Text = "授权设备";
            this.NodeTabPage.UseVisualStyleBackColor = true;
            // 
            // DepartmentTabPage
            // 
            this.DepartmentTabPage.Location = new System.Drawing.Point(4, 26);
            this.DepartmentTabPage.Name = "DepartmentTabPage";
            this.DepartmentTabPage.Size = new System.Drawing.Size(387, 296);
            this.DepartmentTabPage.TabIndex = 2;
            this.DepartmentTabPage.Text = "授权部门";
            this.DepartmentTabPage.UseVisualStyleBackColor = true;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Controls.Add(this.SaveBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 362);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(614, 50);
            this.BottomPanel.TabIndex = 0;
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "Default");
            this.TreeImages.Images.SetKeyName(1, "Menu");
            this.TreeImages.Images.SetKeyName(2, "Area");
            this.TreeImages.Images.SetKeyName(3, "Device");
            this.TreeImages.Images.SetKeyName(4, "Department");
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
            // TreeViewContextMenuStrip3
            // 
            this.TreeViewContextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVToolStripMenuItem31});
            this.TreeViewContextMenuStrip3.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip3.Size = new System.Drawing.Size(125, 26);
            // 
            // TVToolStripMenuItem31
            // 
            this.TVToolStripMenuItem31.Image = global::Delta.MPS.AccessSystem.Properties.Resources.find;
            this.TVToolStripMenuItem31.Name = "TVToolStripMenuItem31";
            this.TVToolStripMenuItem31.Size = new System.Drawing.Size(124, 22);
            this.TVToolStripMenuItem31.Text = "查找节点";
            this.TVToolStripMenuItem31.Click += new System.EventHandler(this.TVToolStripMenuItem31_Click);
            // 
            // SaveRoleForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(634, 412);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "SaveRoleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "角色权限管理";
            this.Shown += new System.EventHandler(this.SaveRoleForm_Shown);
            this.LeftGroupBox.ResumeLayout(false);
            this.LeftTableLayoutPanel.ResumeLayout(false);
            this.LeftTableLayoutPanel.PerformLayout();
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.RoleSplitContainer.Panel1.ResumeLayout(false);
            this.RoleSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoleSplitContainer)).EndInit();
            this.RoleSplitContainer.ResumeLayout(false);
            this.RightGroupBox.ResumeLayout(false);
            this.RoleTabControl.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.TreeViewContextMenuStrip1.ResumeLayout(false);
            this.TreeViewContextMenuStrip2.ResumeLayout(false);
            this.TreeViewContextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LeftGroupBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox RoleIDTB;
        private System.Windows.Forms.Label RoleIDLbl;
        private System.Windows.Forms.TextBox RoleCommentTB;
        private System.Windows.Forms.Label RoleStatusLbl;
        private System.Windows.Forms.Label RoleCommentLbl;
        private System.Windows.Forms.TextBox RoleNameTB;
        private System.Windows.Forms.Label RoleNameLbl;
        private System.Windows.Forms.CheckBox EnabledCB;
        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.SplitContainer RoleSplitContainer;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.TableLayoutPanel LeftTableLayoutPanel;
        private System.Windows.Forms.GroupBox RightGroupBox;
        private System.Windows.Forms.TabControl RoleTabControl;
        private System.Windows.Forms.TabPage AuthorizationTabPage;
        private System.Windows.Forms.TabPage NodeTabPage;
        private System.Windows.Forms.TabPage DepartmentTabPage;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem11;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem21;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem31;
    }
}