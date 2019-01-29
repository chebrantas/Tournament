USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTeam_GetByTournament]    Script Date: 2019-01-29 14:06:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spTeam_GetByTournament]
@TournamentId int
AS
BEGIN
	SET NOCOUNT ON;

	select  t.*
	from dbo.Teams t
	inner join dbo.TournamentEntries e on t.id=e.TeamId
	where e.TournamentId = @TournamentId;

END
GO

