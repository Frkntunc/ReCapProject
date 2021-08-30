USE [EntityDatabase]
GO

/****** Object: Table [dbo].[Brands] Script Date: 7/18/2021 9:25:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Brands] (
    [Id]   INT        NOT NULL,
    [Name] NCHAR (10) NULL
);

insert into [dbo].[Brands] ([Id],[Name])
values (5,'Toyota')


select * from Brands
