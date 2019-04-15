USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTournaments_GetAll]    Script Date: 2019-04-15 10:28:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[spTournaments_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	select * 
	from dbo.Tournaments
	where Active = 1;

END
GO

