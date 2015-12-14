using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delta.MPS.Model;

namespace Delta.MPS.DBUtility
{
    /// <summary>
    /// The SQLiteText class is intended to store common methods.
    /// </summary>
    public abstract class ComUtility
    {
        /// <summary>
        /// Int32 Default Value
        /// </summary>
        public static readonly int DefaultInt32 = Int32.MinValue;

        /// <summary>
        /// Int64 Default Value
        /// </summary>
        public static readonly long DefaultInt64 = Int64.MinValue;

        /// <summary>
        /// String Default Value
        /// </summary>
        public static readonly string DefaultString = String.Empty;

        /// <summary>
        /// Single Default Value
        /// </summary>
        public static readonly float DefaultFloat = Single.MinValue;

        /// <summary>
        /// Double Default Value
        /// </summary>
        public static readonly double DefaultDouble = Double.MinValue;

        /// <summary>
        /// DateTime Default Value
        /// </summary>
        public static readonly DateTime DefaultDateTime = DateTime.MinValue;

        /// <summary>
        /// Boolean Default Value
        /// </summary>
        public static readonly bool DefaultBoolean = false;

        /// <summary>
        /// Bytes Default Value
        /// </summary>
        public static readonly byte[] DefaultBytes = null;

        /// <summary>
        /// Guid Default Value
        /// </summary>
        public static readonly Guid DefaultGuid = default(Guid);

        /// <summary>
        /// Super Role ID.
        /// </summary>
        public static readonly Guid SuperRoleID = new Guid("00000001-0001-0001-0001-000000000001");

        /// <summary>
        /// DBNull String Handler
        /// </summary>
        /// <param name="val">val</param>
        public static string DBNullStringHandler(object val) {
            if (val == DBNull.Value) { return DefaultString; }
            return val.ToString();
        }

        /// <summary>
        /// DBNull String Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullStringChecker(string val) {
            if (val == DefaultString || String.IsNullOrWhiteSpace(val))
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Int32 Handler
        /// </summary>
        /// <param name="val">val</param>
        public static int DBNullInt32Handler(object val) {
            if (val == DBNull.Value) { return DefaultInt32; }
            return Convert.ToInt32(val);
        }

        /// <summary>
        /// DBNull Int32 Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullInt32Checker(int val) {
            if (val == DefaultInt32)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Int64 Handler
        /// </summary>
        /// <param name="val">val</param>
        public static long DBNullInt64Handler(object val) {
            if (val == DBNull.Value) { return DefaultInt64; }
            return Convert.ToInt64(val);
        }

        /// <summary>
        /// DBNull Int64 Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullInt64Checker(long val) {
            if (val == DefaultInt64)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Float Handler
        /// </summary>
        /// <param name="val">val</param>
        public static float DBNullFloatHandler(object val) {
            if (val == DBNull.Value) { return DefaultFloat; }
            return Convert.ToSingle(val);
        }

        /// <summary>
        /// DBNull Float Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullFloatChecker(float val) {
            if (val == DefaultFloat)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Double Handler
        /// </summary>
        /// <param name="val">val</param>
        public static double DBNullDoubleHandler(object val) {
            if (val == DBNull.Value) { return DefaultDouble; }
            return Convert.ToDouble(val);
        }

        /// <summary>
        /// DBNull Double Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullDoubleChecker(double val) {
            if (val == DefaultDouble)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull DateTime Handler
        /// </summary>
        /// <param name="val">val</param>
        public static DateTime DBNullDateTimeHandler(object val) {
            if (val == DBNull.Value) { return DefaultDateTime; }
            return Convert.ToDateTime(val);
        }

        /// <summary>
        /// DBNull DateTime Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullDateTimeChecker(DateTime val) {
            if (val == DefaultDateTime)
                return DBNull.Value;

            return val;
        }

        /// <summary>
        /// DBNull Boolean Handler
        /// </summary>
        /// <param name="val">val</param>
        public static bool DBNullBooleanHandler(object val) {
            if (val == DBNull.Value) { return DefaultBoolean; }
            return Convert.ToBoolean(val);
        }

        /// <summary>
        /// DBNull Bytes Handler
        /// </summary>
        /// <param name="val">val</param>
        public static byte[] DBNullBytesHandler(object val) {
            if (val == DBNull.Value) { return DefaultBytes; }
            return (byte[])val;
        }

        /// <summary>
        /// DBNull Bytes Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullBytesChecker(object val) {
            if (val == null) { return DBNull.Value; }
            return val;
        }

        /// <summary>
        /// DBNull Guid Handler
        /// </summary>
        /// <param name="val">val</param>
        public static Guid DBNullGuidHandler(object val) {
            if (val == DBNull.Value) { return DefaultGuid; }
            return Guid.Parse(val.ToString());
        }

        /// <summary>
        /// DBNull Super Handler
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullSuperChecker(Guid val) {
            if (val == SuperRoleID) { return DBNull.Value; }
            return val;
        }

        /// <summary>
        /// DBNull Node Type Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmNodeType DBNullNodeTypeHandler(object val) {
            if (val == DBNull.Value) { return EnmNodeType.Null; }
            var nodeType = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmNodeType), nodeType) ? (EnmNodeType)nodeType : EnmNodeType.Null;
        }

        /// <summary>
        /// DBNull State Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmState DBNullStateHandler(object val) {
            if (val == DBNull.Value) { return EnmState.Invalid; }
            var state = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmState), state) ? (EnmState)state : EnmState.Invalid;
        }

        /// <summary>
        /// DBNull Alarm Level Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmAlarmLevel DBNullAlarmLevelHandler(object val) {
            if (val == DBNull.Value) { return EnmAlarmLevel.NoAlarm; }
            var alarmLevel = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmAlarmLevel), alarmLevel) ? (EnmAlarmLevel)alarmLevel : EnmAlarmLevel.NoAlarm;
        }

        /// <summary>
        /// DBNull Alarm Level Checker
        /// </summary>
        /// <param name="val">val</param>
        public static object DBNullAlarmLevelChecker(EnmAlarmLevel val) {
            if (val == EnmAlarmLevel.NoAlarm) { return DBNull.Value; }
            return (Int32)val;
        }

        /// <summary>
        /// DBNull Alarm Status Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmAlarmStatus DBNullAlarmStatusHandler(object val) {
            if (val == DBNull.Value) { return EnmAlarmStatus.Invalid; }
            var alarmStatus = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmAlarmStatus), alarmStatus) ? (EnmAlarmStatus)alarmStatus : EnmAlarmStatus.Invalid;
        }

        /// <summary>
        /// DBNull Confirm Marking Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmConfirmMarking DBNullConfirmMarkingHandler(object val) {
            if (val == DBNull.Value) { return EnmConfirmMarking.Cancel; }
            var confirmMarking = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmConfirmMarking), confirmMarking) ? (EnmConfirmMarking)confirmMarking : EnmConfirmMarking.Cancel;
        }

        /// <summary>
        /// DBNull Database Intention Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmDBIntention DBNullDBIntentionHandler(object val) {
            if (val == DBNull.Value) { return EnmDBIntention.Master; }
            var intention = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmDBIntention), intention) ? (EnmDBIntention)intention : EnmDBIntention.Master;
        }

        /// <summary>
        /// DBNull Database Type Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmDBType DBNullDBTypeHandler(object val) {
            if (val == DBNull.Value) { return EnmDBType.SQLServer; }
            var dbType = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmDBType), dbType) ? (EnmDBType)dbType : EnmDBType.SQLServer;
        }

        /// <summary>
        /// DBNull Password Format Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmPasswordFormat DBNullPasswordFormatHandler(object val) {
            if (val == DBNull.Value) { return EnmPasswordFormat.Clear; }
            var format = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmPasswordFormat), format) ? (EnmPasswordFormat)format : EnmPasswordFormat.Clear;
        }

        /// <summary>
        /// DBNull marriage type Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmMarriageType DBNullMarriageTypeHandler(object val) {
            if (val == DBNull.Value) { return EnmMarriageType.OT; }
            var type = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmMarriageType), type) ? (EnmMarriageType)type : EnmMarriageType.OT;
        }

        /// <summary>
        /// DBNull card type Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmCardType DBNullCardTypeHandler(object val) {
            if (val == DBNull.Value) { return EnmCardType.ZSK; }
            var type = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmCardType), type) ? (EnmCardType)type : EnmCardType.ZSK;
        }

        /// <summary>
        /// DBNull worker type Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmWorkerType DBNullWorkerTypeHandler(object val) {
            if (val == DBNull.Value) { return EnmWorkerType.QT; }
            var type = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmWorkerType), type) ? (EnmWorkerType)type : EnmWorkerType.QT;
        }

        /// <summary>
        /// DBNull limit id Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmLimitID DBNullLimitIDHandler(object val) {
            if (val == DBNull.Value) { return EnmLimitID.TQ; }
            var type = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmLimitID), type) ? (EnmLimitID)type : EnmLimitID.TQ;
        }

        /// <summary>
        /// DBNull direction Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmDirection DBNullDirectionHandler(object val) {
            if (val == DBNull.Value) { return EnmDirection.InToOut; }
            var dir = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmDirection), dir) ? (EnmDirection)dir : EnmDirection.InToOut;
        }

        /// <summary>
        /// DBNull Msg Type Handler
        /// </summary>
        /// <param name="val">val</param>
        public static EnmMsgType DBNullMsgTypeHandler(object val) {
            if (val == DBNull.Value) { return EnmMsgType.Other; }
            var msgType = Convert.ToInt32(val);
            return Enum.IsDefined(typeof(EnmMsgType), msgType) ? (EnmMsgType)msgType : EnmMsgType.Other;
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
        /// Get worker type text.
        /// </summary>
        /// <param name="workerType">worker Type</param>
        /// <returns>worker type text</returns>
        public static String GetWorkerTypeText(EnmWorkerType workerType) {
            switch (workerType) {
                case EnmWorkerType.WXRY:
                    return "外协人员";
                case EnmWorkerType.ZSYG:
                    return "正式员工";
                case EnmWorkerType.JZYG:
                    return "兼职员工";
                case EnmWorkerType.WPYG:
                    return "外聘员工";
                case EnmWorkerType.QT:
                    return "其他";
                default:
                    return "未定义";
            }
        }

        /// <summary>
        /// Get marriage type text.
        /// </summary>
        /// <param name="marriageType">marriage type</param>
        /// <returns>marriage type text</returns>
        public static String GetMarriageTypeText(EnmMarriageType marriageType) {
            switch (marriageType) {
                case EnmMarriageType.SG:
                    return "未婚";
                case EnmMarriageType.MD:
                    return "已婚";
                case EnmMarriageType.OT:
                    return "其他";
                default:
                    return "未定义";
            }
        }

        /// <summary>
        /// Get marriage type text.
        /// </summary>
        /// <param name="marriageType">marriage type</param>
        /// <returns>marriage type text</returns>
        public static String GetCardTypeText(EnmCardType cardType) {
            switch (cardType) {
                case EnmCardType.ZSK:
                    return "正式卡";
                case EnmCardType.LSK:
                    return "临时卡";
                default:
                    return "未定义";
            }
        }

        /// <summary>
        /// Get limit Id text.
        /// </summary>
        /// <param name="limitId">limit Id</param>
        /// <returns>limit Id text</returns>
        public static String GetLimitIDText(EnmLimitID limitId) {
            switch (limitId) {
                case EnmLimitID.TQ:
                    return "特权";
                case EnmLimitID.WTMG:
                    return "星期";
                case EnmLimitID.NDTM:
                    return "非工作日";
                case EnmLimitID.DTM:
                    return "工作日";
                case EnmLimitID.IRTM:
                    return "红外";
                case EnmLimitID.SHD:
                    return "假日";
                case EnmLimitID.SWD:
                    return "周末";
                default:
                    return "未定义";
            }
        }

        /// <summary>
        /// Get log type text.
        /// </summary>
        /// <param name="logType">log type</param>
        /// <returns>log type text</returns>
        public static String GetLogTypeText(EnmMsgType logType) {
            switch (logType) {
                case EnmMsgType.Error:
                    return "错误";
                case EnmMsgType.Warning:
                    return "警告";
                case EnmMsgType.Info:
                    return "信息";
                case EnmMsgType.Login:
                    return "登录";
                case EnmMsgType.Logout:
                    return "登出";
                case EnmMsgType.Cardin:
                    return "发卡";
                case EnmMsgType.Cardout:
                    return "撤卡";
                case EnmMsgType.Authin:
                    return "授权";
                case EnmMsgType.Authout:
                    return "撤权";
                case EnmMsgType.Remote:
                    return "遥控";
                case EnmMsgType.Other:
                    return "其他";
                default:
                    return "未定义";
            }
        }

        /// <summary>
        /// Method to get alarm level name
        /// </summary>
        /// <param name="level">level</param>
        public static String GetAlarmLevelName(EnmAlarmLevel level) {
            switch (level) {
                case EnmAlarmLevel.NoAlarm:
                    return "全部告警";
                case EnmAlarmLevel.Critical:
                    return "一级告警";
                case EnmAlarmLevel.Major:
                    return "二级告警";
                case EnmAlarmLevel.Minor:
                    return "三级告警";
                case EnmAlarmLevel.Hint:
                    return "四级告警";
                default:
                    return "Undefined";
            }
        }

        #region Login Package
        /// <summary>
        /// Login Package
        /// </summary>
        /// <param name="uId">UID</param>
        /// <param name="pwd">PWD</param>
        /// <param name="serialNo">SerialNo</param>
        /// <returns>Login Package</returns>
        public static byte[] GetLoginPack(string uId, string pwd, int serialNo) {
            try {
                byte[] pack = new byte[58];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 58;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 101;

                byt = ASCIIEncoding.Default.GetBytes(uId);
                for (int b = 1; b <= 20; b++) {
                    if (byt.Length < b)
                        pack[15 + b] = 0;
                    else
                        pack[15 + b] = byt[b - 1];
                }

                byt = ASCIIEncoding.Default.GetBytes(pwd);
                for (int b = 1; b <= 20; b++) {
                    if (byt.Length < b)
                        pack[35 + b] = 0;
                    else
                        pack[35 + b] = byt[b - 1];
                }

                byt = CRC16T(pack, 4, 55);
                pack[56] = byt[0];
                pack[57] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Logout Package
        /// <summary>
        /// Logout Package
        /// </summary>
        /// <param name="serialNo">serialNo</param>
        /// <returns>Logout Package</returns>
        public static byte[] GetLogOutPack(int serialNo) {
            try {
                byte[] pack = new byte[18];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 18;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 103;

                byt = CRC16T(pack, 4, 15);
                pack[16] = byt[0];
                pack[17] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region NodeState Package
        /// <summary>
        /// NodeState Package
        /// </summary>
        /// <param name="TerminalID">TerminalID</param>
        /// <param name="GroudID">GroudID</param>
        /// <param name="AcceMode">AcceMode</param>
        /// <param name="Polling">Polling</param>
        /// <param name="serialNo">serialNo</param>
        /// <param name="nodes">nodes</param>
        /// <returns>NodeState Package</returns>
        public static byte[] GetNodePack(int TerminalID, int GroudID, byte AcceMode, int Polling, int serialNo, Dictionary<int, int> nodes) {
            if (nodes == null || nodes.Count <= 0)
                return null;

            try {
                int len = 38 + nodes.Count * 8;
                byte[] pack = new byte[len];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;

                byt = BitConverter.GetBytes(len);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0xAB;
                pack[13] = 0xF;

                byt = BitConverter.GetBytes(TerminalID);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                byt = BitConverter.GetBytes(GroudID);
                pack[20] = byt[0];
                pack[21] = byt[1];
                pack[22] = byt[2];
                pack[23] = byt[3];
                pack[24] = AcceMode;

                byt = BitConverter.GetBytes(Polling);
                pack[28] = byt[0];
                pack[29] = byt[1];
                pack[30] = byt[2];
                pack[31] = byt[3];

                byt = BitConverter.GetBytes(nodes.Count);
                pack[32] = byt[0];
                pack[33] = byt[1];
                pack[34] = byt[2];
                pack[35] = byt[3];

                int packIndex = 35;
                foreach (KeyValuePair<int, int> key in nodes) {
                    byt = BitConverter.GetBytes(key.Value);
                    pack[packIndex + 1] = byt[0];
                    pack[packIndex + 2] = byt[1];
                    pack[packIndex + 3] = byt[2];
                    pack[packIndex + 4] = byt[3];
                    byt = BitConverter.GetBytes(key.Key);
                    pack[packIndex + 5] = byt[0];
                    pack[packIndex + 6] = byt[1];
                    pack[packIndex + 7] = byt[2];
                    pack[packIndex + 8] = byt[3];
                    packIndex += 8;
                }

                byt = CRC16T(pack, 4, pack.Length - 3);
                pack[pack.Length - 2] = byt[0];
                pack[pack.Length - 1] = byt[1];
                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region SetDO Package
        /// <summary>
        /// SetDO Package
        /// </summary>
        /// <param name="NodeId">NodeId</param>
        /// <param name="Value">Value</param>
        /// <param name="LscId">LscId</param>
        /// <param name="UserId">UserId</param>
        /// <param name="UserName">UserName</param>
        /// <param name="serialNo">serialNo</param>
        /// <returns>SetDO Package</returns>
        public static byte[] GetSetDOPack(int NodeId, byte Value, int LscId, int UserId, string UserName, int serialNo) {
            try {
                byte[] pack = new byte[59];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 59;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0x89;
                pack[13] = 0x13;
                pack[16] = 4;

                byt = BitConverter.GetBytes(NodeId);
                pack[20] = byt[0];
                pack[21] = byt[1];
                pack[22] = byt[2];
                pack[23] = byt[3];

                byt = BitConverter.GetBytes(LscId);
                pack[24] = byt[0];
                pack[25] = byt[1];
                pack[26] = byt[2];
                pack[27] = byt[3];
                pack[28] = Value;
                pack[29] = (byte)EnmState.Opevent;

                byt = BitConverter.GetBytes(UserId);
                pack[33] = byt[0];
                pack[34] = byt[1];
                pack[35] = byt[2];
                pack[36] = byt[3];

                byt = ASCIIEncoding.Default.GetBytes(UserName);
                for (int i = 0; i < byt.Length; i++) {
                    pack[37 + i] = byt[i];
                }

                byt = CRC16T(pack, 4, 56);
                pack[57] = byt[0];
                pack[58] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region SetAO Package
        /// <summary>
        /// SetAO Package
        /// </summary>
        /// <param name="NodeId">NodeId</param>
        /// <param name="Value">Value</param>
        /// <param name="LscId">LscId</param>
        /// <param name="UserId">UserId</param>
        /// <param name="UserName">UserName</param>
        /// <param name="serialNo">serialNo</param>
        /// <returns>SetAO Package</returns>
        public static byte[] GetSetAOPack(int NodeId, float Value, int LscId, int UserId, string UserName, int serialNo) {
            try {
                byte[] pack = new byte[62];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 62;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0x89;
                pack[13] = 0x13;
                pack[16] = 5;

                byt = BitConverter.GetBytes(NodeId);
                pack[20] = byt[0];
                pack[21] = byt[1];
                pack[22] = byt[2];
                pack[23] = byt[3];

                byt = BitConverter.GetBytes(LscId);
                pack[24] = byt[0];
                pack[25] = byt[1];
                pack[26] = byt[2];
                pack[27] = byt[3];

                byt = BitConverter.GetBytes(Value);
                pack[28] = byt[0];
                pack[29] = byt[1];
                pack[30] = byt[2];
                pack[31] = byt[3];
                pack[32] = (byte)EnmState.Opevent;

                byt = BitConverter.GetBytes(UserId);
                pack[36] = byt[0];
                pack[37] = byt[1];
                pack[38] = byt[2];
                pack[39] = byt[3];

                byt = ASCIIEncoding.Default.GetBytes(UserName);
                for (int i = 0; i < byt.Length; i++) {
                    pack[40 + i] = byt[i];
                }

                byt = CRC16T(pack, 4, 59);
                pack[60] = byt[0];
                pack[61] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region ConfirmAlarm Package
        /// <summary>
        /// ConfirmAlarm Package
        /// </summary>
        /// <param name="Ids">Ids</param>
        /// <param name="DispatchNO">DispatchNO</param>
        /// <param name="UserName">UserName</param>
        /// <param name="serialNo">serialNo</param>
        /// <returns>ConfirmAlarm Package</returns>
        public static byte[] GetConfirmAlarmPack(List<int> Ids, int DispatchNO, string UserName, int serialNo) {
            try {
                byte[] pack = new byte[46 + Ids.Count * 4];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                byt = BitConverter.GetBytes(pack.Length);
                pack[4] = byt[0];
                pack[5] = byt[1];
                pack[6] = byt[2];
                pack[7] = byt[3];

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0x7C;
                pack[13] = 0x15;

                byt = BitConverter.GetBytes(Ids.Count);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                int n = 20;
                for (int i = 0; i < Ids.Count; i++) {
                    byt = BitConverter.GetBytes(Ids[i]);
                    pack[n] = byt[0];
                    pack[n + 1] = byt[1];
                    pack[n + 2] = byt[2];
                    pack[n + 3] = byt[3];
                    n += 4;
                }

                byt = BitConverter.GetBytes(DispatchNO);
                pack[n] = byt[0];
                pack[n + 1] = byt[1];
                pack[n + 2] = byt[2];
                pack[n + 3] = byt[3];
                n += 4;

                byt = ASCIIEncoding.Default.GetBytes(UserName);
                for (int i = 0; i < 20; i++) {
                    if (byt.Length - 1 < i)
                        pack[n + i] = 0;
                    else
                        pack[n + i] = byt[i];
                }
                n += 19;

                byt = CRC16T(pack, 4, n);
                pack[n + 1] = byt[0];
                pack[n + 2] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Alarm Ack Package
        /// <summary>
        /// GetAlarmAckPack
        /// </summary>
        /// <param name="revPack">revPack</param>
        public static byte[] GetAlarmAckPack(byte[] revPack) {
            try {
                byte[] byt;
                revPack[12] = 0xF8;
                byt = CRC16T(revPack, 4, revPack.Length - 3);
                revPack[revPack.Length - 2] = byt[0];
                revPack[revPack.Length - 1] = byt[1];

                return revPack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Sync Alarm Package
        public static byte[] GetSyncAlarmPack(int serialNo) {
            try {
                byte[] pack = new byte[22];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 22;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];

                byt = BitConverter.GetBytes((int)EnmTcpMsgType.packReqSyncAlarm);
                pack[12] = byt[0];
                pack[13] = byt[1];
                pack[14] = byt[2];
                pack[15] = byt[3];

                byt = BitConverter.GetBytes(0);
                pack[16] = byt[0];
                pack[17] = byt[1];
                pack[18] = byt[2];
                pack[19] = byt[3];

                byt = CRC16T(pack, 4, 19);
                pack[20] = byt[0];
                pack[21] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region Sync Server DateTime Package
        /// <summary>
        /// Server DateTime Package
        /// </summary>
        /// <param name="serialNo">serialNo</param>
        /// <returns>Server DateTime Package</returns>
        public static byte[] GetServerDateTimePackage(int serialNo) {
            try {
                byte[] pack = new byte[18];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 18;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0xB5;
                pack[13] = 0x14;

                byt = CRC16T(pack, 4, 15);
                pack[16] = byt[0];
                pack[17] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region HeartBeat Package
        /// <summary>
        /// HeartBeat Package
        /// </summary>
        /// <param name="serialNo">serialNo</param>
        /// <returns>HeartBeat Package</returns>
        public static byte[] GetHeartBeatPack(int serialNo) {
            try {
                byte[] pack = new byte[18];
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 18;

                byt = BitConverter.GetBytes(serialNo);
                pack[8] = byt[0];
                pack[9] = byt[1];
                pack[10] = byt[2];
                pack[11] = byt[3];
                pack[12] = 0xB1;
                pack[13] = 4;

                byt = CRC16T(pack, 4, 15);
                pack[16] = byt[0];
                pack[17] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region HeartBeat Ack Package
        /// <summary>
        /// HeartBeat Ack Package
        /// </summary>
        /// <param name="pack">pack</param>
        /// <returns></returns>
        public static byte[] GetHeartBeatAckPack(byte[] pack) {
            try {
                byte[] byt;

                pack[0] = 0x5A;
                pack[1] = 0x6B;
                pack[2] = 0x7C;
                pack[3] = 0x7E;
                pack[4] = 18;

                pack[12] = 0xB2;
                pack[13] = 4;

                byt = CRC16T(pack, 4, 15);
                pack[16] = byt[0];
                pack[17] = byt[1];

                return pack;
            } catch {
                throw;
            }
        }
        #endregion

        #region CRC-16T Package
        /// <summary>
        /// CRC-16T Package
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="offset">offset</param>
        /// <param name="endset">endset</param>
        /// <returns>CRC-16T Package</returns>
        public static byte[] CRC16T(byte[] data, int offset, int endset) {
            byte[] returnData = { 0, 0 };
            if (data == null)
                return returnData;

            byte CRC16Hi;
            byte CRC16Lo;
            int iIndex;

            try {
                CRC16Hi = 0xFF;
                CRC16Lo = 0xFF;

                if (endset == 0)
                    endset = data.GetUpperBound(0);

                for (int i = offset; i <= endset; i++) {
                    iIndex = CRC16Lo ^ data[i];
                    CRC16Lo = (byte)(CRC16Hi ^ GetCRC_16_Lo(iIndex));
                    CRC16Hi = GetCRC_16_Hi(iIndex);
                }

                returnData[0] = CRC16Hi;
                returnData[1] = CRC16Lo;

                return returnData;
            } catch {
                return (new byte[2] { 0, 0 });
            }
        }
        #endregion

        #region CRC-16T Low List
        /// <summary>
        /// CRC-16T Low List
        /// </summary>
        /// <param name="Ind">Ind</param>
        /// <returns>CRC-16T Low List</returns>
        private static byte GetCRC_16_Lo(int Ind) {
            try {
                byte[] LoBty = { 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 
                                 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 
                                 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 
                                 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0,
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 
                                 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 
                                 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 
                                 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 
                                 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 
                                 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 0x80, 0x41, 0x0, 0xC1, 
                                 0x81, 0x40, 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 
                                 0x0, 0xC1, 0x81, 0x40, 0x1, 0xC0, 0x80, 0x41, 0x1, 0xC0, 
                                 0x80, 0x41, 0x0, 0xC1, 0x81, 0x40
                               };

                return LoBty[Ind];
            } catch {
                return 0;
            }
        }
        #endregion

        #region CRC-16T High List
        /// <summary>
        /// CRC-16T High List
        /// </summary>
        /// <param name="Ind">Ind</param>
        /// <returns>CRC-16T High List</returns>
        private static byte GetCRC_16_Hi(int Ind) {
            try {
                byte[] HiBty = { 0x0, 0xC0, 0xC1, 0x1, 0xC3, 0x3, 0x2, 0xC2, 0xC6, 0x6,
                                 0x7, 0xC7, 0x5, 0xC5, 0xC4, 0x4, 0xCC, 0xC, 0xD, 0xCD, 
                                 0xF, 0xCF, 0xCE, 0xE, 0xA, 0xCA, 0xCB, 0xB, 0xC9, 0x9,
                                 0x8, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A,
                                 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC, 0x14, 0xD4,
                                 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3, 
                                 0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3,
                                 0xF2, 0x32, 0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 
                                 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 
                                 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 
                                 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF, 0x2D, 0xED, 
                                 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26, 
                                 0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 
                                 0x61, 0xA1, 0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 
                                 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 
                                 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 
                                 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 
                                 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5, 
                                 0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 
                                 0x70, 0xB0, 0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 
                                 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 
                                 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 
                                 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89, 0x4B, 0x8B, 
                                 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C, 
                                 0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 
                                 0x43, 0x83, 0x41, 0x81, 0x80, 0x40
                               };

                return HiBty[Ind];
            } catch {
                return 0;
            }
        }
        #endregion

        #region Check Single Package
        /// <summary>
        /// Check Single Package
        /// </summary>
        /// <param name="package">package</param>
        /// <param name="revLen">revLen</param>
        public static bool CheckSinglePackage(byte[] package, int revLen) {
            try {
                if (revLen > 17
                    && package[0] == 0x5A
                    && package[1] == 0x6B
                    && package[2] == 0x7C
                    && package[3] == 0x7E) {
                    int packLen = BitConverter.ToInt32(package, 4);
                    return revLen == packLen;
                }

                return false;
            } catch {
                throw;
            }
        }
        #endregion

        #region Alarm Describe String
        /// <summary>
        /// Alarm Describe String
        /// </summary>
        /// <param name="Describe">Describe</param>
        /// <param name="value">value</param>
        /// <returns>Alarm Describe String</returns>
        public static string GetDesc(string Describe, string value) {
            try {
                string[] strs = Describe.Split(new char[] { '\t' });
                string[] strs1;
                for (int i = 0; i < strs.Length; i++) {
                    strs1 = strs[i].Split(new char[] { '&' });
                    if (strs1[0].Equals(value))
                        return strs1[1];
                }

                return String.Empty;
            } catch {
                return String.Empty;
            }
        }
        #endregion
    }
}