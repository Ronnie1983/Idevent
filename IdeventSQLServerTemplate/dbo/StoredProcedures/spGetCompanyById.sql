CREATE PROCEDURE [dbo].[spGetCompanyById]
	@id int
AS
BEGIN
	SELECT C.Id, C.Name, C.CVR, C.PhoneNumber, C.Email, C.CVR, C.Note, C.Active, A.Id, A.StreetAddress,A.City, A.PostalCode, A.Country, B.Id, B.StreetAddress, B.City, B.PostalCode, B.Country
	FROM Companies AS C
	LEFT JOIN Addresses as A ON C.AddressId = A.Id
	LEFT JOIN Addresses AS B ON C.InvoiceAddressId = B.Id
	WHERE C.Id = @id
END
