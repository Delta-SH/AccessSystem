using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Delta.MPS.AccessSystem
{
    public partial class WaitingForm : Form
    {
        private double _Timeout = 300;
        public WaitingForm() {
            InitializeComponent();
        }

        public WaitingForm(string title) {
            InitializeComponent();
            if (!String.IsNullOrWhiteSpace(title)) { this.Text = title; }
        }

        public WaitingForm(int width, int height) {
            InitializeComponent();
            if (width > 0) { this.Width = width; }
            if (height > 0) { this.Height = height; }
        }

        public WaitingForm(string title, int width, int height) {
            InitializeComponent();
            if (!String.IsNullOrWhiteSpace(title)) { this.Text = title; }
            if (width > 0) { this.Width = width; }
            if (height > 0) { this.Height = height; }
        }

        public String TipText {
            get { return tipLbl.Text; }
            set { if (!String.IsNullOrWhiteSpace(value)) { tipLbl.Text = value; } }
        }

        public Double Timeout {
            get { return _Timeout; }
            set { _Timeout = value; }
        }

        private void WaitingForm_Shown(object sender, EventArgs e) {
            var detect = new Thread(() => {
                var ts = TimeSpan.FromSeconds(_Timeout);
                var sw = Stopwatch.StartNew();
                while (!this.IsDisposed && this.IsHandleCreated) {
                    if (sw.Elapsed > ts) {
                        this.Invoke(new MethodInvoker(delegate {
                            MessageBox.Show("在操作完成之前超时时间已到", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.Abort;
                        }));
                        break;
                    }

                    Thread.Sleep(500);
                }
                sw.Stop();
            });
            detect.IsBackground = true;
            detect.Start();
        }
    }
}