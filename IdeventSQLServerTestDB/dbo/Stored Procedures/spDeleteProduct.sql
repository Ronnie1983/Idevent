CREATE PROCEDURE [dbo].[spDeleteProduct]
	@productId int
AS
BEGIN
	DELETE StandProducts
	WHERE StandProducts.Id = @productId
END