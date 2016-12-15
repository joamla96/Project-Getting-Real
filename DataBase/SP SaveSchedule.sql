USE [EJL86_DB]
GO
/****** Object:  StoredProcedure [db_owner].[usp_SaveSchedule]    Script Date: 15/12/2016 10:50:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [db_owner].[usp_SaveSchedule] (
	@ID				INT,
	@StartDate		Datetime2, 
	@FinishDate		Datetime2,
	@CustomerID		INT
)
AS
	BEGIN
	INSERT INTO Schedule (StartDate, FinishDate, CustomerID)
	VALUES(@StartDate, @FinishDate, @CustomerID);

	SELECT SCOPE_IDENTITY() AS [LastID];
END
