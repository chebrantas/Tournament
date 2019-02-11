USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spMatchups_Insert]    Script Date: 2019-02-11 15:57:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spMatchups_Insert]
@TournamentId int,
--@WinnerId int, we dont know who is winner so dont use
@MatchupRound int,
@id int =0 output
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.Matchups(TournamentId,MatchupRound)
	values (@TournamentId,@MatchupRound);

	--apima veiksmus susijusius su insertinimu, ir paima paskutini panaudota ID
	select @id=SCOPE_IDENTITY();

END
GO

