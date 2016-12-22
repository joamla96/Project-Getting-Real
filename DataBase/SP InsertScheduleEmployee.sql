CREATE PROC usp_InsertEmployeeSchedule (
@ScheduleID		INT,
@EmployeeID		INT
) AS
	BEGIN
	INSERT INTO Schedule_Employees (ScheduleID, EmployeeID)
	VALUES(@ScheduleID, @EmployeeID);
END