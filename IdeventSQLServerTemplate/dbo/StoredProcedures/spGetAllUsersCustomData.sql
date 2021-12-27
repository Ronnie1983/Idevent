CREATE PROCEDURE [dbo].[spGetAllUsersCustomData]
AS
BEGIN
	SELECT Users.Id, Users.CompanyId AS Id, Companies.Name, Users.AddressId AS Id, Users.InvoiceAddressId AS Id
	FROM AspNetUsers AS Users
	LEFT JOIN Companies ON Users.CompanyId = Companies.Id
	LEFT JOIN Addresses AS A1 ON Users.AddressId = A1.Id
	LEFT JOIN Addresses AS A2 ON Users.InvoiceAddressId = A2.Id
END
