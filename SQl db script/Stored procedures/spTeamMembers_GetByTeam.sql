USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTeamMembers_GetByTeam]    Script Date: 2019-01-29 14:16:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spTeamMembers_GetByTeam]
@TeamId int
AS
BEGIN
	SET NOCOUNT ON;

	select  p.*
	from dbo.TeamMembers m
	inner join dbo.People p on m.PersonId = p.id
	where m.TeamId = @TeamId;

END
GO

