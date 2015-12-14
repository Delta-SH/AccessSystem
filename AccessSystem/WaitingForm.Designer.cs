namespace Delta.MPS.AccessSystem
{
    partial class WaitingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingForm));
            this.tipProgressBar = new System.Windows.Forms.ProgressBar();
            this.tipLbl = new System.Windows.Forms.Label();
            this.waitingTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.waitingTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tipProgressBar
            // 
            this.tipProgressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tipProgressBar.Location = new System.Drawing.Point(23, 120);
            this.tipProgressBar.MarqueeAnimationSpeed = 10;
            this.tipProgressBar.Name = "tipProgressBar";
            this.tipProgressBar.Size = new System.Drawing.Size(338, 19);
            this.tipProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tipProgressBar.TabIndex = 0;
            // 
            // tipLbl
            // 
            this.tipLbl.AutoEllipsis = true;
            this.tipLbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tipLbl.Location = new System.Drawing.Point(23, 20);
            this.tipLbl.Name = "tipLbl";
            this.tipLbl.Size = new System.Drawing.Size(338, 20);
            this.tipLbl.TabIndex = 0;
            this.tipLbl.Text = "正在准备数据，请稍后...";
            // 
            // waitingTableLayout
            // 
            this.waitingTableLayout.ColumnCount = 3;
            this.waitingTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.waitingTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.waitingTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.waitingTableLayout.Controls.Add(this.tipLbl, 1, 1);
            this.waitingTableLayout.Controls.Add(this.tipProgressBar, 1, 3);
            this.waitingTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waitingTableLayout.Location = new System.Drawing.Point(0, 0);
            this.waitingTableLayout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.waitingTableLayout.Name = "waitingTableLayout";
            this.waitingTableLayout.RowCount = 5;
            this.waitingTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.waitingTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.waitingTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.waitingTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.waitingTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.waitingTableLayout.Size = new System.Drawing.Size(384, 162);
            this.waitingTableLayout.TabIndex = 0;
            // 
            // WaitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(384, 162);
            this.ControlBox = false;
            this.Controls.Add(this.waitingTableLayout);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "WaitingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "智能门禁管理系统";
            this.Shown += new System.EventHandler(this.WaitingForm_Shown);
            this.waitingTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar tipProgressBar;
        private System.Windows.Forms.Label tipLbl;
        private System.Windows.Forms.TableLayoutPanel waitingTableLayout;
    }
}