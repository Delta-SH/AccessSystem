using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.Model
{
    /// <summary>
    /// Message Type
    /// </summary>
    public enum EnmMsgType
    {
        Error,
        Warning,
        Info,
        Login,
        Logout,
        Cardin,
        Cardout,
        Authin,
        Authout,
        Remote,
        Other
    }

    /// <summary>
    /// Login Status
    /// </summary>
    public enum EnmLoginStatus
    {
        Offing,
        Off,
        Logining,
        Logined,
        Loading,
        Loaded
    }

    /// <summary>
    /// License Status
    /// </summary>
    public enum EnmLicenseStatus
    {
        Invalid,
        Expired,
        Evaluation,
        Licensed
    }

    /// <summary>
    /// Database Type
    /// </summary>
    public enum EnmDBType
    {
        SQLServer,
        Oracle
    }

    /// <summary>
    /// EnmDBIntention
    /// </summary>
    public enum EnmDBIntention
    {
        Master,
        History
    }

    /// <summary>
    /// User Level
    /// </summary>
    public enum EnmUserLevel
    {
        Ordinary,
        Maintenance,
        Attendant,
        Administrator
    }

    /// <summary>
    /// Node Type
    /// </summary>
    public enum EnmNodeType
    {
        Null = -3,
        LSC = -2,
        Area = -1,
        Sta = 0,
        Dev = 1,
        Dic = 2,
        Aic = 3,
        Doc = 4,
        Aoc = 5,
        Str = 6,
        Img = 7,
        Sic = 9,
        SS = 10,
        RS = 11,
        RTU = 12
    }

    /// <summary>
    /// EnmPasswordFormat
    /// </summary>
    public enum EnmPasswordFormat
    {
        Clear,
        Hashed
    }

    /// <summary>
    /// EnmFormBehavior
    /// </summary>
    public enum EnmSaveBehavior
    {
        Null,
        Add,
        Edit
    }

    /// <summary>
    /// Alarm Level
    /// </summary>
    public enum EnmAlarmLevel
    {
        NoAlarm,
        Critical,
        Major,
        Minor,
        Hint
    }

    /// <summary>
    /// EnmWorkerType
    /// </summary>
    public enum EnmWorkerType
    {
        WXRY,
        ZSYG,
        JZYG,
        WPYG,
        QT
    }

    /// <summary>
    /// Marriage Type
    /// </summary>
    public enum EnmMarriageType
    {
        SG,
        MD,
        OT
    }

    /// <summary>
    /// EnmCardType
    /// </summary>
    public enum EnmCardType
    {
        LSK,
        ZSK
    }

    /// <summary>
    /// EnmLimitID
    /// </summary>
    public enum EnmLimitID
    {
        /// <summary>
        /// 特权
        /// </summary>
        TQ = -1,

        /// <summary>
        /// 星期
        /// </summary>
        WTMG = 0,

        /// <summary>
        /// 非工作日
        /// </summary>
        NDTM = 1,

        /// <summary>
        /// 工作日
        /// </summary>
        DTM = 2,

        /// <summary>
        /// 红外
        /// </summary>
        IRTM = 3,

        /// <summary>
        /// 假日
        /// </summary>
        SHD = 4,

        /// <summary>
        /// 周末
        /// </summary>
        SWD = 5
    }

    /// <summary>
    /// EnmTestStatus
    /// </summary>
    public enum EnmTestStatus
    {
        Default,
        Testing,
        Success,
        Failure,
        Stop
    }

    /// <summary>
    /// EnmRunState
    /// </summary>
    public enum EnmRunState
    {
        Start,
        Init,
        Run,
        Pause,
        Stop
    }

    /// <summary>
    /// Alarm status
    /// </summary>
    public enum EnmAlarmStatus
    {
        Start,
        Confirm,
        Ended,
        Invalid
    }

    /// <summary>
    /// Alarm confirm marking
    /// </summary>
    public enum EnmConfirmMarking
    {
        NotConfirm,
        NotDispatch,
        Dispatched,
        Processing,
        Processed,
        FileOff,
        Cancel
    }

    /// <summary>
    /// Node state
    /// </summary>
    public enum EnmState
    {
        NoAlarm,
        Critical,
        Major,
        Minor,
        Hint,
        Opevent,
        Invalid
    }

    /// <summary>
    /// TCP Link State
    /// </summary>
    public enum EnmLinkState
    {
        Disconnect,
        Connected,
        Authentication
    }

    /// <summary>
    /// Msg Type
    /// </summary>
    public enum EnmTcpMsgType
    {
        Pack = 0,
        packLogin = 101,
        packLoginAck = 102,
        packLogout = 103,
        packLogoutAck = 104,
        packSetAcceMode = 401,
        packSetAcceModeAck = 402,
        packSetAcceModeAck2 = 4012,
        packSetAlarmMode = 501,
        packSetAlarmModeAck = 502,
        packSendAlarm = 503,
        packSendAlarmAck = 504,
        packReqSyncAlarm = 505,
        packSyncAllAlarm = 506,
        packSetPoint = 1001,
        packSetPointAck = 1002,
        packReqModifyPassword = 1101,
        packReqModifyPasswordAck = 1102,
        packHeartbeat = 1201,
        packHeartbeatAck = 1202,
        packTimeCheck = 1301,
        packTimeCheckAck = 1302,
        packPropertyModify = 1501,
        packPropertyModifyAck = 1502,
        packGetServerTimeAck = 5302,
        packDirectSendAlarm = 5011,
        packDirectSendAlarmAck = 5012,
        packSetTask = 5601,
        packSendSheetSetMsg = 5603,
        packSendPunch = 6001
    }

    /// <summary>
    /// Right Mode
    /// </summary>
    public enum EnmRightMode
    {
        Invalid,
        Level1,
        Level2,
        Level3
    }

    /// <summary>
    /// Result
    /// </summary>
    public enum EnmResult
    {
        Failure,
        Success
    }

    /// <summary>
    /// EnmAcceMode
    /// </summary>
    public enum EnmAcceMode
    {
        Ask_Answer,
        Change_Trigger,
        Time_Trigger,
        Stoped
    }

    /// <summary>
    /// Action type
    /// </summary>
    public enum EnmActType
    {
        RequestNode,
        ConfirmAlarm,
        SetDoc,
        SetAoc
    }

    /// <summary>
    /// Direction
    /// </summary>
    public enum EnmDirection
    {
        OutToIn,
        InToOut
    }

    /// <summary>
    /// Import Type
    /// </summary>
    public enum EnmImportType
    {
        Org,
        Out
    }
}