CREATE PROCEDURE [dbo].spUpdateAddress
	@id int,
	@street nvarchar(254),
	@city nvarchar(254),
	@postal nvarchar(254),
	@country nvarchar(254)
AS
BEGIN
	UPDATE Addresses SET StreetAddress  = @street, City = @city, PostalCode = @postal, Country = @country 
	WHERE Id = @id
END