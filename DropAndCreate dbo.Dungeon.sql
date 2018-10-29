USE [TreasureHuntWebAppContext-45611804-c13a-4162-b5ba-725c460ae3b3]
GO

/****** Object: Table [dbo].[Dungeon] Script Date: 29/10/2018 19:03:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Dungeon];


GO
CREATE TABLE [dbo].[Dungeon] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [WorldID]   INT            NOT NULL,
    [Name]      NVARCHAR (MAX) NULL DEFAULT 'Pit',
    [NorthID]   INT            NULL Default 0,
    [EastID]    INT            NULL default 0,
    [SouthID]   INT            NULL default 0,
    [WestID]    INT            NULL default 0,
    [StoryLine] NVARCHAR (MAX) NULL default 'You fell in a pit.',
    [ItemID]    INT            NULL default 0
);


