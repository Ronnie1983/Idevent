CREATE PROCEDURE [dbo].[spCreateAddress]
	@street nvarchar(254),
	@city nvarchar(254),
	@postal nvarchar(50),
	@country nvarchar(50)
AS
BEGIN
	INSERT Addresses
	OUTPUT inserted.Id
	VALUES (@street,@city,@postal,@country)
END
