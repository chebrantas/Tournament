USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spMatchupEntries_GetByMatchup]    Script Date: 2019-04-15 13:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[spMatchupEntries_GetByMatchup]
@MatchupId int
AS
BEGIN
	set nocount on;
	select *
	from dbo.MatchupEntries
	where MatchupId = @MatchupId

END
GO

