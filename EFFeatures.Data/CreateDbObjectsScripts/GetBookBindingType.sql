USE [EFFeaturesNontableDb]
GO

/****** Object:  StoredProcedure [dbo].[GetBookBindingType]    Script Date: 06.06.2021 14:30:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetBookBindingType]
@BookTitle nvarchar(350)
AS
SET NOCOUNT ON;
SELECT C.BindingType
FROM BooksCatalogue AS C
WHERE C.Title = @BookTitle
GO

