
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/09/2015 13:58:46
-- Generated from EDMX file: E:\Users\Ricardo\Documents\IS\Projecto\trunk\ServiceePubCloud\Model1.edmx
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

IF OBJECT_ID(N'[dbo].[FK_ChapterEBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChapterSet] DROP CONSTRAINT [FK_ChapterEBook];
GO
IF OBJECT_ID(N'[dbo].[FK_BookmarkChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookmarkSet] DROP CONSTRAINT [FK_BookmarkChapter];
GO
IF OBJECT_ID(N'[dbo].[FK_FavoriteEBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FavoriteSet] DROP CONSTRAINT [FK_FavoriteEBook];
GO
IF OBJECT_ID(N'[dbo].[FK_EBookStatisticsChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EBookStatisticsSet] DROP CONSTRAINT [FK_EBookStatisticsChapter];
GO
IF OBJECT_ID(N'[dbo].[FK_EBookStatisticsUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EBookStatisticsSet] DROP CONSTRAINT [FK_EBookStatisticsUser];
GO
IF OBJECT_ID(N'[dbo].[FK_DateStatisticsUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DateStatisticsSet] DROP CONSTRAINT [FK_DateStatisticsUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserEBook];
GO
IF OBJECT_ID(N'[dbo].[FK_UserChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserChapter];
GO
IF OBJECT_ID(N'[dbo].[FK_FavoriteChapter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FavoriteSet] DROP CONSTRAINT [FK_FavoriteChapter];
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
    [LastChapterRead] int  NULL
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
    [ChapterNumber] int  NOT NULL,
    [EBookID] int  NOT NULL
);
GO

-- Creating table 'BookmarkSet'
CREATE TABLE [dbo].[BookmarkSet] (
    [BookmarkID] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [ChapterID] int  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'FavoriteSet'
CREATE TABLE [dbo].[FavoriteSet] (
    [FavoriteID] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [EBookID] int  NOT NULL,
    [ChapterID] int  NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'EBookStatisticsSet'
CREATE TABLE [dbo].[EBookStatisticsSet] (
    [EBookStatID] int IDENTITY(1,1) NOT NULL,
    [NumTimesRead] int  NOT NULL,
    [ChapterID] int  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- Creating table 'DateStatisticsSet'
CREATE TABLE [dbo].[DateStatisticsSet] (
    [DateStatID] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [UserID] int  NOT NULL
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EBookID] in table 'ChapterSet'
ALTER TABLE [dbo].[ChapterSet]
ADD CONSTRAINT [FK_ChapterEBook]
    FOREIGN KEY ([EBookID])
    REFERENCES [dbo].[EBookSet]
        ([EbookID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChapterEBook'
CREATE INDEX [IX_FK_ChapterEBook]
ON [dbo].[ChapterSet]
    ([EBookID]);
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

-- Creating foreign key on [ChapterID] in table 'EBookStatisticsSet'
ALTER TABLE [dbo].[EBookStatisticsSet]
ADD CONSTRAINT [FK_EBookStatisticsChapter]
    FOREIGN KEY ([ChapterID])
    REFERENCES [dbo].[ChapterSet]
        ([ChapterID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBookStatisticsChapter'
CREATE INDEX [IX_FK_EBookStatisticsChapter]
ON [dbo].[EBookStatisticsSet]
    ([ChapterID]);
GO

-- Creating foreign key on [UserID] in table 'EBookStatisticsSet'
ALTER TABLE [dbo].[EBookStatisticsSet]
ADD CONSTRAINT [FK_EBookStatisticsUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBookStatisticsUser'
CREATE INDEX [IX_FK_EBookStatisticsUser]
ON [dbo].[EBookStatisticsSet]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'DateStatisticsSet'
ALTER TABLE [dbo].[DateStatisticsSet]
ADD CONSTRAINT [FK_DateStatisticsUser]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DateStatisticsUser'
CREATE INDEX [IX_FK_DateStatisticsUser]
ON [dbo].[DateStatisticsSet]
    ([UserID]);
GO

-- Creating foreign key on [LastEBookRead] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserEBook]
    FOREIGN KEY ([LastEBookRead])
    REFERENCES [dbo].[EBookSet]
        ([EbookID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEBook'
CREATE INDEX [IX_FK_UserEBook]
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

-- Creating foreign key on [UserID] in table 'BookmarkSet'
ALTER TABLE [dbo].[BookmarkSet]
ADD CONSTRAINT [FK_UserBookmark]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBookmark'
CREATE INDEX [IX_FK_UserBookmark]
ON [dbo].[BookmarkSet]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'FavoriteSet'
ALTER TABLE [dbo].[FavoriteSet]
ADD CONSTRAINT [FK_UserFavorite]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[UserSet]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserFavorite'
CREATE INDEX [IX_FK_UserFavorite]
ON [dbo].[FavoriteSet]
    ([UserID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------