USE [EJL86_DB]
GO
/****** Object:  StoredProcedure [db_owner].[usp_GetALLEmployees]    Script Date: 07/12/2016 03:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [db_owner].[usp_GetALLEmployees]
AS
	BEGIN
	SELECT * FROM Employee
END