ALTER PROC [db_owner].[usp_SaveCustomer] (
	@Firstname		NVARCHAR (MAX), 
	@Lastname		NVARCHAR (MAX), 
	@Email			NVARCHAR (MAX), 
	@Phone			NVARCHAR (15),
	@HouseNo		INT,
	@FloorNo		INT,
	@Entrance		NVARCHAR (12),
	@Streetname		NVARCHAR (MAX),
	@City			NVARCHAR (MAX),
	@PostCode		INT
) 
AS
	BEGIN
		INSERT INTO Customer (Firstname,Lastname,Email,Phone,HouseNo,FloorNo,Entrance,Streetname,City,PostCode)
		VALUES (@Firstname,@Lastname,@Email,@Phone,@HouseNo,@FloorNo,@Entrance,@Streetname,@City,@PostCode)
	END
