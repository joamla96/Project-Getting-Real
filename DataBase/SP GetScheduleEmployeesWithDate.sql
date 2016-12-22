USE [EJL86_DB]
GO
/****** Object:  StoredProcedure [db_owner].[usp_GetScheduleEmployees]    Script Date: 15/12/2016 01:15:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [db_owner].[usp_GetEmployeeScheduleWithDate](
	@ID			INT,
	@StartDate	Datetime2,
	@FinishDate	Datetime2
)
AS
	BEGIN
	SELECT * FROM Schedule_Employees 
	WHERE 
		EmployeeID = @ID 
		AND ScheduleID IN
			(
				SELECT ID FROM Schedule
				WHERE	StartDate >= @StartDate
				AND		FinishDate <= @FinishDate
			);
END