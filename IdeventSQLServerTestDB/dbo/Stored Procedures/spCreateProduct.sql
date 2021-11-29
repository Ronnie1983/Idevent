CREATE PROCEDURE [dbo].spCreateProduct
	@name varchar(50),
	@value int,
	@standId int
AS
BEGIN
	INSERT INTO StandProducts
	OUTPUT inserted.Id
	VALUES (@name, @value, @standId)
END