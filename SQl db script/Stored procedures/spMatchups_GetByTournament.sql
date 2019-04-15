USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spMatchups_GetByTournament]    Script Date: 2019-04-15 15:00:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[spMatchups_GetByTournament]
@TournamentId int
AS
BEGIN
	set nocount on;
	select m.*
	from dbo.Matchups m
	where m.TournamentId = @TournamentId
	order by MatchupRound;

END
GO

