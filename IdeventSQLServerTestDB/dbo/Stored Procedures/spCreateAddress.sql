CREATE PROCEDURE [dbo].[spCreateAddress]
	@street nvarchar(50),
	@city nvarchar(50),
	@postal nvarchar(50),
	@country nvarchar(50)
AS
BEGIN
	INSERT AddressModel
	OUTPUT inserted.Id
	VALUES (@street,@city,@postal,@country)
END