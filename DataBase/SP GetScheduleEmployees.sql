USE [EJL86_DB]
GO
/****** Object:  StoredProcedure [db_owner].[usp_GetCustomer]    Script Date: 14/12/2016 01:11:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [db_owner].[usp_GetScheduleEmployees](
	@ID		INT
)
AS
	BEGIN
	SELECT * FROM Schedule_Employees WHERE ScheduleID = @ID
END