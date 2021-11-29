CREATE PROCEDURE [dbo].spUpdateAddress
	@id int,
	@street nvarchar(50),
	@city nvarchar(50),
	@postal nvarchar(50),
	@country nvarchar(50)
AS
BEGIN
	UPDATE AddressModel SET StreetAddress  = @street, City = @city, PostalCode = @postal, Country = @country 
	WHERE Id = @id
END