using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delta.MPS.Model;
using Delta.MPS.DBUtility;
using Delta.MPS.SQLServerDAL;
using Excel = org.in2bits.MyXls;

namespace Delta.MPS.AccessSystem
{
    public partial class DevAuthDetailDialog : Form
    {
        /// <summary>
        /// Gloal Variables.
        /// </summary>
        private OrgEmployeeInfo CurOrgEmp;
        private OutEmployeeInfo CurOutEmp;
        private List<DeviceInfo> CurDevices;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public DevAuthDetailDialog(OrgEmployeeInfo emp) {
            InitializeComponent();
            CurOrgEmp = emp;
            CurOutEmp = null;
            CurDevices = new List<DeviceInfo>();
        }

        /// <summary>
        /// Class Constructor
        /// </summary>
        public DevAuthDetailDialog(OutEmployeeInfo emp) {
            InitializeComponent();
            CurOrgEmp = null;
            CurOutEmp = emp;
            CurDevices = new List<DeviceInfo>();
        }

        /// <summary>
        /// Form Load Event.
        /// </summary>
        private void DevAuthDetailDialog_Load(object sender, EventArgs e) {
            try {
                var auths = new List<CardAuthInfo>();
                if (CurOrgEmp != null) {
                    auths.AddRange(new CardAuth().GetCardAuth(CurOrgEmp.EmpId, CurOrgEmp.EmpType));
                } else if (CurOutEmp != null) {
                    auths.AddRange(new CardAuth().GetCardAuth(CurOutEmp.EmpId, EnmWorkerType.WXRY));
                }

                if (auths.Count > 0) {
                    var devices = new MemberShip().GetRoleDevices(ComUtility.SuperRoleID);
                    foreach (var auth in auths) {
                        if (devices.ContainsKey(auth.DevId)) {
                            CurDevices.Add(devices[auth.DevId]);
                        }
                    }
                }
                DevGridView.RowCount = CurDevices.Count;
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DevAuthDetailDialog.Load", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Device GridView CellValue Needed Event.
        /// </summary>
        private void DevGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e) {
            try {
                if (e.RowIndex > CurDevices.Count - 1) { return; }
                switch (DevGridView.Columns[e.ColumnIndex].Name) {
                    case "IDColumn":
                        e.Value = e.RowIndex + 1;
                        break;
                    case "RegionNameColumn":
                        e.Value = CurDevices[e.RowIndex].Area2Name;
                        break;
                    case "CityNameColumn":
                        e.Value = CurDevices[e.RowIndex].Area3Name;
                        break;
                    case "StaNameColumn":
                        e.Value = CurDevices[e.RowIndex].StaName;
                        break;
                    case "DevIDColumn":
                        e.Value = CurDevices[e.RowIndex].DevID;
                        break;
                    case "DevNameColumn":
                        e.Value = CurDevices[e.RowIndex].DevName;
                        break;
                    default:
                        break;
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DevAuthDetailDialog.DevGridView.CellValueNeeded", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Context Menu Opening Event.
        /// </summary>
        private void RecordContextMenuStrip_Opening(object sender, CancelEventArgs e) {
            RecMenuItem1.Enabled = DevGridView.Rows.Count > 0;
        }

        /// <summary>
        /// Record Menu Item Click Event.
        /// </summary>
        private void RecMenuItem1_Click(object sender, EventArgs e) {
            try {
                var data = new DataTable();
                var colors = new Dictionary<Int32, Excel.Color>();

                data.Columns.Add("序号", typeof(String));
                data.Columns.Add("地区", typeof(String));
                data.Columns.Add("县市", typeof(String));
                data.Columns.Add("局站", typeof(String));
                data.Columns.Add("设备编号", typeof(String));
                data.Columns.Add("设备名称", typeof(String));
                for (var i = 0; i < CurDevices.Count; i++) {
                    var dr = data.NewRow();
                    dr["序号"] = i + 1;
                    dr["地区"] = CurDevices[i].Area2Name;
                    dr["县市"] = CurDevices[i].Area3Name;
                    dr["局站"] = CurDevices[i].StaName;
                    dr["设备编号"] = CurDevices[i].DevID.ToString();
                    dr["设备名称"] = CurDevices[i].DevName;
                    data.Rows.Add(dr);
                }

                if (CurOrgEmp != null) {
                    Common.ExportDataToExcel(null, "授权设备信息", "智能门禁管理系统 授权设备信息报表", String.Format("操作员:{0}{1}  日期:{2} 员工:{3} - {4}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now), CurOrgEmp.EmpId, CurOrgEmp.EmpName), data, colors);
                } else if (CurOutEmp != null) {
                    Common.ExportDataToExcel(null, "授权设备信息", "智能门禁管理系统 授权设备信息报表", String.Format("操作员:{0}{1}  日期:{2} 外协:{3} - {4}", Common.CurUser.UserName, String.IsNullOrWhiteSpace(Common.CurUser.RemarkName) ? String.Empty : String.Format("({0})", Common.CurUser.RemarkName), Common.GetDateTimeString(DateTime.Now), CurOutEmp.EmpId, CurOutEmp.EmpName), data, colors);
                }
            } catch (Exception err) {
                Common.WriteLog(DateTime.Now, EnmMsgType.Error, "System", "Delta.MPS.AccessSystem.DevAuthDetailDialog.RecMenuItem1.Click", err.Message, err.StackTrace);
                MessageBox.Show(err.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
