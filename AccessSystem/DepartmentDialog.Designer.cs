namespace Delta.MPS.AccessSystem
{
    partial class DepartmentDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentDialog));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.DeptTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.TVToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.TVToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.MainTableLayoutPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.TreeViewContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.DeptTreeView, 0, 0);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.MainTableLayoutPanel.RowCount = 3;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(334, 362);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Controls.Add(this.OKBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(5, 322);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(324, 40);
            this.BottomPanel.TabIndex = 0;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(234, 5);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OKBtn.Location = new System.Drawing.Point(134, 5);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(90, 30);
            this.OKBtn.TabIndex = 6;
            this.OKBtn.Text = "确定(&O)";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // DeptTreeView
            // 
            this.DeptTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.DeptTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeptTreeView.HideSelection = false;
            this.DeptTreeView.ImageKey = "Department";
            this.DeptTreeView.ImageList = this.TreeImages;
            this.DeptTreeView.Location = new System.Drawing.Point(5, 5);
            this.DeptTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.DeptTreeView.Name = "DeptTreeView";
            this.DeptTreeView.SelectedImageKey = "Department";
            this.DeptTreeView.Size = new System.Drawing.Size(324, 312);
            this.DeptTreeView.TabIndex = 1;
            // 
            // TreeViewContextMenuStrip
            // 
            this.TreeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVToolStripMenuItem2,
            this.TVToolStripMenuItem3,
            this.TVToolStripSeparator1,
            this.TVToolStripMenuItem1});
            this.TreeViewContextMenuStrip.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip.Size = new System.Drawing.Size(153, 98);
            this.TreeViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TreeViewContextMenuStrip_Opening);
            // 
            // TVToolStripMenuItem2
            // 
            this.TVToolStripMenuItem2.Image = global::Delta.MPS.AccessSystem.Properties.Resources.allchecked;
            this.TVToolStripMenuItem2.Name = "TVToolStripMenuItem2";
            this.TVToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.TVToolStripMenuItem2.Text = "全选(&A)";
            this.TVToolStripMenuItem2.Click += new System.EventHandler(this.TVToolStripMenuItem2_Click);
            // 
            // TVToolStripMenuItem3
            // 
            this.TVToolStripMenuItem3.Image = global::Delta.MPS.AccessSystem.Properties.Resources.fchecked;
            this.TVToolStripMenuItem3.Name = "TVToolStripMenuItem3";
            this.TVToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.TVToolStripMenuItem3.Text = "反选(&B)";
            this.TVToolStripMenuItem3.Click += new System.EventHandler(this.TVToolStripMenuItem3_Click);
            // 
            // TVToolStripSeparator1
            // 
            this.TVToolStripSeparator1.Name = "TVToolStripSeparator1";
            this.TVToolStripSeparator1.Size = new System.Drawing.Size(149, 6);
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
            // 
            // DepartmentDialog
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(334, 362);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "筛选部门";
            this.Load += new System.EventHandler(this.DepartmentDialog_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.TreeView DeptTreeView;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator TVToolStripSeparator1;

    }
}