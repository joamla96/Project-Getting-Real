USE [EJL86_DB]
GO

CREATE PROC [db_owner].[usp_UpdateSchedule] (
	@ID				INT,
	@StartDate		Datetime2 = NULL, 
	@FinishDate		Datetime2 = NULL,
	@CustomerID		INT = NULL
)
AS
	BEGIN
	UPDATE Schedule SET 
	StartDate = COALESCE(@StartDate, StartDate),
	FinishDate = COALESCE(@FinishDate, FinishDate),
	CustomerID = COALESCE(@CustomerID, CustomerID);
END
