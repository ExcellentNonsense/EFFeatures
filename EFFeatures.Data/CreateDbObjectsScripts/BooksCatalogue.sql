USE [EFFeaturesNontableDb]
GO

/****** Object:  View [dbo].[BooksCatalogue]    Script Date: 06.06.2021 14:30:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[BooksCatalogue]
AS
SELECT B.Title, BT.Name AS BindingType
FROM Books AS B
LEFT JOIN BookBindingTypes AS BT ON B.BookBindingTypeId = BT.Id
GO

