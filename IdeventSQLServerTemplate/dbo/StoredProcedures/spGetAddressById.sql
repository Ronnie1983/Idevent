CREATE PROCEDURE [dbo].[spGetAddressById]
	@id int
AS
BEGIN
	SELECT A.Id, A.StreetAddress, A.City, A.PostalCode, A.Country 
	FROM Addresses AS A
	WHERE A.Id = @id
END
