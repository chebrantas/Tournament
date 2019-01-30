USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTournamentPrizes_Insert]    Script Date: 2019-01-30 16:37:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spTournamentPrizes_Insert]
@TournamentId int,
@PrizeId int,
@id int =0 output
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.TournamentPrizes(TournamentId,PrizeId)
	values (@TournamentId,@PrizeId);

	--apima veiksmus susijusius su insertinimu, ir paima paskutini panaudota ID
	select @id=SCOPE_IDENTITY();

END
GO

