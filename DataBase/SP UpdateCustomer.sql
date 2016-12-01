ALTER PROC [db_owner].[UpdateCustomer] (
	@ID				INT,
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
	UPDATE Customer SET 
		Firstname = COALESCE(@Firstname, Firstname),
		Lastname = COALESCE(@Lastname, Lastname),
		Email = COALESCE(@Email, Email),
		Phone = COALESCE(@Phone, Phone),
		HouseNo = COALESCE(@HouseNo, HouseNo),
		Entrance = COALESCE(@Entrance, Entrance),
		Streetname = COALESCE(@Streetname, Streetname),
		City = COALESCE(@City, City),
		PostCode = COALESCE(@PostCode, PostCode)
	WHERE ID = @ID
END
