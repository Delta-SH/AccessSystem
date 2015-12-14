using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delta.MPS.DBUtility
{
    /// <summary>
    /// The SQLiteText class is intended to store sqlite statements.
    /// </summary>
    public static class SQLiteText
    {
        public const string Registry_Create_Tables = @"
        CREATE TABLE IF NOT EXISTS [sys_application] (
            [app_id] guid PRIMARY KEY NOT NULL,
            [app_name] nvarchar(50),
            [app_license] text,
            [app_firsttime] datetime,
            [app_lasttime] datetime,
            [app_logintime] datetime
        );

        CREATE TABLE IF NOT EXISTS [sys_database_servers] (
            [unique_id] guid PRIMARY KEY NOT NULL,
            [database_intention] int,
            [database_type] int,
            [database_ip] nvarchar(128),
            [database_port] int,
            [database_user] nvarchar(50),
            [database_pwd] nvarchar(50),
            [database_name] nvarchar(128),
            [update_time] datetime
        );

        CREATE TABLE IF NOT EXISTS [sys_interface_paramters] (
            [unique_id] guid PRIMARY KEY NOT NULL,
            [interface_ip] nvarchar(128),
            [interface_port] int,
            [interface_user] nvarchar(50),
            [interface_pwd] nvarchar(50),
            [interface_detect] int,
            [interface_interrupt] int,
            [interface_synctime] bit,
            [update_time] datetime
        );

        CREATE TABLE IF NOT EXISTS [login_recent_users] (
            [unique_id] guid PRIMARY KEY NOT NULL,
            [recent_user] nvarchar(50),
            [recent_pwd] nvarchar(50),
            [recent_rmb] bit,
            [recent_lan] nvarchar(50),
            [update_time] datetime
        );";

        public const string Registry_Get_DatabaseServers = @"
        SELECT [unique_id],[database_intention],[database_type],[database_ip],[database_port],[database_user],[database_pwd],[database_name],[update_time] FROM [sys_database_servers];";

        public const string Registry_Save_DatabaseServers = @"
        INSERT INTO [sys_database_servers]([unique_id],[database_intention],[database_type],[database_ip],[database_port],[database_user],[database_pwd],[database_name],[update_time]) 
        VALUES(@unique_id,@database_intention,@database_type,@database_ip,@database_port,@database_user,@database_pwd,@database_name,@update_time);";

        public const string Registry_Clear_DatabaseServers = @"
        DELETE FROM [sys_database_servers];";

        public const string Registry_Get_Interface = @"
        SELECT [unique_id],[interface_ip],[interface_port],[interface_user],[interface_pwd],[interface_detect],[interface_interrupt],[interface_synctime],[update_time] FROM [sys_interface_paramters];";

        public const string Registry_Save_Interface = @"
        DELETE FROM [sys_interface_paramters];
        INSERT INTO [sys_interface_paramters]([unique_id],[interface_ip],[interface_port],[interface_user],[interface_pwd],[interface_detect],[interface_interrupt],[interface_synctime],[update_time]) 
        VALUES(@unique_id,@interface_ip,@interface_port,@interface_user,@interface_pwd,@interface_detect,@interface_interrupt,@interface_synctime,@update_time);";

        public const string Registry_Get_RecentUsers = @"
        SELECT [unique_id],[recent_user],[recent_pwd],[recent_rmb],[recent_lan],[update_time] FROM [login_recent_users] 
        ORDER BY [update_time] DESC LIMIT @limit;";

        public const string Registry_Save_RecentUsers = @"
        DELETE FROM [login_recent_users] WHERE [recent_user] = @recent_user;
        INSERT INTO [login_recent_users]([unique_id],[recent_user],[recent_pwd],[recent_rmb],[recent_lan],[update_time]) 
        VALUES(@unique_id,@recent_user,@recent_pwd,@recent_rmb,@recent_lan,@update_time);";

        public const string Registry_Clear_RecentUsers = @"
        DELETE FROM [login_recent_users];";

        public const string Registry_Get_SystemApplication = @"
        SELECT [app_id],[app_name],[app_license],[app_firsttime],[app_lasttime],[app_logintime] FROM [sys_application] WHERE [app_id] = @app_id;";

        public const string Registry_Save_SystemApplication = @"
        INSERT OR IGNORE INTO [sys_application]([app_id],[app_name],[app_license],[app_firsttime],[app_lasttime],[app_logintime]) 
        VALUES(@app_id,@app_name,@app_license,@app_firsttime,@app_lasttime,@app_logintime);
        UPDATE [sys_application] SET [app_license] = @app_license,[app_firsttime] = (CASE WHEN [app_firsttime] > @app_lasttime THEN @app_lasttime ELSE [app_firsttime] END),[app_lasttime] = @app_lasttime,[app_logintime] = @app_logintime;";
    }
}
