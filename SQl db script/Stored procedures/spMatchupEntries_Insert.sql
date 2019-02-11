USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spMatchupEntries_Insert]    Script Date: 2019-02-11 16:19:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spMatchupEntries_Insert]
@MatchupId int,
@ParentMatchupId int,
@TeamCompetingId int,
@id int =0 output
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.MatchupEntries(MatchupId,ParentMatchupId,TeamCompetingId)
	values (@MatchupId,@ParentMatchupId,@TeamCompetingId);

	--apima veiksmus susijusius su insertinimu, ir paima paskutini panaudota ID
	select @id=SCOPE_IDENTITY();

END
GO

