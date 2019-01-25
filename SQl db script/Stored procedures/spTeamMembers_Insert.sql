USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTeamMembers_Insert]    Script Date: 2019-01-25 13:28:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spTeamMembers_Insert]
@TeamId int,
@PersonId int,
@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;
	
	insert into dbo.TeamMembers(TeamId, PersonId)
	values(@TeamId,@PersonId)
    
	select @id = SCOPE_IDENTITY();
END
GO

