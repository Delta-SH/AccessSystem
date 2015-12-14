using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.IO;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using Excel = org.in2bits.MyXls;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLServerDAL;

namespace Delta.MPS.AccessSystem
{
    /// <summary>
    /// Collection of utility methods for form
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Is check license.
        /// </summary>
        public static bool IsCheckLicense = false;

        /// <summary>
        /// Is check failed password attempt count.
        /// </summary>
        public static bool IsCheckFailedPasswordAttemptCount = true;

        /// <summary>
        /// Max FailedPasswordAttemptCount
        /// </summary>
        public static int MaxFailedPasswordAttemptCount = 5;

        /// <summary>
        /// Max FailedPasswordAttemptCount
        /// </summary>
        public static int MaxLockedOutHours = 24;

        /// <summary>
        /// Application
        /// </summary>
        public static ApplicationInfo CurApplication = new ApplicationInfo {
            UniqueID = default(Guid),
            AppName = "Intelligent Access Management System",
            AppLicense = String.Empty,
            AppFirstTime = DateTime.Now,
            AppLastTime = DateTime.Now,
            AppLoginTime = DateTime.Now
        };

        /// <summary>
        /// Current license.
        /// </summary>
        public static LicenseInfo CurLicense = null;

        /// <summary>
        /// License status.
        /// </summary>
        public static EnmLicenseStatus LicenseStatus = EnmLicenseStatus.Evaluation;

        /// <summary>
        /// Current interface paramters information.
        /// </summary>
        public static InterfaceInfo CurInterfaceParamter = null;

        /// <summary>
        /// Current user information.
        /// </summary>
        public static UserInfo CurUser = null;

        /// <summary>
        /// Login status.
        /// </summary>
        public static EnmLoginStatus LoginStatus = EnmLoginStatus.Off;

        /// <summary>
        /// Check code String.
        /// </summary>
        public static String CheckCodeString = String.Empty;

        /// <summary>
        /// Log Entity.
        /// </summary>
        public static Log LogEntity = new Log();

        /// <summary>
        /// Code chars set.
        /// </summary>
        private static readonly String[] CodeChars = new String[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        /// <summary>
        /// Default salts.
        /// </summary>
        private static readonly String[] DefaultSalts = new String[] { "5[xUjy)T47(Xvh|w", "F0+c4-g~sDw3", "4B9633%C*F46E", "X&I@su=", "eX9A1@8D$ixWe" };

        /// <summary>
        /// Method to make sure that user's inputs are not malicious.
        /// </summary>
        /// <param name="text">User's Input</param>
        /// <param name="maxLength">Maximum length of input</param>
        public static String InputText(String text, int maxLength) {
            text = text.Trim();
            if (String.IsNullOrWhiteSpace(text)) { return String.Empty; }
            if (text.Length > maxLength) { text = text.Substring(0, maxLength); }
            text = Regex.Replace(text, "[\\s]{2,}", " ");	//two or more spaces
            text = Regex.Replace(text, "<(.|\\n)*?>", String.Empty);    //any other tags
            text = text.Replace("'", "''");
            return text;
        }

        /// <summary>
        /// Method to get datetime String
        /// </summary>
        /// <param name="dt">DateTime</param>
        public static String GetDateTimeString(DateTime dt) {
            if (dt == ComUtility.DefaultDateTime) { return String.Empty; }
            return dt.ToString("yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        /// Method to get date String
        /// </summary>
        /// <param name="dt">DateTime</param>
        public static String GetDateString(DateTime dt) {
            if (dt == ComUtility.DefaultDateTime) { return String.Empty; }
            return dt.ToString("yyyy/MM/dd");
        }

        /// <summary>
        /// Get Time Interval String.
        /// </summary>
        /// <param name="fromTime">from time</param>
        /// <param name="toTime">to time</param>
        /// <returns>Interval String</returns>
        public static String GetTimeInterval(DateTime fromTime, DateTime toTime) {
            var ts = toTime.Subtract(fromTime);
            return String.Format("{0:0000}. {1:00}:{2:00}:{3:00}", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
        }

        /// <summary>
        /// Method to get seconds interval
        /// </summary>
        /// <param name="date">date</param>
        public static Int32 GetSecondFromDateTime(String date) {
            var seconds = 0;
            var parts = date.Split(new char[] { '.' });
            if (parts.Length == 2) {
                if (!String.IsNullOrWhiteSpace(parts[0])) {
                    seconds += Int32.Parse(parts[0].Trim()) * 24 * 3600;
                }

                var times = parts[1].Split(new char[] { ':' });
                if (times.Length == 3) {
                    if (!String.IsNullOrWhiteSpace(times[0])) {
                        seconds += Int32.Parse(times[0].Trim()) * 3600;
                    }

                    if (!String.IsNullOrWhiteSpace(times[1])) {
                        seconds += Int32.Parse(times[1].Trim()) * 60;
                    }

                    if (!String.IsNullOrWhiteSpace(times[2])) {
                        seconds += Int32.Parse(times[2].Trim());
                    }
                }
            }
            return seconds;
        }

        /// <summary>
        /// Method to get datetime object.
        /// </summary>
        /// <param name="date">DateTime String</param>
        /// <param name="type">DateTime type</param>
        public static DateTime GetDateValue(String date, Int32 type) {
            try {
                if (date == null || date.Length != 4) {
                    return DateTime.Today;
                }

                switch (type) {
                    case 1:
                        var hour = Int32.Parse(date.Substring(0, 2));
                        var min = Int32.Parse(date.Substring(2, 2));
                        return DateTime.Today.AddHours(hour).AddMinutes(min);
                    case 2:
                        var month = Int32.Parse(date.Substring(0, 2));
                        var day = Int32.Parse(date.Substring(2, 2));
                        return new DateTime(DateTime.Today.Year, month, day);
                    default:
                        return DateTime.Today;
                }
            } catch {
                return DateTime.Today;
            }
        }

        /// <summary>
        /// Method to get device ID
        /// </summary>
        /// <param name="nodeId">nodeId</param>
        public static Int32 GetDevID(int nodeId) {
            return (int)(nodeId & 0xFFFFF800);
        }

        /// <summary>
        /// Method to get treeview node name
        /// </summary>
        /// <param name="nl">node</param>
        public static String GetTreeNodeName(NodeLevelInfo nl) {
            switch (nl.NodeType) {
                case EnmNodeType.Area:
                    return nl.NodeName;
                case EnmNodeType.Sta:
                    var remarks = nl.Remark.Split(new char[] { '&' });
                    if (remarks.Length == 2) {
                        var name = nl.NodeName;
                        if (!String.IsNullOrWhiteSpace(remarks[0])) {
                            name = String.Format("{0}_{1}", name, remarks[0]);
                        }

                        if (!String.IsNullOrWhiteSpace(remarks[1])) {
                            name = String.Format("{0}[{1}]", name, remarks[1]);
                        }

                        return name;
                    }
                    break;
                case EnmNodeType.Dev:
                    if (!String.IsNullOrWhiteSpace(nl.Remark)) {
                        return String.Format("{0}[{1}]", nl.NodeName, nl.Remark);
                    }
                    break;
                default:
                    break;
            }
            return nl.NodeName;
        }

        /// <summary>
        /// Method to get treeview icon key.
        /// </summary>
        /// <param name="status">alarm status</param>
        /// <returns>icon key</returns>
        public static String GetTreeViewIcon(EnmAlarmLevel status) {
            switch (status) {
                case EnmAlarmLevel.Critical:
                    return "AL1";
                case EnmAlarmLevel.Major:
                    return "AL2";
                case EnmAlarmLevel.Minor:
                    return "AL3";
                case EnmAlarmLevel.Hint:
                    return "AL4";
                default:
                    return "AL0";
            }
        }

        /// <summary>
        /// Get Decimal Card Sn.
        /// </summary>
        /// <param name="sn">card sn</param>
        /// <returns>decimal card sn</returns>
        public static String GetCardSn16to10(String sn) {
            return String.Format("{0:D10}", Int64.Parse(sn, System.Globalization.NumberStyles.HexNumber));
        }

        /// <summary>
        /// Get Hex Card Sn.
        /// </summary>
        /// <param name="sn">card sn</param>
        /// <returns>hex card sn</returns>
        public static String GetCardSn10to16(String sn) {
            return String.Format("{0:X10}", Int64.Parse(sn));
        }

        /// <summary>
        /// Generating verification image.
        /// </summary>
        /// <param name="codeLen">codeLen</param>
        public static Image CreateCodeImage(int codeLen) {
            var checkCode = GenerateCode(codeLen);
            if (String.IsNullOrWhiteSpace(checkCode)) { return null; }
            var image = new Bitmap(checkCode.Length * 16, 25);
            var g = Graphics.FromImage(image);
            try {
                g.Clear(Color.White);
                for (int i = 0; i < 25; i++) {
                    var random = new Random(Guid.NewGuid().GetHashCode());
                    var x1 = random.Next(image.Width);
                    var x2 = random.Next(image.Width);
                    var y1 = random.Next(image.Height);
                    var y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                var font = new System.Drawing.Font("Arial", 14, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                var brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1f, true);
                g.DrawString(checkCode, font, brush, 2, 2);
                for (int i = 0; i < 100; i++) {
                    var random = new Random(Guid.NewGuid().GetHashCode());
                    var x = random.Next(image.Width);
                    var y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                var ms = new MemoryStream();
                image.Save(ms, ImageFormat.Png);
                return Bitmap.FromStream(ms);
            } finally {
                g.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// Generating verification code.
        /// </summary>
        /// <param name="codeLen">codeLen</param>
        private static String GenerateCode(int codeLen) {
            var maxLen = CodeChars.Length;
            var checkCode = String.Empty;
            for (int i = 0; i < codeLen; i++) {
                var random = new Random(Guid.NewGuid().GetHashCode());
                checkCode += CodeChars[random.Next(maxLen)];
            }

            CheckCodeString = checkCode;
            return checkCode;
        }

        /// <summary>
        /// Get hard disk id.
        /// </summary>
        /// <returns>Hard disk id</returns>
        private static String GetHardDiskID() {
            try {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia")) {
                    foreach (var mo in searcher.Get()) {
                        var sn = mo.GetPropertyValue("SerialNumber");
                        if (sn != null) {
                            return sn.ToString().Trim().ToUpper();
                        }
                    }
                }
            } catch { }
            return "A30B4998A3A349279A8EA22A7EE119BE";
        }

        /// <summary>
        /// Get cpu id.
        /// </summary>
        /// <returns>cpu id</returns>
        private static String GetCPUID() {
            try {
                using (var mc = new ManagementClass("Win32_Processor")) {
                    using (var moc = mc.GetInstances()) {
                        foreach (var mo in moc) {
                            var pi = mo.Properties["ProcessorId"].Value;
                            if (pi != null) {
                                return pi.ToString().Trim().ToUpper();
                            }
                        }
                    }
                }
            } catch { }
            return "7B1C85852F6C4CF0813A6E3398BF458F";
        }

        /// <summary>
        /// Get machine code.
        /// </summary>
        /// <returns>machine code</returns>
        public static Guid GetMachineCode() {
            try {
                var hd = GetHardDiskID().Trim();
                var cu = GetCPUID().Trim();
                if (!String.IsNullOrEmpty(hd) || !String.IsNullOrEmpty(cu)) {
                    var originalKey = String.Format("{0}{1}{2}{3}{4}{5}{6}", DefaultSalts[0], GetCPUID(), DefaultSalts[1], DefaultSalts[2], GetHardDiskID(), DefaultSalts[3], DefaultSalts[4]);
                    var md5 = MD5.Create();
                    var bs = Encoding.UTF8.GetBytes(originalKey);
                    var hs = md5.ComputeHash(bs);
                    return new Guid(hs);
                }
            } catch { }
            return new Guid("FA349C9D08C54EDA90807AEAE3105830");
        }

        /// <summary>
        /// Decrypt license.
        /// </summary>
        private static LicenseInfo DecryptLicense(String lcode, String mcode) {
            try {
                var keys = mcode.ToUpper().ToCharArray().Reverse().ToArray();
                if (keys.Length != 32) { return null; }
                var aesKey = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", keys[3], keys[6], keys[9], keys[12], keys[13], keys[16], keys[19], keys[25], keys[29], keys[31], keys[7], keys[16], keys[12], keys[20], keys[2], keys[3]);
                var aesIV = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}", keys[5], keys[8], keys[10], keys[14], keys[20], keys[21], keys[24], keys[25], keys[29], keys[30], keys[2], keys[5], keys[6], keys[17], keys[22], keys[10]);

                var aes = new AesCryptoServiceProvider();
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.IV = Encoding.UTF8.GetBytes(aesIV);
                aes.Key = Encoding.UTF8.GetBytes(aesKey);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                var src = System.Convert.FromBase64String(lcode);
                using (var decrypt = aes.CreateDecryptor()) {
                    var dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                    lcode = Encoding.Unicode.GetString(dest);

                    var licenses = lcode.Split(new char[] { '┋' });
                    if (licenses == null || licenses.Length != 4) { return null; }
                    return new LicenseInfo() {
                        Name = licenses[0],
                        Company = licenses[1],
                        Email = licenses[2],
                        Expiration = new DateTime(Int64.Parse(licenses[3]))
                    };
                }
            } catch { }
            return null;
        }

        /// <summary>
        /// Check license.
        /// </summary>
        /// <param name="lcode">license code</param>
        public static void CheckLicense(String lcode) {
            try {
                LicenseStatus = EnmLicenseStatus.Invalid;
                if (CurApplication.AppLastTime.Subtract(CurApplication.AppFirstTime).Days <= 30) {
                    LicenseStatus = EnmLicenseStatus.Evaluation;
                }

                if (String.IsNullOrWhiteSpace(lcode)) { return; }
                CurLicense = DecryptLicense(lcode, CurApplication.UniqueID.ToString("N").ToUpper());
                if (CurLicense == null) { return; }

                if (CurLicense.Expiration < CurApplication.AppLastTime) {
                    LicenseStatus = EnmLicenseStatus.Expired;
                    return;
                }

                LicenseStatus = EnmLicenseStatus.Licensed;
            } catch { throw; }
        }

        /// <summary>
        /// Create contents of connection strings used by the SqlConnection class.
        /// </summary>
        /// <param name="database">database information</param>
        /// <returns>Connection String</returns>
        public static String CreateConnectionString(DatabaseServerInfo database) {
            return SQLHelper.CreateConnectionString(false, database.DatabaseIP, database.DatabasePort, database.DatabaseName, database.DatabaseUser, database.DatabasePwd, 120);
        }

        /// <summary>
        /// Tests the given connection String.
        /// </summary>
        /// <param name="connectionString">SqlConnection String</param>
        /// <returns>Returns true if an attempt to open the database by using the connection succeeds.</returns>
        public static bool TestConnection(String connectionString) {
            var success = false;
            var timeout = 5;

            var conn = new SqlConnection(connectionString);
            var thread = new Thread(() => {
                try {
                    conn.Open();
                    conn.Close();
                    success = true;
                } catch { } finally {
                    if (conn.State == ConnectionState.Open) {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            });

            thread.IsBackground = true;
            var sw = Stopwatch.StartNew();
            thread.Start();

            var ts = TimeSpan.FromSeconds(timeout);
            while (sw.Elapsed < ts) {
                thread.Join(TimeSpan.FromMilliseconds(100));
                if (success) { break; }
            }
            sw.Stop();
            return success;
        }

        /// <summary>
        /// Sync sntp time.
        /// </summary>
        /// <param name="callback">callback event</param>
        /// <param name="failure">failure event</param>
        public static void SyncSntpTime(Action<DateTime> callback, Action failure) {
            if (!NetworkInterface.GetIsNetworkAvailable()) {
                failure();
                return;
            }

            var sntp = new SntpClient();
            sntp.BeginGetDate(time => { callback(time.AddHours(8)); }, () => { failure(); });
        }

        /// <summary>
        /// Write log information.
        /// </summary>
        /// <param name="msgTime">message datetime</param>
        /// <param name="msgType">message type</param>
        /// <param name="msgOperator">message operator</param>
        /// <param name="msgSource">message source</param>
        /// <param name="message">message</param>
        /// <param name="trace">stack trace</param>
        public static void WriteLog(DateTime msgTime, EnmMsgType msgType, String msgOperator, String msgSource, String message, String trace) {
            try {
                var log = new LogInfo();
                log.EventId = Guid.NewGuid();
                log.EventTime = msgTime;
                log.EventType = msgType;
                log.Operator = msgOperator;
                log.Source = msgSource;
                log.Message = message;
                log.StackTrace = trace;
                LogEntity.WriteTxtLog(log);
                LogEntity.WriteDBLog(log);
            } catch (Exception err) {
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Write text log information.
        /// </summary>
        /// <param name="msgTime">message datetime</param>
        /// <param name="msgType">message type</param>
        /// <param name="msgOperator">message operator</param>
        /// <param name="msgSource">message source</param>
        /// <param name="message">message</param>
        /// <param name="trace">stack trace</param>
        public static void WriteTextLog(DateTime msgTime, EnmMsgType msgType, String msgOperator, String msgSource, String message, String trace) {
            try {
                var log = new LogInfo();
                log.EventId = Guid.NewGuid();
                log.EventTime = msgTime;
                log.EventType = msgType;
                log.Operator = msgOperator;
                log.Source = msgSource;
                log.Message = message;
                log.StackTrace = trace;
                LogEntity.WriteTxtLog(log);
            } catch (Exception err) {
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Show waitting form.
        /// </summary>
        /// <param name="load">load function</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowWait(Action load) {
            return ShowWait(load, default(String), default(String), default(int), default(int));
        }

        /// <summary>
        /// Show waitting form.
        /// </summary>
        /// <param name="load">load function</param>
        /// <param name="title">title</param>
        /// <param name="tip">tip text</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowWait(Action load, String title, String tip, int width, int height) {
            return ShowWait(load, default(String), default(String), default(int), default(int), 900);
        }

        /// <summary>
        /// Show waitting form.
        /// </summary>
        /// <param name="load">load function</param>
        /// <param name="title">title</param>
        /// <param name="tip">tip text</param>
        /// <param name="width">width</param>
        /// <param name="height">height</param>
        /// <param name="timeout">timeout</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowWait(Action load, String title, String tip, int width, int height, double timeout) {
            var waitForm = new WaitingForm(title, width, height);
            waitForm.TipText = tip;
            waitForm.Timeout = timeout;
            var thread = new Thread(() => {
                try {
                    Thread.Sleep(500); load();
                    if (!waitForm.IsDisposed && waitForm.IsHandleCreated) { waitForm.DialogResult = DialogResult.OK; }
                } catch (Exception err) {
                    MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!waitForm.IsDisposed && waitForm.IsHandleCreated) { waitForm.DialogResult = DialogResult.Abort; }
                }
            });
            thread.IsBackground = true;
            thread.Start();
            return waitForm.ShowDialog();
        }

        /// <summary>
        /// Export data to excel.
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <param name="sheetName">sheetName</param>
        /// <param name="title">title</param>
        /// <param name="subtitle">subtitle</param>
        /// <param name="datas">datas</param>
        public static void ExportDataToExcel(String fileName, String sheetName, String title, String subtitle, DataTable data) {
            ExportDataToExcel(fileName, sheetName, title, subtitle, data, null);
        }

        /// <summary>
        /// Export data to excel.
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <param name="sheetName">sheetName</param>
        /// <param name="title">title</param>
        /// <param name="subtitle">subtitle</param>
        /// <param name="datas">datas</param>
        /// <param name="colors">colors</param>
        public static void ExportDataToExcel(String fileName, String sheetName, String title, String subtitle, DataTable data, Dictionary<Int32, Excel.Color> colors) {
            if (data == null) {
                MessageBox.Show("数据源为空，导出数据失败。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (data.Columns.Count == 0) {
                MessageBox.Show("数据源无任何列信息，导出数据失败。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (data.Rows.Count == 0) {
                MessageBox.Show("数据源无数据，导出数据失败。", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (data == null || data.Columns.Count == 0) { return; }
            if (String.IsNullOrWhiteSpace(fileName)) { fileName = String.Format("{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss")); }
            if (String.IsNullOrWhiteSpace(sheetName)) { sheetName = "ExcelSheet"; }

            //创建Excel管理对象
            var xls = new Excel.XlsDocument();
            xls.SummaryInformation.Title = title;
            xls.SummaryInformation.Author = "Intelligent Access Management System";
            xls.DocumentSummaryInformation.Company = "Delta GreenTech(China) Co., Ltd.";
            xls.SummaryInformation.Comments = null;

            //Sheet标题样式  
            var titleXF = xls.NewXF();
            titleXF.HorizontalAlignment = Excel.HorizontalAlignments.Centered;
            titleXF.VerticalAlignment = Excel.VerticalAlignments.Centered;
            titleXF.UseBorder = true;
            titleXF.BottomLineStyle = 1;
            titleXF.BottomLineColor = Excel.Colors.Black;
            titleXF.RightLineStyle = 1;
            titleXF.RightLineColor = Excel.Colors.Black;
            titleXF.Font.Bold = true;
            titleXF.Font.Height = 15 * 20;

            //Sheet副标题样式  
            var subtitleXF = xls.NewXF();
            subtitleXF.HorizontalAlignment = Excel.HorizontalAlignments.Right;
            subtitleXF.VerticalAlignment = Excel.VerticalAlignments.Centered;
            subtitleXF.UseBorder = true;
            subtitleXF.RightLineStyle = 1;
            subtitleXF.RightLineColor = Excel.Colors.Black;
            subtitleXF.Font.Bold = false;
            subtitleXF.Font.Height = 10 * 20;

            //列标题样式  
            var coltitleXF = xls.NewXF();
            coltitleXF.HorizontalAlignment = Excel.HorizontalAlignments.Centered;
            coltitleXF.VerticalAlignment = Excel.VerticalAlignments.Centered;
            coltitleXF.UseBorder = true;
            coltitleXF.TopLineStyle = 1;
            coltitleXF.TopLineColor = Excel.Colors.Black;
            coltitleXF.BottomLineStyle = 1;
            coltitleXF.BottomLineColor = Excel.Colors.Black;
            coltitleXF.RightLineStyle = 1;
            coltitleXF.RightLineColor = Excel.Colors.Black;
            coltitleXF.Pattern = 1;
            coltitleXF.PatternBackgroundColor = Excel.Colors.Grey;
            coltitleXF.PatternColor = Excel.Colors.Grey;
            coltitleXF.Font.Bold = true;
            coltitleXF.Font.Height = 11 * 20;
            coltitleXF.Font.ColorIndex = 1;

            //数据单元格样式  
            var dataXF = xls.NewXF();
            dataXF.HorizontalAlignment = Excel.HorizontalAlignments.Left;
            dataXF.VerticalAlignment = Excel.VerticalAlignments.Centered;
            dataXF.UseBorder = true;
            dataXF.RightLineStyle = 1;
            dataXF.RightLineColor = Excel.Colors.Black;
            dataXF.BottomLineStyle = 1;
            dataXF.BottomLineColor = Excel.Colors.Black;
            dataXF.UseProtection = false;
            dataXF.TextWrapRight = true;
            dataXF.Font.Height = 10 * 20;

            var sheetSize = 50000;
            var sheetCount = 1;
            if (data.Rows.Count > sheetSize) {
                sheetCount = (int)Math.Ceiling((float)data.Rows.Count / (float)sheetSize);
            }

            for (var i = 1; i <= sheetCount; i++) {
                //创建表单
                Excel.Worksheet sheet;
                if (sheetCount == 1)
                    sheet = xls.Workbook.Worksheets.Add(sheetName);
                else
                    sheet = xls.Workbook.Worksheets.Add(String.Format("{0}-{1}", sheetName, i));

                //设置标题栏
                ushort startDataIndex = 1;
                if (!String.IsNullOrWhiteSpace(title)) {
                    for (var k = 1; k <= data.Columns.Count; k++) {
                        sheet.Cells.Add(1, k, title, titleXF);
                    }
                    sheet.AddMergeArea(new Excel.MergeArea(1, 1, 1, data.Columns.Count));
                    sheet.Rows[1].RowHeight = 40 * 20;
                    startDataIndex++;
                }

                //设置副标题
                if (!String.IsNullOrWhiteSpace(subtitle)) {
                    for (var k = 1; k <= data.Columns.Count; k++) {
                        sheet.Cells.Add(2, k, subtitle, subtitleXF);
                    }
                    sheet.AddMergeArea(new Excel.MergeArea(2, 2, 1, data.Columns.Count));
                    sheet.Rows[2].RowHeight = 20 * 20;
                    startDataIndex++;
                }

                //列设置  
                var col = new Excel.ColumnInfo(xls, sheet);
                col.ColumnIndexStart = 0;
                col.ColumnIndexEnd = (ushort)(data.Columns.Count - 1);
                col.Width = 20 * 256;
                sheet.AddColumnInfo(col);

                //设置列标题
                for (var k = 1; k <= data.Columns.Count; k++) {
                    sheet.Cells.Add(startDataIndex, k, data.Columns[k - 1].ColumnName, coltitleXF);
                }
                sheet.Rows[startDataIndex].RowHeight = 20 * 20;
                startDataIndex++;

                for (var k = 0; k < sheetSize; k++) {
                    int r = (i - 1) * sheetSize + k;
                    if (r >= data.Rows.Count) { break; }
                    if (colors != null && colors.ContainsKey(r)) {
                        dataXF.Pattern = 1;
                        dataXF.PatternBackgroundColor = colors[r];
                        dataXF.PatternColor = colors[r];
                    } else {
                        dataXF.Pattern = 1;
                        dataXF.PatternBackgroundColor = Excel.Colors.White;
                        dataXF.PatternColor = Excel.Colors.White;
                    }

                    for (var g = 1; g <= data.Columns.Count; g++) {
                        sheet.Cells.Add(startDataIndex, g, data.Rows[r][g - 1], dataXF);
                    }
                    startDataIndex++;
                }
            }

            var dataSaveFileDialog = new SaveFileDialog();
            dataSaveFileDialog.DefaultExt = "xls";
            dataSaveFileDialog.FileName = fileName;
            dataSaveFileDialog.Filter = "Excel 工作薄|*.xls|所有文件|*.*";
            dataSaveFileDialog.Title = "文件另存为";
            if (dataSaveFileDialog.ShowDialog() == DialogResult.OK) {
                using (var fs = new FileStream(dataSaveFileDialog.FileName, FileMode.Create)) {
                    fs.Write(xls.Bytes.ByteArray, 0, xls.Bytes.Length);
                    fs.Flush();
                    MessageBox.Show("数据导出完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Export data to excel.
        /// </summary>
        /// <param name="fileName">fileName</param>
        /// <param name="sheetName">sheetName</param>
        /// <param name="title">title</param>
        /// <param name="subtitle">subtitle</param>
        /// <param name="datas">datas</param>
        public static void ExportDataToText(String fileName, String title, String data) {
            if (String.IsNullOrWhiteSpace(data)) { return; }
            if (String.IsNullOrWhiteSpace(fileName)) { fileName = String.Format("{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss")); }
            if (String.IsNullOrWhiteSpace(title)) { title = "No Title"; }

            var logText = new StringBuilder();
            logText.AppendLine(title);
            logText.AppendLine();
            logText.Append(data);

            var dataSaveFileDialog = new SaveFileDialog();
            dataSaveFileDialog.DefaultExt = "txt";
            dataSaveFileDialog.FileName = fileName;
            dataSaveFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
            dataSaveFileDialog.Title = "文件另存为";
            if (dataSaveFileDialog.ShowDialog() == DialogResult.OK) {
                var file = new FileInfo(dataSaveFileDialog.FileName);
                if (!file.Exists) {
                    using (var sw = file.CreateText()) {
                        sw.Write(logText.ToString());
                        sw.Close();
                    }

                    MessageBox.Show("数据导出完成", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    MessageBox.Show("文件已存在", "系统警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Copy Object Values
        /// </summary>
        /// <param name="source">source object</param>
        /// <param name="target">target object</param>
        public static void CopyObjectValues(object source, object target) {
            if (source == null || target == null) { return; }
            if (source.GetType() != target.GetType()) { return; }
            var Properties = target.GetType().GetProperties();
            foreach (var ps in Properties) {
                ps.SetValue(target, ps.GetValue(source, null), null);
            }
        }

        /// <summary>
        /// Method to get node type name
        /// </summary>
        /// <param name="nodeType">nodeType</param>
        public static String GetNodeTypeName(EnmNodeType nodeType) {
            switch (nodeType) {
                case EnmNodeType.Null:
                    return "Null";
                case EnmNodeType.LSC:
                    return "LSC";
                case EnmNodeType.Area:
                    return "区域";
                case EnmNodeType.Sta:
                    return "局站";
                case EnmNodeType.Dev:
                    return "设备";
                case EnmNodeType.Dic:
                    return "遥信";
                case EnmNodeType.Aic:
                    return "遥测";
                case EnmNodeType.Doc:
                    return "遥控";
                case EnmNodeType.Aoc:
                    return "遥调";
                case EnmNodeType.Str:
                    return "Str";
                case EnmNodeType.Img:
                    return "Img";
                case EnmNodeType.Sic:
                    return "Sic";
                case EnmNodeType.SS:
                    return "SS";
                case EnmNodeType.RS:
                    return "RS";
                case EnmNodeType.RTU:
                    return "RTU";
                default:
                    return "Undefined";
            }
        }

        /// <summary>
        /// Method to get node value
        /// </summary>
        /// <param name="nodeType">node</param>
        public static String GetNodeValue(NodeInfo node) {
            switch (node.NodeType) {
                case EnmNodeType.Dic:
                case EnmNodeType.Doc:
                    return GetDesc(node.Remark, (Int32)node.Value);
                case EnmNodeType.Aic:
                case EnmNodeType.Aoc:
                    return String.Format("{0} {1}", node.Value.ToString("0.000"), node.Remark);
                default:
                    break;
            }
            return String.Empty;
        }

        /// <summary>
        /// Method to get description String
        /// </summary>
        /// <param name="Describe">Describe</param>
        /// <param name="value">value</param>
        public static String GetDesc(String describe, Int32 value) {
            var describes = describe.Split(new char[] { '\t' });
            for (int i = 0; i < describes.Length; i++) {
                var subDescribes = describes[i].Split(new char[] { '&' });
                if (subDescribes.Length == 2 && subDescribes[0].Trim().Equals(value.ToString())) { return subDescribes[1].Trim(); }
            }
            return String.Empty;
        }

        /// <summary>
        /// Method to get confirm marking name
        /// </summary>
        /// <param name="confirmMarking">confirmMarking</param>
        public static String GetConfirmMarkingName(EnmConfirmMarking confirmMarking) {
            switch (confirmMarking) {
                case EnmConfirmMarking.NotConfirm:
                    return "未确认";
                case EnmConfirmMarking.NotDispatch:
                    return "未派修";
                case EnmConfirmMarking.Dispatched:
                    return "已派修";
                case EnmConfirmMarking.Processing:
                    return "处理中";
                case EnmConfirmMarking.Processed:
                    return "已处理";
                case EnmConfirmMarking.FileOff:
                    return "已归档";
                case EnmConfirmMarking.Cancel:
                    return "已作废";
                default:
                    return "Undefined";
            }
        }

        /// <summary>
        /// Method to get state color
        /// </summary>
        /// <param name="state">state</param>
        public static Color GetStateColor(EnmState state) {
            switch (state) {
                case EnmState.NoAlarm:
                    return Color.White;
                case EnmState.Critical:
                    return Color.Red;
                case EnmState.Major:
                    return Color.Orange;
                case EnmState.Minor:
                    return Color.Yellow;
                case EnmState.Hint:
                    return Color.SkyBlue;
                case EnmState.Opevent:
                    return Color.White;
                case EnmState.Invalid:
                    return Color.Blue;
                default:
                    return Color.Blue;
            }
        }

        /// <summary>
        /// Method to get level color
        /// </summary>
        /// <param name="level">level</param>
        public static Color GetLevelColor(EnmAlarmLevel level) {
            switch (level) {
                case EnmAlarmLevel.NoAlarm:
                    return Color.White;
                case EnmAlarmLevel.Critical:
                    return Color.Red;
                case EnmAlarmLevel.Major:
                    return Color.Orange;
                case EnmAlarmLevel.Minor:
                    return Color.Yellow;
                case EnmAlarmLevel.Hint:
                    return Color.SkyBlue;
                default:
                    return Color.White;
            }
        }

        /// <summary>
        /// Method to get excel node color
        /// </summary>
        /// <param name="state">state</param>
        public static Excel.Color GetExcelStateColor(EnmState state) {
            switch (state) {
                case EnmState.NoAlarm:
                    return Excel.Colors.White;
                case EnmState.Opevent:
                    return Excel.Colors.White;
                case EnmState.Critical:
                    return Excel.Colors.Red;
                case EnmState.Major:
                    return Excel.Colors.Default34;
                case EnmState.Minor:
                    return Excel.Colors.Yellow;
                case EnmState.Hint:
                    return Excel.Colors.Default2C;
                case EnmState.Invalid:
                    return Excel.Colors.Blue;
                default:
                    return Excel.Colors.White;
            }
        }

        /// <summary>
        /// Method to get excel alarm color
        /// </summary>
        /// <param name="level">level</param>
        public static Excel.Color GetExcelAlarmColor(EnmAlarmLevel level) {
            switch (level) {
                case EnmAlarmLevel.NoAlarm:
                    return Excel.Colors.White;
                case EnmAlarmLevel.Critical:
                    return Excel.Colors.Red;
                case EnmAlarmLevel.Major:
                    return Excel.Colors.Default34;
                case EnmAlarmLevel.Minor:
                    return Excel.Colors.Yellow;
                case EnmAlarmLevel.Hint:
                    return Excel.Colors.Default2C;
                default:
                    return Excel.Colors.White;
            }
        }
    }
}