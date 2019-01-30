USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTournaments_Insert]    Script Date: 2019-01-30 16:29:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[spTournaments_Insert]
@TournamentName nvarchar(50),
@EntryFee money,

@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;
	insert into dbo.Tournaments(TournamentName,EntryFee,Active)
	values (@TournamentName,@EntryFee,1)

	select @id=SCOPE_IDENTITY();
END
GO

