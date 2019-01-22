USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spPrizes_Insert]    Script Date: 2019-01-22 17:23:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spPrizes_Insert]
@PlaceNumber int,
@PlaceName nvarchar(50),
@PrizeAmount money,
@PrizePercentage float,
@id int =0 output
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.Prizes(PlaceNumber,PlaceName, PrizeAmount, PrizePercentage)
	values (@PlaceNumber,@PlaceName,@PrizeAmount,@PrizePercentage);

	--apima veiksmus susijusius su insertinimu, ir paima paskutini panaudota ID
	select @id=SCOPE_IDENTITY();

END
GO

