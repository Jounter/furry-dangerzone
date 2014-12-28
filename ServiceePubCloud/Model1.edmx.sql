
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/28/2014 16:01:42
-- Generated from EDMX file: D:\Escola\1Semestre\IS\projeto\trunk\ServiceePubCloud\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EpubBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EBookName]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChapterSet] DROP CONSTRAINT [FK_EBookName];
GO
IF OBJECT_ID(N'[dbo].[FK_LastEBookRead]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_LastEBookRead];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserChapter];
GO
IF OBJECT_ID(N'[dbo].[FK_BookmarkChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookmarkSet] DROP CONSTRAINT [FK_BookmarkChapter];
GO
IF OBJECT_ID(N'[dbo].[FK_FavoriteEBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FavoriteSet] DROP CONSTRAINT [FK_FavoriteEBook];
GO
IF OBJECT_ID(N'[dbo].[FK_FavoriteChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FavoriteSet] DROP CONSTRAINT [FK_FavoriteChapter];
GO
IF OBJECT_ID(N'[dbo].[FK_EBookStatisticsChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EBookStatisticsSet] DROP CONSTRAINT [FK_EBookStatisticsChapter];
GO
IF OBJECT_ID(N'[dbo].[FK_DateStatisticsUser_DateStatistics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DateStatisticsUser] DROP CONSTRAINT [FK_DateStatisticsUser_DateStatistics];
GO
IF OBJECT_ID(N'[dbo].[FK_DateStatisticsUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DateStatisticsUser] DROP CONSTRAINT [FK_DateStatisticsUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_EBookStatisticsUser_EBookStatistics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EBookStatisticsUser] DROP CONSTRAINT [FK_EBookStatisticsUser_EBookStatistics];
GO
IF OBJECT_ID(N'[dbo].[FK_EBookStatisticsUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EBookStatisticsUser] DROP CONSTRAINT [FK_EBookStatisticsUser_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[EBookSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EBookSet];
GO
IF OBJECT_ID(N'[dbo].[ChapterSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChapterSet];
GO
IF OBJECT_ID(N'[dbo].[BookmarkSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookmarkSet];
GO
IF OBJECT_ID(N'[dbo].[FavoriteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FavoriteSet];
GO
IF OBJECT_ID(N'[dbo].[EBookStatisticsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EBookStatisticsSet];
GO
IF OBJECT_ID(N'[dbo].[DateStatisticsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DateStatisticsSet];
GO
IF OBJECT_ID(N'[dbo].[DateStatisticsUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DateStatisticsUser];
GO
IF OBJECT_ID(N'[dbo].[EBookStatisticsUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EBookStatisticsUser];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Birthdate] datetime  NOT NULL,
    [LastLogin] datetime  NULL,
    [LastEBookRead] int  NULL,
    [LastChapterRead] int  NULL,
    [EBookStatisticsEBookStatID] int  NULL
);
GO

-- Creating table 'EBookSet'
CREATE TABLE [dbo].[EBookSet] (
    [EbookID] int IDENTITY(1,1) NOT NULL,
    [EBookName] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Publisher] nvarchar(max)  NOT NULL,
    [Subject] nvarchar(max)  NULL
);
GO

-- Creating table 'ChapterSet'
CREATE TABLE [dbo].[ChapterSet] (
    [ChapterID] int IDENTITY(1,1) NOT NULL,
    [ChapterName] nvarchar(max)  NOT NULL,
    [ChapterNumber] nvarchar(max)  NOT NULL,
    [EBookID] int  NOT NULL
);
GO

-- Creating table 'BookmarkSet'
CREATE TABLE [dbo].[BookmarkSet] (
    [BookmarkID] int IDENTITY(1,1) NOT NULL,
    [ChapterID] int  NOT NULL
);
GO

-- Creating table 'FavoriteSet'
CREATE TABLE [dbo].[FavoriteSet] (
    [FavoriteID] int IDENTITY(1,1) NOT NULL,
    [EBookID] int  NOT NULL,
    [ChapterID] int  NULL
);
GO

-- Creating table 'EBookStatisticsSet'
CREATE TABLE [dbo].[EBookStatisticsSet] (
    [EBookStatID] int IDENTITY(1,1) NOT NULL,
    [NumTimesRead] int  NOT NULL,
    [Chapter_ChapterID] int  NOT NULL
);
GO

-- Creating table 'DateStatisticsSet'
CREATE TABLE [dbo].[DateStatisticsSet] (
    [DateStatID] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'DateStatisticsUser'
CREATE TABLE [dbo].[DateStatisticsUser] (
    [DateStatistics_DateStatID] int  NOT NULL,
    [User_UserID] int  NOT NULL
);
GO

-- Creating table 'EBookStatisticsUser'
CREATE TABLE [dbo].[EBookStatisticsUser] (
    [EBookStatistics_EBookStatID] int  NOT NULL,
    [User_UserID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [UserID] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [EbookID] in table 'EBookSet'
ALTER TABLE [dbo].[EBookSet]
ADD CONSTRAINT [PK_EBookSet]
    PRIMARY KEY CLUSTERED ([EbookID] ASC);
GO

-- Creating primary key on [ChapterID] in table 'ChapterSet'
ALTER TABLE [dbo].[ChapterSet]
ADD CONSTRAINT [PK_ChapterSet]
    PRIMARY KEY CLUSTERED ([ChapterID] ASC);
GO

-- Creating primary key on [BookmarkID] in table 'BookmarkSet'
ALTER TABLE [dbo].[BookmarkSet]
ADD CONSTRAINT [PK_BookmarkSet]
    PRIMARY KEY CLUSTERED ([BookmarkID] ASC);
GO

-- Creating primary key on [FavoriteID] in table 'FavoriteSet'
ALTER TABLE [dbo].[FavoriteSet]
ADD CONSTRAINT [PK_FavoriteSet]
    PRIMARY KEY CLUSTERED ([FavoriteID] ASC);
GO

-- Creating primary key on [EBookStatID] in table 'EBookStatisticsSet'
ALTER TABLE [dbo].[EBookStatisticsSet]
ADD CONSTRAINT [PK_EBookStatisticsSet]
    PRIMARY KEY CLUSTERED ([EBookStatID] ASC);
GO

-- Creating primary key on [DateStatID] in table 'DateStatisticsSet'
ALTER TABLE [dbo].[DateStatisticsSet]
ADD CONSTRAINT [PK_DateStatisticsSet]
    PRIMARY KEY CLUSTERED ([DateStatID] ASC);
GO

-- Creating primary key on [DateStatistics_DateStatID], [User_UserID] in table 'DateStatisticsUser'
ALTER TABLE [dbo].[DateStatisticsUser]
ADD CONSTRAINT [PK_DateStatisticsUser]
    PRIMARY KEY NONCLUSTERED ([DateStatistics_DateStatID], [User_UserID] ASC);
GO

-- Creating primary key on [EBookStatistics_EBookStatID], [User_UserID] in table 'EBookStatisticsUser'
ALTER TABLE [dbo].[EBookStatisticsUser]
ADD CONSTRAINT [PK_EBookStatisticsUser]
    PRIMARY KEY NONCLUSTERED ([EBookStatistics_EBookStatID], [User_UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EBookID] in table 'ChapterSet'
ALTER TABLE [dbo].[ChapterSet]
ADD CONSTRAINT [FK_EBookName]
    FOREIGN KEY ([EBookID])
    REFERENCES [dbo].[EBookSet]
        ([EbookID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBookName'
CREATE INDEX [IX_FK_EBookName]
ON [dbo].[ChapterSet]
    ([EBookID]);
GO

-- Creating foreign key on [LastEBookRead] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_LastEBookRead]
    FOREIGN KEY ([LastEBookRead])
    REFERENCES [dbo].[EBookSet]
        ([EbookID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LastEBookRead'
CREATE INDEX [IX_FK_LastEBookRead]
ON [dbo].[UserSet]
    ([LastEBookRead]);
GO

-- Creating foreign key on [LastChapterRead] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserChapter]
    FOREIGN KEY ([LastChapterRead])
    REFERENCES [dbo].[ChapterSet]
        ([ChapterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserChapter'
CREATE INDEX [IX_FK_UserChapter]
ON [dbo].[UserSet]
    ([LastChapterRead]);
GO

-- Creating foreign key on [ChapterID] in table 'BookmarkSet'
ALTER TABLE [dbo].[BookmarkSet]
ADD CONSTRAINT [FK_BookmarkChapter]
    FOREIGN KEY ([ChapterID])
    REFERENCES [dbo].[ChapterSet]
        ([ChapterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BookmarkChapter'
CREATE INDEX [IX_FK_BookmarkChapter]
ON [dbo].[BookmarkSet]
    ([ChapterID]);
GO

-- Creating foreign key on [EBookID] in table 'FavoriteSet'
ALTER TABLE [dbo].[FavoriteSet]
ADD CONSTRAINT [FK_FavoriteEBook]
    FOREIGN KEY ([EBookID])
    REFERENCES [dbo].[EBookSet]
        ([EbookID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FavoriteEBook'
CREATE INDEX [IX_FK_FavoriteEBook]
ON [dbo].[FavoriteSet]
    ([EBookID]);
GO

-- Creating foreign key on [ChapterID] in table 'FavoriteSet'
ALTER TABLE [dbo].[FavoriteSet]
ADD CONSTRAINT [FK_FavoriteChapter]
    FOREIGN KEY ([ChapterID])
    REFERENCES [dbo].[ChapterSet]
        ([ChapterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FavoriteChapter'
CREATE INDEX [IX_FK_FavoriteChapter]
ON [dbo].[FavoriteSet]
    ([ChapterID]);
GO

-- Creating foreign key on [Chapter_ChapterID] in table 'EBookStatisticsSet'
ALTER TABLE [dbo].[EBookStatisticsSet]
ADD CONSTRAINT [FK_EBookStatisticsChapter]
    FOREIGN KEY ([Chapter_ChapterID])
    REFERENCES [dbo].[ChapterSet]
        ([ChapterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBookStatisticsChapter'
CREATE INDEX [IX_FK_EBookStatisticsChapter]
ON [dbo].[EBookStatisticsSet]
    ([Chapter_ChapterID]);
GO

-- Creating foreign key on [DateStatistics_DateStatID] in table 'DateStatisticsUser'
ALTER TABLE [dbo].[DateStatisticsUser]
ADD CONSTRAINT [FK_DateStatisticsUser_DateStatistics]
    FOREIGN KEY ([DateStatistics_DateStatID])
    REFERENCES [dbo].[DateStatisticsSet]
        ([DateStatID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_UserID] in table 'DateStatisticsUser'
ALTER TABLE [dbo].[DateStatisticsUser]
ADD CONSTRAINT [FK_DateStatisticsUser_User]
    FOREIGN KEY ([User_UserID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DateStatisticsUser_User'
CREATE INDEX [IX_FK_DateStatisticsUser_User]
ON [dbo].[DateStatisticsUser]
    ([User_UserID]);
GO

-- Creating foreign key on [EBookStatistics_EBookStatID] in table 'EBookStatisticsUser'
ALTER TABLE [dbo].[EBookStatisticsUser]
ADD CONSTRAINT [FK_EBookStatisticsUser_EBookStatistics]
    FOREIGN KEY ([EBookStatistics_EBookStatID])
    REFERENCES [dbo].[EBookStatisticsSet]
        ([EBookStatID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [User_UserID] in table 'EBookStatisticsUser'
ALTER TABLE [dbo].[EBookStatisticsUser]
ADD CONSTRAINT [FK_EBookStatisticsUser_User]
    FOREIGN KEY ([User_UserID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBookStatisticsUser_User'
CREATE INDEX [IX_FK_EBookStatisticsUser_User]
ON [dbo].[EBookStatisticsUser]
    ([User_UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------