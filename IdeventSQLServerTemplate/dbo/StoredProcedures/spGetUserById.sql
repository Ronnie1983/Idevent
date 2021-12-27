CREATE PROCEDURE [dbo].[spGetUserById]
	@userId NVARCHAR(256)
AS
BEGIN

	SELECT Users.Id, Users.UserName, Users.Email, Users.PhoneNumber, A.Id, A.StreetAddress, A.City, A.Country, A.PostalCode
	FROM AspNetUsers AS Users
	LEFT JOIN Addresses AS A ON Users.AddressId = A.Id
	--INNER JOIN AspNetUserRoles AS UserRole ON Users.Id = UserRole.UserId
	WHERE  Users.Id = @userId
END