CREATE PROCEDURE [dbo].[spUpdateStandName]
	@standId int,
	@name varchar(50)
AS
BEGIN
	UPDATE EventStands SET Name = @name
	WHERE EventStands.Id = @standId
END