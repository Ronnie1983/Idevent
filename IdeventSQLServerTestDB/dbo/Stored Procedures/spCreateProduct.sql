CREATE PROCEDURE [dbo].spCreateProduct
	@name varchar(50),
	@value int,
	@standId int
AS
BEGIN
	INSERT INTO StandProducts
	OUTPUT inserted.Id
	VALUES (6, @name, @value, @standId) -- 6 default id for testing.
END