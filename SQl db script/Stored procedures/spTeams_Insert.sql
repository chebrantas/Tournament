USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTeams_Insert]    Script Date: 2019-01-25 14:09:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spTeams_Insert]
@TeamName nvarchar(100),
@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;
	insert into dbo.Teams(TeamName)
	values (@TeamName)

	select @id=SCOPE_IDENTITY();
END
GO

