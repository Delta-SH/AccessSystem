namespace Delta.MPS.AccessSystem
{
    partial class OrgEmployeeDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrgEmployeeDialog));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.SubEmpCB = new System.Windows.Forms.CheckBox();
            this.lineLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DeptTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.EmpTreeView = new System.Windows.Forms.TreeView();
            this.OperationContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OpMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.TreeViewContextMenuStrip.SuspendLayout();
            this.OperationContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.MainSplitContainer, 0, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 3;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(534, 412);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.SubEmpCB);
            this.BottomPanel.Controls.Add(this.lineLbl);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Controls.Add(this.OKBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 362);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(514, 50);
            this.BottomPanel.TabIndex = 1;
            // 
            // SubEmpCB
            // 
            this.SubEmpCB.BackColor = System.Drawing.Color.Transparent;
            this.SubEmpCB.Location = new System.Drawing.Point(0, 2);
            this.SubEmpCB.Margin = new System.Windows.Forms.Padding(0);
            this.SubEmpCB.Name = "SubEmpCB";
            this.SubEmpCB.Size = new System.Drawing.Size(180, 20);
            this.SubEmpCB.TabIndex = 9;
            this.SubEmpCB.Text = "显示所有子级部门员工";
            this.SubEmpCB.UseVisualStyleBackColor = false;
            this.SubEmpCB.CheckedChanged += new System.EventHandler(this.SubEmpCB_CheckedChanged);
            // 
            // lineLbl
            // 
            this.lineLbl.BackColor = System.Drawing.Color.Transparent;
            this.lineLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lineLbl.Location = new System.Drawing.Point(0, 0);
            this.lineLbl.Name = "lineLbl";
            this.lineLbl.Size = new System.Drawing.Size(514, 2);
            this.lineLbl.TabIndex = 0;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(424, 10);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OKBtn.Location = new System.Drawing.Point(315, 10);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(90, 30);
            this.OKBtn.TabIndex = 4;
            this.OKBtn.Text = "确定(&O)";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
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
            this.MainSplitContainer.Panel1.Controls.Add(this.DeptTreeView);
            this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.EmpTreeView);
            this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.MainSplitContainer.Size = new System.Drawing.Size(514, 347);
            this.MainSplitContainer.SplitterDistance = 220;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // DeptTreeView
            // 
            this.DeptTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.DeptTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeptTreeView.HideSelection = false;
            this.DeptTreeView.ImageKey = "Department";
            this.DeptTreeView.ImageList = this.TreeImages;
            this.DeptTreeView.Location = new System.Drawing.Point(0, 0);
            this.DeptTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.DeptTreeView.Name = "DeptTreeView";
            this.DeptTreeView.SelectedImageKey = "Department";
            this.DeptTreeView.Size = new System.Drawing.Size(215, 347);
            this.DeptTreeView.TabIndex = 0;
            this.DeptTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DeptTreeView_AfterSelect);
            // 
            // TreeViewContextMenuStrip
            // 
            this.TreeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVToolStripMenuItem1});
            this.TreeViewContextMenuStrip.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // TVToolStripMenuItem1
            // 
            this.TVToolStripMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.find;
            this.TVToolStripMenuItem1.Name = "TVToolStripMenuItem1";
            this.TVToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.TVToolStripMenuItem1.Text = "查找节点";
            this.TVToolStripMenuItem1.Click += new System.EventHandler(this.TVToolStripMenuItem1_Click);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "Department");
            this.TreeImages.Images.SetKeyName(1, "Employee");
            // 
            // EmpTreeView
            // 
            this.EmpTreeView.ContextMenuStrip = this.OperationContextMenu;
            this.EmpTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmpTreeView.FullRowSelect = true;
            this.EmpTreeView.HideSelection = false;
            this.EmpTreeView.ImageKey = "Employee";
            this.EmpTreeView.ImageList = this.TreeImages;
            this.EmpTreeView.Location = new System.Drawing.Point(5, 0);
            this.EmpTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.EmpTreeView.Name = "EmpTreeView";
            this.EmpTreeView.SelectedImageKey = "Employee";
            this.EmpTreeView.ShowRootLines = false;
            this.EmpTreeView.Size = new System.Drawing.Size(285, 347);
            this.EmpTreeView.TabIndex = 0;
            // 
            // OperationContextMenu
            // 
            this.OperationContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpMenuItem1,
            this.OpMenuItem2,
            this.OpSeparator1,
            this.OpMenuItem3});
            this.OperationContextMenu.Name = "OperationContextMenu";
            this.OperationContextMenu.Size = new System.Drawing.Size(125, 76);
            this.OperationContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OperationContextMenu_Opening);
            // 
            // OpMenuItem1
            // 
            this.OpMenuItem1.Image = global::Delta.MPS.AccessSystem.Properties.Resources.allchecked;
            this.OpMenuItem1.Name = "OpMenuItem1";
            this.OpMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.OpMenuItem1.Text = "全选(&A)";
            this.OpMenuItem1.Click += new System.EventHandler(this.OpMenuItem1_Click);
            // 
            // OpMenuItem2
            // 
            this.OpMenuItem2.Image = global::Delta.MPS.AccessSystem.Properties.Resources.fchecked;
            this.OpMenuItem2.Name = "OpMenuItem2";
            this.OpMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.OpMenuItem2.Text = "反选(&B)";
            this.OpMenuItem2.Click += new System.EventHandler(this.OpMenuItem2_Click);
            // 
            // OpSeparator1
            // 
            this.OpSeparator1.Name = "OpSeparator1";
            this.OpSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // OpMenuItem3
            // 
            this.OpMenuItem3.Image = global::Delta.MPS.AccessSystem.Properties.Resources.find;
            this.OpMenuItem3.Name = "OpMenuItem3";
            this.OpMenuItem3.Size = new System.Drawing.Size(124, 22);
            this.OpMenuItem3.Text = "查找节点";
            this.OpMenuItem3.Click += new System.EventHandler(this.OpMenuItem3_Click);
            // 
            // OrgEmployeeDialog
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(534, 412);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrgEmployeeDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "筛选员工";
            this.Load += new System.EventHandler(this.OrgEmployeeDialog_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            this.OperationContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Label lineLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.TreeView DeptTreeView;
        private System.Windows.Forms.CheckBox SubEmpCB;
        private System.Windows.Forms.ContextMenuStrip OperationContextMenu;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem1;
        private System.Windows.Forms.ToolStripSeparator OpSeparator1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem2;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.TreeView EmpTreeView;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpMenuItem3;
    }
}