USE [EJL86_DB]
GO

CREATE PROC usp_DeleteSchedule (
	@ID	INT
)
AS	
	BEGIN
	DELETE FROM Schedule_Employees WHERE ScheduleID = @ID;
	DELETE FROM Schedule WHERE ID = @ID;
END
