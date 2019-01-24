USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spPeople_Insert]    Script Date: 2019-01-24 17:43:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spPeople_Insert]
@FirstName nvarchar(100),
@LastName nvarchar(100),
@EmailAddress nvarchar(100),
@CellphoneNumber varchar(20),
@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.People(FirstName, LastName, EmailAddress, CellphoneNumber)
	values (@FirstName,@LastName,@EmailAddress,@CellphoneNumber);

	--apima veiksmus susijusius su insertinimu, ir paima paskutini panaudota ID
	select @id=SCOPE_IDENTITY();

END
GO

