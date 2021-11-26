CREATE PROCEDURE [dbo].spCreateProduct
	@id int,
	@name varchar(50),
	@value int,
	@standId int
AS
BEGIN
	INSERT INTO StandProducts
	OUTPUT inserted.Id
	VALUES (@id, @name, @value, @standId)
END