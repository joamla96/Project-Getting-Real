USE [EJL86_DB]
GO
/****** Object:  StoredProcedure [db_owner].[usp_GetEmployee]    Script Date: 07/12/2016 03:18:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [db_owner].[usp_GetEmployee](
	@ID		INT
)
AS
	BEGIN
	SELECT * FROM Employee WHERE ID = @ID
END