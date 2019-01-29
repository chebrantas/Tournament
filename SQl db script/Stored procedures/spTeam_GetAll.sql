USE [Tournament]
GO

/****** Object:  StoredProcedure [dbo].[spTeam_GetAll]    Script Date: 2019-01-29 14:07:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






-- =============================================
--WRITE TO PRIZES TABLE STORED PROCEDURE
-- =============================================
CREATE PROCEDURE [dbo].[spTeam_GetAll]

AS
BEGIN
	SET NOCOUNT ON;

	select * from dbo.Teams;

END
GO

