CREATE PROCEDURE [dbo].[spCreateCompany]
	@name nvarchar(50),
	@logo nvarchar(255),
	@cvr nvarchar(8),
	@email nvarchar(254),
	@phoneNumber nvarchar(30),
	@active bit,
	@note nvarchar(255),
	@addressId int,
	@invoiceAddress int
AS
BEGIN
	INSERT INTO Companies (Name, Logo, CVR, Email, PhoneNumber, Active, Note, AddressId, InvoiceAddressId)
	OUTPUT inserted.Id
	VALUES (@name, @logo, @cvr, @email, @phoneNumber, @active, @note, @addressId, @invoiceAddress)
END
