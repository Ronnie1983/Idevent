CREATE PROCEDURE [dbo].spGetUserByEmail
	@id varchar(255)
AS
BEGIN
	SELECT U.id, U.Email ,U.Role, C.Id, A.Id, B.Id
	FROM AspNetUsers AS U
	LEFT JOIN CompanyModel AS C ON U.CompanyId = C.Id
	LEFT JOIN AddressModel as A ON U.AddressId = A.Id
	LEFT JOIN AddressModel AS B ON U.InvoiceAddressId = B.Id
	WHERE U.Email = @id
END