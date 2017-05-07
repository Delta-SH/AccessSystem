using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.DBUtility
{
    /// <summary>
    /// The SQLText class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SqlClient.
    /// </summary>
    public static class SQLText
    {
        /// <summary>
        /// Member ship SQL Text
        /// </summary>
        public const String SQL_MS_GetRole = @"
        SELECT [RoleId],[RoleName],[Comment],[LastRoleId],[Enabled] FROM [dbo].[AS_Roles] WHERE [RoleId] = @RoleId;";

        public const String SQL_MS_GetRoles = @"
        SELECT [RoleId],[RoleName],[Comment],[LastRoleId],[Enabled] FROM [dbo].[AS_Roles];";

        public const String SQL_MS_GetSubRoles = @"
        ;WITH Roles([RoleId],[RoleName],[Comment],[LastRoleId],[Enabled]) AS
        (
	        SELECT [RoleId],[RoleName],[Comment],[LastRoleId],[Enabled] FROM [dbo].[AS_Roles]
	        WHERE [LastRoleId] = @RoleId
	        UNION ALL
	        SELECT AR.[RoleId],AR.[RoleName],AR.[Comment],AR.[LastRoleId],AR.[Enabled]
	        FROM [dbo].[AS_Roles] AR INNER JOIN Roles R ON AR.[LastRoleId] = R.[RoleId]
        )
        SELECT [RoleId],[RoleName],[Comment],[LastRoleId],[Enabled] FROM Roles;";

        public const String SQL_MS_GetRoleAuthorizations = @"
        IF(@RoleId IS NULL)
        BEGIN
            SELECT [AuthId],[AuthName],[Comment],[LastAuthId],[Enabled] FROM [dbo].[AS_Authorizations] ORDER BY [AuthId];
        END
        ELSE
        BEGIN
            SELECT AA.[AuthId],AA.[AuthName],AA.[Comment],AA.[LastAuthId],AA.[Enabled] FROM [dbo].[AS_Authorizations] AA 
            INNER JOIN [dbo].[AS_AuthorizationsInRoles] AAR ON AAR.[RoleId] = @RoleId AND AA.[AuthId] = AAR.[AuthId]
            ORDER BY AA.[AuthId];
        END";

        public const String SQL_MS_GetRoleNodes = @"
        DECLARE @Nodes TABLE 
        (
	        [NodeId] [INT] NOT NULL,
	        [NodeType] [INT] NOT NULL,
	        [NodeName] [NVARCHAR](50) NULL,
	        [LastNodeId] [INT] NULL,
	        [SortIndex] [INT] NULL,
	        [Remark] [VARCHAR](255) NULL
	        PRIMARY KEY CLUSTERED 
	        (
		        [NodeId] ASC,
		        [NodeType] ASC
	        )
        );

        IF(@RoleId IS NULL)
        BEGIN
            ;WITH MJ AS
            (
	            SELECT SS.[SicID] AS [RtuID],SS.[LscNodeID] AS [DevID] FROM [dbo].[TM_SubSic] SS 
	            INNER JOIN [dbo].[TR_RTU] R  ON SS.[SicID] = R.[RtuID]
	            WHERE R.[Protocol] = 'F1' OR R.[Protocol] = 'CD' OR R.[Protocol] = 'CD_NEW'
            )
            INSERT INTO @Nodes([NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark])
            SELECT D.[DevID] AS NodeID,@DevType AS NodeType,D.[DevName] AS NodeName,D.[StaID] AS LastNodeID,ROW_NUMBER() OVER(ORDER BY D.[DevName]) AS SortIndex,ISNULL(P.ProdName,'') AS [Remark] 
            FROM [dbo].[TM_DEV] D
            INNER JOIN [dbo].[TC_DeviceType] TDT ON D.[DevTypeID] = TDT.[TypeID] AND TDT.[TypeName] LIKE '%门禁%'
            LEFT OUTER JOIN [dbo].[TC_Productor] P ON D.[ProductorID] = P.[RecordID]
            WHERE EXISTS(SELECT 1 FROM MJ WHERE D.[DevID] = MJ.[DevID]);
	    
	        INSERT INTO @Nodes([NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark])
	        SELECT TS.[StaID] AS NodeID,@StaType AS NodeType,TS.[StaName] AS [NodeName],TS.[AreaID] AS LastNodeID,
	        ROW_NUMBER() OVER(ORDER BY ISNULL(TS.[NetGridID],2000000000),TS.[StaTypeID],TS.[StaName]) AS SortIndex,ISNULL(TST.[TypeName],'')+'&'+ISNULL(TNG.[TypeName],'') AS [Remark] 
	        FROM [dbo].[TM_STA] TS
	        LEFT OUTER JOIN [dbo].[TC_StationType] TST ON TS.[StaTypeID] = TST.[TypeID]
            LEFT OUTER JOIN [dbo].[TC_NetGrid] TNG ON TS.[NetGridID] = TNG.[TypeID]
	        WHERE (SELECT COUNT(1) FROM @Nodes TD WHERE TS.StaID = TD.LastNodeID AND TD.[NodeType] = @DevType) > 0;
	    
	        INSERT INTO @Nodes([NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark])
	        SELECT TA.[AreaID] AS NodeID,@AreaType AS NodeType,TA.[AreaName] AS [NodeName],TA.[LastAreaID] AS LastNodeID,
	        ROW_NUMBER() OVER(ORDER BY TA.[LastAreaID],TA.[AreaName]) AS SortIndex,CAST(TA.[NodeLevel] AS VARCHAR) AS [Remark] 
	        FROM [dbo].[TM_AREA] TA 
	        WHERE (SELECT COUNT(1) FROM @Nodes TS WHERE TA.[AreaID] = TS.[LastNodeID] AND TS.[NodeType] = @StaType) > 0;

	        INSERT INTO @Nodes([NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark])
	        SELECT TAA.[AreaID] AS NodeID,@AreaType AS NodeType,TAA.[AreaName] AS [NodeName],TAA.[LastAreaID] AS LastNodeID,
	        ROW_NUMBER() OVER(ORDER BY TAA.[LastAreaID],TAA.[AreaName]) AS SortIndex,CAST(TAA.[NodeLevel] AS VARCHAR) AS [Remark] 
	        FROM [dbo].[TM_AREA] TAA 
	        WHERE (SELECT COUNT(1) FROM @Nodes TA WHERE TAA.[AreaID] = TA.[LastNodeID] AND TAA.[NodeLevel] = 2 AND TA.[NodeType] = @AreaType) > 0;

	        INSERT INTO @Nodes([NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark])
	        SELECT TAAA.[AreaID] AS NodeID,@AreaType AS NodeType,TAAA.[AreaName] AS [NodeName],TAAA.[LastAreaID] AS LastNodeID,
	        ROW_NUMBER() OVER(ORDER BY TAAA.[LastAreaID],TAAA.[AreaName]) AS SortIndex,CAST(TAAA.[NodeLevel] AS VARCHAR) AS [Remark] 
	        FROM [dbo].[TM_AREA] TAAA 
	        WHERE (SELECT COUNT(1) FROM @Nodes TAA WHERE TAAA.[AreaID] = TAA.[LastNodeID] AND TAAA.[NodeLevel] = 1 AND TAA.[NodeType] = @AreaType) > 0;
        END
        ELSE 
        BEGIN
	        DECLARE @RoleNodes TABLE 
	        (
		        [RoleId] [UNIQUEIDENTIFIER] NOT NULL,
		        [NodeId] [INT] NOT NULL,
		        [NodeType] [INT] NULL,
		        [LastNodeId] [INT] NULL,
		        [SortIndex] [INT] NULL,
		        PRIMARY KEY CLUSTERED 
		        (
			        [RoleId] ASC,
			        [NodeId] ASC
		        )
	        );

	        INSERT INTO @RoleNodes([RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex])
	        SELECT [RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex] FROM [dbo].[Fun_GetNodesInRole](@RoleID)
	        WHERE [RoleId] = @RoleId;

	        INSERT INTO @Nodes([NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark])
	        SELECT RN.[NodeId],RN.[NodeType],TA.[AreaName] AS [NodeName],RN.[LastNodeId],ROW_NUMBER() OVER(ORDER BY TA.[LastAreaID],TA.[AreaName]) AS [SortIndex],CAST(TA.[NodeLevel] AS VARCHAR) AS [Remark] 
	        FROM [dbo].[TM_AREA] TA 
	        INNER JOIN @RoleNodes RN ON TA.[AreaID] = RN.[NodeID] AND RN.[NodeType] = @AreaType;

	        INSERT INTO @Nodes([NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark])
	        SELECT RN.[NodeId],RN.[NodeType],TS.[StaName] AS [NodeName],RN.[LastNodeId],ROW_NUMBER() OVER(ORDER BY ISNULL(TS.[NetGridID],2000000000),TS.[StaTypeID],TS.[StaName]) AS [SortIndex],ISNULL(TST.[TypeName],'')+'&'+ISNULL(TNG.[TypeName],'') AS [Remark]
	        FROM [dbo].[TM_STA] TS
	        INNER JOIN @RoleNodes RN ON TS.[StaID] = RN.[NodeID] AND RN.[NodeType] = @StaType
	        LEFT OUTER JOIN [dbo].[TC_StationType] TST ON TS.[StaTypeID] = TST.[TypeID]
            LEFT OUTER JOIN [dbo].[TC_NetGrid] TNG ON TS.[NetGridID] = TNG.[TypeID];

	        INSERT INTO @Nodes([NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark])
	        SELECT RN.[NodeId],RN.[NodeType],TD.[DevName] AS NodeName,RN.[LastNodeId],ROW_NUMBER() OVER(ORDER BY TD.[DevName]) AS [SortIndex],ISNULL(TP.[ProdName],'') AS [Remark]
	        FROM [dbo].[TM_DEV] TD 
	        INNER JOIN @RoleNodes RN ON TD.[DevID] = RN.[NodeID] AND RN.[NodeType] = @DevType
	        LEFT OUTER JOIN [dbo].[TC_Productor] TP ON TD.[ProductorID] = TP.[RecordID]
	        LEFT OUTER JOIN [dbo].[TC_DeviceType] TCD ON TD.[DevTypeID] = TCD.[TypeID];
        END

        SELECT [NodeId],[NodeType],[NodeName],[LastNodeId],[SortIndex],[Remark] FROM @Nodes ORDER BY [NodeType],[SortIndex];";

        public const String SQL_MS_GetRoleDevices = @"
        IF(@RoleId IS NULL)
        BEGIN
        DECLARE @MJ TABLE(
            [RtuID] [INT] NOT NULL,
            [DevID] [INT] NOT NULL,
            PRIMARY KEY CLUSTERED 
            (
                [RtuID] ASC,
                [DevID] ASC
            )
        );

        INSERT INTO @MJ([RtuID],[DevID])
        SELECT SS.[SicID],SS.[LscNodeID] FROM [dbo].[TM_SubSic] SS 
        INNER JOIN [dbo].[TR_RTU] R  ON SS.[SicID] = R.[RtuID]
        WHERE R.[Protocol] = 'F1' OR R.[Protocol] = 'CD' OR R.[Protocol] = 'CD_NEW';

        ;WITH Dev AS
        (
	        SELECT * FROM [dbo].[TM_DEV] D
	        WHERE EXISTS(SELECT 1 FROM @MJ MJ WHERE D.[DevID] = MJ.[DevID])
        )
        SELECT TAAA.[AreaID] AS [Area1ID],TAAA.[AreaName] AS [Area1Name],TAA.[AreaID] AS [Area2ID],TAA.[AreaName] AS [Area2Name],
        TA.[AreaID] AS [Area3ID],TA.[AreaName] AS [Area3Name],TS.[StaID],TS.[StaName],D.[DevID],D.[DevName],D.[Enabled] FROM Dev D
        INNER JOIN [dbo].[TC_DeviceType] TD ON D.[DevTypeID] = TD.[TypeID] AND TD.[TypeName] LIKE '%门禁%'
        INNER JOIN [dbo].[TM_STA] TS ON D.[StaID] = TS.[StaID]
        INNER JOIN [dbo].[TM_AREA] TA ON TS.[AreaID] = TA.[AreaID]
        LEFT OUTER JOIN [dbo].[TM_AREA] TAA ON TA.[LscID] = TAA.[LscID] AND TA.[LastAreaID] = TAA.[AreaID] AND TAA.[NodeLevel] = 2
        LEFT OUTER JOIN [dbo].[TM_AREA] TAAA ON TAA.[LscID] = TAAA.[LscID] AND TAA.[LastAreaID] = TAAA.[AreaID] AND TAAA.[NodeLevel] = 1
        ORDER BY ISNULL(TS.[NetGridID],2000000000),TS.[StaTypeID],TS.[StaName],D.[DevName];
        END
        ELSE 
        BEGIN
        ;WITH RoleDev AS
        (
            SELECT [RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex] FROM [dbo].[Fun_GetNodesInRole](@RoleID) 
            WHERE [RoleId] = @RoleId AND [NodeType] = @DevType
        )
        SELECT TAAA.[AreaID] AS [Area1ID],TAAA.[AreaName] AS [Area1Name],TAA.[AreaID] AS [Area2ID],TAA.[AreaName] AS [Area2Name],
        TA.[AreaID] AS [Area3ID],TA.[AreaName] AS [Area3Name],TS.[StaID],TS.[StaName],D.[DevID],D.[DevName],D.[Enabled] FROM [dbo].[TM_DEV] D
        INNER JOIN RoleDev RD ON D.[DevID] = RD.[NodeId]
        INNER JOIN [dbo].[TC_DeviceType] TD ON D.[DevTypeID] = TD.[TypeID] AND TD.[TypeName] LIKE '%门禁%'
        INNER JOIN [dbo].[TM_STA] TS ON D.[StaID] = TS.[StaID]
        INNER JOIN [dbo].[TM_AREA] TA ON TS.[AreaID] = TA.[AreaID]
        LEFT OUTER JOIN [dbo].[TM_AREA] TAA ON TA.[LscID] = TAA.[LscID] AND TA.[LastAreaID] = TAA.[AreaID] AND TAA.[NodeLevel] = 2
        LEFT OUTER JOIN [dbo].[TM_AREA] TAAA ON TAA.[LscID] = TAAA.[LscID] AND TAA.[LastAreaID] = TAAA.[AreaID] AND TAAA.[NodeLevel] = 1
        ORDER BY ISNULL(TS.[NetGridID],2000000000),TS.[StaTypeID],TS.[StaName],D.[DevName];
        END";

        public const String SQL_MS_GetRoleDepartments = @"
        IF(@RoleId IS NULL)
        BEGIN
            SELECT [ID],[DepId],[DepName],[LastDepId],[Comment],[Enabled] FROM [dbo].[AS_Departments] ORDER BY [DepId];
        END
        ELSE
        BEGIN
            SELECT AD.[ID],AD.[DepId],AD.[DepName],AD.[LastDepId],AD.[Comment],AD.[Enabled] FROM [dbo].[AS_Departments] AD
            INNER JOIN [dbo].[AS_DepartmentsInRoles] ADR ON ADR.[RoleId] = @RoleId AND AD.[DepId] = ADR.[DepId]
            ORDER BY AD.[DepId];
        END";

        public const String SQL_MS_RoleExists = @"
        SELECT COUNT(1) AS Cnt FROM [dbo].[AS_Roles] WHERE [RoleName] = @RoleName;";

        public const String SQL_MS_RoleUserExists = @"
        SELECT COUNT(1) AS [Cnt] FROM [dbo].[AS_UsersInRoles] AUR INNER JOIN [dbo].[AS_Users] AU ON AUR.[RoleId] = @RoleId AND AUR.[UserId] = AU.[UserId];";

        public const String SQL_MS_SaveRoles_Role = @"
        UPDATE [dbo].[AS_Roles] SET [RoleName]=@RoleName,[Comment]=@Comment,[LastRoleId]=@LastRoleId,[Enabled]=@Enabled WHERE [RoleId]=@RoleId;
        IF(@@ROWCOUNT = 0)
        BEGIN
	        INSERT INTO [dbo].[AS_Roles]([RoleId],[RoleName],[Comment],[LastRoleId],[Enabled]) VALUES(@RoleId,@RoleName,@Comment,@LastRoleId,@Enabled);
        END";

        public const String SQL_MS_SaveRoles_ClearXInRoles = @"
        DELETE FROM [dbo].[AS_AuthorizationsInRoles] WHERE [RoleId] = @RoleId;
        DELETE FROM [dbo].[AS_NodesInRoles] WHERE [RoleId] = @RoleId;
        DELETE FROM [dbo].[AS_DepartmentsInRoles] WHERE [RoleId] = @RoleId;";

        public const String SQL_MS_SaveRoles_AddAuthorizationInRoles = @"
        INSERT INTO [dbo].[AS_AuthorizationsInRoles]([RoleId],[AuthId]) VALUES(@RoleId,@AuthId);";

        public const String SQL_MS_SaveRoles_AddNodeInRoles = @"
        INSERT INTO [dbo].[AS_NodesInRoles]([RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex]) VALUES(@RoleId,@NodeId,@NodeType,@LastNodeId,@SortIndex);";

        public const String SQL_MS_SaveRoles_AddDepartmentInRoles = @"
        INSERT INTO [dbo].[AS_DepartmentsInRoles]([RoleId],[DepId]) VALUES(@RoleId,@DepId);";

        public const String SQL_MS_VerifyRoles = @"
        DECLARE @Roles TABLE 
        (
	        [RoleId] [uniqueidentifier] NOT NULL,
	        [RoleName] [nvarchar](50) NOT NULL,
	        [Comment] [nvarchar](1024) NULL,
	        [LastRoleId] [uniqueidentifier] NOT NULL,
	        [Enabled] [bit] NOT NULL,
	        PRIMARY KEY CLUSTERED 
	        (
		        [RoleId] ASC
	        )
        );
	
        ;WITH Roles([RoleId],[RoleName],[Comment],[LastRoleId],[Enabled]) AS
        (
            SELECT [RoleId],[RoleName],[Comment],[LastRoleId],[Enabled] FROM [dbo].[AS_Roles]
            WHERE [LastRoleId] = @RoleId
            UNION ALL
            SELECT AR.[RoleId],AR.[RoleName],AR.[Comment],AR.[LastRoleId],AR.[Enabled]
            FROM [dbo].[AS_Roles] AR INNER JOIN Roles R ON AR.[LastRoleId] = R.[RoleId]
        )
        INSERT INTO @Roles([RoleId],[RoleName],[Comment],[LastRoleId],[Enabled])
        SELECT [RoleId],[RoleName],[Comment],[LastRoleId],[Enabled] FROM Roles;

        ;WITH Auth AS
        (
            SELECT AAR.[RoleId],AAR.[AuthId] FROM [dbo].[AS_AuthorizationsInRoles] AAR 
            INNER JOIN @Roles T ON AAR.[RoleId] = T.[RoleId]
        ),
        RoleAuth AS
        (
            SELECT [RoleId],[AuthId] FROM [dbo].[AS_AuthorizationsInRoles] WHERE [RoleId] = @RoleId
        ),
        DelAuth AS
        (
            SELECT [RoleId],[AuthId] FROM Auth A 
            WHERE (SELECT COUNT(1) AS Num FROM RoleAuth RA WHERE RA.[AuthId] = A.[AuthId]) = 0
        )
        DELETE [dbo].[AS_AuthorizationsInRoles] FROM [dbo].[AS_AuthorizationsInRoles] AAR 
        INNER JOIN DelAuth DA ON AAR.[RoleId] = DA.[RoleId] AND AAR.[AuthId] = DA.[AuthId];

        ;WITH Nodes AS
        (
            SELECT ANR.[RoleId],ANR.[NodeId] FROM [dbo].[AS_NodesInRoles] ANR 
            INNER JOIN @Roles T ON ANR.[RoleId] = T.[RoleId]
        ),
        RoleNodes AS
        (
            SELECT [RoleId],[NodeId] FROM [dbo].[AS_NodesInRoles] WHERE [RoleId] = @RoleId
        ),
        DelNodes AS
        (
            SELECT [RoleId],[NodeId] FROM Nodes N 
            WHERE (SELECT COUNT(1) AS Num FROM RoleNodes RN WHERE RN.[NodeId] = N.[NodeId]) = 0
        )
        DELETE [dbo].[AS_NodesInRoles] FROM [dbo].[AS_NodesInRoles] ANR 
        INNER JOIN DelNodes DN ON ANR.[RoleId] = DN.[RoleId] AND ANR.[NodeId] = DN.[NodeId];

        ;WITH Dept AS
        (
            SELECT ADR.[RoleId],ADR.[DepId] FROM [dbo].[AS_DepartmentsInRoles] ADR 
            INNER JOIN @Roles T ON ADR.[RoleId] = T.[RoleId]
        ),
        RoleDept AS
        (
            SELECT [RoleId],[DepId] FROM [dbo].[AS_DepartmentsInRoles] WHERE [RoleId] = @RoleId
        ),
        DelDept AS
        (
            SELECT [RoleId],[DepId] FROM Dept D 
            WHERE (SELECT COUNT(1) AS Num FROM RoleDept RD WHERE RD.[DepId] = D.[DepId]) = 0
        )
        DELETE [dbo].[AS_DepartmentsInRoles] FROM [dbo].[AS_DepartmentsInRoles] ADR 
        INNER JOIN DelDept DD ON ADR.[RoleId] = DD.[RoleId] AND ADR.[DepId] = DD.[DepId];";

        public const String SQL_MS_DeleteRoles = @"
        DELETE FROM [dbo].[AS_AuthorizationsInRoles] WHERE [RoleId] = @RoleId;
        DELETE FROM [dbo].[AS_NodesInRoles] WHERE [RoleId] = @RoleId;
        DELETE FROM [dbo].[AS_DepartmentsInRoles] WHERE [RoleId] = @RoleId;
        DELETE FROM [dbo].[AS_UsersInRoles] WHERE [RoleId] = @RoleId;
        DELETE FROM [dbo].[AS_Roles] WHERE [RoleId] = @RoleId;";
        
        public const String SQL_MS_GetUserByName = @"
        SELECT AR.[RoleId],AR.[RoleName],AU.[UserId],AU.[UserName],AU.[RemarkName],AU.[Password],AU.[PasswordFormat],
        AU.[PasswordSalt],AU.[MobilePhone],AU.[Email],AU.[CreateDate],AU.[LimitDate],AU.[LastLoginDate],AU.[LastPasswordChangedDate],
        AU.[FailedPasswordAttemptCount],AU.[FailedPasswordDate],AU.[IsLockedOut],AU.[LastLockoutDate],AU.[Comment],AU.[Enabled] FROM [dbo].[AS_Users] AU 
        INNER JOIN [dbo].[AS_UsersInRoles] AUR ON AU.[UserId] = AUR.[UserId]
        INNER JOIN [dbo].[AS_Roles] AR ON AUR.[RoleId] = AR.[RoleId] WHERE AU.[UserName] = @UserName;";

        public const String SQL_MS_GetUserByID = @"
        SELECT AR.[RoleId],AR.[RoleName],AU.[UserId],AU.[UserName],AU.[RemarkName],AU.[Password],AU.[PasswordFormat],
        AU.[PasswordSalt],AU.[MobilePhone],AU.[Email],AU.[CreateDate],AU.[LimitDate],AU.[LastLoginDate],AU.[LastPasswordChangedDate],
        AU.[FailedPasswordAttemptCount],AU.[FailedPasswordDate],AU.[IsLockedOut],AU.[LastLockoutDate],AU.[Comment],AU.[Enabled] FROM [dbo].[AS_Users] AU 
        INNER JOIN [dbo].[AS_UsersInRoles] AUR ON AU.[UserId] = AUR.[UserId]
        INNER JOIN [dbo].[AS_Roles] AR ON AUR.[RoleId] = AR.[RoleId] WHERE AU.[UserId] = @UserId;";

        public const String SQL_MS_GetUsers = @"
        SELECT R.[RoleId],R.[RoleName],AU.[UserId],AU.[UserName],AU.[RemarkName],AU.[Password],AU.[PasswordFormat],AU.[PasswordSalt],
        AU.[MobilePhone],AU.[Email],AU.[CreateDate],AU.[LimitDate],AU.[LastLoginDate],AU.[LastPasswordChangedDate],
        AU.[FailedPasswordAttemptCount],AU.[FailedPasswordDate],AU.[IsLockedOut],AU.[LastLockoutDate],AU.[Comment],AU.[Enabled] FROM [dbo].[AS_Users] AU 
        INNER JOIN [dbo].[AS_UsersInRoles] AUR ON AU.[UserId] = AUR.[UserId]
        INNER JOIN [dbo].[AS_Roles] R ON R.[RoleId] = AUR.[RoleId];";

        public const String SQL_MS_GetUsersByRoleId = @"
        ;WITH Roles([RoleId],[RoleName],[Comment],[LastRoleId],[Enabled]) AS
        (
            SELECT [RoleId],[RoleName],[Comment],[LastRoleId],[Enabled] FROM [dbo].[AS_Roles]
            WHERE [RoleId] = @RoleId
            UNION ALL
            SELECT AR.[RoleId],AR.[RoleName],AR.[Comment],AR.[LastRoleId],AR.[Enabled]
            FROM [dbo].[AS_Roles] AR INNER JOIN Roles R ON AR.[LastRoleId] = R.[RoleId]
        )
        SELECT R.[RoleId],R.[RoleName],AU.[UserId],AU.[UserName],AU.[RemarkName],AU.[Password],AU.[PasswordFormat],AU.[PasswordSalt],
        AU.[MobilePhone],AU.[Email],AU.[CreateDate],AU.[LimitDate],AU.[LastLoginDate],AU.[LastPasswordChangedDate],
        AU.[FailedPasswordAttemptCount],AU.[FailedPasswordDate],AU.[IsLockedOut],AU.[LastLockoutDate],AU.[Comment],AU.[Enabled] FROM [dbo].[AS_Users] AU 
        INNER JOIN [dbo].[AS_UsersInRoles] AUR ON AU.[UserId] = AUR.[UserId]
        INNER JOIN Roles R ON R.[RoleId] = AUR.[RoleId];";

        public const String SQL_MS_UserExists = @"
        SELECT COUNT(1) AS Cnt FROM [dbo].[AS_Users] WHERE [UserName] = @UserName;";

        public const String SQL_MS_CreateUser = @"
        DELETE FROM [dbo].[AS_Users] WHERE [UserId] = @UserId;
        DELETE FROM [dbo].[AS_UsersInRoles] WHERE [UserId] = @UserId;    
        INSERT INTO [dbo].[AS_Users]([UserId],[UserName],[RemarkName],[Password],[PasswordFormat],[PasswordSalt],[MobilePhone],[Email],[CreateDate],[LimitDate],[LastLoginDate],[LastPasswordChangedDate],[FailedPasswordAttemptCount],[FailedPasswordDate],[IsLockedOut],[LastLockoutDate],[Comment],[Enabled])
        VALUES(@UserId,@UserName,@RemarkName,@Password,@PasswordFormat,@PasswordSalt,@MobilePhone,@Email,@CreateDate,@LimitDate,@LastLoginDate,@LastPasswordChangedDate,@FailedPasswordAttemptCount,@FailedPasswordDate,@IsLockedOut,@LastLockoutDate,@Comment,@Enabled);
        INSERT INTO [dbo].[AS_UsersInRoles]([RoleId],[UserId]) VALUES(@RoleId,@UserId);";

        public const String SQL_MS_SaveUser = @"
        UPDATE [dbo].[AS_Users] SET [UserName]=@UserName,[RemarkName]=@RemarkName,[MobilePhone]=@MobilePhone,[Email]=@Email,[LimitDate]=@LimitDate,[Comment]=@Comment,[Enabled]=@Enabled WHERE [UserId] = @UserId;
        DELETE FROM [dbo].[AS_UsersInRoles] WHERE [UserId] = @UserId;
        INSERT INTO [dbo].[AS_UsersInRoles]([RoleId],[UserId]) VALUES(@RoleId,@UserId);";

        public const String SQL_MS_UpdateUser = @"
        UPDATE [dbo].[AS_Users] SET [LastLoginDate]=@LastLoginDate,[FailedPasswordAttemptCount]=@FailedPasswordAttemptCount,FailedPasswordDate=@FailedPasswordDate,[IsLockedOut]=@IsLockedOut,[LastLockoutDate]=@LastLockoutDate WHERE [UserId] = @UserId;";

        public const String SQL_MS_ChangePassword = @"
        UPDATE [dbo].[AS_Users] SET [Password]=@Password,[PasswordFormat]=@PasswordFormat,[PasswordSalt]=@PasswordSalt,[LastPasswordChangedDate]=@LastPasswordChangedDate WHERE [UserId] = @UserId;";

        public const String SQL_MS_DeleteUsers = @"
        DELETE FROM [dbo].[AS_Users] WHERE [UserId] = @UserId;
        DELETE FROM [dbo].[AS_UsersInRoles] WHERE [UserId] = @UserId;";

        public const String SQL_MS_GetClientUsers = @"
        SELECT [ID],[ClientName],[UID],[PWD],[OpLevel],[PortVer],[Enabled] FROM [dbo].[TU_Client] WHERE [UID] = @UID;";

        public const String SQL_MS_VerifySystemData = @"
        DELETE AR FROM [dbo].[AS_AuthorizationsInRoles] AR WHERE NOT EXISTS(SELECT 1 FROM [dbo].[AS_Authorizations] AA WHERE AA.[AuthId] = AR.[AuthId]);
        DELETE CE FROM [dbo].[AS_CardsPerEmployee] CE WHERE NOT EXISTS(SELECT 1 FROM [dbo].[AS_Cards] AC WHERE CE.[CardSn] = AC.[CardSn]);
        DELETE DR FROM [dbo].[AS_DepartmentsInRoles] DR WHERE NOT EXISTS(SELECT 1 FROM [dbo].[AS_Departments] AD WHERE AD.[DepId] = DR.[DepId]);
        DELETE DC FROM [dbo].[AS_DevicesInCards] DC WHERE NOT EXISTS(SELECT 1 FROM [dbo].[TR_RTU] TR WHERE (TR.[Protocol] = 'F1' OR TR.[Protocol] = 'CD' OR TR.[Protocol] = 'CD_NEW') AND DC.[RtuId] = TR.[RtuID]);
        DELETE DC FROM [dbo].[AS_DevicesInCards] DC WHERE NOT EXISTS(SELECT 1 FROM [dbo].[AS_Cards] AC WHERE DC.[CardSn] = AC.[CardSn]);
        DELETE UR FROM [dbo].[AS_UsersInRoles] UR WHERE NOT EXISTS(SELECT 1 FROM [dbo].[AS_Roles] AR WHERE UR.[RoleId] = AR.[RoleId]);
        DELETE UR FROM [dbo].[AS_UsersInRoles] UR WHERE NOT EXISTS(SELECT 1 FROM [dbo].[AS_Users] AU WHERE UR.[UserId] = AU.[UserId]);";

        /// <summary>
        /// Department SQL Text
        /// </summary>
        public const String SQL_DT_GetDepartment = @"
        SELECT [ID],[DepId],[DepName],[Comment],[LastDepId],[Enabled] FROM [dbo].[AS_Departments] WHERE [DepId] = @DepId;";

        public const String SQL_DT_SaveDepartments = @"
        UPDATE [dbo].[AS_Departments] SET [DepName]=@DepName,[Comment]=@Comment,[LastDepId]=@LastDepId,[Enabled]=@Enabled WHERE [DepId] = @DepId;
        IF(@@ROWCOUNT = 0)
        BEGIN
            INSERT INTO [dbo].[AS_Departments]([DepId],[DepName],[Comment],[LastDepId],[Enabled]) VALUES(@DepId, @DepName,@Comment,@LastDepId,@Enabled);
        END";

        public const String SQL_DT_DeleteDepartment = @"
        DELETE FROM [dbo].[AS_Departments] WHERE [DepId] = @DepId;
        DELETE FROM [dbo].[AS_DepartmentsInRoles] WHERE [DepId] = @DepId;";

        public const String SQL_DT_GetMaxDepartmentID = @"
        SELECT MAX([ID]) AS [ID] FROM [dbo].[AS_Departments];";

        public const String SQL_DT_ExistEmployeesInDepartment = @"
        SELECT COUNT(1) AS CNT FROM [dbo].[AS_Departments] D INNER JOIN [dbo].[AS_OrgEmployees] AOE ON D.[DepId] = @DepId AND D.[DepId] = AOE.[DepId];";

        public const String SQL_DT_ExistDepartment = @"
        SELECT COUNT(1) AS CNT FROM [dbo].[AS_Departments] WHERE [DepId] = @DepId;";

        /// <summary>
        /// Employee SQL Text
        /// </summary>
        public const String SQL_EE_GetOrgEmployees = @"
        IF(@RoleId IS NULL)
        BEGIN
	        SELECT AOE.[ID],AOE.[EmpId],AOE.[EmpType],AOE.[EmpName],AOE.[EnglishName],AOE.[Sex],AOE.[CardId],
	        AOE.[Hometown],AOE.[BirthDay],AOE.[Marriage],AOE.[HomeAddress],AOE.[HomePhone],AOE.[EntryDay],
	        AOE.[PositiveDay],AOE.[DepId],D.[DepName],AOE.[DutyName],AOE.[OfficePhone],AOE.[MobilePhone],
	        AOE.[Email],AOE.[Comment],AOE.[Photo],AOE.[PhotoLayout],AOE.[ResignationDate],AOE.[ResignationRemark],
	        AOE.[Enabled] FROM [dbo].[AS_OrgEmployees] AOE 
            LEFT OUTER JOIN [dbo].[AS_Departments] D ON AOE.[DepId] = D.[DepId]
            ORDER BY AOE.[EmpId];
        END
        ELSE 
        BEGIN
	        ;WITH RoleDept AS
	        (
		        SELECT AD.* FROM [dbo].[AS_Departments] AD 
		        INNER JOIN [dbo].[AS_DepartmentsInRoles] ADR ON ADR.[RoleId] = @RoleId AND AD.[DepId] = ADR.[DepId]
	        )
	        SELECT AOE.[ID],AOE.[EmpId],AOE.[EmpType],AOE.[EmpName],AOE.[EnglishName],AOE.[Sex],AOE.[CardId],
	        AOE.[Hometown],AOE.[BirthDay],AOE.[Marriage],AOE.[HomeAddress],AOE.[HomePhone],AOE.[EntryDay],
	        AOE.[PositiveDay],AOE.[DepId],D.[DepName],AOE.[DutyName],AOE.[OfficePhone],AOE.[MobilePhone],
	        AOE.[Email],AOE.[Comment],AOE.[Photo],AOE.[PhotoLayout],AOE.[ResignationDate],AOE.[ResignationRemark],
	        AOE.[Enabled] FROM [dbo].[AS_OrgEmployees] AOE 
            INNER JOIN [RoleDept] D ON AOE.[DepId] = D.[DepId]
            ORDER BY AOE.[EmpId];
        END";

        public const String SQL_EE_GetOrgEmployee = @"
        SELECT AOE.[ID],AOE.[EmpId],AOE.[EmpType],AOE.[EmpName],AOE.[EnglishName],AOE.[Sex],AOE.[CardId],
	    AOE.[Hometown],AOE.[BirthDay],AOE.[Marriage],AOE.[HomeAddress],AOE.[HomePhone],AOE.[EntryDay],
	    AOE.[PositiveDay],AOE.[DepId],D.[DepName],AOE.[DutyName],AOE.[OfficePhone],AOE.[MobilePhone],
	    AOE.[Email],AOE.[Comment],AOE.[Photo],AOE.[PhotoLayout],AOE.[ResignationDate],AOE.[ResignationRemark],
	    AOE.[Enabled] FROM [dbo].[AS_OrgEmployees] AOE LEFT OUTER JOIN [dbo].[AS_Departments] D ON AOE.[DepId] = D.[DepId]
        WHERE AOE.[EmpId] = @EmpId;";

        public const String SQL_EE_GetMaxOrgEmployeeID = @"
        SELECT MAX([ID]) AS [ID] FROM [dbo].[AS_OrgEmployees];";

        public const String SQL_EE_SaveOrgEmployee = @"
        UPDATE [dbo].[AS_OrgEmployees] SET [EmpType] = @EmpType,[EmpName] = @EmpName,[EnglishName] = @EnglishName,[Sex] = @Sex,[CardID] = @CardID,[Hometown] = @Hometown,[BirthDay] = @BirthDay,[Marriage] = @Marriage,[HomeAddress] = @HomeAddress,[HomePhone] = @HomePhone,[EntryDay] = @EntryDay,[PositiveDay] = @PositiveDay,[DepId] = @DepId,[DutyName] = @DutyName,[OfficePhone] = @OfficePhone,[MobilePhone] = @MobilePhone,[Email] = @Email,[Comment] = @Comment,[Photo] = @Photo,[PhotoLayout] = @PhotoLayout,[ResignationDate] = @ResignationDate,[ResignationRemark] = @ResignationRemark,[Enabled] = @Enabled WHERE [EmpId] = @EmpId;
        IF(@@ROWCOUNT = 0)
        BEGIN
	        INSERT INTO [dbo].[AS_OrgEmployees]([EmpId],[EmpType],[EmpName],[EnglishName],[Sex],[CardID],[Hometown],[BirthDay],[Marriage],[HomeAddress],[HomePhone],[EntryDay],[PositiveDay],[DepId],[DutyName],[OfficePhone],[MobilePhone],[Email],[Comment],[Photo],[PhotoLayout],[ResignationDate],[ResignationRemark],[Enabled])
	        VALUES(@EmpId,@EmpType,@EmpName,@EnglishName,@Sex,@CardID,@Hometown,@BirthDay,@Marriage,@HomeAddress,@HomePhone,@EntryDay,@PositiveDay,@DepId,@DutyName,@OfficePhone,@MobilePhone,@Email,@Comment,@Photo,@PhotoLayout,@ResignationDate,@ResignationRemark,@Enabled);
        END";

        public const String SQL_EE_DeleteOrgEmployee = @"
        DECLARE @Cards TABLE([CardSn] [varchar](50) NOT NULL);
        INSERT INTO @Cards([CardSn])
        SELECT [CardSn] FROM [dbo].[AS_CardsPerEmployee] WHERE [EmpId] = @EmpId AND [EmpType] = @EmpType;
        DELETE DC FROM [dbo].[AS_DevicesInCards] DC INNER JOIN @Cards C ON DC.[CardSn] = C.[CardSn];
        DELETE FROM [dbo].[AS_CardsPerEmployee] WHERE [EmpId] = @EmpId AND [EmpType] = @EmpType;
        DELETE AC FROM [dbo].[AS_Cards] AC INNER JOIN @Cards C ON AC.[CardSn] = C.[CardSn];
        DELETE FROM [dbo].[AS_OrgEmployees] WHERE [EmpId] = @EmpId;";

        public const String SQL_EE_ExistOrgEmployee = @"
        SELECT COUNT(1) AS CNT FROM [dbo].[AS_OrgEmployees] WHERE [EmpId] = @EmpId;";

        public const String SQL_EE_ExistOutEmployeesInOrgEmployees = @"
        SELECT COUNT(1) AS CNT FROM [dbo].[AS_OutEmployees] WHERE [ParentEmpId] = @EmpId;";

        public const String SQL_EE_GetOutEmployees = @"
        IF(@RoleId IS NULL)
        BEGIN
            SELECT ATE.[ID],ATE.[EmpId],ATE.[EmpName],ATE.[Sex],ATE.[CardId],ATE.[CardAddress],
            ATE.[CardIssue],ATE.[Hometown],ATE.[CompanyName],ATE.[ProjectName],ATE.[OfficePhone],
            ATE.[MobilePhone],ATE.[Email],ATE.[Comment],AD.[DepId],AD.[DepName],AOE.[EmpId] AS [ParentEmpId],
            AOE.[EmpName] AS [ParentEmpName],ATE.[Photo],ATE.[PhotoLayout],ATE.[Enabled] 
            FROM [dbo].[AS_OutEmployees] ATE 
            LEFT OUTER JOIN [dbo].[AS_OrgEmployees] AOE ON ATE.[ParentEmpId] = AOE.[EmpId]
            LEFT OUTER JOIN [dbo].[AS_Departments] AD ON AOE.[DepId] = AD.[DepId]
            ORDER BY ATE.[EmpId];
        END
        ELSE 
        BEGIN
            ;WITH RoleDept AS
            (
                SELECT AD.* FROM [dbo].[AS_Departments] AD 
                INNER JOIN [dbo].[AS_DepartmentsInRoles] ADR ON ADR.[RoleId] = @RoleId AND AD.[DepId] = ADR.[DepId]
            )
            SELECT ATE.[ID],ATE.[EmpId],ATE.[EmpName],ATE.[Sex],ATE.[CardId],ATE.[CardAddress],
            ATE.[CardIssue],ATE.[Hometown],ATE.[CompanyName],ATE.[ProjectName],ATE.[OfficePhone],
            ATE.[MobilePhone],ATE.[Email],ATE.[Comment],RD.[DepId],RD.[DepName],AOE.[EmpId] AS [ParentEmpId],
            AOE.[EmpName] AS [ParentEmpName],ATE.[Photo],ATE.[PhotoLayout],ATE.[Enabled] 
            FROM [dbo].[AS_OutEmployees] ATE 
            INNER JOIN [dbo].[AS_OrgEmployees] AOE ON ATE.[ParentEmpId] = AOE.[EmpId]
            INNER JOIN [RoleDept] RD ON AOE.[DepId] = RD.[DepId]
            ORDER BY ATE.[EmpId];
        END";

        public const String SQL_EE_GetOutEmployee = @"
        SELECT ATE.[ID],ATE.[EmpId],ATE.[EmpName],ATE.[Sex],ATE.[CardId],ATE.[CardAddress],
        ATE.[CardIssue],ATE.[Hometown],ATE.[CompanyName],ATE.[ProjectName],ATE.[OfficePhone],
        ATE.[MobilePhone],ATE.[Email],ATE.[Comment],AD.[DepId],AD.[DepName],AOE.[EmpId] AS [ParentEmpId],
        AOE.[EmpName] AS [ParentEmpName],ATE.[Photo],ATE.[PhotoLayout],ATE.[Enabled] 
        FROM [dbo].[AS_OutEmployees] ATE 
        LEFT OUTER JOIN [dbo].[AS_OrgEmployees] AOE ON ATE.[ParentEmpId] = AOE.[EmpId]
        LEFT OUTER JOIN [dbo].[AS_Departments] AD ON AOE.[DepId] = AD.[DepId]
        WHERE ATE.[EmpId] = @EmpId;";

        public const String SQL_EE_GetMaxOutEmployeeID = @"
        SELECT MAX([ID]) AS [ID] FROM [dbo].[AS_OutEmployees];";

        public const String SQL_EE_SaveOutEmployee = @"
        UPDATE [dbo].[AS_OutEmployees] SET [EmpName] = @EmpName,[Sex] = @Sex,[CardId] = @CardId,[CardAddress] = @CardAddress,[CardIssue] = @CardIssue,[Hometown] = @Hometown,[CompanyName] = @CompanyName,[ProjectName] = @ProjectName,[OfficePhone] = @OfficePhone,[MobilePhone] = @MobilePhone,[Email] = @Email,[Comment] = @Comment,[ParentEmpId] = @ParentEmpId,[Photo] = @Photo,[PhotoLayout] = @PhotoLayout,[Enabled] = @Enabled WHERE [EmpId] = @EmpId;
        IF(@@ROWCOUNT = 0)
        BEGIN
	        INSERT INTO [dbo].[AS_OutEmployees]([EmpId],[EmpName],[Sex],[CardId],[CardAddress],[CardIssue],[Hometown],[CompanyName],[ProjectName],[OfficePhone],[MobilePhone],[Email],[Comment],[ParentEmpId],[Photo],[PhotoLayout],[Enabled])
	        VALUES(@EmpId,@EmpName,@Sex,@CardId,@CardAddress,@CardIssue,@Hometown,@CompanyName,@ProjectName,@OfficePhone,@MobilePhone,@Email,@Comment,@ParentEmpId,@Photo,@PhotoLayout,@Enabled);
        END";

        public const String SQL_EE_DeleteOutEmployee = @"
        DECLARE @Cards TABLE([CardSn] [varchar](50) NOT NULL);
        INSERT INTO @Cards([CardSn])
        SELECT [CardSn] FROM [dbo].[AS_CardsPerEmployee] WHERE [EmpId] = @EmpId AND [EmpType] = @EmpType;
        DELETE DC FROM [dbo].[AS_DevicesInCards] DC INNER JOIN @Cards C ON DC.[CardSn] = C.[CardSn];
        DELETE FROM [dbo].[AS_CardsPerEmployee] WHERE [EmpId] = @EmpId AND [EmpType] = @EmpType;
        DELETE AC FROM [dbo].[AS_Cards] AC INNER JOIN @Cards C ON AC.[CardSn] = C.[CardSn];
        DELETE FROM [dbo].[AS_OutEmployees] WHERE [EmpId] = @EmpId;";

        public const String SQL_EE_ExistOutEmployee = @"
        SELECT COUNT(1) AS CNT FROM [dbo].[AS_OutEmployees] WHERE [EmpId] = @EmpId;";

        public const String SQL_EE_ImportOrgEmployees = @"
        DELETE FROM [dbo].[AS_OrgEmployees] WHERE [EmpId] = @EmpId;
        INSERT INTO [dbo].[AS_OrgEmployees]([EmpId],[EmpType],[EmpName],[Sex],[CardId],[BirthDay],[EntryDay],[PositiveDay],[DepId],[MobilePhone],[Email],[Comment],[PhotoLayout],[Enabled])
        VALUES(@EmpId,@EmpType,@EmpName,@Sex,@CardId,'1985-01-01',GETDATE(),DATEADD(MM,3,GETDATE()),@DepId,@MobilePhone,@Email,N'批量导入',4,1);

        IF(@CardSn IS NOT NULL)
        BEGIN
	        DELETE FROM [dbo].[AS_Cards] WHERE [CardSn] = @CardSn;
	        INSERT INTO [dbo].[AS_Cards]([CardSn],[CardType],[UID],[Pwd],[BeginTime],[BeginReason],[Comment],[Enabled])
	        VALUES(@CardSn,@CardType,'00000000','0000',GETDATE(),N'员工入职',N'批量导入',1);
	
	        DELETE FROM [dbo].[AS_CardsPerEmployee] WHERE [EmpId] = @EmpId AND [EmpType] = @EmpType AND [CardSn] = @CardSn;
	        INSERT INTO [dbo].[AS_CardsPerEmployee]([EmpId],[EmpType],[CardSn]) VALUES(@EmpId,@EmpType,@CardSn);
        END";

        public const String SQL_EE_ExportOrgEmployees = @"
        IF(@RoleId IS NULL)
        BEGIN
            SELECT D.[DepId],D.[DepName],AOE.[EmpId],AOE.[EmpName],AOE.[CardId],AOE.[MobilePhone],AOE.[Email],CPE.[CardSn] FROM [dbo].[AS_OrgEmployees] AOE 
            INNER JOIN [dbo].[AS_Departments] D ON AOE.[DepId] = D.[DepId]
            LEFT OUTER JOIN [dbo].[AS_CardsPerEmployee] CPE ON AOE.[EmpId] = CPE.[EmpId] AND AOE.[EmpType] = CPE.[EmpType]
            ORDER BY AOE.[EmpId];
        END
        ELSE 
        BEGIN
            ;WITH RoleDept AS
            (
                SELECT AD.* FROM [dbo].[AS_Departments] AD 
                INNER JOIN [dbo].[AS_DepartmentsInRoles] ADR ON ADR.[RoleId] = @RoleId AND AD.[DepId] = ADR.[DepId]
            )
            SELECT D.[DepId],D.[DepName],AOE.[EmpId],AOE.[EmpName],AOE.[CardId],AOE.[MobilePhone],AOE.[Email],CPE.[CardSn] FROM [dbo].[AS_OrgEmployees] AOE 
            INNER JOIN [RoleDept] D ON AOE.[DepId] = D.[DepId]
            LEFT OUTER JOIN [dbo].[AS_CardsPerEmployee] CPE ON AOE.[EmpId] = CPE.[EmpId] AND AOE.[EmpType] = CPE.[EmpType]
            ORDER BY AOE.[EmpId];
        END";

        public const String SQL_EE_ImportOutEmployees = @"
        DELETE FROM [dbo].[AS_OutEmployees] WHERE [EmpId] = @EmpId;
        INSERT INTO [dbo].[AS_OutEmployees]([EmpId],[EmpName],[Sex],[CardId],[MobilePhone],[Email],[Comment],[ParentEmpId],[PhotoLayout],[Enabled])
        VALUES(@EmpId,@EmpName,@Sex,@CardId,@MobilePhone,@Email,N'批量导入',@ParentEmpId,4,1);

        IF(@CardSn IS NOT NULL)
        BEGIN
	        DELETE FROM [dbo].[AS_Cards] WHERE [CardSn] = @CardSn;
	        INSERT INTO [dbo].[AS_Cards]([CardSn],[CardType],[UID],[Pwd],[BeginTime],[BeginReason],[Comment],[Enabled])
	        VALUES(@CardSn,@CardType,'00000000','0000',GETDATE(),N'员工入职',N'批量导入',1);
	
	        DELETE FROM [dbo].[AS_CardsPerEmployee] WHERE [EmpId] = @EmpId AND [EmpType] = @EmpType AND [CardSn] = @CardSn;
	        INSERT INTO [dbo].[AS_CardsPerEmployee]([EmpId],[EmpType],[CardSn]) VALUES(@EmpId,@EmpType,@CardSn);
        END";

        public const String SQL_EE_ExportOutEmployees = @"
        IF(@RoleId IS NULL)
        BEGIN
            SELECT AD.[DepId],AD.[DepName],AOE.[EmpId] AS [ParentEmpId],AOE.[EmpName] AS [ParentEmpName],ATE.[EmpId],ATE.[EmpName],ATE.[CardId],ATE.[MobilePhone],ATE.[Email],CPE.[CardSn]
            FROM [dbo].[AS_OutEmployees] ATE 
            INNER JOIN [dbo].[AS_OrgEmployees] AOE ON ATE.[ParentEmpId] = AOE.[EmpId]
            INNER JOIN [dbo].[AS_Departments] AD ON AOE.[DepId] = AD.[DepId]
            LEFT OUTER JOIN [dbo].[AS_CardsPerEmployee] CPE ON ATE.[EmpId] = CPE.[EmpId] AND CPE.[EmpType] = @EmpType
            ORDER BY ATE.[EmpId];
        END
        ELSE 
        BEGIN
            ;WITH RoleDept AS
            (
                SELECT AD.* FROM [dbo].[AS_Departments] AD 
                INNER JOIN [dbo].[AS_DepartmentsInRoles] ADR ON ADR.[RoleId] = @RoleId AND AD.[DepId] = ADR.[DepId]
            )
            SELECT AD.[DepId],AD.[DepName],AOE.[EmpId] AS [ParentEmpId],AOE.[EmpName] AS [ParentEmpName],ATE.[EmpId],ATE.[EmpName],ATE.[CardId],ATE.[MobilePhone],ATE.[Email],CPE.[CardSn]
            FROM [dbo].[AS_OutEmployees] ATE 
            INNER JOIN [dbo].[AS_OrgEmployees] AOE ON ATE.[ParentEmpId] = AOE.[EmpId]
            INNER JOIN [RoleDept] AD ON AOE.[DepId] = AD.[DepId]
            LEFT OUTER JOIN [dbo].[AS_CardsPerEmployee] CPE ON ATE.[EmpId] = CPE.[EmpId] AND CPE.[EmpType] = @EmpType
            ORDER BY ATE.[EmpId];
        END";

        /// <summary>
        /// Log SQL Text
        /// </summary>
        public const String SQL_LG_WriteLog = @"
        INSERT INTO [dbo].[AS_Events]([EventId],[EventTime],[EventType],[Operator],[Source],[Message],[StackTrace])
        VALUES(@EventId,@EventTime,@EventType,@Operator,@Source,@Message,@StackTrace);";

        public const String SQL_LG_ClearLog = @"
        IF(@EventType IS NULL)
        BEGIN
            DELETE FROM [dbo].[AS_Events] WHERE [EventTime] BETWEEN @BeginDate AND @EndDate; 
        END
        ELSE
        BEGIN
            DELETE FROM [dbo].[AS_Events] WHERE [EventTime] BETWEEN @BeginDate AND @EndDate AND [EventType] = @EventType;
        END";

        public const String SQL_LG_GetLogs = @"
        IF(@EventType IS NULL)
        BEGIN
            SELECT [EventId],[EventTime],[EventType],[Operator],[Source],[Message],[StackTrace] FROM [dbo].[AS_Events] WHERE [EventTime] BETWEEN @BeginDate AND @EndDate; 
        END
        ELSE
        BEGIN
            SELECT [EventId],[EventTime],[EventType],[Operator],[Source],[Message],[StackTrace] FROM [dbo].[AS_Events] WHERE [EventTime] BETWEEN @BeginDate AND @EndDate AND [EventType] = @EventType;
        END";

        /// <summary>
        /// Card SQL Text
        /// </summary>
        public const String SQL_CD_GetOrgCards = @"
        IF(@RoleId IS NULL)
        BEGIN
            SELECT AOE.[EmpId],AE.[EmpType],AOE.[EmpName],AD.[DepId],AD.[DepName],AC.[CardSn],AC.[CardType],AC.[UID],AC.[Pwd],AC.[BeginTime],AC.[BeginReason],AC.[Comment],AC.[Enabled]
	        FROM [dbo].[AS_Cards] AC 
	        INNER JOIN [dbo].[AS_CardsPerEmployee] AE ON AC.[CardSn] = AE.[CardSn] 
	        INNER JOIN [dbo].[AS_OrgEmployees] AOE ON AE.[EmpId] = AOE.[EmpId]
            LEFT OUTER JOIN [dbo].[AS_Departments] AD ON AOE.[DepId] =  AD.[DepId]
	        WHERE AE.[EmpType] <> @EmpType ORDER BY AC.[CardSn];
        END
        ELSE 
        BEGIN
            ;WITH RoleDept AS
            (
                SELECT AD.* FROM [dbo].[AS_Departments] AD 
                INNER JOIN [dbo].[AS_DepartmentsInRoles] ADR ON ADR.[RoleId] = @RoleId AND AD.[DepId] = ADR.[DepId]
            )
            SELECT AOE.[EmpId],AE.[EmpType],AOE.[EmpName],RD.[DepId],RD.[DepName],AC.[CardSn],AC.[CardType],AC.[UID],AC.[Pwd],AC.[BeginTime],AC.[BeginReason],AC.[Comment],AC.[Enabled]
	        FROM [dbo].[AS_Cards] AC 
	        INNER JOIN [dbo].[AS_CardsPerEmployee] AE ON AC.[CardSn] = AE.[CardSn] 
	        INNER JOIN [dbo].[AS_OrgEmployees] AOE ON AE.[EmpId] = AOE.[EmpId]
	        INNER JOIN [RoleDept] RD ON AOE.[DepId] = RD.[DepId]
	        WHERE AE.[EmpType] <> @EmpType ORDER BY AC.[CardSn];
        END";

        public const String SQL_CD_GetOutCards = @"
        IF(@RoleId IS NULL)
        BEGIN
            SELECT AOE.[EmpId],AE.[EmpType],AOE.[EmpName],AD.[DepId],AD.[DepName],AC.[CardSn],AC.[CardType],AC.[UID],AC.[Pwd],AC.[BeginTime],AC.[BeginReason],AC.[Comment],AC.[Enabled]
            FROM [dbo].[AS_Cards] AC 
            INNER JOIN [dbo].[AS_CardsPerEmployee] AE ON AC.[CardSn] = AE.[CardSn] 
            INNER JOIN [dbo].[AS_OutEmployees] AOE ON AE.[EmpId] = AOE.[EmpId]
            LEFT OUTER JOIN [dbo].[AS_OrgEmployees] AEE ON AOE.[ParentEmpId] = AEE.[EmpId]
            LEFT OUTER JOIN [dbo].[AS_Departments] AD ON AEE.[DepId] =  AD.[DepId]
            WHERE AE.[EmpType] = @EmpType ORDER BY AC.[CardSn];
        END
        ELSE 
        BEGIN
            ;WITH RoleDept AS
            (
                SELECT AD.* FROM [dbo].[AS_Departments] AD 
                INNER JOIN [dbo].[AS_DepartmentsInRoles] ADR ON ADR.[RoleId] = @RoleId AND AD.[DepId] = ADR.[DepId]
            )
            SELECT AOE.[EmpId],AE.[EmpType],AOE.[EmpName],RD.[DepId],RD.[DepName],AC.[CardSn],AC.[CardType],AC.[UID],AC.[Pwd],AC.[BeginTime],AC.[BeginReason],AC.[Comment],AC.[Enabled]
            FROM [dbo].[AS_Cards] AC 
            INNER JOIN [dbo].[AS_CardsPerEmployee] AE ON AC.[CardSn] = AE.[CardSn] 
            INNER JOIN [dbo].[AS_OutEmployees] AOE ON AE.[EmpId] = AOE.[EmpId]
            INNER JOIN [dbo].[AS_OrgEmployees] AEE ON AOE.[ParentEmpId] = AEE.[EmpId]
            INNER JOIN [RoleDept] RD ON AEE.[DepId] = RD.[DepId]
            WHERE AE.[EmpType] = @EmpType ORDER BY AC.[CardSn];
        END";

        public const String SQL_CD_ExistCard = @"
        SELECT COUNT(1) AS CNT FROM [dbo].[AS_Cards] WHERE [CardSn] = @CardSn;";

        public const String SQL_CD_DeleteCard = @"
        DELETE FROM [dbo].[AS_DevicesInCards] WHERE [CardSn] = @CardSn;
        DELETE FROM [dbo].[AS_CardsPerEmployee] WHERE [CardSn] = @CardSn;
        DELETE FROM [dbo].[AS_Cards] WHERE [CardSn] = @CardSn;";

        public const String SQL_CD_SaveCard = @"
        UPDATE [dbo].[AS_Cards] SET [CardType] = @CardType,[UID] = @UID,[Pwd] = @Pwd,[BeginTime] = @BeginTime,[BeginReason] = @BeginReason,[Comment] = @Comment,[Enabled] = @Enabled WHERE [CardSn] = @CardSn;
        IF(@@ROWCOUNT = 0)
        BEGIN
            INSERT INTO [dbo].[AS_Cards]([CardSn],[CardType],[UID],[Pwd],[BeginTime],[BeginReason],[Comment],[Enabled]) VALUES(@CardSn,@CardType,@UID,@Pwd,@BeginTime,@BeginReason,@Comment,@Enabled);
            INSERT INTO [dbo].[AS_CardsPerEmployee]([EmpId],[EmpType],[CardSn]) VALUES(@EmpId,@EmpType,@CardSn);
        END
        ELSE
        BEGIN
            UPDATE [dbo].[AS_CardsPerEmployee] SET [EmpId] = @EmpId,[EmpType] = @EmpType WHERE [CardSn] = @CardSn;
        END";

        public const String SQL_CD_GetLastCardRecords = @"
        DECLARE @CntFromTime DATETIME,@CntToTime DATETIME,@tpDate DATETIME,@tbName NVARCHAR(255),@tableCnt INT = 0,@SQL NVARCHAR(MAX) = N'';
        SET @CntFromTime = ISNULL(@BeginTime,DATEADD(MM,-1,GETDATE()));
        SET @CntToTime = ISNULL(@EndTime,GETDATE());
        SET @tpDate = @CntFromTime;
        WHILE(DATEDIFF(MM,@tpDate,ISNULL(@CntToTime,GETDATE()))>=0)
        BEGIN
            SET @tbName = N'[dbo].[TH_DoorPunch' + CONVERT(VARCHAR(6),@tpDate,112) + ']';
            IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(@tbName) AND type in (N'U'))
            BEGIN
                IF(@tableCnt>0)
                BEGIN
                    SET @SQL += N' 
                    UNION ALL 
                    ';
                END
	
                SET @SQL += N'SELECT * FROM ' + @tbName + N' WHERE [PunchTime] BETWEEN ''' + CONVERT(NVARCHAR,@CntFromTime,120) + N''' AND ''' + CONVERT(NVARCHAR,@CntToTime,120) + N''' AND ([Remark] = N''远程(由SU)开门记录'' OR [Remark] = N''键入用户ID及个人密码开门的记录'' OR [Remark] = N''报警记录:非正常开门'' OR [Remark] = N''刷卡开门记录'' OR [Remark] = N''手动开门记录'' OR [Remark] = N''正常开门（刷卡）'' OR [Remark] = N''非法开门'' OR ([Remark] = N''按钮开门'' AND [Status] = N''门开''))';
                SET @tableCnt += 1;
            END
            SET @tpDate = DATEADD(MM,1,@tpDate);
        END

        IF(@tableCnt>0)
        BEGIN
            SET @SQL = N'
            ;WITH DP AS
            (
                ' + @SQL + N'
            ),
            RN AS
            (
               SELECT ROW_NUMBER() OVER (PARTITION BY [DevID] ORDER BY [PunchTime] DESC) AS [RowNumber],* FROM DP
            )
            SELECT [ID],[DevID],[PunchTime],[PunchNO],[Status],[Remark],[Direction],[GrantPunch] FROM RN WHERE [RowNumber] = 1;';
            EXECUTE sp_executesql @SQL;
        END";

        public const String SQL_CD_GetHisCardRecords = @"
        DECLARE @CntFromTime DATETIME,@CntToTime DATETIME,@tpDate DATETIME,@tbName NVARCHAR(255),@tableCnt INT = 0,@SQL NVARCHAR(MAX) = N'';
        SET @CntFromTime = ISNULL(@BeginTime,DATEADD(MM,-1,GETDATE()));
        SET @CntToTime = ISNULL(@EndTime,GETDATE());
        SET @tpDate = @CntFromTime;
        WHILE(DATEDIFF(MM,@tpDate,ISNULL(@CntToTime,GETDATE()))>=0)
        BEGIN
            SET @tbName = N'[dbo].[TH_DoorPunch' + CONVERT(VARCHAR(6),@tpDate,112) + ']';
            IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(@tbName) AND type in (N'U'))
            BEGIN
                IF(@tableCnt>0)
                BEGIN
                    SET @SQL += N' 
                    UNION ALL 
                    ';
                END

                SET @SQL += N'SELECT * FROM ' + @tbName + N' WHERE [PunchTime] BETWEEN ''' + CONVERT(NVARCHAR,@CntFromTime,120) + N''' AND ''' + CONVERT(NVARCHAR,@CntToTime,120) + N'''';
                SET @tableCnt += 1;
            END
            SET @tpDate = DATEADD(MM,1,@tpDate);
        END

        IF(@tableCnt>0)
        BEGIN
            SET @SQL = N'
            ;WITH DP AS
            (
                ' + @SQL + N'
            )
            SELECT [ID],[DevID],[PunchTime],[PunchNO],[Status],[Remark],[Direction],[GrantPunch] FROM DP;';
            EXECUTE sp_executesql @SQL;
        END";

        /// <summary>
        /// Card Auth SQL Text
        /// </summary>
        public const String SQL_CA_GetDevCardAuth = @"
        SELECT DC.[CardSn],DC.[RtuId],@DevId AS [DevId],DC.[LimitId],DC.[LimitIndex],DC.[BeginTime],DC.[EndTime],DC.[Password],DC.[Enabled]
        FROM [dbo].[AS_DevicesInCards] DC INNER JOIN [dbo].[TM_SubSic] SS ON SS.[LscNodeID] = @DevId AND DC.[RtuId] = SS.[SicID];";

        public const String SQL_CA_GetCardAuthByEmpId = @"
        SELECT DC.[CardSn],DC.[RtuId],SS.[LscNodeID] AS [DevId],DC.[LimitId],DC.[LimitIndex],DC.[BeginTime],DC.[EndTime],DC.[Password],DC.[Enabled]
        FROM [dbo].[AS_DevicesInCards] DC 
        INNER JOIN [dbo].[TM_SubSic] SS ON DC.[RtuId] = SS.[SicID]
        INNER JOIN [dbo].[AS_CardsPerEmployee] CPE ON CPE.[EmpId] = @EmpId AND CPE.[EmpType] = @EmpType AND DC.[CardSn] = CPE.[CardSn];";

        public const String SQL_CA_GetCardAuthByCondition = @"
        IF(@WorkType <> @WXRY)
        BEGIN
	        IF(@QType=0)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OrgEmployees] AOE
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE AOE.[EmpId] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=1)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OrgEmployees] AOE
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE AOE.[EmpName] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=2)
	        BEGIN
		        ;WITH Cards AS
		        (
			        SELECT C.[CardSn] FROM [dbo].[AS_Cards] C
			        INNER JOIN [dbo].[AS_CardsPerEmployee] AC ON C.[CardSn] = AC.[CardSn] AND AC.[EmpType] <> @WXRY
			        WHERE RIGHT(REPLICATE('0', 10) + CONVERT(VARCHAR(10), CONVERT(BIGINT, CONVERT(VARBINARY(5), C.[CardSn], 2))), 10) LIKE '%'+@Filter+'%'
		        )
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_DevicesInCards] ADC 
		        INNER JOIN [Cards] C ON ADC.[CardSn] = C.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID];
	        END
	        ELSE IF(@QType=3)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OrgEmployees] AOE
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE AOE.[DepId] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=4)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OrgEmployees] AOE
		        INNER JOIN [dbo].[AS_Departments] AD ON AOE.[DepId] = AD.[DepId]
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE AD.[DepName] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=5)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_DevicesInCards] ADC 
		        INNER JOIN [dbo].[AS_CardsPerEmployee] AC ON ADC.[CardSn] = AC.[CardSn] AND AC.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE SS.[LscNodeID] LIKE '%'+@Filter+'%';
	        END
        END
        ELSE
        BEGIN
	        IF(@QType=0)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OutEmployees] AOE
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE AOE.[EmpId] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=1)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OutEmployees] AOE
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE AOE.[EmpName] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=2)
	        BEGIN
		        ;WITH Cards AS
		        (
			        SELECT C.[CardSn] FROM [dbo].[AS_Cards] C
			        INNER JOIN [dbo].[AS_CardsPerEmployee] AC ON C.[CardSn] = AC.[CardSn] AND AC.[EmpType] = @WXRY
			        WHERE RIGHT(REPLICATE('0', 10) + CONVERT(VARCHAR(10), CONVERT(BIGINT, CONVERT(VARBINARY(5), C.[CardSn], 2))), 10) LIKE '%'+@Filter+'%'
		        )
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_DevicesInCards] ADC 
		        INNER JOIN [Cards] C ON ADC.[CardSn] = C.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID];
	        END
	        ELSE IF(@QType=3)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OutEmployees] AOE
		        INNER JOIN [AS_OrgEmployees] ORE ON AOE.[ParentEmpId] = ORE.[EmpId]
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE ORE.[DepId] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=4)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OutEmployees] AOE
		        INNER JOIN [AS_OrgEmployees] ORE ON AOE.[ParentEmpId] = ORE.[EmpId]
		        INNER JOIN [dbo].[AS_Departments] AD ON ORE.[DepId] = AD.[DepId]
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE AD.[DepName] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=5)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_DevicesInCards] ADC 
		        INNER JOIN [dbo].[AS_CardsPerEmployee] AC ON ADC.[CardSn] = AC.[CardSn] AND AC.[EmpType] = @WXRY
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE SS.[LscNodeID] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=6)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OutEmployees] AOE
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE AOE.[ParentEmpId] LIKE '%'+@Filter+'%';
	        END
	        ELSE IF(@QType=7)
	        BEGIN
		        SELECT ADC.[CardSn],ADC.[RtuId],SS.[LscNodeID] AS [DevId],ADC.[LimitId],ADC.[LimitIndex],ADC.[BeginTime],ADC.[EndTime],ADC.[Password],ADC.[Enabled] 
		        FROM [dbo].[AS_OutEmployees] AOE
		        INNER JOIN [AS_OrgEmployees] ORE ON AOE.[ParentEmpId] = ORE.[EmpId]
		        INNER JOIN [dbo].[AS_CardsPerEmployee] APE ON AOE.[EmpId] = APE.[EmpId] AND APE.[EmpType] <> @WXRY
		        INNER JOIN [dbo].[AS_DevicesInCards] ADC ON APE.[CardSn] = ADC.[CardSn]
		        INNER JOIN [dbo].[TM_SubSic] SS ON ADC.[RtuId] = SS.[SicID]
		        WHERE ORE.[EmpName] LIKE '%'+@Filter+'%';
	        END
        END";

        public const String SQL_CA_GetCardAuthByCardSn = @"
        SELECT DC.[CardSn],DC.[RtuId],@DevId AS [DevId],DC.[LimitId],DC.[LimitIndex],DC.[BeginTime],DC.[EndTime],DC.[Password],DC.[Enabled]
        FROM [dbo].[AS_DevicesInCards] DC INNER JOIN [dbo].[TM_SubSic] SS ON DC.[CardSn] = @CardSn AND SS.[LscNodeID] = @DevId AND DC.[RtuId] = SS.[SicID];";

        public const String SQL_CA_DeleteCardAuth = @"
        DELETE [dbo].[AS_DevicesInCards] FROM [dbo].[AS_DevicesInCards] DIC INNER JOIN [dbo].[TM_SubSic] SS ON DIC.[CardSn] = @CardSn AND SS.[LscNodeID] = @DevId AND DIC.[RtuId] = SS.[SicID];";

        public const String SQL_CA_SaveCardAuth = @"
        DECLARE @RtuId INT = NULL;
        SELECT @RtuId = [SicID] FROM [dbo].[TM_SubSic] WHERE [LscNodeID] = @DevId;
        IF(@RtuId IS NOT NULL)
        BEGIN
	        UPDATE [dbo].[AS_DevicesInCards] SET [LimitId] = @LimitId,[LimitIndex] = @LimitIndex,[BeginTime] = @BeginTime,[EndTime] = @EndTime,[Password] = @Password,[Enabled] = @Enabled WHERE [CardSn] = @CardSn AND [RtuId] = @RtuId;
	        IF(@@ROWCOUNT=0)
	        BEGIN
		        INSERT INTO [dbo].[AS_DevicesInCards]([CardSn],[RtuId],[LimitId],[LimitIndex],[BeginTime],[EndTime],[Password],[Enabled])
		        VALUES(@CardSn,@RtuId,@LimitId,@LimitIndex,@BeginTime,@EndTime,@Password,@Enabled);
	        END
        END";

        public const String SQL_CA_BitchUpdateCardAuth = @"
        UPDATE [dbo].[AS_DevicesInCards] SET [LimitId] = @LimitId,[LimitIndex] = @LimitIndex,[BeginTime] = @BeginTime,[EndTime] = @EndTime,[Password] = @Password,[Enabled] = @Enabled WHERE [CardSn] = @CardSn AND [RtuId] = @RtuId;";

        public const String SQL_CA_SyncCardAuth = @"
        UPDATE [dbo].[AS_DevicesInCards] SET [LimitId] = @LimitId,[LimitIndex] = @LimitIndex,[BeginTime] = @BeginTime,[EndTime] = @EndTime,[Password] = @Password,[Enabled] = @Enabled WHERE [CardSn] = @CardSn;";

        public const String SQL_CA_DeleteAuthByDev = @"
        DELETE [dbo].[AS_DevicesInCards] FROM [dbo].[AS_DevicesInCards] DIC INNER JOIN [dbo].[TM_SubSic] SS ON SS.[LscNodeID] = @TargetDevId AND DIC.[RtuId] = SS.[SicID];";

        public const String SQL_CA_CopyAuthByDev = @"
        ;WITH SourceT AS
        (
	        SELECT DC.[CardSn],@TargetDevId AS [DevId],DC.[LimitId],DC.[LimitIndex],DC.[BeginTime],DC.[EndTime],DC.[Password],DC.[Enabled] FROM [dbo].[AS_DevicesInCards] DC 
	        INNER JOIN [dbo].[TM_SubSic] SS ON SS.[LscNodeID] = @SourceDevId AND DC.[RtuId] = SS.[SicID]
        ),
        TargetT AS
        (
	        SELECT ST.[CardSn],SS.[SicID] AS [RtuId],ST.[LimitId],ST.[LimitIndex],ST.[BeginTime],ST.[EndTime],ST.[Password],ST.[Enabled] FROM SourceT ST 
	        INNER JOIN [dbo].[TM_SubSic] SS ON SS.[LscNodeID] = ST.[DevId]
        )
        INSERT INTO [dbo].[AS_DevicesInCards]([CardSn],[RtuId],[LimitId],[LimitIndex],[BeginTime],[EndTime],[Password],[Enabled])
        SELECT [CardSn],[RtuId],[LimitId],[LimitIndex],[BeginTime],[EndTime],[Password],[Enabled] FROM TargetT TT 
        WHERE NOT EXISTS(SELECT 1 FROM [dbo].[AS_DevicesInCards] DC WHERE DC.[CardSn] = TT.[CardSn] AND DC.[RtuId] = TT.[RtuId]);";

        public const String SQL_CA_DeleteAuthByCard = @"
        DELETE FROM [dbo].[AS_DevicesInCards] WHERE [CardSn] = @TargetCardSn;";

        public const String SQL_CA_CopyAuthByCard = @"
        ;WITH SourceT AS
        (
	        SELECT @TargetCardSn AS [CardSn],[RtuId],[LimitId],[LimitIndex],[BeginTime],[EndTime],[Password],[Enabled] FROM [dbo].[AS_DevicesInCards] WHERE [CardSn] = @SourceCardSn
        )
        INSERT INTO [dbo].[AS_DevicesInCards]([CardSn],[RtuId],[LimitId],[LimitIndex],[BeginTime],[EndTime],[Password],[Enabled])
        SELECT [CardSn],[RtuId],[LimitId],[LimitIndex],[BeginTime],[EndTime],[Password],[Enabled] FROM SourceT ST 
        WHERE NOT EXISTS(SELECT 1 FROM [dbo].[AS_DevicesInCards] DC WHERE DC.[CardSn] = ST.[CardSn] AND DC.[RtuId] = ST.[RtuId]);";

        public const String SQL_CA_GetDevAuthCount = @"
        ;WITH CntTemp AS
        (
	        SELECT [RtuId],COUNT(1) AS [Count] FROM [dbo].[AS_DevicesInCards] GROUP BY [RtuId]
        )
        SELECT SS.[LscNodeID] AS [DevId],CT.[Count] FROM CntTemp CT
        INNER JOIN [dbo].[TM_SubSic] SS ON CT.[RtuId] = SS.[SicID];";

        public const String SQL_CA_GetCardAuthCount = @"
        SELECT [CardSn],COUNT(1) AS [Count] FROM [dbo].[AS_DevicesInCards] DC 
        INNER JOIN [dbo].[TM_SubSic] SS ON DC.[RtuId] = SS.[SicID]
        GROUP BY [CardSn];";

        public const String SQL_CA_GetCardAuthCards = @"
        SELECT [CardSn] FROM [dbo].[AS_DevicesInCards] DC 
        INNER JOIN [dbo].[TM_SubSic] SS ON SS.[LscNodeID] = @DevId AND DC.[RtuId] = SS.[SicID];";

        public const String SQL_CA_GetCardAuthDevs = @"
        SELECT [LscNodeID] AS [DevId] FROM [dbo].[AS_DevicesInCards] DC 
        INNER JOIN [dbo].[TM_SubSic] SS ON DC.[CardSn]=@CardSn AND DC.[RtuId] = SS.[SicID];";

        /// <summary>
        /// Limit Time SQL Text
        /// </summary>
        public const String SQL_LT_GetLimitTimes = @"
        SELECT [ID],[LscNodeID] AS [DevID],[LimitID],[LimitDesc],[LimitIndex],[WeekIndex],[StartTime1],[EndTime1],[StartTime2],[EndTime2],
        [StartTime3],[EndTime3],[StartTime4],[EndTime4],[StartTime5],[EndTime5],[StartTime6],[EndTime6] FROM [dbo].[AS_LimitParameters] LP 
        INNER JOIN [dbo].[TM_SubSic] SS ON SS.[LscNodeID] = @DevId AND LP.[RtuID] = SS.[SicID];";

        public const String SQL_LT_DeleteLimitTimes = @"
        DELETE [dbo].[AS_LimitParameters] FROM [dbo].[AS_LimitParameters] LP 
        INNER JOIN [dbo].[TM_SubSic] SS ON SS.[LscNodeID] = @DevId AND LP.[LimitID] = @LimitId AND LP.[RtuID] = SS.[SicID];";

        public const String SQL_LT_SaveLimitTimes = @"
        INSERT INTO [dbo].[AS_LimitParameters]([RtuID],[LimitID],[LimitDesc],[LimitIndex],[WeekIndex],[StartTime1],[EndTime1],[StartTime2],[EndTime2],[StartTime3],[EndTime3],[StartTime4],[EndTime4],[StartTime5],[EndTime5],[StartTime6],[EndTime6])
        SELECT [SicID] AS [RtuID],@LimitId,@LimitDesc,@LimitIndex,@WeekIndex,@StartTime1,@EndTime1,@StartTime2,@EndTime2,@StartTime3,@EndTime3,@StartTime4,@EndTime4,@StartTime5,@EndTime5,@StartTime6,@EndTime6 FROM [dbo].[TM_SubSic] 
        WHERE [LscNodeID] = @DevId;";

        /// <summary>
        /// Node
        /// </summary>
        public const String SQL_ND_GetNodes = @"
        ;WITH Nodes AS
        (
            SELECT [DevID],[RtuID],[DotID],[AicID] AS [NodeID],@AIType AS [NodeType],[AicName] AS [NodeName],[AicDesc] AS [NodeDesc],[Unit] AS [Remark],[AuxSet],[Enabled] FROM [dbo].[TM_AIC] WHERE [DevID] = @DevID
            UNION ALL
            SELECT [DevID],[RtuID],[DotID],[AocID] AS [NodeID],@AOType AS [NodeType],[AocName] AS [NodeName],[AocDesc] AS [NodeDesc],[Unit] AS [Remark],[AuxSet],[Enabled] FROM [dbo].[TM_AOC] WHERE [DevID] = @DevID
            UNION ALL
            SELECT [DevID],[RtuID],[DotID],[DicID] AS [NodeID],@DIType AS [NodeType],[DicName] AS [NodeName],[DicDesc] AS [NodeDesc],[Describe] AS [Remark],[AuxSet],[Enabled] FROM [dbo].[TM_DIC] WHERE [DevID] = @DevID
            UNION ALL
            SELECT [DevID],[RtuID],[DotID],[DocID] AS [NodeID],@DOType AS [NodeType],[DocName] AS [NodeName],[DocDesc] AS [NodeDesc],[Describe] AS [Remark],[AuxSet],[Enabled] FROM [dbo].[TM_DOC] WHERE [DevID] = @DevID
        )
        SELECT [DevID],[RtuID],[DotID],[NodeID],[NodeType],[NodeName],[NodeDesc],[Remark],[AuxSet],[Enabled],0 AS [Value],NULL AS [Status],NULL AS [DateTime],GETDATE() AS [UpdateTime] FROM Nodes;";

        public const String SQL_ND_GetStatusNodes = @"
        IF(@RoleId IS NULL)
        BEGIN
	        SELECT DC.[DevID],DC.[RtuID],DC.[DotID],DC.[DicID] AS [NodeID],@DIType AS [NodeType],DC.[DicName] AS [NodeName],DC.[DicDesc] AS [NodeDesc],DC.[Describe] AS [Remark],DC.[AuxSet],DC.[Enabled],0 AS [Value],NULL AS [Status],NULL AS [DateTime],GETDATE() AS [UpdateTime] 
	        FROM [dbo].[TM_DIC] DC 
	        INNER JOIN [dbo].[TR_RTU] R ON DC.[RtuID] = R.[RtuID]
	        WHERE (R.[Protocol] = 'F1' AND DC.[DotID] = 0) OR ((R.[Protocol] = 'CD' OR R.[Protocol] = 'CD_NEW') AND DC.[DotID] = 10);
        END
        ELSE 
        BEGIN
	        ;WITH RoleDev AS
            (
                SELECT * FROM [dbo].[Fun_GetNodesInRole](@RoleID) 
                WHERE [RoleId] = @RoleId AND [NodeType] = @DevType
            )
            SELECT DC.[DevID],DC.[RtuID],DC.[DotID],DC.[DicID] AS [NodeID],@DIType AS [NodeType],DC.[DicName] AS [NodeName],DC.[DicDesc] AS [NodeDesc],DC.[Describe] AS [Remark],DC.[AuxSet],DC.[Enabled],0 AS [Value],NULL AS [Status],NULL AS [DateTime],GETDATE() AS [UpdateTime] 
	        FROM [dbo].[TM_DIC] DC 
	        INNER JOIN RoleDev RD ON DC.[DevID] = RD.[NodeId]
	        INNER JOIN [dbo].[TR_RTU] R ON DC.[RtuID] = R.[RtuID]
	        WHERE (R.[Protocol] = 'F1' AND DC.[DotID] = 0) OR ((R.[Protocol] = 'CD' OR R.[Protocol] = 'CD_NEW') AND DC.[DotID] = 10);
        END";

        public const String SQL_ND_GetRemoteNodes = @"
        IF(@RoleId IS NULL)
        BEGIN
	        SELECT DC.[DevID],DC.[RtuID],DC.[DotID],DC.[DocID] AS [NodeID],@DOType AS [NodeType],DC.[DocName] AS [NodeName],DC.[DocDesc] AS [NodeDesc],DC.[Describe] AS [Remark],DC.[AuxSet],DC.[Enabled],0 AS [Value],NULL AS [Status],NULL AS [DateTime],GETDATE() AS [UpdateTime]
            FROM [dbo].[TM_DOC] DC
            INNER JOIN [dbo].[TR_RTU] R ON DC.[RtuID] = R.[RtuID]
            WHERE (R.[Protocol] = 'F1' OR R.[Protocol] = 'CD' OR R.[Protocol] = 'CD_NEW') AND DC.[DotID] = 0;
        END
        ELSE 
        BEGIN
	        ;WITH RoleDev AS
            (
                SELECT * FROM [dbo].[Fun_GetNodesInRole](@RoleID) 
                WHERE [RoleId] = @RoleId AND [NodeType] = @DevType
            )
            SELECT DC.[DevID],DC.[RtuID],DC.[DotID],DC.[DocID] AS [NodeID],@DOType AS [NodeType],DC.[DocName] AS [NodeName],DC.[DocDesc] AS [NodeDesc],DC.[Describe] AS [Remark],DC.[AuxSet],DC.[Enabled],0 AS [Value],NULL AS [Status],NULL AS [DateTime],GETDATE() AS [UpdateTime]
            FROM [dbo].[TM_DOC] DC
            INNER JOIN RoleDev RD ON DC.[DevID] = RD.[NodeId]
            INNER JOIN [dbo].[TR_RTU] R ON DC.[RtuID] = R.[RtuID]
            WHERE (R.[Protocol] = 'F1' OR R.[Protocol] = 'CD' OR R.[Protocol] = 'CD_NEW') AND DC.[DotID] = 0;
        END";

        public const String SQL_ND_GetLsc = @"SELECT [LscID],[LscName] FROM [dbo].[TM_LSC];";

        /// <summary>
        /// Alarm
        /// </summary>
        public const String SQL_AM_GetAlarms = @"
        SELECT [SerialNO],[Area1Name],[Area2Name],[Area3Name],[Area4Name],[StaName],[DevName],NULL AS [DevDesc],[NodeID],[NodeType],[NodeName],[AlarmID],[AlarmValue],[AlarmLevel],[AlarmStatus],[AlarmDesc],[AuxAlarmDesc],
        [StartTime],[EndTime],[ConfirmName],[ConfirmMarking],[ConfirmTime],[AuxSet],[TaskID],[ProjStr] AS [ProjName],0 AS [TurnCount],GETDATE() AS [UpdateTime] FROM [dbo].[TA_Alarm];";

        public const String SQL_AM_GetHisAlarms = @"
        DECLARE @tpDate DATETIME, 
                @tbName NVARCHAR(255),
                @tableCnt INT = 0,
                @SQL NVARCHAR(MAX) = N'';

        SET @BeginFromTime = ISNULL(@BeginFromTime,DATEADD(MM,-1,GETDATE()));
        SET @BeginToTime = ISNULL(@BeginToTime,GETDATE());
        SET @tpDate = @BeginFromTime;
        WHILE(DATEDIFF(MM,@tpDate,@BeginToTime)>=0)
        BEGIN
        SET @tbName = N'[dbo].[TH_Alarm'+CONVERT(VARCHAR(6),@tpDate,112)+ N']';
        IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(@tbName) AND type in (N'U'))
        BEGIN
            IF(@tableCnt>0)
            BEGIN
            SET @SQL += N' 
            UNION ALL 
            ';
            END
            SET @SQL += N'SELECT [SerialNO],[NodeType],[NodeID],[NodeName],[Area1Name],[Area2Name],[Area3Name],[Area4Name],[StaName],[DevName],[StartTime],[EndTime],[AlarmID],[AlarmLevel],[AlarmValue],[AlarmDesc],[ConfirmTime],[ConfirmName],[ConfirmMarking],[AlarmLast],[AuxAlarmDesc],[ProjStr] FROM ' + @tbName + N' WHERE [StartTime] BETWEEN ''' + CONVERT(NVARCHAR,@BeginFromTime,120) + N''' AND ''' + CONVERT(NVARCHAR,@BeginToTime,120) + N'''';
    
            IF(@Area2Name IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [Area2Name] = ''' + @Area2Name + N'''';
            END
    
            IF(@Area3Name IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [Area3Name] = ''' + @Area3Name + N'''';
            END
		
            IF(@StaName IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [StaName] = ''' + @StaName + N'''';
            END
		
            IF(@DevName IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [DevName] = ''' + @DevName + N'''';
            END
	
            IF(@NodeName IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [NodeName] = ''' + @NodeName + N'''';
            END
	
            IF(@AlarmLevel IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [AlarmLevel] = ' + CAST(@AlarmLevel AS NVARCHAR);
            END
	
            IF(@EndFromTime IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [EndTime] >= ''' + CONVERT(NVARCHAR,@EndFromTime,120) + N'''';
            END
	
            IF(@EndToTime IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [EndTime] <= ''' + CONVERT(NVARCHAR,@EndToTime,120) + N'''';
            END
	
            IF(@FromInterval IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [AlarmLast]*24*3600 >= ' + CAST(@FromInterval AS NVARCHAR);
            END
	
            IF(@EndInterval IS NOT NULL)
            BEGIN
                SET @SQL += N' AND [AlarmLast]*24*3600 <= ' + CAST(@EndInterval AS NVARCHAR);
            END
    
            SET @tableCnt += 1;
        END
        SET @tpDate = DATEADD(MM,1,@tpDate);
        END

        IF(@tableCnt > 0)
        BEGIN
        SET @SQL = N';WITH HisAlarms AS
        (
            ' + @SQL + N'
        )
        SELECT [SerialNO],[NodeType],[NodeID],[NodeName],[Area1Name],[Area2Name],[Area3Name],[Area4Name],[StaName],[DevName],[StartTime],[EndTime],[AlarmID],[AlarmLevel],[AlarmValue],[AlarmDesc],[ConfirmTime],[ConfirmName],[ConfirmMarking],[AlarmLast],[AuxAlarmDesc],[ProjStr] AS [ProjName] FROM HisAlarms ORDER BY [StartTime];'
        END

        EXECUTE sp_executesql @SQL;";

        /// <summary>
        /// Combobox Dictionary.
        /// </summary>
        public const String SQL_CB_GetLsc = @"SELECT [LscID],[LscName] FROM [dbo].[TM_LSC];";

        public const String SQL_CB_GetArea1 = @"
        IF(@RoleId IS NULL)
        BEGIN
	        SELECT [AreaID],[AreaName] FROM [dbo].[TM_AREA] WHERE [NodeLevel] = 1 ORDER BY [LastAreaID],[AreaID];
        END
        ELSE 
        BEGIN
	        SELECT TA.[AreaID],TA.[AreaName] FROM [dbo].[TM_AREA] TA 
	        INNER JOIN [dbo].[Fun_GetNodesInRole](@RoleID) TGT ON TA.[NodeLevel] = 1 
	        AND TA.[AreaID] = TGT.[NodeID] 
	        AND TGT.[RoleId] = @RoleId 
	        AND TGT.[NodeType] = @AreaType 
	        ORDER BY TA.[LastAreaID],TA.[AreaID];
        END";

        public const String SQL_CB_GetArea2 = @"
        IF(@RoleId IS NULL)
        BEGIN
	        SELECT [AreaID],[AreaName] FROM [dbo].[TM_AREA] 
	        WHERE [NodeLevel] = 2 AND (@AreaID IS NULL OR [LastAreaID] = @AreaID) ORDER BY [LastAreaID],[AreaID];
        END
        ELSE 
        BEGIN
	        SELECT TA.[AreaID],TA.[AreaName] FROM [dbo].[TM_AREA] TA 
	        INNER JOIN [dbo].[Fun_GetNodesInRole](@RoleID) TGT ON TA.[NodeLevel] = 2 
	        AND (@AreaID IS NULL OR TA.[LastAreaID] = @AreaID)
	        AND TA.[AreaID] = TGT.[NodeID] 
	        AND TGT.[RoleId] = @RoleId 
	        AND TGT.[NodeType] = @AreaType 
	        ORDER BY TA.[LastAreaID],TA.[AreaID];
        END";

        public const String SQL_CB_GetArea3 = @"
        IF(@RoleId IS NULL)
        BEGIN
	        SELECT [AreaID],[AreaName] FROM [dbo].[TM_AREA] 
	        WHERE [NodeLevel] = 3 AND (@AreaID IS NULL OR [LastAreaID] = @AreaID) ORDER BY [LastAreaID],[AreaID];
        END
        ELSE 
        BEGIN
	        SELECT TA.[AreaID],TA.[AreaName] FROM [dbo].[TM_AREA] TA 
	        INNER JOIN [dbo].[Fun_GetNodesInRole](@RoleID) TGT ON TA.[NodeLevel] = 3 
	        AND (@AreaID IS NULL OR TA.[LastAreaID] = @AreaID)
	        AND TA.[AreaID] = TGT.[NodeID] 
	        AND TGT.[RoleId] = @RoleId 
	        AND TGT.[NodeType] = @AreaType 
	        ORDER BY TA.[LastAreaID],TA.[AreaID];
        END";

        public const String SQL_CB_GetSta = @"
        IF(@RoleId IS NULL)
        BEGIN
	        SELECT [StaID],[StaName] FROM [dbo].[TM_STA] 
	        WHERE (@AreaID IS NULL OR [AreaID] = @AreaID)
            ORDER BY ISNULL([NetGridID],2000000000),[StaTypeID],[StaName];
        END
        ELSE 
        BEGIN
	        SELECT TS.[StaID],TS.[StaName] FROM [dbo].[TM_STA] TS 
	        INNER JOIN [dbo].[Fun_GetNodesInRole](@RoleID) TGT ON (@AreaID IS NULL OR TS.[AreaID] = @AreaID)
	        AND TS.[StaID] = TGT.[NodeID] 
	        AND TGT.[RoleId] = @RoleId 
	        AND TGT.[NodeType] = @StaType 
	        ORDER BY ISNULL(TS.[NetGridID],2000000000),TS.[StaTypeID],TS.[StaName];
        END";

        public const String SQL_CB_GetDev = @"
        IF(@RoleId IS NULL)
        BEGIN
            ;WITH MJ AS
            (
	            SELECT SS.[SicID] AS [RtuID],SS.[LscNodeID] AS [DevID] FROM [dbo].[TM_SubSic] SS 
	            INNER JOIN [dbo].[TR_RTU] R  ON SS.[SicID] = R.[RtuID]
	            WHERE R.[Protocol] = 'F1' OR R.[Protocol] = 'CD' OR R.[Protocol] = 'CD_NEW'
            )
            SELECT TD.[DevID],TD.[DevName] FROM [dbo].[TM_DEV] TD
            INNER JOIN [dbo].[TC_DeviceType] TDT ON TD.[DevTypeID] = TDT.[TypeID] AND TDT.[TypeName] LIKE '%门禁%'
            INNER JOIN [dbo].[TM_STA] TS ON TD.[StaID] = TS.[StaID]
            WHERE EXISTS(SELECT 1 FROM MJ WHERE TD.[DevID] = MJ.[DevID]) 
            AND (@StaID IS NULL OR TS.[StaID] = @StaID) 
            AND (@AreaID IS NULL OR TS.[AreaID] = @AreaID)
            ORDER BY TD.[DevName];
        END
        ELSE 
        BEGIN
	        SELECT TD.[DevID],TD.[DevName] FROM [dbo].[TM_DEV] TD
	        INNER JOIN [dbo].[TM_STA] TS ON TD.[StaID] = TS.[StaID]
	        INNER JOIN [dbo].[Fun_GetNodesInRole](@RoleID) TGT ON TD.[DevID] = TGT.[NodeId]
	        AND TGT.[NodeType] = @DevType 
	        AND TGT.[RoleId] = @RoleId
	        AND (@StaID IS NULL OR TD.[StaID] = @StaID)
	        AND (@AreaID IS NULL OR TS.[AreaID] = @AreaID)  
	        ORDER BY TD.[DevName];
        END";

        public const String SQL_CB_GetNodes = @"
        DECLARE @Nodes TABLE(
	        NodeID INT PRIMARY KEY,
	        NodeName VARCHAR(40)
        );

        IF(@AI = 1)
        BEGIN
            INSERT INTO @Nodes([NodeID],[NodeName])
            SELECT [AicID],[AicName] FROM [dbo].[TM_AIC]
            WHERE [Enabled] = 1 AND [DevID] = @DevID;
        END

        IF(@AO = 1)
        BEGIN
            INSERT INTO @Nodes([NodeID],[NodeName])
            SELECT [AocID],[AocName] FROM [dbo].[TM_AOC]
            WHERE [Enabled] = 1 AND [DevID] = @DevID;
        END

        IF(@DI = 1)
        BEGIN
            INSERT INTO @Nodes([NodeID],[NodeName])
            SELECT [DicID],[DicName] FROM [dbo].[TM_DIC]
            WHERE [Enabled] = 1 AND [DevID] = @DevID;
        END

        IF(@DO = 1)
        BEGIN
            INSERT INTO @Nodes([NodeID],[NodeName])
            SELECT [DocID],[DocName] FROM [dbo].[TM_DOC]
            WHERE [Enabled] = 1 AND [DevID] = @DevID;
        END

        SELECT NodeID,NodeName FROM @Nodes ORDER BY NodeID;";

        /// <summary>
        /// Grid.
        /// </summary>
        public const String SQL_GD_GetGrids = @"
        SELECT [TypeID],[TypeName] FROM [dbo].[TC_NetGrid] ORDER BY [TypeID];";
        public const String SQL_GD_DeleteGrids = @"
        DELETE FROM [dbo].[TC_NetGrid] WHERE [TypeID] = @TypeID;
        UPDATE [dbo].[TM_STA] SET [NetGridID] = NULL WHERE [NetGridID] = @TypeID;";
        public const String SQL_GD_AddGrid = @"
        INSERT INTO [dbo].[TC_NetGrid]([TypeID],[TypeName])
        SELECT ISNULL(MAX([TypeID]),0)+1 AS [TypeID],@TypeName AS [TypeName] FROM [dbo].[TC_NetGrid];";
        public const String SQL_GD_UpdateGrid = @"
        UPDATE [dbo].[TC_NetGrid] SET [TypeName] = @TypeName WHERE [TypeID] = @TypeID;";
        public const String SQL_GD_ExistGrid = @"
        SELECT COUNT(1) AS CNT FROM [dbo].[TC_NetGrid] WHERE [TypeName] = @TypeName;";
        public const String SQL_GD_GetGridStations = @"
        IF(@RoleId IS NULL)
        BEGIN
        SELECT TAAA.[AreaID] AS [Area1ID],TAAA.[AreaName] AS [Area1Name],TAA.[AreaID] AS [Area2ID],TAA.[AreaName] AS [Area2Name],
        TA.[AreaID] AS [Area3ID],TA.[AreaName] AS [Area3Name],TS.[StaID],TS.[StaName],NG.[TypeID] AS NetGridID,NG.[TypeName] AS NetGridName 
        FROM [dbo].[TC_NetGrid] NG
        INNER JOIN [dbo].[TM_STA] TS ON NG.[TypeID] = TS.[NetGridID] AND NG.[TypeID] = @TypeID
        INNER JOIN [dbo].[TM_AREA] TA ON TS.[AreaID] = TA.[AreaID]
        LEFT OUTER JOIN [dbo].[TM_AREA] TAA ON TA.[LscID] = TAA.[LscID] AND TA.[LastAreaID] = TAA.[AreaID] AND TAA.[NodeLevel] = 2
        LEFT OUTER JOIN [dbo].[TM_AREA] TAAA ON TAA.[LscID] = TAAA.[LscID] AND TAA.[LastAreaID] = TAAA.[AreaID] AND TAAA.[NodeLevel] = 1
        ORDER BY TS.[StaTypeID],TS.[StaName];
        END
        ELSE 
        BEGIN
        ;WITH RoleSta AS
        (
            SELECT [RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex] FROM [dbo].[Fun_GetNodesInRole](@RoleID) 
            WHERE [RoleId] = @RoleId AND [NodeType] = @StaType
        )
        SELECT TAAA.[AreaID] AS [Area1ID],TAAA.[AreaName] AS [Area1Name],TAA.[AreaID] AS [Area2ID],TAA.[AreaName] AS [Area2Name],
        TA.[AreaID] AS [Area3ID],TA.[AreaName] AS [Area3Name],TS.[StaID],TS.[StaName],NG.[TypeID] AS NetGridID,NG.[TypeName] AS NetGridName 
        FROM [dbo].[TC_NetGrid] NG
        INNER JOIN [dbo].[TM_STA] TS ON NG.[TypeID] = TS.[NetGridID] AND NG.[TypeID] = @TypeID
        INNER JOIN RoleSta RD ON TS.[StaID] = RD.[NodeId]
        INNER JOIN [dbo].[TM_AREA] TA ON TS.[AreaID] = TA.[AreaID]
        LEFT OUTER JOIN [dbo].[TM_AREA] TAA ON TA.[LscID] = TAA.[LscID] AND TA.[LastAreaID] = TAA.[AreaID] AND TAA.[NodeLevel] = 2
        LEFT OUTER JOIN [dbo].[TM_AREA] TAAA ON TAA.[LscID] = TAAA.[LscID] AND TAA.[LastAreaID] = TAAA.[AreaID] AND TAAA.[NodeLevel] = 1
        ORDER BY TS.[StaTypeID],TS.[StaName];
        END";
        public const String SQL_GD_UpdateStaGrid = @"
        UPDATE [dbo].[TM_STA] SET [NetGridID] = @NetGridID WHERE [StaID] = @StaID;";
        public const String SQL_GD_DeleteStaGrid = @"
        UPDATE [dbo].[TM_STA] SET [NetGridID] = NULL WHERE [StaID] = @StaID;";
    }
}
