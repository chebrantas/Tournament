USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTournamentEntries_Insert]    Script Date: 2019-01-30 16:40:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spTournamentEntries_Insert]
@TournamentId int,
@TeamId int,
@id int =0 output
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.TournamentEntries(TournamentId,TeamId)
	values (@TournamentId,@TeamId);

	--apima veiksmus susijusius su insertinimu, ir paima paskutini panaudota ID
	select @id=SCOPE_IDENTITY();

END
GO

