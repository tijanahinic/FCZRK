﻿/*
Deployment script for FCZRK

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "FCZRK"
:setvar DefaultFilePrefix "FCZRK"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Creating [dbo].[Alumni]...';


GO
CREATE TABLE [dbo].[Alumni] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50)  NOT NULL,
    [LastName]    NVARCHAR (50)  NOT NULL,
    [DateOfBirth] DATE           NOT NULL,
    [ImageUrl]    NVARCHAR (50)  NULL,
    [Occupation]  NVARCHAR (100) NOT NULL,
    [Duration]    INT            NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Career]...';


GO
CREATE TABLE [dbo].[Career] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Position]    NVARCHAR (50)  NOT NULL,
    [Company]     NVARCHAR (50)  NOT NULL,
    [CompanyUrl]  NVARCHAR (50)  NOT NULL,
    [DateFrom]    DATE           NOT NULL,
    [DateTo]      DATE           NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Job]         BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Comment]...';


GO
CREATE TABLE [dbo].[Comment] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Text]        NVARCHAR (MAX) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Active]      BIT            NOT NULL,
    [DateCreated] DATE           NOT NULL,
    [ProjectId]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Info]...';


GO
CREATE TABLE [dbo].[Info] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    [Mission]      NVARCHAR (MAX) NOT NULL,
    [Vision]       NVARCHAR (MAX) NOT NULL,
    [BecomeMember] NVARCHAR (MAX) NOT NULL,
    [AboutUs]      NVARCHAR (MAX) NOT NULL,
    [AboutFax]     NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Log]...';


GO
CREATE TABLE [dbo].[Log] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Operation] NVARCHAR (50) NOT NULL,
    [ChangedBy] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Member]...';


GO
CREATE TABLE [dbo].[Member] (
    [UserId]      INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50)  NOT NULL,
    [LastName]    NVARCHAR (50)  NOT NULL,
    [MemberSince] INT            NOT NULL,
    [ImageUrl]    NVARCHAR (50)  NULL,
    [LinkedInUrl] NVARCHAR (50)  NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [SectionId]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
PRINT N'Creating [dbo].[Project]...';


GO
CREATE TABLE [dbo].[Project] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)  NOT NULL,
    [Description]     NVARCHAR (MAX) NOT NULL,
    [LogoUrl]         NVARCHAR (50)  NOT NULL,
    [Year]            INT            NOT NULL,
    [Active]          BIT            NOT NULL,
    [ProjectImagesId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[ProjectImages]...';


GO
CREATE TABLE [dbo].[ProjectImages] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[ProjectSponsor]...';


GO
CREATE TABLE [dbo].[ProjectSponsor] (
    [ProjectId] INT NOT NULL,
    [SponsorId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ProjectId] ASC, [SponsorId] ASC)
);


GO
PRINT N'Creating [dbo].[Role]...';


GO
CREATE TABLE [dbo].[Role] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Section]...';


GO
CREATE TABLE [dbo].[Section] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[Sponsor]...';


GO
CREATE TABLE [dbo].[Sponsor] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [ImageUrl]   NVARCHAR (50)  NOT NULL,
    [Text]       NVARCHAR (MAX) NOT NULL,
    [WebsiteUrl] NVARCHAR (50)  NOT NULL,
    [CategoryId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[SponsorCategory]...';


GO
CREATE TABLE [dbo].[SponsorCategory] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[User]...';


GO
CREATE TABLE [dbo].[User] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR (15) NOT NULL,
    [Password] NVARCHAR (20) NOT NULL,
    [Email]    NVARCHAR (50) NOT NULL,
    [RoleId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Comment_Project]...';


GO
ALTER TABLE [dbo].[Comment]
    ADD CONSTRAINT [FK_Comment_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Log_User]...';


GO
ALTER TABLE [dbo].[Log]
    ADD CONSTRAINT [FK_Log_User] FOREIGN KEY ([ChangedBy]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Member_Section]...';


GO
ALTER TABLE [dbo].[Member]
    ADD CONSTRAINT [FK_Member_Section] FOREIGN KEY ([SectionId]) REFERENCES [dbo].[Section] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Member_User]...';


GO
ALTER TABLE [dbo].[Member]
    ADD CONSTRAINT [FK_Member_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Project_ProjectImages]...';


GO
ALTER TABLE [dbo].[Project]
    ADD CONSTRAINT [FK_Project_ProjectImages] FOREIGN KEY ([ProjectImagesId]) REFERENCES [dbo].[ProjectImages] ([Id]);


GO
PRINT N'Creating [dbo].[FK_ProjectSponsor_Project]...';


GO
ALTER TABLE [dbo].[ProjectSponsor]
    ADD CONSTRAINT [FK_ProjectSponsor_Project] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([Id]);


GO
PRINT N'Creating [dbo].[FK_ProjectSponsor_Sponsor]...';


GO
ALTER TABLE [dbo].[ProjectSponsor]
    ADD CONSTRAINT [FK_ProjectSponsor_Sponsor] FOREIGN KEY ([SponsorId]) REFERENCES [dbo].[Sponsor] ([Id]);


GO
PRINT N'Creating [dbo].[FK_Sponsor_SponsorCategory]...';


GO
ALTER TABLE [dbo].[Sponsor]
    ADD CONSTRAINT [FK_Sponsor_SponsorCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[SponsorCategory] ([Id]);


GO
PRINT N'Creating [dbo].[FK_User_Role]...';


GO
ALTER TABLE [dbo].[User]
    ADD CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'f7009185-e113-4949-a198-d04fedea0954')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('f7009185-e113-4949-a198-d04fedea0954')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '86af438c-9a20-4dbc-a89d-f8bb344abc3c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('86af438c-9a20-4dbc-a89d-f8bb344abc3c')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Update complete.';


GO
