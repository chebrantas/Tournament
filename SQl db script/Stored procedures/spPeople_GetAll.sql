USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spPeople_GetAll]    Script Date: 2019-01-24 17:43:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spPeople_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	select * from dbo.People;

END
GO

