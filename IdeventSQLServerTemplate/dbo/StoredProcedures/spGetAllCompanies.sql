CREATE PROCEDURE [dbo].[spGetAllCompanies]
AS
BEGIN
	SELECT C.id, C.Name, C.CVR, C.PhoneNumber, C.Email, C.CVR, C.Note, A.Id, A.StreetAddress,A.City, A.PostalCode, A.Country, B.Id, B.StreetAddress, B.City, B.PostalCode, B.Country
	FROM Companies AS C
	INNER JOIN Addresses as A ON C.AddressId = A.Id
	INNER JOIN Addresses AS B ON C.InvoiceAddressId = B.Id
END
