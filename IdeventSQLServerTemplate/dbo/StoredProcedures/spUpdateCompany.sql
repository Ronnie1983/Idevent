CREATE PROCEDURE [dbo].spUpdateCompany
	@id int,
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
	UPDATE Companies 
	SET
	Name = @name,
	Logo = @logo,
	CVR = @cvr,
	Email = @email,
	PhoneNumber = @phoneNumber,
	Active = @active,
	Note = @note, 
	AddressId = @addressId, 
	InvoiceAddressId = @invoiceAddress
	WHERE Id = @id
END