USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spPrizes_GetByTournament]    Script Date: 2019-04-15 10:52:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spPrizes_GetByTournament]
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

