CREATE PROCEDURE [dbo].spGetUserById
	@id int
AS
BEGIN
	SELECT U.id, U.Email ,U.Role, C.Id, A.Id, B.Id
	FROM AspNetUsers AS U
	INNER JOIN Companies AS C ON U.CompanyId = C.Id
	INNER JOIN Addresses as A ON U.AddressId = A.Id
	INNER JOIN Addresses AS B ON U.InvoiceAddressId = B.Id
	WHERE U.Id = @id
END
