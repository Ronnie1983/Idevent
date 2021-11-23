CREATE PROCEDURE [dbo].spCreateProduct
	@name varchar(50),
	@value int,
	@standId int
AS
BEGIN
	INSERT INTO StandProducts
	VALUES (@name, @value, @standId)
END