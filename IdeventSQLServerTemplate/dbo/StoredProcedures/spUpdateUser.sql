CREATE PROCEDURE [dbo].[spUpdateUser]
	@UserId NVARCHAR(450),
	@UserName NVARCHAR(256),
	@Email NVARCHAR(256),
	@PhoneNumber NVARCHAR(MAX),
	@CompanyId int,

	@AddressId int = NULL,
	@StreetAddress NVARCHAR(100) = '',
	@City NVARCHAR(100) ='',
	@Country NVARCHAR(100)='',
	@PostalCode NVARCHAR(12)=''
AS
BEGIN
	UPDATE AspNetUsers
	SET
	UserName = @UserName,
	Email = @Email,
	PhoneNumber = @PhoneNumber,
	CompanyId = @CompanyId,
	AddressId = @AddressId,
	InvoiceAddressId = @AddressId
	WHERE AspNetUsers.Id = @UserId
	
	IF(@AddressId > 0)
		UPDATE Addresses
		SET
		StreetAddress = @StreetAddress,
		City = @City,
		Country = @Country,
		PostalCode = @PostalCode
		WHERE Addresses.Id = @AddressId
END
	
