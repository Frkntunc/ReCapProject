USE [EntityDatabase]
GO

/****** Object: Table [dbo].[Cars] Script Date: 7/18/2021 9:33:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cars] (
    [Id]          INT        NOT NULL,
    [BrandId]     INT        NULL,
    [ColorId]     INT        NULL,
    [ModelYear]   INT        NULL,
    [DailyPrice]  INT        NULL,
    [Description] NCHAR (10) NULL
);

insert into [dbo].[Cars] ([BrandId],[ColorId],[ModelYear],[DailyPrice],[Description])
values (4,3,2021,250,'Mercedes Araba')

update Cars set Description='Bmw Araba' where id=2

select * from Cars

