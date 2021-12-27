CREATE PROCEDURE [dbo].[spGetUserById]
	@userId NVARCHAR(256)
AS
BEGIN

	SELECT Users.Id, Users.UserName, Users.Email, Users.PhoneNumber,
	Users.CompanyId As Id,
	A.Id, A.StreetAddress, A.City, A.Country, A.PostalCode,
	A2.Id, A2.StreetAddress, A2.City, A2.Country, A2.PostalCode
	FROM AspNetUsers AS Users
	LEFT JOIN Addresses AS A ON Users.AddressId = A.Id
	LEFT JOIN Addresses AS A2 ON Users.InvoiceAddressId = A2.Id
	--INNER JOIN AspNetUserRoles AS UserRole ON Users.Id = UserRole.UserId
	WHERE  Users.Id = @userId
END