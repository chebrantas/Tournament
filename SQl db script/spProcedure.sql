USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spPrizesGetByTournament]    Script Date: 2019-01-21 16:57:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spPrizesGetByTournament]
@TournamentId int
AS
BEGIN
	set nocount on;
	select p.*
	from dbo.Prizes p
	inner join dbo.TournamentPrizes t on p.id=t.PrizeId
	where t.TournamentId = @TournamentId

END
GO

