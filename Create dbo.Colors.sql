USE [EntityDatabase]
GO

/****** Object: Table [dbo].[Colors] Script Date: 7/18/2021 9:52:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Colors] (
    [Id]   INT        IDENTITY (1, 1) NOT NULL,
    [Name] NCHAR (10) NULL
);

insert into [dbo].[Colors] ([Name])
values('Kırmızı')

select * from Colors

