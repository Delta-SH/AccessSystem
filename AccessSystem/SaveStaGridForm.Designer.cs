namespace Delta.MPS.AccessSystem
{
    partial class SaveStaGridForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveStaGridForm));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.StaTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TVToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImages = new System.Windows.Forms.ImageList(this.components);
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.TreeViewContextMenuStrip.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.StaTreeView, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.BottomPanel, 0, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(384, 412);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // StaTreeView
            // 
            this.StaTreeView.CheckBoxes = true;
            this.StaTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.StaTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StaTreeView.HideSelection = false;
            this.StaTreeView.ImageKey = "Area";
            this.StaTreeView.ImageList = this.TreeImages;
            this.StaTreeView.Location = new System.Drawing.Point(10, 10);
            this.StaTreeView.Margin = new System.Windows.Forms.Padding(0);
            this.StaTreeView.Name = "StaTreeView";
            this.StaTreeView.SelectedImageKey = "Area";
            this.StaTreeView.Size = new System.Drawing.Size(364, 352);
            this.StaTreeView.TabIndex = 0;
            this.StaTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.StaTreeView_AfterCheck);
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
            this.TVToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.TVToolStripMenuItem1.Text = "查找节点";
            this.TVToolStripMenuItem1.Click += new System.EventHandler(this.TVToolStripMenuItem1_Click);
            // 
            // TreeImages
            // 
            this.TreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImages.ImageStream")));
            this.TreeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImages.Images.SetKeyName(0, "Area");
            this.TreeImages.Images.SetKeyName(1, "Device");
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.SaveBtn);
            this.BottomPanel.Controls.Add(this.CancelBtn);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(10, 362);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(364, 50);
            this.BottomPanel.TabIndex = 1;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SaveBtn.Location = new System.Drawing.Point(174, 10);
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
            this.CancelBtn.Location = new System.Drawing.Point(274, 10);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(90, 30);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "取消(&C)";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveStaGridForm
            // 
            this.AcceptButton = this.SaveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(384, 412);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "SaveStaGridForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加网格所含局站";
            this.Shown += new System.EventHandler(this.SaveStaGridForm_Shown);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.TreeView StaTreeView;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.ImageList TreeImages;
        private System.Windows.Forms.ContextMenuStrip TreeViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TVToolStripMenuItem1;
    }
}