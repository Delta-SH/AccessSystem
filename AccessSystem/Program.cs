using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using System.Threading;
using Delta.MPS.Model;
using Delta.MPS.SQLiteDAL;
using Delta.MPS.SQLServerDAL;

namespace Delta.MPS.AccessSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Common.WriteTextLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.Program.Main", "===================================================", null);
                Common.WriteTextLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.Program.Main", String.Format("启动应用程序 \"智能门禁管理系统 {0}\"", ConfigurationManager.AppSettings["Version"]), null);
                //Common.SyncSntpTime(time => {
                //    Common.CurApplication.AppFirstTime = Common.CurApplication.AppLastTime = time;
                //    Common.WriteTextLog(DateTime.Now, EnmMsgType.Info, "System", "Delta.MPS.AccessSystem.Program.Main", "程序时钟同步成功。", null);
                //}, () => { Common.WriteTextLog(DateTime.Now, EnmMsgType.Warning, "System", "Delta.MPS.AccessSystem.Program.Main", "程序时钟同步失败。", null); });

                new RegistryDatabase().CreateRegistry();
                if (new LoginForm().ShowDialog() == DialogResult.OK && Common.LoginStatus == EnmLoginStatus.Loaded) {
                    Application.Run(new MainForm());
                }
            } catch (Exception err) {
                Common.WriteTextLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.Program.Main", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
