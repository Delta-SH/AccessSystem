namespace Delta.MPS.AccessSystem
{
    partial class BatchCancelCardAuthForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchCancelCardAuthForm));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TopSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DevTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.CardTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem21 = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
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
            this.MainTableLayoutPanel.Controls.Add(this.TopSplitContainer, 0, 0);
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
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(584, 412);
            this.MainTableLayoutPanel.TabIndex = 2;
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
            this.TopSplitContainer.Size = new System.Drawing.Size(564, 352);
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
            this.DevTreeView.Size = new System.Drawing.Size(277, 352);
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
            this.TVToolStripMenuItem11.Size = new System.Drawing.Size(152, 22);
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
            this.CardTreeView.Size = new System.Drawing.Size(273, 352);
            this.CardTreeView.TabIndex = 0;
            this.CardTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.CardTreeView_AfterCheck);
            // 
            // TreeViewContextMenuStrip2
            // 
            this.TreeViewContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TVToolStripMenuItem21});
            this.TreeViewContextMenuStrip2.Name = "TreeViewContextMenuStrip";
            this.TreeViewContextMenuStrip2.Size = new System.Drawing.Size(153, 48);
            // 
            // TVToolStripMenuItem21
            // 
            this.TVToolStripMenuItem21.Image = global::Delta.MPS.AccessSystem.Properties.Resources.find;
            this.TVToolStripMenuItem21.Name = "TVToolStripMenuItem21";
            this.TVToolStripMenuItem21.Size = new System.Drawing.Size(152, 22);
            this.TVToolStripMenuItem21.Text = "查找节点";
            this.TVToolStripMenuItem21.Click += new System.EventHandler(this.TVToolStripMenuItem21_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.DeleteBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 362);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(564, 50);
            this.BottomPanel.TabIndex = 3;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DeleteBtn.Location = new System.Drawing.Point(374, 10);
            this.DeleteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(90, 30);
            this.DeleteBtn.TabIndex = 1;
            this.DeleteBtn.Text = "撤销(&D)";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
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
            // BatchCancelCardAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "BatchCancelCardAuthForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量撤权管理";
            this.Shown += new System.EventHandler(this.BatchCancelCardAuthForm_Shown);
            this.MainTableLayoutPanel.ResumeLayout(false);
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
        private System.Windows.Forms.TreeView DevTreeView;
        private System.Windows.Forms.TreeView CardTreeView;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem11;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem21;
    }
}