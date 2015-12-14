/*
* Intelligent Access Management System Script Library v1.0.0
* Copyright 2013, Delta
* Author: Steven
* Date: 2013/12/31
*/

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_Authorizations]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_Authorizations]') AND type in (N'U'))
DROP TABLE [dbo].[AS_Authorizations]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_Authorizations](
	[AuthId] [int] NOT NULL,
	[AuthName] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](1024) NULL,
	[LastAuthId] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_AS_Authorizations] PRIMARY KEY CLUSTERED 
(
	[AuthId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_AuthorizationsInRoles]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_AuthorizationsInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[AS_AuthorizationsInRoles]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_AuthorizationsInRoles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[AuthId] [int] NOT NULL,
 CONSTRAINT [PK_AS_AuthorizationsInRoles] PRIMARY KEY CLUSTERED 
(
	[AuthId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_Cards]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_Cards]') AND type in (N'U'))
DROP TABLE [dbo].[AS_Cards]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_Cards](
	[CardSn] [varchar](50) NOT NULL,
	[CardType] [int] NOT NULL,
	[UID] [varchar](50) NULL,
	[Pwd] [varchar](50) NULL,
	[BeginTime] [datetime] NOT NULL,
	[BeginReason] [nvarchar](1024) NULL,
	[Comment] [nvarchar](1024) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_AS_Cards] PRIMARY KEY CLUSTERED 
(
	[CardSn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_CardsPerEmployee]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_CardsPerEmployee]') AND type in (N'U'))
DROP TABLE [dbo].[AS_CardsPerEmployee]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_CardsPerEmployee](
	[EmpId] [varchar](50) NOT NULL,
	[EmpType] [int] NOT NULL,
	[CardSn] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AS_CardsPerEmployee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC,
	[EmpType] ASC,
	[CardSn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_Departments]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_Departments]') AND type in (N'U'))
DROP TABLE [dbo].[AS_Departments]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_Departments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[DepId] [varchar](50) NOT NULL,
	[DepName] [nvarchar](50) NOT NULL,
	[LastDepId] [varchar](50) NOT NULL,
	[Comment] [nvarchar](1024) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_AS_Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AS_Departments] UNIQUE NONCLUSTERED 
(
	[DepId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_DepartmentsInRoles]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_DepartmentsInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[AS_DepartmentsInRoles]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_DepartmentsInRoles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[DepId] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AS_DepartmentsInRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[DepId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_DevicesInCards]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_DevicesInCards]') AND type in (N'U'))
DROP TABLE [dbo].[AS_DevicesInCards]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_DevicesInCards](
	[CardSn] [varchar](50) NOT NULL,
	[RtuId] [int] NOT NULL,
	[LimitId] [int] NOT NULL,
	[LimitIndex] [int] NULL,
	[BeginTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[Password] [varchar](50) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_AS_DevicesInCards] PRIMARY KEY CLUSTERED 
(
	[CardSn] ASC,
	[RtuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_Events]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_Events]') AND type in (N'U'))
DROP TABLE [dbo].[AS_Events]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_Events](
	[EventId] [uniqueidentifier] NOT NULL,
	[EventTime] [datetime] NOT NULL,
	[EventType] [int] NOT NULL,
	[Operator] [varchar](50) NOT NULL,
	[Source] [varchar](256) NULL,
	[Message] [nvarchar](1024) NOT NULL,
	[StackTrace] [nvarchar](max) NULL,
 CONSTRAINT [PK_AS_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_LimitParameters]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_LimitParameters]') AND type in (N'U'))
DROP TABLE [dbo].[AS_LimitParameters]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_LimitParameters](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[RtuId] [int] NOT NULL,
	[LimitId] [int] NULL,
	[LimitIndex] [int] NULL,
	[LimitDesc] [nvarchar](50) NULL,
	[WeekIndex] [int] NULL,
	[StartTime1] [varchar](5) NULL,
	[EndTime1] [varchar](5) NULL,
	[StartTime2] [varchar](5) NULL,
	[EndTime2] [varchar](5) NULL,
	[StartTime3] [varchar](5) NULL,
	[EndTime3] [varchar](5) NULL,
	[StartTime4] [varchar](5) NULL,
	[EndTime4] [varchar](5) NULL,
	[StartTime5] [varchar](5) NULL,
	[EndTime5] [varchar](5) NULL,
	[StartTime6] [varchar](5) NULL,
	[EndTime6] [varchar](5) NULL,
 CONSTRAINT [PK_AS_LimitParameters] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_NodesInRoles]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_NodesInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[AS_NodesInRoles]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_NodesInRoles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[NodeId] [int] NOT NULL,
	[NodeType] [int] NOT NULL,
	[LastNodeId] [int] NOT NULL,
	[SortIndex] [int] NOT NULL,
 CONSTRAINT [PK_AS_NodesInRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[NodeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_OrgEmployees]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_OrgEmployees]') AND type in (N'U'))
DROP TABLE [dbo].[AS_OrgEmployees]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_OrgEmployees](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EmpId] [varchar](50) NOT NULL,
	[EmpType] [int] NOT NULL,
	[EmpName] [nvarchar](50) NOT NULL,
	[EnglishName] [varchar](50) NULL,
	[Sex] [varchar](50) NOT NULL,
	[CardId] [varchar](50) NULL,
	[Hometown] [nvarchar](200) NULL,
	[BirthDay] [datetime] NULL,
	[Marriage] [int] NULL,
	[HomeAddress] [nvarchar](200) NULL,
	[HomePhone] [varchar](50) NULL,
	[EntryDay] [datetime] NULL,
	[PositiveDay] [datetime] NULL,
	[DepId] [varchar](50) NULL,
	[DutyName] [nvarchar](50) NULL,
	[OfficePhone] [varchar](50) NULL,
	[MobilePhone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Comment] [nvarchar](1024) NULL,
	[Photo] [image] NULL,
	[PhotoLayout] [int] NULL,
	[ResignationDate] [datetime] NULL,
	[ResignationRemark] [nvarchar](1024) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_AS_OrgEmployees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AS_OrgEmployees] UNIQUE NONCLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_OutEmployees]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_OutEmployees]') AND type in (N'U'))
DROP TABLE [dbo].[AS_OutEmployees]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_OutEmployees](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EmpId] [varchar](50) NOT NULL,
	[EmpName] [nvarchar](50) NOT NULL,
	[Sex] [varchar](50) NOT NULL,
	[CardId] [varchar](50) NULL,
	[CardAddress] [nvarchar](200) NULL,
	[CardIssue] [nvarchar](200) NULL,
	[Hometown] [nvarchar](200) NULL,
	[CompanyName] [nvarchar](100) NULL,
	[ProjectName] [nvarchar](100) NULL,
	[OfficePhone] [varchar](50) NULL,
	[MobilePhone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Comment] [nvarchar](1024) NULL,
	[ParentEmpId] [varchar](50) NULL,
	[Photo] [image] NULL,
	[PhotoLayout] [int] NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_AS_OutEmployees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AS_OutEmployees] UNIQUE NONCLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_Roles]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_Roles]') AND type in (N'U'))
DROP TABLE [dbo].[AS_Roles]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_Roles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[Comment] [nvarchar](1024) NULL,
	[LastRoleId] [uniqueidentifier] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_AS_Roles] PRIMARY KEY NONCLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_AS_Roles] UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_Users]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_Users]') AND type in (N'U'))
DROP TABLE [dbo].[AS_Users]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[RemarkName] [nvarchar](50) NULL,
	[Password] [varchar](128) NOT NULL,
	[PasswordFormat] [int] NOT NULL,
	[PasswordSalt] [varchar](128) NOT NULL,
	[MobilePhone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LimitDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NULL,
	[LastPasswordChangedDate] [datetime] NULL,
	[FailedPasswordAttemptCount] [int] NOT NULL,
	[FailedPasswordDate] [datetime] NULL,
	[IsLockedOut] [bit] NOT NULL,
	[LastLockoutDate] [datetime] NULL,
	[Comment] [nvarchar](1024) NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_AS_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表[dbo].[AS_UsersInRoles]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AS_UsersInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[AS_UsersInRoles]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AS_UsersInRoles](
	[RoleId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AS_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[AS_Cards_Delete]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[AS_Cards_Delete]'))
DROP TRIGGER [dbo].[AS_Cards_Delete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<Cards Delete Triger>
-- =============================================
CREATE TRIGGER [dbo].[AS_Cards_Delete] 
   ON [dbo].[AS_Cards] 
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;
	DELETE FROM TC FROM [dbo].[TD_Card] TC INNER JOIN deleted D ON TC.[CardNO] = D.[CardSn];
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[AS_Cards_Insert]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[AS_Cards_Insert]'))
DROP TRIGGER [dbo].[AS_Cards_Insert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<Cards Insert Triger>
-- =============================================
CREATE TRIGGER [dbo].[AS_Cards_Insert] 
   ON [dbo].[AS_Cards] 
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	DELETE FROM TC FROM [dbo].[TD_Card] TC INNER JOIN inserted I ON TC.[CardNO] = I.[CardSn];
	INSERT INTO [dbo].[TD_Card]([CardNO],[CardType],[DoorUID],[DoorPWD],[CardDesc],[UserID],[RegTime],[RegReason],[UnregTime],[UnregReason],[Enabled])
	SELECT [CardSn],[CardType],[UID],[Pwd],[Comment],0 AS [UserId],[BeginTime],[BeginReason],NULL AS [UnregTime],NULL AS [UnregReason],[Enabled] FROM inserted;
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[AS_Cards_Update]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[AS_Cards_Update]'))
DROP TRIGGER [dbo].[AS_Cards_Update]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<Cards Update Triger>
-- =============================================
CREATE TRIGGER [dbo].[AS_Cards_Update] 
   ON [dbo].[AS_Cards] 
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	UPDATE TC SET TC.[CardType] = I.[CardType],TC.[DoorUID] = I.[UID],TC.[DoorPWD] = I.[Pwd],
	TC.[CardDesc] = I.[Comment],TC.[RegTime] = I.[BeginTime],TC.[RegReason] = I.[BeginReason],
	TC.[Enabled] = I.[Enabled] FROM [dbo].[TD_Card] TC INNER JOIN inserted I ON TC.[CardNO] = I.[CardSn];
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[AS_DevicesInCards_Delete]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[AS_DevicesInCards_Delete]'))
DROP TRIGGER [dbo].[AS_DevicesInCards_Delete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<DevicesInCards Delete Triger>
-- =============================================
CREATE TRIGGER [dbo].[AS_DevicesInCards_Delete]
   ON  [dbo].[AS_DevicesInCards]
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;
	WITH Temp AS
	(
		SELECT D.*,CD.[CardID] FROM Deleted D 
		INNER JOIN [dbo].[TD_Card] CD ON D.[CardSn] = CD.[CardNO]
	)
	DELETE FROM TC FROM [dbo].[TD_CardGrant] TC INNER JOIN Temp T ON TC.[CardID] = T.[CardID] AND TC.[RtuID] = T.[RtuId];
	
	INSERT INTO [dbo].[TM_Sync]([Type],[SSID],[RtuID],[OpType],[OpValue],[OpTime],[OpState])
	SELECT 1 AS [Type],TR.[SSID],D.[RtuId],2 AS [OpType],RIGHT(REPLICATE('0', 10) + D.[CardSn],10) AS [OpValue],GETDATE() AS [OpTime],0 AS [OpState] FROM Deleted D 
	INNER JOIN [dbo].[TR_RTU] TR ON D.[RtuId] = TR.[RtuID]
	INNER JOIN [dbo].[AS_Cards] AC ON D.[CardSn] = AC.[CardSn];
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[AS_DevicesInCards_Insert]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[AS_DevicesInCards_Insert]'))
DROP TRIGGER [dbo].[AS_DevicesInCards_Insert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<DevicesInCards Insert Triger>
-- =============================================
CREATE TRIGGER [dbo].[AS_DevicesInCards_Insert]
   ON  [dbo].[AS_DevicesInCards]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[TD_CardGrant]([RtuID],[CardID],[LimitID],[LimitIndex],[BeginTime],[LimitTime],[Pwd],[Enabled])
	SELECT I.[RtuId],CD.[CardID],I.[LimitId],I.[LimitIndex],I.[BeginTime],I.[EndTime],I.[Password],I.[Enabled] FROM Inserted I
	INNER JOIN [dbo].[TD_Card] CD ON I.[CardSn] = CD.[CardNO];
	
	INSERT INTO [dbo].[TM_Sync]([Type],[SSID],[RtuID],[OpType],[OpValue],[OpTime],[OpState])
	SELECT 1 AS [Type],TR.[SSID],I.[RtuId],1 AS [OpType],
	[dbo].[GetSyncOpValue](I.[CardSn],AC.[UID],AC.[Pwd],I.[LimitId],I.LimitIndex,I.EndTime) AS [OpValue],
	GETDATE() AS [OpTime],0 AS [OpState] FROM Inserted I 
	INNER JOIN [dbo].[TR_RTU] TR ON I.[RtuId] = TR.[RtuID]
	INNER JOIN [dbo].[AS_Cards] AC ON I.[CardSn] = AC.[CardSn];
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[AS_DevicesInCards_Update]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[AS_DevicesInCards_Update]'))
DROP TRIGGER [dbo].[AS_DevicesInCards_Update]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<DevicesInCards Update Triger>
-- =============================================
CREATE TRIGGER [dbo].[AS_DevicesInCards_Update]
   ON  [dbo].[AS_DevicesInCards]
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;
	WITH Temp AS
	(
		SELECT I.*,CD.[CardID] FROM Inserted I
		INNER JOIN [dbo].[TD_Card] CD ON I.[CardSn] = CD.[CardNO]
	)
	UPDATE TC SET TC.[LimitID]=T.[LimitId],TC.[LimitIndex]=T.[LimitIndex],TC.[BeginTime]=T.[BeginTime],
	TC.[LimitTime]=T.[EndTime],TC.[Pwd]=T.[Password],TC.[Enabled]=T.[Enabled] FROM [dbo].[TD_CardGrant] TC 
	INNER JOIN Temp T ON TC.[CardID] = T.[CardID] AND TC.[RtuID] = T.[RtuId];
	
	INSERT INTO [dbo].[TM_Sync]([Type],[SSID],[RtuID],[OpType],[OpValue],[OpTime],[OpState])
	SELECT 1 AS [Type],TR.[SSID],D.[RtuId],2 AS [OpType],RIGHT(REPLICATE('0', 10) + D.[CardSn],10) AS [OpValue],GETDATE() AS [OpTime],0 AS [OpState] FROM Deleted D 
	INNER JOIN [dbo].[TR_RTU] TR ON D.[RtuId] = TR.[RtuID]
	INNER JOIN [dbo].[AS_Cards] AC ON D.[CardSn] = AC.[CardSn];
	
	INSERT INTO [dbo].[TM_Sync]([Type],[SSID],[RtuID],[OpType],[OpValue],[OpTime],[OpState])
	SELECT 1 AS [Type],TR.[SSID],I.[RtuId],1 AS [OpType],
	[dbo].[GetSyncOpValue](I.[CardSn],AC.[UID],AC.[Pwd],I.[LimitId],I.LimitIndex,I.EndTime) AS [OpValue],
	GETDATE() AS [OpTime],0 AS [OpState] FROM Inserted I 
	INNER JOIN [dbo].[TR_RTU] TR ON I.[RtuId] = TR.[RtuID]
	INNER JOIN [dbo].[AS_Cards] AC ON I.[CardSn] = AC.[CardSn];
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[AS_LimitParameters_Delete]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[AS_LimitParameters_Delete]'))
DROP TRIGGER [dbo].[AS_LimitParameters_Delete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<Limit Parameters Delete Triger>
-- =============================================
CREATE TRIGGER [dbo].[AS_LimitParameters_Delete]
   ON  [dbo].[AS_LimitParameters]
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;
	DELETE FROM TL FROM [dbo].[TD_LimitParameter] TL INNER JOIN Deleted D ON TL.[RtuID] = D.[RtuId] AND TL.[LimitID] = D.[LimitId]
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[AS_LimitParameters_Insert]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[AS_LimitParameters_Insert]'))
DROP TRIGGER [dbo].[AS_LimitParameters_Insert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<Limit Parameters Insert Triger>
-- =============================================
CREATE TRIGGER [dbo].[AS_LimitParameters_Insert]
   ON  [dbo].[AS_LimitParameters]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	INSERT INTO [dbo].[TD_LimitParameter]([RtuID],[LimitID],[LimitIndex],[LimitDesc],[WeekIndex],[StartTime1],[EndTime1],[StartTime2],[EndTime2],[StartTime3],[EndTime3],[StartTime4],[EndTime4],[StartTime5],[EndTime5],[StartTime6],[EndTime6])
    SELECT [RtuId],[LimitId],[LimitIndex],[LimitDesc],[WeekIndex],[StartTime1],[EndTime1],[StartTime2],[EndTime2],[StartTime3],[EndTime3],[StartTime4],[EndTime4],[StartTime5],[EndTime5],[StartTime6],[EndTime6] FROM Inserted
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[TD_LimitParameter_Delete]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TD_LimitParameter_Delete]'))
DROP TRIGGER [dbo].[TD_LimitParameter_Delete]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<Limit Parameters Delete Triger>
-- =============================================
CREATE TRIGGER [dbo].[TD_LimitParameter_Delete]
   ON  [dbo].[TD_LimitParameter]
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;
    INSERT INTO [dbo].[TM_Sync]([Type],[SSID],[RtuID],[OpType],[OpValue],[OpTime],[OpState])
	SELECT 1 AS [Type],TR.[SSID],D.[RtuId],
	CASE WHEN [LimitID] = 2 THEN 5 WHEN [LimitID] = 0 THEN 6 WHEN [LimitID] = 1 THEN 7 WHEN [LimitID] = 3 THEN 8 WHEN [LimitID] = 4 THEN 10 WHEN [LimitID] = 5 THEN 12 END AS [OpType],
	CASE WHEN [LimitID] = 2 THEN CAST(D.[ID] AS VARCHAR)+';'+CAST(D.[LimitID] AS VARCHAR)+';'+CAST(D.[LimitIndex] AS VARCHAR)+';0;'+D.[StartTime1]+D.[EndTime1]+D.[StartTime2]+D.[EndTime2]+D.[StartTime3]+D.[EndTime3]+D.[StartTime4]+D.[EndTime4]
	WHEN [LimitID] = 0 THEN CAST(D.[ID] AS VARCHAR)+';'+CAST(D.[LimitID] AS VARCHAR)+';'+CAST(D.[LimitIndex] AS VARCHAR)+';'+CAST(D.[WeekIndex] AS VARCHAR)+';'+D.[StartTime1]+D.[EndTime1]+D.[StartTime2]+D.[EndTime2]+D.[StartTime3]+D.[EndTime3]+D.[StartTime4]+D.[EndTime4]+D.[StartTime5]+D.[EndTime5]+D.[StartTime6]+D.[EndTime6]
	WHEN [LimitID] = 1 THEN CAST(D.[ID] AS VARCHAR)+';'+CAST(D.[LimitID] AS VARCHAR)+';0;0;'+D.[StartTime1]+D.[EndTime1]+D.[StartTime2]+D.[EndTime2]+D.[StartTime3]+D.[EndTime3]+D.[StartTime4]+D.[EndTime4] 
	WHEN [LimitID] = 3 THEN CAST(D.[ID] AS VARCHAR)+';'+CAST(D.[LimitID] AS VARCHAR)+';'+CAST(D.[LimitIndex] AS VARCHAR)+';0;'+D.[StartTime1]+D.[EndTime1]+D.[StartTime2]+D.[EndTime2]+D.[StartTime3]+D.[EndTime3]+D.[StartTime4]+D.[EndTime4]
	WHEN [LimitID] = 4 THEN CAST(D.[ID] AS VARCHAR)+';'+CAST(D.[LimitID] AS VARCHAR)+';'+CAST(D.[LimitIndex] AS VARCHAR)+';0;'+D.[StartTime1]
	WHEN [LimitID] = 5 THEN CAST(D.[ID] AS VARCHAR)+';'+CAST(D.[LimitID] AS VARCHAR)+';'+CAST(D.[LimitIndex] AS VARCHAR)+';0;'+D.[StartTime1] END AS [OpValue],
	GETDATE() AS [OpTime],0 AS [OpState] FROM Deleted D 
	INNER JOIN [dbo].[TR_RTU] TR ON D.[RtuId] = TR.[RtuID];
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建触发器[dbo].[TD_LimitParameter_Insert]
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TD_LimitParameter_Insert]'))
DROP TRIGGER [dbo].[TD_LimitParameter_Insert]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<Limit Parameters Insert Triger>
-- =============================================
CREATE TRIGGER [dbo].[TD_LimitParameter_Insert]
   ON  [dbo].[TD_LimitParameter]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
    INSERT INTO [dbo].[TM_Sync]([Type],[SSID],[RtuID],[OpType],[OpValue],[OpTime],[OpState])
	SELECT 1 AS [Type],TR.[SSID],I.[RtuId],
	CASE WHEN [LimitID] = 2 THEN 5 WHEN [LimitID] = 0 THEN 6 WHEN [LimitID] = 1 THEN 7 WHEN [LimitID] = 3 THEN 8 WHEN [LimitID] = 4 THEN 9 WHEN [LimitID] = 5 THEN 12 END AS [OpType],
	CASE WHEN [LimitID] = 2 THEN CAST(I.[ID] AS VARCHAR)+';'+CAST(I.[LimitID] AS VARCHAR)+';'+CAST(I.[LimitIndex] AS VARCHAR)+';0;'+I.[StartTime1]+I.[EndTime1]+I.[StartTime2]+I.[EndTime2]+I.[StartTime3]+I.[EndTime3]+I.[StartTime4]+I.[EndTime4]
	WHEN [LimitID] = 0 THEN CAST(I.[ID] AS VARCHAR)+';'+CAST(I.[LimitID] AS VARCHAR)+';'+CAST(I.[LimitIndex] AS VARCHAR)+';'+CAST(I.[WeekIndex] AS VARCHAR)+';'+I.[StartTime1]+I.[EndTime1]+I.[StartTime2]+I.[EndTime2]+I.[StartTime3]+I.[EndTime3]+I.[StartTime4]+I.[EndTime4]+I.[StartTime5]+I.[EndTime5]+I.[StartTime6]+I.[EndTime6]
	WHEN [LimitID] = 1 THEN CAST(I.[ID] AS VARCHAR)+';'+CAST(I.[LimitID] AS VARCHAR)+';0;0;'+I.[StartTime1]+I.[EndTime1]+I.[StartTime2]+I.[EndTime2]+I.[StartTime3]+I.[EndTime3]+I.[StartTime4]+I.[EndTime4] 
	WHEN [LimitID] = 3 THEN CAST(I.[ID] AS VARCHAR)+';'+CAST(I.[LimitID] AS VARCHAR)+';'+CAST(I.[LimitIndex] AS VARCHAR)+';0;'+I.[StartTime1]+I.[EndTime1]+I.[StartTime2]+I.[EndTime2]+I.[StartTime3]+I.[EndTime3]+I.[StartTime4]+I.[EndTime4]
	WHEN [LimitID] = 4 THEN CAST(I.[ID] AS VARCHAR)+';'+CAST(I.[LimitID] AS VARCHAR)+';'+CAST(I.[LimitIndex] AS VARCHAR)+';0;'+I.[StartTime1]
	WHEN [LimitID] = 5 THEN CAST(I.[ID] AS VARCHAR)+';'+CAST(I.[LimitID] AS VARCHAR)+';'+CAST(I.[LimitIndex] AS VARCHAR)+';0;'+I.[StartTime1] END AS [OpValue],
	GETDATE() AS [OpTime],0 AS [OpState] FROM Inserted I 
	INNER JOIN [dbo].[TR_RTU] TR ON I.[RtuId] = TR.[RtuID];
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建标量函数[dbo].[GetSyncOpValue]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSyncOpValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetSyncOpValue]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2013/12/16>
-- Description:	<Get Sync Operation Value>
-- =============================================
CREATE FUNCTION [dbo].[GetSyncOpValue]
(
	@CardSn VARCHAR(50),
	@UID VARCHAR(50),
	@Pwd VARCHAR(50),
	@LimitId INT,
	@LimitIndex INT,
	@LimitTime DATETIME
)
RETURNS VARCHAR(100)
AS
BEGIN
	DECLARE @VipValue INT;
	SET @CardSn = RIGHT(REPLICATE('0', 10) + @CardSn,10);
	SET @UID = RIGHT(REPLICATE('0', 8) + ISNULL(@UID,''),8);
	SET @Pwd = RIGHT(REPLICATE('0', 4) + ISNULL(@Pwd,''),4);
	SET @VipValue = CASE WHEN @LimitId = -1 THEN 192 WHEN @LimitId = 0 THEN @LimitIndex ELSE 64 + @LimitIndex END;
	RETURN @CardSn + @UID + @Pwd + CONVERT(VARCHAR(8),@LimitTime,112) + CAST(@VipValue AS VARCHAR);
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--创建表值函数[dbo].[Fun_GetNodesInRole]
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fun_GetNodesInRole]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Fun_GetNodesInRole]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Steven>
-- Create date: <2014/01/22>
-- Description:	<Get Nodes In Role>
-- =============================================
CREATE FUNCTION [dbo].[Fun_GetNodesInRole]
(
	@RoleId UNIQUEIDENTIFIER
)
RETURNS @RoleNodes TABLE 
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
)
AS
BEGIN
	DECLARE @AreaType INT = -1,@StaType INT = 0,@DevType INT = 1;
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
    
	;WITH AreaNodes AS
	(
		SELECT [RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex] FROM [dbo].[AS_NodesInRoles] 
		WHERE [RoleId] = @RoleId AND [NodeType] = @AreaType
	),
	DevNodes AS
	(
		SELECT @RoleId AS [RoleId],TD.[DevID] AS [NodeId],@DevType AS [NodeType],
		TS.[StaID] AS [LastNodeId],TD.[DevID] AS [SortIndex] FROM [dbo].[TM_DEV] TD
		INNER JOIN [dbo].[TC_DeviceType] TDT ON TD.[DevTypeID] = TDT.[TypeID] AND TDT.[TypeName] LIKE '%门禁%'
		INNER JOIN [dbo].[TM_STA] TS ON TD.[StaID] = TS.[StaID]
		INNER JOIN AreaNodes AN ON TS.[AreaID] = AN.[NodeId]
		WHERE EXISTS(SELECT 1 FROM @MJ MJ WHERE TD.[DevID] = MJ.[DevID])
	),
	StaNodes AS
	(
		SELECT @RoleId AS [RoleId],TS.[StaID] AS [NodeId],@StaType AS [NodeType],
		TS.[AreaID] AS [LastNodeId],TS.[StaID] AS [SortIndex] FROM [dbo].[TM_STA] TS
		WHERE (SELECT COUNT(1) FROM DevNodes DN WHERE TS.StaID = DN.LastNodeID) > 0
	),
	TotalNodes AS
	(
		SELECT [RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex] FROM AreaNodes
		UNION ALL
		SELECT [RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex] FROM DevNodes
		UNION ALL
		SELECT [RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex] FROM StaNodes
	)
	INSERT INTO @RoleNodes([RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex])
	SELECT [RoleId],[NodeId],[NodeType],[LastNodeId],[SortIndex] FROM TotalNodes;
	RETURN
END
GO

--■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
--添加默认数据
INSERT INTO [dbo].[AS_Roles]([RoleId],[RoleName],[Comment],[LastRoleId],[Enabled]) VALUES('00000001-0001-0001-0001-000000000001','Administrator',N'拥有系统最高权限','00000000-0000-0001-0000-000000000000',1);
GO
INSERT INTO [dbo].[AS_Users]([UserId],[UserName],[RemarkName],[Password],[PasswordFormat],[PasswordSalt],[MobilePhone],[Email],[CreateDate],[LimitDate],[LastLoginDate],[LastPasswordChangedDate],[FailedPasswordAttemptCount],[FailedPasswordDate],[IsLockedOut],[LastLockoutDate],[Comment],[Enabled])
VALUES('52bc192a-2e04-49ce-a571-a76b55cd5b84','system','系统管理员','c/OffX1kScJvrnBrK5C0mvJPaiY=',1,'MHGf2fnPzkAg5TYy6CrAyw==',NULL,NULL,GETDATE(),'2099-12-31 23:59:59',NULL,NULL,0,NULL,0,NULL,N'系统默认用户',1);
GO
INSERT INTO [dbo].[AS_UsersInRoles]([RoleId],[UserId]) VALUES('00000001-0001-0001-0001-000000000001','52bc192a-2e04-49ce-a571-a76b55cd5b84');
GO
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (1000,N'系统',NULL,0,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (1001,N'更改密码',NULL,1000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (1002,N'用户管理',NULL,1000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (1003,N'角色权限',NULL,1000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (1004,N'安全退出',NULL,1000,0);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (2000,N'维护',NULL,0,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (2001,N'准进时段',NULL,2000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (2002,N'系统日志',NULL,2000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (2003,N'网格管理',NULL,2000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (2004,N'清理数据',NULL,2000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (3000,N'发卡',NULL,0,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (3001,N'部门管理',NULL,3000,0);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (3002,N'员工管理',NULL,3000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (3003,N'外协管理',NULL,3000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (3004,N'员工持卡',NULL,3000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (3005,N'外协持卡',NULL,3000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (3006,N'设备授权',NULL,3000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (3007,N'权限复制',NULL,3000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (4000,N'报表',NULL,0,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (4001,N'历史告警',NULL,4000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (4002,N'设备报表',NULL,4000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (4003,N'员工报表',NULL,4000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (4004,N'外协报表',NULL,4000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (4005,N'刷卡记录',NULL,4000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (4006,N'刷卡次数统计',NULL,4000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (5000,N'视图',NULL,0,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (5001,N'监控层级',NULL,5000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (5002,N'实时状态',NULL,5000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (5003,N'实时告警',NULL,5000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (6000,N'帮助',NULL,0,0);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (6001,N'使用手册',NULL,6000,0);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (6002,N'注册软件',NULL,6000,0);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (6003,N'语言',NULL,6000,0);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (6004,N'关于',NULL,6000,0);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (7000,N'操作',NULL,0,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (7001,N'远程控制',NULL,7000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (7002,N'参数设置',NULL,7000,1);
INSERT INTO [dbo].[AS_Authorizations]([AuthId],[AuthName],[Comment],[LastAuthId],[Enabled]) VALUES (7003,N'告警确认',NULL,7000,1);
GO